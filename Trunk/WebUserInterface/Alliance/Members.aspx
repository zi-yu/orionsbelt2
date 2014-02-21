<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Members" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBelt:AllianceStorageItem Source="Items" runat="server">
        <div class='bigBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceMembers" runat="server"></OrionsBelt:Label></h2></div>
            <div class='center'>
                <OrionsBelt:AllianceStoragePlayers ItemsPerPage="100"  runat="server">
                <table class="newtable">
                    <OrionsBelt:PlayerStorageItem runat="server">
                        <tr>
                            <td><OrionsBeltUI:PlayerStorageLinkAndAvatar runat="server" /></td>
                            <td><OrionsBeltUI:PlayerStorageRace runat="server" /></td>
                            <td><OrionsBelt:PlayerStorageAllianceRank runat="server" /></td>
                            <td style='width:180px;'><OrionsBeltUI:AllianceManagePlayerLink runat="server" /></td>
                        </tr>
                    </OrionsBelt:PlayerStorageItem>
                </table>
                </OrionsBelt:AllianceStoragePlayers>
            </div>
            <div class='bottom'></div>
        </div>
    </OrionsBelt:AllianceStorageItem>
    
</asp:Content>
