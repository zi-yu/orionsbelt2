<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Classificação ELO
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batalhas</h2><ul><li><a href='/pt/Battles/Tournaments.aspx'>Torneios</a></li><li><a href='/pt/Battles/Ladder.aspx'>Escada</a></li><li><a href='/pt/Battles/Friendly.aspx'>Amigáveis</a></li><li><a href='/pt/Battles/ELO.aspx'>Classificação ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Sistema de Pontuação ELO</h1>
<div class="content">
    O ELO é um sistema de pontuação no <a href='http://www.orionsbelt.eu'>Orion's Belt</a> que mede o nível de capacidade de batalha de cada jogador. Quanto mais
    ELO um jogador tiver, melhor ele será no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>. O Elo de um jogador é actualzado em cada batalha de
    <a href='/pt/Battles/Tournaments.aspx'>Torneio</a> ou <a href='/pt/Battles/Ladder.aspx'>Escada</a>.
    <p />
    A implementação ELO do <a href='http://www.orionsbelt.eu'>Orion's Belt</a> é baseada no <a href="http://en.wikipedia.org/wiki/Elo_rating_system">Sistema de Pontuação ELO</a>
    usado no Xadrez.
  </div>
	
</asp:Content>