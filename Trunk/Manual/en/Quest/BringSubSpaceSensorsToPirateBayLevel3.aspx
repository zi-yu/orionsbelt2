﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Sub-Space Sensors to a level 3 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Sub-Space Sensors to a level 3 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		Beta Force is always able to detect our fleets. We need to avoid that. Bring 2 Sub-Space Sensors to any Pirate Bay level 3.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +4500</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +3500</li></ul>
	</div>
	
</asp:Content>