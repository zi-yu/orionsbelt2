<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="PaymentHistory.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.PaymentHistory" MasterPageFile="~/Account/BuyOrions.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

    <div id='paymentHistory' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="PaymentHistory" runat="server" /></h2></div>
        <div class='center'>
             <OrionsBelt:PaymentPagedList OrderBy="UpdatedDate" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
                <OrionsBelt:PaymentNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
                <table class='newtable'>
		            <tr>
		                <th><OrionsBelt:Label Key="Method" runat="server" /></th>
		                <th><OrionsBelt:Label Key="State" runat="server" /></th>
		                <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		                <th><OrionsBelt:Label Key="Date" runat="server" /></th>
		            </tr>
		            <OrionsBelt:PaymentItem runat="server">
		                <tr>
		                    <td><OrionsBelt:PaymentMethod runat="server" /></td>
		                    <td><OrionsBeltUI:StateRender runat="server" /></td>
		                    <td><OrionsBelt:PaymentAmmount runat="server" /></td>
		                    <td><OrionsBeltUI:PaymentDate runat="server" /></td>
		                </tr>
		            </OrionsBelt:PaymentItem>
	            </table>
            </OrionsBelt:PaymentPagedList>
        </div>
        <div class='bottom'></div>
    </div><div 

	<h2><OrionsBelt:Label Key="" runat="server" /></h2>
   
	
</asp:Content>