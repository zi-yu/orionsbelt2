﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Black Merc Wrecks to a level 9 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Black Merc Wrecks to a level 9 Academy" runat="server" /></h1>
	
	<div class="description">
		I need some components from the main units of the Black Mercs. Bring those components to any level 9 Academy.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +13000</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +7000</li></ul>
	</div>
	
</asp:Content>