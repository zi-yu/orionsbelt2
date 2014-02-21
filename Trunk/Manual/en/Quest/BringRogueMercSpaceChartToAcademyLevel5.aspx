<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Rogue Merc Space Chart to a level 5 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Rogue Merc Space Chart to a level 5 Academy" runat="server" /></h1>
	
	<div class="description">
		Mercs have one of the best charts of the universe. I need you to aquire one of those universe charts from a Rogue Mercs Fleet. When you adquire one, bring it to a level 5 Academy.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +8500</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='scourge' href='/en/Unit/Scourge.aspx'>Scourge</a> : +40</li></ul>
	</div>
	
</asp:Content>