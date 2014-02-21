using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class PlayerStatistics: IPlayerStatistics {

		#region Fields

		private readonly Dictionary<string, int> statistics = new Dictionary<string, int>();
		private readonly Dictionary<IUnitInfo, int> unitsDestroyed = new Dictionary<IUnitInfo, int>();
		private readonly Dictionary<IUnitInfo, int> unitsPlayersDestroyedByOthers = new Dictionary<IUnitInfo, int>();
		private int totalUnits = 0;

		private delegate void ParseUnitsDestroyed( IPlayerStatistics stats, string units );
		private static readonly Dictionary<string, ParseUnitsDestroyed> unitsDestroyedDelegates = new Dictionary<string, ParseUnitsDestroyed>();

		#endregion Fields

		#region Properties

		public bool HasHeavy {
			get { return HeavyCount != 0; }
		}

		public bool HasMedium {
			get { return MediumCount != 0; }
		}

		public bool HasLight {
			get { return LightCount != 0; }
		}

		public bool HasAirUnits {
			get { return AirUnitsCount != 0; }
		}

		public bool HasGroundUnits {
			get { return GroundUnitsCount != 0; }
		}

		public bool HasWaterUnits {
			get { return WaterUnitsCount != 0; }
		}

		public bool HasOrganic {
			get { return OrganicCount != 0; }
		}

		public bool HasMechanic {
			get { return MechanicCount != 0; }
		}

		public int HeavyCount {
			get { return GetTotalUnits(UnitCategory.Heavy); }
		}

		public int MediumCount {
			get { return GetTotalUnits(UnitCategory.Medium); }
		}

		public int LightCount {
			get { return GetTotalUnits(UnitCategory.Light); }
		}

		public int AirUnitsCount {
			get { return GetTotalUnits(UnitDisplacement.Air); }
		}

		public int GroundUnitsCount {
			get { return GetTotalUnits(UnitDisplacement.Ground); }
		}

		public int WaterUnitsCount {
			get { return GetTotalUnits(UnitDisplacement.Water); }
		}

		public int OrganicCount {
			get { return GetTotalUnits(UnitType.Organic); }
		}

		public int MechanicCount {
			get { return GetTotalUnits(UnitType.Mechanic); }
		}

		/// <summary>
		/// Total Units
		/// </summary>
		public int TotalUnits {
			get{ return totalUnits; }
		}

		/// <summary>
		/// Units destroyed by the player
		/// </summary>
		public Dictionary<IUnitInfo, int> UnitsDestroyed {
			get { return unitsDestroyed; }
		}

		/// <summary>
		/// Units destroyed by other players
		/// </summary>
		public Dictionary<IUnitInfo, int> UnitsDestroyedByOthers {
			get { return unitsPlayersDestroyedByOthers; }
		}

		#endregion Properties

		#region Private

		private int GetTotalUnits( string name ) {
			return statistics[name];
		}

		private int GetTotalUnits( UnitType unitType ) {
			return GetTotalUnits(unitType.ToString());
		}

		private int GetTotalUnits( UnitDisplacement unitType ) {
			return GetTotalUnits(unitType.ToString());
		}

		private int GetTotalUnits( UnitCategory unitType ) {
			return GetTotalUnits(unitType.ToString());
		}

        private void SafeRemove(string key, int quantity) {
            if (statistics.ContainsKey(key)) {
                statistics[key] -= quantity;
            }
        }

		#endregion Private

		#region Public

		/// <summary>
		/// Adds a new unit
		/// </summary>
		public void Add( IElement element ) {
			int quantity = element.Quantity;

			statistics[element.Unit.UnitCategory.ToString()] += quantity;
			statistics[element.Unit.UnitDisplacement.ToString()] += quantity;
			statistics[element.Unit.UnitType.ToString()] += quantity;
			if( statistics.ContainsKey(element.Unit.Name) ) {
				statistics[element.Unit.Name] += quantity;
			} else {
				statistics.Add(element.Unit.Name, quantity);
			}

			totalUnits += quantity;
		}

		/// <summary>
		/// Add a new unit to the destroyed unit statistics
		/// </summary>
		public void AddDestroyedUnit( IUnitInfo unit, int quantity ) {
			if( !UnitsDestroyed.ContainsKey(unit) ) {
				UnitsDestroyed.Add(unit,quantity);
			}else {
				UnitsDestroyed[unit] += quantity;
			}
		}

		/// <summary>
		/// Adds a unit of the player that has been destroyed
		/// </summary>
		public void AddDestroyedUnitByOtherPlayer( IUnitInfo unit, int quantity ) {
			if( !UnitsDestroyedByOthers.ContainsKey(unit) ) {
				UnitsDestroyedByOthers.Add(unit, quantity);
			} else {
				UnitsDestroyedByOthers[unit] += quantity;
			}
		}

		/// <summary>
		/// Removes a unit from the statistics
		/// </summary>
		public void RemoveUnit( IUnitInfo unit, int quantity ) {
            SafeRemove(unit.UnitCategory.ToString(),quantity);
			SafeRemove(unit.UnitDisplacement.ToString(),quantity);
			SafeRemove(unit.UnitType.ToString(),quantity);
            SafeRemove(unit.Name, quantity);
			totalUnits -= quantity;
		}

		/// <summary>
		/// Parses a string that contains statistics about the units destroyed by a player
		/// </summary>
		/// <param name="unitsDestroyedInfo">statistics to parse</param>
		public void Parse( string unitsDestroyedInfo ) {
			string[] uD = unitsDestroyedInfo.Split('|');
			foreach (string s in uD) {
				if( !string.IsNullOrEmpty(s)){
					string[] unitsInformation = s.Split(':');
					unitsDestroyedDelegates[unitsInformation[0]](this, unitsInformation[1]);
				}
			}
		}

		#endregion Public

		#region Units Destroyed Delegates

		/// <summary>
		/// generic parser for the units destroyed
		/// </summary>
		/// <param name="unitsDestroyed">String with the destroyed units information</param>
		/// <param name="unitContainer">Container where to put the destroyed units</param>
		private static void GenericParseUnitsDestroyed( string unitsDestroyed, Dictionary<IUnitInfo, int> unitContainer ) {
			string[] units = unitsDestroyed.Split(';');
			foreach( string unit in units ) {
				if( !string.IsNullOrEmpty(unit) ) {
					string[] unitInformation = unit.Split('-');
					int quantity;
					if( int.TryParse(unitInformation[1], out quantity) ) {
						IUnitInfo unitInfo = Unit.Create(unitInformation[0]);
						unitContainer.Add(unitInfo, quantity);
					}
				}
			}
		}

		/// <summary>
		/// Parses the units destroyed by the player
		/// </summary>
		/// <param name="stats">Object that represents the statistis of a player</param>
		/// <param name="unitsDestroyed">Units destroyed</param>
		private static void ParseUnitsDestoyed( IPlayerStatistics stats, string unitsDestroyed ) {
			GenericParseUnitsDestroyed(unitsDestroyed, stats.UnitsDestroyed);
		}

		/// <summary>
		/// Parses the units destroyed by other players
		/// </summary>
		/// <param name="stats">Object that represents the statistis of a player</param>
		/// <param name="unitsDestroyed">Units destroyed</param>
		private static void ParseUnitsDestoyedByOthers( IPlayerStatistics stats, string unitsDestroyed ) {
			GenericParseUnitsDestroyed(unitsDestroyed, stats.UnitsDestroyedByOthers);
		}

		#endregion Units Destroyed Delegates

		#region Object Implementation

		/// <summary>
		/// Converts the dictionary of destroyed units into it's string representation
		/// </summary>
		/// <param name="code"></param>
		/// <param name="container"></param>
		/// <returns></returns>
		private static string UnitsToString( string code, Dictionary<IUnitInfo, int> container ) {
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("{0}:", code);
			foreach( KeyValuePair<IUnitInfo, int> pair in container ) {
				builder.AppendFormat("{0}-{1};", pair.Key.Code, pair.Value);
			}

			return builder.ToString();
		}

		/// <summary>
		/// Converts a PlayerStatistics object into it's string representation
		/// </summary>
		/// <returns>The string representation of this object</returns>
		public override string ToString() {
			StringBuilder builder = new StringBuilder();

			builder.Append( UnitsToString("ud", UnitsDestroyed) );
			builder.AppendFormat( "|{0}", UnitsToString("uod", UnitsDestroyedByOthers) );

			return builder.ToString();
		}		

		#endregion Object Implementation

		#region Constructor

		static PlayerStatistics() {
			unitsDestroyedDelegates.Add("ud",ParseUnitsDestoyed );
			unitsDestroyedDelegates.Add("uod", ParseUnitsDestoyedByOthers);
		}
		
		public PlayerStatistics() {
			statistics.Add(UnitCategory.Heavy.ToString(), 0);
			statistics.Add(UnitCategory.Medium.ToString(), 0);
			statistics.Add(UnitCategory.Light.ToString(), 0);
			statistics.Add(UnitCategory.Ultimate.ToString(), 0);
			statistics.Add(UnitCategory.Special.ToString(), 0);
			statistics.Add(UnitDisplacement.Air.ToString(), 0);
			statistics.Add(UnitDisplacement.Ground.ToString(), 0);
			statistics.Add(UnitDisplacement.Water.ToString(), 0);
			statistics.Add(UnitType.Organic.ToString(), 0);
			statistics.Add(UnitType.Mechanic.ToString(), 0);
		}

		public PlayerStatistics( string unitsDestroyed ) : this() {
			Parse(unitsDestroyed);
		}

		#endregion Constructor

	}
}
