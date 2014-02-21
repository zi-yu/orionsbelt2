
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ArenaStorage editor control
    /// </summary>
	public partial class ArenaStorageEditor : BaseEntityEditor<ArenaStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageIsInBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ConquestTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageConquestTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BattleType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageBattleTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Coordinate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageCoordinateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Payment</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStoragePaymentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Fleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Sector</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageSectorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ArenaStorage> Implementation
		
	};

}