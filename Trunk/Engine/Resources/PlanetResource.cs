using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Resources {

    /// <summary>
    /// This class represents a planet resource
    /// </summary>
    public class PlanetResource : IPlanetResource {

        #region Ctor

        public PlanetResource()
        {
        }

        public PlanetResource(IResourceOwner planet, Type type)
        {
            Info = RulesUtils.GetResource(type);
            Owner = planet;
            Quantity = 1;
            AttachToOwner();
            Init();
        }

        public PlanetResource(IResourceOwner planet, IResourceInfo info)
        {
            Info = info;
            Owner = planet;
            AttachToOwner();
            Init();
        }

        public PlanetResource(IResourceOwner planet, IResourceInfo info, int quantity)
        {
            Info = info;
            Quantity = quantity;
            Owner = planet;
            AttachToOwner();
            Init();
        }

        public void AttachToOwner(IResourceOwner owner)
        {
            this.Owner = owner;
            this.Owner.AddResource(this);
        }

        public void AttachToOwner()
        {
            if (HasOwner){
                Owner.AddResource(this);
            }
        }

        public PlanetResource(IPlanetResource resource)
        {
            Info = resource.Info;
            Quantity = resource.Quantity;
            if (resource.HasOwner) {
                Owner = resource.Owner;
            }
            Level = resource.Level;
            State = resource.State;
            Slot = resource.Slot;
            AttachToOwner();
        }

        public PlanetResource(IPlanetResource resource, ResourceState state)
        {
            Info = resource.Info;
            Quantity = resource.Quantity;
            if (resource.HasOwner) {
                Owner = resource.Owner;
            }
            Level = resource.Level;
            State = state;
            Slot = resource.Slot;
            AttachToOwner();
        }

        public PlanetResource(Type type)
        {
            Info = RulesUtils.GetResource(type);
            Init();
        }

        public PlanetResource(IResourceInfo type)
        {
            Info = type;
            Init();
        }

        private void Init()
        {
            Level = Info.StartLevel;
        }

        #endregion Ctor

        #region IPlanetResource Members

        private bool isTemplate = false;

        public bool IsTemplate  {
            get { return isTemplate; }
            set { isTemplate = value; }
        }

        private int endTick = -1;
        public int EndTick {
            get { return endTick; }
            set { 
                Touch();
                endTick = value; 
            }
        }

        private int queueOrder = -1;
        public int QueueOrder {
            get { return queueOrder; }
            set { 
                Touch();
                queueOrder = value; 
            }
        }

        private int quantity;
        public int Quantity {
            get { return quantity; }
            set {
                Touch();
                quantity = value; 
            }
        }

        private ResourceState state = ResourceState.Available;
        public ResourceState State {
            get { return state; }
            set {
                Touch();
                state = value; 
            }
        }

        private int level;
        public int Level {
            get { return level; }
            set {
                Touch();
                level = value; 
            }
        }

        public bool HasOwner {
            get { return planet != null; }
        }

        private IResourceOwner planet;
        public IResourceOwner Owner {
            get {
                if (planet == null) {
                    throw new EngineException("This resource `{0}' does not have an associated IResourceOwner", Info.Identifier);
                }
                return planet;  
            }
            set {
                Touch();
                planet = value; 
            }
        }

        private IResourceInfo info;
        public IResourceInfo Info {
            get {
                if (info == null) {
                    throw new EngineException("This resource does not have an associated IResourceInfo");
                }
                return info; 
            }
            set {
                Touch();
                info = value; 
            }
        }

        private IFacilitySlot slot = null;
        public IFacilitySlot Slot {
            get { return slot; }
            set { slot = value; Touch(); }
        }

        #endregion

        #region Methods

        public Result IsUpgradeAvailable()
        {
            return Info.IsUpgradeAvailable(this);
        }

        public void OnComplete()
        {
            Info.OnComplete(this);
        }

        #endregion

        #region Static Utils

        public static PlanetResource Create(IResourceInfo info, int quantity)
        {
            return Create(null, info, quantity);
        }

        public static PlanetResource Create(IResourceOwner owner, IResourceInfo info, int quantity)
        {
            PlanetResource res = new PlanetResource(owner, info, quantity);
            res.State = ResourceState.Available;
            return res;
        }

        public static PlanetResource Create(IResourceOwner owner, Type typeInfo, int quantity)
        {
            return Create(owner, RulesUtils.GetResource(typeInfo), quantity);
        }

        #endregion Static Utils

        #region Generic Utils

        public override string ToString()
        {
            return string.Format("Id:{5} Resource:{0} Quantity:{1} State:{2} Level:{3} QueueOrder:{4}", Info.Name, Quantity, State, Level, QueueOrder, Storage.Id);
        }

        #endregion Generic Utils

        #region IBackToStorage Implementation

        private PlanetResourceStorage storage;

        public PlanetResourceStorage Storage {
            get {
                if (this.storage == null) {
                    throw new EngineException("Storage is null");
                }
                return storage; 
            }
            set { storage = value; }
        }

        public void PrepareStorage()
        {
            if (this.storage == null) {
                this.storage = PlanetResourceConversion.ConvertToStorage(this);
            }
        }

        public void UpdateStorage()
        {
            PlanetResourceConversion.SetStorage(Storage, this);
        }

        public void Touch()
        {
            IsDirty = true;
        }

        private bool dirty = false;
        public bool IsDirty {
            get { return dirty; }
            set { dirty = value; }
        }

        #endregion IBackToStorage Implementation

    };
}
