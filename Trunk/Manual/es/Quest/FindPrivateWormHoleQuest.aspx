<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Encuentra el Túnel Espacial de tu zona privada y usalo para viajar hacia la zona pública
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Encuentra el Túnel Espacial de tu zona privada y usalo para viajar hacia la zona pública" runat="server" /></h1>
	
	<div class="description">
		Después de haber colonizado todos los <a href='/es/Universe/Planets.aspx'>Planetas</a> de tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> no tienes opción de poseer mas <a href='/es/Universe/Planets.aspx'>Planetas</a>
  a no ser que existan <a href='/es/Universe/Planets.aspx'>Planetas</a> en la <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>. Para que llegues a la <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> sólo existe una manera, que hagas un viaje por el <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> que existe
  en tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>, en caso contrário nunca conseguirias hacer un viaje de millones de años luz.<p />
  Tu <a href='/es/Quests.aspx'>Misión</a> es encontrar el <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> idéntico al de la imagén siguiente y viajar a través de el hasta la <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>.
  <img class="block" src="/Resources/Images/pt/Wormhole.png" alt="Túnel Espacial" title="Tunel Espacial" />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>