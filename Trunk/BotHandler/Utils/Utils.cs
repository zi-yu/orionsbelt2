using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Xml.XPath;
using BotHandler.Engine;

namespace BotHandler {
	public static class Utils {

		#region Private

		
		#endregion Private 

        #region Properties

        public static string Bot001Id{
            get{
				return "2066965";
            }
        }

	    public static string Bot001VerificationCode{
	        get{
				return "74F198630863B0822787D708C383C19130A18D41";
            }
	    }

        #endregion

		#region Public

		public static XPathNavigator GetNavigator(string data) {
			return XPathUtils.GetNavigator(data);
		}

		public static IEnumerable<Battle> GetBattle(string data) {
			XPathNavigator nav = GetNavigator(data);
			XPathNodeIterator n = nav.Select("Battles/Battle");
			while(n.MoveNext()) {
				yield return new Battle(n);
			}
		}

        public static string GetResponse( IAsyncResult ar  ){
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
		    return reader.ReadToEnd();
        }

		public static string GetResponse(WebResponse webResponse) {
			StreamReader reader = new StreamReader(webResponse.GetResponseStream());
			return reader.ReadToEnd();
        }

		#endregion Public


	}
}
