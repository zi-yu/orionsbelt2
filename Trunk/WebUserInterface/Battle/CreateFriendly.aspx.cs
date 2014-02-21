using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {
	public class CreateFriendly: System.Web.UI.Page {

		#region Fields

		protected DisplayUnits displayUnits;
		protected ChooseOpponent chooseOpponent;
		protected Button createBattle;

		#endregion Fields

		#region Private

		private static IList<Principal> GetPrincipals( int id ) {
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = persistance.SelectById(id);
				if( p.Count > 0 ) {
					p.Add(Utils.Principal);
					return p;
				}
			}
			ErrorBoard.AddLocalizedMessage("InvalidOpponent");
			throw new OrionsBeltException("InvalidOpponent");
		}

		private void CreateBattle_Click( object sender, EventArgs e ) {
			if (Utils.Principal.VacationStartTick > 0) {
				ErrorBoard.AddLocalizedMessage("CannotStartOnVacations");
				return;
			}

			int id = chooseOpponent.GetSelectedPlayerId();
			if (id == 0 || id == Utils.Principal.Id) {
				ErrorBoard.AddLocalizedMessage("InvalidOpponent");
				return;
			}

			string bt = displayUnits.GetBattleType();
			if( string.IsNullOrEmpty(bt) ) {
				ErrorBoard.AddLocalizedMessage("MustSelectABattleType");
				return;
			}
			BattleType battleType = (BattleType)Enum.Parse(typeof(BattleType), bt);
			try {
				IList<Principal> principals = GetPrincipals(id);
				IFleetInfo units = displayUnits.GetUnits();
                IFleetInfo opponentUnits = displayUnits.GetOpponentUnits();
                BattleManager.CreateFriendlyBattle(principals, units, opponentUnits, battleType);	
			}catch( OrionsBeltException ) {
				return;
			}
			InformationBoard.AddLocalizedMessage("FriendlyBattleCreatedWithSuccess");
		}

		#endregion Private

		#region Control Implementation

		protected override void OnInit( System.EventArgs e ) {
			createBattle.Text = LanguageManager.Instance.Get("CreateBattle");
			createBattle.Click += CreateBattle_Click;
		}

		#endregion Control Implementation
	}
}
