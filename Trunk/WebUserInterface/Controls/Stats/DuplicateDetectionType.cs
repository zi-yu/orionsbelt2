using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class DuplicateDetectionType : DuplicateDetectionFindType
    {
        private IDictionary<int, string> principals;

        public IDictionary<int, string> Principals
        {
            get { return principals; }
            set { principals = value; }
        }

        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, DuplicateDetection entity, int renderCount, bool flipFlop)
        {
            writer.Write(LanguageManager.Instance.Get(entity.FindType));

        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
