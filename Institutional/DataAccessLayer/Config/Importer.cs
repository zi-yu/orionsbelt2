using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Loki.Generic;
using Loki.Generic.Formatting;
using Loki.DataRepresentation;

namespace Institutional.DataAccessLayer {

    /// <summary>
    /// Imports data from configuration files to the database
    /// </summary>
    public static class Importer {

        #region Static Properties

        /// <summary>
        /// The database configuration base dir
        /// </summary>
        public static string BaseDir {
            get { return baseDir; }
            set { baseDir = value; }
        }
        private static string baseDir;

        /// <summary>
        /// Gets the location of DatabaseConfig.xml
        /// </summary>
        public static string DatabaseConfigFile {
            get { return Path.Combine(BaseDir, "DatabaseConfig.xml"); }
        }

        private static bool addValidators = false;

        /// <summary>
        /// Tells if this importer will add validation to the import
        /// </summary>
        public static bool AddValidators {
            get { return addValidators; }
            set { addValidators = value; }
        }

        #endregion Static Properties

        #region Stats

        public class EntityStats {
            public TimeSpan Duration = TimeSpan.Zero;
            public string EntityName = string.Empty;
            public int EntityCount = 0;
        };

        public static Dictionary<string, EntityStats> Stats = new Dictionary<string, EntityStats>();

        #endregion Stats

        #region Static Access

        /// <summary>
        /// Imports all files defined in DatabaseConfig.xml
        /// </summary>
        public static void Import(string configPath)
        {
            try {

                Stats.Clear();
                BaseDir = configPath;

                Log.Info("Importing data from:");
                Log.Info("- {0}", DatabaseConfigFile);

                DatabaseConfig config = GetDatabaseConfig(DatabaseConfigFile);

                if (config == null) {
                    throw new Exception("Null configuration file");
                }

                if (config.Data == null || config.Data.Length == 0) {
                    Log.Warn("No data to import");
                    return;
                }

                foreach (DatabaseConfigData data in config.Data) {
                    Import(data);
                }

            } catch( Exception ex ) {
                Log.Fatal(ex);
                throw new DALException("Error importing data from base dir {0}", ex, configPath);
            }
        }

        /// <summary>
        /// Imports data from a specific file
        /// </summary>
        /// <param name="data">The import data</param>
        public static void Import(DatabaseConfigData data)
        {
            string file = Path.Combine(BaseDir, data.File);
            Log.Debug("- Importing file {0}", file, data.Format, data.EntityName);

            using (TextReader reader = new StreamReader(file)) {
                Type type = Type.GetType(GetTypeName(data), true);
                MethodInfo method = typeof(Importer).GetMethod("TypedImport");
                method = method.MakeGenericMethod(type);
                method.Invoke(null, new object[] { reader, data.Format });
            }
        }

        /// <summary>
        /// Imports data into the entity repository
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="reader">The data source</param>
        public static void TypedImport<T>(TextReader reader, string format) where T : IEntity
        {
            DateTime start = DateTime.Now;
            IEntityFormatter<T> formatter = Formatter.GetByFormat<T>(format);
            List<T> list = new List<T>();

            formatter.Import(reader, list);
            Log.Debug("  - Entities loaded: {0}", list.Count);

            AddToDatabase<T>(list);
            AddToStats(start, list);
        }

        /// <summary>
        /// Adds import information to Stats
        /// </summary>
        /// <param name="start">The start time</param>
        /// <param name="list">The list</param>
        private static void AddToStats<T>(DateTime start, IList<T> list)
        {
            string name = typeof(T).Name;
            DateTime end = DateTime.Now;
            TimeSpan duration = end - start;
            
            EntityStats es = null;
            
            if( !Stats.ContainsKey(name) ){
                es = new EntityStats();
                es.EntityName = name;
                Stats.Add(name, es);
            } else {
                es = Stats[name];
            }

            es.Duration = es.Duration.Add(duration);
            es.EntityCount += list.Count;
        }

        #endregion Static Access

        #region Static Utils

        /// <summary>
        /// Adds entities to database
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="list">The entity list</param>
        public static void AddToDatabase<T>(List<T> list) where T : IEntity
        {
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>()) {
                if (AddValidators) {
                    persistance.AddValidators();
                }
                foreach (T entity in list) {
                    if (!Exists<T>(persistance, entity)) {
                        persistance.ResetEntity(entity);
                    }
                    persistance.Update(entity);
                }
                persistance.Flush();
            }
        }

        /// <summary>
        /// Checks if the entity already exists in the repository
        /// </summary>
        /// <param name="persistance">The persistance</param>
        /// <param name="entity">The entity</param>
        /// <returns>True if exists</returns>
        private static bool Exists<T>(IPersistance<T> persistance, IEntity entity)
        {
            return Persistance.Exists(entity);
        }

        /// <summary>
        /// Returns the type name for a given entity
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The type name</returns>
        private static string GetTypeName(DatabaseConfigData data)
        {
            return string.Format("Institutional.Core.{0}, Institutional.Core", data.EntityName); 
        }

        /// <summary>
        /// Generates an example of DatabaseConfig.xml
        /// </summary>
        /// <param name="outputFile">The output file</param>
        public static void GenerateSampleConfig(string outputFile)
        {
            DatabaseConfig config = new DatabaseConfig();

            List<DatabaseConfigData> data = new List<DatabaseConfigData>();
            
            data.Add( GetSampleConfigData("PrincipalAdmins.xml", "Principal", "Xml") );
            data.Add( GetSampleConfigData("Roles.xml", "Role", "Xml") );
            data.Add( GetSampleConfigData("Other.xml", "Principal", "Xml") );

            config.Data = data.ToArray();

            XmlSerializer serializer = new XmlSerializer(config.GetType());

            using( StreamWriter writer = new StreamWriter(outputFile) ) {
                serializer.Serialize(writer, config);
            }
        }

        /// <summary>
        /// Gets a config object
        /// </summary>
        /// <param name="fileName">The file</param>
        /// <param name="entityName">The entity</param>
        /// <param name="format">The format</param>
        /// <returns>The config object</returns>
        private static DatabaseConfigData GetSampleConfigData(string fileName, string entityName, string format)
        {
            DatabaseConfigData file = new DatabaseConfigData();

            file.EntityName = entityName;
            file.Format = format;
            file.File = fileName;

            return file;
        }

        /// <summary>
        /// Gets the database config object
        /// </summary>
        /// <returns>The DatabaseConfig</returns>
        private static DatabaseConfig GetDatabaseConfig(string configPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
            using (StreamReader reader = new StreamReader(DatabaseConfigFile)) {
                object obj = serializer.Deserialize(reader);
                return (DatabaseConfig)obj;
            }
        }

        #endregion Static Utils

    };
}
