<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Serviços Premium
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comércio</h2><ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a></li><li><a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a></li><li><a href='/pt/Commerce/Shop.aspx'>Serviços Premium</a></li><li><a href='/pt/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Serviços Premium</h1>
<div class="content">
    Na <a href='/pt/Commerce/Shop.aspx'>Serviços Premium</a> podes comprar serviços especiais que te vão assistir no jogo e baixar a sua dificuldade. Apenas
    podes comprar estes serviços usando <a href='/pt/Commerce/Orions.aspx'>Orions</a>.
    <p />
    Esta é a lista de serviços disponíveis:
    <ul><li><a href='/pt/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Dedução de 30% no custo de recursos intrínseco dos Edifícios e Unidades de Combate</a></li><li><a href='/pt/Commerce/Shop.aspx#BuyRareDeduction'>Dedução de 30% no custo de recursos raros dos Edifícios e Unidades de Combate</a></li><li><a href='/pt/Commerce/Shop.aspx#BuyQueueSpace'>Mais 3 espaços na lista de espera. Estes espaços adicionais estarão disponíveis na lista de espera de Edifícios e Unidades.</a></li><li><a href='/pt/Commerce/Shop.aspx#BuyFastSpeed'>Velocidade de construção aumentada em 50%</a></li><li><a href='/pt/Commerce/Shop.aspx#BuyFullLineOfSight'>Remoção da Névoa de Guerra no universo descoberto</a></li><li><a href='/pt/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Tornar todo o universo descoberto</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Dedução de 30% no custo de recursos intrínseco dos Edifícios e Unidades de Combate</a></h2>
    Com este serviço activado, os custos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a> dos teus <a href='/pt/FacilityIndex.aspx'>Edifícios</a> e <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> será 30%
    mais baixo. Isto apenas se aplica aos recursos da tua <a href='/pt/Race/Races.aspx'>Raça</a>, não afectará recursos raros.

    <ul><li>Se fores dos <a href='/pt/Race/LightHumans.aspx'>Utopianos</a>, afecta <a class='energy' href='/pt/Intrinsic/Energy.aspx'>Energia</a>, <a class='serium' href='/pt/Intrinsic/Serium.aspx'>Serium</a> e <a class='mithril' href='/pt/Intrinsic/Mithril.aspx'>Mithril</a></li><li>Se fores dos <a href='/pt/Race/DarkHumans.aspx'>Renegados</a>, afecta <a class='gold' href='/pt/Intrinsic/Gold.aspx'>Ouro</a>, <a class='titanium' href='/pt/Intrinsic/Titanium.aspx'>Titânio</a> e <a class='uranium' href='/pt/Intrinsic/Uranium.aspx'>Urânio</a></li><li>Se fores dos <a href='/pt/Race/Bugs.aspx'>Levyr</a>, afecta <a class='protol' href='/pt/Intrinsic/Protol.aspx'>Protol</a> e <a class='elk' href='/pt/Intrinsic/Elk.aspx'>Comida</a></li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyRareDeduction'>Dedução de 30% no custo de recursos raros dos Edifícios e Unidades de Combate</a></h2>
    Com este serviço activado, os custos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a> dos teus <a href='/pt/FacilityIndex.aspx'>Edifícios</a> e <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> será 30%
    mais baixo. Ao contrário do serviço anterior, este é somente válido para os recursos raros: 
    <a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a>, <a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> e <a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a>.

    <a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyQueueSpace'>Mais 3 espaços na lista de espera. Estes espaços adicionais estarão disponíveis na lista de espera de Edifícios e Unidades.</a></h2>
    A fila de espera é a quantidade de <a href='/pt/FacilityIndex.aspx'>Edifícios</a> ou <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> que podes colocar em espera para entrar
    em produção. Por omissão, a tua lista apenas suporta uma posição. Isto significa que se tiveres a construir
    algo, só podes colocar mais uma ordem de construção, que terá início assim que o que estiver em construcção
    fique concluído.
    <p />
    Com este serviço podes colocar mais 3 ordens em lista de espera.

    <a name="BuyFastSpeed" id="BuyFastSpeed"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyFastSpeed'>Velocidade de construção aumentada em 50%</a></h2>
    O tempo que algo demora a construir depende do teu factor de produção e do que estiveres a construir.
    Com este serviço, o teu factor de produção é reduzido em 50%, o que significa que tudo o que construires
    vai levar metade do tempo a ficar pronto.

    <a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyFullLineOfSight'>Remoção da Névoa de Guerra no universo descoberto</a></h2>
    Tu só consegues ver outros jogadores se eles estiverem a operar na tua <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a>. A tua [LineOfsight]
    é determinada pelos <a href='/pt/Universe/Planets.aspx'>Planetas</a> e <a href='/pt/Universe/Fleet.aspx'>Armadas</a> que tens próximo. Com este serviço, terás <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> total
    no universo discoberto.

    <a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/pt/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Tornar todo o universo descoberto</a></h2>
    Os quadrados pretos no <a href='/pt/Universe/Default.aspx'>Universo</a> são espaço por descobrir. Tu não sabes o que lá está, e precisas de
    <a href='/pt/Universe/Travel.aspx'>Viajar</a> com uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> para essa localização para ver o que lá está. Com este serviço, conseguirás ver
    <b>todo</b> o universo como se o tivesses descoberto.
  </div>
	
</asp:Content>