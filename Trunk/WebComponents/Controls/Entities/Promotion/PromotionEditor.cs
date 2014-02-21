
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Promotion editor control
    /// </summary>
	public partial class PromotionEditor : BaseEntityEditor<Promotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PromotionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPromotionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Promotion> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BeginDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBeginDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionEndDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RevenueType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRevenueTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Revenue</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRevenueEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PromotionType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionPromotionTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RangeBegin</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRangeBeginEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RangeEnd</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRangeEndEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PromotionCode</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionPromotionCodeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BonusType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBonusTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Bonus</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBonusEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Status</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionStatusEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Description</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionDescriptionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Uses</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionUsesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Promotion> Implementation
		
	};

}