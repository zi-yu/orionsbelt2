<%@ Page Language="C#" AutoEventWireup="false" Codebehind="AllianceInfo.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AllianceInfo"
    MasterPageFile="~/OrionsbeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1>
        <OrionsBelt:Label Key="AllianceInfo" runat="server" />
    </h1>
    <OrionsBeltUI:AllianceInfoReader ID="reader" runat="server" />

</asp:Content>
