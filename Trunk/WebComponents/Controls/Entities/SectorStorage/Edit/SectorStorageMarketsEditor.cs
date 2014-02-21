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
    /// Edits the Markets of the SectorStorage entity
    /// </summary>
	public class SectorStorageMarketsEditor : 
			MarketItem, IEntityFieldEditor<SectorStorage>, INamingContainer {

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

		#region IEntityFieldEditor<Market> Implementation
		
		/// <summary>
        /// Updates an SectorStorage
        /// </summary>
        /// <param name="entity">An instance of SectorStorage</param>
		public void Update( SectorStorage entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Market> list = entity.Markets;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Market> Implementation
		
	};

}
