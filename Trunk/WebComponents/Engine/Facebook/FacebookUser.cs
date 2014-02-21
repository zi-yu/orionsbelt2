using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;

namespace OrionsBelt.WebComponents {

    [XmlType("user")]
    public class FacebookUser {

        #region Fields

        private long uid;
        private string firstName;
        private string lastName;
        private string avatar;
        private string locale;
        private string email;
        private string url;

        #endregion Fields

        #region Properties

        [XmlElement("uid")]
        public long Id {
            get { return uid; }
            set { uid = value; }
        }

        [XmlElement("first_name")]
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        [XmlElement("last_name")]
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        [XmlElement("locale")]
        public string Locale {
            get { return locale; }
            set { locale = value; }
        }

        [XmlElement("pic_square")]
        public string Avatar {
            get { return avatar; }
            set { avatar = value; }
        }

        [XmlElement("contact_email")]
        public string Email {
            get { return email; }
            set { email = value; }
        }

        [XmlElement("website")]
        public string Url {
            get { return url; }
            set { url = value; }
        }

        #endregion Properties
    }
}
