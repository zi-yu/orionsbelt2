
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Fleet editor control
    /// </summary>
	public partial class FleetEditor : BaseEntityEditor<Fleet> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FleetEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFleetPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Fleet> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Units</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUnitsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TournamentFleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetTournamentFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsMovable</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsMovableEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UltimateUnit</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUltimateUnitEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsInBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsPlanetDefenseFleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsPlanetDefenseFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSystemXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSystemYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSectorXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSectorYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Cargo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCargoEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsBot</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsBotEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WayPoints</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetWayPointsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ImmunityStartTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetImmunityStartTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentPlanet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCurrentPlanetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PrincipalOwner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetPrincipalOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Sector</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSectorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PlayerOwner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetPlayerOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Fleet> Implementation
		
	};

}