using DesignPatterns;

namespace OrionsBelt.RulesCore.Interfaces {

	public interface IUltimateWeapon {
		
		/// <summary>
		/// Number of ticks that the ultimate will be available or time before it's used
		/// </summary>
		int Duration { get; }

        /// <summary>
        /// Number of cooldown Ticks
        /// </summary>
        int Cooldown { get; }

        /// <summary>
        /// If the weapon can only be used around a planet
        /// </summary>
        bool LimitedToPlanetsSurroundings { get; }

		/// <summary>
		/// If the ultimate weapon can be deploy anywhere or not
		/// </summary>
		bool HasLimits { get; }

		/// <summary>
        /// If the ultimate weapon is ready to use
        /// </summary>
        bool IsReady(IPlayer owner);

		/// <summary>
		/// Use the ultimate weapon
		/// </summary>
        void Use(IUltimateWeaponArgs args);

        /// <summary>
        /// Charges the usage of the ultimate weapon
        /// </summary>
        void ChargeUsage(IUltimateWeaponArgs args);

        /// <summary>
        /// Refunds the usage of the price of the ultimate
        /// </summary>
        void RefundUsage(IUltimateWeaponArgs args);

	}
}