using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class DuplicateClone : DuplicateDetectionDuplicate
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
            string prin = entity.Duplicate.ToString();

            if (principals.ContainsKey(entity.Duplicate))
            {
                prin = principals[entity.Duplicate];
                writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a><b> <a href='UserDuplicates.aspx?Principal={1}'>[+]</a></b>",
                WebUtilities.ApplicationPath, entity.Duplicate, prin);
            }
            else
            {
                writer.Write("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                WebUtilities.ApplicationPath, entity.Duplicate, prin);
            }
            

        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
