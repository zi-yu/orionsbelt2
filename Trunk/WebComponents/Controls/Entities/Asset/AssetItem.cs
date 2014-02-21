
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Asset control renderer
    /// </summary>
	public class AssetItem : BaseEntityItem<Asset> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AssetItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAssetPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Asset> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Description</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetDescription () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Coordinate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetCoordinate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Task</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetTask () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Alliance</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetAlliance () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AssetLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Asset> Implementation
		
	};

}
