using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IBattlePlayer {
		IBattleOwner Owner { get; set; }
		string Name{ get; }
		int PlayerNumber { get; set; }
		int TeamNumber { get; set; }
		int FleetId { get;set;}
		int WinScore { get;set;}
		int LoseScore { get;set;}
		int VictoryPercentage { get;set;}
		int DominationPoints { get;set;}
		int Timeouts { get;set;}
		IInitialContainer InitialContainer{ get; }
		bool UpdateFleet { get; set; }
		bool HasPositioned{ get; set; }
		bool HasLost { get; set; }
		bool HasGaveUp {get;set;}
		bool IsTurn {get;set;}
		IPositionConversion PositionConverter {get;}
	    string TeamName {get;set;}
		bool HasUltimateUnit{get;}
		IUltimateUnit UltimateUnit { get;set;}
		PlayerBattleInformation PlayerBattleInformation { get;set;}
		void UpdatePlayerBattleInfo();
	}
}
