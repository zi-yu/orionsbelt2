<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring a Black Merc Uniforms to a level 9 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring a Black Merc Uniforms to a level 9 Academy" runat="server" /></h1>
	
	<div class="description">
		I need to infiltrate in a Black Mercs fleet and for that i need certain items. 6 Black Mercs uniforms to be exact. Bring them to any level 9 Academy.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +14000</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +7000</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +7000</li></ul>
	</div>
	
</asp:Content>