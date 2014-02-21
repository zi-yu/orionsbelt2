<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Arenas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Arenas</h1>
	<div class="description">
	A <a href='/pt/Universe/Arenas.aspx'>Arena</a> é o local de eleição dos jogadores guerreiros, onde há a oportunidade de lutar pelo reconhecimento e prestígio.<p />
  Existem diversas <a href='/pt/Universe/Arenas.aspx'>Arenas</a> pelo <a href='/pt/Universe/Default.aspx'>Universo</a>, sendo que quanto mais para o centro do <a href='/pt/Universe/Default.aspx'>Universo</a> se for maior é a recompensa pela vitória.<p />
  Quando um jogador encontra uma <a href='/pt/Universe/Arenas.aspx'>Arena</a> desocupada passa automaticamente a ser o campeão dessa <a href='/pt/Universe/Arenas.aspx'>Arena</a>, caso contrário pode desafiar 
  o campeão actual, sendo que a <a href='/pt/Universe/Fleet.aspx'>Armada</a> da batalha irá ser uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> não escolhida por nenhum dos jogadores, mas sim uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> igual 
  para os dois jogadores que é disponibilizada pela <a href='/pt/Universe/Arenas.aspx'>Arena</a> só para a batalha em questão. No caso de vitória o campeão é destronado e 
  é coroado um novo campeão daquela <a href='/pt/Universe/Arenas.aspx'>Arena</a>.<p />
  Mas o maior incentivo é a possibilidade de ganhar <a href='/pt/Commerce/Orions.aspx'>Orions</a>. O jogador que desafia o campeão tem de pagar <a href='/pt/Commerce/Orions.aspx'>Orions</a> para o desafiar, no caso
  do campeão ganhar, ganha também parte dos <a href='/pt/Commerce/Orions.aspx'>Orions</a> pagos pelo oponente. Quanto mais batalhas de <a href='/pt/Universe/Arenas.aspx'>Arena</a> se ganhar mais pontos se 
  ganha na profissão de <a href='/pt/GladiatorQuests.aspx'>Gladiador</a>. A pergunta é só - <i>De quantas <a href='/pt/Universe/Arenas.aspx'>Arenas</a> consegues ser campeão?</i>
	</div>
	
</asp:Content>