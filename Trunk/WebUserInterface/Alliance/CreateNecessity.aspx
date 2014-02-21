<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.CreateNecessity" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

     <div id='allianceCreateNecessity' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="CreateNecessity" runat="server"></OrionsBelt:Label></h2></div>
        <div class='center'>
            <table class="newtable">
                <tr>
                    <td><OrionsBelt:Label Key="Type" runat="server" /></td>
                    <td><asp:DropDownList ID="resources" CssClass="styled" runat="server" /></td>
                </tr>
                <tr>
                    <td><OrionsBelt:Label Key="Description" runat="server" /></td>
                    <td><asp:TextBox ID="description" TextMode="MultiLine" runat="server"/></td>
                </tr>
                <tr>
                    <td><OrionsBelt:Label Key="Coordinates" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="coordinates" runat="server"/>
                        <asp:RegularExpressionValidator ControlToValidate="coordinates" Display="Dynamic" 
                        ValidationExpression="^\d{1,2}:\d{1,2}:\d{1,2}:\d{1,2}" ID="validator" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class='bottom'><asp:Button ID="button" OnClick="Send" CssClass="button" runat="server" /></div>
    </div>
</asp:Content>
