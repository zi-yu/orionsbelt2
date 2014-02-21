<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master"
    Inherits="OrionsBelt.WebUserInterface.Alliance.AssetEdit" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label ID="Label2" Key="EditAsset" runat="server" /></h1>
    <OrionsBelt:AssetEditor runat="server" Source="QueryString" >

        <table class="table">
            <tr>
                <td>
                    <OrionsBelt:Label ID="Label1" Key="Type" runat="server" />
                </td>
                <td>
                    <OrionsBeltUI:AssetTypeRender ID="AssetDescriptionEditor1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <OrionsBelt:Label Key="Description" runat="server" />
                </td>
                <td>
                    <OrionsBelt:AssetDescriptionEditor IsMultiline="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <OrionsBelt:Label Key="Coordinate" runat="server" />
                </td>
                <td>
                    <OrionsBelt:AssetCoordinateEditor runat="server" />
                </td>
            </tr>
        </table>
        <OrionsBelt:UpdateButton ID="update" CssClass="button" runat="server" />
    </OrionsBelt:AssetEditor>
</asp:Content>
