using System;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {
	public class PrincipalOwner : IPrincipalOwner {

		#region Fields

		private readonly Principal principal;
		private readonly bool isOnVacations;
		
		#endregion Fields

		#region IBattleOwner Members

		public int Id {
			get { return principal.Id; }
            set { principal.Id = value; }
		}

		public string Name {
			get { return principal.DisplayName; }
		}

		public int Ranking {
			get { return principal.EloRanking; }
		}

		public DateTime LastUpdate {
			get { return principal.UpdatedDate; }
		}

		public Principal Principal {
			get { return principal; }
		}

		public bool IsOnVacations {
			get { return isOnVacations; }
		}

		public string Avatar {
			get {return principal.Avatar;}
		}

		public int Elo {
			get { return principal.EloRanking; } 
		}

		public bool IsBot {
			get { return Principal.IsBot; }
		}

		public string BotUrl {
			get { return Principal.BotUrl; }
		}

		public int BotId {
			get {
				if (IsBot) {
					return Principal.Id;	
				}
				return 0;
			}
		}

		public string BotName {
			get { return Principal.DisplayName; }
		}

		public bool HasGeneral {
			get { return false; }
		} 

		#endregion IBattleOwner Members

		#region Constructor

		public PrincipalOwner( Principal principal ) {
			this.principal = principal;
			isOnVacations = principal.IsOnVacations;
		}

		#endregion Constructor

	}
}
