
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ActivatedPromotion editor control
    /// </summary>
	public partial class ActivatedPromotionEditor : BaseEntityEditor<ActivatedPromotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ActivatedPromotionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetActivatedPromotionPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Used</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionUsedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Code</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionCodeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Promotion</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionPromotionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Principal</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionPrincipalEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ActivatedPromotionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ActivatedPromotion> Implementation
		
	};

}