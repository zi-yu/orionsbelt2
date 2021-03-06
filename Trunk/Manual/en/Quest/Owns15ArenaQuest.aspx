﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Become champion of 15 arenas at the same time
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Become champion of 15 arenas at the same time" runat="server" /></h1>
	
	<div class="description">
		Explore the <a href='/en/Universe/Default.aspx'>Universe</a>, find <a href='/en/Universe/Arenas.aspx'>Arenas</a> and become the undisputed champion in at least 15 arenas.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a> : +150</li><li><a class='fenix' href='/en/Unit/Fenix.aspx'>Fenix</a> : +500</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +15000</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +15000</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +15000</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +15000</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +15000</li></ul>
	</div>
	
</asp:Content>