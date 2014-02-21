using OrionsBelt.Generic.Log;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class Replicator: ISpecialMove {

		#region Fields

		private static readonly Replicator replicator = new Replicator();

		#endregion Fields

        #region Private

        private static bool CanReplicate(IElement unit, IElement target){
            UnitCategory attackerCategory = unit.Unit.UnitCategory;
            UnitCategory defenderCategory = target.Unit.UnitCategory;
            switch (attackerCategory){
                case UnitCategory.Medium:
                    return defenderCategory == UnitCategory.Medium || defenderCategory == UnitCategory.Heavy;
                case UnitCategory.Heavy:
                    return defenderCategory == UnitCategory.Heavy;
                default:
                    return true;
            }
        }

        #endregion Private

		#region Public

		public static ISpecialMove Instance {
			get { return replicator; }
		}

		#endregion Public 

		#region ISpecialMove Members

		public void ResolveMove( IBattleInfo battleInfo, IElement unit, IElement target ) {
            if( CanReplicate(unit, target) ) {
			    int defense = target.GetDefense(battleInfo.Terrain, unit.Unit);
                //Logger.Info("Replicator> target:{0};defense:{1}", target.Unit.Name, defense);

			    int totalDamage = AttackUtils.GetTotalDamage(battleInfo, unit, target);
                //Logger.Info("Replicator> totalDamage:{0}", totalDamage);

			    int unitsDestroyed = totalDamage/defense;
                //Logger.Info("Replicator> unitsDestroyed 1:{0}", unitsDestroyed);
				if (unitsDestroyed > target.OriginalQuantity ) {
					//Logger.Info("Replicator> unitsDestroyed 2:{0};target.Quantity:{1}", unitsDestroyed, target.Quantity);
					unitsDestroyed = target.OriginalQuantity;
				}
				
			    unit.Quantity += unitsDestroyed;

			    battleInfo.AddTurnMessage( 
				    new ReplicatorMessage(
					    battleInfo.Id,
					    battleInfo.CurrentTurn, 
					    unit.Unit.Name,
					    unitsDestroyed
				    )
			    );
            }
		}

        #endregion

		#region Constructor

		private Replicator() { }

		#endregion Constructor

	}
}
