using System;
using OrionsBelt.Core;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Engine.Alliances {
    
    /// <summary>
    /// Represented an alliance
    /// </summary>
    public class Alliance : IAlliance {

        #region IBackToStorage Implementation

        private AllianceStorage storage;

        public AllianceStorage Storage {
            get {
                if (storage == null) {
                    throw new EngineException("Storage is null");
                }
                return storage;
            }
            set { storage = value; }
        }

        public void PrepareStorage()
        {
            if (this.storage == null) {
                this.storage = Persistance.Create<AllianceStorage>();
            }
        }

        public void UpdateStorage()
        {
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
