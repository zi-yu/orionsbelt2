<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Leave" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div id="allianceLeave" class='mediumBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceLeaveAlliance" runat="server"></OrionsBelt:Label></h2></div>
    <div class='bottom'>
        <asp:Button CssClass="button" ID="leaveAlliance" runat="server" />
    </div>
</div>
</asp:Content>
