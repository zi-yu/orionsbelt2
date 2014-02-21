using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class BattleRenderer : Control {

		#region Temp

		private static IFleetInfo GetUnits() {
			FleetInfo fleetInfo = new FleetInfo("Fleet1");

			fleetInfo.Add("Crusader", 90);
			fleetInfo.Add("Rain", 200);
			fleetInfo.Add("Fenix", 50);
			fleetInfo.Add("Taurus", 70);
			fleetInfo.Add("Pretorian", 110);
			fleetInfo.Add("BlackWidow", 100);

			return fleetInfo;
		}

		private static List<Principal> GetPlayers() {
			List<Principal> principals = new List<Principal>();

			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				principals.Add(persistance.SelectById(1)[0]);
				principals.Add(persistance.SelectById(2)[0]);
			}

			return principals;
		}

		private static List<Principal> Get4Players() {
			List<Principal> principals = new List<Principal>();

			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				principals.Add(persistance.SelectById(202)[0]);
				principals.Add(persistance.SelectById(203)[0]);
				principals.Add(persistance.SelectById(204)[0]);
				principals.Add(persistance.SelectById(104535)[0]);
			}

			return principals;
		}

		private void SetBattleInfo() {
            if (battleInfo != null) {
                return;
            }
			string id = HttpContext.Current.Request.QueryString["id"];
			int battleId;

			if( string.IsNullOrEmpty(id) ) {
				string type = HttpContext.Current.Request.QueryString["nof"];
				IFleetInfo fleetInfo = GetUnits();
				if( !string.IsNullOrEmpty(type) && type.Equals("4") ) {
					List<Principal> players = Get4Players();
					battleId = BattleManager.CreateFriendlyBattle(players, fleetInfo, BattleType.TotalAnnihalation4);
				} else {
					List<Principal> players = GetPlayers();

					battleId = BattleManager.CreateFriendlyBattle(players, fleetInfo, BattleType.TotalAnnihalation);
				}

			} else {
				battleId = int.Parse(id);
			}

			battleInfo = BattleUtilities.GetBattle(battleId);
		}

		#endregion Temp

		#region Fields

		private IBattleInfo battleInfo;
		private IBattlePlayer battlePlayer;
		private BattleRendererBase battleRenderer;
		private bool isSpectator = false;

        private bool embedded = false;
        private bool preview = false;

        public bool Embedded {
            get { return embedded; }
            set { embedded = value; }
        }

        public bool IsPreview {
            get { return preview; }
            set { preview = value; Embedded = value; }
        }

        public IBattleInfo BattleInfo {
            get { return battleInfo; }
            set { battleInfo = value; }
        }

		#endregion Fields

		#region Private

		#region Choose Renderers

		/// <summary>
		/// Chooses the renderer to render the current battle
		/// </summary>
		private BattleRendererBase ChooseRenderer( IBattleOwner battleOwner ) {
			if( battleInfo.NumberOfPlayers == 2 ) {
				return ChooseRendererBattle2(battleOwner);
			}
			return ChooseRendererBattle4(battleOwner);
		}

		/// <summary>
		/// Chooses the render to render a battle between 2 players
		/// </summary>
		private BattleRendererBase ChooseRendererBattle2( IBattleOwner battleOwner ) {
			if( battleInfo.HasEnded() ) {
				return new BattleEndRenderer2(battleInfo, battleOwner);
			}

			if( battleInfo.AllPlayersPositioned ) {
				return new BattleRenderer2(battleInfo, battleOwner);
			}
			return new BattleRenderer2Positioning(battleInfo, battleOwner);
		}

		/// <summary>
		/// Chooses the render to render a battle between 3 or 4 players
		/// </summary>
		private BattleRendererBase ChooseRendererBattle4( IBattleOwner battleOwner ) {
			if( battleInfo.HasEnded() ) {
				return new BattleEndRenderer4(battleInfo, battleOwner);
			}

			if( battleInfo.AllPlayersPositioned ) {
				return new BattleRenderer4(battleInfo, battleOwner);
			}

			return new BattleRenderer4Positioning(battleInfo, battleOwner);
		}

		#endregion Choose Renderers

		#region Write Scripts

	
		#endregion Write Scripts

		/// <summary>
		/// Render the battle messages
		/// </summary>
		/// <param name="writer">HtmlTextWriter to write the content</param>
		private void RenderBoard( HtmlTextWriter writer ) {
			if( battleInfo.NumberOfPlayers == 2 ) {
				writer.Write("<div id='battle'{0}>", GetEmbeddedCss());
			} else {
                writer.Write("<div id='battle4'{0}>", GetEmbeddedCss());
			}
			battleRenderer.Render(writer);
			writer.Write("</div>");
		}

        private string GetEmbeddedCss()
        {
            if (!Embedded) {
                return string.Empty;
            }
            if (IsPreview) {
                return " class='preview'";
            }
            return " style='margin:0;'";
        }

		#endregion Private

		#region Control Events

		protected override void OnInit( EventArgs e ) {
			SetBattleInfo();
			IBattleOwner battleOwner = BattleUtilities.GetCurrentOwner(battleInfo);
			battlePlayer = battleInfo.GetPlayer(battleOwner);
			battleRenderer = ChooseRenderer(battleOwner);
			battleRenderer.IsPreview = IsPreview;
			battleRenderer.Embedded = Embedded;
            
			battleRenderer.RegisterFields(Page);
			isSpectator = battleRenderer.IsSpectactor;
		}

		protected override void OnPreRender( EventArgs e ) {
			Page.ClientScript.RegisterHiddenField("isSpectator", isSpectator?"1":"0");
            if (Embedded) {
                Page.ClientScript.RegisterHiddenField("path", WebUtilities.ApplicationPath);
                Page.ClientScript.RegisterHiddenField("imagePath", ResourcesManager.ImagesCommonPath);
            }
            if (battleInfo.BattleMode == BattleMode.Tournament && battleInfo.TournamentMode != TournamentMode.Ladder && !battlePlayer.HasPositioned)
            {
				Page.ClientScript.RegisterHiddenField("tournamentId", battleInfo.Battle.Tournament.Id.ToString() );
				Page.ClientScript.RegisterHiddenField("currentUser", PlayerUtils.Current.Name);
			}
		}

		protected override void Render( HtmlTextWriter writer ) {
			RenderBoard(writer);
		}

		#endregion Control Events

	}
}
