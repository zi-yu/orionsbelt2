
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// TimedActionStorage control renderer
    /// </summary>
	public class TimedActionStorageItem : BaseEntityItem<TimedActionStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TimedActionStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTimedActionStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StartTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageStartTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageEndTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Data</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageData () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStoragePlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Battle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TimedActionStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<TimedActionStorage> Implementation
		
	};

}
