using System.Collections;
using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using System.Web;
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Engine.Alliances;
using System.IO;
using OrionsBelt.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine {

    /// <summary>
    /// MedalManager utilities
    /// </summary>
    public static class MedalManager  {

        #region Add/Remove Medal

        public static bool Add(IPlayer source, IPlayer target, MedalType type)
        {
            if (PrincipalAlreadyAddedMedal(source.Principal, target, type)) {
                return false;
            }

            AddMedal(source, target, type, false);
            return true;
        }

        public static bool Add(IPlayer target, MedalType type)
        {
            AddMedal(null, target, type, true);
            return true;
        }

        public static bool Add(Principal source, Principal target, MedalType type)
        {
            if (PrincipalAlreadyAddedMedal(source, target, type)) {
                return false;
            }

            AddMedal(source, target, type, false);
            return true;
        }

        public static bool Add(Principal target, MedalType type)
        {
            AddMedal(null, target, type, true);
            return true;
        }

        private static void AddMedal(IPlayer source, IPlayer target, MedalType type, bool isAuto)
        {
            using (IMedalPersistance persistance = Persistance.Instance.GetMedalPersistance())
            {
                persistance.StartTransaction();

                Medal medal = persistance.Create();
                medal.Name = type.ToString();
                medal.Player = target.Storage;
                medal.IsAuto = isAuto;
                if (!isAuto) {
                    target.Storage.Medals.Add(medal);
                }
                if( source != null ) {
                    Messenger.Add(new PlayerNewUserMedalMessage(target.Id, medal.Name, source.Name), persistance);
                } else {
                    Messenger.Add(new PlayerNewGameMedalMessage(target.Id, medal.Name), persistance);
                }
                persistance.Update(medal);

                persistance.CommitTransaction();
            }
        }

        private static void AddMedal(Principal source, Principal target, MedalType type, bool isAuto)
        {
            using (IMedalPersistance persistance = Persistance.Instance.GetMedalPersistance())
            {
                persistance.StartTransaction();

                Medal medal = persistance.Create();
                medal.Name = type.ToString();
                medal.Principal = target;
                medal.IsAuto = isAuto;
                if (!isAuto) {
                    target.Medals.Add(medal);
                }
                if( source != null ) {
                    Messenger.Add(new PrincipalNewUserMedalMessage(target.Id,medal.Name,source.Name), persistance);
                } else {
                    Messenger.Add(new PrincipalNewGameMedalMessage(target.Id, medal.Name), persistance);
                }
                persistance.Update(medal);

                persistance.CommitTransaction();
            }
        }

        #endregion Add/Remove Medal

        #region Utils

        private static bool PrincipalAlreadyAddedMedal(Principal principal, IPlayer target, MedalType type)
        {
            foreach (Medal medal in GetMedals(target)) {
                if (medal.Name == type.ToString() && medal.LastActionUserId == principal.Id) {
                    return true;
                }
            }
            return false;
        }

        public static IList<Medal> GetMedals(IPlayer player)
        {
            return player.Storage.Medals;
        }

        private static bool PrincipalAlreadyAddedMedal(Principal principal, Principal target, MedalType type)
        {
            foreach (Medal medal in GetMedals(target)) {
                if (medal.Name == type.ToString() && medal.LastActionUserId == principal.Id) {
                    return true;
                }
            }
            return false;
        }

        public static IList<Medal> GetMedals(Principal principal)
        {
            return principal.Medals;
        }

        #endregion Utils

    };
}
