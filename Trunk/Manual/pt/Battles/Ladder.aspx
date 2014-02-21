<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Escada
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batalhas</h2><ul><li><a href='/pt/Battles/Tournaments.aspx'>Torneios</a></li><li><a href='/pt/Battles/Ladder.aspx'>Escada</a></li><li><a href='/pt/Battles/Friendly.aspx'>Amigáveis</a></li><li><a href='/pt/Battles/ELO.aspx'>Classificação ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Escada</h1>
<div class="content">
    A <a href='/pt/Battles/Ladder.aspx'>Escada</a> representa os jogadores activos que melhor jogam no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>. Quando começas o jogo, tu vais para
    a última posição da <a href='/pt/Battles/Ladder.aspx'>Escada</a>. Nessa altura poderás desafiar jogadores acima de ti. Se ganhares, irás
    trocar de posição com eles. O objectivo é chegar à primeira posição e permanecer por lá o máximo período
    de tempo possível.
  </div>
	
</asp:Content>