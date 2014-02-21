using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Bids of the AuctionHouse entity
    /// </summary>
	public class AuctionHouseBidsEditor : 
			BidHistoricalItem, IEntityFieldEditor<AuctionHouse>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region IEntityFieldEditor<BidHistorical> Implementation
		
		/// <summary>
        /// Updates an AuctionHouse
        /// </summary>
        /// <param name="entity">An instance of AuctionHouse</param>
		public void Update( AuctionHouse entity )
		{
			// OneToMany
			System.Collections.Generic.IList<BidHistorical> list = entity.Bids;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<BidHistorical> Implementation
		
	};

}
