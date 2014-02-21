<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddToStorehouse.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AddToStorehouse"
    MasterPageFile="~/Alliance/Alliance.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <ul class="submenu">
        <li>
            <asp:Literal ID="link" runat="server" />
        </li>
    </ul>

    <div style="float:right;margin:10px 10px 0 0">
        <OrionsBeltUI:ResourcesViewer runat="server" />
    </div>
    
    
    <div id="allianceAddStoreHouse" class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="Deposit" runat="server"></OrionsBelt:Label></h2></div>
        <div class='center'>
            <table class="newtable">
                <tr>
                    <td>
                        <OrionsBelt:Label Key="Resource" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="resources" CssClass="styled" runat="server" />
                        <asp:Literal ID="condition" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <OrionsBelt:Label Key="Quantity" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="quantity" runat="server" />
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="quantity"
                        ID="quantityRequired" runat="server" />
                        <asp:RegularExpressionValidator ControlToValidate="quantity" Display="Dynamic" ID="quantityValidator"
                            ValidationExpression="^\d+" runat="server" />
                            <asp:CustomValidator ControlToValidate="quantity" Display="Dynamic" 
                            OnServerValidate="ValidateQuantity" ValidateEmptyText="false" ID="invalidQuantity" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><OrionsBelt:Label ID="Label1" Key="StorehouseRules" runat="server" /></td>
                </tr>
            </table>
        </div>
        <div class='bottom'>
            <asp:Button CausesValidation="true" CssClass="button" OnClick="Send" ID="send" runat="server" />
        </div>
    </div>
    
</asp:Content>
