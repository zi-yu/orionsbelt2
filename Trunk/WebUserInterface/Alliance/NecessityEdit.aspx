<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master"
    Inherits="OrionsBelt.WebUserInterface.Alliance.NecessityEdit" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label Key="EditNecessity" runat="server" /></h1>
    <OrionsBelt:NecessityEditor runat="server" Source="QueryString" >

        <table class="table">
            <tr>
                <td>
                    <OrionsBelt:Label ID="Label1" Key="Type" runat="server" />
                </td>
                <td>
                    <OrionsBeltUI:NecessityTypeRender ID="AssetDescriptionEditor1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <OrionsBelt:Label Key="Description" runat="server" />
                </td>
                <td>
                    <OrionsBelt:NecessityDescriptionEditor IsMultiline="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <OrionsBelt:Label Key="Coordinate" runat="server" />
                </td>
                <td>
                    <OrionsBelt:NecessityCoordinateEditor runat="server" />
                </td>
            </tr>
        </table>
        <OrionsBelt:UpdateButton ID="update" CssClass="button" runat="server" />
    </OrionsBelt:NecessityEditor>
</asp:Content>
