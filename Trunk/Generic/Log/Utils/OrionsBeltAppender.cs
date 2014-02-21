using log4net.Appender;
using log4net.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Generic.Log {

	/// <summary>
	/// Appends logging events to the Database.
	/// </summary>
	public class OrionsBeltAppender {
		
		#region Public

		/// <summary>
		/// This method is called by the <see cref="AppenderSkeleton.DoAppend(LoggingEvent)"/> method.
		/// </summary>
        /// <param name="loggingInfo">The event to log.</param>
        internal static void Append(LogInformation loggingInfo){ 
			using( ILogStoragePersistance persistance = Persistance.Instance.OpenLogStoragePersistance() ) {
				LogInformation logInformation = loggingInfo;
				persistance.Update(logInformation.GetLogStorage());
                persistance.Flush();
			}
        }

        #endregion Public
    }
}
