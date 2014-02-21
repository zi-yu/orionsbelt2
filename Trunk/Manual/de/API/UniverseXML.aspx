<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Universum XML
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API und Nützliches</h2><ul><li><a href='/de/API/Battle.aspx'>Kämpfe API</a></li><li><a href='/de/API/UniverseXML.aspx'>Universum XML</a></li><li><a href='/de/API/UnitsJSON.aspx'>Einheiten Spezifikationen</a></li><li><a href='/de/API/Utilities.aspx'>Nützliches von der Orion's Belt Gemeinde</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Universum XML</h1>
	<div class="content">
    Das <u>Universum XML</u> ist ein XML Dokument das jeden Tag aktualisiert wird mit der Information 
    des Universums: Sektoren, Planeten, Flotten, Allianz Eigentum etc.
    Du kannst dies benutzen um dynamische Karten zu erstellen die Allianz Zonen, leere Zonen 
    darstellen, etc.
    <p>
    Du kannst mehr über die Grösse des Universums und das Koordinaten-System erfahren auf der 
    <a href='/de/Universe/Coordinates.aspx'>Koordinaten</a> Seite.
    </p><h2>Access</h2>
    You can access this file via:
    <pre><a href="http://s1.orionsbelt.eu/API/Universe.xml.zip">http://s1.orionsbelt.eu/API/Universe.xml.zip</a> (gziped)
    </pre></div>
	
</asp:Content>