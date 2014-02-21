
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of AllianceStorage 
    /// </summary>
	public class AllianceStorageList : BaseList<AllianceStorage> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the AllianceStorage collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<AllianceStorage> GetCollection()
		{
			using( IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<AllianceStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			AllianceStorageItem entity = new AllianceStorageItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"22\"> Listing <i>") );
			Controls.Add( new AllianceStorageCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>AllianceStorage</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Score</th>") );
			Controls.Add( new LiteralControl("<th>Karma</th>") );
			Controls.Add( new LiteralControl("<th>TotalMembers</th>") );
			Controls.Add( new LiteralControl("<th>Name</th>") );
			Controls.Add( new LiteralControl("<th>Tag</th>") );
			Controls.Add( new LiteralControl("<th>Description</th>") );
			Controls.Add( new LiteralControl("<th>Language</th>") );
			Controls.Add( new LiteralControl("<th>Orions</th>") );
			Controls.Add( new LiteralControl("<th>OpenToNewMembers</th>") );
			Controls.Add( new LiteralControl("<th>TotalRelics</th>") );
			Controls.Add( new LiteralControl("<th>TotalRelicsIncome</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new AllianceStorageDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageScore () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageKarma () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageTotalMembers () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageTag () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageDescription () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageLanguage () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageOrions () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageOpenToNewMembers () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageTotalRelics () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageTotalRelicsIncome () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceStorageDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<AllianceStorage> Implementation
		
	};

}