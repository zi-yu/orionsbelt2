<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Commander Fox
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Commander Fox" runat="server" /></h1>
	
	<div class="description">
		I've done with it. Bring me Commander Fox head now. This is the most important mission i will give you until today, so don't fail or you will regreat. You must search levels 9 and 10 and bring his head to a level 10 Pirate Bay.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +50000</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +12000</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='commanderfox' href='/es/Unit/CommanderFox.aspx'>Commander Fox</a> : +1</li></ul>
	</div>
	
</asp:Content>