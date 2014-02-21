
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// SpecialEvent control renderer
    /// </summary>
	public class SpecialEventItem : BaseEntityItem<SpecialEvent> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SpecialEventItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSpecialEventPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<SpecialEvent> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Cost</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventCost () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Token</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventToken () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Resorces</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventResorces () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BeginDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventBeginDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventEndDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<SpecialEvent> Implementation
		
	};

}
