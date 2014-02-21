
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// BattleStats control renderer
    /// </summary>
	public class BattleStatsItem : BaseEntityItem<BattleStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleStatsItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattleStatsPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<BattleStats> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Wins</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsWins () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Defeats</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsDefeats () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Detail</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsDetail () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GiveUps</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsGiveUps () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Stats</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsStats () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PlayerStats</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsPlayerStats () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<BattleStats> Implementation
		
	};

}
