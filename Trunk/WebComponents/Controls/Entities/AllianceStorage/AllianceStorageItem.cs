
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// AllianceStorage control renderer
    /// </summary>
	public class AllianceStorageItem : BaseEntityItem<AllianceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AllianceStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAllianceStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Score</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageScore () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Karma</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageKarma () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalMembers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalMembers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Tag</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTag () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Description</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageDescription () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Language</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageLanguage () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Orions</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageOrions () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>OpenToNewMembers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageOpenToNewMembers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalRelics</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalRelics () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalRelicsIncome</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageTotalRelicsIncome () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<AllianceStorage> Implementation
		
	};

}
