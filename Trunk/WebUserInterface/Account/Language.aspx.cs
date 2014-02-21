using System;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Account
{
    public class Language : System.Web.UI.Page {

        #region Fields

        protected DropDownList languageList;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            languageList.AutoPostBack = true;
            languageList.SelectedIndexChanged += new EventHandler(languageList_SelectedIndexChanged);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Page.IsPostBack) {
                foreach (string lang in LanguageManager.SupportedLanguages) {
                    if ((lang.Contains("hr") || lang.Contains("fr") || lang.Contains("es")) && !Utils.Principal.IsInRole("admin")) {
                        continue;
                    }
                    ListItem item = new ListItem(LanguageManager.Instance.Get(lang), lang);
                    item.Selected = lang == LanguageManager.CurrentLanguage;
                    languageList.Items.Add(item);
                }
            }
        }

        void languageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = languageList.SelectedItem.Value;
            OrionsBelt.WebUserInterface.Modules.AuthenticateModule.SetLanguage(lang);

            foreach (ListItem item in languageList.Items) {
                item.Text = LanguageManager.Instance.Get(item.Value);
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                Principal principal = Utils.Principal;
                principal.Locale = lang;
                persistance.Update(principal);
                persistance.Flush();
            }
        }

        #endregion Events

    };
}
