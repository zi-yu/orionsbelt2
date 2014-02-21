<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonizar otro planeta en tu zona privada
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonizar otro planeta en tu zona privada" runat="server" /></h1>
	
	<div class="description">
		El objetivo de esta misión es aprender a conquistar un <a href='/es/Universe/Planets.aspx'>Planeta</a>. En tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> no puedes ser molestado
  por otros jugadores, por eso no tienes que estar preocupado de ser atacado.<p />
  Navega por el universo com una <a href='/es/Universe/Fleet.aspx'>Flota</a> hasta que encuentres un <a href='/es/Universe/Planets.aspx'>Planeta</a>. Enseguida selecciona la <a href='/es/Universe/Fleet.aspx'>Flota</a>, haz click encima del <a href='/es/Universe/Planets.aspx'>Planeta</a> y
  haz conquistar,  como lo que sucede en la imagem siguiente, y tienes la mision lista para ser entregada.
  <img class="block" src="/Resources/Images/pt/colonize.png" alt="Colonizar" title="Colonizar" />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a> : +5</li></ul>
	</div>
	
</asp:Content>