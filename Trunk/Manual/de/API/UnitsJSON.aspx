<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Einheiten Spezifikationen
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API und Nützliches</h2><ul><li><a href='/de/API/Battle.aspx'>Kämpfe API</a></li><li><a href='/de/API/UniverseXML.aspx'>Universum XML</a></li><li><a href='/de/API/UnitsJSON.aspx'>Einheiten Spezifikationen</a></li><li><a href='/de/API/Utilities.aspx'>Nützliches von der Orion's Belt Gemeinde</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Einheiten Spezifikationen</h1>
	<div class="content">
    Die Spezifikationen der Einheiten sind Dokumente die detaillierte Information über die Einheiten 
    geben. Diese Dokumente liefern Informationen über <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> wie:
    Angriff, Verteidigung, Reichweite, Bonus, etc. 
    Du kannst diese Dokumente benutzen um dynamische Webseiten kreiren und Anwendungen die mit dieser 
    Information arbeiten. Ein gutes Beispiel sind der Schlacht-Rechner oder Spiel-Clients.
    
    <h2>Access</h2>
    Du kannst diese Information im XML format hier abrufen:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.xml">http://resources.orionsbelt.eu/Scripts/Units.xml</a></pre><p>
    Du kannst diese Information im XML format hier abrufen:
    </p><pre><a href="http://resources.orionsbelt.eu/Scripts/Units.js">http://resources.orionsbelt.eu/Scripts/Units.js</a></pre></div>
	
</asp:Content>