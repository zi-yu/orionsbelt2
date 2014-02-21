using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IElement {

		/// <summary>
		/// Cuurent position of the element: N,S,E,W
		/// </summary>
		PositionType Position { get; set; }

		/// <summary>	
		/// Coordinate of this element in the game board
		/// </summary>
		IBattleCoordinate Coordinate { get; set; }

		/// <summary>
		/// Object that represents the unit in this element
		/// </summary>
		IUnitInfo Unit { get; set; }

		/// <summary>
		/// Quantity of units in this element
		/// </summary>
		int Quantity { get; set; }

		/// <summary>
		/// Original Quantity of units in this element
		/// </summary>
		int OriginalQuantity { get; set; }

		/// <summary>
		/// Remaining defense of the last unit in the element
		/// </summary>
		int RemainingDefense { get; set; }

		/// <summary>
		/// Gets the owner of this element
		/// </summary>
		IBattlePlayer Owner { get; set; }

		/// <summary>
		/// Indicates if this element can be moved
		/// </summary>
		bool CanBeMoved { get; set; }

		/// <summary>
		/// Indicates if this element can use special Abilities
		/// </summary>
		bool CanUseSpecialAbilities { get; set; }

		/// <summary>
		/// Returns true if the element has effects
		/// </summary>
		bool HasEffects { get; }

		/// <summary>
		/// Unit Cooldown
		/// </summary>
		int Cooldown { get; set; }

		Dictionary<string, List<IEffect>> Effects {get;}

	    bool IsInfestated{
	        get;
	    }

	    /// <summary>
		/// Adds an new effect to this element
		/// </summary>
		/// <param name="effect">Effect to add</param>
		void AddEffect(IEffect effect);

		/// <summary>
		/// Resolves all the effects
		/// </summary>
		void ResolveEffects(IBattleInfo info);

		/// <summary>
		/// Validates the move of an Element
		/// </summary>
		/// <param name="src">Source coordinate</param>
		/// <param name="dst">Destiny Coordinate</param>
		/// <returns>True if the unit can be moved</returns>
		bool ValidateMove( IBattleCoordinate src, IBattleCoordinate dst );

		/// <summary>
		/// Clones the current element
		/// </summary>
		IElement Clone();

		/// <summary>
		/// Gets the attack with all the bonus
		/// </summary>
		int GetAttack( Terrain terrain, IUnitInfo target );

		/// <summary>
		/// Gets the defense with all the bonus
		/// </summary>
		int GetDefense( Terrain terrain, IUnitInfo target );

		/// <summary>
		/// Gets the range with all the bonus
		/// </summary>
		int GetRange( Terrain terrain, IUnitInfo target );

		/// <summary>
		/// Converts the element to Json
		/// </summary>
		/// <returns></returns>
		string ToJson();

		/// <summary>
		/// Adds an effect 
		/// </summary>
		/// <param name="element">Element from where to obtain the effect</param>
		void AddEffects(IElement element);

		/// <summary>
		/// Resolves the attack cycle of an element
		/// </summary>
		/// <param name="BattleInfo">Object that represents the battle</param>
		/// <param name="target">Unit that is being targeted</param>
		/// <param name="executeDefense">Executres the defense</param>
		void ResolveAttackCycle( IBattleInfo BattleInfo, IElement target, bool executeDefense );
	}
}
