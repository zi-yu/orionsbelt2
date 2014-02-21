
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Promotion control renderer
    /// </summary>
	public class PromotionItem : BaseEntityItem<Promotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PromotionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPromotionPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BeginDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBeginDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionEndDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RevenueType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRevenueType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Revenue</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRevenue () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PromotionType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionPromotionType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RangeBegin</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRangeBegin () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RangeEnd</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionRangeEnd () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PromotionCode</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionPromotionCode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BonusType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBonusType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Bonus</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionBonus () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Status</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionStatus () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Description</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionDescription () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Uses</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionUses () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PromotionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Promotion> Implementation
		
	};

}
