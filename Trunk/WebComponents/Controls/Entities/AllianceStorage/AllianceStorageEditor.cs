
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// AllianceStorage editor control
    /// </summary>
	public partial class AllianceStorageEditor : BaseEntityEditor<AllianceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AllianceStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAllianceStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<AllianceStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Score</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageScoreEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Karma</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageKarmaEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalMembers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalMembersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Tag</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTagEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Description</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageDescriptionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Language</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageLanguageEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Orions</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageOrionsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>OpenToNewMembers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageOpenToNewMembersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalRelics</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalRelicsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalRelicsIncome</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalRelicsIncomeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<AllianceStorage> Implementation
		
	};

}