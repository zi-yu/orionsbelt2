<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Advertising.ascx.cs"
    Inherits="OrionsBelt.WebUserInterface.Controls.Advertising" %>
<table class='table' id="ahAd">
    <tr<%= FirstTrStyle %>>
        <th>
            <OrionsBelt:Label Key="Quantity" runat="server" />
        </th>
        <th>
            <OrionsBelt:Label Key="Description" runat="server" />
        </th>
        <th>
            <OrionsBelt:Label Key="NextBid" runat="server" />
        </th>
        <th>
            <OrionsBelt:Label Key="Buyout" runat="server" />
        </th>
    </tr>
</table>

<asp:Literal ID="jason" runat="server" />