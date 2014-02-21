using System.Collections.Generic;
using System.Web;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class RaceDropDown : ControlBase
    {
        private string browserID;

        public string BrowserID
        {
            get { return browserID; }
            set { browserID = value; }
        }

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            Dictionary<string,string> resor = new Dictionary<string, string>(4);
            resor.Add("", ""); 
            resor.Add(LanguageManager.Instance.Get("Bugs"), "512");
            resor.Add(LanguageManager.Instance.Get("DarkHumans"), "256");
            resor.Add(LanguageManager.Instance.Get("Humans"), "128");

            string arg = HttpContext.Current.Request.Form[browserID];
            string arg2 = HttpContext.Current.Request.Form["searchChange"];

            if (arg2 != "1" && State.Session["AuctionSearchRace"] != null)
            {
                arg = State.Session["AuctionSearchRace"].ToString();
            }

			Write("<select name={0} id='{0}' class='styled'>", browserID);
            WriteOptions(resor, arg);
            Write("</select>");
        }

        private void WriteOptions(IEnumerable<KeyValuePair<string, string>> resor, string arg)
        {
            foreach (KeyValuePair<string, string> info in resor)
            {
                if (arg == info.Value || arg == info.Key)
                {
                    Write("<option selected='selected' value='{0}'>{1}</option>", info.Value, info.Key);
                }
                else
                {
                    Write("<option value='{0}'>{1}</option>", info.Value, info.Key);
                }
            }
        }
    }
}
