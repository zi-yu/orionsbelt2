
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// TeamStorage control renderer
    /// </summary>
	public class TeamStorageItem : BaseEntityItem<TeamStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TeamStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTeamStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EloRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageEloRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberPlayedBattles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageNumberPlayedBattles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LadderActive</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLadderActive () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LadderPosition</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLadderPosition () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageIsInBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RestUntil</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageRestUntil () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StoppedUntil</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageStoppedUntil () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MyStatsId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageMyStatsId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsComplete</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageIsComplete () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TeamStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<TeamStorage> Implementation
		
	};

}
