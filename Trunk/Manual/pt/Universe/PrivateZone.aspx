<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zona Privada
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Zona Privada</h1>
<div class="content">
    A <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> é o sítio onde começas o jogo. É uma zona que só está disponível para ti, outros jogadores
    não conseguem entrar na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>. Na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> tens cinco <a href='/pt/Universe/Planets.aspx'>Planetas</a>. Estes serão os teus
    planetas principais onde conseguirás obter recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a> e construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    Esta é uma imagem da tua zona privada quando o jogo começa:
    <img class="block" src="/Resources/Images/PZ1.png" alt="Imagem da Zona Privada" />

    E esta é uma imagem de uma zona privada já toda descoberta:
    <img class="block" src="/Resources/Images/PZ2.png" alt="Imagem da Zona Privada" />

    Na tua zona privada (e em todo o universo), vais encontrar recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a> que podes apanhar simplesmente
    movendo a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> para a sua posição. Quando começas o jogo, certifica-te que os apanhas todos, pois
    vais precisar.
    <p />
    Quando estiveres pronto para sair da tua zona privada, podes usar o <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> para viajar para a 
    <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> e interagir com outros jogadores, colonizar mais planetas, e muito mais.
    <p />
    Mas enquanto estás na tua zona privada, não te esqueças de seguir as seguintes <a href='/pt/Quests.aspx'>Missões</a>:
    <ul><li><a href='/pt/Quest/GetAllPrivateZoneResources.aspx'>Apanhar todos os recursos que tens na zona privada</a></li><li><a href='/pt/Quest/ColonizeOnePlanetQuest.aspx'>Colonizar um outro planeta na tua zona privada</a></li><li><a href='/pt/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Colonizar todos os cinco planetas na tua zona privada</a></li><li><a href='/pt/Quest/FindPrivateWormHoleQuest.aspx'>Encontra o Túnel Espacial da tua zona privada e usa-o para viajar para a zona pública</a></li></ul></div>
	
</asp:Content>