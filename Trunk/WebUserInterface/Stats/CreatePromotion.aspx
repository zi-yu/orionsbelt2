<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePromotion.aspx.cs" Inherits="OrionsBelt.WebUserInterface.CreatePromotion" MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

<table class='table'>
<tr>
<th colspan='2'>
    <OrionsBelt:Label runat="server" Key="CreatePromotion">
    </OrionsBelt:Label>
</th>
</tr>
    <tr>
        <td><OrionsBelt:Label Key="Name" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="name" runat="server" />
            <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="name" Text="*" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label Key="Description" runat="server"/></td>
        <td>
            <asp:TextBox TextMode="Multiline" width="200px" ID="description" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label Key="Owner" runat="server"/></td>
        <td><OrionsBeltUI:ChooseOpponent SearchPrincipals="true" TitleToken="" id="finder" runat="server"/></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label Key="BeginDate" runat="server"/></td>
        <td>
            <OrionsBeltUI:DateTimeRender ID="begin" runat="server"/>
            <asp:CustomValidator Display="Dynamic" ID="beginEndDate" OnServerValidate="ValidateBeginEnd" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label1" Key="EndDate" runat="server"/></td>
        <td>
            <OrionsBeltUI:DateTimeRender ID="end" runat="server"/>
            <asp:CustomValidator Display="Dynamic" ID="endValidator" OnServerValidate="ValidateEndDate" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label2" Key="RevenueType" runat="server"/></td>
        <td><asp:DropDownList ID="revenueType" CssClass="styled" runat="server" /></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label3" Key="RevenueValue" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="revenueValue" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]+$" ControlToValidate="revenueValue" ID="revValidator" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label4" Key="PromotionType" runat="server"/></td>
        <td><asp:DropDownList ID="promotionType" CssClass="styled" runat="server" /></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label5" Key="BeginRange" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="beginRange" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]+$" ControlToValidate="beginRange" ID="beginValidator" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label6" Key="EndRange" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="endRange" runat="server" />            
            <asp:RegularExpressionValidator Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]+$" ControlToValidate="endRange" ID="endRValidator" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label9" Key="PromotionCode" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="promotionCode" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]+$" ControlToValidate="promotionCode" ID="codeValidator" runat="server" />
        </td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label7" Key="BonusType" runat="server"/></td>
        <td><asp:DropDownList ID="bonusType" CssClass="styled" runat="server" /></td>
    </tr>
    <tr>
        <td><OrionsBelt:Label ID="Label8" Key="BonusValue" runat="server"/></td>
        <td>
            <asp:TextBox width="200px" ID="bonusValue" runat="server" />
            <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="bonusValue" Text="*" runat="server" />
            <asp:RegularExpressionValidator Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]+$" ControlToValidate="bonusValue" ID="bonusNValidator" runat="server" />
        </td>
    </tr>
</table>
<div class="center">
    <asp:Button id="generate" OnClick="Generate" CssClass="button" runat="server" />
</div>
</asp:Content>

