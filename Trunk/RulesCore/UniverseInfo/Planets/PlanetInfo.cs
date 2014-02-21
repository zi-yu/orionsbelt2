using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static planet information/configuration
    /// </summary>
    public abstract class PlanetInfo : BaseRichness, IPlanetInfo, IFactory {

        #region IPlanetInfo Impplementation

        public virtual IRaceInfo RaceInformation {
            get {
                return RaceInfo.Get(RaceType);
            }
        }

        public abstract Race RaceType { get;}

        public abstract bool HotZone { get; }

        public virtual bool MayAbandonPlanet {
            get { return HotZone; }
        }

		public abstract string ShortIdentifier { get; }

        private List<IFacilitySlot> slots = new List<IFacilitySlot>();
        public IList<IFacilitySlot> FacilitySlots {
            get { return slots; }
        }

        public IFacilitySlot GetSlot(string identifier)
        {
            IFacilitySlot slot = slots.Find(delegate(IFacilitySlot s) { return s.Identifier == identifier; });
            if (slot == null)  {
                throw new RulesException("No slot `{0}' available in planet info `{1}'", identifier, GetType().Name);
            }
            return slot;
        }

        public virtual IFacilityInfo GetUnitBuilderFacility()
        {
            return null;
        }

        public virtual IFacilityInfo GetMainFacility()
        {
            return null;
        }

        public abstract void Initialize(IPlanet planet);

        public string Identifier {
            get { return GetType().Name; }
        }

        #endregion IPlanetInfo Impplementation

        #region Static Access

        private static FactoryContainer planets = new FactoryContainer(typeof(PlanetInfo));

        public static IPlanetInfo Get(string name)
        {
            return (IPlanetInfo)planets.create(name);
        }

        public static IPlanetInfo GetRandomHotZone()
        {
            return Get("GenericPlanet");
        }

        public static IPlanetInfo GetRandomPrivateZone(IPlayer player)
        {
            if (player.RaceInfo == null) {
                throw new RulesException("Player doesn't have race");
            }
            string key = string.Format("{0}PrivatePlanet", player.RaceInfo.Race);
            return Get(key);
        }

        public static IEnumerable<IPlanetInfo> GetAllPlanetInfos()
        {
            foreach (IFactory factory in planets.Values) {
                yield return (IPlanetInfo)factory;
            }
        }

        #endregion Static Access

        #region IFactoryImplementation

        object IFactory.create(object args)
        {
            return this;
        }

        #endregion IFactoryImplementation

    };
}
