using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Log;
using System.Web;

namespace OrionsBelt.Generic {

    /// <summary>
    /// Server generic properties and status
    /// </summary>
    public static class Server {

		#region Instance Fields

		private static bool isInTests = false;
		private static bool isChronos = false;

		#endregion Instance Fields

		#region Singleton Instance

        private static object sync = new object();

        static Server()
        {
            lock (sync){
                PrepareProperties();
                PrepareServer();
            }
        }

		private static ServerProperties properties = null;
        public static ServerProperties Properties {
            get { 
                return properties; 
            }
        }

        private static void PrepareServer()
        {
            UsingInProcClock = Properties.UseWebClock;
        }

        private static void PrepareProperties()
        {
            ServerProperties props = GetPropertiesFromDB();
            if (props == null) {
                props = BootstrapProperties();
            }
            properties = props;
        }

        private static ServerProperties BootstrapProperties()
        {
            using (IServerPropertiesPersistance persistance = Persistance.Instance.GetServerPropertiesPersistance()){
                ServerProperties props = persistance.Create();
                props.CurrentTick = 1;
                props.MillisPerTick = 600000;
                props.VacationTicksPerWeek = 1000;
                props.CreatedDate = DateTime.Now;
                props.Running = true;
                props.UseWebClock = true;
                props.Name = "Dev";
                props.BaseUrl = "http://change_me_at_ServerProperties/";
                props.MaxPlayers = 100;
                Persist(persistance, props);
                return props;
            }
        }

        private static void Persist(IServerPropertiesPersistance persistance, ServerProperties props)
        {
            try {

                persistance.Update(props);
                persistance.Flush();

            } catch (Exception ex) {
                Logger.Error("*** Error persisting server properties");
                Logger.Error(ex.ToString());
                throw;
            }
        }

        private static ServerProperties GetPropertiesFromDB()
        {
            try {
                using (IServerPropertiesPersistance persistance = Persistance.Instance.OpenServerPropertiesPersistance()){
                    IList<ServerProperties> props = persistance.Select();
                    if (props.Count == 1){
                        return props[0];
                    }
                    return null;
                }
            } catch( Exception ex ) {
                Logger.Error("*** Error getting server properties from Database");
                Logger.Error(ex.ToString());
                throw;
            }
        }

        #endregion Singleton Instance

        #region Utility Properties

        private static bool usingInProcClock = true;
        public static bool UsingInProcClock {
            get {
                return usingInProcClock;
            }
            set {
                usingInProcClock = value;
            }
        }

		public static bool IsInTests {
			get {
				return isInTests;
			}
			set {
				isInTests = value;
			}
		}

		public static bool IsChronos {
			get { return isChronos; }
			set { isChronos = value; }
		}


        public static bool IsWeb {
            get { return HttpContext.Current != null; }
        }

        public static bool IsDev {
            get { 
                return Properties.Name == "Dev" || Properties.Name == "Alpha";
            }
        }

    	#endregion Utility Properties

        #region Utility Methods

        public static void Persist(int tick, DateTime date)
        {
            using (IServerPropertiesPersistance persistance = Persistance.Instance.OpenServerPropertiesPersistance()) {
                persistance.StartTransaction();
                Properties.CurrentTick = tick;
                Properties.LastTickDate = date;
                persistance.Update(Properties);
                persistance.CommitTransaction();
            }
        }

        public static void Persist()
        {
            using (IServerPropertiesPersistance persistance = Persistance.Instance.GetServerPropertiesPersistance()) {
                persistance.StartTransaction();
                persistance.Update(Properties);
                persistance.CommitTransaction();
            }
        }

        public static void Refresh()
        {
            lock (sync) {
                Persistance.RefreshEntity(Properties);
            }
        }

        #endregion Utility Methods

    };
}
