﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attackiere und zerstöre 3 Beta Force Flotten
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Attackiere und zerstöre 3 Beta Force Flotten" runat="server" /></h1>
	
	<div class="description">
		Beta Force Flotten sind gesichtet worden in der Level 3 Zone. Finde sie und zerstöre 3 Flotten.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +6000</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +2000</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +2000</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +2000</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +2000</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +2000</li></ul>
	</div>
	
</asp:Content>