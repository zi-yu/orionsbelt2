using BotHandler.Engine;
using OrionsBelt.RulesCore.Enum;

namespace BotHandler{
    public class Bot002Calculator : Bot001Calculator{

		#region Public

        public override string Calculate(SimpleElement[,] initialBoard){
        	return null;
        }

		#endregion Public

		#region Constructor

		public Bot002Calculator(Terrain terrain):base(terrain) {
			
		}

		public Bot002Calculator(int turn, Terrain terrain):base(turn,terrain) {
            
		}

		#endregion Constructor
	}
}
