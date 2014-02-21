<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Invoice.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.InvoicePage" MasterPageFile="~/Account/BuyOrions.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

    <table class="table">
        <OrionsBelt:InvoiceItem Source="QueryString" runat="server">
        <tr>
            <td><OrionsBelt:Label Key="Number" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceIdentifier runat="server" />            
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="Date" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceCreatedDate runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="Product" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceCreditsGain runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="PayedValue" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceMoney runat="server" /> €
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="TaxValue" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceTaxMoney runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="ValueWithoutTax" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceWithoutTaxMoney runat="server" />
	        </td>
	    </tr>
	    </OrionsBelt:InvoiceItem>
    	
    	<OrionsBelt:InvoiceEditor ID="InvoiceEditor1" Source="QueryString" runat="server">
    	<tr>
    	    <td>
    	        <OrionsBelt:Label ID="Label1" Key="Country" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBeltUI:CountryDropDownEditor runat="server" />
	        </td>
        </tr>
        
        <tr>
    	    <td>
    	        <OrionsBelt:Label Key="Name" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBeltUI:InvoicePlayerNameEditor runat="server" />
	        </td>
        </tr>
        
        <tr>
    	    <td>
    	        <OrionsBelt:Label Key="Nif" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBeltUI:InvoiceNIFEditor runat="server" />
	        </td>
        </tr>
        
        <OrionsBelt:UpdateButton CssClass="button" ID="updateButton" runat="server" />
        
	    </OrionsBelt:InvoiceEditor>

	</table>
	
	<asp:Button CssClass="button" ID="print" OnClientClick="printPage('PrintInvoice.aspx');" runat="server" />
	
</asp:Content>