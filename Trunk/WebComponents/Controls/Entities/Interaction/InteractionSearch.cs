
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
    /// Control that enables Interaction search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a InteractionPagedList
    /// </remarks>
	public class InteractionSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox source = new TextBox();
		protected DropDownList operatorsForSource = new DropDownList();
		protected TextBox target = new TextBox();
		protected DropDownList operatorsForTarget = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox response = new TextBox();
		protected DropDownList operatorsForResponse = new DropDownList();
		protected TextBox responseExtension = new TextBox();
		protected DropDownList operatorsForResponseExtension = new DropDownList();
		protected TextBox interactionContext = new TextBox();
		protected DropDownList operatorsForInteractionContext = new DropDownList();
		protected TextBox resolved = new TextBox();
		protected DropDownList operatorsForResolved = new DropDownList();
		protected TextBox sourceAditionalData = new TextBox();
		protected DropDownList operatorsForSourceAditionalData = new DropDownList();
		protected TextBox targetAditionalData = new TextBox();
		protected DropDownList operatorsForTargetAditionalData = new DropDownList();
		protected TextBox sourceType = new TextBox();
		protected DropDownList operatorsForSourceType = new DropDownList();
		protected TextBox targetType = new TextBox();
		protected DropDownList operatorsForTargetType = new DropDownList();
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
        /// Search box for Interaction's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's Source property
        /// </summary>
		public TextBox Source {
			get { return source; }
			set { source = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Source operators
        /// </summary>
		public DropDownList OperatorsForSource {
			get { return operatorsForSource; }
			set { operatorsForSource = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's Target property
        /// </summary>
		public TextBox Target {
			get { return target; }
			set { target = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Target operators
        /// </summary>
		public DropDownList OperatorsForTarget {
			get { return operatorsForTarget; }
			set { operatorsForTarget = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's Response property
        /// </summary>
		public TextBox Response {
			get { return response; }
			set { response = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Response operators
        /// </summary>
		public DropDownList OperatorsForResponse {
			get { return operatorsForResponse; }
			set { operatorsForResponse = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's ResponseExtension property
        /// </summary>
		public TextBox ResponseExtension {
			get { return responseExtension; }
			set { responseExtension = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's ResponseExtension operators
        /// </summary>
		public DropDownList OperatorsForResponseExtension {
			get { return operatorsForResponseExtension; }
			set { operatorsForResponseExtension = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's InteractionContext property
        /// </summary>
		public TextBox InteractionContext {
			get { return interactionContext; }
			set { interactionContext = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's InteractionContext operators
        /// </summary>
		public DropDownList OperatorsForInteractionContext {
			get { return operatorsForInteractionContext; }
			set { operatorsForInteractionContext = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's Resolved property
        /// </summary>
		public TextBox Resolved {
			get { return resolved; }
			set { resolved = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's Resolved operators
        /// </summary>
		public DropDownList OperatorsForResolved {
			get { return operatorsForResolved; }
			set { operatorsForResolved = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's SourceAditionalData property
        /// </summary>
		public TextBox SourceAditionalData {
			get { return sourceAditionalData; }
			set { sourceAditionalData = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's SourceAditionalData operators
        /// </summary>
		public DropDownList OperatorsForSourceAditionalData {
			get { return operatorsForSourceAditionalData; }
			set { operatorsForSourceAditionalData = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's TargetAditionalData property
        /// </summary>
		public TextBox TargetAditionalData {
			get { return targetAditionalData; }
			set { targetAditionalData = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's TargetAditionalData operators
        /// </summary>
		public DropDownList OperatorsForTargetAditionalData {
			get { return operatorsForTargetAditionalData; }
			set { operatorsForTargetAditionalData = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's SourceType property
        /// </summary>
		public TextBox SourceType {
			get { return sourceType; }
			set { sourceType = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's SourceType operators
        /// </summary>
		public DropDownList OperatorsForSourceType {
			get { return operatorsForSourceType; }
			set { operatorsForSourceType = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's TargetType property
        /// </summary>
		public TextBox TargetType {
			get { return targetType; }
			set { targetType = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's TargetType operators
        /// </summary>
		public DropDownList OperatorsForTargetType {
			get { return operatorsForTargetType; }
			set { operatorsForTargetType = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Interaction's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Interaction's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Source.Text ) ) {
					writer.Write( "{2} e.Source {0} '{1}' ",
							operatorsForSource.SelectedValue, 
							Source.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Target.Text ) ) {
					writer.Write( "{2} e.Target {0} '{1}' ",
							operatorsForTarget.SelectedValue, 
							Target.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( ResponseExtension.Text ) ) {
					writer.Write( "{2} e.ResponseExtension {0} '{1}' ",
							operatorsForResponseExtension.SelectedValue, 
							ResponseExtension.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( InteractionContext.Text ) ) {
					writer.Write( "{2} e.InteractionContext {0} '{1}' ",
							operatorsForInteractionContext.SelectedValue, 
							InteractionContext.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Resolved.Text ) ) {
					writer.Write( "{2} e.Resolved {0} '{1}' ",
							operatorsForResolved.SelectedValue, 
							Resolved.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SourceAditionalData.Text ) ) {
					writer.Write( "{2} e.SourceAditionalData {0} '{1}' ",
							operatorsForSourceAditionalData.SelectedValue, 
							SourceAditionalData.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TargetAditionalData.Text ) ) {
					writer.Write( "{2} e.TargetAditionalData {0} '{1}' ",
							operatorsForTargetAditionalData.SelectedValue, 
							TargetAditionalData.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SourceType.Text ) ) {
					writer.Write( "{2} e.SourceType {0} '{1}' ",
							operatorsForSourceType.SelectedValue, 
							SourceType.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TargetType.Text ) ) {
					writer.Write( "{2} e.TargetType {0} '{1}' ",
							operatorsForTargetType.SelectedValue, 
							TargetType.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Interaction>.GetWhereKey("Interaction")] = writer.ToString();
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
			Source.ID = "searchSource";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Source</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSource ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Source );
			Controls.Add( new LiteralControl("</td><tr>") );
			Target.ID = "searchTarget";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Target</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTarget ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Target );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			Response.ID = "searchResponse";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Response</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForResponse ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Response );
			Controls.Add( new LiteralControl("</td><tr>") );
			ResponseExtension.ID = "searchResponseExtension";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ResponseExtension</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForResponseExtension ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ResponseExtension );
			Controls.Add( new LiteralControl("</td><tr>") );
			InteractionContext.ID = "searchInteractionContext";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>InteractionContext</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForInteractionContext ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( InteractionContext );
			Controls.Add( new LiteralControl("</td><tr>") );
			Resolved.ID = "searchResolved";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Resolved</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForResolved ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Resolved );
			Controls.Add( new LiteralControl("</td><tr>") );
			SourceAditionalData.ID = "searchSourceAditionalData";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SourceAditionalData</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSourceAditionalData ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SourceAditionalData );
			Controls.Add( new LiteralControl("</td><tr>") );
			TargetAditionalData.ID = "searchTargetAditionalData";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TargetAditionalData</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTargetAditionalData ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TargetAditionalData );
			Controls.Add( new LiteralControl("</td><tr>") );
			SourceType.ID = "searchSourceType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SourceType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSourceType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SourceType );
			Controls.Add( new LiteralControl("</td><tr>") );
			TargetType.ID = "searchTargetType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TargetType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTargetType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TargetType );
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
