<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Possuir um planeta de nível 1 na zona pública
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Possuir um planeta de nível 1 na zona pública" runat="server" /></h1>
	
	<div class="description">
		Possuir um <a href='/pt/Universe/Planets.aspx'>Planeta</a> de nível 1 na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>. Conquistar planetas na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> é identico a conquistar planetas na <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>, existe apenas uma pequena diferença. Estar na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>
  significa que vais entrar em competição com outros jogadores pela posse dos planetas.<p />
  O <a href='/pt/Universe/Planets.aspx'>Planeta</a> que quiseres conquistar pode já estar na posse de outro jogador. Nesse caso duas coisas podem acontecer: o <a href='/pt/Universe/Planets.aspx'>Planeta</a> não tem defesas (o <a href='/pt/Universe/Planets.aspx'>Planeta</a> ainda não tem <a href='/pt/UnitIndex.aspx'>Unidades</a>
  na <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa), ou então o <a href='/pt/Universe/Planets.aspx'>Planeta</a> já está protegido.<p />
  No primeiro caso o <a href='/pt/Universe/Planets.aspx'>Planeta</a> é imediatamente conquistado, como acontecem com os planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>. No segundo caso a <a href='/pt/Universe/Fleet.aspx'>Armada</a> utilizada para conquistar o <a href='/pt/Universe/Planets.aspx'>Planeta</a> entra em
  batalha com a <a href='/pt/Universe/Fleet.aspx'>Armada</a> de desefa do <a href='/pt/Universe/Planets.aspx'>Planeta</a>. O jogador que ganhar a <a href="../Battles/BattleConcepts.aspx">batalha</a> ficará como o dono do <a href='/pt/Universe/Planets.aspx'>Planeta</a>.<p />
  Atenção que os planetas da <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> têm uma gestão Diferente dos planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>, na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> só é possível construir um tipo de <a href='/pt/FacilityIndex.aspx'>Edifícios</a>, os
  <a href="../Facility/Extractor.aspx">Extractores</a>.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Pontuação : +80</li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a> : +2</li><li><a class='seeker' href='/pt/Unit/Seeker.aspx'>Batedor</a> : +3</li></ul>
	</div>
	
</asp:Content>