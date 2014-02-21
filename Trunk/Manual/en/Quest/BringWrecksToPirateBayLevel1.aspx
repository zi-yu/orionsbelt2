<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Alpha Force Wrecks to a level 1 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Alpha Force Wrecks to a level 1 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		We need to obtain some components from a Jumper unit. Raid all the Alpha Force fleets you can find and bring 4 Jumper Reactors and 4 Jumper Stabilizers to any level 1 Pirate Bay.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +500</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +2500</li></ul>
	</div>
	
</asp:Content>