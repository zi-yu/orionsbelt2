using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using System;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

    public enum Tutorial { 
        None                    = 0,
        InvalidBattle           = -1,
        Home                    = -2,

        PrivateZone             = 1 << 0,
        HotZone                 = -3,//1 << 1,

        BugsPlanets             = 1 << 2,
        LightHumansPlanets      = 1 << 3,
        DarkHumansPlanets       = 1 << 4,

        BattleDeploy            = 1 << 5,
        RegicideDeploy          = 1 << 9,
        Battle                  = 1 << 6,

        CheckpointQuest         = 1 << 7,
        TaskQuest               = 1 << 8
    };

	public class TutorialManager: Control {

        #region Fields & Props

        public static Tutorial Current {
            get {
                if (State.HasItems("CurrentTutorial")) {
                    return (Tutorial)State.GetItems("CurrentTutorial");
                }
                return Tutorial.None;
            }
            set { State.SetItems("CurrentTutorial", value); }
        }

        #endregion Fields & Props

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            if (IsToAutoStart()) {
                writer.Write("<script type='text/javascript'>window.autoStartTutorial=\"{0}\";</script>", Current);
            }
            WriteControl(writer);
        }

        private static void WriteControl(HtmlTextWriter writer)
        {
            writer.Write("<div id='tutorial'>");
            writer.Write("<a name='followtutorial' id='followtutorial' class='followtutorial'>&nbsp;</a>");

            writer.Write("<div id='top'><span class='arrow topArrow'></span></div>");

            writer.Write("<div id='left'><span class='arrow leftArrow'></span></div>");

			
			FramesHtml.FrameHtmlTitleX(writer, "middlet", "<span id='tutorialTitle'></span>", "<div id='tutorialContent'></div>","Tutorial.hide();");
			
            writer.Write("<div id='right'><span class='arrow rightArrow'></span></div>");

            writer.Write("<div id='bottom'><span class='arrow bottomArrow'></span></div>");

            writer.Write("</div>");
        }

        #endregion Events

        #region Utils

        public static string GetHref()
        {
            return string.Format("javascript:Tutorial.show(\"{0}\");", Current);
        }

        private bool IsToAutoStart()
        {
            int val = Convert.ToInt32(Current);
            if (val <= 0) {
                return false;
            }

            if ((val & Utils.Principal.TutorialState) != 0) {
                return false;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                Utils.Principal.TutorialState |= val;
                persistance.Update(Utils.Principal);
                persistance.Flush();
            }

            return true;
        }

        #endregion Utils

    };
}

