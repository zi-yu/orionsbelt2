using System.IO;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	public abstract class UniverseBaseRenderer {
		#region Private

		protected static string GetString( bool value ) {
			return value.ToString().ToLower();		
		}

		protected static void WriteVisible(TextWriter writer, SectorInformation sector) {
			string type = sector.Type.ToLower();
			if (!sector.IsSpace) {
				writer.Write("type='{2}' class='{0}' {1}></td>", sector.Representer, sector.HtmlAttributes, type);
			} else {
				if (sector.HasResource) {
                    IResourceQuantity r = sector.Resource;
					writer.Write("type='{1}' class='resource {0}'></td>", r.Resource.Name, type);
				} else {
					writer.Write("type='{0}' class='n'></td>", type);
				}
			}
		}

		protected static void WriteDiscovered(TextWriter writer, SectorInformation sector) {
            if (sector.IsSpace || sector.IsFleet || sector.IsFleetBattle || sector.IsUltimate || sector.IsRelic){
				writer.Write("type='normalsector' class='faded'></td>");
			} else {
				writer.Write("class='f{0}' type='{2}' {1}></td>", sector.Representer, sector.HtmlAttributes, sector.Type.ToLower());
			}
		}

		protected static void RenderImage(TextWriter writer, SectorInformation sector) {
			if( sector.Visibility is Undiscovered ) {
				writer.Write("<td id='{0}_{1}' system='{0}' sector='{1}' type='undiscoveredsector' class='undiscovered'></td>", sector.Coordinate.System, sector.Coordinate.Sector);
				return;
			}else {
				writer.Write("<td id='{0}_{1}' system='{0}' sector='{1}' ", sector.Coordinate.System, sector.Coordinate.Sector );
			}

			if( sector.Visibility is Discovered ) {
				WriteDiscovered(writer, sector);
				return;
			}
			WriteVisible(writer, sector);
		}

        protected static void ToJson(UniverseSpecialSector hole, StringBuilder builder, string comma)
        {
			builder.AppendFormat("{0}'{1}_{2}':{{s:'{3}_{4}'}}", comma, hole.SystemX, hole.SystemY, hole.SectorX, hole.SectorY);
		}

		private static void WriteUltimate(TextWriter writer, string name, string methodName) {
			name = LanguageManager.Instance.Get(name);
			writer.Write("<div id='useUltimate'><a href='javascript:UniverseUtils.{1}();'>{0}</a></div>", name, methodName);
		}

		private static void CreateUltimateLink(TextWriter writer) {
            IPlayer player = PlayerUtils.Current;
			if ( player.IsUltimateWeaponReady ) {
				switch (player.RaceInfo.Race) {
					case Race.Bugs:
						WriteUltimate(writer, "CreateWormHole", "useUltimate");
						return;
					case Race.LightHumans:
						WriteUltimate(writer, "CreateBeacon", "useUltimate");
						return;
					case Race.DarkHumans:
						WriteUltimate(writer, "FireDevastation", "fireDevastation");
						return;
				}
			}
		}

		protected static void RenderMenu(TextWriter writer) {
			writer.Write("<div id='optionMenu' class='optionMenuUniverse hidden'>");
			writer.Write("<div class='optionMenuTitle'>Menu</div><div id='optionMenuText' class='optionMenuText'>");
			writer.Write("<div id='move'><a href='javascript:UniverseUtils.moveEvent();'>{0}</a></div>", LanguageManager.Instance.Get("MoveHere"));
			writer.Write("<div id='moveUndiscovered'><a href='javascript:UniverseUtils.moveUndiscoveredEvent();'>{0}</a></div>", LanguageManager.Instance.Get("MoveHere"));
			writer.Write("<div id='transport'><a href='javascript:UniverseUtils.transportEvent();'>{0}</a></div>", LanguageManager.Instance.Get("Transport"));
			writer.Write("<div id='attack'><a href='javascript:UniverseUtils.attackEvent();'>{0}</a></div>", LanguageManager.Instance.Get("Attack"));
			writer.Write("<div id='attackPlanetConquer'><a href='javascript:UniverseUtils.attackPlanetConquerEvent();'>{0}</a></div>", LanguageManager.Instance.Get("AttackPlanetConquer"));
			writer.Write("<div id='attackPlanetRaid'><a href='javascript:UniverseUtils.attackPlanetRaidEvent();'>{0}</a></div>", LanguageManager.Instance.Get("AttackPlanetRaid"));
			writer.Write("<div id='pursuitAndAttack'><a href='javascript:UniverseUtils.pursuitAttackEvent();'>{0}</a></div>", LanguageManager.Instance.Get("PursuitAndAttack"));
			writer.Write("<div id='cancel'><a href='javascript:UniverseUtils.cancelEvent();'>{0}</a></div>", LanguageManager.Instance.Get("CancelMovement"));
			writer.Write("<div id='challenge'><a href='javascript:UniverseUtils.challengeEvent();'>{0}</a></div>", LanguageManager.Instance.Get("Challenge"));
			writer.Write("<div id='arena'><a href='javascript:UniverseUtils.showArenaEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ShowArena"));
			writer.Write("<div id='conquer'><a href='javascript:UniverseUtils.conquerEvent();'>{0}</a></div>", LanguageManager.Instance.Get("Conquer"));
			writer.Write("<div id='toMarket'><a href='javascript:UniverseUtils.goToMarketEvent();'>{0}</a></div>", LanguageManager.Instance.Get("MoveToMarket"));
            writer.Write("<div id='toAcademy'><a href='javascript:UniverseUtils.goToAcademyEvent();'>{0}</a></div>", LanguageManager.Instance.Get("MoveToAcademy"));
            writer.Write("<div id='toPirateBay'><a href='javascript:UniverseUtils.goToPirateBayEvent();'>{0}</a></div>", LanguageManager.Instance.Get("MoveToPirateBay"));
            writer.Write("<div id='market'><a href='javascript:UniverseUtils.showMarketEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ShowMarket"));
            writer.Write("<div id='academy'><a href='javascript:UniverseUtils.showAcademyEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ShowAcademy"));
            writer.Write("<div id='pirateBay'><a href='javascript:UniverseUtils.showPirateBayEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ShowPirateBay"));
            writer.Write("<div id='viewBattle'><a href='javascript:UniverseUtils.viewBattleEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ViewBattle"));
			writer.Write("<div id='unloadCargo'><a href='javascript:UniverseUtils.unloadCargoEvent();'>{0}</a></div>", LanguageManager.Instance.Get("UnloadCargo"));
			writer.Write("<div id='showRelic'><a href='javascript:UniverseUtils.showRelicEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ShowRelic"));
			writer.Write("<div id='showRelic2'><a href='javascript:UniverseUtils.showRelic2Event();'>{0}</a></div>", LanguageManager.Instance.Get("ShowRelic"));
			writer.Write("<div id='attackRelic'><a href='javascript:UniverseUtils.attackRelicEvent();'>{0}</a></div>", LanguageManager.Instance.Get("AttackRelic"));
			writer.Write("<div id='conquerRelic'><a href='javascript:UniverseUtils.conquerRelicEvent();'>{0}</a></div>", LanguageManager.Instance.Get("ConquerRelic"));

			writer.Write("<div id='viewPlanet'><a>{0}</a></div>", LanguageManager.Instance.Get("ViewPlanet"));
			writer.Write("<div id='viewQueue'><a>{0}</a></div>", LanguageManager.Instance.Get("ViewQueue"));
			writer.Write("<div id='buildUnits'><a>{0}</a></div>", LanguageManager.Instance.Get("BuildUnits"));
			writer.Write("<div id='viewFleets'><a>{0}</a></div>", LanguageManager.Instance.Get("ViewFleets"));
			writer.Write("<div id='viewManage'><a>{0}</a></div>", LanguageManager.Instance.Get("Manage"));

			CreateUltimateLink(writer);
			writer.Write("<div id='noOption'>No Options Available</div>");
			writer.Write("</div></div>");
		}

		protected static void RenderUniverseElementsJson(TextWriter writer, SectorInformationContainer container){
			writer.Write("<script type='text/javascript'>");
			writer.Write(container.FleetsToJson());
			writer.Write(container.PlanetsToJson());
			writer.Write(container.BattlesToJson());
			writer.Write(container.MarketsToJson());
			writer.Write(container.ArenasToJson());
			writer.Write(container.WormholesToJson());
			writer.Write(container.UltimateInfoToJson());
			writer.Write(container.BeaconsToJson());
			writer.Write(container.AcademiesToJson());
			writer.Write(container.PirateBaysToJson());
			writer.Write(container.RelicsToJson());
			writer.Write("</script>");
		}

        protected static void RenderContent(TextWriter writer, SectorInformationContainer container, int maxPerLine) {
			int counter = 0;
			writer.Write("<tr>");
			foreach (SectorInformation sector in container.OrderedSectors) {
				if (counter == maxPerLine) {
					writer.Write("</tr><tr>");
					counter = 0;
				}
				RenderImage(writer, sector);
				++counter;
			}
			writer.Write("</tr>");
		}

        #region Render Right Menu

		private static void RenderFleets(TextWriter writer) {
			writer.Write("<h3>{0}</h3>",LanguageManager.Instance.Get("Fleets"));
			writer.Write("<div id='fleetUniverseList'>");
			foreach (IFleetInfo fleet in PlayerUtils.Current.Fleets) {
				if (fleet.Movable) {
					writer.Write("<div><a href='javascript:UniverseUtils.centerInFleet({0});'>{1} - {2}</a>{3}</div>", fleet.Id, fleet.Name, fleet.Location, GetIdle(fleet));
				}
			}
			writer.Write("</div>");
		}

		private static object GetIdle(IFleetInfo fleet) {
            if( fleet.IsIdle ) {
                return "*";
            }
			return string.Empty;
		}

        private static void RenderPlanets(TextWriter writer) {
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Planets"));
			writer.Write("<div id='planetUniverseList'>");
			writer.Write("<div><a href='javascript:UniverseUtils.centerInPlanet({0});'>{1}</a></div>", PlayerUtils.Current.HomePlanetId, LanguageManager.Instance.Get("PrivatePlanets"));
			foreach (IPlanet planet in PlayerUtils.Current.Planets) {
				if (!planet.IsPrivate) {
					writer.Write("<div><a href='javascript:UniverseUtils.centerInPlanet({0});'>{1} - {2}</a></div>", planet.Storage.Id, planet.Name, planet.Location);
				}
			}
			writer.Write("</div>");
		}

        private static void RenderRelics(TextWriter writer) {
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Relics"));
			writer.Write("<div id='relicUniverseList'>");
			foreach (SectorCoordinate relic in PlayerUtils.Current.Relics) {
                writer.Write("<div><a href='javascript:UniverseUtils.centerInCoordinate(\"{0}\");'>{1} - {2}</a></div>", relic.ToString("_"), LanguageManager.Localize("Relic"), relic);
			}
			writer.Write("</div>");
		}

        private static void RenderBottom(TextWriter writer) {
            writer.Write("<div id='universeListBottom'>");
            writer.Write("</div>");
        }

        protected static void RenderRightMenu(TextWriter writer, int zoomLevel){
			RenderRightMenu(writer, false, zoomLevel);
		}

        protected static void RenderRightMenu(TextWriter writer, bool isPrivate, int zoomLevel){
            writer.Write("<div id='rightMenu'>");

            if (!isPrivate){
				RenderDirectionalArrows(writer, zoomLevel);
            }
            RenderFleets(writer);
            RenderPlanets(writer);
            RenderRelics(writer);
            RenderBottom(writer);
                  
            writer.Write("</div>");
		}

		private static void RenderDirectionalArrows(TextWriter writer, int zoomLevel) {
            writer.Write("<div id='arrows'>");
			writer.Write("<div id='rightArrows'>");
			writer.Write("<table id='zoom'><tbody>");
			writer.Write("<tr><td id='zoom1'></td></tr>");
            writer.Write("<tr><td id='zoom2'></td></tr>");
            writer.Write("<tr><td id='zoom3'> </td></tr>");
            writer.Write("<tr><td id='zoom4'></td></tr>");
			writer.Write("</tbody></table>");
			if (zoomLevel != 0) {
				writer.Write("<div id='moveTo'>" );
				writer.Write("<input id='x' type='text' />:<input id='y' type='text' />:<input id='sx' type='text' />:<input id='sy' type='text' /><br/>");
				writer.Write("<div><input id='moveToButton' type='button' class='buttonSmall' value='{0}' disabled='true' /></div>", LanguageManager.Instance.Get("MoveTo"));
				writer.Write("</div>");
			}
			writer.Write("</div>");
			writer.Write("<div class='arrows'><table><tbody>");
            writer.Write("<tr><td></td><td id='uab' code='b'></td><td></td></tr>");
            writer.Write("<tr><td id='uad' code='d'></td><td></td><td id='uae' code='e'></td></tr>");
            writer.Write("<tr><td></td><td id='uag' code='g'></td><td></td></tr>");
			writer.Write("</tbody></table></div>");

			writer.Write("</div>");
		}

		#endregion Render Right Menu

        #region Render Bottom Menu

        protected static void RenderBottomMenu(TextWriter writer){
            writer.Write("<div id='bottomMenu'>");
			writer.Write("<div id='bottomMenuOptions'></div>");
            RenderMessages(writer);
            writer.Write("</div>");
        }

		protected static void RenderMessages(TextWriter writer){
            new GenericMessages(Category.Universe, PlayerUtils.Current).Render(writer);
        }

        #endregion Render Bottom Menu

		protected static void SetCenterCoordinate(SectorCoordinate startCoordinate, int xGap, int yGap) {
			SectorCoordinate centerCoordinate = CoordinateMapping.GetCenterCoordinateFromStartCoordinate(startCoordinate,xGap,yGap);
			CenterCoordinate.Current.SetCenter(centerCoordinate);
		}

        #endregion Private
    }
}
