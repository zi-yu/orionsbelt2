using log4net;
using log4net.Config;
using OrionsBelt.Generic.Log;

namespace OrionsBelt.Generic.Log {

	public static class Logger {

		#region Fields

		private static readonly string info = "Info";
		private static readonly string debug = "Debug";
		private static readonly string warn = "Warn";
		private static readonly string error = "Error";
		private static readonly string fatal = "Fatal";

		private static readonly string unknownUser = string.Empty;

		#endregion Fields

		#region Private

		private static LogInformation CreateParameterFormater( string username1 , string username2, LogType type, string level, params object[] parameters ) {
			return new LogInformation(username1, username2, type, level, parameters);
		}

		#endregion Private

		#region Info

		public static void Info( string msg, params object[] parameters ) {
		    string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, LogType.Generic, info, message));
		}

        public static void Info( LogType type, params object[] parameters ) {
			OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, info, parameters));
		}

		public static void Info( string username2, string msg, LogType type, params object[] parameters ) {
            string message = string.Format(msg, parameters);
			OrionsBeltAppender.Append(CreateParameterFormater("",username2,type,info,message));	
		}

		#endregion Info
		
		#region Debug

		public static void Debug(LogType type, string msg, params object[] parameters ) {
		    string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, debug, message));
		}

        public static void Debug(string msg, params object[] parameters)
        {
            Debug(LogType.Generic, msg, parameters);
        }

        public static void Debug(LogType type, params object[] parameters) {
			OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, debug, parameters));
		}

		public static void Debug( string username2, string msg, LogType type, params object[] parameters ) {
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", username2, type, debug, message));	
		}

		#endregion Debug

		#region Warn

        public static void Warn(LogType type, string msg, params object[] parameters)
        {
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, warn, message));
        }

		public static void Warn( string msg, params object[] parameters ) {
            Warn(LogType.Generic, msg, parameters);
        }

		public static void Warn( LogType type, params object[] parameters ) {
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, warn, parameters));
		}

		public static void Warn( string username2, string msg, LogType type, params object[] parameters ) {
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", username2, type, warn, message));	
		}
		
		#endregion Warn
		
		#region Error

        public static void Error(LogType type, string msg, params object[] parameters)
        {
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, error, message));
        }

		public static void Error( string msg, params object[] parameters ) {
            Error(LogType.Generic, msg, parameters);
        }

		public static void Error( LogType type, params object[] parameters ) {
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, error, parameters));
		}

		public static void Error( string username2, string msg, LogType type, params object[] parameters ) {
            string message = string.Format(msg, parameters);
			OrionsBeltAppender.Append(CreateParameterFormater("",username2,type,error,message));	
		}
		
		#endregion Error
		
		#region Fatal

        public static void Fatal(LogType type,string msg, params object[] parameters)
        {
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, fatal, message));
        }

        public static void Fatal(string msg, params object[] parameters){
            Fatal(LogType.Generic, msg, parameters);
        }

        public static void Fatal(LogType type, params object[] parameters){
            OrionsBeltAppender.Append(CreateParameterFormater("", unknownUser, type, fatal, parameters));
        }

        public static void Fatal(string username2, string msg, LogType type, params object[] parameters){
            string message = string.Format(msg, parameters);
            OrionsBeltAppender.Append(CreateParameterFormater("", username2, type, fatal, message));
        }
				
		#endregion Fatal

        #region Constructor
        
        #endregion Constructor
	}
}
