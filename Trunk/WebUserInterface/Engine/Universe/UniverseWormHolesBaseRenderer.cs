using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {

	public abstract class UniverseWormHolesBaseRenderer {

		#region Fields

		private readonly Dictionary<int, int> xMapping = new Dictionary<int, int>();
		private readonly Dictionary<int, int> yMapping = new Dictionary<int, int>();
        private static readonly string imageStr = "<img src='{0}' style='top:{1}px;left:{2}px' class='wormHole' system='{3}_{4}' sector='{5}_{6}'/>";
        private static readonly string imageCurrentStr = "<img src='{0}' style='top:{1}px;left:{2}px' class='wormHole' system='{3}_{4}' sector='{5}_{6}' current='true'/>";
		private static readonly string image = ResourcesManager.GetUniverseImage("WormHoleSmallest", "png");
		private static readonly string imageCurrent = ResourcesManager.GetUniverseImage("WormHoleSmallestCurrent", "png");
		private static readonly string imagePrivate = ResourcesManager.GetUniverseImage("WormHoleSmallestPrivate", "png");
		private static readonly string imagePrivateCurrent = ResourcesManager.GetUniverseImage("WormHoleSmallestPrivateCurrent", "png");
		private static readonly List<Coordinate> exceptions = new List<Coordinate>();
		protected int[] xyWormHoleMap;
		
		#endregion Fields 

		#region Private

		private static int GetIdxOdd(int i) {
			return (i * 6) + 1;
		}

		private static int GetIdxEven(int i) {
			return (i * 6) + 4;
		}

		private static bool IsWormHoleAvailable(int x, int y) {
			Coordinate c = exceptions.Find(delegate(Coordinate coord) { return coord.X == x && coord.Y == y; });
			if( c != null ) {
				return false;
			}
            List<UniverseSpecialSector> wormHoles = PlayerUtils.Current.SpecialSectors;
            UniverseSpecialSector wh = wormHoles.Find(delegate(UniverseSpecialSector w) { return w.SystemX == x && w.SystemY == y; });
			return wh != null && wh.Type.Equals("Wormhole");
			
		}

		private static IEnumerable<int> GetLineNumbers(int x) {
			if (x % 2 == 0) {
				for (int i = 0; i < 6; ++i) {
					yield return GetIdxEven(i);
				}
			} else {
				for (int i = 0; i < 7; ++i) {
					yield return GetIdxOdd(i);
				}
			}
		}

		private int GetMapping(int index, IDictionary<int, int> container, int xyIndex) {
            return container[index] + xyWormHoleMap[xyIndex];
		}


		private void WriteImage(TextWriter writer, SectorCoordinate current, int x, int y, int sx, int sy) {
			int xGap = GetMapping(x, xMapping, 0);
			int yGap = GetMapping(y, yMapping, 1);
			
			if (current.System.X == x && current.System.Y == y) {
				writer.Write(imageCurrentStr, imageCurrent, xGap, yGap, x, y, sx, sy);
			} else {
                writer.Write(imageStr, image, xGap, yGap, x, y, sx, sy);
			}
		}

		private void WritePrivateImage(TextWriter writer, SectorCoordinate current) {
			int xGap = GetMapping(0, xMapping, 0);
			int yGap = GetMapping(0, yMapping, 1);
			
			if (current.System.X == 0 && current.System.Y == 0) {
				writer.Write(imageCurrentStr, imagePrivateCurrent, xGap, yGap, 0, 0, 0, 0);
			} else {
				writer.Write(imageStr, imagePrivate, xGap, yGap, 0, 0, 0, 0);
			}
		}
		private void WriteImage(TextWriter writer, UniverseSpecialSector sector) {
			int xGap = GetMapping(sector.SystemX, xMapping, 0);
            int yGap = GetMapping(sector.SystemY, yMapping, 1);

            writer.Write(imageStr, image, xGap, yGap, sector.SystemX, sector.SystemY, sector.SectorX, sector.SectorY);
		}

		private static void WriteOptionMenu(TextWriter writer) {
			writer.Write("<div id='options'>");
			writer.Write("<ul>");	
			writer.Write("<li id='pTab1' class='selected'><a href='javascript:Site.selectTab(\"pTab1\");'>{0}</a></li>", LanguageManager.Instance.Get("UniverseWormHoles"));
			writer.Write("<li id='pTab2'><a href='javascript:Site.selectTab(\"pTab2\");'>{0}</a></li>", LanguageManager.Instance.Get("AllianceWormHoles"));
			writer.Write("</ul>");
			writer.Write("</div>");
		}

		private void WriteWormHoleMap(TextWriter writer, SectorCoordinate current) {
			writer.Write("<div id='pTab1Content' class='visible'>");
			foreach (int x in xMapping.Keys) {
				if (x == 0) {
					continue;
				}
				foreach (int y in GetLineNumbers(x)) {
					if (y != 0 && IsWormHoleAvailable(x, y)) {
						WriteImage(writer, current, x, y, 0,0);
					}
				}
			}
			WritePrivateImage(writer, current);
			writer.Write("</div>");
		}

		private static IEnumerable<BugsWormHoleSector> AllianceWormHoles() {
            StringWriter sw = new StringWriter();
            if (PlayerUtils.Current.Alliance != null){
                int allianceId = PlayerUtils.Current.Alliance.Storage.Id;
                IList<PlayerStorage> players = Hql.Query<PlayerStorage>("select p from SpecializedPlayerStorage p where p.AllianceNHibernate.Id = :allianceId", Hql.Param("allianceId", allianceId));
                foreach (PlayerStorage player in players){
                    sw.Write("s.OwnerNHibernate.Id = {0} or ", player.Id);
                }
                sw.Write("1 = 2");
            }else {
                sw.Write(" s.OwnerNHibernate.Id = {0}", PlayerUtils.Current.Id);
            }


            IList<SectorStorage> wormHoles = Hql.Query<SectorStorage>(string.Format("select s from SpecializedSectorStorage s where s.Type = 'BugsWormHoleSector' and ( {0} )", sw));
            foreach (SectorStorage hole in wormHoles){
                BugsWormHoleSector sector = (BugsWormHoleSector)SectorUtils.LoadSector(hole);
                if ( sector.Owner.Id == PlayerUtils.Current.Id || sector.UltimateLevel >= BugsWormHoleSector.AllianceAvailableLevel ){
                    yield return sector;
                }
            }
            
		}

		private void WritePrivateWormHoleMap(TextWriter writer, SectorCoordinate current) {
			writer.Write("<div id='pTab2Content'>");

			foreach (BugsWormHoleSector bugsWormHoleSector in AllianceWormHoles()) {
                WriteImage(writer, current, bugsWormHoleSector.SystemCoordinate.X, bugsWormHoleSector.SystemCoordinate.Y, bugsWormHoleSector.SectorCoordinate.X, bugsWormHoleSector.SectorCoordinate.Y);
			}

			writer.Write("</div>");
		}

		#endregion Private

		#region Public

		public void Render(TextWriter writer, SectorCoordinate current) {
			WriteOptionMenu(writer);
			WriteWormHoleMap(writer, current);
			WritePrivateWormHoleMap(writer, current);
		}

		public void Render(TextWriter writer) {
			foreach (UniverseSpecialSector sectors in PlayerUtils.Current.SpecialSectors) {
				if (sectors.SystemX != 0) {
					WriteImage(writer, sectors);
				}
			}
		}

		#endregion Public

		#region Constructor

		public UniverseWormHolesBaseRenderer(int x, int y) {
			for (int i = 1, xfactor = 0, yfactor = 0; i <= 37; ++i, xfactor+= x, yfactor+= y) {
				xMapping[i] = xfactor;
				yMapping[i] = yfactor;
			}

			xMapping[0] = 210;
			yMapping[0] = -135;

			exceptions.Add(new Coordinate(19,19));
			exceptions.Add(new Coordinate(16, 16));
			exceptions.Add(new Coordinate(16, 22));
			exceptions.Add(new Coordinate(22, 16));
			exceptions.Add(new Coordinate(22, 22));
		}

		#endregion Constructor

	}

}
