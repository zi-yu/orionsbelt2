<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Amistoso
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batallas</h2><ul><li><a href='/es/Battles/Tournaments.aspx'>Torneos</a></li><li><a href='/es/Battles/Ladder.aspx'>Escala</a></li><li><a href='/es/Battles/Friendly.aspx'>Amistoso</a></li><li><a href='/es/Battles/ELO.aspx'>Clasificación ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Amistoso</h1>
	<div class="content">
 Los <a href='/es/Battles/Friendly.aspx'>Amistoso</a> son combates en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a> que puedes hacer sólo por diversión o para practicar. Puedes escojer la <a href='/es/Universe/Fleet.aspx'>Flota</a> de la  batalla y tu oponente.
 Estas batallas no son tomadas en cuentas para tu <a href='/es/Battles/ELO.aspx'>Clasificación ELO</a>.
    <p />
 Puedes usar estas batallas para probar nuevas <a href='/es/Battles/BattleTactics.aspx'>Tácticas de Batalla</a>, conocer mejor algunas <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> o para practicar para <a href='/es/Battles/Tournaments.aspx'>Torneos</a>.
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>