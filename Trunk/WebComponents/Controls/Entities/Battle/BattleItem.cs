
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Battle control renderer
    /// </summary>
	public class BattleItem : BaseEntityItem<Battle> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattlePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentTurn</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentTurn () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasEnded</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleHasEnded () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleBattleType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleMode</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleBattleMode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UnitsDestroyed</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleUnitsDestroyed () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Terrain</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTerrain () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentPlayer</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentPlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TimeoutsAllowed</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTimeoutsAllowed () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TournamentMode</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTournamentMode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsDeployTime</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsDeployTime () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsTeamBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsTeamBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SeqNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleSeqNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsToConquer</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsToConquer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInPlanet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleIsInPlanet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentBot</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCurrentBot () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Tournament</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleTournament () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Group</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleGroup () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Battle> Implementation
		
	};

}
