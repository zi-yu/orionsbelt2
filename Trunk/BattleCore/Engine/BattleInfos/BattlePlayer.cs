using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class BattlePlayer : IBattlePlayer {

		#region Fields

		private IBattleOwner battleOwner;
		private int playerNumber;
		private IInitialContainer initialContainer;
		private int teamNumber;
		private bool hasPositioned;
		private bool hasLost;
		private bool hasGaveUp;
		private bool updateFleet;
		private bool isTurn = false;
		private int fleetId;
		private int winScore = 0;
		private int loseScore = 0;
		private int victoryPercentage = 0;
		private int dominationPoints = 0;
		private int timeouts = 0;
		private readonly IPositionConversion positionConverter;
	    private string teamName;
		private IUltimateUnit ultimateUnit;
		private PlayerBattleInformation playerBattleInformation;
		
		#endregion Fields

		#region Properties

		public IBattleOwner Owner {
			get { return battleOwner; }
			set { battleOwner = value; }
		}

		public int PlayerNumber {
			get { return playerNumber; }
			set { playerNumber = value; }
		}

		public string Name {
			get { return Owner.Name; }
		}

		public int TeamNumber {
			get { return teamNumber; }
			set { teamNumber = value; }
		}

		public IInitialContainer InitialContainer {
			get { return initialContainer; }
			set { initialContainer = value; }
		}

		public bool HasPositioned {
			get { return hasPositioned; }
			set { hasPositioned = value; }
		}

		public bool HasLost {
			get { return hasLost; }
			set { hasLost = value; }
		}

		public bool UpdateFleet {
			get { return updateFleet; }
			set { updateFleet = value; }
		}

		public int FleetId {
			get { return fleetId; }
			set { fleetId = value; }
		}

		public bool HasGaveUp {
			get { return hasGaveUp; }
			set { hasGaveUp = value; }
		}

		public int WinScore {
			get { return winScore; }
			set { winScore = value; }
		}

		public int LoseScore {
			get { return loseScore; }
			set { loseScore = value; }
		}

		public int VictoryPercentage {
			get { return victoryPercentage; }
			set { victoryPercentage = value; }
		}

		public int DominationPoints {
			get { return dominationPoints; }
			set { dominationPoints = value; }
		}

		public bool IsTurn {
			get { return isTurn; }
			set { 
				isTurn = value; 
			}
		}

		public IPositionConversion PositionConverter {
			get { return positionConverter; }
		}

		public int Timeouts {
			get { return timeouts; }
			set { timeouts = value; }
		}

	    public string TeamName {
	        get { return teamName; }
	        set { teamName = value; }
	    }

		public bool HasUltimateUnit{
			get { return ultimateUnit != null; }
		}

		public IUltimateUnit UltimateUnit{
			get { return ultimateUnit; }
			set { ultimateUnit = value; }
		}

		public PlayerBattleInformation PlayerBattleInformation {
			get { return playerBattleInformation; }
			set { playerBattleInformation = value; }
		}

		#endregion Properties

		#region Public

		public void UpdatePlayerBattleInfo() {
			PlayerBattleInformation.HasPositioned = HasPositioned;
			PlayerBattleInformation.HasLost = HasLost;
			PlayerBattleInformation.HasGaveUp = HasGaveUp;
			PlayerBattleInformation.WinScore = WinScore;
			PlayerBattleInformation.LoseScore = LoseScore;
			PlayerBattleInformation.VictoryPercentage = VictoryPercentage;
			PlayerBattleInformation.DominationPoints = DominationPoints;
			PlayerBattleInformation.Timeouts = Timeouts;
			if (HasUltimateUnit) {
				PlayerBattleInformation.UltimateUnit = UltimateUnit.ToString();
			}else {
				PlayerBattleInformation.UltimateUnit = null;
			}
		}

		#endregion

		#region Constructor

		public BattlePlayer(PlayerBattleInformation playerBattleInformation, IPositionConversion positionConverter, int playerId, IBattleOwner owner, IBattleInfo battleInfo) {
			PlayerBattleInformation = playerBattleInformation;
			FleetId = playerBattleInformation.FleetId;
			HasPositioned = playerBattleInformation.HasPositioned;
			HasLost = playerBattleInformation.HasLost;
			HasGaveUp = playerBattleInformation.HasGaveUp;
			InitialContainer = new InitialContainer(playerBattleInformation, this);
			PlayerNumber = playerId;
			battleOwner = owner;
			WinScore = playerBattleInformation.WinScore;
			LoseScore = playerBattleInformation.LoseScore;
			TeamNumber = playerBattleInformation.TeamNumber;
			UpdateFleet = playerBattleInformation.UpdateFleet;
			DominationPoints = playerBattleInformation.DominationPoints;
			Timeouts = playerBattleInformation.Timeouts;
		    TeamName = playerBattleInformation.TeamName;
			this.positionConverter = positionConverter;

			if ( !string.IsNullOrEmpty(playerBattleInformation.UltimateUnit) ) {
				ultimateUnit = new UltimateUnit(playerBattleInformation.UltimateUnit, this, battleInfo);
			}
		}

		public BattlePlayer(IBattleOwner owner) {
            Owner = owner;
        }

		#endregion Constructor


	}
}
