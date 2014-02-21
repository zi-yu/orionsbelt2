<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Spécifications des unités de combat
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API et Utilités</h2><ul><li><a href='/fr/API/Battle.aspx'>API de Combat</a></li><li><a href='/fr/API/UniverseXML.aspx'>XML de l'Univers</a></li><li><a href='/fr/API/UnitsJSON.aspx'>Spécifications des unités de combat</a></li><li><a href='/fr/API/Utilities.aspx'>Utilités créer par la communauté d'Orions's Belt</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Spécifications des unités de combat</h1>
	<div class="content">
    Les fichiers concernant les unités de combats donnent tous les détails à propos des unités
    pour un accès facile lors de programmation.
    Ces fichiers fournissent des informations à propos des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> tel que:
    l'attaque, la défense, la portée, les bonus contre certaines unités, etc.
    Vous pouvez utiliser ces fichiers pour créer des pages web dynamiques ou même un logiciel  
    fonctionnant à l'aide de ces informations. Un bon exemple serait des calculateurs de combat ou
    bien un "game client". 

    <h2>Access</h2>
    Vous pouvez accéder au fichier en format XML ici:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.xml">http://resources.orionsbelt.eu/Scripts/Units.xml</a></pre><p />
    Vous pouvez accéder au fichier en format JSON ici:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.js">http://resources.orionsbelt.eu/Scripts/Units.js</a></pre></div>
	
</asp:Content>