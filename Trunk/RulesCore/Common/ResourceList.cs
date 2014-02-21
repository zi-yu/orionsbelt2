using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Results;
using System.Collections.Generic;
using System.IO;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a resourc list
    /// </summary>
    public class ResourceList {

        #region Ctor

        public ResourceList()
        {
            resources = new List<IPlanetResource>();
        }

        #endregion Ctor

        #region Properties

        private List<IPlanetResource> resources = null;

        public List<IPlanetResource> Resources {
            get { return resources; }
            set { resources = value; }
        }

        public int Count {
            get { return Resources.Count; }
        }

        #endregion Properties

        #region Utilities

        public void DirectAdd(IPlanetResource resource)
        {
            Resources.Add(resource);
        }

        public IList<IPlanetResource> Get(IResourceInfo info)
        {
            List<IPlanetResource> list = new List<IPlanetResource>();

            foreach (IPlanetResource resource in Resources) {
                if (resource.Info == info && IsAvailable(resource) ) {
                    list.Add(resource);
                }
            }

            return list;
        }

        private bool IsAvailable(IPlanetResource resource)
        {
            if (resource.State == ResourceState.Available || resource.State == ResourceState.Running){
                return true;
            }
            return false;
        }

        public List<IPlanetResource> Get(ResourceState resourceState)
        {
            return Resources.FindAll(delegate(IPlanetResource res) { return res.State == resourceState; });
        }

        public void Clear()
        {
            Resources.Clear();
        }

        #endregion Utilities

    };

}
