using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Institutional.DataAccessLayer {

      /// <summary>
    /// Export report
    /// </summary>
    public class ExportReport {

        #region Fields

        private string entity;
        [XmlAttribute()]
        public string Entity {
            get { return entity; }
            set { entity = value; }
        }

        private int entityCount;
        [XmlAttribute()]
        public int Count {
            get { return entityCount; }
            set { entityCount = value; }
        }

        private double repositoryFetchTime;
        [XmlAttribute()]
        public double RepositoryFetchTime {
            get { return repositoryFetchTime; }
            set { repositoryFetchTime = value; }
        }
	
        #endregion Fields

    };

    /// <summary>
    /// Configuration data for a specific file
    /// </summary>
    public class DatabaseConfigData {

        #region Fields

        private string file;
        [System.Xml.Serialization.XmlAttribute()]
        public string File {
            get { return file; }
            set { file = value; }
        }

        private string entityName;
        [System.Xml.Serialization.XmlAttribute()]
        public string EntityName {
            get { return entityName; }
            set { entityName = value; }
        }

        private string format;
        [System.Xml.Serialization.XmlAttribute()]
        public string Format {
            get { return format; }
            set { format = value; }
        }

        #endregion Fields

    };

    /// <summary>
    /// Represents config information for the Importer
    /// </summary>
    public class DatabaseConfig {

        #region Fields

        private DateTime date;
        public DateTime Date {
            get { return date; }
            set { date = value; }
        }

        private ExportReport[] exportInformation;
        public ExportReport[] ExportInformation {
            get { return exportInformation; }
            set { exportInformation = value; }
        }

        private DatabaseConfigData[] data;
        public DatabaseConfigData[] Data {
            get { return data; }
            set { data = value; }
        }

        #endregion Fields

    };
}
