using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of Invoice 
    /// </summary>
	public class InvoicePagedList : BasePagedList<Invoice> {
		
		#region BasePagedList<Invoice> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<Invoice> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetInvoicePersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "Invoice";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			InvoiceItem entity = new InvoiceItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"11\"> Listing <i>") );
			Controls.Add( new InvoiceCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>Invoice</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Identifier</th>") );
			Controls.Add( new LiteralControl("<th>Name</th>") );
			Controls.Add( new LiteralControl("<th>Nif</th>") );
			Controls.Add( new LiteralControl("<th>Money</th>") );
			Controls.Add( new LiteralControl("<th>Country</th>") );
			Controls.Add( new LiteralControl("<th>Transaction</th>") );
			Controls.Add( new LiteralControl("<th>Payment</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new InvoiceDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceIdentifier () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceNif () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceMoney () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceCountry () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceTransaction () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoicePayment () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new InvoiceDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<Invoice> Implementation
		
	};

}