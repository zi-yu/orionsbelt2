<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Join" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBelt:AllianceStorageItem ID="AllianceStorageItem1" Source="Items" runat="server">
    
    <div id="allianceLeave" class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceJoinAllinaceLink" runat="server"></OrionsBelt:Label></h2></div>
        <div class='center'>
            <OrionsBelt:Label ID="alreadyAllianceMember" Key="AlreadyAllianceMember" runat="server" />
            <OrionsBelt:Label ID="allianceJoinRequested" Key="AllianceJoinRequested" runat="server" />
        </div>
        <div class='bottom'>
            <asp:Button CssClass="button" ID="joinAlliance" runat="server" />
        </div>
    </div>    
    </OrionsBelt:AllianceStorageItem>
    
</asp:Content>
