
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Offering control renderer
    /// </summary>
	public class OfferingItem : BaseEntityItem<Offering> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public OfferingItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetOfferingPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Offering> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>InitialValue</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingInitialValue () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentValue</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingCurrentValue () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Product</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingProduct () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Donor</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingDonor () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Receiver</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingReceiver () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Alliance</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingAlliance () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Offering> Implementation
		
	};

}
