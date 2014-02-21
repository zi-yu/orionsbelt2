<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Elo.aspx.cs" Inherits="OrionsBelt.WebUserInterface.Ladder" MasterPageFile="~/Tops/Tops.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PrincipalPagedList Where="LadderActive=True" OrderBy="LadderPosition" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBeltUI:PrincipalNumberPagination ItemsPerPage="50" ID="PrincipalNumberPagination1" runat="server" />
	<div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TopByLadder" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="PrincipalName" runat="server" /></th>
		        </tr>
		        <OrionsBelt:PrincipalItem runat="server">
		        <tr>
		            <td><OrionsBeltUI:LadderPosition runat="server" /></td>
		            <td><OrionsBeltUI:PrincipalLinkAndAvatar ID="PrincipalLinkAndAvatar1" runat="server" /></td>
		        </tr>
		        </OrionsBelt:PrincipalItem>
	        </table>
	        </div>
        <div class='bottom'></div>
    </div>
    <OrionsBeltUI:PrincipalNumberPagination ItemsPerPage="50" ID="PrincipalNumberPagination2" runat="server" />
    </OrionsBelt:PrincipalPagedList>
	         
    
</asp:Content>