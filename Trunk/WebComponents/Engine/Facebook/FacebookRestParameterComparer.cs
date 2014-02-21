using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace OrionsBelt.WebComponents {
    public class FacebookRestParameterComparer : IComparer<FacebookRestParameter> {

        #region Fields

        private static FacebookRestParameterComparer f = new FacebookRestParameterComparer();

        #endregion Fields

        #region Properties

        public static FacebookRestParameterComparer Instance { 
            get {
                return f;
            } 
        }

        #endregion

        #region IComparer<FacebookRestParameter> Members

        public int Compare(FacebookRestParameter x, FacebookRestParameter y) {
            return x.Name.CompareTo(y.Name);
        }

        #endregion IComparer<FacebookRestParameter> Members

        #region Constructor

        private FacebookRestParameterComparer() { }

        #endregion Constructor
    }
}
