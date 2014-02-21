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
    /// Edits the Promotion of the ActivatedPromotion entity
    /// </summary>
	public class ActivatedPromotionPromotionEditor : 
			PromotionItem, IEntityFieldEditor<ActivatedPromotion>, INamingContainer {

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

		#region PromotionItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Promotion GetSourceFromParent( IDescriptable descriptable )
        {
            ActivatedPromotion entity = descriptable as ActivatedPromotion;
            if (entity == null) {
                return null;
            }
            return entity.Promotion;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ActivatedPromotionPromotion";
		}
		
		#endregion Control unique identifier
		
		#endregion PromotionItem Implementation
		

		#region IEntityFieldEditor<Promotion> Implementation
		
		/// <summary>
        /// Updates an ActivatedPromotion
        /// </summary>
        /// <param name="entity">An instance of ActivatedPromotion</param>
		public void Update( ActivatedPromotion entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Promotion = Current;
		}
		
		#endregion IEntityFieldEditor<Promotion> Implementation
		
	};

}
