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
    /// Edits the Battle of the BattleExtention entity
    /// </summary>
	public class BattleExtentionBattleEditor : 
			BattleItem, IEntityFieldEditor<BattleExtention>, INamingContainer {

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

		#region BattleItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Battle GetSourceFromParent( IDescriptable descriptable )
        {
            BattleExtention entity = descriptable as BattleExtention;
            if (entity == null) {
                return null;
            }
            return entity.Battle;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BattleExtentionBattle";
		}
		
		#endregion Control unique identifier
		
		#endregion BattleItem Implementation
		

		#region IEntityFieldEditor<Battle> Implementation
		
		/// <summary>
        /// Updates an BattleExtention
        /// </summary>
        /// <param name="entity">An instance of BattleExtention</param>
		public void Update( BattleExtention entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Battle = Current;
		}
		
		#endregion IEntityFieldEditor<Battle> Implementation
		
	};

}
