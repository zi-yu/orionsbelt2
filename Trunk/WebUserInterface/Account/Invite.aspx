<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.InvitePage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
<div id='inviteFriend' class='normalBorder'>
    <div class='top'><h2><OrionsBelt:Label Key="InviteAFriend" runat="server" /></h2></div>
    <div class='center'>
        <p></p><OrionsBelt:Label ID="Label5" Key="InviteAFriendIntro" runat="server" /></p>
        <div class="smallCenterPanel">
            <OrionsbeltUI:BoardHandler ID="BoardHandler1" runat="server" />
            
            <h2><OrionsBelt:Label ID="Label2" Key="InviteAFriendMail" runat="server" /></h2>
            <asp:TextBox ID="mail" CssClass="block mediumSize" runat="server" />
            
            <h2><OrionsBelt:Label ID="Label4" Key="InviteAFriendMessage" runat="server" /></h2>
            <asp:TextBox ID="message" TextMode="MultiLine" CssClass="block mediumSize" runat="server" />
        </div>

    </div>
    <div class='bottom'>
        <asp:Button ID="send" CssClass="button" runat="server" />
    </div>
</div>
    
    
    
    
   
    
</asp:Content>
