<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Raid 3 planets
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Raid 3 planets" runat="server" /></h1>
	
	<div class="description">
		Raiding a <a href='/en/Universe/Planets.aspx'>Planet</a> is much the same as conquering one.
  When you left click with your mouse button (and have a <a href='/en/Universe/Fleet.aspx'>Fleet</a> selected, of course) on a <a href='/en/Universe/Planets.aspx'>Planet</a> with an owner two options appear:
  "Attack and conquer Planet" and "Raid Planet".
  You already know what the first is about, but what about the second one? Raiding?
  Raiding is almost the same as conquering a <a href='/en/Universe/Planets.aspx'>Planet</a>, all the rules apply, only one thing changes: the prize.<p />
  On the first option if you win you gain ownership of the <a href='/en/Universe/Planets.aspx'>Planet</a>.
  On the second option you steal resources from the <a href='/en/Universe/Planets.aspx'>Planet</a>. If there is no Defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> on the <a href='/en/Universe/Planets.aspx'>Planet</a> the <a href='/en/Universe/Raids.aspx'>Raid</a> is automatically
  successful, otherwise a battle will begin, if you win the <a href='/en/Universe/Raids.aspx'>Raid</a> will be successful.<p />
  While you're low level Raiding may not look like a useful feature as you may have all the resources you need, but as you progress
  along the game Raiding will be more and more useful as you'll have more need for resources and there are more resources to steal.
  Of course you can't raid a <a href='/en/Universe/Planets.aspx'>Planet</a> without an owner.<p />
  Note: Raiding will only give you access to Rare Resources, the probability of the resources you steal will depend on the <a href='/en/Race/Races.aspx'>Race</a> of
  the owner of the <a href='/en/Universe/Planets.aspx'>Planet</a>.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li>Score : +5500</li><li><a href='/en/PirateQuests.aspx'>Pirate</a> : +30</li><li><a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a> : +600</li><li><a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>