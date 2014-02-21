<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Diplomacy" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:AllianceStoragePagedList ID="allianceDiplomacyList" ItemsPerPage="25" runat="server">
         <div class='bigBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceDiplomacyListTitle" runat="server"></OrionsBelt:Label></h2></div>
            <div class='center'>
                <table class="newtable">
                    <OrionsBelt:AllianceStorageItem runat="server">
                        <tr>
                            <td><OrionsBeltUI:AllianceLink ID="AllianceLink1" runat="server" /></td>
                            <td><OrionsBeltUI:AllianceDiplomacyLevelTranslated runat="server" /></td>
                            <OrionsBeltUI:AllianceManageDiplomacyLink ID="AllianceManageDiplomacyLink1" runat="server" />
                        </tr>
                    </OrionsBelt:AllianceStorageItem>
                </table>
            </div>
            <div class="bottom"></div>
        </div>
    </OrionsBelt:AllianceStoragePagedList>
    
    <OrionsBelt:AllianceStoragePagedList ID="allianceNeutralList" ItemsPerPage="25" runat="server">
        <div class='bigBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="AllianceDiplomacyNeutralTitle" runat="server"></OrionsBelt:Label></h2></div>
            <div class='center'>
                <table class="newtable">
                    <OrionsBelt:AllianceStorageItem runat="server">
                        <tr>
                            <td><OrionsBeltUI:AllianceLink runat="server" /></td>
                            <OrionsBeltUI:AllianceManageDiplomacyLink runat="server" />
                        </tr>
                    </OrionsBelt:AllianceStorageItem>
                </table>
            </div>
            <div class="bottom"></div>
        </div>
    </OrionsBelt:AllianceStoragePagedList>
    
</asp:Content>
