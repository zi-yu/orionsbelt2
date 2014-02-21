<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Utilitários feitos pela Comunidade
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API e Utilitários</h2><ul><li><a href='/pt/API/Battle.aspx'>API das Batalhas</a></li><li><a href='/pt/API/UniverseXML.aspx'>XML do Universo</a></li><li><a href='/pt/API/UnitsJSON.aspx'>Especificação das Unidades</a></li><li><a href='/pt/API/Utilities.aspx'>Utilitários feitos pela Comunidade</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Utilitários feitos pela Comunidade</h1>
	<ul>
  <li>
    <a href="http://www.orionsbelt.eu/Tools/obcalc.html">Calculadora Orion's Belt</a> - uma calculadora de batalha online (feita por Syriin)
    </li>
  <li>
    <a href="http://www.orionsbelt.eu/Tools/obrevcalc.html">Calculadora Reversa Orion's Belt</a> - uma calculadora de batalha reversa online (feita por Syriin)
    </li>
  <li>
    <a href="http://forum.orionsbelt.eu/viewtopic.php?p=34133#34133">OBExplorer</a> - Uma aplicação que te permite fazer pesquisas sobre
  armadas e planetas no universo; podes fazer download 
  <a href="http://www.orionsbelt.eu/Tools/OBExplorer.zip">aqui</a> (feita pelo ikkie)
    </li>
  <li>
    <a href="http://www.alexandresemmer.net/googorions/">GoogOrion's</a> - Pesquisa no pontos no universo (feita pelo Ashis)
  </li>
</ul>
	
</asp:Content>