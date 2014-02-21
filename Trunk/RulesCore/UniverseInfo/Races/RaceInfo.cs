using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static race information/configuration
    /// </summary>
    public abstract class RaceInfo : BaseRichness, IRaceInfo, IFactory {

        #region RaceInfo Implementation

        public abstract Race Race { get;}

        public abstract IIntrinsicInfo RichResource { get;}

        public abstract IIntrinsicInfo MoreNeededResource { get;}

        public abstract void Initialize(IPlayer player);

        #endregion RaceInfo Implementation

        #region Static Access

        private static FactoryContainer races = new FactoryContainer(typeof(RaceInfo));

        public static IRaceInfo Get(Race race)
        {
            return Get(race.ToString());
        }

        public static IRaceInfo Get(string name)
        {
            return (IRaceInfo)races.create(name);
        }

        public static IEnumerable<IRaceInfo> GetAvailableRaces() 
        {
            return new IRaceInfo[] { 
                    Get(Race.LightHumans), 
                    Get(Race.DarkHumans), 
                    Get(Race.Bugs)
                };
        }

		public static IEnumerable<IRaceInfo> GetMobs() {
			return new IRaceInfo[] { 
                    Get(Race.Mercs),
                    Get(Race.SpaceForce)
                };
		}

        public static IRaceInfo LightHumans {
            get { return Get(Race.LightHumans); }
        }

        public static IRaceInfo DarkHumans {
            get { return Get(Race.DarkHumans); }
        }

        public static IRaceInfo Bugs {
            get { return Get(Race.Bugs); }
        }

		public static IRaceInfo Mercs {
			get { return Get(Race.Mercs); }
		}

        public static IRaceInfo SpaceForce {
            get { return Get(Race.SpaceForce); }
        }

		public static bool IsMob(Race race) {
			foreach (IRaceInfo raceInfo in GetMobs()) {
				if( raceInfo.Race == race ) {
					return true;
				}
			}
			return false;
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
