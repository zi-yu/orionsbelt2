using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Interfaces {

	public interface IBattleCoordinate {
		int X { get; set; }
		int Y { get; set; }
		IBattleCoordinate NextCoordinate( PositionType position, int numberOfPlayers );
		IBattleCoordinate LeftCoordinate( PositionType position, int numberOfPlayers );
		IBattleCoordinate RightCoordinate( PositionType position, int numberOfPlayers );
		IBattleCoordinate PreviousCoordinate(PositionType position, int numberOfPlayers);
		IBattleCoordinate Clone();
	}
}
