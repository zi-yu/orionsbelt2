
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that enables Payment search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PaymentPagedList
    /// </remarks>
	public class PaymentSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox principalId = new TextBox();
		protected DropDownList operatorsForPrincipalId = new DropDownList();
		protected TextBox method = new TextBox();
		protected DropDownList operatorsForMethod = new DropDownList();
		protected TextBox request = new TextBox();
		protected DropDownList operatorsForRequest = new DropDownList();
		protected TextBox response = new TextBox();
		protected DropDownList operatorsForResponse = new DropDownList();
		protected TextBox requestId = new TextBox();
		protected DropDownList operatorsForRequestId = new DropDownList();
		protected TextBox verifyState = new TextBox();
		protected DropDownList operatorsForVerifyState = new DropDownList();
		protected TextBox parameters = new TextBox();
		protected DropDownList operatorsForParameters = new DropDownList();
		protected TextBox parentPayment = new TextBox();
		protected DropDownList operatorsForParentPayment = new DropDownList();
		protected TextBox ammount = new TextBox();
		protected DropDownList operatorsForAmmount = new DropDownList();
		protected TextBox createdDate = new TextBox();
		protected DropDownList operatorsForCreatedDate = new DropDownList();
		protected TextBox updatedDate = new TextBox();
		protected DropDownList operatorsForUpdatedDate = new DropDownList();
		protected TextBox lastActionUserId = new TextBox();
		protected DropDownList operatorsForLastActionUserId = new DropDownList();
		protected Button button = new Button();

		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// Search box for Payment's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Payment's PrincipalId property
        /// </summary>
		public TextBox PrincipalId {
			get { return principalId; }
			set { principalId = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's PrincipalId operators
        /// </summary>
		public DropDownList OperatorsForPrincipalId {
			get { return operatorsForPrincipalId; }
			set { operatorsForPrincipalId = value; }
		}
		
		/// <summary>
        /// Search box for Payment's Method property
        /// </summary>
		public TextBox Method {
			get { return method; }
			set { method = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Method operators
        /// </summary>
		public DropDownList OperatorsForMethod {
			get { return operatorsForMethod; }
			set { operatorsForMethod = value; }
		}
		
		/// <summary>
        /// Search box for Payment's Request property
        /// </summary>
		public TextBox Request {
			get { return request; }
			set { request = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Request operators
        /// </summary>
		public DropDownList OperatorsForRequest {
			get { return operatorsForRequest; }
			set { operatorsForRequest = value; }
		}
		
		/// <summary>
        /// Search box for Payment's Response property
        /// </summary>
		public TextBox Response {
			get { return response; }
			set { response = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Response operators
        /// </summary>
		public DropDownList OperatorsForResponse {
			get { return operatorsForResponse; }
			set { operatorsForResponse = value; }
		}
		
		/// <summary>
        /// Search box for Payment's RequestId property
        /// </summary>
		public TextBox RequestId {
			get { return requestId; }
			set { requestId = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's RequestId operators
        /// </summary>
		public DropDownList OperatorsForRequestId {
			get { return operatorsForRequestId; }
			set { operatorsForRequestId = value; }
		}
		
		/// <summary>
        /// Search box for Payment's VerifyState property
        /// </summary>
		public TextBox VerifyState {
			get { return verifyState; }
			set { verifyState = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's VerifyState operators
        /// </summary>
		public DropDownList OperatorsForVerifyState {
			get { return operatorsForVerifyState; }
			set { operatorsForVerifyState = value; }
		}
		
		/// <summary>
        /// Search box for Payment's Parameters property
        /// </summary>
		public TextBox Parameters {
			get { return parameters; }
			set { parameters = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Parameters operators
        /// </summary>
		public DropDownList OperatorsForParameters {
			get { return operatorsForParameters; }
			set { operatorsForParameters = value; }
		}
		
		/// <summary>
        /// Search box for Payment's ParentPayment property
        /// </summary>
		public TextBox ParentPayment {
			get { return parentPayment; }
			set { parentPayment = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's ParentPayment operators
        /// </summary>
		public DropDownList OperatorsForParentPayment {
			get { return operatorsForParentPayment; }
			set { operatorsForParentPayment = value; }
		}
		
		/// <summary>
        /// Search box for Payment's Ammount property
        /// </summary>
		public TextBox Ammount {
			get { return ammount; }
			set { ammount = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's Ammount operators
        /// </summary>
		public DropDownList OperatorsForAmmount {
			get { return operatorsForAmmount; }
			set { operatorsForAmmount = value; }
		}
		
		/// <summary>
        /// Search box for Payment's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Payment's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Payment's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Payment's LastActionUserId operators
        /// </summary>
		public DropDownList OperatorsForLastActionUserId {
			get { return operatorsForLastActionUserId; }
			set { operatorsForLastActionUserId = value; }
		}
		
		#endregion Control Properties
		
		#region Control Events
		
		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			EnsureChildControls();
			button.Text = "Search";
		}
		
		/// <summary>
        /// Control actions
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnLoad( EventArgs args )
		{
			base.OnLoad(args);
			if( Page.IsPostBack ) {
				StringWriter writer = new StringWriter();
				bool first = true;
				
				if( !string.IsNullOrEmpty( Id.Text ) ) {
					writer.Write( "{2} e.Id {0} '{1}' ",
							operatorsForId.SelectedValue, 
							Id.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PrincipalId.Text ) ) {
					writer.Write( "{2} e.PrincipalId {0} '{1}' ",
							operatorsForPrincipalId.SelectedValue, 
							PrincipalId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Method.Text ) ) {
					writer.Write( "{2} e.Method {0} '{1}' ",
							operatorsForMethod.SelectedValue, 
							Method.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Request.Text ) ) {
					writer.Write( "{2} e.Request {0} '{1}' ",
							operatorsForRequest.SelectedValue, 
							Request.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Response.Text ) ) {
					writer.Write( "{2} e.Response {0} '{1}' ",
							operatorsForResponse.SelectedValue, 
							Response.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RequestId.Text ) ) {
					writer.Write( "{2} e.RequestId {0} '{1}' ",
							operatorsForRequestId.SelectedValue, 
							RequestId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VerifyState.Text ) ) {
					writer.Write( "{2} e.VerifyState {0} '{1}' ",
							operatorsForVerifyState.SelectedValue, 
							VerifyState.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Parameters.Text ) ) {
					writer.Write( "{2} e.Parameters {0} '{1}' ",
							operatorsForParameters.SelectedValue, 
							Parameters.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ParentPayment.Text ) ) {
					writer.Write( "{2} e.ParentPayment {0} '{1}' ",
							operatorsForParentPayment.SelectedValue, 
							ParentPayment.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Ammount.Text ) ) {
					writer.Write( "{2} e.Ammount {0} '{1}' ",
							operatorsForAmmount.SelectedValue, 
							Ammount.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreatedDate.Text ) ) {
					writer.Write( "{2} e.CreatedDate {0} '{1}' ",
							operatorsForCreatedDate.SelectedValue, 
							CreatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UpdatedDate.Text ) ) {
					writer.Write( "{2} e.UpdatedDate {0} '{1}' ",
							operatorsForUpdatedDate.SelectedValue, 
							UpdatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastActionUserId.Text ) ) {
					writer.Write( "{2} e.LastActionUserId {0} '{1}' ",
							operatorsForLastActionUserId.SelectedValue, 
							LastActionUserId.Text, first ? "" : ","
						);
					first = false;
				}

				string search = writer.ToString();
				if( !string.IsNullOrEmpty(search) ) {
					HttpContext.Current.Items[BasePagedList<Payment>.GetWhereKey("Payment")] = writer.ToString();
				}
			}
		}
		
		/// <summary>
        /// Creates the control tree
        /// </summary>
		protected override void CreateChildControls()
        {
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th>Field</th><th>Operator</th><th>Search</th></tr>") );
			Id.ID = "searchId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Id</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Id );
			Controls.Add( new LiteralControl("</td><tr>") );
			PrincipalId.ID = "searchPrincipalId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PrincipalId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPrincipalId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PrincipalId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Method.ID = "searchMethod";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Method</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMethod ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Method );
			Controls.Add( new LiteralControl("</td><tr>") );
			Request.ID = "searchRequest";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Request</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRequest ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Request );
			Controls.Add( new LiteralControl("</td><tr>") );
			Response.ID = "searchResponse";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Response</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForResponse ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Response );
			Controls.Add( new LiteralControl("</td><tr>") );
			RequestId.ID = "searchRequestId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RequestId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRequestId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RequestId );
			Controls.Add( new LiteralControl("</td><tr>") );
			VerifyState.ID = "searchVerifyState";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VerifyState</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVerifyState ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VerifyState );
			Controls.Add( new LiteralControl("</td><tr>") );
			Parameters.ID = "searchParameters";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Parameters</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForParameters ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Parameters );
			Controls.Add( new LiteralControl("</td><tr>") );
			ParentPayment.ID = "searchParentPayment";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ParentPayment</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForParentPayment ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ParentPayment );
			Controls.Add( new LiteralControl("</td><tr>") );
			Ammount.ID = "searchAmmount";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Ammount</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAmmount ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Ammount );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreatedDate.ID = "searchCreatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			UpdatedDate.ID = "searchUpdatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UpdatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUpdatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UpdatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastActionUserId.ID = "searchLastActionUserId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastActionUserId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastActionUserId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastActionUserId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Controls.Add( new LiteralControl("<tr><td></td><td></td><td>") );
			Controls.Add( button );
			Controls.Add( new LiteralControl("</td></tr>") );
			Controls.Add( new LiteralControl("</table>") );
        }
		
		#endregion Control Events
		
		#region Utilities
		
		/// <summary>
        /// Adds Search operators
        /// </summary>
        /// <param name="list">The Target List</param>
        /// <returns>The target list</returns>
		private DropDownList AddOperators( DropDownList list )
		{
			list.Items.Add( "=" );
			list.Items.Add( "!=" );
			list.Items.Add( "<" );
			list.Items.Add( ">" );
			list.Items.Add( "<=" );
			list.Items.Add( ">=" );
			list.Items.Add( "like" );
			list.Items.Add( "not like" );
			
			return list;
		}
		
		#endregion Utilities
	
	};

}
