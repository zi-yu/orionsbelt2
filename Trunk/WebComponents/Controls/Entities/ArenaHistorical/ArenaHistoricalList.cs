
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of ArenaHistorical 
    /// </summary>
	public class ArenaHistoricalList : BaseList<ArenaHistorical> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the ArenaHistorical collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<ArenaHistorical> GetCollection()
		{
			using( IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<ArenaHistorical> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			ArenaHistoricalItem entity = new ArenaHistoricalItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"12\"> Listing <i>") );
			Controls.Add( new ArenaHistoricalCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>ArenaHistorical</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>ChampionId</th>") );
			Controls.Add( new LiteralControl("<th>ChallengerId</th>") );
			Controls.Add( new LiteralControl("<th>Winner</th>") );
			Controls.Add( new LiteralControl("<th>WinningSequence</th>") );
			Controls.Add( new LiteralControl("<th>BattleId</th>") );
			Controls.Add( new LiteralControl("<th>StartTick</th>") );
			Controls.Add( new LiteralControl("<th>EndTick</th>") );
			Controls.Add( new LiteralControl("<th>Arena</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new ArenaHistoricalDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalChampionId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalChallengerId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalWinner () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalWinningSequence () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalBattleId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalStartTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalEndTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalArena () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new ArenaHistoricalDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<ArenaHistorical> Implementation
		
	};

}