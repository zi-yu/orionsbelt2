
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayersGroupStorage editor control
    /// </summary>
	public partial class PlayersGroupStorageEditor : BaseEntityEditor<PlayersGroupStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayersGroupStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayersGroupStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EliminatoryNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageEliminatoryNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PlayersIds</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStoragePlayersIdsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GroupNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageGroupNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Tournament</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageTournamentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayersGroupStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayersGroupStorage> Implementation
		
	};

}