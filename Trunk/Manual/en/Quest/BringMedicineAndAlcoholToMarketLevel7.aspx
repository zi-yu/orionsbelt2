<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Medicine and Alcohol to a Market level 7
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Medicine and Alcohol to a Market level 7" runat="server" /></h1>
	
	<div class="description">
		Bring a fleet with both Medicine and Alcohol to a level 7 Market
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +2500</li><li><a href='/en/MerchantQuests.aspx'>Merchant</a> : +30</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +500</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +500</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +500</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +500</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +500</li></ul>
	</div>
	
</asp:Content>