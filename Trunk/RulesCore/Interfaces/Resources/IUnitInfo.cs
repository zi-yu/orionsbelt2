using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Combat unit metadata
    /// </summary>
	public interface IUnitInfo: IResourceWithRulesInfo, IUnitBonus {

        #region Battle Information

        /// <summary>
        /// The unit attack
        /// </summary>
        int Attack { get; }

        /// <summary>
        /// The unit Defense
        /// </summary>
        int Defense { get; }

		/// <summary>
		/// The unit Defense
		/// </summary>
		int Range { get; }

		/// <summary>
		/// The unit cooldown
		/// </summary>
		int CoolDown { get; }

		/// <summary>
		/// Indicates if the unit has catapult
		/// </summary>
		bool Catapult { get; }

		/// <summary>
		/// The unit type
		/// </summary>
		UnitType UnitType { get; }

		/// <summary>
		/// The unit Category
		/// </summary>
		UnitCategory UnitCategory { get; }

		/// <summary>
		/// The unit Displacament
		/// </summary>
		UnitDisplacement UnitDisplacement { get; }

		/// <summary>
		/// The unit type of movement
		/// </summary>
		MovementType MovementType { get; }

        /// <summary>
        /// The unit movement cost
        /// </summary>
        int MovementCost { get; }

		/// <summary>
		/// The unit attack cost
		/// </summary>
		int AttackCost { get; }

        /// <summary>
        /// The unit code
        /// </summary>
        string Code { get; }

		/// <summary>
		/// The value of the unit in battle
		/// </summary>
		int UnitValue { get; }

        /// <summary>
        /// True if the unit is building
        /// </summary>
        bool IsBuilding { get; }

		/// <summary>
		/// True if the unit is Ultimate
		/// </summary>
		bool IsUltimate { get; }
		
		/// <summary>
		/// if this unit will be save in the database
		/// </summary>
		bool CanBeSaved{ get; }

		/// <summary>
		/// If the unit is allowed to attack
		/// </summary>
		bool CanAttack{ get; }

		/// <summary>
		/// Special moves made in the Pos Attack Event
		/// </summary>
		List<ISpecialMove> PosAttackMoves { get; }

		/// <summary>
		/// Special moves made in the Defense Event
		/// </summary>
		List<ISpecialMove> DefenseMoves { get; }
		
		/// <summary>
		/// Special moves made in the Pos Defense Event
		/// </summary>
		List<ISpecialMove> PosDefenseMoves { get; }

		/// <summary>
		/// The value of the unit in battle with the bonus
		/// </summary>
		int GetFinalUnitValue( IBattlePlayer owner, IBattleStatistics statistics );

		/// <summary>
		/// If the unit appear in places lite the AH ou the Friendly board
		/// </summary>
		bool IsShowable { get; }
		
        #endregion Battle Information

        #region Generic Information

        /// <summary>
        /// Time to build per unit
        /// </summary>
        int BuildDuration { get;}

        #endregion Generic Information
        
    };
}
