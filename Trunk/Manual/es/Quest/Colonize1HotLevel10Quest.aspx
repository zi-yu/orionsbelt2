<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Poseer un planeta de nivel 10 en la zona pública
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Poseer un planeta de nivel 10 en la zona pública" runat="server" /></h1>
	
	<div class="description">
		Poseer un planeta de nível 10 en la zona pública
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +4040</li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a> : +116</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +2200</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +1600</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1400</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +1900</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +2000</li></ul>
	</div>
	
</asp:Content>