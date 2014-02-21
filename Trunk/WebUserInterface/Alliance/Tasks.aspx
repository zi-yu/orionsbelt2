<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Tasks" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div id='allianceNecessities' class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Necessities" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBelt:NecessityPagedList ID="necessities" ItemsPerPage="50" runat="server">
    
        <table class="newtable">
            <tr>
                <th width='75px'><OrionsBelt:NecessityTypeSort ID="typeN" runat="server" /></th>
                <th><OrionsBelt:Label Key="Description" runat="server" /></th>
                <th width='145px'><OrionsBelt:NecessityCreatorSort ID="creator" runat="server" /></th>
                <th><OrionsBelt:NecessityCoordinateSort ID="coordinateN" runat="server" /></th>
                <th width='145px'><OrionsBelt:NecessityCreatedDateSort ID="dateN" runat="server" /></th>
                <th width='50px'><OrionsBelt:Label Key="Manage" runat="server" /></th>
            </tr>
            <OrionsBelt:NecessityItem ID="AllianceStorageItem1" runat="server">
                <tr>
                    <td><OrionsBeltUI:NecessityTypeRender runat="server" /></td>
                    <td><OrionsBelt:NecessityDescription runat="server" /></td>
                    <td><OrionsBeltUI:NecessityPlayer runat="server" /></td>
                    <td><OrionsBelt:NecessityCoordinate runat="server" /></td>
                    <td><OrionsBeltUI:NecessityCreatedAt runat="server" /></td>
                    <td><OrionsBeltUI:NecessityManage runat="server" /></td>
                </tr>
            </OrionsBelt:NecessityItem>
        </table>
    
    </OrionsBelt:NecessityPagedList>
    </div>
    <div class='bottom'>
        <div class='button'><a href="CreateNecessity.aspx"><OrionsBelt:Label Key="Create" runat="server" /></a></div>
    </div>
</div>
<div id='allianceAssets' class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="Assets" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBelt:AssetPagedList ID="assets" ItemsPerPage="50" runat="server">
        <table class="newtable">
            <tr>
                <th width='75px><OrionsBelt:AssetTypeSort ID="typeA" runat="server" /></th>
                <th><OrionsBelt:Label Key="Description" runat="server" /></th>
                <th width='145px'><OrionsBelt:AssetOwnerSort ID="owner" runat="server" /></th>
                <th><OrionsBelt:AssetCoordinateSort ID="coordinateA" runat="server" /></th>
                <th width='145px'><OrionsBelt:AssetCreatedDateSort ID="dateA" runat="server" /></th>
                <th width='50px'><OrionsBelt:Label Key="Manage" runat="server" /></th>
            </tr>
            <OrionsBelt:AssetItem ID="NecessityItem1" runat="server">
                <tr>
                    <td><OrionsBeltUI:AssetTypeRender ID="NecessityType1" runat="server" /></td>
                    <td><OrionsBelt:AssetDescription ID="NecessityDescription1" runat="server" /></td>
                    <td><OrionsBeltUI:AssetPlayer ID="NecessityCreator1" runat="server" /></td>
                    <td><OrionsBelt:AssetCoordinate ID="NecessityCoordinate1" runat="server" /></td>
                    <td><OrionsBeltUI:AssetCreatedAt ID="NecessityCreatedAt1" runat="server" /></td>
                    <td><OrionsBeltUI:AssetManage ID="NecessityManage1" runat="server" /></td>
                </tr>
            </OrionsBelt:AssetItem>
        </table>
    </OrionsBelt:AssetPagedList>
    </div>
    <div class='bottom'>
        <div class='button'><a href="CreateAsset.aspx"><OrionsBelt:Label ID="Label3" Key="Create" runat="server" /></a></div>
    </div>
</div>
<div id='allianceTasks' class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label Key="Tasks" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBeltUI:TasksBoard ID="board" runat="server"/>
    </div>
     <div class='bottom'>
        <asp:Literal ID="taskLink" runat="server" />
    </div>
</div>
</asp:Content>
