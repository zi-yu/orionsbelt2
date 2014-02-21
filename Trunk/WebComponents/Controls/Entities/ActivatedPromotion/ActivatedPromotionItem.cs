
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ActivatedPromotion control renderer
    /// </summary>
	public class ActivatedPromotionItem : BaseEntityItem<ActivatedPromotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ActivatedPromotionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetActivatedPromotionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ActivatedPromotion> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Used</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionUsed () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Code</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionCode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Promotion</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionPromotion () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionPrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ActivatedPromotion> Implementation
		
	};

}
