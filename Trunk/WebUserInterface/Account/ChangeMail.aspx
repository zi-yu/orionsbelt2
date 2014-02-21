<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.ChangeMailPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<OrionsBelt:PrincipalEditor ID="PrincipalEditor1" Source="contextuser" runat="server">
    <div id='changeEmail' class='smallBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="PersonalSettings" runat="server" /></h2></div>
        <div class='center'>
            <dl>
                <dt><OrionsBelt:Label ID="Label1" Key="Email" runat="server" /></dt>
                <dd><OrionsBelt:PrincipalEmailEditor runat="server" /></dd>
                <dt><OrionsBelt:Label ID="Label4" Key="WebSite" runat="server" /></dt>    
                <dd><OrionsBelt:PrincipalWebSiteEditor ID="PrincipalEmailEditor1" runat="server" /></dd>
            </dl>
            <div class="clear">
                <OrionsBelt:PrincipalLadderActiveEditor ID="PrincipalLadderActiveEditor1" runat="server" /><OrionsBelt:Label ID="Label2" Key="LadderActive" runat="server" />
            </div>
        </div>
        <div class='bottom'>
            <OrionsBelt:UpdateButton CssClass="button" runat="server" />
        </div>
    </div>
</OrionsBelt:PrincipalEditor>
    <OrionsBeltUI:ChooseAvatar runat="server" />
    <div class="clear"></div>
</asp:Content>
