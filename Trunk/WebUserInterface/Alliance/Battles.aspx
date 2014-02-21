<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.BattlesPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

 <div class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceBattlesPage" runat="server"></OrionsBelt:Label></h2></div>
    <div class='center'>
        <OrionsBelt:BattleNumberPagination ID="pagination" ItemsPerPage="20" runat="server" />
        <OrionsBeltUI:AllianceBattles ID="history" runat="server" />
    </div>
    <div class="bottom"></div>
</div>
    
</asp:Content>
