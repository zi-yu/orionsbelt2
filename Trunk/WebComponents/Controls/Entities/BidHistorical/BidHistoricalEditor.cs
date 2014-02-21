
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// BidHistorical editor control
    /// </summary>
	public partial class BidHistoricalEditor : BaseEntityEditor<BidHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BidHistoricalEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBidHistoricalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<BidHistorical> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Value</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalValueEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Date</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Resource</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalResourceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MadeBy</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalMadeByEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<BidHistorical> Implementation
		
	};

}