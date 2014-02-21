
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// SpecialEvent editor control
    /// </summary>
	public partial class SpecialEventEditor : BaseEntityEditor<SpecialEvent> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SpecialEventEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSpecialEventPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<SpecialEvent> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Cost</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventCostEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Token</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventTokenEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Resorces</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventResorcesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BeginDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventBeginDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventEndDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SpecialEventLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<SpecialEvent> Implementation
		
	};

}