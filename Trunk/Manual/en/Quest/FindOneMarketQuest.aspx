<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Find one market on the public zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Find one market on the public zone" runat="server" /></h1>
	
	<div class="description">
		Find one market on the public zone
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Score : +1000</li><li><a href='/en/MerchantQuests.aspx'>Merchant</a> : +10</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +200</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +200</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +200</li></ul>
	</div>
	
</asp:Content>