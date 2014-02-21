using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class ParalyseAttack: ISpecialMove {

		#region Fields

		private static readonly ParalyseAttack paralyseAttack = new ParalyseAttack();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return paralyseAttack; }
		}

		#endregion Public 

		#region ISpecialMove Members

		public void ResolveMove( IBattleInfo battleInfo, IElement unit, IElement target ) {
			if( battleInfo.SectorRawHasElement(target.Coordinate) ) {
				target.CanBeMoved = false;
                if (battleInfo.NumberOfPlayers == 2){
                    target.AddEffect(new Paralyse(target));
                }else {
                    target.AddEffect(new Paralyse(target,3));
                }

				//battleInfo.AddTurnMessage(new ParalyseMessage(battleInfo.Id, battleInfo.CurrentTurn, target.Coordinate.ToString()));
			}
		}

		#endregion ISpecialMove Members

		#region Constructor

		private ParalyseAttack() { }

		#endregion Constructor

	}
}
