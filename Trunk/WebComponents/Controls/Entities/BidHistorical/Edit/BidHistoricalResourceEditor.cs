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
    /// Edits the Resource of the BidHistorical entity
    /// </summary>
	public class BidHistoricalResourceEditor : 
			AuctionHouseItem, IEntityFieldEditor<BidHistorical>, INamingContainer {

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

		#region AuctionHouseItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override AuctionHouse GetSourceFromParent( IDescriptable descriptable )
        {
            BidHistorical entity = descriptable as BidHistorical;
            if (entity == null) {
                return null;
            }
            return entity.Resource;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BidHistoricalResource";
		}
		
		#endregion Control unique identifier
		
		#endregion AuctionHouseItem Implementation
		

		#region IEntityFieldEditor<AuctionHouse> Implementation
		
		/// <summary>
        /// Updates an BidHistorical
        /// </summary>
        /// <param name="entity">An instance of BidHistorical</param>
		public void Update( BidHistorical entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Resource = Current;
		}
		
		#endregion IEntityFieldEditor<AuctionHouse> Implementation
		
	};

}
