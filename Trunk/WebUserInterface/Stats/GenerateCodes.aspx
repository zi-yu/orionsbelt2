<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateCodes.aspx.cs" Inherits="OrionsBelt.WebUserInterface.GenerateCodes" MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

<table class='table'>
<tr>
<th colspan='2'>
    <OrionsBelt:Label runat="server" Key="GenerateCodes">
    </OrionsBelt:Label>
</th>
</tr>
    <tr>
        <td><OrionsBelt:Label Key="Campaign" runat="server"/></td>
        <td><asp:TextBox width="200px" ID="code" runat="server" /></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label Key="Quantity" runat="server"/></td>
        <td><asp:TextBox width="200px" ID="quantity" runat="server" /></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label Key="Orions" runat="server"/></td>
        <td><asp:TextBox width="200px" ID="orions" runat="server" /></td>
    </tr>
    <tr>
        <td colspan='2'><asp:Literal ID="result" runat="server" /></td>
    </tr>
</table>
<div class="center">
    <asp:Button id="generate" OnClick="Generate" CssClass="button" runat="server" />
</div>
</asp:Content>

