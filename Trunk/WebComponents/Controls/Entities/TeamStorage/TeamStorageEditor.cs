
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// TeamStorage editor control
    /// </summary>
	public partial class TeamStorageEditor : BaseEntityEditor<TeamStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TeamStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTeamStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<TeamStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EloRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageEloRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberPlayedBattles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageNumberPlayedBattlesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LadderActive</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLadderActiveEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LadderPosition</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLadderPositionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageIsInBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RestUntil</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageRestUntilEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StoppedUntil</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageStoppedUntilEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MyStatsId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageMyStatsIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsComplete</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageIsCompleteEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<TeamStorage> Implementation
		
	};

}