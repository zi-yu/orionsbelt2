﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Owner of the AuctionHouse entity
    /// </summary>
	public class AuctionHouseOwnerEditor : 
			PlayerStorageItem, IEntityFieldEditor<AuctionHouse>, INamingContainer {

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

		#region PlayerStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PlayerStorage GetSourceFromParent( IDescriptable descriptable )
        {
            AuctionHouse entity = descriptable as AuctionHouse;
            if (entity == null) {
                return null;
            }
            return entity.Owner;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "AuctionHouseOwner";
		}
		
		#endregion Control unique identifier
		
		#endregion PlayerStorageItem Implementation
		

		#region IEntityFieldEditor<PlayerStorage> Implementation
		
		/// <summary>
        /// Updates an AuctionHouse
        /// </summary>
        /// <param name="entity">An instance of AuctionHouse</param>
		public void Update( AuctionHouse entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Owner = Current;
		}
		
		#endregion IEntityFieldEditor<PlayerStorage> Implementation
		
	};

}
