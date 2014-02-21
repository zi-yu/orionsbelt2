using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore {

    /// <summary>
    /// Utility Methods
    /// </summary>
    public static class RaceUtils {

        #region Static Race Collections

        private static readonly Race[] darkHumans = { Race.DarkHumans };
        public static Race[] DarkHumans {
            get { return darkHumans; }
        }

        private static readonly Race[] allraces = { Race.Global };
        public static Race[] AllRaces {
            get { return allraces; }
        }

        private static readonly Race[] norace = { Race.None };
        public static Race[] NoRace {
            get { return norace; }
        }

        private static readonly Race[] lightHumans = { Race.LightHumans };
        public static Race[] LightHumans {
            get { return lightHumans; }
        }

        private static readonly Race[] humans = { Race.LightHumans, Race.DarkHumans };
        public static Race[] Humans {
            get { return humans; }
        }

        private static readonly Race[] bugs = { Race.Bugs };
        public static Race[] Bugs {
            get { return bugs; }
        }

		private static readonly Race[] mercs = { Race.Mercs };
		public static Race[] Mercs {
			get { return mercs; }
		}

		private static readonly Race[] spaceForce = { Race.SpaceForce };
		public static Race[] SpaceForce {
			get { return spaceForce; }
		}

		private static readonly Race[] mobs = { Race.Mercs, Race.SpaceForce };
		public static Race[] Mobs {
			get { return mobs; }
		}

        private static readonly Race[] dummy = { Race.LightHumans, Race.Mercs, Race.SpaceForce };
        public static Race[] Dummy{
            get { return dummy; }
        }

        #endregion Static Race Collections

    };

}
