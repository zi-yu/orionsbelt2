using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static terrain information/configuration
    /// </summary>
    public abstract class TerrainInfo : BaseRichness, ITerrainInfo, IFactory {

		#region Fields

		private static Random terrainRandom = new Random((int)DateTime.Now.Ticks);

		#endregion Fields

		#region Private

		private static ITerrainInfo GetRandomTerrain() {
			int idx = terrainRandom.Next(0, terrains.Values.Count);
			int i = 0;
			ITerrainInfo terrain = null;
			foreach (TerrainInfo t in terrains.Values) {
				if (i == idx) {
					terrain = t;
					break;
				}
				++i;
			}
			return terrain;
		}

		#endregion Private

		#region ITerrainInfo Implementation

		public abstract Terrain Terrain { get;}

        #endregion ITerrainInfo Implementation

        #region Static Access

        private static FactoryContainer terrains = new FactoryContainer(typeof(TerrainInfo));

        public static ITerrainInfo Get(Terrain terrain)
        {
            return Get(terrain.ToString());
        }

        public static ITerrainInfo Get(string name)
        {
            return (ITerrainInfo)terrains.create(name);
        }

        public static ITerrainInfo GetRandom()
        {
        	ITerrainInfo terrain = null;
			while (terrain == null || !terrain.AvailableForPlanets) {
				terrain = GetRandomTerrain();
			}
        	return terrain;
        }

		#endregion Static Access

		#region Properties
		
    	public virtual bool AvailableForPlanets {
    		get{ return true; }
    	}

		#endregion Properties

        #region Ctor

        public TerrainInfo()
        {
            SetRichness(Supplies.Resource, 0);
            SetRichness(Tools.Resource, 0);
            SetRichness(Alcohol.Resource, 0);
            SetRichness(CosmicDust.Resource, 0);
            SetRichness(Mercury.Resource, 0);
            SetRichness(Diamonds.Resource, 0);
            SetRichness(Medicine.Resource, 0);
            SetRichness(Animals.Resource, 0);
        }

        #endregion Ctor

        #region IFactoryImplementation

        object IFactory.create(object args)
        {
            return this;
        }

        #endregion IFactoryImplementation

    };
}
