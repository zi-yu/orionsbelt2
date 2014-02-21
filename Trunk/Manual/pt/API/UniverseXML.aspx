<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	XML do Universo
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API e Utilitários</h2><ul><li><a href='/pt/API/Battle.aspx'>API das Batalhas</a></li><li><a href='/pt/API/UniverseXML.aspx'>XML do Universo</a></li><li><a href='/pt/API/UnitsJSON.aspx'>Especificação das Unidades</a></li><li><a href='/pt/API/Utilities.aspx'>Utilitários feitos pela Comunidade</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>XML do Universo</h1>
	<div class="content">
    O <u>XML do Universo</u> é um ficheiro XML que é actualizado diariamente com informação sobre o universo: sectores, planets, armadas, alianças, etc.
    Podes usar esta informação para construir páginas dinamicas que mostram zonas por aliança, zonas vazias, etc.
    <p />
    Podes saber mais sobre o tamanho do universo e o sistema de coordenadas na página de <a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a>.
    <h2>Acesso</h2>
    Podes aceder a este ficheiro via:
    <pre><a href="http://s1.orionsbelt.eu/API/Universe.xml.zip">http://s1.orionsbelt.eu/API/Universe.xml.zip</a> (gziped)
    </pre></div>
	
</asp:Content>