using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace OrionsBelt.WebComponents {
    public class FacebookRestMethod {
    
		#region Fields
		
		protected string method;
		protected List<FacebookRestParameter> parameters;
		
		#endregion Fields

        #region Properties

        public string Method { 
			get { return method;}
			set { method = value;} 
		}

        public List<FacebookRestParameter> Parameters { 
			get { return parameters;}
			set { parameters = value; }
		}

        #endregion Properties

        #region Private

        private string GetMD5Hash(string value) {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(value);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs) {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        #endregion

        #region Public

        public void AddParameter(string name, string value) {
            AddParameter(new FacebookRestParameter(name, value));
        }

        public void AddParameter(FacebookRestParameter parameter) {
            Parameters.Add(parameter);
        }

        public string GetSig() {
            StringWriter writer = new StringWriter();
            Parameters.Sort(FacebookRestParameterComparer.Instance);

            foreach (FacebookRestParameter parameter in Parameters) {
                writer.Write(parameter.ToString());
            }
            writer.Write(FacebookSession.ApplicationSecret);
            return GetMD5Hash(writer.ToString()).ToLower();
        }

        public string GetPostData() {
            StringWriter writer = new StringWriter();
            bool first = true;
            foreach (FacebookRestParameter parameter in Parameters) {
                if (first) {
                    writer.Write("{0}={1}", parameter.Name, parameter.Value);
                    first = false;
                } else {
                    writer.Write("&{0}={1}", parameter.Name, parameter.Value);    
                }
            }
            return writer.ToString();
        }

        #endregion Public

        #region Constructor

        public FacebookRestMethod(string method) {
            Method = method;
            Parameters = new List<FacebookRestParameter>();
            AddParameter("method", method);
        }

        #endregion Constructor

    }
}
