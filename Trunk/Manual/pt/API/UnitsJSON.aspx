<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Especificação das Unidades
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API e Utilitários</h2><ul><li><a href='/pt/API/Battle.aspx'>API das Batalhas</a></li><li><a href='/pt/API/UniverseXML.aspx'>XML do Universo</a></li><li><a href='/pt/API/UnitsJSON.aspx'>Especificação das Unidades</a></li><li><a href='/pt/API/Utilities.aspx'>Utilitários feitos pela Comunidade</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Especificação das Unidades</h1>
	<div class="content">
    O jogo disponibiliza um conjunto de ficheiros com a especificação das <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> que conteém:
    ataque, defesa, alcance, bónus, etc.
    Podes consumir esta informação para criar páginas dinamicas ou aplicações. Um bom exemplo são calculadoras de batalha.
    <h2>Acesso</h2>
    Podes aceder a esta informação em formato XML através do URL:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.xml">http://resources.orionsbelt.eu/Scripts/Units.xml</a></pre><p />
    Podes aceder a esta informação em formato JSON através do URL:
    <pre><a href="http://resources.orionsbelt.eu/Scripts/Units.js">http://resources.orionsbelt.eu/Scripts/Units.js</a></pre></div>
	
</asp:Content>