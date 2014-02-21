<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master"
    Inherits="OrionsBelt.WebUserInterface.Alliance.TaskEdit" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label Key="EditTask" runat="server" /></h1>
    
    <table class="table">
        <tr>
            <td><OrionsBelt:Label ID="Label6" Key="Type" runat="server" /></td>
            <td><asp:Literal ID="typeNec" runat="server" /></td>
        </tr>
        <tr>
            <td><OrionsBelt:Label ID="Label1" Key="Title" runat="server" /></td>
            <td><asp:TextBox ID="title" runat="server"/></td>
        </tr>
        <tr>
            <td><OrionsBelt:Label ID="Label2" Key="Priority" runat="server" /></td>
            <td><asp:DropDownList ID="priority" CssClass="styled" runat="server" /></td>
        </tr>
        <tr>
            <td><OrionsBelt:Label ID="Label3" Key="Status" runat="server" /></td>
            <td><asp:DropDownList ID="status" CssClass="styled" runat="server" /></td>
        </tr>
    </table>
    
    <h2><OrionsBelt:Label ID="Label4" Key="Assets" runat="server" /></h2>
        <OrionsBelt:AssetPagedList ID="assets" ItemsPerPage="50" runat="server">
        
            <table class="table">
                <tr>
                    <th/>
                    <th><OrionsBelt:AssetTypeSort ID="typeA" runat="server" /></th>
                    <th><OrionsBelt:Label ID="Label5" Key="Description" runat="server" /></th>
                    <th><OrionsBelt:AssetOwnerSort ID="owner" runat="server" /></th>
                    <th><OrionsBelt:AssetCoordinateSort ID="coordinateA" runat="server" /></th>
                    <th><OrionsBelt:AssetCreatedDateSort ID="dateA" runat="server" /></th>
                </tr>
                <OrionsBelt:AssetItem ID="NecessityItem1" runat="server">
                    <tr>
                        <td><OrionsBeltUI:AssetSelected ID="AssetSelect1" runat="server" /></td>
                        <td><OrionsBeltUI:AssetTypeRender ID="AssetTypeRender1" runat="server" /></td>
                        <td><OrionsBelt:AssetDescription ID="AssetDescription1"  runat="server" /></td>
                        <td><OrionsBeltUI:AssetPlayer ID="AssetPlayer1" runat="server" /></td>
                        <td><OrionsBelt:AssetCoordinate ID="AssetCoordinate1" runat="server" /></td>
                        <td><OrionsBeltUI:AssetCreatedAt ID="AssetCreatedAt1" runat="server" /></td>
                    </tr>
                </OrionsBelt:AssetItem>
            </table>
        </OrionsBelt:AssetPagedList>
    
    <table class="table">
        <tr>
            <td style="vertical-align:middle; height:40px; " colspan="2"><asp:Button ID="update" OnClick="Send" CssClass="button" runat="server" /></td>
        </tr>
    </table>

    
</asp:Content>
