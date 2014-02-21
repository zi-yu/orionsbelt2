
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ArenaHistorical control renderer
    /// </summary>
	public class ArenaHistoricalItem : BaseEntityItem<ArenaHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaHistoricalItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaHistoricalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ArenaHistorical> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ChampionId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalChampionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ChallengerId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalChallengerId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Winner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalWinner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WinningSequence</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalWinningSequence () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalBattleId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StartTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalStartTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalEndTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Arena</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalArena () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ArenaHistorical> Implementation
		
	};

}
