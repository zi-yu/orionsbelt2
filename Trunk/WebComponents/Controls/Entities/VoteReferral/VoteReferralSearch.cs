
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
    /// Control that enables VoteReferral search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a VoteReferralPagedList
    /// </remarks>
	public class VoteReferralSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox shortName = new TextBox();
		protected DropDownList operatorsForShortName = new DropDownList();
		protected TextBox url = new TextBox();
		protected DropDownList operatorsForUrl = new DropDownList();
		protected TextBox imageUrl = new TextBox();
		protected DropDownList operatorsForImageUrl = new DropDownList();
		protected TextBox reward = new TextBox();
		protected DropDownList operatorsForReward = new DropDownList();
		protected TextBox clickCount = new TextBox();
		protected DropDownList operatorsForClickCount = new DropDownList();
		protected TextBox voteOrder = new TextBox();
		protected DropDownList operatorsForVoteOrder = new DropDownList();
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
        /// Search box for VoteReferral's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's ShortName property
        /// </summary>
		public TextBox ShortName {
			get { return shortName; }
			set { shortName = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's ShortName operators
        /// </summary>
		public DropDownList OperatorsForShortName {
			get { return operatorsForShortName; }
			set { operatorsForShortName = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's Url property
        /// </summary>
		public TextBox Url {
			get { return url; }
			set { url = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's Url operators
        /// </summary>
		public DropDownList OperatorsForUrl {
			get { return operatorsForUrl; }
			set { operatorsForUrl = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's ImageUrl property
        /// </summary>
		public TextBox ImageUrl {
			get { return imageUrl; }
			set { imageUrl = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's ImageUrl operators
        /// </summary>
		public DropDownList OperatorsForImageUrl {
			get { return operatorsForImageUrl; }
			set { operatorsForImageUrl = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's Reward property
        /// </summary>
		public TextBox Reward {
			get { return reward; }
			set { reward = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's Reward operators
        /// </summary>
		public DropDownList OperatorsForReward {
			get { return operatorsForReward; }
			set { operatorsForReward = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's ClickCount property
        /// </summary>
		public TextBox ClickCount {
			get { return clickCount; }
			set { clickCount = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's ClickCount operators
        /// </summary>
		public DropDownList OperatorsForClickCount {
			get { return operatorsForClickCount; }
			set { operatorsForClickCount = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's VoteOrder property
        /// </summary>
		public TextBox VoteOrder {
			get { return voteOrder; }
			set { voteOrder = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's VoteOrder operators
        /// </summary>
		public DropDownList OperatorsForVoteOrder {
			get { return operatorsForVoteOrder; }
			set { operatorsForVoteOrder = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for VoteReferral's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for VoteReferral's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Name.Text ) ) {
					writer.Write( "{2} e.Name {0} '{1}' ",
							operatorsForName.SelectedValue, 
							Name.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ShortName.Text ) ) {
					writer.Write( "{2} e.ShortName {0} '{1}' ",
							operatorsForShortName.SelectedValue, 
							ShortName.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Url.Text ) ) {
					writer.Write( "{2} e.Url {0} '{1}' ",
							operatorsForUrl.SelectedValue, 
							Url.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ImageUrl.Text ) ) {
					writer.Write( "{2} e.ImageUrl {0} '{1}' ",
							operatorsForImageUrl.SelectedValue, 
							ImageUrl.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Reward.Text ) ) {
					writer.Write( "{2} e.Reward {0} '{1}' ",
							operatorsForReward.SelectedValue, 
							Reward.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ClickCount.Text ) ) {
					writer.Write( "{2} e.ClickCount {0} '{1}' ",
							operatorsForClickCount.SelectedValue, 
							ClickCount.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VoteOrder.Text ) ) {
					writer.Write( "{2} e.VoteOrder {0} '{1}' ",
							operatorsForVoteOrder.SelectedValue, 
							VoteOrder.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<VoteReferral>.GetWhereKey("VoteReferral")] = writer.ToString();
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
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			ShortName.ID = "searchShortName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ShortName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForShortName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ShortName );
			Controls.Add( new LiteralControl("</td><tr>") );
			Url.ID = "searchUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Url</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Url );
			Controls.Add( new LiteralControl("</td><tr>") );
			ImageUrl.ID = "searchImageUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ImageUrl</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForImageUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ImageUrl );
			Controls.Add( new LiteralControl("</td><tr>") );
			Reward.ID = "searchReward";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Reward</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForReward ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Reward );
			Controls.Add( new LiteralControl("</td><tr>") );
			ClickCount.ID = "searchClickCount";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ClickCount</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForClickCount ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ClickCount );
			Controls.Add( new LiteralControl("</td><tr>") );
			VoteOrder.ID = "searchVoteOrder";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VoteOrder</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVoteOrder ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VoteOrder );
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
