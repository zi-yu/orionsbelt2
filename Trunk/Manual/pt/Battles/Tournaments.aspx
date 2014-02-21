<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Torneios
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batalhas</h2><ul><li><a href='/pt/Battles/Tournaments.aspx'>Torneios</a></li><li><a href='/pt/Battles/Ladder.aspx'>Escada</a></li><li><a href='/pt/Battles/Friendly.aspx'>Amigáveis</a></li><li><a href='/pt/Battles/ELO.aspx'>Classificação ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Torneios</h1>
	<div class="content">
    Os <a href='/pt/Battles/Tournaments.aspx'>Torneios</a> são o campo de batalha supremo para os jogadores de <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. Aqui podes batalhar com os melhores jogadores
    e terás de provar o quão bom és para ganhar. Podes participar em torneios de <a href='/pt/Battles/Regicide.aspx'>Regicídeo</a> e <a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a>.
    Além de prestígio, ganhar batalhas de <a href='/pt/Battles/Tournaments.aspx'>Torneios</a> também te dá <a href='/pt/Commerce/Orions.aspx'>Orions</a>.

    <h2>Estrutura dos Torneios</h2>
    Há várias fases num torneio. Primeiro o torneio começa com a fase de inscrições. Se as restricções do torneio o permitirem,
    podes inscrever-te e serás colocado num de dez potes. Quando o torneio avança, é começada a fase de grupos.
    <p />
    Na fase de grupos os 3 primeiros jogadores passam à próxima fase. Também poderá acontecer a repescagem de alguns jogadores
    se for necessário.
    <p />
    Depos da fase de grupos vêm as eliminatórias. Se perderes, sais da competição!
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>