<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Tactical Computers to a level 5 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Tactical Computers to a level 5 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		Space Force is becoming very strong due to their Tactical computers. We need to obtain them. Bring 5 tactical computers from a Gamma Force fleet to any Pirate Bay Level 5.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +6500</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +4500</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li></ul>
	</div>
	
</asp:Content>