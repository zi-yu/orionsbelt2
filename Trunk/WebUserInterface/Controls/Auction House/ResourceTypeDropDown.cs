using System.Collections.Generic;
using System.Web;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ResourceTypeDropDown : ControlBase
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

            Dictionary<string,int> resor = new Dictionary<string, int>(2);
            resor.Add(LanguageManager.Instance.Get("Intrinsic"), 1); 
            resor.Add(LanguageManager.Instance.Get("Rare"), 2);

            Dictionary<string, int> units = new Dictionary<string, int>(5);
            units.Add(LanguageManager.Instance.Get("Ships"), 4);
            units.Add(LanguageManager.Instance.Get("Light"), 8);
            units.Add(LanguageManager.Instance.Get("Medium"), 16);
            units.Add(LanguageManager.Instance.Get("Heavy"), 32);
            units.Add(LanguageManager.Instance.Get("UltimateWeapon"), 64);

            Dictionary<string, int> races = new Dictionary<string, int>(2);
            races.Add(LanguageManager.Instance.Get("Bugs"), 512);
            races.Add(LanguageManager.Instance.Get("DarkHumans"), 256);
            races.Add(LanguageManager.Instance.Get("Humans"), 128);

            string arg = HttpContext.Current.Request.Form[browserID];
            string arg2 = HttpContext.Current.Request.Form["searchChange"];

            if (arg2 != "1" && State.Session["AuctionSearchResourceGroup"] != null)
            {
                arg = State.Session["AuctionSearchResourceGroup"].ToString();
            }

			Write("<select name={0} id='{0}' class='styled'><option value=''> </option><optgroup label='{1}'>", browserID, LanguageManager.Instance.Get("Resources"));
            WriteOptions(resor, arg);
            Write("</optgroup><optgroup label='{0}'>",LanguageManager.Instance.Get("Units"));
            WriteOptions(units, arg);
            //Write("</optgroup><optgroup label='{0}'>", LanguageManager.Instance.Get("Races"));
            //WriteOptions(races, arg);
            Write("</optgroup></select>");
        }

        private void WriteOptions(Dictionary<string, int> resor, string arg)
        {
            foreach (KeyValuePair<string, int> info in resor)
            {
                if (arg == info.Value.ToString() || arg == info.Key)
                {
                    Write("<option selected='selected' value='{0}'>{1}</option>", info.Value.ToString(), info.Key);
                }
                else
                {
                    Write("<option value='{0}'>{1}</option>", info.Value.ToString(), info.Key);
                }
            }
        }
    }
}
