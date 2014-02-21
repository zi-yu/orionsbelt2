<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Alpha Force Wrecks to a level 1 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Alpha Force Wrecks to a level 1 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		We need to obtain some components from a Jumper unit. Raid all the Alpha Force fleets you can find and bring 4 Jumper Reactors and 4 Jumper Stabilizers to any level 1 Pirate Bay.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +500</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +2500</li></ul>
	</div>
	
</asp:Content>