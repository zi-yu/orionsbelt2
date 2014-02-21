<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Eagle Strike
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Tactics</h2><ul><li><a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li><li><a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a></li><li><a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a></li><li><a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a></li><li><a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Eagle Strike</h1>
<div class="content">
    The <a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a> tactic aims to eliminate on the first turns some weak adversary <a href='/en/UnitIndex.aspx'>Combat Units</a> that
    present a threat in the future. This tactic sacrifices small groups of <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> to destroy:
    <ul><li>
    <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> - that can destroy important <a href='/en/UnitIndex.aspx'>Combat Units</a>, not to mention the always present <a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a>
  </li><li><a class='rain' href='/en/Unit/Rain.aspx'>Rain</a> - With a big bonus against <a href='/en/Battles/Heavy.aspx'>Heavy</a> units, the <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a> is a relevant threat</li><li><a class='seeker' href='/en/Unit/Seeker.aspx'>Seeker</a> - With a great bonus against <a href='/en/Battles/Medium.aspx'>Medium</a> units, the <a class='seeker' href='/en/Unit/Seeker.aspx'>Seeker</a> is also a great threat</li><li>Groups with large amounts of <a href='/en/Battles/Light.aspx'>Light</a> units, that can be used as <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li></ul>
    All these <a href='/en/UnitIndex.aspx'>Combat Units</a> can make a lot of damage to our <a href='/en/Universe/Fleet.aspx'>Fleet</a>, but they are very weak. That's why we
    allocate small groups of <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> to destroy them.
    <p />
    The preparation for an <a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a> begins on the <a href='/en/Battles/Deploy.aspx'>Deploy</a>. You should place 2/3 groups of <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>
    on the front row. On your first turn, move those groups one square. Example:

    <img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

    As you can see, the <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> groups pose a threat to the adversary <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a> and <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>. And it'll be
    very hard for the opponent to protect both groups. And even if he can, he probabilly won't be
    able to perform any other movements.
    
    <p />
    
    The <a class='kahuna' href='/en/Unit/Kahuna.aspx'>Kahuna</a> can also be considered instead of the <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>, but it won't be so effective.

  </div>

</asp:Content>