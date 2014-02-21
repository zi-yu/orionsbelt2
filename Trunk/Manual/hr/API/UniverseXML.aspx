<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Svemir XML
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API i Utilities</h2><ul><li><a href='/hr/API/Battle.aspx'>API bitke</a></li><li><a href='/hr/API/UniverseXML.aspx'>Svemir XML</a></li><li><a href='/hr/API/UnitsJSON.aspx'>Specifikacije Jedinica</a></li><li><a href='/hr/API/Utilities.aspx'>Utilities iz zajednice Orions Belta</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Svemir XML</h1>
	<div class="content">
  <u>Universe XML</u> je XML dokument koji je updatean svaki dan s informacijama o svemiru : sektori, planete, vlasništvo saveza itd.
Možete se poslužiti s ovim da gradite dinamične mape koje predstavljaju zone saveza, prazne zone, itd.
 <p />
Možete više saznati o veličini svemira i koordinatama na <a href='/hr/Universe/Coordinates.aspx'>Koordinate</a> stranici.
  <h2>Access</h2>
Možete pristupiti ovom dokumentu sljedećim linkom:
<pre><a href="http://s1.orionsbelt.eu/API/Universe.xml.zip">http://s1.orionsbelt.eu/API/Universe.xml.zip</a> (gziped)
    </pre></div>
	
</asp:Content>