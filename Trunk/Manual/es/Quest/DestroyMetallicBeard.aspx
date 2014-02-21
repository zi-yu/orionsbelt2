<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Metallic Beard
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Metallic Beard" runat="server" /></h1>
	
	<div class="description">
		This is the most important mission i will give you until today. You must search levels 9 and 10 and end with Metallic Beard's menace. Bring his head to a level 10 Academy.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a> : +3000</li><li>Pontuación : +100000</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='metallicbeard' href='/es/Unit/MetallicBeard.aspx'>Barba de Metal</a> : +1</li></ul>
	</div>
	
</asp:Content>