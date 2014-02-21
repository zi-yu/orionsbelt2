using System;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;

namespace OrionsBelt.Engine {
	public class PlayerOwner : IPlayerOwner {

		#region Fields

		private readonly IPlayer player;
		private readonly bool isOnVacations;

		#endregion Fields

		#region IBattleOwner Members

		public int Id {
			get { return player.Id; }
            set { player.Storage.Id = value; }
		}

		public string Name {
			get { return player.Name; }
		}

		public int Ranking {
			get { return player.Ranking; }
		}

		public DateTime LastUpdate {
			get { return player.Storage.UpdatedDate; }
		}

		public IPlayer Player {
			get { return player; }
		}

		public bool IsOnVacations {
			get { return isOnVacations; }
		}

		public string Avatar {
			get { return player.Avatar; }
		}

		public int Elo {
			get { return player.Principal.EloRanking; }
		}

		public bool IsBot {
			get { return HasGeneral; }
		}

		public string BotUrl {
			get {
				Principal general = Generals.GetGeneralById(player.GeneralId);
				return general.BotUrl;
			}
		}

		public int BotId {
			get { return player.GeneralId; }
		}

		public string BotName {
			get { return player.GeneralName; }
		}

		public bool HasGeneral {
			get { return player.GeneralId > 0; }	
		} 

		#endregion IBattleOwner Members

		#region Constructor

		public PlayerOwner( IPlayer player ) {
			this.player = player;
		    isOnVacations = player.InVacations;
		}

		#endregion Constructor

	}
}
