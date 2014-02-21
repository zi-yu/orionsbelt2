using System.IO;
using System.Xml.XPath;

namespace BotHandler {
	public static class XPathUtils {

		#region Public

        public static XPathNavigator GetNavigator(string data){
            StringReader reader = new StringReader(data);
            XPathDocument doc = new XPathDocument(reader);
            return doc.CreateNavigator();
        }

		public static string Get(XPathNavigator nav, string xpath) {
			XPathNodeIterator iter = nav.Select(xpath);
			iter.MoveNext();
			return iter.Current.Value;
		}

        public static string Get(XPathNodeIterator nav, string xpath){
			XPathNodeIterator iter = nav.Current.Select(xpath);
			iter.MoveNext();
			return iter.Current.Value;
		}

		public static int GetInt(XPathNavigator nav, string xpath) {
			XPathNodeIterator iter = nav.Select(xpath);
			iter.MoveNext();
			return int.Parse(iter.Current.Value);
		}

        public static int GetInt(XPathNodeIterator nav, string xpath){
			XPathNodeIterator iter = nav.Current.Select(xpath);
			iter.MoveNext();
			return int.Parse(iter.Current.Value);
		}

		public static string GetAttribute(XPathNodeIterator nav, string attribute) {
			return nav.Current.GetAttribute(attribute, string.Empty);
		}

		public static int GetAttributeInt(XPathNodeIterator nav, string attribute) {
			return int.Parse(nav.Current.GetAttribute(attribute, string.Empty));
		}

        public static bool GetAttributeBool(XPathNodeIterator nav, string attribute){
            return bool.Parse(nav.Current.GetAttribute(attribute, string.Empty));
        }

		#endregion Public

	}
}
