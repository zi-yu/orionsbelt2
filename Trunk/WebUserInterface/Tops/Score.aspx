<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Score.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Score" MasterPageFile="~/Tops/Tops.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PlayerStoragePagedList OrderBy="Score" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:PlayerStorageNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="TopByScore" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Player" runat="server" /></th>
		            <th><OrionsBelt:Label Key="WinsDefeats" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Score" runat="server" /></th>
		        </tr>
		        <OrionsBelt:PlayerStorageItem runat="server">
		        <tr>
		            <td><OrionsBeltUI:RankPosition runat="server" /></td>
		            <td><OrionsBeltUI:PlayerStorageLinkAndAvatar runat="server" /></td>
		            <td><OrionsBeltUI:WinsDefeats runat="server" /></td>
		            <td><OrionsBelt:PlayerStorageScore runat="server" /></td>
		        </tr>
		        </OrionsBelt:PlayerStorageItem>
	        </table>
        </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:PlayerStorageNumberPagination ItemsPerPage="50" ID="PlayerStorageNumberPagination1" runat="server" />
    </OrionsBelt:PlayerStoragePagedList>

</asp:Content>