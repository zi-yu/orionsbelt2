<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Own one planet level 1 on the hot zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Own one planet level 1 on the hot zone" runat="server" /></h1>
	
	<div class="description">
		Own one <a href='/en/Universe/Planets.aspx'>Planet</a> in the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>.
  Conquering Planets on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> is just about the same as conquering Planets on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>, there's only one catch. The <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> is
  a public zone, that means you'll be competing with other Players for Planets.<p />
  The <a href='/en/Universe/Planets.aspx'>Planet</a> you want to conquer may already be possession of someone else. In this case two things can happen: the <a href='/en/Universe/Planets.aspx'>Planet</a> you are trying to conquer has
  no defenses (the <a href='/en/Universe/Planets.aspx'>Planet</a> has no Defense <a href='/en/Universe/Fleet.aspx'>Fleet</a>), or the <a href='/en/Universe/Planets.aspx'>Planet</a> does have defenses.<p />
  In the first case you immediatly gain ownership of the <a href='/en/Universe/Planets.aspx'>Planet</a> in question, just like conquering in the <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>. On the second case the <a href='/en/Universe/Fleet.aspx'>Fleet</a> you used
  to try and conquer the Planet will enter in a Battle with the defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> of the <a href='/en/Universe/Planets.aspx'>Planet</a>. The Player who gains the <a href="../Battles/BattleConcepts.aspx">Battle</a> will
  be the owner of the <a href='/en/Universe/Planets.aspx'>Planet</a>.<p />
  Note that <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> planets are different from your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets, on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> planets you will only be able to build one Facility,
  <a href="../Facility/Extractor.aspx">Extractors</a>.
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Score : +80</li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a> : +2</li><li><a class='seeker' href='/en/Unit/Seeker.aspx'>Seeker</a> : +3</li></ul>
	</div>
	
</asp:Content>