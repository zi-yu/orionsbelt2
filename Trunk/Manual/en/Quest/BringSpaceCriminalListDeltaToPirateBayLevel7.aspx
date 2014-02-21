﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring a Criminal List Delta to a level 7 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring a Criminal List Delta to a level 7 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		The Delta Force has a list with the most wanted criminals in the level 7 zone. We want you to find that list and bring it to any level 7 pirate bay.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +11500</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +4500</li></ul>
	</div>
	
</asp:Content>