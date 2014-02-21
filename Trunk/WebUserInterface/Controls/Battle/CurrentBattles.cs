using System;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Controls {
	public class CurrentBattles : Control {

		#region Fields

        private SimpleBattleInfos simpleBattleInfos = null;
		protected bool allBattles = false;
	    private bool showTournaments = true;
        private bool showFriendlies = true;
        private bool showRounds = true;
        private bool showArenas = true;
		private bool showCampaigns = true;

		#endregion Fields

		#region Properties

		public SimpleBattleInfos SimpleBattleInfos {
			get {
				if( simpleBattleInfos == null ) {
					simpleBattleInfos = LoadBattleInfos();
				}
				return simpleBattleInfos;
			}
		}

	    public bool ShowTournaments{
	        get { return showTournaments; }
	        set { showTournaments = value; }
	    }

	    public bool ShowFriendlies{
	        get { return showFriendlies; }
	        set { showFriendlies = value; }
	    }

	    public bool ShowRounds{
	        get { return showRounds; }
	        set { showRounds = value; }
	    }

	    public bool ShowArenas{
	        get { return showArenas; }
	        set { showArenas = value; }
	    }

		public bool ShowCampaigns {
			get { return showCampaigns; }
			set { showCampaigns = value; }
		}

	    #endregion Properties

		#region Public

		protected virtual SimpleBattleInfos LoadBattleInfos() {
			return BattleUtilities.GetBattles();
		}
		
		#endregion Public 

		#region Private

		private void RenderBattles(TextWriter writer, BattleMode mode) {
			Mode modes = SimpleBattleInfos.GetBattleMode(mode);
			if (modes != null) {
				new GenericRender(writer, modes).Render(allBattles);
			}
		}

		#endregion Private

		#region Control Events

        protected override void OnInit(EventArgs e){
            HttpContext.Current.Items.Remove("NumberOfBattles");
            HttpContext.Current.Items.Remove("NumberUniverseOfBattles");

            simpleBattleInfos = LoadBattleInfos();
        }

        protected override void Render(HtmlTextWriter writer) {
            if( Utils.Principal != null ) {
                if (showRounds)                {
                    RenderBattles(writer,BattleMode.Battle);
                }
                if (showTournaments){
					RenderBattles(writer, BattleMode.Tournament);
                }
                if (showFriendlies){
					RenderBattles(writer, BattleMode.Friendly);
                }
                if (showArenas){
					RenderBattles(writer, BattleMode.Arena);
                }
				if (showCampaigns) {
					RenderBattles(writer, BattleMode.Campaign);
				}
            }
        }

		#endregion Control Events

	}
}
