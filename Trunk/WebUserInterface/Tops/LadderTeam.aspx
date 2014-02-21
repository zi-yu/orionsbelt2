<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Elo.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Ladder" MasterPageFile="~/Tops/Tops.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
	<OrionsBelt:TeamStoragePagedList Where="LadderActive=True and IsComplete=True" OrderBy="LadderPosition" ItemsPerPage="50" runat="server" >
	<OrionsBelt:TeamStorageNumberPagination ItemsPerPage="50" runat="server" />
	<div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label  Key="TopByLadderTeam" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="TeamName" runat="server" /></th>
		        </tr>
		        <OrionsBelt:TeamStorageItem ID="TeamStorageItem1" runat="server">
		        <tr>
		            <td><OrionsBeltUI:TeamPosition runat="server" /></td>
		            <td><OrionsBelt:TeamStorageName runat="server" /></td>
		        </tr>
		        </OrionsBelt:TeamStorageItem>
	        </table>
	    </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:TeamStorageNumberPagination ID="TeamStorageNumberPagination1" ItemsPerPage="50" runat="server" />
	</OrionsBelt:TeamStoragePagedList>

</asp:Content>