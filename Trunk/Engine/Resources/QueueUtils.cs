using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using OrionsBelt.RulesCore;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.Results;

namespace OrionsBelt.Engine.Resources {

    /// <summary>
    /// Generic resource queue implementation details
    /// </summary>
    public static class QueueUtils {

        #region IResourceQueue Mapping

        public static Result CanQueue(IResourceQueue queue, IPlanetResource resource)
        {
            if (!IsValidState(resource)) {
                return Result.Create(new InvalidResourceState());
            }
            if (InvalidSlotInformation(queue, resource)) {
                return Result.Create(new InvalidSlot(resource.Slot));
            }
            bool available = queue.GetUsedQueueSpace(resource.Info.Type) < queue.TotalQueueSpace;
            return Result.Create( new CanQueueResult(available) );
        }

        private static bool InvalidSlotInformation(IResourceQueue queue, IPlanetResource resource)
        {
            if (resource.Info.Type != ResourceType.Facility) {
                return false;
            }

            IPlanet planet = queue as IPlanet;
            if (planet == null){
                return false;
            }

            if (planet.Info == null || planet.Info.FacilitySlots.Count == 0) {
                return false;
            }

            if (resource.Slot == null) {
                return true;
            }

            if(!SlotExistsInInfo(resource, planet)){
                return false;
            }

            foreach (IPlanetResource planetResource in planet.Facilities.Resources) {
                if( planetResource.Slot != null && resource.Slot.Identifier == planetResource.Slot.Identifier ) {
                    return resource.Level <= 1;
                }
            }

            return false;
        }

        private static bool SlotExistsInInfo(IPlanetResource resource, IPlanet planet)
        {
            foreach (IFacilitySlot slot in planet.Info.FacilitySlots) {
                if (slot.Identifier == resource.Slot.Identifier) {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidState(IPlanetResource resource)
        {
            return resource.State == ResourceState.Running || resource.State == ResourceState.Available;
        }

        public static IPlanetResource Enqueue(IResourceQueue queue, IPlanetResource resource)
        {
            IPlanetResource enqueued = EnqueueLogic(queue, resource);
            resource.Info.ProcessCost(resource);
            return enqueued;
        }

        private static IPlanetResource EnqueueLogic(IResourceQueue queue, IPlanetResource resource)
        {
            IPlanetResource original = resource;
            original.Owner = queue.ResourceOwner;
            if (!IsUpgrade(original)){
                IPlanetResource duplicated = new PlanetResource(resource, ResourceState.InQueue);
                duplicated.QueueOrder = GetNextQueueSlot(queue, resource.Info.Type);
                return duplicated;
            } else {
                original.State = ResourceState.InQueue;
                original.QueueOrder = GetNextQueueSlot(queue, resource.Info.Type);
                return original;
            }
        }

        public static int GetNextQueueSlot(IResourceQueue queue, ResourceType type)
        {
            return queue.GetQueueList(type).Count;
        }

        public static bool IsUpgrade(IPlanetResource resource)
        {
            return RulesUtils.IsUpgrade(resource);
        }

        public static void Dequeue(IResourceQueue queue, IPlanetResource resource)
        {
            if (resource.State != ResourceState.InQueue) {
                throw new EngineException("Trying to dequeue a resource in the {0} state", resource.State);
            }
            if (IsUpgrade(resource)){
                resource.State = ResourceState.Running;
            } else {
                resource.State = ResourceState.Deleted;
            }

            resource.Info.UndoCost(resource);
            --resource.Level;
        }

        public static IList<IPlanetResource> GetQueueList(IPlanet planet, ResourceType type)
        {
            ResourceList list = ResourceUtils.GetResourcesByType(planet, type);
            List<IPlanetResource> inqueue = list.Get(ResourceState.InQueue);
            inqueue.Sort(delegate(IPlanetResource r1, IPlanetResource r2) { return r1.QueueOrder.CompareTo(r2.QueueOrder); });
            return inqueue;
        }

        public static int GetTotalQueueSpace(IPlanet planet)
        {
            IResourceInfo info = RulesUtils.GetIntrinsic(typeof(QueueSpace));
            return planet.Owner.GetQuantity(info);
        }

        public static int GetUsedQueueSpace(IPlanet planet, ResourceType type)
        {
            return GetQueueList(planet, type).Count;
        }

        public static IPlanetResource GetNextResourceToProduction(IPlanet planet, ResourceType type)
        {
            IList<IPlanetResource> list = GetQueueList(planet, type);
            if (list.Count == 0) {
                return null;
            }

            return list[0];
        }

        #endregion IResourceQueue Mapping

    };
}
