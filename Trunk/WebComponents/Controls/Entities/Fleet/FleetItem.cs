
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Fleet control renderer
    /// </summary>
	public class FleetItem : BaseEntityItem<Fleet> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FleetItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFleetPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Units</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUnits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TournamentFleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetTournamentFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsMovable</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsMovable () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UltimateUnit</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUltimateUnit () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsInBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsPlanetDefenseFleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsPlanetDefenseFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSystemX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSystemY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSectorX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSectorY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Cargo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCargo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsBot</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetIsBot () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WayPoints</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetWayPoints () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ImmunityStartTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetImmunityStartTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentPlanet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCurrentPlanet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PrincipalOwner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetPrincipalOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Sector</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetSector () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PlayerOwner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetPlayerOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FleetLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Fleet> Implementation
		
	};

}
