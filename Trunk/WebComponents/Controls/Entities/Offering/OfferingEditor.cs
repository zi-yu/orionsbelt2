
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Offering editor control
    /// </summary>
	public partial class OfferingEditor : BaseEntityEditor<Offering> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public OfferingEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetOfferingPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>InitialValue</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingInitialValueEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentValue</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingCurrentValueEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Product</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingProductEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Donor</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingDonorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Receiver</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingReceiverEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Alliance</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingAllianceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new OfferingLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Offering> Implementation
		
	};

}