
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayersGroupStorage control renderer
    /// </summary>
	public class PlayersGroupStorageItem : BaseEntityItem<PlayersGroupStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayersGroupStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayersGroupStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlayersGroupStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EliminatoryNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageEliminatoryNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PlayersIds</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStoragePlayersIds () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GroupNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageGroupNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Tournament</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageTournament () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayersGroupStorage> Implementation
		
	};

}
