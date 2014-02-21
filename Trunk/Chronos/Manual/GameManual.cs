using System;
using System.Collections.Generic;
using OrionsBelt.WebComponents;
using Loki.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using System.IO;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.BattleCore;
using System.Collections;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Chronos.Manual {

    /// <summary>
    /// Generates the orionsbelt manual
    /// </summary>
    public class GameManual {

        #region Entry Point

        public static void Generate(string outputDir)
        {
            foreach (string locale in LanguageManager.SupportedLanguages) {
                Generate(outputDir, locale);
            }
        }

        private static void Generate(string outputDir, string locale)
        {
            Console.WriteLine("Generating `{0}' Manual...", locale);
            LanguageManager.CurrentCulture = new System.Globalization.CultureInfo(locale);
            TimeFormatter.Translator = LanguageParameterTranslator.Instance;
            ManualUtils.Translator = LanguageParameterTranslator.Instance;
            string localeDir = Globals.AppendDirectory(outputDir, locale);
            string templateDir = Path.Combine(outputDir, "Templates");
            string battleDir = Globals.AppendDirectory(localeDir, "Battles");
            string racesDir = Globals.AppendDirectory(localeDir, "Race");
            string commerceDir = Globals.AppendDirectory(localeDir, "Commerce");
            string universeDir = Globals.AppendDirectory(localeDir, "Universe");
            string apiDir = Globals.AppendDirectory(localeDir, "API");
            string questDir = Globals.AppendDirectory(localeDir, "Quest");

            Generate(localeDir, templateDir, "Default.aspx.vtl", "Default.aspx");

            Generate(localeDir, templateDir, "Quests.aspx.vtl", "Quests.aspx");
            GenerateQuestsPerContext(localeDir, templateDir);
            GenerateQuestPages(localeDir, templateDir);

            Generate(battleDir, Path.Combine(templateDir, "Battle"), "BattleTactics.aspx.vtl", "BattleTactics.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "BattleConcepts.aspx.vtl", "BattleConcepts.aspx");
			Generate(battleDir, Path.Combine(templateDir, "Battle"), "Deploy.aspx.vtl", "Deploy.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Catapult.aspx.vtl", "Catapult.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "ParalyseAttack.aspx.vtl", "ParalyseAttack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Replicator.aspx.vtl", "Replicator.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "StrikeBack.aspx.vtl", "StrikeBack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "InfestationAttack.aspx.vtl", "InfestationAttack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "RemoveAbilityAttack.aspx.vtl", "RemoveAbilityAttack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "TripleAttack.aspx.vtl", "TripleAttack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "BombAttack.aspx.vtl", "BombAttack.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Rebound.aspx.vtl", "Rebound.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Range.aspx.vtl", "Range.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Movement.aspx.vtl", "Movement.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Rules.aspx.vtl", "Rules.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Light.aspx.vtl", "Light.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Medium.aspx.vtl", "Medium.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Heavy.aspx.vtl", "Heavy.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Ultimate.aspx.vtl", "Ultimate.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Special.aspx.vtl", "Special.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "GameBoard.aspx.vtl", "GameBoard.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "KamikazeMenace.aspx.vtl", "KamikazeMenace.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "FiringSquad.aspx.vtl", "FiringSquad.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "DispensableUnits.aspx.vtl", "DispensableUnits.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "DiagonalTrap.aspx.vtl", "DiagonalTrap.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "EagleStrike.aspx.vtl", "EagleStrike.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Regicide.aspx.vtl", "Regicide.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "TotalAnnihilation.aspx.vtl", "TotalAnnihilation.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "WarZone.aspx.vtl", "WarZone.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Tournaments.aspx.vtl", "Tournaments.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Ladder.aspx.vtl", "Ladder.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "Friendly.aspx.vtl", "Friendly.aspx");
            Generate(battleDir, Path.Combine(templateDir, "Battle"), "ELO.aspx.vtl", "ELO.aspx");

            Generate(racesDir, Path.Combine(templateDir, "Race"), "Races.aspx.vtl", "Races.aspx");
            Generate(racesDir, Path.Combine(templateDir, "Race"), "Bugs.aspx.vtl", "Bugs.aspx");
            Generate(racesDir, Path.Combine(templateDir, "Race"), "LightHumans.aspx.vtl", "LightHumans.aspx");
            Generate(racesDir, Path.Combine(templateDir, "Race"), "DarkHumans.aspx.vtl", "DarkHumans.aspx");
            Generate(racesDir, Path.Combine(templateDir, "Race"), "Mercs.aspx.vtl", "Mercs.aspx");

            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "Default.aspx.vtl", "Default.aspx");
            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "TradeRoutes.aspx.vtl", "TradeRoutes.aspx");
            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "Markets.aspx.vtl", "Markets.aspx");
            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "AuctionHouse.aspx.vtl", "AuctionHouse.aspx");
            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "Orions.aspx.vtl", "Orions.aspx");
            Generate(commerceDir, Path.Combine(templateDir, "Commerce"), "Shop.aspx.vtl", "Shop.aspx");

            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Default.aspx.vtl", "Default.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Alliance.aspx.vtl", "Alliance.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "PrivateZone.aspx.vtl", "PrivateZone.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "HotZone.aspx.vtl", "HotZone.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Travel.aspx.vtl", "Travel.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "LineOfSight.aspx.vtl", "LineOfSight.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Colonize.aspx.vtl", "Colonize.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Conquer.aspx.vtl", "Conquer.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "UniverseAttack.aspx.vtl", "UniverseAttack.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Raids.aspx.vtl", "Raids.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Planets.aspx.vtl", "Planets.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "WormHole.aspx.vtl", "WormHole.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Fleet.aspx.vtl", "Fleet.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Arenas.aspx.vtl", "Arenas.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Beacon.aspx.vtl", "Beacon.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Coordinates.aspx.vtl", "Coordinates.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "UnloadCargo.aspx.vtl", "UnloadCargo.aspx");
			Generate(universeDir, Path.Combine(templateDir, "Universe"), "DevastationAttack.aspx.vtl", "DevastationAttack.aspx");
            Generate(universeDir, Path.Combine(templateDir, "Universe"), "Relics.aspx.vtl", "Relics.aspx");

            Generate(apiDir, Path.Combine(templateDir, "API"), "UniverseXML.aspx.vtl", "UniverseXML.aspx");
            Generate(apiDir, Path.Combine(templateDir, "API"), "UnitsJSON.aspx.vtl", "UnitsJSON.aspx");
            Generate(apiDir, Path.Combine(templateDir, "API"), "Battle.aspx.vtl", "Battle.aspx");
            Generate(apiDir, Path.Combine(templateDir, "API"), "Utilities.aspx.vtl", "Utilities.aspx");

            Generate(questDir, Path.Combine(templateDir, "Quest"), "CustomPlayerBounty.aspx.vtl", "CustomPlayerBounty.aspx");
        
            Generate(localeDir, templateDir, "API.aspx.vtl", "API.aspx");
            Generate(localeDir, templateDir, "UnitIndex.aspx.vtl", "UnitIndex.aspx");
            Generate(localeDir, templateDir, "MobsIndex.aspx.vtl", "MobsIndex.aspx");
            Generate(localeDir, templateDir, "FacilityIndex.aspx.vtl", "FacilityIndex.aspx");
            Generate(localeDir, templateDir, "IntrinsicIndex.aspx.vtl", "IntrinsicIndex.aspx");

            Generate(localeDir, templateDir, "Resources.Master.vtl", "Resources.Master");

            GenerateResources(Unit.Units, localeDir, templateDir, "Unit.aspx.vtl");
            GenerateResources(RulesUtils.GetResources(ResourceType.Facility), localeDir, templateDir, "Facility.aspx.vtl");
            GenerateResources(RulesUtils.GetResources(ResourceType.Intrinsic), localeDir, templateDir, "Intrinsic.aspx.vtl");
            
        }

        #endregion Entry Point

        #region Template Utils

        #region Universe

        public string GetUniverseMenu()
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Universe"));
                writer.Write("<ul>");
                writer.Write("<li>{0}</li>", Wikify("[PrivateZone]"));
                writer.Write("<li>{0}</li>", Wikify("[HotZone]"));
                writer.Write("<li>{0}</li>", Wikify("[Coordinates]"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("UniverseActions"));
                writer.Write("<ul>");
                writer.Write("<li>{0}</li>", Wikify("[Travel]"));
                writer.Write("<li>{0}</li>", Wikify("[LineOfSight]"));
                writer.Write("<li>{0}</li>", Wikify("[Colonize]"));
                writer.Write("<li>{0}</li>", Wikify("[UniverseAttack]"));
                writer.Write("<li>{0}</li>", Wikify("[Conquer]"));
                writer.Write("<li>{0}</li>", Wikify("[Raid]"));
                writer.Write("<li>{0}</li>", Wikify("[UnloadCargo]"));
                writer.Write("<li>{0}</li>", Wikify("[DevastationAttack]"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("UniverseElements"));
                writer.Write("<ul>");
                writer.Write("<li>{0}</li>", Wikify("[Planets]"));
                writer.Write("<li>{0}</li>", Wikify("[WormHole]"));
                writer.Write("<li>{0}</li>", Wikify("[Fleet]"));
                writer.Write("<li>{0}</li>", Wikify("[Arenas]"));
                writer.Write("<li>{0}</li>", Wikify("[Beacon]"));
                writer.Write("<li>{0}</li>", Wikify("[Academy]"));
                writer.Write("<li>{0}</li>", Wikify("[PirateBay]"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Other"));
                writer.Write("<ul>");
                writer.Write("<li>{0}</li>", Wikify("[Alliance]"));
                writer.Write("<li>{0}</li>", Wikify("[Relics]"));
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        private string Wikify(string raw)
        {
            return ManualUtils.Wikify(raw, QuestManager.GetQuests());
        }

        #endregion Universe

        #region API

        public string GetAPIMenu()
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("API"));
                writer.Write("<ul>");
                writer.Write("<li><a href='/{1}/API/Battle.aspx'>{0}</a></li>", LanguageManager.Instance.Get("BattleAPI"), LanguageManager.CurrentLanguage);
                writer.Write("<li><a href='/{1}/API/UniverseXML.aspx'>{0}</a></li>", LanguageManager.Instance.Get("UniverseXML"), LanguageManager.CurrentLanguage);
                writer.Write("<li><a href='/{1}/API/UnitsJSON.aspx'>{0}</a></li>", LanguageManager.Instance.Get("UnitsJSON"), LanguageManager.CurrentLanguage);
                writer.Write("<li><a href='/{1}/API/Utilities.aspx'>{0}</a></li>", LanguageManager.Instance.Get("Utilities"), LanguageManager.CurrentLanguage);
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        #endregion API

        #region Commerce

        public string GetCommerceMenu()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Commerce"));
                writer.Write("<ul>");
                writer.Write("<li>{0}</li>", Wikify("[Orions]"));
                writer.Write("<li>{0}</li>", Wikify("[AuctionHouse]"));
                writer.Write("<li>{0}</li>", Wikify("[Shop]"));
                writer.Write("<li>{0}</li>", Wikify("[Markets]"));
                writer.Write("<li>{0}</li>", Wikify("[TradeRoutes]"));
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        #endregion Commerce

        #region Resources

        public string GetIntrinsicIndex()
        {
            using(TextWriter writer = new StringWriter()){

            ICollection coll = RulesUtils.GetResources(ResourceType.Intrinsic);

            writer.Write("<h1>{0}</h1>", LanguageManager.Localize("Intrinsic"));
            writer.Write("<ul>");
            foreach (IResourceInfo info in GetSorted(coll)) {
                if (info.IsResourceCost) {
                    writer.Write("<li><a href='{2}' class='{3}'>{0} {1}</a></li>", ResourcesManager.GetResourceSmallImageHtml(info), LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
                }
            }
            writer.Write("</ul>");

            writer.Write("<h1>{0}</h1>", LanguageManager.Localize("TradeRoute"));
            writer.Write("<ul>");
            foreach (IResourceInfo info in GetSorted(coll)) {
                if (info.IsTradeRouteSpecific) {
                    writer.Write("<li><a href='{2}' class='{3}'>{0} {1}</a></li>", ResourcesManager.GetResourceSmallImageHtml(info), LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
                }
            }
            writer.Write("</ul>");

            writer.Write("<h1>{0}</h1>", LanguageManager.Localize("Other"));
            writer.Write("<ul>");
            foreach (IResourceInfo info in GetSorted(coll)) {
                if (!info.IsTradeRouteSpecific && !info.IsResourceCost) {
                    writer.Write("<li><a href='{2}' class='{3}'>{0} {1}</a></li>", ResourcesManager.GetResourceSmallImageHtml(info), LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
                }
            }
            writer.Write("</ul>");

            return writer.ToString();
            }
        }

        public string GetUnitMenu()
        {
            return WriteResourcesMenu("Units", ResourceType.Unit);
        }

        public string GetFacilityMenu()
        {
            return WriteResourcesMenu("Facilities", ResourceType.Facility);
        }

        public string GetIntrinsicMenu()
        {
            return WriteResourcesMenu("Intrinsics", ResourceType.Intrinsic);
        }

        private string WriteResourcesMenu(string title, ResourceType type)
        {
            using(TextWriter writer = new StringWriter()){
            
                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get(title));

                ICollection coll = Unit.Units; 
                if (type != ResourceType.Unit) {
                    coll = RulesUtils.GetResources(type);
                }

                writer.Write("<ul>");
                foreach (IResourceInfo info in GetSorted(coll)) {
                    writer.Write("<li>");
                    if (info is IUnitInfo) {
                        writer.Write("<a href='{2}' class='{3}'><img src='{0}' alt='{1}' /> {1}</a>", ResourcesManager.GetUnitImage(info.Name), LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
                    } else if ( info is IIntrinsicInfo ) {
                        //writer.Write("<a href='{2}' class='{3}'><img src='http://resources.orionsbelt.eu/Images/Common/Resources/{0}Small.png' alt='{1}' /> {1}</a>", info.Name, LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
					    writer.Write("<a href='{2}' class='{3}'>{0} {1}</a>", ResourcesManager.GetResourceSmallImageHtml(info), LanguageManager.Instance.Get(info.Name), GetResourceUrl(info), info.Name.ToLower());
                    } else {
                        writer.Write("<a href='/{2}/{3}/{0}.aspx'>{1}</a>", info.Name, LanguageManager.Instance.Get(info.Name), LanguageManager.CurrentLanguage, info.Type.ToString());
                    }
                    writer.Write("</li>");
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        private static IEnumerable<IResourceInfo> GetSorted(ICollection coll)
        {
            List<IResourceInfo> list = new List<IResourceInfo>();

            foreach (IResourceInfo info in coll) {
                list.Add(info);
            }

            list.Sort(delegate(IResourceInfo r1, IResourceInfo r2) {
                return LanguageManager.Instance.Get(r1.Name).CompareTo(LanguageManager.Instance.Get(r2.Name));
                });

            return list;
        }

        public string LightUnitsImageList()
        {
            UnitCategory cat = UnitCategory.Light;
            return WriteUnitImageList(cat);
        }

        public string MediumUnitsImageList()
        {
            UnitCategory cat = UnitCategory.Medium;
            return WriteUnitImageList(cat);
        }

        public string HeavyUnitsImageList()
        {
            UnitCategory cat = UnitCategory.Heavy;
            return WriteUnitImageList(cat);
        }

        public string UltimateUnitsImageList()
        {
            UnitCategory cat = UnitCategory.Ultimate;
            return WriteUnitImageList(cat);
        }

        public string SpecialUnitsImageList()
        {
            UnitCategory cat = UnitCategory.Special;
            return WriteUnitImageList(cat);
        }

        public string GetUnitList(string rawRace)
        {
            Race race = (Race) Enum.Parse(typeof(Race), rawRace);
            using(TextWriter writer = new StringWriter()){
                writer.Write("<ul class='resourceList'>");
                foreach (IUnitInfo unit in RulesUtils.GetUnitResources()) {
                    if (!unit.IsAvailableToRace(race)) {
                        continue;
                    }
                    writer.Write("<li>");
                    writer.Write("<a class='{2}' href='{0}'>{1}</a>", GetResourceUrl(unit), LanguageManager.Instance.Get(unit.Name), unit.Name.ToLower());
                    writer.Write("</li>");
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        public string GetFacilityList(string rawRace)
        {
            Race race = (Race) Enum.Parse(typeof(Race), rawRace);
            using(TextWriter writer = new StringWriter()){
                writer.Write("<ul class='resourceList'>");
                foreach (IFacilityInfo unit in RulesUtils.GetFacilityResources()) {
                    if (!unit.IsAvailableToRace(race)) {
                        continue;
                    }
                    writer.Write("<li>");
                    writer.Write("<a class='{2}' href='{0}'>{1}</a>", GetResourceUrl(unit), LanguageManager.Instance.Get(unit.Name), unit.Name.ToLower());
                    writer.Write("</li>");
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        private string WriteUnitImageList(UnitCategory cat)
        {
            using(TextWriter writer = new StringWriter()){
                writer.Write("<ul class='imageList'>");
                foreach (IUnitInfo unit in GetUnits(cat))
                {
                    writer.Write("<li>");
                    writer.Write("<a href='{2}'><img class='{3}' src='{0}' alt='{1}' /></a>", ResourcesManager.GetUnitImage(unit.Name), LanguageManager.Instance.Get(unit.Name), GetResourceUrl(unit), unit.Name.ToLower());
                    writer.Write("</li>");
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        public string GetUnitBonusInformation(object obj)
        {
            IUnitInfo info = obj as IUnitInfo;
            if (info == null){
                return "(No IUnitInfo given)";
            }

            if (info.Bonus.Count == 0) {
                return string.Empty;
            }

            using(TextWriter writer = new StringWriter()){

                writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("UnitBonus"));

                writer.Write("<table class='table'>");
                writer.Write("<tr>");
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Target"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Attack"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Defense"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Range"));
                writer.Write("</tr>");
                foreach (KeyValuePair<string, IBonus> pair in info.Bonus) {
                    writer.Write("<tr>");
                    writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(pair.Key));
                    writer.Write("<td>{0}</td>", pair.Value.GetAttack());
                    writer.Write("<td>{0}</td>", pair.Value.GetDefense());
                    writer.Write("<td>{0}</td>", pair.Value.GetRange());
                    writer.Write("</tr>");
                }
                writer.Write("</table>");

                return writer.ToString();
            }
        }

        private void WriteBonus(TextWriter writer, int value, string label)
        {
            if (value > 0) {
                writer.Write("{0} {1}", value, LanguageManager.Instance.Get(label));
            }
        }

        public string GetFooterContent()
        {
            return LanguageManager.Instance.Get("AskManualContributions");
        }

        public string LocalizeUnitTitle(object obj)
        {
            IUnitInfo info = obj as IUnitInfo;
            if (info == null) {
                return "(No IUnitInfo given)";
            }
            return string.Format(LanguageManager.Instance.Get("UnitTitle"), LanguageManager.Instance.Get(info.Name));
        }

        public string LocalizeFacilityTitle(object obj)
        {
            IFacilityInfo info = obj as IFacilityInfo;
            if (info == null) {
                return "(No IUnitInfo given)";
            }
            return string.Format(LanguageManager.Instance.Get("FacilityTitle"), LanguageManager.Instance.Get(info.Name));
        }

        public string GetUnitSpecialInformation(object obj)
        {
            IUnitInfo info = obj as IUnitInfo;
            if (info == null) {
                return "(No IUnitInfo given)";
            }

            using(TextWriter writer = new StringWriter()){

                writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("SpecialAbilities"));

                bool hasAbilities = false;

                writer.Write("<table class='table'>");
                writer.Write("<tr>");
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Type"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("SpecialAbilities"));
                writer.Write("</tr>");

                hasAbilities = WriteUnitCatapult(writer, info) || hasAbilities;
                hasAbilities = WriteUnitSpecialInfo(writer, info, "PosAttackMoves", info.PosAttackMoves) || hasAbilities;
                hasAbilities = WriteUnitSpecialInfo(writer, info, "PosDefenseMoves", info.PosDefenseMoves) || hasAbilities;
                hasAbilities = WriteUnitSpecialInfo(writer, info, "PosDefenseMoves", info.DefenseMoves) || hasAbilities;

                writer.Write("</table>");

                if (!hasAbilities) {
                    return string.Empty;
                }

                return writer.ToString();
            }
        }

        private bool WriteUnitCatapult(TextWriter writer, IUnitInfo info)
        {
            if (!info.Catapult){
                return false;
            }
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", LanguageManager.Instance.Get("AttackMoves"));
            writer.Write("<td>{0}</td>", LocalizeAndWikify("[Catapult]"));
            writer.Write("</tr>");
            return true;
        }

        private static bool WriteUnitSpecialInfo(TextWriter writer, IUnitInfo info, string title, IList<ISpecialMove> moves)
        {
            if (moves.Count == 0) {
                return false;
            }
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(title));
            writer.Write("<td>");
            writer.Write("<ul>");
            foreach (ISpecialMove move in moves){
                writer.Write("<li>{0}</li>", ManualUtils.Wikify(string.Format("[{0}]", move.GetType().Name)));
            }
            writer.Write("</ul>");
            writer.Write("</td>");
            writer.Write("</tr>");
            return true;
        }

        public string GetBuildInformation(object obj)
        {
            return GetBuildInformationByLevel(obj);
        }

        public string GetBuildInformationByLevel(object obj)
        {
            try { 
                IResourceWithRulesInfo info = obj as IResourceWithRulesInfo;
                if (info == null) {
                    return "(No IResourceWithRulesInfo given)";
                }

                using(TextWriter writer = new StringWriter()){

                    for (int i = 1; i < info.MaxLevel+1; ++i) {
                        WriteLevelInfo(writer, info, i);
                    }

                    return writer.ToString();
                }

            } catch( Exception ex ) {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

        private void WriteLevelInfo(TextWriter writer, IResourceWithRulesInfo info, int i)
        {
            if (info.CanLevelUp) {
                writer.Write("<h2><a href='#Level{0}' name='Level{0}'>{1} {2} {0}</a></h2>", i, LanguageManager.Instance.Get(info.Name), LanguageManager.Instance.Get("Level"));
            }

            writer.Write("<table class='table'>");

            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Dependencies"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Cost"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Duration"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("OnComplete"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Unlocks"));
            writer.Write("</tr>");

            writer.Write("<tr>");

            writer.Write("<td>");
            WriteRules(writer, info, "Dependencies", ResourceState.Available, i);
            writer.Write("</td>");

            writer.Write("<td>");
            WriteRules(writer, info, "Cost", ResourceState.InQueue, i);
            writer.Write("</td>");

            writer.Write("<td class='duration'>");
            WriteDuration(writer, info, i);
            writer.Write("</td>");

            writer.Write("<td>");
            WriteRules(writer, info, "OnComplete", ResourceState.Running, i);
            writer.Write("</td>");

            writer.Write("<td>");
            WriteUnlocks(writer, info, i);
            writer.Write("</td>");

            writer.Write("</tr>");

            writer.Write("</table>");
        }

        private void WriteUnlocks(TextWriter writer, IResourceWithRulesInfo info, int level)
        {
            Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();

            foreach (IResourceInfo otherInfo in RulesUtils.GetResources()) {
                IResourceWithRulesInfo other = otherInfo as IResourceWithRulesInfo;
                if (other == null) {
                    continue;
                }
                IList<IRule> rules = other.Rules.GetRulesByState(ResourceState.Available);
                foreach (IRule rule in rules) {
                    Dependency dep = rule as Dependency;
                    if (dep != null && dep.FacilityDependencyLevel == level && dep.FacilityDependency.Name == info.Name && !dic.ContainsKey(dep.FacilityInfo)) {
                        dic.Add(dep.FacilityInfo, dep.FacilityLevel);
                    }
                }
            }

            writer.Write("<ul>");
            foreach (KeyValuePair<IResourceInfo, int> pair in dic) {
                writer.Write("<li>");
                writer.Write("<a href='{1}'>{0}</a>",
                        LanguageManager.Instance.Get(pair.Key.Name),
                        ManualUtils.GetUrlOnResourcePage(pair.Key)
                    );
                if( pair.Key.CanLevelUp ) {
                    writer.Write(" {1} {0}",
                            pair.Value,
                            LanguageManager.Instance.Get("Level")
                        );
                }
                writer.Write("</li>");
            }
            writer.Write("</ul>");
        }

        private void WriteScore(TextWriter writer, IResourceWithRulesInfo info, int level)
        {
            int score = info.GetScore(level, 1);
            if(score > 0) {
                writer.Write("<li>+{0} {1}</li>", score, LanguageManager.Instance.Get("ToScore"));
            }
        }

        private void WriteDuration(TextWriter writer, IResourceWithRulesInfo info, int level)
        {
            if (info.InitialState == ResourceState.Running && level == 1) {
                WriteLocalized(writer, "AutoBuilds");
                return;
            }
            int ticks = info.GetFixedBuildDuration(level, 1);
            writer.Write(TimeFormatter.GetFormattedTicks(ticks));
        }

        private void WriteRules( TextWriter writer, IResourceWithRulesInfo info, string name, ResourceState state, int level)
        {
            IList<IRule> rules = info.Rules.GetRulesByState(state);
            
            int count = 0;

            writer.Write("<ul>");
            foreach (IRule rule in rules) {
                if( rule.IsForLevel(level) ){
                    string str = rule.ToString(LanguageParameterTranslator.Instance, info, level);
                    if (!string.IsNullOrEmpty(str)) {
                        ++count;
                        writer.Write("<li>");
                        writer.Write(str);
                        writer.Write("</li>");
                    }
                }
            }

            //WriteScore(writer, info, level);
            
            if (count == 0){
                writer.Write("<li>");
                WriteLocalized(writer, string.Format("No{0}", name));
                writer.Write("</li>");
                return;
            }
             

            writer.Write("</ul>");
        }

        private void WriteLocalized(TextWriter writer, string key)
        {
            writer.Write(LanguageManager.Instance.Get(key));
        }

        public string GetDescription(object obj)
        {
            IResourceInfo info = obj as IResourceInfo;
            if (info != null) {
                return Wikify(LanguageManager.Instance.Get(string.Format("{0}Description", info.Name)));
            }
            if (obj is string) {
                return Wikify(LanguageManager.Instance.Get(obj.ToString()));
            }
            return string.Format("Don't know how to get {0}'s description", obj);
        }

        public string GetRaces(object obj)
        {
            IResourceInfo info = obj as IResourceInfo;
            if (info != null) {
                using(TextWriter writer = new StringWriter()){
                    foreach (Race race in info.Races) {
                        writer.Write("[{0}]", race.ToString());
                    }
                    return Wikify(writer.ToString());
                }
            }
            return string.Format("Don't know how to get {0}'s races", obj);
        }

        public string Localize(object obj)
        {
            return Wikify(LanguageManager.Instance.Get(obj.ToString()));
        }

        public string LocalizeAndWikify(object obj)
        {
            if (obj is string) {
                return Wikify(obj.ToString());
            }
            return Wikify(string.Format("[{0}]", obj.ToString()));
        }

        public string GetFacilityIndex()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h1>{0}</h1>", LanguageManager.Instance.Get("Facilities"));

                writer.Write("<table class='table'>");

                writer.Write("<tr>");
                writer.Write("<th>{0}</td>", LocalizeAndWikify(Race.LightHumans));
                writer.Write("<th>{0}</td>", LocalizeAndWikify(Race.DarkHumans));
                writer.Write("<th>{0}</td>", LocalizeAndWikify(Race.Bugs));
                writer.Write("</tr>");

                WriteFacilitiesByCategory(writer);

                writer.Write("</table>");

                return writer.ToString();
            }
        }

        private void WriteFacilitiesByCategory(TextWriter writer)
        {
            writer.Write("<tr>");
            WriteFacilitiesByRace(writer, Race.LightHumans);
            WriteFacilitiesByRace(writer, Race.DarkHumans);
            WriteFacilitiesByRace(writer, Race.Bugs);
            writer.Write("</tr>");
        }

        private void WriteFacilitiesByRace(TextWriter writer, Race race)
        {
            writer.Write("<td><ul>");
            foreach (IFacilityInfo info in GetFacilities(race)) {
                writer.Write("<li><a href='{1}'>{0}</a></li>", LanguageManager.Instance.Get(info.Name), GetResourceUrl(info));
            }
            writer.Write("</td></ul>");
        }

        private IEnumerable<IFacilityInfo> GetFacilities(Race race)
        {
            foreach (IFacilityInfo facility in RulesUtils.GetFacilityResources()) {
                if (Array.Exists<Race>(facility.Races, delegate(Race r) { return r == race; })) {
                    yield return facility;
                }
            }
        }

        public string GetMobsndex()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h1>{0}</h1>", LanguageManager.Localize("Mobs"));
                writer.Write("<p>{0}</p>", Localize("MobsInfo"));

                writer.Write("<table class='table'>");

                writer.Write("<tr>");
                writer.Write("<th>{0}</td>", LanguageManager.Localize("Race"));
                writer.Write("<th>{0}</td>", LanguageManager.Localize("CombatUnits"));
                writer.Write("</tr>");

                foreach (IRaceInfo info in RaceInfo.GetMobs()) {
                    writer.Write("<tr>");
                    writer.Write("<td>{0}</td>", LocalizeAndWikify(info.Race));
                    writer.Write("<td>");
                    List<IUnitInfo> list = new List<IUnitInfo>(RulesUtils.GetUnitResources());
                    list.Sort(delegate(IUnitInfo u1, IUnitInfo u2) { return u1.Attack.CompareTo(u2.Attack); });

                    writer.Write("<ul class='unitIndexList'>");
                    foreach (IUnitInfo unit in list) {
                        if (RulesUtils.MatchRace(unit.Races, info)) {
                            writer.Write("<li>");
                            writer.Write("<a href='{2}'><img class='{3}' src='{0}' alt='{1}' /></a>", ResourcesManager.GetUnitImage(unit.Name), LanguageManager.Instance.Get(unit.Name), GetResourceUrl(unit), unit.Name.ToLower());
                            writer.Write("</li>");
                        }
                    }
                    writer.Write("</ul>");

                    writer.Write("</td>");
                    writer.Write("</tr>");
                }

                writer.Write("</table>");

                return writer.ToString();
            }
        }

        public string GetUnitIndex()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h1>{0}</h1>", LanguageManager.Instance.Get("Units"));

                writer.Write("<table class='table'>");

                writer.Write("<tr>");
                writer.Write("<th>{0}</th>", LocalizeAndWikify(Race.LightHumans));
                writer.Write("<th>{0}</th>", LocalizeAndWikify(Race.DarkHumans));
                writer.Write("<th>{0}</th>", LocalizeAndWikify(Race.Bugs));
                writer.Write("</tr>");

                WriteUnitsByCategory(writer, UnitCategory.Light);
                WriteUnitsByCategory(writer, UnitCategory.Medium);
                WriteUnitsByCategory(writer, UnitCategory.Heavy);
                WriteUnitsByCategory(writer, UnitCategory.Ultimate);

                writer.Write("</table>");

                writer.Write("<h1>{0}</h1>", LanguageManager.Instance.Get("Units"));

                return writer.ToString();
            }
        }

        private void WriteUnitsByCategory(TextWriter writer, UnitCategory unitCategory)
        {
            writer.Write("<tr><td colspan='3'>{0}</td></tr>", LocalizeAndWikify(unitCategory));

            writer.Write("<tr>");
            WriteUnitsByCategoryAndRace(writer, unitCategory, Race.LightHumans);
            WriteUnitsByCategoryAndRace(writer, unitCategory, Race.DarkHumans);
            WriteUnitsByCategoryAndRace(writer, unitCategory, Race.Bugs);
            writer.Write("</tr>");
        }

        private void WriteUnitsByCategoryAndRace(TextWriter writer, UnitCategory unitCategory, Race race)
        {
            writer.Write("<td><ul class='unitIndexList'>");

            foreach (IUnitInfo unit in GetUnits(unitCategory, race)) {
                writer.Write("<li>");
                writer.Write("<a href='{2}'><img class='{3}' src='{0}' alt='{1}' /></a>", ResourcesManager.GetUnitImage(unit.Name), LanguageManager.Instance.Get(unit.Name), GetResourceUrl(unit), unit.Name.ToLower());
                writer.Write("</li>");
            }

            writer.Write("</ul></td>");
        }

        public string GetResourceImage(object obj)
        {
            IResourceInfo info = obj as IResourceInfo;
            if (info == null) {
                throw new Exception("Not IResourceInfo");
            }
            if (info is IUnitInfo) {
                return string.Format("<img src='{0}' alt='{1}' />", ResourcesManager.GetUnitImage(((IUnitInfo)info).Name), LanguageManager.Instance.Get(info.Name));
            }
            if (info is IFacilityInfo) {
                return GetFacilityImage((IFacilityInfo)info);
            }
            return string.Format("<img alt='{0}' />", LanguageManager.Instance.Get(info.Name));
        }

        private string GetFacilityImage(IFacilityInfo info)
        {
            if (info.IsAvailableToRace(Race.LightHumans)) {
                return string.Format("<img src='{0}' alt='{1}' />", ResourcesManager.GetFacilityImage(RaceInfo.LightHumans, info), LanguageManager.Instance.Get(info.Name));
            }
			return string.Format("<div class='base{1}Preview {1}{0}Preview manualPreview'></div>", info.Name, info.Races[0]);
        }

        private string GetResourceUrl(IResourceInfo info)
        {
            return string.Format("/{2}/{3}/{0}.aspx", info.Name, LanguageManager.Instance.Get(info.Name), LanguageManager.CurrentLanguage, info.Type.ToString());
        }

        private IEnumerable<IUnitInfo> GetUnits(UnitCategory unitCategory, Race race)
        {
            foreach (IUnitInfo unit in RulesUtils.GetUnitResources()) {
                if (unit.UnitCategory == unitCategory && Array.Exists<Race>(unit.Races, delegate(Race r) { return r == race; })) {
                    yield return unit;
                }
            }
        }

        private IEnumerable<IUnitInfo> GetUnits(UnitCategory unitCategory)
        {
            if (unitCategory == UnitCategory.Special) { 
                yield return Unit.Create("fg");
            }
            foreach (IUnitInfo unit in RulesUtils.GetUnitResources()) {
                if (unit.UnitCategory == unitCategory ) {
                    yield return unit;
                }
            }
        }

        public string GetUnitTips()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<script type='text/javascript'>");
                writer.Write("window.unitTips = {");
                writer.Write("Attack:'{0}',", LanguageManager.Instance.Get("Attack"));
                writer.Write("Defense:'{0}',", LanguageManager.Instance.Get("Defense"));
                writer.Write("MovementCost:'{0}',", LanguageManager.Instance.Get("MovementCost"));
                writer.Write("Range:'{0}'", LanguageManager.Instance.Get("Range"));

                foreach (IUnitInfo unit in Unit.Units)  {
                    writer.Write(",{0}:{{Name:'{1}'}}", unit.Name, LanguageManager.Instance.Get(unit.Name));
                }
                writer.Write("};</script>");

                return writer.ToString();
            }
        }

        #endregion Resources

        #region Quests

        public string WriteReward(object obj)
        {
            IQuestInfo info = obj as IQuestInfo;
            using(TextWriter writer = new StringWriter()){
                
                writer.Write("<ul>");
                if (info.OrionsReward != 0) {
                    writer.Write("<li>{0} : +{1}</li>", Wikify("[Orions]"), info.OrionsReward);
                }
                if (info.ScoreReward != 0) {
                    writer.Write("<li>{0} : +{1}</li>", LanguageManager.Instance.Get("Score"), info.ScoreReward);
                }
                if (info.ProfessionPoints != null) {
                    foreach (KeyValuePair<Profession, int> pair in info.ProfessionPoints) {
                        writer.Write("<li>{0} : +{1}</li>", LocalizeAndWikify(pair.Key), pair.Value);
                    }
                }
                if (info.IntrinsicRewards != null) {
                    foreach (KeyValuePair<IResourceInfo, int> pair in info.IntrinsicRewards) {
                        writer.Write("<li>{0} : +{1}</li>", Wikify(string.Format("[{0}]",pair.Key.Name)), pair.Value);
                    }
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        public string GetQuestsByContext(string raw)
        {
            QuestContext context = (QuestContext)Enum.Parse(typeof(QuestContext), raw);
            using(TextWriter writer = new StringWriter()){

                int totalRaces = 0;
                int maxLevel = QuestManager.GetMaxLevel(context);

                writer.Write("<h1>{0}</h1>", LanguageManager.Instance.Get(context.ToString()));
                writer.Write("<div class='description'>{0}</div>", Localize(context.ToString()+"Intro"));

                writer.Write("<h2>{0}</h2>", string.Format(LanguageManager.Instance.Get("QuestContextTitle"), LanguageManager.Instance.Get(context.ToString())));

                if (maxLevel < 0) {
                    return writer.ToString();
                }

                CheckTopLevelDeps(context, writer);

                writer.Write("<table class='table' id='quests'>");

                writer.Write("<tr>");
                foreach (RaceInfo race in RaceInfo.GetAvailableRaces()) {
                    writer.Write("<th colspan='2'>{0}</th>", LanguageManager.Instance.Get(race.Race.ToString()));
                    ++totalRaces;
                }
                writer.Write("</tr>");

                for (int i = 0; i < maxLevel + 1; ++i) {
                    writer.Write("<tr>");
                    IQuestInfo quest = QuestManager.GetQuest(context, i);

                    if (quest.TargetRace == null) {
                        writer.Write("<td colspan='{0}'>", totalRaces * 2);
                        writer.Write("<a href='Quest/{0}.aspx'>{1}</a>", quest.Name, LanguageManager.Instance.Get(quest.Name));
                        writer.Write("</td>");
                    } else {
                        foreach (RaceInfo race in RaceInfo.GetAvailableRaces()) {
                            IQuestInfo rquest = QuestManager.GetQuest(context, race, i);
                            IQuestInfo aux = GetAuxQuest(rquest);
                            if( aux == null ) {
                                writer.Write("<td colspan='2'>");
                                if (rquest != null) {
                                    writer.Write("<a href='Quest/{0}.aspx'>{1}</a>", rquest.Name, LanguageManager.Instance.Get(rquest.Name));
                                }
                                writer.Write("</td>");
                            } else {
                                writer.Write("<td>");
                                writer.Write("<a href='Quest/{0}.aspx'>{1}</a>", rquest.Name, LanguageManager.Instance.Get(rquest.Name));
                                writer.Write("</td>");
                                writer.Write("<td>");
                                writer.Write("<a href='Quest/{0}.aspx'>{1}</a>", aux.Name, LanguageManager.Instance.Get(aux.Name));
                                writer.Write("</td>");
                            }
                        }
                    }
                    writer.Write("</tr>");
                }

                writer.Write("</table>");
                
                return writer.ToString();
            }
        }

        private static void CheckTopLevelDeps(QuestContext context, TextWriter writer)
        {
            IQuestInfo quest = QuestManager.GetQuest(context, 0);
            if (quest.Dependencies != null) {
                string token = LanguageManager.Instance.Get("QuestDependenciesWarning");
                StringWriter temp = new StringWriter();
                temp.Write("<ul>");
                foreach (IQuestInfo dep in quest.Dependencies)  {
                    temp.Write("<li><a href='Quest/{0}.aspx'>{1}</a></li>", dep.Name, LanguageManager.Instance.Get(dep.Name));
                }
                temp.Write("</ul>");
                writer.Write("<div class='description'>{0}</div>", string.Format(token, temp.ToString()));
            }
            
        }

        private IQuestInfo GetAuxQuest(IQuestInfo rquest)
        {
            if (rquest == null) {
                return null;
            }
            string auxName = string.Format("{0}Aux", rquest.Context);
            if( Enum.IsDefined(typeof(QuestContext), auxName) ) {
                return QuestManager.GetQuest((QuestContext)Enum.Parse(typeof(QuestContext), auxName), rquest.TargetRace, rquest.TargetLevel);
            }
            return null;
        }

        public string GetQuestsMenu()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Quests"));

                writer.Write("<ul>");
                foreach (QuestContext context in Enum.GetValues(typeof(QuestContext))) {
                    if (IsMasterContext(context)) {
                        writer.Write("<li>");
                        writer.Write("<a href='/{2}/{1}Quests.aspx'>{0}</a>", LanguageManager.Instance.Get(context.ToString()), context.ToString(), LanguageManager.CurrentCulture);
                        writer.Write("</li>");
                    }
                }
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        private bool IsMasterContext(QuestContext context)
        {
            return !context.ToString().Contains("Aux");
        }

        private static void GenerateQuestsPerContext(string localeDir, string templateDir)
        {
            foreach (QuestContext context in Enum.GetValues(typeof(QuestContext))) {
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("context", context.ToString());
                Generate(localeDir, templateDir, "QuestContext.aspx.vtl", string.Format("{0}Quests.aspx", context.ToString()), args);
            }
        }

        private static void GenerateQuestPages(string localeDir, string templateDir)
        {
            Globals.AppendDirectory(localeDir, "Quest");
            foreach (IQuestInfo quest in QuestManager.GetQuests()) {
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("quest", quest);
                args.Add("description", ManualUtils.Wikify(LanguageManager.Instance.Get(quest.Name + "Manual")));
                Generate(localeDir, templateDir, "Quest.aspx.vtl", string.Format("Quest/{0}.aspx", quest.Name), args);
            }

        }

        #endregion Quests

        #region OTher

        public string GetRacesMenu()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Races"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Race/LightHumans.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("LightHumans"));
                writer.Write("<li><a href='/{0}/Race/DarkHumans.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("DarkHumans"));
                writer.Write("<li><a href='/{0}/Race/Bugs.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Bugs"));
                writer.Write("<li><a href='/{0}/Race/Mercs.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Mercs"));
                writer.Write("<ul>");

                return writer.ToString();
            }
        }

        public string GetWarZoneConceptsMenu()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("WarZone"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/Tournaments.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Tournaments"));
                writer.Write("<li><a href='/{0}/Battles/Ladder.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Ladder"));
                writer.Write("<li><a href='/{0}/Battles/Friendly.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Friendly"));
                writer.Write("<li><a href='/{0}/Battles/ELO.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("ELO"));
                writer.Write("</ul>");

                return writer.ToString();
            }
        }

        public string GetBattleConceptsMenu()
        {
            using(TextWriter writer = new StringWriter()){

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("BattleConcepts"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/GameBoard.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("GameBoard"));
			    writer.Write("<li><a href='/{0}/Battles/Deploy.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Deploy"));
                writer.Write("<li><a href='/{0}/Battles/Movement.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Movement"));
                writer.Write("<li><a href='/{0}/Battles/Rules.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Rules"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Attack"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/Range.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Range"));
                writer.Write("<li><a href='/{0}/Battles/Catapult.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Catapult"));
                writer.Write("<li><a href='/{0}/Battles/ParalyseAttack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Paralyse"));
                writer.Write("<li><a href='/{0}/Battles/Replicator.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Replicator"));
                writer.Write("<li><a href='/{0}/Battles/StrikeBack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("StrikeBack"));
                writer.Write("<li><a href='/{0}/Battles/InfestationAttack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("InfestationAttack"));
                writer.Write("<li><a href='/{0}/Battles/RemoveAbilityAttack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("RemoveAbilityAttack"));
                writer.Write("<li><a href='/{0}/Battles/TripleAttack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("TripleAttack"));
                writer.Write("<li><a href='/{0}/Battles/BombAttack.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("BombAttack"));
                writer.Write("<li><a href='/{0}/Battles/Rebound.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Rebound"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("UnitCategory"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/Light.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Light"));
                writer.Write("<li><a href='/{0}/Battles/Medium.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Medium"));
                writer.Write("<li><a href='/{0}/Battles/Heavy.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Heavy"));
                writer.Write("<li><a href='/{0}/Battles/Ultimate.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Ultimate"));
                writer.Write("<li><a href='/{0}/Battles/Special.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Special"));
                writer.Write("</ul>");

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("BattleType"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/TotalAnnihilation.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("TotalAnnihilation"));
                writer.Write("<li><a href='/{0}/Battles/Regicide.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("Regicide"));
                writer.Write("</ul>");

                return writer.ToString();
            }
        }


        public string GetBattleTacticsMenu()
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("BattleTactics"));

                writer.Write("<ul>");
                writer.Write("<li><a href='/{0}/Battles/DispensableUnits.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("DispensableUnits"));
                writer.Write("<li><a href='/{0}/Battles/KamikazeMenace.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("KamikazeMenace"));
                writer.Write("<li><a href='/{0}/Battles/DiagonalTrap.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("DiagonalTrap"));
                writer.Write("<li><a href='/{0}/Battles/EagleStrike.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("EagleStrike"));
                writer.Write("<li><a href='/{0}/Battles/FiringSquad.aspx'>{1}</a></li>", LanguageManager.CurrentLanguage, LanguageManager.Instance.Get("FiringSquad"));
                writer.Write("<ul>");

                return writer.ToString();
            }
        }

        #endregion

        #endregion Template Utils

        #region Generation

        private static void Generate(string localeDir, string templateDir, string templateFile, string outputFile)
        {
            Generate(localeDir, templateDir, templateFile, outputFile, null);
        }

        private static void Generate(string localeDir, string templateDir, string templateFile, string outputFile, Dictionary<string, object> args)
        {
            templateFile = Path.Combine(templateDir, templateFile);
            outputFile = Path.Combine(localeDir, outputFile);
            Console.WriteLine(" » {0}", outputFile);
            Templates.Generate(null, templateFile, outputFile, true, GetBaseBargs(args));
        }

        private static void GenerateResources(ICollection resources, string outputDir, string templateDir, string templateFileName)
        {
            foreach (IResourceInfo info in resources) {
                string resourceOutput = Globals.AppendDirectory(outputDir, info.Type.ToString());
                string outputFile = Path.Combine(resourceOutput, string.Format("{0}.aspx", info.Name));
                string templateFile = Path.Combine(templateDir, templateFileName);
                Console.WriteLine(" » {0}", outputFile);
                Dictionary<string, object> args = GetBaseBargs(null);
                args["info"] = info;
                Templates.Generate(null, templateFile, outputFile, true, args);
            }
        }

        private static Dictionary<string, object> GetBaseBargs(Dictionary<string, object> args)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            if (args != null) {
                foreach (KeyValuePair<string, object> pair in args) {
                    dic.Add(pair.Key, pair.Value);
                }
            }

            dic["utils"] = new GameManual();
            dic["locale"] = LanguageManager.CurrentCulture;

            return dic;
        }

        #endregion Generation        

    };
}
