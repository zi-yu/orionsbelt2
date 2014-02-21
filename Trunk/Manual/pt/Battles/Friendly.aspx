<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Amigáveis
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batalhas</h2><ul><li><a href='/pt/Battles/Tournaments.aspx'>Torneios</a></li><li><a href='/pt/Battles/Ladder.aspx'>Escada</a></li><li><a href='/pt/Battles/Friendly.aspx'>Amigáveis</a></li><li><a href='/pt/Battles/ELO.aspx'>Classificação ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Amigáveis</h1>
	<div class="content">
    Os <a href='/pt/Battles/Friendly.aspx'>Amigáveis</a> são combates no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a> que podes fazer só por divertimento ou para praticar. Podes escolher a <a href='/pt/Universe/Fleet.aspx'>Armada</a> da batalha e o teu oponente.
    Estas batalhas não são tidas em conta para a tua <a href='/pt/Battles/ELO.aspx'>Classificação ELO</a>.
    <p />
    Podes usar estas batalhas para testar novas <a href='/pt/Battles/BattleTactics.aspx'>Tácticas de Batalha</a>, conhecer melhor algumas <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> ou para praticar para <a href='/pt/Battles/Tournaments.aspx'>Torneios</a>.
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>