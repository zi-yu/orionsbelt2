<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master"
    Inherits="OrionsBelt.WebUserInterface.Alliance.TaskView" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label Key="ViewTask" runat="server" /></h1>
    
    <OrionsBelt:TaskItem Source="QueryString" runat="server">
        <table class="table">
            <tr>
                <td><OrionsBelt:Label Key="Type" runat="server" /></td>
                <td><OrionsBeltUI:TaskTypeRender runat="server" /></td>
            </tr>
            <tr>
                <td><OrionsBelt:Label Key="Title" runat="server" /></td>
                <td><OrionsBelt:TaskTitle runat="server"/></td>
            </tr>
            <tr>
                <td><OrionsBelt:Label ID="Label2" Key="Priority" runat="server" /></td>
                <td><OrionsBeltUI:TaskPriorityRender runat="server" /></td>
            </tr>
            <tr>
                <td><OrionsBelt:Label ID="Label3" Key="Status" runat="server" /></td>
                <td><OrionsBeltUI:TaskStatusRender runat="server" /></td>
            </tr>
        </table>
    
    
        <h2><OrionsBelt:Label Key="Necessity" runat="server" /></h2>
    
        <table class="table">
            <tr>
                <td><OrionsBelt:Label ID="Label1" Key="Description" runat="server" /></td>
                <td><OrionsBeltUI:TaskDescriptionRender runat="server" /></td>
            </tr>
            <tr>
                <td><OrionsBelt:Label Key="Player" runat="server" /></td>
                <td><OrionsBeltUI:NecessityCreatorRender ID="TaskTitle1" runat="server"/></td>
            </tr>
            <tr>
                <td><OrionsBelt:Label Key="CreatedAt" runat="server" /></td>
                <td><OrionsBeltUI:TaskNecessityDateRender ID="TaskPriorityRender1" runat="server" /></td>
            </tr>
        </table>
        
    </OrionsBelt:TaskItem>
    
    <h2><OrionsBelt:Label ID="Label4" Key="Assets" runat="server" /></h2>
        <OrionsBelt:AssetPagedList ID="assets" ItemsPerPage="50" runat="server">
        
            <table class="table">
                <tr>
                    <th><OrionsBelt:AssetTypeSort ID="typeA" runat="server" /></th>
                    <th><OrionsBelt:Label ID="Label5" Key="Description" runat="server" /></th>
                    <th><OrionsBelt:AssetOwnerSort ID="owner" runat="server" /></th>
                    <th><OrionsBelt:AssetCoordinateSort ID="coordinateA" runat="server" /></th>
                    <th><OrionsBelt:AssetCreatedDateSort ID="dateA" runat="server" /></th>
                </tr>
                <OrionsBelt:AssetItem ID="NecessityItem1" runat="server">
                    <tr>
                        <td><OrionsBeltUI:AssetTypeRender ID="AssetTypeRender1" runat="server" /></td>
                        <td><OrionsBelt:AssetDescription ID="AssetDescription1"  runat="server" /></td>
                        <td><OrionsBeltUI:AssetPlayer ID="AssetPlayer1" runat="server" /></td>
                        <td><OrionsBelt:AssetCoordinate ID="AssetCoordinate1" runat="server" /></td>
                        <td><OrionsBeltUI:AssetCreatedAt ID="AssetCreatedAt1" runat="server" /></td>
                    </tr>
                </OrionsBelt:AssetItem>
            </table>
        </OrionsBelt:AssetPagedList>

    
</asp:Content>
