<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Specifikacije Jedinica
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API i Utilities</h2><ul><li><a href='/hr/API/Battle.aspx'>API bitke</a></li><li><a href='/hr/API/UniverseXML.aspx'>Svemir XML</a></li><li><a href='/hr/API/UnitsJSON.aspx'>Specifikacije Jedinica</a></li><li><a href='/hr/API/Utilities.aspx'>Utilities iz zajednice Orions Belta</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Specifikacije Jedinica</h1>
	<div class="content">
Specifikacije jedinica su dokumenti koji sadržavaju sve informacije o jedinici, za jednostavni programatski pristup.
Ovi dokumenti pružaju informacije o <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> kao što su:
napad, obrana, domet, bonus, itd.
Možete obraditi ove dokumente da stvorite dinamične web stranice i aplikacije koje rade sa ovim informacijama. Dobar primjer su borbeni kalkulatori ili game klijenti.

 <h2>Access</h2>
Možete pristupiti XML formatu dokumenta ovdje:

<pre><a href="http://resources.orionsbelt.eu/Scripts/Units.xml">http://resources.orionsbelt.eu/Scripts/Units.xml</a></pre><p />
    You can access a JSON format file here:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.js">http://resources.orionsbelt.eu/Scripts/Units.js</a></pre></div>
	
</asp:Content>