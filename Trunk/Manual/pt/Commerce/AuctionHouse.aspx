<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Casa de Leilões
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comércio</h2><ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a></li><li><a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a></li><li><a href='/pt/Commerce/Shop.aspx'>Serviços Premium</a></li><li><a href='/pt/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Casa de Leilões</h1>
	<div class="description">
	A <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a> é o local onde um jogador pode comprar ou vender coisas a outro jogador. As transacções são sempre feitas
  usando os <a href='/pt/Commerce/Orions.aspx'>Orions</a> como moeda de compra.<p /><h2>O que posso vender e como posso vender?</h2>
  É possível vender recursos e <a href='/pt/UnitIndex.aspx'>Unidades</a>. Para vender <a href='/pt/UnitIndex.aspx'>Unidades</a> é necessário que elas estejam na <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa no <a href='/pt/Universe/Planets.aspx'>Planeta</a> mãe.<p />
  Para proceder à venda (colocação em leilão) é necessário ir à página da <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a> e depois seguir para a página de "Adicionar Leilão".<p />
  Nesta página aparecem os recursos/<a href='/pt/UnitIndex.aspx'>Unidades</a> que se podem colocar a leilão assim como, a quantidade pretendida, o valor mínimo de licitação,
  o valor de venda imediata, o tempo que estará na <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a> e se é para fazer publicidade ao produto que se colocará à venda.
  Os campos de preenchimento obrigatório são a quantidade a colocar em leilão e o valor base de licitação.<p />
  É necessário ainda que o jogador esteja à 3 dias sem mudar de conta, para conseguir colocar algo na <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a>.<p /><h2>Como se procede a venda?</h2>
  Durante o tempo que se escolheu quando o produto foi posto na <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a>, é possível aos jogadores licitarem ou comprarem o produto de imediato.
  No caso da compra imediata o jogador que está a vender recebe os <a href='/pt/Commerce/Orions.aspx'>Orions</a> de imediato, no caso da licitação o vendedor só recebe os <a href='/pt/Commerce/Orions.aspx'>Orions</a> quando
  terminar o tempo de licitação.<p />
  Todas as vendas têm a taxa da <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a> associada que pode variar de 8%-25%, sendo mais baixa a taxa quanto maior for o valor da venda final.
  Isto significa que o vendedor vai receber o valor da venda (pago pelo outro jogador) menos a taxa da <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a>.<p />
  No caso do produto não ser vendido se for uma unidade volta à <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa do <a href='/pt/Universe/Planets.aspx'>Planeta</a> mãe, se for um recurso volta para o repositório de recursos
  até ao limite máximo do repositório.<p />
  Existe ainda uma página onde o jogador pode ainda ver os produtos que tem a leilão naquele momento, e os produtos que já vendeu na <a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a> em outras alturas.<p /><h2>Como se procede a compra?</h2>
  Após ganhar uma licitação o jogador recebe o produto comprado na <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa do <a href='/pt/Universe/Planets.aspx'>Planeta</a> mãe. No caso de ser uma unidade ela aparece directamente
  na <a href='/pt/Universe/Fleet.aspx'>Armada</a> e está pronta a ser movida para uma outra <a href='/pt/Universe/Fleet.aspx'>Armada</a> que possa navegar pelo <a href='/pt/Universe/Default.aspx'>Universo</a>.<p />
  No caso de ser um recurso ou uma <a href='/pt/Battles/Ultimate.aspx'>Suprema</a> ela vai para a carga da <a href='/pt/Universe/Fleet.aspx'>Armada</a> no <a href='/pt/Universe/Planets.aspx'>Planeta</a> mãe. No caso dos recursos quando são retirados da carga vão
  para o repositório de recursos, no caso de uma <a href='/pt/Battles/Ultimate.aspx'>Suprema</a> é criada uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> na órbita do <a href='/pt/Universe/Planets.aspx'>Planeta</a> mãe caso o jogador ainda não tenha chegado ao limite de armadas,
  caso contrário não é possível descarregar a <a href='/pt/Battles/Ultimate.aspx'>Suprema</a>.
	</div>
	
</asp:Content>