<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="PrintInvoice.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.PrintInvoicePage" MasterPageFile="~/OrionsBeltMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<h3>PDM & FC - Projectos de Desenvolvimento Manutenção Formação e Consultadoria, Lda.</h3>
<h3>Av. Conde Valbom, nº 30, 3º Piso, 1050-068 Lisboa</h3>
<h3><OrionsBelt:Label Key="TaxNumber" runat="server" />: 502980826</h3>
<h3><OrionsBelt:Label Key="SocialCapital" runat="server" />: 100.000 €</h3>

    <table class="table">
        <OrionsBelt:InvoiceItem Source="QueryString" ID="invoice" runat="server">
        <tr>
            <td><OrionsBelt:Label Key="Number" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceIdentifier ID="InvoiceIdentifier1" runat="server" />            
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="Date" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceCreatedDate ID="InvoiceCreatedDate1" runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label Key="Product" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceCreditsGain runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label ID="Label3" Key="PayedValue" runat="server" /></td>
            <td>
	            <OrionsBelt:InvoiceMoney ID="InvoiceMoney1" runat="server" /> €
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label ID="Label4" Key="TaxValue" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceTaxMoney ID="InvoiceTaxMoney1" runat="server" />
	        </td>
	    </tr>
	    <tr>
            <td><OrionsBelt:Label ID="Label5" Key="ValueWithoutTax" runat="server" /></td>
            <td>
	            <OrionsBeltUI:InvoiceWithoutTaxMoney ID="InvoiceWithoutTaxMoney1" runat="server" />
	        </td>
	    </tr>    	
    	<tr>
    	    <td>
    	        <OrionsBelt:Label ID="Label6" Key="Country" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBeltUI:InvoiceCountryName ID="country" runat="server" />
	        </td>
        </tr>
        
        <tr>
    	    <td>
    	        <OrionsBelt:Label ID="Label7" Key="Name" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBelt:InvoiceName ID="InvoiceName1" runat="server" />
	        </td>
        </tr>
        
        <tr>
    	    <td>
    	        <OrionsBelt:Label ID="Label8" Key="Nif" runat="server" />
    	    </td>
    	    <td>
	            <OrionsBelt:InvoiceNif ID="nif" runat="server" />
	        </td>
        </tr>
                
	    </OrionsBelt:InvoiceItem>

	</table>
<p><asp:Literal ID="article" runat="server" /></p>	
<p><OrionsBelt:Label Key="ComputerProcessed" runat="server" /></p>	
	<script type="text/javascript">
	    window.print();
	</script>
	
</asp:Content>