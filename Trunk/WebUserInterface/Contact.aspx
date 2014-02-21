<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/OrionsBeltMaster.Master"
    Inherits="OrionsBelt.WebUserInterface.ContactPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label ID="Label2" Key="ContactUs" runat="server" /></h1>
    <asp:Panel ID="messagePanel" runat="server"></asp:Panel>
    <div class="smallCenterPanel">
        <OrionsbeltUI:BoardHandler ID="BoardHandler1" runat="server" />
        
        <h2><OrionsBelt:Label ID="Label1" Key="Topic" runat="server" /></h2>
	    <asp:DropDownList ID="topics" CssClass="styled" runat="server" />
		
	    <h2><OrionsBelt:Label ID="Label3" Key="Message" runat="server" /></h2>
	    <asp:TextBox Height="300" ID="message" TextMode="MultiLine" CssClass="block mediumSize" runat="server" />
	    
	    <div class="center">
	        <asp:Button ID="send" CssClass="button" runat="server" />
	    </div>
    </div>
    
</asp:Content>
