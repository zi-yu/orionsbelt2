namespace BotHandler.Engine {
	public class Bot002Moves : Moves {

		#region Fields

		protected static Bot002Moves instance = new Bot002Moves();

		#endregion Fields

		#region Properties

		public static Moves Instance {
			get { return instance; }
		}

		#endregion Properties
	
		#region Public

		public override void MakeMoves(Battle battle) {
            SimpleElement[,] start = battle.GetSimpleRepresentation();
			Bot001Calculator movesCalculator = new Bot001Calculator(battle.Turn, battle.Terrain);
            MakeMoves(battle, movesCalculator.Calculate(start));
		}

		#endregion Public

		#region Constructor

		private Bot002Moves() {
        	botName = "Bot002";
        }

		#endregion Constructor


	}
}
