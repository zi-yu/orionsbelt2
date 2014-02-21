
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Battle editor control
    /// </summary>
	public partial class BattleEditor : BaseEntityEditor<Battle> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattlePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Battle> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentTurn</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentTurnEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasEnded</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleHasEndedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BattleType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleBattleTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BattleMode</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleBattleModeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UnitsDestroyed</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleUnitsDestroyedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Terrain</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTerrainEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentPlayer</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentPlayerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TimeoutsAllowed</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTimeoutsAllowedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TournamentMode</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTournamentModeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsDeployTime</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsDeployTimeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsTeamBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsTeamBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SeqNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleSeqNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsToConquer</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsToConquerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInPlanet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsInPlanetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentBot</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentBotEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Tournament</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTournamentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Group</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleGroupEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Battle> Implementation
		
	};

}