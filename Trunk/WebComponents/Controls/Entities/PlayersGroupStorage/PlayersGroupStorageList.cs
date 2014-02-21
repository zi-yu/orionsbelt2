
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of PlayersGroupStorage 
    /// </summary>
	public class PlayersGroupStorageList : BaseList<PlayersGroupStorage> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the PlayersGroupStorage collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<PlayersGroupStorage> GetCollection()
		{
			using( IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<PlayersGroupStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			PlayersGroupStorageItem entity = new PlayersGroupStorageItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"9\"> Listing <i>") );
			Controls.Add( new PlayersGroupStorageCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>PlayersGroupStorage</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>EliminatoryNumber</th>") );
			Controls.Add( new LiteralControl("<th>PlayersIds</th>") );
			Controls.Add( new LiteralControl("<th>GroupNumber</th>") );
			Controls.Add( new LiteralControl("<th>Tournament</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new PlayersGroupStorageDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageEliminatoryNumber () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStoragePlayersIds () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageGroupNumber () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageTournament () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayersGroupStorageDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<PlayersGroupStorage> Implementation
		
	};

}