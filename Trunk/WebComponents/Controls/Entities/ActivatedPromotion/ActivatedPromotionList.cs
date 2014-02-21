
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of ActivatedPromotion 
    /// </summary>
	public class ActivatedPromotionList : BaseList<ActivatedPromotion> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the ActivatedPromotion collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<ActivatedPromotion> GetCollection()
		{
			using( IActivatedPromotionPersistance persistance = Persistance.Instance.GetActivatedPromotionPersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<ActivatedPromotion> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			ActivatedPromotionItem entity = new ActivatedPromotionItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"8\"> Listing <i>") );
			Controls.Add( new ActivatedPromotionCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>ActivatedPromotion</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Used</th>") );
			Controls.Add( new LiteralControl("<th>Code</th>") );
			Controls.Add( new LiteralControl("<th>Promotion</th>") );
			Controls.Add( new LiteralControl("<th>Principal</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new ActivatedPromotionDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionUsed () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionCode () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionPromotion () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionPrincipal () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ActivatedPromotionDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<ActivatedPromotion> Implementation
		
	};

}