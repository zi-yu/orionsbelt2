
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerBattleInformation control renderer
    /// </summary>
	public class PlayerBattleInformationItem : BaseEntityItem<PlayerBattleInformation> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerBattleInformationItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerBattleInformationPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlayerBattleInformation> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>InitialContainer</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationInitialContainer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasPositioned</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasPositioned () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TeamNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTeamNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasLost</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasLost () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WinScore</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationWinScore () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>FleetId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationFleetId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdateFleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUpdateFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasGaveUp</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasGaveUp () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LoseScore</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationLoseScore () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VictoryPercentage</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationVictoryPercentage () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>DominationPoints</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationDominationPoints () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Timeouts</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTimeouts () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TeamName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTeamName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UltimateUnit</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUltimateUnit () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationBotId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Battle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerBattleInformation> Implementation
		
	};

}
