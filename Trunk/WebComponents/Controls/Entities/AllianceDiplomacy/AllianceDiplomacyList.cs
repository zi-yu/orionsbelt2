
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of AllianceDiplomacy 
    /// </summary>
	public class AllianceDiplomacyList : BaseList<AllianceDiplomacy> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the AllianceDiplomacy collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<AllianceDiplomacy> GetCollection()
		{
			using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<AllianceDiplomacy> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			AllianceDiplomacyItem entity = new AllianceDiplomacyItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"7\"> Listing <i>") );
			Controls.Add( new AllianceDiplomacyCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>AllianceDiplomacy</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Level</th>") );
			Controls.Add( new LiteralControl("<th>AllianceA</th>") );
			Controls.Add( new LiteralControl("<th>AllianceB</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new AllianceDiplomacyDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyAllianceA () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyAllianceB () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new AllianceDiplomacyDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<AllianceDiplomacy> Implementation
		
	};

}