<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Storehouse" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<ul class="submenu">
    <li>
        <asp:Literal ID="link" runat="server" />
    </li>
</ul>

<OrionsBelt:OfferingPagedList ItemsPerPage="25" ID="paged" runat="server" >
    <OrionsBelt:OfferingNumberPagination ItemsPerPage="25" ID="pagination" runat="server" />
    
    <div id="allianceAddStoreHouse" class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Deposit" runat="server"></OrionsBelt:Label></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Donor" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Members" runat="server" /></th>  
		            <th><OrionsBelt:Label Key="Donate" runat="server" /></th> 
		        </tr>
		        <OrionsBelt:OfferingItem ID="OfferingItem1" runat="server">
		        <tr>
		            <td><OrionsBelt:OfferingCurrentValue ID="OfferingQuantity1" runat="server" /></td>
		            <td><OrionsBeltUI:SHProductName ID="AHProductName1" runat="server" /></td>
		            <td><OrionsBeltUI:SHDonor runat="server" /></td>
		            <td><OrionsBeltUI:MembersControl browserID="members" ID="members" runat="server" /></td>
		            <td><OrionsBeltUI:Donate runat="server" /></td>
		        </tr>
		        </OrionsBelt:OfferingItem>
	        </table>
	    </div>
	    <div class='bottom'></div>
    </div>
    </OrionsBelt:OfferingPagedList>

</asp:Content>
