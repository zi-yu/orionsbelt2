<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Become champion of 17 arenas at the same time
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Become champion of 17 arenas at the same time" runat="server" /></h1>
	
	<div class="description">
		Explore the <a href='/es/Universe/Default.aspx'>Universo</a>, find <a href='/es/Universe/Arenas.aspx'>Arenas</a> and become the undisputed champion in at least 17 arenas.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a> : +170</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +17000</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +17000</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +17000</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +17000</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +17000</li></ul>
	</div>
	
</asp:Content>