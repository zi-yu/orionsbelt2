
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// GroupPointsStorage control renderer
    /// </summary>
	public class GroupPointsStorageItem : BaseEntityItem<GroupPointsStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public GroupPointsStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetGroupPointsStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Stage</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageStage () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Pontuation</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStoragePontuation () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Wins</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageWins () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Losses</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageLosses () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Regist</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageRegist () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new GroupPointsStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<GroupPointsStorage> Implementation
		
	};

}
