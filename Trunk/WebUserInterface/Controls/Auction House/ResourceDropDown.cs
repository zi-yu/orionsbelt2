using System.Collections.Generic;
using System.Web;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ResourceDropDown : ControlBase
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

            List<IResourceInfo> list = RulesUtils.GetIntrinsicNonConceptualResources();
            List<IUnitInfo> units = RulesUtils.GetUnitResources();

            list.Sort(WebUtilities.Compare);
            units.Sort(WebUtilities.Compare);

            string arg = HttpContext.Current.Request.Form[browserID];
            string arg2 = HttpContext.Current.Request.Form["searchChange"];

            if (arg2 != "1" && State.Session["AuctionSearchResource"] != null)
            {
                arg = State.Session["AuctionSearchResource"].ToString();
            }

            Write("<select name={0} id='{0}' class='styled'><option value=''> </option><optgroup label='{1}'>", browserID, LanguageManager.Instance.Get("Resources"));
            foreach (IResourceInfo info in list)
            {  
                if (arg == LanguageManager.Instance.Get(info.Name))
                {
                    Write("<option selected='selected' value='{0}'>{1}</option>", info.Name, LanguageManager.Instance.Get(info.Name));
                }
                else
                {
                    Write("<option value='{0}'>{1}</option>", info.Name, LanguageManager.Instance.Get(info.Name));
                }
            }
            Write("</optgroup><optgroup label='{0}'>",LanguageManager.Instance.Get("Units"));
            foreach (IUnitInfo info in units)
            {
                if (arg == LanguageManager.Instance.Get(info.Name))
                {
                    Write("<option selected='selected' value='{0}'>{1}</option>", info.Name,
                          LanguageManager.Instance.Get(info.Name));
                }
                else
                {
                    Write("<option value='{0}'>{1}</option>", info.Name, LanguageManager.Instance.Get(info.Name));
                }
            }
            Write("</optgroup></select>");
        }
    }
}
