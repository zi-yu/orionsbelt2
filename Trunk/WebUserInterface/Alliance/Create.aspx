<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Create" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <div id="allianceCreate" class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="CreateAlliancePageTitle" runat="server"></OrionsBelt:Label></h2></div>
        <OrionsBelt:AllianceStorageEditor ID="allianceStorageEditor" Source="New" runat="server">
        <div class='center'>
            <p><asp:Literal ID="information" runat="server" /></p>
                <dl>
                    <dt><OrionsBelt:Label Key="AllianceName" runat="server" /></dt>
                    <dd><OrionsBelt:AllianceStorageNameEditor runat="server" /></dd>
                    <dt><OrionsBelt:Label Key="AllianceTag" runat="server" /></dt>
                    <dd><OrionsBelt:AllianceStorageTagEditor runat="server" /></dd>
                    <dt><OrionsBelt:Label Key="AllianceDescription" runat="server" /></dt>
                    <dd><OrionsBelt:AllianceStorageDescriptionEditor IsMultiline="true" runat="server" /></dd>
                    <dt><OrionsBelt:Label ID="Label2" Key="Cost" runat="server" /></dt>
                    <dd><%= CreateAllianceCost %> <OrionsBelt:Label ID="Label1" Key="Orions" runat="server" /></dd>
                </dl>
        </div>
        <div class='bottom'>
            <OrionsBelt:UpdateButton CssClass="button" ID="updateButton" runat="server" />
        </div>
        </OrionsBelt:AllianceStorageEditor>
    </div>
    
    
</asp:Content>
