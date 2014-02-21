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
    /// Edits the Products of the Market entity
    /// </summary>
	public class MarketProductsEditor : 
			ProductItem, IEntityFieldEditor<Market>, INamingContainer {

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

		#region IEntityFieldEditor<Product> Implementation
		
		/// <summary>
        /// Updates an Market
        /// </summary>
        /// <param name="entity">An instance of Market</param>
		public void Update( Market entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Product> list = entity.Products;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Product> Implementation
		
	};

}
