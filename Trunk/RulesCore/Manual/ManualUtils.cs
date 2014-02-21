using System.Globalization;
using System;
using OrionsBelt.RulesCore.Interfaces;
using System.Web;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Generic {

    /// <summary>
    /// Utilities for the manual
    /// </summary>
    public static class ManualUtils {

        #region Configs

        public static string BaseUrl {
            get { return "http://manual.orionsbelt.eu"; }
        }

        public static string FrameUrl {
            get {
                if (HttpContext.Current != null && HttpContext.Current.Request != null) {
                    if (HttpContext.Current.Request.ApplicationPath != "/") {
                        return HttpContext.Current.Request.ApplicationPath + "/Manual.aspx?path=";
                    }
                }
                return "/Manual.aspx?path=";
            }
        }

        #endregion Configs

        #region Get Url

        public static string GetUrlOnResourcePage(IResourceInfo info)
        {
            return string.Format("../{0}/{1}.aspx", info.Type, info.Name);
        }

        public static string GetUrl(string locale, IResourceInfo info, int level)
        {
            return string.Format("{0}/{1}/{2}/{3}.aspx#Level{4}", BaseUrl, locale, info.Type, info.Name, level);
        }

        public static string GetUrl(IResourceInfo info)
        {
            return string.Format("{0}{1}/{2}.aspx", FrameUrl, info.Type, info.Name);
        }

        public static string GetUrl(IResourceInfo info, int level)
        {
            return GetUrl(info);
        }

        #endregion Get Url

        #region Get Link

        public static string GetLink(IResourceInfo info, string caption)
        {
            return string.Format("<a href='{0}' class='manual'>{1}</a>", GetUrl(info), caption);
        }

        #endregion Get Link

        #region Wikifiing

        private static IMessageParameterTranslator translator;

        public static IMessageParameterTranslator Translator {
            get {return translator;  }
            set { translator = value; }
        }

        private static Dictionary<string, string> substitutions = new Dictionary<string, string>();
        static ManualUtils()
        {
            substitutions.Add("OB", "<a href='http://www.orionsbelt.eu'>{1}</a>");

            substitutions.Add("BattleTactics", "<a href='{0}Battles/BattleTactics.aspx'>{1}</a>");

            substitutions.Add("CombatUnits", "<a href='{0}UnitIndex.aspx'>{1}</a>");
            substitutions.Add("GameBoard", "<a href='{0}Battles/GameBoard.aspx'>{1}</a>");
			substitutions.Add("Deploy", "<a href='{0}Battles/Deploy.aspx'>{1}</a>");
            substitutions.Add("Catapult", "<a href='{0}Battles/Catapult.aspx'>{1}</a>");
            substitutions.Add("Paralyse", "<a href='{0}Battles/ParalyseAttack.aspx'>{1}</a>");
            substitutions.Add("Replicator", "<a href='{0}Battles/Replicator.aspx'>{1}</a>");
            substitutions.Add("StrikeBack", "<a href='{0}Battles/StrikeBack.aspx'>{1}</a>");
            substitutions.Add("InfestationAttack", "<a href='{0}Battles/InfestationAttack.aspx'>{1}</a>");
            substitutions.Add("RemoveAbilityAttack", "<a href='{0}Battles/RemoveAbilityAttack.aspx'>{1}</a>");
            substitutions.Add("TripleAttack", "<a href='{0}Battles/TripleAttack.aspx'>{1}</a>");
            substitutions.Add("Triple", "<a href='{0}Battles/TripleAttack.aspx'>{1}</a>");
            substitutions.Add("BombAttack", "<a href='{0}Battles/BombAttack.aspx'>{1}</a>");
            substitutions.Add("Rebound", "<a href='{0}Battles/Rebound.aspx'>{1}</a>");
            substitutions.Add("Ricochet", "<a href='{0}Battles/Rebound.aspx'>{1}</a>");
            substitutions.Add("Range", "<a href='{0}Battles/Range.aspx'>{1}</a>");
            substitutions.Add("MovAll", "<a href='{0}Battles/Movement.aspx#MovAll'>{1}</a>");
            substitutions.Add("MovFront", "<a href='{0}Battles/Movement.aspx#MovFront'>{1}</a>");
            substitutions.Add("MovDiagonal", "<a href='{0}Battles/Movement.aspx#MovDiagonal'>{1}</a>");
            substitutions.Add("MovNone", "<a href='{0}Battles/Movement.aspx#MovNone'>{1}</a>");
            substitutions.Add("MovNormal", "<a href='{0}Battles/Movement.aspx#MovNormal'>{1}</a>");
            substitutions.Add("MovDrop", "<a href='{0}Battles/Movement.aspx#MovDrop'>{1}</a>");
            substitutions.Add("Movement", "<a href='{0}Battles/Movement.aspx'>{1}</a>");
            substitutions.Add("MovCost", "<a href='{0}Battles/Movement.aspx#MovCost'>{1}</a>");
            substitutions.Add("MovPoints", "<a href='{0}Battles/Movement.aspx#MovPoints'>{1}</a>");
            substitutions.Add("Organic", "<a href='{0}Battles/Organic.aspx'>{1}</a>");
            substitutions.Add("Regicide", "<a href='{0}Battles/Regicide.aspx'>{1}</a>");
            substitutions.Add("TotalAnnihilation", "<a href='{0}Battles/TotalAnnihilation.aspx'>{1}</a>");
            substitutions.Add("WarZone", "<a href='{0}Battles/WarZone.aspx'>{1}</a>");
            substitutions.Add("ELO", "<a href='{0}Battles/ELO.aspx'>{1}</a>");
            substitutions.Add("Tournaments", "<a href='{0}Battles/Tournaments.aspx'>{1}</a>");
            substitutions.Add("Tournament", "<a href='{0}Battles/Tournaments.aspx'>{1}</a>");
            substitutions.Add("Ladder", "<a href='{0}Battles/Ladder.aspx'>{1}</a>");
            substitutions.Add("Friendly", "<a href='{0}Battles/Friendly.aspx'>{1}</a>");

            substitutions.Add("FiringSquad", "<a href='{0}Battles/FiringSquad.aspx'>{1}</a>");
            substitutions.Add("DispensableUnits", "<a href='{0}Battles/DispensableUnits.aspx'>{1}</a>");
            substitutions.Add("KamikazeMenace", "<a href='{0}Battles/KamikazeMenace.aspx'>{1}</a>");
            substitutions.Add("DiagonalTrap", "<a href='{0}Battles/DiagonalTrap.aspx'>{1}</a>");
            substitutions.Add("EagleStrike", "<a href='{0}Battles/EagleStrike.aspx'>{1}</a>");

            substitutions.Add("Light", "<a href='{0}Battles/Light.aspx'>{1}</a>");
            substitutions.Add("Medium", "<a href='{0}Battles/Medium.aspx'>{1}</a>");
            substitutions.Add("Heavy", "<a href='{0}Battles/Heavy.aspx'>{1}</a>");
            substitutions.Add("Ultimate", "<a href='{0}Battles/Ultimate.aspx'>{1}</a>");
            substitutions.Add("Special", "<a href='{0}Battles/Special.aspx'>{1}</a>");

            substitutions.Add("Race", "<a href='{0}Race/Races.aspx'>{1}</a>");
            substitutions.Add("Races", "<a href='{0}Race/Races.aspx'>{1}</a>");
            substitutions.Add(Race.LightHumans.ToString(), "<a href='{0}Race/LightHumans.aspx'>{1}</a>");
            substitutions.Add(Race.DarkHumans.ToString(), "<a href='{0}Race/DarkHumans.aspx'>{1}</a>");
            substitutions.Add(Race.Bugs.ToString(), "<a href='{0}Race/Bugs.aspx'>{1}</a>");
            substitutions.Add(Race.Mercs.ToString(), "<a href='{0}Race/Mercs.aspx'>{1}</a>");

            substitutions.Add("Resources", "<a href='{0}IntrinsicIndex.aspx'>{1}</a>");
            substitutions.Add("Resource", "<a href='{0}IntrinsicIndex.aspx'>{1}</a>");
            substitutions.Add("Intrinsics", "<a href='{0}IntrinsicIndex.aspx'>{1}</a>");
            substitutions.Add("Intrinsic", "<a href='{0}IntrinsicIndex.aspx'>{1}</a>");
            substitutions.Add("Facilities", "<a href='{0}FacilityIndex.aspx'>{1}</a>");
            substitutions.Add("Units", "<a href='{0}UnitIndex.aspx'>{1}</a>");
            substitutions.Add("Flag", "<a href='{0}Unit/Flag.aspx'>{1}</a>");

            substitutions.Add("Capacity", "<a href='{0}Universe/Planets.aspx#Capacity'>{1}</a>");

            substitutions.Add("Planet", "<a href='{0}Universe/Planets.aspx'>{1}</a>");
            substitutions.Add("Planets", "<a href='{0}Universe/Planets.aspx'>{1}</a>");
            substitutions.Add("WormHole", "<a href='{0}Universe/WormHole.aspx'>{1}</a>");
			substitutions.Add("WormHoles", "<a href='{0}Universe/WormHole.aspx'>{1}</a>");
            substitutions.Add("Universe", "<a href='{0}Universe/Default.aspx'>{1}</a>");
            substitutions.Add("HotZone", "<a href='{0}Universe/HotZone.aspx'>{1}</a>");
            substitutions.Add("ZoneLevel", "<a href='{0}Universe/HotZone.aspx#levels'>{1}</a>");
            substitutions.Add("PrivateZone", "<a href='{0}Universe/PrivateZone.aspx'>{1}</a>");
            substitutions.Add("Fleet", "<a href='{0}Universe/Fleet.aspx'>{1}</a>");
            substitutions.Add("Fleets", "<a href='{0}Universe/Fleet.aspx'>{1}</a>");
            substitutions.Add("Raid", "<a href='{0}Universe/Raids.aspx'>{1}</a>");
            substitutions.Add("Raids", "<a href='{0}Universe/Raids.aspx'>{1}</a>");
            substitutions.Add("Arenas", "<a href='{0}Universe/Arenas.aspx'>{1}</a>");
            substitutions.Add("Arena", "<a href='{0}Universe/Arenas.aspx'>{1}</a>");
            substitutions.Add("Beacon", "<a href='{0}Universe/Beacon.aspx'>{1}</a>");
            substitutions.Add("Travel", "<a href='{0}Universe/Travel.aspx'>{1}</a>");
            substitutions.Add("Colonize", "<a href='{0}Universe/Colonize.aspx'>{1}</a>");
            substitutions.Add("Conquer", "<a href='{0}Universe/Conquer.aspx'>{1}</a>");
            substitutions.Add("UniverseAttack", "<a href='{0}Universe/UniverseAttack.aspx'>{1}</a>");
            substitutions.Add("LineOfSight", "<a href='{0}Universe/LineOfSight.aspx'>{1}</a>");
            substitutions.Add("Alliance", "<a href='{0}Universe/Alliance.aspx'>{1}</a>");
            substitutions.Add("Alliances", "<a href='{0}Universe/Alliance.aspx'>{1}</a>");
            substitutions.Add("Coordinates", "<a href='{0}Universe/Coordinates.aspx'>{1}</a>");
            substitutions.Add("Coordinate", "<a href='{0}Universe/Coordinates.aspx'>{1}</a>");
            substitutions.Add("UnloadCargo", "<a href='{0}Universe/UnloadCargo.aspx'>{1}</a>");
			substitutions.Add("DevastationAttack", "<a href='{0}Universe/DevastationAttack.aspx'>{1}</a>");
            substitutions.Add("Relic", "<a href='{0}Universe/Relics.aspx'>{1}</a>");
            substitutions.Add("Relics", "<a href='{0}Universe/Relics.aspx'>{1}</a>");

            substitutions.Add("Quests", "<a href='{0}Quests.aspx'>{1}</a>");
            substitutions.Add("Quest", "<a href='{0}Quests.aspx'>{1}</a>");
            substitutions.Add("Professions", "<a href='{0}Quests.aspx#Professions'>{1}</a>");
            substitutions.Add("Profession", "<a href='{0}Quests.aspx#Professions'>{1}</a>");
            substitutions.Add("Bounties", "<a href='{0}BountyHunterQuests.aspx'>{1}</a>");
            substitutions.Add("Merchant", "<a href='{0}MerchantQuests.aspx'>{1}</a>");
            substitutions.Add("Pirate", "<a href='{0}PirateQuests.aspx'>{1}</a>");
            substitutions.Add("BountyHunter", "<a href='{0}BountyHunterQuests.aspx'>{1}</a>");
            substitutions.Add("Gladiator", "<a href='{0}GladiatorQuests.aspx'>{1}</a>");
            substitutions.Add("Colonizer", "<a href='{0}ColonizerQuests.aspx'>{1}</a>");

            substitutions.Add("TradeRoute", "<a href='{0}Commerce/TradeRoutes.aspx'>{1}</a>");
            substitutions.Add("Shop", "<a href='{0}Commerce/Shop.aspx'>{1}</a>");
            substitutions.Add("TradeRoutes", "<a href='{0}Commerce/TradeRoutes.aspx'>{1}</a>");
            substitutions.Add("Markets", "<a href='{0}Commerce/Markets.aspx'>{1}</a>");
            substitutions.Add("Market", "<a href='{0}Commerce/Markets.aspx'>{1}</a>");
            substitutions.Add("AuctionHouse", "<a href='{0}Commerce/AuctionHouse.aspx'>{1}</a>");
            substitutions.Add("Orions", "<a href='{0}Commerce/Orions.aspx'>{1}</a>");
        }

        public static string Wikify(string raw)
        {
            raw = ReplaceResources(raw);
            raw = ReplaceSubstitutions(raw);
            raw = ReplaceShopServices(raw);
            return raw;
        }        

        public static string Wikify(string raw, IEnumerable<IQuestInfo> quests)
        {
            raw = ReplaceResources(raw);
            raw = ReplaceQuests(raw, quests);
            raw = ReplaceSubstitutions(raw);
            raw = ReplaceShopServices(raw);
            return raw;    
        }

        private static string ReplaceShopServices(string raw)
        {
            foreach (ServiceType type in Enum.GetValues(typeof(ServiceType))) {
                string key = string.Format("[{0}]", type);
                string value = string.Format("<a href='{0}Commerce/Shop.aspx#{2}'>{1}</a>", GetBasePath(), Translator.Translate(string.Format("{0}Info", type)), type);
                raw = raw.Replace(key, value);
            }
            return raw;
        }

        private static string ReplaceSubstitutions(string raw)
        {
            foreach (KeyValuePair<string, string> pair in substitutions) {
                string key = string.Format("[{0}]", pair.Key);
                string value = string.Format(pair.Value, GetBasePath(), Translator.Translate(pair.Key));
                raw = raw.Replace(key, value);
            }
            return raw;
        }

        private static string GetBasePath()
        {
            if (HttpContext.Current == null) {
                return string.Format("/{0}/", Translator.CurrentLanguage);
            }
            return FrameUrl;
        }

        private static string ReplaceResources(string raw)
        {
            foreach (IResourceInfo info in RulesUtils.GetResources()) { 
                string key = string.Format("[{0}]", info.Name);
                string value = string.Format("<a class='{2}' href='{0}'>{1}</a>", GetResourceUrl(info), Translator.Translate(info.Name), info.Name.ToLower());
                raw = raw.Replace(key, value); 
            }
            return raw;
        }

        private static string GetResourceUrl(IResourceInfo info)
        {
            return string.Format("{2}{3}/{0}.aspx", info.Name, Translator.Translate(info.Name), GetBasePath(), info.Type.ToString());
        }

        private static string ReplaceQuests(string raw, IEnumerable<IQuestInfo> quests)
        {
            foreach (IQuestInfo info in quests)
            {
                string key = string.Format("[{0}]", info.Name);
                string value = string.Format("<a href='{0}Quest/{1}.aspx'>{2}</a>",
                        GetBasePath(), info.Name, Translator.Translate(info.Name)
                    );
                raw = raw.Replace(key, value);
            }
            return raw;
        }

        #endregion Wikifiing

    };

}
