
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// BattleStats editor control
    /// </summary>
	public partial class BattleStatsEditor : BaseEntityEditor<BattleStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleStatsEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattleStatsPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Wins</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsWinsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Defeats</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsDefeatsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Detail</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsDetailEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GiveUps</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsGiveUpsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Stats</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsStatsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PlayerStats</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsPlayerStatsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleStatsLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<BattleStats> Implementation
		
	};

}