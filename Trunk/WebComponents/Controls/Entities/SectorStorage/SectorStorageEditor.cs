
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// SectorStorage editor control
    /// </summary>
	public partial class SectorStorageEditor : BaseEntityEditor<SectorStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SectorStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSectorStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<SectorStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsStatic</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsStaticEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SubType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSubTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSystemXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSystemYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSectorXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSectorYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>AdditionalInformation</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageAdditionalInformationEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsInBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsConstructing</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsConstructingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsMoving</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsMovingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Alliance</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageAllianceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<SectorStorage> Implementation
		
	};

}