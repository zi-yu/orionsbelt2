<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Professions.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Professions" MasterPageFile="~/Tops/Tops.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PlayerStoragePagedList ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:PlayerStorageNumberPagination ItemsPerPage="50" ID="PlayerStorageNumberPagination1" runat="server" />
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TopByProfessions" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		            <asp:Literal ID="header" runat="server" />
		        </tr>
        		
		        <OrionsBelt:PlayerStorageItem runat="server">
		        <tr>
		            <td><OrionsBeltUI:RankPosition runat="server" /></td>
		            <td><OrionsBeltUI:PlayerStorageLinkAndAvatar ID="PlayerStorageLinkAndAvatar1" runat="server" /></td>
		            <td><OrionsBelt:PlayerStoragePirateRanking runat="server" /></td>
		            <td><OrionsBelt:PlayerStorageBountyRanking runat="server" /></td>
		            <td><OrionsBelt:PlayerStorageMerchantRanking runat="server" /></td>
		            <td><OrionsBelt:PlayerStorageColonizerRanking runat="server" /></td>
		            <td><OrionsBelt:PlayerStorageGladiatorRanking runat="server" /></td>
		        </tr>
		        </OrionsBelt:PlayerStorageItem>
	        </table>
	        <div class='bottom'></div>
        </div>
    <OrionsBelt:PlayerStorageNumberPagination ItemsPerPage="50" ID="PlayerStorageNumberPagination2" runat="server" />
    </OrionsBelt:PlayerStoragePagedList>

</asp:Content>