using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace OrionsBelt.WebComponents {
    public class FacebookRestParameter {
    
		#region Fields
		
		protected string name;
		protected string restValue;
		protected bool sigValid;
		
		#endregion Fields

        #region Properties

        public string Name { 
			get { return name;}
			set { name = value;} 
		}

        public string Value { 
			get { return restValue;}
			set { restValue = value;} 
        }

        public bool SigValid { 
			get { return sigValid;}
			set { sigValid = value;}  
		}

        #endregion Properties

        #region Public

        public override string ToString() {
            return string.Format("{0}={1}", Name, Value);
        }

        public string ToXML() {
            return string.Format("<{0}>{1}</{0}>", Name, Value);
        }

        #endregion Public

        #region Constructor

        public FacebookRestParameter(string name, string value) 
            : this(name,value,true){}

        public FacebookRestParameter(string name, string value, bool sigvalid) {
            Name = name;
            Value = value;
            SigValid = sigvalid;
        }

        #endregion Constructor

    }
}
