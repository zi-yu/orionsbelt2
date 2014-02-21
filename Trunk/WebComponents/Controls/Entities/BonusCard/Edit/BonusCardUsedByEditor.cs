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
    /// Edits the UsedBy of the BonusCard entity
    /// </summary>
	public class BonusCardUsedByEditor : 
			PrincipalItem, IEntityFieldEditor<BonusCard>, INamingContainer {

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

		#region PrincipalItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Principal GetSourceFromParent( IDescriptable descriptable )
        {
            BonusCard entity = descriptable as BonusCard;
            if (entity == null) {
                return null;
            }
            return entity.UsedBy;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BonusCardUsedBy";
		}
		
		#endregion Control unique identifier
		
		#endregion PrincipalItem Implementation
		

		#region IEntityFieldEditor<Principal> Implementation
		
		/// <summary>
        /// Updates an BonusCard
        /// </summary>
        /// <param name="entity">An instance of BonusCard</param>
		public void Update( BonusCard entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.UsedBy = Current;
		}
		
		#endregion IEntityFieldEditor<Principal> Implementation
		
	};

}
