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
    /// Edits the SpecialSectores of the PlayerStorage entity
    /// </summary>
	public class PlayerStorageSpecialSectoresEditor : 
			UniverseSpecialSectorItem, IEntityFieldEditor<PlayerStorage>, INamingContainer {

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

		#region IEntityFieldEditor<UniverseSpecialSector> Implementation
		
		/// <summary>
        /// Updates an PlayerStorage
        /// </summary>
        /// <param name="entity">An instance of PlayerStorage</param>
		public void Update( PlayerStorage entity )
		{
			// OneToMany
			System.Collections.Generic.IList<UniverseSpecialSector> list = entity.SpecialSectores;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<UniverseSpecialSector> Implementation
		
	};

}
