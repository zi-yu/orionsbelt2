<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonizar los cinco planetas en tu zona privada
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonizar los cinco planetas en tu zona privada" runat="server" /></h1>
	
	<div class="description">
		Ahora ya aprendiste a colonizar <a href='/es/Universe/Planets.aspx'>Planetas</a> tu próxima <a href='/es/Quests.aspx'>Misión</a> es colonizar todos os planetas de tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>.
  En tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> existén 5 <a href='/es/Universe/Planets.aspx'>Planetas</a>, descubrelos y colonizalos.<p />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a> : +50</li></ul>
	</div>
	
</asp:Content>