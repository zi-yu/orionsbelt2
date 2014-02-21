using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;

namespace OrionsBelt.WebComponents {

    [XmlRoot("Users_getInfo_response", Namespace = "http://api.facebook.com/1.0/")]
    public class FacebookUserArray {

        #region Fields

        private List<FacebookUser> facebookUser;

        #endregion Fields

        #region Properties

        [XmlElement("user", Namespace = "http://api.facebook.com/1.0/")]
        public List<FacebookUser> FacebookUsers {
            get { return facebookUser; }
            set { facebookUser = value; }
        }

        #endregion Properties
    }
}
