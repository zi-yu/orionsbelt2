﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring to a level 7 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring to a level 7 Academy" runat="server" /></h1>
	
	<div class="description">
		Mercs have one of the best charts of the universe. I need you to aquire one of those universe charts from a Tech Mercs Fleet. When you adquire one, bring it to a level 7 Academy.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +11500</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +5500</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +5500</li></ul>
	</div>
	
</asp:Content>