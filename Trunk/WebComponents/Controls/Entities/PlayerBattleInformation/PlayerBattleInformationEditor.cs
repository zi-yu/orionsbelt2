
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerBattleInformation editor control
    /// </summary>
	public partial class PlayerBattleInformationEditor : BaseEntityEditor<PlayerBattleInformation> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerBattleInformationEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerBattleInformationPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>InitialContainer</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationInitialContainerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasPositioned</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasPositionedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TeamNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTeamNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasLost</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasLostEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WinScore</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationWinScoreEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>FleetId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationFleetIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdateFleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUpdateFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasGaveUp</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationHasGaveUpEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LoseScore</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationLoseScoreEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VictoryPercentage</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationVictoryPercentageEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>DominationPoints</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationDominationPointsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Timeouts</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTimeoutsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TeamName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationTeamNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UltimateUnit</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUltimateUnitEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationBotIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Battle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerBattleInformationLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerBattleInformation> Implementation
		
	};

}