using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of Market 
    /// </summary>
	public class MarketPagedList : BasePagedList<Market> {
		
		#region BasePagedList<Market> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<Market> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetMarketPersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "Market";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			MarketItem entity = new MarketItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"9\"> Listing <i>") );
			Controls.Add( new MarketCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>Market</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Name</th>") );
			Controls.Add( new LiteralControl("<th>Level</th>") );
			Controls.Add( new LiteralControl("<th>Coordinates</th>") );
			Controls.Add( new LiteralControl("<th>Sector</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new MarketDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketCoordinates () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketSector () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new MarketDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<Market> Implementation
		
	};

}