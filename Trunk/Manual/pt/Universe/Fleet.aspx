<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Armada
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Armadas</h1>
<div class="content">
    Uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> é um grupo de <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> que pode <a href='/pt/Universe/Travel.aspx'>Viajar</a> no <a href='/pt/Universe/Default.aspx'>Universo</a>. Há vários tipos de armadas:
    <ul><li>
    Armadas de Defesa: Cada <a href='/pt/Universe/Planets.aspx'>Planeta</a> tem a sua própria armada de defesa. Esta armada não se pode mover
    e só é usada quando o planeta é atacado
  </li><li>Armadas Móveis: nos teus <a href='/pt/Universe/Planets.aspx'>Planetas</a> podes criar armadas para <a href='/pt/Universe/Travel.aspx'>Viajar</a> no <a href='/pt/Universe/Default.aspx'>Universo</a></li><li>Armadas Supremas: se uma armada tem uma unidade <a href='/pt/Battles/Ultimate.aspx'>Suprema</a>, é chamada armada suprema</li></ul><h2>Como criar uma Armada?</h2>
    Em primeiro lugar, é preciso construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> num dos planetas da tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>. Quando estiverem
    prontas, serão colocadas na armada de defesa desse planeta. Nessa altura podes ir à secção <i>Armadas</i>
    desse planeta e criar uma nova armada. Podes então mover <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> da armada de defesa para a armada
    criada.
    <p />
    Uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> só se pode mover se tiver <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> e estiver sem nenhuma ordem.

    <h2>O que podem fazer as Armadas?</h2>
    A primeira utilidade de uma armada é apenas <a href='/pt/Universe/Travel.aspx'>Viajar</a> na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>. Serás capaz de descobrir
    a tua zona devido à <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> da tua armada. Também poderás apanhar recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a> e colonizar
    outros <a href='/pt/Universe/Planets.aspx'>Planetas</a>. Quando estiveres pronto, podes usar o <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> para <a href='/pt/Universe/Travel.aspx'>Viajar</a> para a <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>.
    <p />
    Na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> serás capaz de atacar outras armadas, fazer <a href='/pt/Universe/Raids.aspx'>Pilhagem</a> a planetas, realizar <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a>
    e muito mais.

    <h2>Carga de uma Armada</h2>
    Cada armada tem um compartimento que pode armazenar recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a>. Quando a tua armada tem carga,
    tens de ir a um dos teus planetas para a descarregar para os teus recursos. Nota que se fores atacado e perderes,
    o teu adversário ganha a carga da tua armada como prémio.
    <p />
    A armada de defesa do teu planeta mãe é também usada para armazenar recursos que compras na <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a>.

    <h2>Cores das Armadas no Universo</h2>
    Na vista do <a href='/pt/Universe/Default.aspx'>Universo</a> podes ver várias <a href='/pt/Universe/Fleet.aspx'>Armadas</a> com cores diferentes. Cada cor tem ó seu próprio significado
    e depende do teu estado diplomático com a <a href='/pt/Universe/Alliance.aspx'>Aliança</a> do jogador dono da <a href='/pt/Universe/Fleet.aspx'>Armada</a>.
    <ul><li>Cor cinzenta: tens uma relação neutra com este jogador</li><li>Cor amarela: estás com um pacto de não agressão com este jogador</li><li>Cor azul: estás aliado com este jogador</li><li>Cor vermelha: estás em guerra com este jogador</li></ul></div>
	
</asp:Content>