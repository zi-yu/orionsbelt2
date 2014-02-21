
using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Modules {

	/// <summary>
    /// Logs NHibernate SQL queries
    /// </summary>
	public class QueryCounterLog : IHttpModule {

        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            if (!NHibernateUtilities.IncludeStats) {
                return;

            }
            Logger logger = (Logger)LogManager.GetLogger("NHibernate.SQL").Logger;
            logger.Repository.Threshold = Level.Verbose; 
            lock (logger){
                if (HasCountingAppender(logger) == false) {
                    logger.AddAppender(new CountToContextItemsAppender());
                    logger.Level = logger.Hierarchy.LevelMap["DEBUG"];
                }
            }
        }

        public void Dispose()
        {
        }

        #endregion

        #region Private

        private static bool HasCountingAppender(IAppenderAttachable logger)
        {
            foreach (IAppender appender in logger.Appenders)  {
                if (appender is CountToContextItemsAppender)
                    return true;
            }
            return false;
        }

        #endregion Private

        #region Nested type: CountToContextItemsAppender

        public class CountToContextItemsAppender : IAppender  {

            #region IAppender Members

            public void Close()
            {
            }

            public void DoAppend(LoggingEvent loggingEvent)
            {
                if (loggingEvent.MessageObject != null) {
                    StatsInterceptor.Instance.RegisterSql(loggingEvent.MessageObject.ToString());
                }
            }

            private string name;
            public string Name  {
                get { return name; }
                set { name = value; }
            }

            #endregion
        }

        #endregion
    
    };

}
