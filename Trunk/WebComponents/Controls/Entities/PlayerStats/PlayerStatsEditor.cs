
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerStats editor control
    /// </summary>
	public partial class PlayerStatsEditor : BaseEntityEditor<PlayerStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStatsEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStatsPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlayerStats> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberOfPlayedBattles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberOfPlayedBattlesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberPirateQuest</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberPirateQuestEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberBountyQuests</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberBountyQuestsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberMerchantQuests</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberMerchantQuestsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberGladiatorQuests</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberGladiatorQuestsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberColonizerQuests</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberColonizerQuestsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerStats> Implementation
		
	};

}