<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.BoardPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div id='allianceBoardsPublic' class='mediumBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label4" Key="PublicBoard" runat="server" /></h2></div>
    <div class='center'>
        <Orionsbelt:Label ID="Label3" Key="PublicBoardInfo" runat="server" />
        <asp:TextBox ID="publicBoard" Width="420px" Height="400px" TextMode="MultiLine" runat="server" />
    </div>
    <div class='bottom'>
        <asp:Button ID="send" CssClass="button" runat="server" />
    </div>
</div>
<div id='allianceBoardsPrivate' class='mediumBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label5" Key="PrivateBoard" runat="server" /></h2></div>
    <div class='center'>
        <Orionsbelt:Label ID="Label2" Key="PrivateBoardInfo" runat="server" />
        <asp:TextBox ID="privateBoard" Width="420px" Height="400px" TextMode="MultiLine" runat="server" />
    </div>
    <div class='bottom'>
        <asp:Button ID="sendPrivate" CssClass="button" runat="server" />
    </div>
</div>
</asp:Content>
