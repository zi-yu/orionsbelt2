<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zona Pública
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Zona Pública</h1>
<div class="content">
    A <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> é onde toda a acção se passa. Lá encontrarás outros jogadores, outras <a href='/pt/Race/Races.aspx'>Raças</a> e um
    vasto <a href='/pt/Universe/Default.aspx'>Universo</a> para explorar. Na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> o jogo não te protege contra outros jogadores, estás
    por tua conta e risco, A única protecção que o jogo dá, é que jogadores de nível mais alto não
    podem atacar jogadores de nível mais baixo.
    <p />
    Mas não precisas de estar sozinho no universo, podes entrar para uma <a href='/pt/Universe/Alliance.aspx'>Aliança</a> para protecção
    e ajuda. Também deves escolher uma <a href='/pt/Quests.aspx#Professions'>Actividade</a> e seguir as suas <a href='/pt/Quests.aspx'>Missões</a>, porque desta forma
    serás capaz de evoluir mais rapidamente.
    <p />
    Alguns pontos de interesse que poderás encontrar na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>:
    <ul><li>Outros <a href='/pt/Universe/Planets.aspx'>Planetas</a> para colonizar, que te permitirão construir o <a class='extractor' href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a>, que te dá acesso a recursos raross</li><li>
    <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> - Há uma vasta rede de túneis espalhados pelo universo, e quantos mais conheceres,
    mais rápido conseguirás <a href='/pt/Universe/Travel.aspx'>Viajar</a>
  </li><li><a href='/pt/Commerce/Markets.aspx'>Mercados</a> - Encontra mercados para efecturares <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> e torna-te num <a href='/pt/MerchantQuests.aspx'>Comerciante</a> rico</li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a> - Batalha nas arenas para te tornares no <a href='/pt/GladiatorQuests.aspx'>Gladiador</a> supremo</li></ul><a id="levels" name="levels"></a><h2>Nível de Zona</h2>
  Todos os elementos no universeo têm um nível, que depende da zona onde estão. Isto é válido para
  <a href='/pt/Universe/Planets.aspx'>Planetas</a>, <a href='/pt/Universe/Arenas.aspx'>Arenas</a>, <a href='/pt/Commerce/Markets.aspx'>Mercados</a>, <a href='/pt/Universe/Relics.aspx'>Reliquias</a>, etc. Quanto mais para o centro, maior o nível será. A zona do centro
  é chamada <i>Sirius</i>.
    <p />
    Esta lógica de zonas existe para providenciar o seguinte:
    <ul><li>
    Quando um jogador começa o jogo, ele tem um <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> privado que liga a sua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> a um
    outro <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> na extremidade do universo. Daí, ele pode mover-se para o centro para obter
    <a href='/pt/Universe/Planets.aspx'>Planetas</a> melhores.
  </li><li>
    Isto significa que os jogadores começam na extremidade do universo, e à medida que vão evoluindo, vão
    migrando mais para o centro.
  </li><li>
    E assim acontece que jogadores mais recentes não vão chocar com jogadores mais avançados, porque
    os jogadores avançados já se moveram para zonas melhores.
  </li></ul>
    Os níveis variam entre 1 e 10, sendo 10 o melhor. A seguinte imagem é uma representação do universo
    do <a href='http://www.orionsbelt.eu'>Orion's Belt</a>:
  </div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>