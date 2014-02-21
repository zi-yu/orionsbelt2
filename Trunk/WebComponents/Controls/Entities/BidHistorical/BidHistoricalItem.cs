
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// BidHistorical control renderer
    /// </summary>
	public class BidHistoricalItem : BaseEntityItem<BidHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BidHistoricalItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBidHistoricalPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Value</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalValue () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Date</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Resource</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalResource () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MadeBy</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalMadeBy () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BidHistoricalLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<BidHistorical> Implementation
		
	};

}
