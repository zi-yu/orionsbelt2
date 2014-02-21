<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Universe XML
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API and Utilities</h2><ul><li><a href='/en/API/Battle.aspx'>Battle API</a></li><li><a href='/en/API/UniverseXML.aspx'>Universe XML</a></li><li><a href='/en/API/UnitsJSON.aspx'>Units Specification</a></li><li><a href='/en/API/Utilities.aspx'>Utilities from the Orion's Belt Community</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Universe XML</h1>
	<div class="content">
    The <u>Universe XML</u> is a XML file that's updated every day with the information of the universe: sectors, planets, fleets, alliance ownership etc.
    You can use this to build dynamic maps representing alliance zones, empty zones, etc.
    <p />
    You can know more about the universe size and coordinates system at the <a href='/en/Universe/Coordinates.aspx'>Coordinates</a> page.
    <h2>Access</h2>
    You can access this file via:
    <pre><a href="http://s1.orionsbelt.eu/API/Universe.xml.zip">http://s1.orionsbelt.eu/API/Universe.xml.zip</a> (gziped)
    </pre></div>
	
</asp:Content>