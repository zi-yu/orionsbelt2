
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ArenaStorage control renderer
    /// </summary>
	public class ArenaStorageItem : BaseEntityItem<ArenaStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ArenaStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageIsInBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ConquestTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageConquestTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageBattleType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Coordinate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageCoordinate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Payment</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStoragePayment () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Fleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Sector</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageSector () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ArenaStorage> Implementation
		
	};

}
