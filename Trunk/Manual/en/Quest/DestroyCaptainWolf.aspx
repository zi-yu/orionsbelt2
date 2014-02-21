<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Captain Wolf
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Captain Wolf" runat="server" /></h1>
	
	<div class="description">
		The Space Force is destroying our empire and we need to stop it. Captain Wolf, the right hand of their leader, Commander Fox, has to be stopped. Bring me his head! Reports locate him in the level 7 zone but sometimes he wonders in the level 9 and level 10 zones. Find him and bring his Head to any level 7 Pirate Bay.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +100000</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='captainwolf' href='/en/Unit/CaptainWolf.aspx'>CaptainWolf</a> : +1</li></ul>
	</div>
	
</asp:Content>