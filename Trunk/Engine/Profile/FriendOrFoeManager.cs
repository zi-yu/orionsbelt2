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
    /// FriendOrFoeManager utilities
    /// </summary>
    public static class FriendOrFoeManager  {

        #region Add/Remove Friend Or Foe

        public static void AddFriend(IPlayer source, IPlayer target)
        {
            Add(source, target, true, new AddedAsFriendMessage(target.Id, source.Id, source.Name));
        }

        public static void AddEnemy(IPlayer source, IPlayer target)
        {
            Add(source, target, false, new AddedAsEnemyMessage(target.Id, source.Id, source.Name));
        }

        private static void Add(IPlayer source, IPlayer target, bool isFriend, IMessage msg)
        {
            using (IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance())
            {
                persistance.StartTransaction();

                FriendOrFoe entity = persistance.Create();
                entity.Source = source.Storage;
                entity.Target = target.Storage;
                entity.IsFriend = isFriend;
                persistance.Update(entity);
                Messenger.Add(msg, persistance);

                persistance.CommitTransaction();
            }
        }

        public static void RemoveRelationship(IPlayer source, IPlayer target, int relation)
        {
            using (IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance())
            {
                persistance.StartTransaction();

                persistance.Delete(relation);
                Messenger.Add(new RemovedFromListMessage(target.Id, source.Id, source.Name), persistance);

                persistance.CommitTransaction();
            }
        }

        #endregion Add Friend Or Foe

    };
}
