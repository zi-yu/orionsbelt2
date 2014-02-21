
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// GroupPointsStorage editor control
    /// </summary>
	public partial class GroupPointsStorageEditor : BaseEntityEditor<GroupPointsStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public GroupPointsStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetGroupPointsStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<GroupPointsStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Stage</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageStageEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Pontuation</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStoragePontuationEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Wins</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageWinsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Losses</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageLossesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Regist</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageRegistEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<GroupPointsStorage> Implementation
		
	};

}