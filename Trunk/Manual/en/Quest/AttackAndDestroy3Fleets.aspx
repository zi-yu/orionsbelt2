<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attack and destroy 3 fleets
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Attack and destroy 3 fleets" runat="server" /></h1>
	
	<div class="description">
		Engaging in a battle with another <a href='/en/Universe/Fleet.aspx'>Fleet</a> is as easy as Conquering a <a href='/en/Universe/Planets.aspx'>Planet</a>.
  You just need to have your <a href='/en/Universe/Fleet.aspx'>Fleet</a> selected (the one you want to engage the other player with) and click the <a href='/en/Universe/Fleet.aspx'>Fleet</a> you want to
  engage (battle with). <p />
  A little pop-up menu will appear with the option "Follow and Attack Fleet", click it and your <a href='/en/Universe/Fleet.aspx'>Fleet</a> will automatically follow
  and attack that <a href='/en/Universe/Fleet.aspx'>Fleet</a>.
  Once your <a href='/en/Universe/Fleet.aspx'>Fleet</a> reaches the other <a href='/en/Universe/Fleet.aspx'>Fleet</a> the battle will begin and will be accessible in the battle menu.<p />
  Your <a href='/en/Universe/Fleet.aspx'>Fleet</a> will, obviously be immobile for the duration of the battle.
  Once the battle ends (and if you win of course) you will once again be able to control the <a href='/en/Universe/Fleet.aspx'>Fleet</a> as normal,
  if you lose the <a href='/en/Universe/Fleet.aspx'>Fleet</a> and all that was with it will be destroyed (Resources included).
  So be careful before attacking another <a href='/en/Universe/Fleet.aspx'>Fleet</a> if you have resources you don't want to risk going to waste.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +3500</li><li><a href='/en/PirateQuests.aspx'>Pirate</a> : +20</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +1500</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>