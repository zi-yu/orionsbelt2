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
    /// Exports data from the repository
    /// </summary>
    public static class Exporter {

        #region Static Access

        /// <summary>
        /// Exports all database to the provided directory
        /// </summary>
        /// <param name="configPath">Target directory</param>
        public static void Export(string configPath)
        {
            try {

                Log.Info("Exporting data to:");
                Log.Info("- {0}", configPath);

                DatabaseConfig config = new DatabaseConfig();
                config.Date = DateTime.Now;

                List<DatabaseConfigData> data = new List<DatabaseConfigData>();
                List<ExportReport> export = new List<ExportReport>();
                string dataPath = GetDataPath(configPath);
                string bdConfigFile = Path.Combine(configPath, "DatabaseConfig.xml");
                int counter = 0;

                foreach (Type type in GetExportTypes())  {
                    string file = string.Format("{1}.{0}.xml", type.Name, GetCounterString(++counter));
                    string outputFile = Path.Combine(dataPath, file);
                    AddTypeData(data, type, file);
                    ExportReport report = ExportType(type, outputFile);
                    export.Add(report);
                }

                config.Data = data.ToArray();
                config.ExportInformation = export.ToArray();

                using (TextWriter writer = new StreamWriter(bdConfigFile)){
                    XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
                    serializer.Serialize(writer, config);
                }


            } catch( Exception ex ) {
                Log.Fatal(ex);
                throw new DALException("Error importing data from base dir {0}", ex, configPath);
            }
        }

        /// <summary>
        /// Exports a type to a XML file
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="outputFile">The target file</param>
        /// <returns>The export information</returns>
        private static ExportReport ExportType(Type type, string outputFile )
        {
            ExportReport report = new ExportReport();

            Helper.StaticTypedInvoke(typeof(Exporter), "TypedExport", type, report, outputFile);
            
            return report;
        }

        /// <summary>
        /// Exports a type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="report">The export report</param>
        /// <param name="outputFile">The output file</param>
        public static void TypedExport<T>(ExportReport report, string outputFile)
        {
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>()) {
                DateTime repositoryFetch = DateTime.Now;
                IList<T> all = persistance.Select();
                report.RepositoryFetchTime = (DateTime.Now - repositoryFetch).TotalSeconds;
                report.Count = all.Count;
                report.Entity = typeof(T).Name;

                IEntityFormatter<T> formatter = Formatter.GetByFormat<T>(FormatName);
                using (TextWriter writer = new StreamWriter(outputFile)) {
                    formatter.Export(writer, all);
                }
                
            }
        }

        /// <summary>
        /// The formater to use
        /// </summary>
        private static string FormatName {
            get { return "Xml"; }
        }

        #endregion Static Access

        #region Utils

        /// <summary>
        /// Returns a nice counter string
        /// </summary>
        /// <param name="counter">The counter</param>
        /// <returns>The string representation</returns>
        private static string GetCounterString(int counter)
        {
            string str = counter.ToString();
            return str.PadLeft(4, '0');
        }

        /// <summary>
        /// Gets the data dir fot the entity's files
        /// </summary>
        /// <param name="configPath">The base dir</param>
        /// <returns>The path</returns>
        private static string GetDataPath(string configPath)
        {
            string dataPath = Path.Combine(configPath, "Data");
            if (!Directory.Exists(dataPath)) {
                Directory.CreateDirectory(dataPath);
            }
            return dataPath;
        }

        /// <summary>
        /// Adds the type's data to the container
        /// </summary>
        /// <param name="data">The container</param>
        /// <param name="type">The type</param>
        private static void AddTypeData(IList<DatabaseConfigData> data, Type type, string file)
        {
            DatabaseConfigData typeData = new DatabaseConfigData();

            typeData.EntityName = type.Name;
            typeData.File = string.Format("Data/{0}", file);
            typeData.Format = FormatName;

            data.Add(typeData);
        }

        /// <summary>
        /// The types to export
        /// </summary>
        /// <returns>The types</returns>
        private static IEnumerable<Type> GetExportTypes()
        {
            return Persistance.GetPersistableTypes();
        }

        #endregion Utils

    };
}
