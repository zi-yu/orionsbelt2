using DesignPatterns;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IEffect: IFactory {

		/// <summary>
		/// Turns left for the event to disappear
		/// </summary>
		int TurnsLeft{ get; }

		/// <summary>
		/// Name of the effect
		/// </summary>
		string Name{ get; }

		/// <summary>
		/// Code to represent the effect
		/// </summary>
		string Code { get; }

		/// <summary>
		/// Owner of the effect
		/// </summary>
		IElement Element { get; }

		/// <summary>
		/// Indicates if this effect can be applied several times
		/// to the same Element. The Default value is false.
		/// </summary>
		bool Cumulative { get; }

		/// <summary>
		/// Indicates if this effect was been resolved 
		/// at the end of the battle
		/// </summary>
		bool Resolved { get; set; }

		/// <summary>
		/// Indicates if this effect has ended
		/// </summary>
		bool Ended { get; }

		/// <summary>
		/// Resolves the effect at the end of each turn.
		/// </summary>
		bool Resolve( IBattleInfo battleInfo );

	}
}
