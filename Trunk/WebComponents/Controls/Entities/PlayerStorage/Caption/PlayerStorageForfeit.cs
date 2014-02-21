
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a PlayerStorage's Forfeit
    /// </summary>
	public class PlayerStorageForfeit : BaseFieldControl<PlayerStorage>, INamingContainer {
	
		#region BaseFieldControl<PlayerStorage> Implementation
		
		private OfferingPagedList list = new OfferingPagedList ();
		
		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnInit( EventArgs args )
        {
			base.OnInit(args);
			while (Controls.Count > 0) {
                Control control = Controls[0];
                list.Controls.Add(control);
            }
            Controls.Add(list);
        }
        
        /// <summary>
        /// Sets the items per page
        /// </summary>
        public int ItemsPerPage {
            get { return list.ItemsPerPage; }
            set { list.ItemsPerPage = value; }
        }
        
        /// <summary>
        /// Sets the order by field
        /// </summary>
        public string OrderBy {
            get { return list.OrderBy; }
            set { list.OrderBy = value; }
        }
        
        /// <summary>
        /// Sets the order by parameter
        /// </summary>
        public string OrderByParam {
            get { return list.OrderByParam; }
            set { list.OrderByParam = value; }
        }

		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, PlayerStorage entity, int renderCount, bool flipFlop )
		{
			list.Where = "e.ReceiverNHibernate.Id = " + entity.Id;
			list.RenderControl(writer);
		}
		
		#endregion BaseFieldControl<PlayerStorage> Implementation
		
	};

}
