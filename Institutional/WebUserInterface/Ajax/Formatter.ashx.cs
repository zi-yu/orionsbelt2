
using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using System.Collections;
using System.Reflection;
using Loki.Generic.Formatting;
using Loki.DataRepresentation;

using Institutional.Core;
using Institutional.WebComponents;
using Institutional.WebUserInterface;

namespace Institutional.DataAccessLayer.Controls {

    /// <summary>
    /// AJAX formatter handler
    /// </summary>
    public class FormatterHandler : IHttpHandler {

        #region Properties

        private HttpContext context;
        public HttpContext Context {
            get { return context; }
            set { context = value; }
        }

        public string Entity {
            get { return GetParam(Context, "type"); }
        }

        public string TypeName {
            get {
                string fullName = string.Format("Sms.Core.{0}, Sms.Core", Entity);
                return fullName;
            }
        }

        public string FormatType {
            get { return GetParam(Context, "format"); }
        }

        public int CurrentId {
            get { return int.Parse(GetParam(Context, "id")); }
        }

        #endregion Properties

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            Context = context;
            Type type = Type.GetType(TypeName, true);
            MethodInfo method = typeof(FormatterHandler).GetMethod("Format");
            method = method.MakeGenericMethod(type);
            method.Invoke(this, null);
        }

        private static string GetParam(HttpContext context, string name)
        {
            string param = context.Request.QueryString[name];
            if (param == null) {
                throw new UIException("NO '{0}' at query string", name);
            }
            return param;
        }

        public void Format<T>()
        {
            IEntityFormatter<T> formatter = Formatter.GetByFormat<T>(FormatType);

            context.Response.ContentType = formatter.ContentType;
            T entity = GetEntity<T>();

            TextWriter writer;
            using (writer = new StringWriter()){
                formatter.Export(writer, entity);
            }

            context.Response.Write(writer.ToString());
            
        }

        private T GetEntity<T>()
        {
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>()) {
                return persistance.Select(CurrentId);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

	};
}