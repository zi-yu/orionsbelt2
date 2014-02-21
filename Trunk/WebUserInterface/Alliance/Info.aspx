<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Info" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBelt:AllianceStorageItem Source="Items" runat="server">
    
        <OrionsBeltUI:JoinAlliancePanel runat="server" />
    
        <div id='allianceInfo' class='mediumBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceInfoPageTitle" runat="server" /></h2></div>
            <div class='center'>
                <table class="newtable">
                    <tr>
                        <td><OrionsBelt:Label Key="AllianceName" runat="server" /></td>
                        <td><OrionsBelt:AllianceStorageName runat="server" /></td>
                    </tr>
                    <tr>
                        <td><OrionsBelt:Label Key="AllianceTag" runat="server" /></td>
                        <td><OrionsBelt:AllianceStorageTag runat="server" /></td>
                    </tr>
                    <tr>
                        <td><OrionsBelt:Label Key="AllianceDescription" runat="server" /></td>
                        <td><OrionsBelt:AllianceStorageDescription runat="server" /></td>
                    </tr>
                </table>
            </div>
            <div class="bottom"></div>
        </div>
        
        <OrionsBeltUI:AllianceBoard Type="Public" runat="server" />
        
        <div class="clear"></div>
        
        <div class='bigBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="AllianceMembers" runat="server" /></h2></div>
            <div class='center'>
                <OrionsBelt:AllianceStoragePlayers OrderBy="Name" ItemsPerPage="100" runat="server">
                    <table class="newtable">
                        <OrionsBelt:PlayerStorageItem runat="server">
                            <tr>
                                <td><OrionsBeltUI:PlayerStorageLinkAndAvatar runat="server" /></td>
                                <td><OrionsBelt:PlayerStorageAllianceRank runat="server" /></td>
                            </tr>
                        </OrionsBelt:PlayerStorageItem>
                    </table>
                </OrionsBelt:AllianceStoragePlayers>
            </div>
            <div class="bottom"></div>
        </div>
        
    </OrionsBelt:AllianceStorageItem>
    
    <OrionsBeltUI:AllianceInfoReader ID="reader" runat="server" />
    
</asp:Content>
