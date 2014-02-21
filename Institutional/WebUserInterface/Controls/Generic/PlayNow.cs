using System.Web.UI;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

    public class PlayNow : Control {

        #region Fields

        private static readonly string image = "http://resources.orionsbelt.eu/Institutional/Images/IntergalacticTournament/PlayNow_{0}.png";

        #endregion

        #region Properties

        private string key;

        public string Key {
            get {
                if (string.IsNullOrEmpty(key)) {
                    return "PlayNow";
                }
                return key; 
            }
            set { key = value; }
        }

        private bool intergalactic;

        public bool IntergalacticTournament
        {
            get { return intergalactic; }
            set { intergalactic = value; }
        }

        #endregion Properties

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            string lang = Page.Request.QueryString["Lang"];
            if (!string.IsNullOrEmpty(lang))
            {
                State.SetSession("Lang", lang);
                GetContent(writer, lang);
            }
            else
            {
                if (State.HasSession("Lang"))
                {
                    State.Session.Remove("Lang");
                }
                GetContent(writer, LanguageManager.CurrentLanguage);
            }
        }

        private void GetContent(HtmlTextWriter writer, string lang)
        {
            if (IntergalacticTournament) {
                writer.Write("<a href='{0}?lang={2}'><img src='{3}' alt='{1}' title='{1}'/></a>", WebUtilities.GetPlayUrlProxy(), LanguageManager.Instance.Get(Key), lang, GetImages(lang));
                return;
            }
            writer.Write("<a href='{0}?lang={2}'>{1}</a>", WebUtilities.GetPlayUrlProxy(), LanguageManager.Instance.Get(Key), lang);
        }

        private string GetImages(string lang) {
            
            if( lang.ToLower().Contains("pt") ) {
                return string.Format(image, "pt");
            }
            return string.Format(image, "en");
        }

        #endregion Rendering

    };

}
