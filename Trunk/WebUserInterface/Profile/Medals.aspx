<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.MedalsPage"
    MasterPageFile="~/Profile/PlayerProfile.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBeltUI:PlayerMedals ID="AddUserMedal1" runat="server" />
    <OrionsBeltUI:AddUserMedal runat="server" />
</asp:Content>
