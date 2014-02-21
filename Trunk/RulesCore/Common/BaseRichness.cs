using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// Generic resource richness implementation
    /// </summary>
    public abstract class BaseRichness : IResourceRichness {

        #region IResourceRichness Implementation

        private Dictionary<IResourceInfo, int> richness = new Dictionary<IResourceInfo, int>();
        public Dictionary<IResourceInfo, int> Richness { 
            get { return richness; }
            set { richness = value; }
        }

        public int GetRichness(IResourceInfo info)
        {
            if (!Richness.ContainsKey(info)) {
                return 0;
            }
            return Richness[info];
        }

        public void SetRichness(IResourceInfo info, int quantity)
        {
            Richness[info] = quantity;
        }

        public void AddToRichness(IResourceInfo info, int quantity)
        {
            SetRichness(info, GetRichness(info) + quantity);
        }

        #endregion IResourceRichness Implementation

    };
}
