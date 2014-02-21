<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="GroupBattles.aspx.cs" Inherits="OrionsBelt.WebUserInterface.GroupBattles" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBeltUI:GroupRender runat="server" />
    <asp:Literal ID="containe" runat="server" />
</asp:Content>