
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// TimedActionStorage editor control
    /// </summary>
	public partial class TimedActionStorageEditor : BaseEntityEditor<TimedActionStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TimedActionStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTimedActionStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<TimedActionStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StartTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageStartTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageEndTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Data</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageDataEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Player</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStoragePlayerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Battle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<TimedActionStorage> Implementation
		
	};

}