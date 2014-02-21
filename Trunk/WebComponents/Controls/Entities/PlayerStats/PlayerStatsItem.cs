
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerStats control renderer
    /// </summary>
	public class PlayerStatsItem : BaseEntityItem<PlayerStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStatsItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStatsPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberOfPlayedBattles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberOfPlayedBattles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberPirateQuest</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberPirateQuest () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberBountyQuests</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberBountyQuests () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberMerchantQuests</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberMerchantQuests () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberGladiatorQuests</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberGladiatorQuests () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberColonizerQuests</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsNumberColonizerQuests () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStatsLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerStats> Implementation
		
	};

}
