
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ArenaHistorical editor control
    /// </summary>
	public partial class ArenaHistoricalEditor : BaseEntityEditor<ArenaHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaHistoricalEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaHistoricalPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ChampionId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalChampionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ChallengerId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalChallengerIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Winner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalWinnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WinningSequence</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalWinningSequenceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BattleId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalBattleIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StartTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalStartTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalEndTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Arena</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalArenaEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ArenaHistoricalLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ArenaHistorical> Implementation
		
	};

}