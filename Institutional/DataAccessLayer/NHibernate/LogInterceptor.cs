
using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using Loki.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Proxy;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Logs NHibernate events
    /// </summary>
    public class LogInterceptor : IInterceptor {

        #region Ctor & Fields

        private bool addStackTrace = false;

        public bool AddStackTrace
        {
            get { return addStackTrace; }
            set { addStackTrace = value; }
        }

        private string outputFile;

        public string OutputFile
        {
            get { return outputFile; }
            set { outputFile = value; }
        }

        private string logPath;

        public string LogPath
        {
            get { return logPath; }
            set { logPath = value; }
        }

        public LogInterceptor(string path)
        {
            LogPath = path;
            OutputFile = GetFileName();
            LogHeader();
        }

        #endregion Ctor & Fields

        #region Log Utils

        private void LogHeader()
        {
            try {
                using (TextWriter writer = GetTextWriter()) {
                    writer.WriteLine("<NHibernateLog Date='{0}'>", DateTime.Now);
                    writer.Flush();
                }

            } catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            throw new Exception("Error writing log", ex);
        }

        public void Log(string method, string text, params object[] args)
        {
            try {

                using(TextWriter writer = GetTextWriter()) {
                    writer.Write("<Entry Principal='{3}' Method='{0}' Date='{1}' Session='{2}'>", method, DateTime.Now, GetSessionIdentifier(), GetPrincipal());
                    writer.Write("<Message>{0}</Message>", string.Format(text, args));
                    if (AddStackTrace) {
                        writer.Write("<StackTrace><![CDATA[{0}]]></StackTrace>", System.Environment.StackTrace);
                    }
                    writer.WriteLine("</Entry>");

                    writer.Flush();
                }

            } catch( Exception ex ) {
                HandleException(ex);
            }
        }

        private TextWriter GetTextWriter()
        {
            return GetTextWriterForWebApp();
        }

        private TextWriter GetTextWriterForWebApp()
        {
            return new StreamWriter(new FileStream(OutputFile, FileMode.Append));
        }

        private string GetFileName()
        {
            string path = LogPath;
            if (HttpContext.Current != null) {
                path = Path.Combine(LogPath, "Web");
            }
            string output = GetDateString();
            return Path.Combine(path, string.Format("{0}.xml", output));
        }

        private string GetSessionIdentifier()
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null) {
                return "null";
            }

            return HttpContext.Current.Session.SessionID;
        }

        private string GetDateString()
        {
            return DateTime.Now.ToString("yyyy_MM_dd___hh_mm_ss");
        }

        private string GetPrincipal()
        {
            if (HttpContext.Current == null) {
                return "console";
            }
            Principal principal = HttpContext.Current.User as Principal;
            if (principal != null) {
                return principal.Name;
            }
            return "guest";
        }

        #endregion Log Utils

        #region IInterceptor Members

        public void AfterTransactionBegin(ITransaction tx)
        {
        }

        public void AfterTransactionCompletion(ITransaction tx)
        {
        }

        public void BeforeTransactionCompletion(ITransaction tx)
        {
        }

        public int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            return null;
        }

        public object Instantiate(Type type, object id)
        {
            //Log("Instantiate", "Type `{0}' instanciated with id `{1}'", type.Name, id);
            return null;
        }

        public object IsUnsaved(object entity)
        {
            return null;
        }

        public void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            Log("OnDelete", "Entity `{0}', id:{1} deleted", entity, id);
        }

        public bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            Log("OnFlushDirty", "Entity `{0}', id:{1} has dirty flush", entity, id);
            return false;
        }

        public bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            Log("OnLoad", "Entity `{0}', id:{1} loaded", entity.GetType().Name, id);
            return false;
        }

        public bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            string entityText = "null";
            if (entity != null) {
                entityText = entity.GetType().Name;
                entityText += "-" + entity.GetType().Name;
            }
            string idText = "null";
            if (id != null) {
                idText = id.ToString();
            }
            Log("OnSave", "Entity `{0}', id:{1} saved", entityText, idText);
            return false;
        }

        public void PostFlush(System.Collections.ICollection entities)
        {
        }

        public void PreFlush(System.Collections.ICollection entities)
        {
            Log("PreFlush", "Flushing `{0}' entities", entities.Count);
        }

        public void SetSession(ISession session)
        {
            Log("SetSession", "Session changed: {0}", session.GetHashCode());
        }

        #endregion
        
       #region Extra IInterceptor Members

        public object GetEntity(string entityName, object id)
        {
            return null;
        }

        public string GetEntityName(object entity)
        {
            return null;
        }

        public object Instantiate(string entityName, EntityMode entityMode, object id)
        {
            return null;
        }

        public bool? IsTransient(object entity)
        {
            return null;
        }

        public void OnCollectionRecreate(object collection, object key)
        {
        }

        public void OnCollectionRemove(object collection, object key)
        {
        }

        public void OnCollectionUpdate(object collection, object key)
        {
        }

        public NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            return sql;
        }

        #endregion
        
    };
}
