using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Converts PlanetResourceStorage to/from IPlanetResource
    /// </summary>
    public static class PlanetResourceConversion {

        #region Load/Store Methods

        public static IPlanetResource ConvertToResource(PlanetResourceStorage storage)
        {
            PlanetResource resource = new PlanetResource();
            SetResource(resource, storage);
            return resource;
        }

        public static PlanetResourceStorage ConvertToStorage(IPlanetResource resource)
        {
            using (IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance())
            {
                PlanetResourceStorage storage = persistance.Create();
                SetStorage(storage, resource);
                return storage;
            }
        }

        public static void SetStorage(PlanetResourceStorage storage, IPlanetResource resource)
        {
            resource.Storage = storage;

            storage.Level = resource.Level;
            storage.EndTick = resource.EndTick;
            storage.Quantity = resource.Quantity;
            storage.QueueOrder = resource.QueueOrder;
            storage.State = resource.State.ToString();
            storage.Type = resource.Info.Name;

            if (resource.Slot != null) {
                storage.Slot = resource.Slot.Identifier;
            }else {
                storage.Slot = null;
            }
        }

        internal static void SetResource(IPlanetResource resource, PlanetResourceStorage storage)
        {
            resource.Storage = storage;

            resource.Level = storage.Level;
            resource.Quantity = storage.Quantity;
            resource.QueueOrder = storage.QueueOrder;
            resource.State = GetResourceState(storage.State);
            resource.Info = GetInfo(storage.Type);
            resource.EndTick = storage.EndTick;
            resource.Slot = GetSlot(resource, storage.Slot);
            resource.IsTemplate = false;

            resource.IsDirty = false;
        }

        private static IFacilitySlot GetSlot(IPlanetResource resource, string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) {
                return null;
            }

            if (!resource.HasOwner) {
                return null;
            }

            IPlanet planet = resource.Owner as IPlanet;
            if (planet != null) {
                return planet.Info.GetSlot(identifier);
            }

            return null;
        }

        private static IResourceInfo GetInfo(string raw)
        {
            return RulesUtils.GetResource(raw);
        }

        private static ResourceState GetResourceState(string raw)
        {
            return (ResourceState)Enum.Parse(typeof(ResourceState), raw);
        }

        #endregion Load/Store Methods

    };

}
