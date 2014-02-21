using System;
using System.Xml.Serialization;

namespace OrionsBelt.WebComponents {

	/// <summary>
    /// Twitter OAuth information
    /// </summary>
    [XmlType("user")]
    public class TwitterInfo {

        [XmlElement("screen_name")]
        public string UserName { 
			get { return username; }
			set { username = value; }
        }
        private string username;

        [XmlElement("url")]
        public string Url {
			get { return url; }
			set { url = value; }
        }
        private string url;

        [XmlElement("profile_image_url")]
        public string Avatar { 
			get { return avatar; }
			set { avatar = value; }
        }
        private string avatar;
       
    };
    
}
