using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of SpecialEvent 
    /// </summary>
	public class SpecialEventPagedList : BasePagedList<SpecialEvent> {
		
		#region BasePagedList<SpecialEvent> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<SpecialEvent> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetSpecialEventPersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "SpecialEvent";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			SpecialEventItem entity = new SpecialEventItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"9\"> Listing <i>") );
			Controls.Add( new SpecialEventCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>SpecialEvent</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Cost</th>") );
			Controls.Add( new LiteralControl("<th>Token</th>") );
			Controls.Add( new LiteralControl("<th>Resorces</th>") );
			Controls.Add( new LiteralControl("<th>BeginDate</th>") );
			Controls.Add( new LiteralControl("<th>EndDate</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new SpecialEventDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventCost () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventToken () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventResorces () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventBeginDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventEndDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new SpecialEventDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<SpecialEvent> Implementation
		
	};

}