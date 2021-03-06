﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Berilium to a level 3 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Berilium to a level 3 Academy" runat="server" /></h1>
	
	<div class="description">
		Sentry Merc fleets use a very rare element that powers their units, the Berilium. Bring 3 samples of this element to any level 3 Academy.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +2500</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +3500</li></ul>
	</div>
	
</asp:Content>