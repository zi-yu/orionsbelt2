<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Units Specification
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API and Utilities</h2><ul><li><a href='/en/API/Battle.aspx'>Battle API</a></li><li><a href='/en/API/UniverseXML.aspx'>Universe XML</a></li><li><a href='/en/API/UnitsJSON.aspx'>Units Specification</a></li><li><a href='/en/API/Utilities.aspx'>Utilities from the Orion's Belt Community</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Units Specification</h1>
	<div class="content">
    The units specifications are files that detail all the units information, for easy programmatic access.
    These files provide information on <a href='/en/UnitIndex.aspx'>Combat Units</a> such as:
    attack, defense, range, bonus, etc. 
    You can consume these files to create dynamic
    web pages and applications that work on that information. A good example are combat calculators or game clients.
    
    <h2>Access</h2>
    You can access a XML format file here:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.xml">http://resources.orionsbelt.eu/Scripts/Units.xml</a></pre><p />
    You can access a JSON format file here:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.js">http://resources.orionsbelt.eu/Scripts/Units.js</a></pre></div>
	
</asp:Content>