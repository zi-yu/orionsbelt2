<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.CreateTask" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <div id='allianceCreateTask' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="CreateTask" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
                <tr>
                    <td><OrionsBelt:Label Key="Title" runat="server" /></td>
                    <td><asp:TextBox ID="title" runat="server"/></td>
                </tr>
                <tr>
                    <td><OrionsBelt:Label Key="Priority" runat="server" /></td>
                    <td><asp:DropDownList ID="priority" CssClass="styled" runat="server" /></td>
                </tr>
            </table>
        </div>
        <div class="bottom"><OrionsBelt:Label ID="Label4" Key="SelectElems" runat="server" /></div>
    </div>
    <div id='allianceCreateTaskNecessity' class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label6" Key="Necessities" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBelt:NecessityPagedList ID="necessities" ItemsPerPage="50" runat="server">
                <table class="newtable">
                    <tr>
                        <th/>
                        <th><OrionsBelt:NecessityTypeSort ID="typeN" runat="server" /></th>
                        <th><OrionsBelt:Label ID="Label2" Key="Description" runat="server" /></th>
                        <th><OrionsBelt:NecessityCreatorSort ID="creator" runat="server" /></th>
                        <th><OrionsBelt:NecessityCoordinateSort ID="coordinateN" runat="server" /></th>
                        <th><OrionsBelt:NecessityCreatedDateSort ID="dateN" runat="server" /></th>
                    </tr>
                    <OrionsBelt:NecessityItem ID="AllianceStorageItem1" runat="server">
                        <tr>
                            <td><OrionsBeltUI:NecessitySelect runat="server" /></td>
                            <td><OrionsBeltUI:NecessityTypeRender runat="server" /></td>
                            <td><OrionsBelt:NecessityDescription runat="server" /></td>
                            <td><OrionsBeltUI:NecessityPlayer runat="server" /></td>
                            <td><OrionsBelt:NecessityCoordinate runat="server" /></td>
                            <td><OrionsBeltUI:NecessityCreatedAt runat="server" /></td>
                        </tr>
                    </OrionsBelt:NecessityItem>
                </table>
            </OrionsBelt:NecessityPagedList>
        </div>
        <div class="bottom"></div>
    </div>
    
    <div id='allianceCreateTaskAsset' class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Assets" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBelt:AssetPagedList ID="assets" ItemsPerPage="50" runat="server">
                <table class="newtable">
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
                            <td><OrionsBeltUI:AssetSelect runat="server" /></td>
                            <td><OrionsBeltUI:AssetTypeRender runat="server" /></td>
                            <td><OrionsBelt:AssetDescription  runat="server" /></td>
                            <td><OrionsBeltUI:AssetPlayer runat="server" /></td>
                            <td><OrionsBelt:AssetCoordinate runat="server" /></td>
                            <td><OrionsBeltUI:AssetCreatedAt runat="server" /></td>
                        </tr>
                    </OrionsBelt:AssetItem>
                </table>
            </OrionsBelt:AssetPagedList>
        </div>
        <div class="bottom"></div>
    </div>
    <div class="center clear" style="padding-top:20px;">
        <asp:Button ID="button" OnClick="Send" CssClass="button" runat="server" />
    </div>
</asp:Content>
