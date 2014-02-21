<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Firing Squad
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Tactics</h2><ul><li><a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li><li><a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a></li><li><a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a></li><li><a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a></li><li><a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Firing Squad</h1>
<div class="content">
    The <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a> was a popular battle strategy used a long time ago on <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. In the old days,
    it was possible to build the <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a> very early in the game. The <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a> is a
    very powerfull <a href='/en/Battles/Heavy.aspx'>Heavy</a> unit that has a <a href='/en/Battles/Range.aspx'>Range</a> of 6. Many players started to concentrate on building
    only crusaders to put them on the front row. With a <a href='/en/Battles/Range.aspx'>Range</a> of 6 they could reach all the
    <a href='/en/Battles/GameBoard.aspx'>Game Board</a>, that's why we call it <i>firing squad</i>.
    <p /><h2>Example Battle</h2>
    The <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a> can be a very complex tactic for your opponent do defend, but it can also be
    very easy to dispel. Let's analyse the following battle where one of the players choose a <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a>:
  </div>

	<p><iframe class='battle' src="/Resources/Battles/FiringSquad1.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
	<div class="content">
  <p>
  As we can see, the opponent can't resist the power of the <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a>. This tactic only requires
  a large amount of long range <a href='/en/UnitIndex.aspx'>Combat Units</a> on your <a href='/en/Universe/Fleet.aspx'>Fleet</a> to succeed.
    </p>
  <h2>Changes to the Game</h2>
  <p>
  <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a> become a very mainstream tactic, and the game had to change some of it's rules
  to attenuate this tactic:
  <ul><li>
  The damage done by units will be attenuated based on the distance. This way the <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a>
  won't do so much damage to the opponent's defenses
    </li><li>We created several <a href='/en/Battles/Light.aspx'>Light</a> units with special bonus against <a href='/en/Battles/Heavy.aspx'>Heavy</a> units.</li></ul></p>
  <h2>How to Fight a Firing Squad</h2>
  <p>
  Even with the changes to the game, <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a> looks like an ideal, unbeatable tactic.
  However, every average player can easilly beat the <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a>, even if that means loosing a lot of
  <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    </p>
  <p>
  The following battle ilustrates on strategy that can be used to beat the <a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a>.
  As one can see, it only takes a <a href='/en/Universe/Fleet.aspx'>Fleet</a> with some <a href='/en/Battles/Light.aspx'>Light</a> units serving as <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>
  and a small amount of <a href='/en/Battles/Medium.aspx'>Medium</a> units to beat a large quantity of <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a>.
    </p>
</div>
	
	<p><iframe class='battle' src="/Resources/Battles/FiringSquad2.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
</asp:Content>