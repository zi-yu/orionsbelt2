
using System.Collections.Generic;
using System.Reflection;
using DesignPatterns;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {
	public static class UltimateWeaponChooser {

		#region Fields

		private delegate IUltimateWeapon ChooseUltimate(int ultimateLevel);
		private static readonly Dictionary<Race,ChooseUltimate> races = new Dictionary<Race, ChooseUltimate>();
		private delegate IUltimateWeaponArgs UltimateParameters(IPlayer owner, ISector sector);
		private static readonly Dictionary<Race, UltimateParameters> parameters = new Dictionary<Race, UltimateParameters>();
		private static readonly FactoryContainer container = new FactoryContainer(typeof(UltimateCreatorBase));

		#endregion Fields

		#region Delegates

		#region Get Ultimate Object

		private static IUltimateWeapon CreateBeacon(int ultimateLevel) {
			return (IUltimateWeapon)container.create("BeaconLevel" + ultimateLevel);
		}

		private static IUltimateWeapon FireDevastation(int ultimateLevel) {
			return (IUltimateWeapon)container.create("DevastationLevel" + ultimateLevel);
		}

		private static IUltimateWeapon CreateWormHole(int ultimateLevel) {
			return (IUltimateWeapon)container.create("WormHoleLevel" + ultimateLevel);
		}

		#endregion Get Ultimate Object

		#region Get Ultimate Parameters

		private static IUltimateWeaponArgs CreateBeaconParameters(IPlayer owner, ISector sector) {
			return new BeaconCreatorArgs(owner,sector.Coordinate);
		}

		private static IUltimateWeaponArgs CreateDevastationParameters(IPlayer owner, ISector sector) {
			return null;
		}

		private static IUltimateWeaponArgs CreateWormHoleParameters(IPlayer owner, ISector sector) {
			return new WormHoleCreatorArgs(owner,sector.Coordinate);
		}

		#endregion Get Ultimate Parameters

		#endregion Delegates

		#region Private

		#endregion Private

		#region Public

		public static IUltimateWeapon GetUltimateWeapon(IPlayer owner) {
			int level = owner.UltimateWeaponLevel;
			return races[owner.RaceInfo.Race](level);
		}

        public static IUltimateWeaponArgs GetParameters(IPlayer owner, ISector sector) {
			return parameters[owner.RaceInfo.Race](owner,sector);
		}

        public static WormHoleCreatorBase GetWormHoleUltimateWeapon(int level) {
            return (WormHoleCreatorBase)races[Race.Bugs](level);
        }

		#endregion Public

		#region Constructor

		static UltimateWeaponChooser() {
			races[Race.Bugs] = CreateWormHole;
			races[Race.DarkHumans] = FireDevastation;
			races[Race.LightHumans] = CreateBeacon;

			parameters[Race.Bugs] = CreateWormHoleParameters;
			parameters[Race.DarkHumans] = CreateDevastationParameters;
			parameters[Race.LightHumans] = CreateBeaconParameters;
		}

		#endregion Constructor
	}
}
