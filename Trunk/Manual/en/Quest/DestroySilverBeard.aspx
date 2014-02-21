<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Silver Beard
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Silver Beard" runat="server" /></h1>
	
	<div class="description">
		We have located the ruthless right hand of Metallic Beard. He calls himself Silver Beard. Reports locate him in the level 7 zone but sometimes he wonders in the level 9 and level 10 zones. Find him and bring his Head to any level 7 Academy.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +50000</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +12000</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='silverbeard' href='/en/Unit/SilverBeard.aspx'>Silver Beard</a> : +1</li></ul>
	</div>
	
</asp:Content>