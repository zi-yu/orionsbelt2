
using System;
using System.Text;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Generic.Log {

	internal class LogInformation {

		#region Fields

		private readonly LogStorage log;
		private static readonly string url = "Unknown Url";

		#endregion Fields

		#region Private

		/// <summary>
		/// Obtains the value of the content. If the object implements ILog, then the log information is retrieved.
		/// Else, it's applied the ToString Method.
		/// </summary>
		/// <param name="o">Object from which the content must be obtained</param>
		/// <returns>The content represented in a string</returns>
		private static string GetContentInformation( object o ) {
			if( o is ILogger ) {
				return ( (ILogger) o ).Log();
			}
			return o.ToString();
		}

		/// <summary>
		/// Obtains the information an exception
		/// </summary>
		/// <param name="o">Object that represents the exception</param>
		/// <returns>The information of the exception in a strign format</returns>
		private static string GetExceptionInformation( object o ) {
			Exception exception = (Exception) o;
			StringBuilder builder = new StringBuilder();

			builder.AppendFormat("\nException Name: {0}", exception);
			builder.AppendFormat("\nException Message: {0}", exception.Message);
			builder.AppendFormat("\nException Stack Trace: {0}", exception.StackTrace);
			builder.AppendFormat("\nException Source: {0}", exception.Source);

			if( exception.InnerException != null ) {
				builder.AppendFormat("\nInnerException Name: {0}", exception.InnerException);
				builder.AppendFormat("\nInnerException Message: {0}", exception.InnerException.Message);
				builder.AppendFormat("\nInnerException Stack Trace: {0}", exception.InnerException.StackTrace);
				builder.AppendFormat("\nInnerException Source: {0}\n", exception.InnerException.Source);
			}

			return builder.ToString();
		}

		/// <summary>
		/// Parses the parameters and creates a log object
		/// </summary>
		/// <param name="parameters">Parameters to pass</param>
		private void Parse( object[] parameters ) {
			StringBuilder content = new StringBuilder();
			StringBuilder exceptions = new StringBuilder();
			foreach( object o in parameters ) {
				if( o is Exception ) {
					exceptions.AppendFormat("\n{0}", GetExceptionInformation(o));
				}else {
					content.AppendFormat("\n{0}", GetContentInformation(o));
				}
			}

			log.Content = content.ToString();
			log.ExceptionInformation = exceptions.ToString();
		}

		/// <summary>
		/// Obtains the url of the current request, if exists.
		/// </summary>
		private static string GetUrl() {
			HttpContext context = HttpContext.Current;
			if( context != null ) {
				return context.Request.Url.AbsoluteUri;
			}
			return url;
		}

		#endregion Private

		#region Public

		public LogStorage GetLogStorage() {
			return log;
		}

		#endregion Public

		#region Object Implementation

		public override string ToString() {
			StringBuilder builder = new StringBuilder();

			builder.AppendFormat("\n[Level] {0}", log.Level);
			builder.AppendFormat("\n[Date] {0}", log.Date);
			builder.AppendFormat("\n[Url] {0}", log.Date);
			builder.AppendFormat("\n[Username1] {0}", log.Username1);
			builder.AppendFormat("\n[Username2] {0}", log.Username2);
			builder.AppendFormat("\n[Type] {0}", log.Type);
			builder.AppendFormat("\n[Content] {0}", log.Content);
			builder.AppendFormat("\n[Exception] {0}", log.ExceptionInformation);
			
			return builder.ToString();
		}

		#endregion Object Implementation

		#region Constructor

		public LogInformation( string username1, string username2, LogType type, string level, params object[] parameters ) {
			using( ILogStoragePersistance p = Persistance.Instance.GetLogStoragePersistance() ) {
				log = p.Create();
			}

			log.Level = level;
			log.Date = DateTime.Now;
			log.Url = GetUrl();
			log.Username1 = username1;
			log.Username2 = username2;
			log.Type = type.ToString();
			log.Level = level;

			Parse(parameters);
		}

		#endregion Constructor
	}
}
