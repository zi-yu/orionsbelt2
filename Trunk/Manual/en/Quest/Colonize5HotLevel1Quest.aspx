<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Own five planets level 1 on the hot zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Own five planets level 1 on the hot zone" runat="server" /></h1>
	
	<div class="description">
		Own five planets level 1 on the hot zone
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +240</li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a> : +6</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +100</li></ul>
	</div>
	
</asp:Content>