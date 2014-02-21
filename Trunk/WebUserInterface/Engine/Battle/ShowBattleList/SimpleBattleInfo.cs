using System;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class SimpleBattleInfo {

		#region Fields

		private int battleId;
		private int currentTurn;
		private bool hasEnded;
		private BattleType battleType;
		private BattleMode battleMode;
		private int currentPlayer;
		private bool isDeployTime;
		private bool hasDeployed;
		private int teamNumber;
		private bool hasLost;
		private bool hasGaveUp;
		private int victoryPercentage;
		private int timeouts;
        private int currentPlayerIndex;
        private List<OtherPlayersInformations> opponents = new List<OtherPlayersInformations>();
	    private int numberOfPlayers;
        private bool isTurn = false;
		private string currentName;
		private string timeLeft;
		private int score;
        private IList<PlayerStorage> players;
        private Battle battle;
		private TournamentMode tournamentMode;
        private int tournamentid;
        private string tournamentName;

	    #endregion Fields

		#region Properties

		public int BattleId {
			get { return battleId; }
		}

		public int CurrentTurn {
			get { return currentTurn; }
		}

		public bool HasEnded {
			get { return hasEnded; }
		}

		public BattleType BattleType {
			get { return battleType; }
		}

		public BattleMode BattleMode {
			get { return battleMode; }
		}

		public int CurrentPlayer {
			get { return currentPlayer; }
		}

		public bool IsDeployTime {
			get { return isDeployTime; }
		}

		public bool HasDeployed {
			get { return hasDeployed; }
		}

		public int TeamNumber {
			get { return teamNumber; }
		}

		public bool HasLost {
			get { return hasLost; }
		}

		public bool HasGaveUp {
			get { return hasGaveUp; }
		}

		public int VictoryPercentage {
			get { return victoryPercentage; }
		}

		public int Timeouts {
			get { return timeouts; }
		}

	    public int NumberOfPlayers {
	        get { return numberOfPlayers; }
	    }

	    public List<OtherPlayersInformations> Opponents {
            get { return opponents; }
	    }

	    public bool IsTurn {
	        get { return isTurn; }
	    }

		public string TimeLeft {
			get { return timeLeft; }
		}

		public int Score {
			get { return score; }
		}

		public TournamentMode TournamentMode {
			get { return tournamentMode; }
		}

        public int TournamentId {
            get { return tournamentid; }
        }

        public string TournamentName {
            get { return tournamentName; }
        }

	    #endregion Properties

		#region Private

		private static BattleType GetBattleType( string p ) {
			return(BattleType) Enum.Parse(typeof(BattleType), p);
		}

		private static BattleMode GetBattleMode(string p) {
			return (BattleMode) Enum.Parse(typeof(BattleMode), p);
		}

		private static TournamentMode GetTournamentMode(string p) {
			if(!string.IsNullOrEmpty(p)) {
				return (TournamentMode)Enum.Parse(typeof(TournamentMode), p);	
			}
			return TournamentMode.Normal;
		}


        private int GetNumberOfPlayers() {
            if( battleType == BattleType.Domination || battleType == BattleType.Regicide || battleType == BattleType.TotalAnnihalation ) {
                return 2;
            }
            return 4;
        }

        private int GetId() {
            if( players == null ) {
			    if (battleMode == BattleMode.Battle || battleMode == BattleMode.Arena) {
                    return PlayerUtils.Current.Id;
                } 
                return Utils.Principal.Id;
            }
            for (int i = 0; i < battle.PlayerInformation.Count; ++i)   {
                foreach (PlayerStorage storage in players)  {
                    if (battle.PlayerInformation[i].Owner == storage.Id) {
                        return storage.Id;
                    }
                }
            }
            throw new UIException("Can't resolve current player's Id");
        }

        private int GetCurrentPlayer(Battle battle) {
            int id = GetId();

            for( int i = 0; i < battle.PlayerInformation.Count; ++i ) {
                if( battle.PlayerInformation[i].Owner == id ) {
                    return i;
                }
            }

        	return 0;
        }

	    private void GatherOtherPlayers(int id, Battle battle) {
            foreach ( PlayerBattleInformation player in battle.PlayerInformation ) {
                if (player.Owner != id ) {
					Opponents.Add(new OtherPlayersInformations(player, GetScore(player), battle.BattleMode));
                }
            }
        }

		private static string GetTimeLeft(Battle battle) {
			if( battle.HasEnded ) {
				return LanguageManager.Instance.Get("BattleEnded");
			}
            if (battle.TimedAction.Count == 0) {
                return TimeFormatter.GetFormattedTicksTo(CreateAction(battle));
            }
			int endtick = battle.TimedAction[0].EndTick;
			if (endtick < 0) {
				return LanguageManager.Instance.Get("OnVacations");
			} 
			return TimeFormatter.GetFormattedTicksTo(endtick);
		}

        private static int CreateAction(Battle battle){
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()){
                persistance.StartTransaction();

                TimedActionStorage t = persistance.Create();
                t.Battle = battle;
                t.EndTick = Clock.Instance.Tick + 100;
                t.StartTick = Clock.Instance.Tick;
                t.Name = "BattleTimeout";
                t.Data = battle.Id.ToString();
                persistance.Update(t);

                persistance.CommitTransaction();
            }
            return Clock.Instance.Tick + 100;
        }

		private static int GetVictoryPercentage(Battle battle, PlayerBattleInformation current) {
			if (battle.HasEnded) {
				return 0;
			}
			return current.VictoryPercentage;
		}

		private int GetScore(PlayerBattleInformation current) {
			if (battleMode == BattleMode.Battle || battleMode == BattleMode.Arena) {
				return current.HasLost || current.HasGaveUp ? current.LoseScore : current.WinScore;
			}
			return current.WinScore;
		}

        private void UpdateNumberOfBattles(){
            if( HasEnded ) {
				return;
			}

			IncrementTotalBattles();

            if( IsDeployTime ) {
                if( HasDeployed ) {
                    return;
                }
                IncrementBattles();
                return;
            }

            if( IsTurn ) {
                IncrementBattles();
            }
        }

        private static void IncrementTotalBattles(){
            IncrementItems("TotalNumberOfBattles");
        }

        private static void IncrementUniverseTotalBattles(){
            IncrementItems("NumberUniverseOfBattles");
        }

		private static void IncrementBattles() {
		    IncrementItems("NumberOfBattles");
        }

        private static void IncrementItems( string key){
            int count = 0;
            if (State.HasItems(key)){
                count = State.GetItemsInt(key);
            }
            State.SetItems(key, ++count);
        }
        
        #endregion Private

		#region Public 

		public string GetOpponents( bool showAll) {
			StringBuilder builder = new StringBuilder();
			if( showAll ) {
				builder.Append(currentName);
				foreach (OtherPlayersInformations opponent in opponents) {
					builder.AppendFormat(" {0}",opponent.Name);
				}
			}else{
				builder.AppendFormat("{0}", opponents[0].Name);
				for( int i = 1; i < opponents.Count; ++i ) {
					builder.AppendFormat(" {0}", opponents[i].Name);
				}
			}
			return builder.ToString();
		}

		#endregion

        #region Constructor

        public SimpleBattleInfo(Battle battle) {
            Init(battle);
		}

        public SimpleBattleInfo(Battle battle, IList<PlayerStorage> players)
        {
            this.battle = battle;
            this.players = players;
            Init(battle);
        }

        private void Init(Battle battle)
        {
            battleId = battle.Id;
            currentTurn = battle.CurrentTurn;
            hasEnded = battle.HasEnded;
            battleType = GetBattleType(battle.BattleType);
            battleMode = GetBattleMode(battle.BattleMode);
            currentPlayer = battle.CurrentPlayer;
            isDeployTime = battle.IsDeployTime;
            currentPlayerIndex = GetCurrentPlayer(battle);
            numberOfPlayers = GetNumberOfPlayers();

            PlayerBattleInformation current = battle.PlayerInformation[currentPlayerIndex];

			currentName = WebUtilities.GetBattlePlayerUrl(battleMode, current.Name, current.Owner);
            hasDeployed = current.HasPositioned;
            teamNumber = current.TeamNumber;
            hasLost = current.HasLost;
            hasGaveUp = current.HasGaveUp;
            victoryPercentage = GetVictoryPercentage(battle, current);
            timeouts = current.Timeouts;
            isTurn = battle.CurrentPlayer == current.Owner;
            UpdateNumberOfBattles();
            timeLeft = GetTimeLeft(battle);
            score = GetScore(current);
        	tournamentMode = GetTournamentMode(battle.TournamentMode);
            if (battle.Tournament != null) {
                tournamentid = battle.Tournament.Id;
                if (battle.Tournament.Token != null) {
                    tournamentName = string.Format("{0} {1}", LanguageManager.Instance.Get(battle.Tournament.Token), battle.Tournament.TokenNumber);
                } else {
                    tournamentName = battle.Tournament.Name;
                }
            }

            GatherOtherPlayers(current.Owner, battle);

            if (hasEnded) {
                return;
            }

            if ( (isDeployTime && !hasDeployed)
                || ( !isDeployTime && isTurn && battle.TimedAction[0].StartTick < WebUtilities.BattleReferenceTick)) {
                if( battleMode == BattleMode.Battle || battleMode == BattleMode.Arena) {
                    IncrementUniverseTotalBattles();
                }else{
                    IncrementBattles();
                }
            }
        }

        

		#endregion Constructor
	}
}
