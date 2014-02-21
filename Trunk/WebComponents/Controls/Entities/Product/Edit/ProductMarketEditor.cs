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
    /// Edits the Market of the Product entity
    /// </summary>
	public class ProductMarketEditor : 
			MarketItem, IEntityFieldEditor<Product>, INamingContainer {

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

		#region MarketItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Market GetSourceFromParent( IDescriptable descriptable )
        {
            Product entity = descriptable as Product;
            if (entity == null) {
                return null;
            }
            return entity.Market;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ProductMarket";
		}
		
		#endregion Control unique identifier
		
		#endregion MarketItem Implementation
		

		#region IEntityFieldEditor<Market> Implementation
		
		/// <summary>
        /// Updates an Product
        /// </summary>
        /// <param name="entity">An instance of Product</param>
		public void Update( Product entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Market = Current;
		}
		
		#endregion IEntityFieldEditor<Market> Implementation
		
	};

}
