<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "items";
		HttpContext.Current.Session["CurrentAction"] = "";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<p>
		Use this page to manage the webSite Items settings. You can online view the items and delete them. Add a new item is not suported.
	</p>
	<p/>
	<Admin:StateManager State="Items" runat="server" />
</asp:Content>