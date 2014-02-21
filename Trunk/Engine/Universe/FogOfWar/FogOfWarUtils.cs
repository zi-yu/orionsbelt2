using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	internal class FogOfWarUtils {

		#region Fields

		#endregion Fields

		#region Private

		private static string GetWhere(SectorInformationContainer sectorInformationContainer) {
			List<Coordinate> systems = sectorInformationContainer.SystemCoordinates;
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat(" ((f.SystemX = {0} and f.SystemY = {1})", systems[0].X, systems[0].Y );
			for( int i = 1; i < systems.Count; ++i ) {
				builder.AppendFormat(" or (f.SystemX = {0} and f.SystemY = {1})", systems[i].X, systems[i].Y);
			}
			builder.Append(")");
			if(PlayerUtils.HasPlayer) {
				builder.AppendFormat(" and f.OwnerNHibernate.Id = {0}", PlayerUtils.Current.Id);	
			}
			return builder.ToString();
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Creates the fog of war for the private sector
		/// </summary>
		/// <param name="player">Owner of the fog of war</param>
		public static void CreateInitialFogOfWar(IPlayer player) {
			using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()) {
				FogOfWarStorage fogOfWar = fogPersistance.Create();
				fogOfWar.HasDiscoveredAll = false;
				fogOfWar.HasDiscoveredHalf = false;
				fogOfWar.Sectors = "1_1;1_2;1_3;2_1;2_2;2_3;3_1;3_2;3_3;";
				fogOfWar.SystemX = 0;
				fogOfWar.SystemY = 0;
				fogOfWar.Owner = player.Storage;

				fogPersistance.Update(fogOfWar);
			}
		}

		/// <summary>
		/// Gets the fog of war forte pa systems
		/// </summary>
		/// <param name="sectorInformationContainer"></param>
		public static FogOfWarContainer GetFogOfWar(SectorInformationContainer sectorInformationContainer) {
			using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()) {
				IList<FogOfWarStorage> fogOfWar = fogPersistance.TypedQuery("select f from SpecializedFogOfWarStorage f where {0}", GetWhere(sectorInformationContainer));
				return new FogOfWarContainer(fogOfWar);
			}
		}

		/// <summary>
		/// Gets the fog of war forte pa systems
		/// </summary>
		/// <param name="player"></param>
		public static FogOfWarContainer GetFogOfWar(IPlayer player) {
			IList<FogOfWarStorage> fogOfWar = Hql.StatelessQuery<FogOfWarStorage>("select f from SpecializedFogOfWarStorage f where f.OwnerNHibernate.Id = :id",Hql.Param("id",player.Id));
			return new FogOfWarContainer(fogOfWar);
		}

		public static void SaveFogOfWar(ISector sector, ISector nextSector) {
			SaveFogOfWar(sector, nextSector, sector.Owner);
		}

		/// <summary>
		/// Saves the fogOfWar arround the coordinate
		/// </summary>
		/// <param name="sector"></param>
        /// <param name="nextSector"></param>
		/// <param name="owner"></param>
		public static void SaveFogOfWar(ISector sector, ISector nextSector, IPlayer owner) {
			DateTime start = DateTime.Now;
			SectorInformation sectorInformation = UniverseUtils.CreateSectorInformation(sector);
            bool privateSystem = nextSector.SystemCoordinate.IsPrivateSystem();
			FogOfWarContainer fogOfWarContainer = Universe.GetFogOfWar(owner.Id);
			fogOfWarContainer.VisibleCoordinates.Clear();
            fogOfWarContainer.AddVisibleCoordinates(sectorInformation);
			Console.WriteLine(" » Loading Fog Of War took {0}ms", (DateTime.Now - start).TotalMilliseconds);
			start = DateTime.Now;

			List<FogOfWar> updated = new List<FogOfWar>();
			foreach (SectorCoordinate coordinate in fogOfWarContainer.VisibleCoordinates) {
                if (!coordinate.IsValid(privateSystem)){
                    continue;
                }
		    	FogOfWar fogOfWar;
				if( !fogOfWarContainer.DiscoveredElements.ContainsKey(coordinate.System)) {
					fogOfWar = new FogOfWar(coordinate.System);
		            fogOfWarContainer.DiscoveredElements[coordinate.System] = fogOfWar;
		        }else {
					fogOfWar = fogOfWarContainer.DiscoveredElements[coordinate.System];
				}
		        fogOfWar.AddCoordinate(coordinate);
				updated.Add(fogOfWar);
				
		    }
			Console.WriteLine(" » AddCoordinate took {0}ms", (DateTime.Now - start).TotalMilliseconds);
			start = DateTime.Now;
			using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()) {
				foreach (FogOfWar fogOfWar in updated) {
					if (fogOfWar.IsDirty) {
						if (fogOfWar.Owner == null) {
							fogOfWar.Owner = owner;
						}

                        fogOfWar.PrepareStorage();
						fogOfWar.UpdateStorage();
						fogPersistance.Update(fogOfWar.Storage);
					}
				}
			}
			Console.WriteLine(" » Updating Fog of War took {0}ms", (DateTime.Now - start).TotalMilliseconds);
		}

		#endregion Public

		
	}
}
