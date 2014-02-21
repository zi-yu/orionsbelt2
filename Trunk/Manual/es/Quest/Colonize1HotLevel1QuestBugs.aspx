<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Poseer un planeta de nivel 1 en la zona pública
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Poseer un planeta de nivel 1 en la zona pública" runat="server" /></h1>
	
	<div class="description">
		Poseer un <a href='/es/Universe/Planets.aspx'>Planeta</a> de nível 1 na <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>. Conquistar planetas na <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> é identico a conquistar planetas na <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>, existe apenas uma pequena diferença. Estar na <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>
  significa que vais entrar em competição com outros jogadores pela posse dos planetas.<p />
  O <a href='/es/Universe/Planets.aspx'>Planeta</a> que quiseres conquistar pode já estar na posse de outro jogador. Nesse caso duas coisas podem acontecer: o <a href='/es/Universe/Planets.aspx'>Planeta</a> não tem defesas (o <a href='/es/Universe/Planets.aspx'>Planeta</a> ainda não tem <a href='/es/UnitIndex.aspx'>Unidades</a>
  na <a href='/es/Universe/Fleet.aspx'>Flota</a> de defesa), ou então o <a href='/es/Universe/Planets.aspx'>Planeta</a> já está protegido.<p />
  No primeiro caso o <a href='/es/Universe/Planets.aspx'>Planeta</a> é imediatamente conquistado, como acontecem com os planetas da <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>. No segundo caso a <a href='/es/Universe/Fleet.aspx'>Flota</a> utilizada para conquistar o <a href='/es/Universe/Planets.aspx'>Planeta</a> entra em
  batalha com a <a href='/es/Universe/Fleet.aspx'>Flota</a> de desefa do <a href='/es/Universe/Planets.aspx'>Planeta</a>. O jogador que ganhar a <a href="../Battles/BattleConcepts.aspx">batalha</a> ficará como o dono do <a href='/es/Universe/Planets.aspx'>Planeta</a>.<p />
  Atenção que os planetas da <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> têm uma gestão Diferente dos planetas da <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>, na <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> só é possível construir um tipo de <a href='/es/FacilityIndex.aspx'>Edificios</a>, os
  <a href="../Facility/Extractor.aspx">Extractores</a>.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Pontuación : +80</li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a> : +2</li><li><a class='seeker' href='/es/Unit/Seeker.aspx'>Buscador</a> : +3</li></ul>
	</div>
	
</asp:Content>