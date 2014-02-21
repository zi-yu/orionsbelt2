<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Black Merc Wrecks to a level 9 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Black Merc Wrecks to a level 9 Academy" runat="server" /></h1>
	
	<div class="description">
		I need some components from the main units of the Black Mercs. Bring those components to any level 9 Academy.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +13000</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +7000</li></ul>
	</div>
	
</asp:Content>