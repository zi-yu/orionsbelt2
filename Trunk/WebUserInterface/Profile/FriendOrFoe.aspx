<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.FriendOrFoePage"
    MasterPageFile="~/Profile/PlayerProfile.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
     <div id='friendsAndEnemies' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="FriendOrFoe" runat="server" /></h2></div>
        <div class='center'>
            <asp:Literal ID="content" runat="server" />
        </div>
        <div class='bottom'></div>
    </div>
</asp:Content>
