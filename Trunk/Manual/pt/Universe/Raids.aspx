<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pilhagem
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Pilhagens</h1>
<div class="content">
    Uma pilhagem consiste em atacar um planeta de outro jogador com o objectivo de roubar recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a>.
    Esta acção é normalmente feita por jogadores <a href='/pt/PirateQuests.aspx'>Pirata</a> nas suas <a href='/pt/Quests.aspx'>Missões</a>, mas pode ser feita por qualquer
    jogador, independentemente da sua <a href='/pt/Quests.aspx#Professions'>Actividade</a>.
    <p />
    Quando pilhas um planeta, duas coisas podem acontecer:
    <ul><li>A <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa do planeta está vazia, e a pilhagem é efectuada</li><li>
  O planeta tem defesas e é começada uma batalha no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>; só se a ganhares é que a pilhagem
  é efectuada
 </li></ul>
    Mesmo que a pilhagem seja efectuada, isso não significa que obtenhas recursos. Há um tempo de intervalo
    entre pilhagens para evitar abusos, pelo que só é possível pilhar com sucesso a cada ~14 horas.
    <p />
    Se a pilhagem tiver sucesso, então serão roubados alguns recursos e a tua reputação como <a href='/pt/PirateQuests.aspx'>Pirata</a> é aumentada.
    É possível roubar vários recursos, mas provavelmente só irás roubar o recurso mais comum para o dono do
    planeta que pilhaste, e isso depende da sua <a href='/pt/Race/Races.aspx'>Raça</a>:
    <ul><li>Se atacaste um planeta de <a href='/pt/Race/LightHumans.aspx'>Utopianos</a> vais obter <a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a></li><li>Se atacaste um planeta de <a href='/pt/Race/DarkHumans.aspx'>Renegados</a> vais obter <a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>Se atacaste um planeta de <a href='/pt/Race/Bugs.aspx'>Levyr</a> vais obter <a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
    A quantidade do recurso que é roubada é uma percentagem da quantidade total que esse jogador tiver.
    Planetas de nível superior têm percentagens mais elevadas.
   </div></h1>
	
</asp:Content>