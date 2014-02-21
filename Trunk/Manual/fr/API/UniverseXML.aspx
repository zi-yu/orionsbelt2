<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	XML de l'Univers
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API et Utilités</h2><ul><li><a href='/fr/API/Battle.aspx'>API de Combat</a></li><li><a href='/fr/API/UniverseXML.aspx'>XML de l'Univers</a></li><li><a href='/fr/API/UnitsJSON.aspx'>Spécifications des unités de combat</a></li><li><a href='/fr/API/Utilities.aspx'>Utilités créer par la communauté d'Orions's Belt</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>XML de l'Univers</h1>
	<div class="content">
    L'<u>Universe XML</u> est un fichier constamment mis à jour concernant les événements à travers L'univers. Il contient de l'information concernant les secteurs, les planètes, les escadrilles, la propriété des alliances, etc.
    Vous pouvez construire des cartes interactives représentant les zones appartenant à une alliance, les zones vides, etc.
    <p>
    Vous pouvez en connaître plus sur les dimensions de l'univers et le système de coordonnées à la page de <a href='/fr/Universe/Coordinates.aspx'>Coordonées</a>
    </p><h2>Access</h2>
    Vous pouvez accéder à ce fichier par ici :
    <pre><a href="http://s1.orionsbelt.eu/API/Universe.xml.zip">http://s1.orionsbelt.eu/API/Universe.xml.zip</a> (gziped)
    </pre></div>
	
</asp:Content>