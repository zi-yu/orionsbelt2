<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Utilities iz zajednice Orions Belta
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API i Utilities</h2><ul><li><a href='/hr/API/Battle.aspx'>API bitke</a></li><li><a href='/hr/API/UniverseXML.aspx'>Svemir XML</a></li><li><a href='/hr/API/UnitsJSON.aspx'>Specifikacije Jedinica</a></li><li><a href='/hr/API/Utilities.aspx'>Utilities iz zajednice Orions Belta</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Utilities iz zajednice Orions Belta</h1>
	<div class="content">
  <ul>
    <li>
      <a href="http://www.orionsbelt.eu/Tools/obcalc.html">Orionov Pojas Kalkulator</a> - online kalkulator (napravljen od Syriin)</li>
    <li>
      <a href="http://www.orionsbelt.eu/Tools/obrevcalc.html">Orioniv Pojas Obrnuti Kalkulator</a> - online obrnuti kalkulator bitki (napravljen od Syriin)</li>
    <li>
      <a href="http://forum.orionsbelt.eu/viewtopic.php?p=34133#34133">OBExplorer</a> - aplikacija gdje tražite informacije o flotama i planetama u svemiru; možete je downloadati 
<a href="http://www.orionsbelt.eu/Tools/OBExplorer.zip">ovdje</a> (napravljena of ikkie)</li>
    <li>
      <a href="http://www.alexandresemmer.net/googorions/">GoogOrion's</a> - Pretraga svemira (napravljena od Ashis)
</li>
  </ul>
</div>
	
</asp:Content>