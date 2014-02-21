using System.Collections.Generic;
using System.IO;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	public class UniverseSectorRendererZoom0 : UniverseBaseRenderer {

        #region Fields

        private static string zone;
            
        #endregion Fields

		#region Private
            		
		private static void RenderGrid(TextWriter writer) {
			writer.Write("<table><tbody>");
		    int counter = 0;
            for (int i = 1; i <= 18; ++i ){
                writer.Write("<tr>");
                for (int j = 1; j <= 19; ++j){
                    writer.Write("<td id='s{0}'></td>", counter + j);
                }
                writer.Write("</tr>");
                counter+=19;
            }
			writer.Write("</tbody></table>");
        }

        private static void RenderShowOptions(TextWriter writer) {
			writer.Write("<div id='bottomMenuOptions'><div>");
			writer.Write("<a href='javascript:UniverseUtils.showPlanetIcons();'>{0}</a><br/>", LanguageManager.Instance.Get("ShowPlanets"));
			writer.Write("<a href='javascript:UniverseUtils.showFleetIcons();'>{0}</a><br/>", LanguageManager.Instance.Get("ShowFleets"));
			writer.Write("<a href='javascript:UniverseUtils.showWormHoleIcons();'>{0}</a><br/>", LanguageManager.Instance.Get("ShowWormHoles"));
			writer.Write("<a href='javascript:UniverseUtils.showMarketIcons();'>{0}</a><br/>", LanguageManager.Instance.Get("ShowMarkets"));
			writer.Write("<a href='javascript:UniverseUtils.showArenaIcons();'>{0}</a>", LanguageManager.Instance.Get("ShowArenas"));
            writer.Write("</div></div>");
        }

        protected static void RenderUniverseElementsJsonZoom0(TextWriter writer, SectorInformationContainer container){
			writer.Write("<script type='text/javascript'>");
			writer.Write(container.FleetsToJson());
			writer.Write(container.PlanetsToJson());
			writer.Write(container.BattlesToJson());
			writer.Write(container.MarketsToJson());
			writer.Write(container.ArenasToJson());
            writer.Write(container.WormholesToJson());
			writer.Write(container.BeaconsToJson());
			writer.Write(container.AcademiesToJson());
			writer.Write(container.PirateBaysToJson());
			writer.Write(container.RelicsToJson());
			writer.Write(zone);
			writer.Write("</script>");
		}

        protected static void RenderBottomMenuZoom0(TextWriter writer){
            writer.Write("<div id='bottomMenu'>");
			RenderShowOptions(writer);
			RenderMessages(writer);
            writer.Write("</div>");
        }

		#endregion Private

		#region Control Events

		public static void Render(TextWriter writer, SectorCoordinate center ) {
            RenderRightMenu(writer,0);
			writer.Write("<div id='universeMap' class='universe0'><div id='universeItems' >");
		    RenderGrid(writer);
			writer.Write("</div></div>");
            SectorInformationContainer container = UniverseUtils.GetUniverseWithSpecialSectorsInformation(PlayerUtils.Current);
            RenderUniverseElementsJsonZoom0(writer, container);
            RenderBottomMenuZoom0(writer);
			RenderMenu(writer);
		}

		#endregion Control Events

        #region Constructor

        static UniverseSectorRendererZoom0(){
            StringWriter writer = new StringWriter();
            writer.Write("var zoneMapping = [[]");
            for (int i = 1; i <= 37; i+=2 ){//Column
                for (int j = 1; j <= 37; j+=2){//Line
                    writer.Write(",[{0},{1},{2},{3}]", i, j, i+1, j+1);
                }
            }
            writer.Write("];");
            zone = writer.ToString();
        }

        #endregion

    }
}
