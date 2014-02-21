using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using System;

namespace OrionsBelt.BattleCore {
	public static class AttackUtils {
		
		#region Private

		/// <summary>
		/// Gets all the damage made by the attack unit into the targeted unit
		/// </summary>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="source">Attacker unit</param>
		/// <param name="target">Targeted unit</param>
		/// <param name="writeMessage">Indicates if a Battle message is written</param>
		/// <returns>New value of the attack</returns>
		private static int GetTotalDamage( IBattleInfo battleInfo, IElement source, IElement target, bool writeMessage ) {
			int totalDamage = source.GetAttack(battleInfo.Terrain, target.Unit) * source.Quantity;
			int distance = Distance(source, target);

			return CalculatePenalty(distance, totalDamage, battleInfo, writeMessage);
		}

		

		/// <summary>
		/// Calculates the new attack value with the penalty (if applied)
		/// </summary>
		/// <param name="distance">distance to the target</param>
		/// <param name="attack">Attack's initial value</param>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="writeMessage">if this method will write the battle message</param>
		/// <returns>New value of the attack</returns>
		private static int CalculatePenalty( int distance, int attack, IBattleInfo battleInfo, bool writeMessage ) {
			if( distance < 4 ) {
				return attack;
			}

			double percent = ( 7 - distance ) * 0.25;

			if( writeMessage ) {
				double percentValue = 100 - ( percent * 100 );
				battleInfo.AddTurnMessage(
					new PenaltyMessage(battleInfo.Id, battleInfo.CurrentTurn, percentValue, distance)
				);
			}

			return (int) ( ( percent * attack ) + 0.5 );
		}
		
		

		#endregion Private

		#region Public

		/// <summary>
		/// Calculates the distance between two elements
		/// </summary>
		/// <returns>Distance of the attack</returns>
		public static int Distance( IElement source, IElement target ) {
			if( source.Coordinate.X == 13 ) {
				return Math.Abs(source.Coordinate.X - target.Coordinate.X);
			}

			//Normal front attack or attack to player 2 Ultimate Unit
			if (source.Coordinate.X == target.Coordinate.X /*||
				( target.Coordinate.Y == 0 && source.Position == PositionType.N )*/
			) {
				return Math.Abs(source.Coordinate.Y - target.Coordinate.Y);
			}

			return Math.Abs(source.Coordinate.X - target.Coordinate.X);

		}

		/// <summary>
		/// Gets all the damage made by the attack unit into the targeted unit
		/// </summary>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="source">Attacker unit</param>
		/// <param name="target">Targeted unit</param>
		/// <returns>New value of the attack</returns>
		public static int GetTotalDamage( IBattleInfo battleInfo, IElement source, IElement target ) {
			return GetTotalDamage(battleInfo, source, target, false);
		}

		/// <summary>
		/// Resolves the attack between 2 units
		/// </summary>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="source">Attacker unit</param>
		/// <param name="target">Targeted unit</param>
		public static void ResolveAttack( IBattleInfo battleInfo, IElement source, IElement target ) {
			int defense = target.GetDefense(battleInfo.Terrain, source.Unit);
			int totalDamage = GetTotalDamage(battleInfo, source, target, true);
			
			int unitsDestroyed = ResolveDamage(totalDamage, defense, battleInfo, target);

			battleInfo.BattleStatistics.UpdateStatistics(source.Owner,target.Owner,target.Unit,unitsDestroyed);

			battleInfo.AddTurnMessage(
				new AttackMessage(
					battleInfo.Id,
					battleInfo.CurrentTurn, 
					source.Coordinate,
					target.Coordinate
				)
			);

			battleInfo.AddTurnMessage(
				new DamageMessage(
					battleInfo.Id,
					battleInfo.CurrentTurn,
					source.Quantity,
					source.Unit.Name,
					totalDamage,
					unitsDestroyed,
					target.Unit.Name
				)
			);
		}

		/// <summary>
		/// Calculates the remaining units of the targeted unit and updates the battleInfo
		/// </summary>
		/// <param name="totalDamage">Damage made</param>
		/// <param name="totalDefense">Total defense of the targeted unit/param>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="target">targeted unit</param>
		/// <returns>The number of destroyed units</returns>
		public static int ResolveDamage( int totalDamage, int totalDefense, IBattleInfo battleInfo, IElement target ) {
			int unitsDestroyed = totalDamage / totalDefense;
			int destroyed = unitsDestroyed;

			if( unitsDestroyed >= target.Quantity || unitsDestroyed < 0 ) {
				destroyed = target.Quantity;
				battleInfo.SectorRemoveElement(target.Coordinate);
			} else {
				int quantity = target.Quantity;
				quantity -= unitsDestroyed;

				if (totalDefense > target.Unit.Defense) {
					double td = totalDamage;
					double result = (target.Unit.Defense*td) / totalDefense;
					totalDamage = (int)result;
				}

				int remain = target.RemainingDefense - (totalDamage - (unitsDestroyed * target.Unit.Defense));
				if (remain <= 0) {
					quantity -= 1;
					destroyed += 1;
					if (quantity > 0 ) {
						target.RemainingDefense = target.Unit.Defense;
					}
				}else {
					target.RemainingDefense = remain;
				}

				if( quantity <= 0 ) {
					battleInfo.SectorRemoveElement(target.Coordinate);
				}else{
					target.Quantity = quantity;
				}
			}
			return destroyed;
		}

		#endregion Public
	}
}
