<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.ChangePasswordPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <div id='inviteFriend' class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="ChangePassword" runat="server" /></h2></div>
        <div class='center'>
            <dl>
                <dt><OrionsBelt:Label ID="Label6" Key="CurrentPassword" runat="server" /></dt>
                <dd> <asp:TextBox ID="current" TextMode="Password" CssClass="block mediumSize" runat="server" /></dd>
                <dt><OrionsBelt:Label ID="Label7" Key="NewPassword" runat="server" /></dt>    
                <dd><asp:TextBox ID="newPassword" TextMode="Password" CssClass="block mediumSize" runat="server" /></dd>
                <dt><OrionsBelt:Label ID="Label5" Key="NewPasswordConfirmation" runat="server" /></dt>    
                <dd><asp:TextBox ID="newPasswordConf" TextMode="Password" CssClass="block mediumSize" runat="server" /></dd>
            </dl>
        </div>
        <div class='bottom'>
            <asp:Button ID="send" CssClass="button" runat="server" />
        </div>
    </div>


    
</asp:Content>
