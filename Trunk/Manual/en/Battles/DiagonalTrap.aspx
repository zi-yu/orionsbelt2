<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Diagonal Trap
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Tactics</h2><ul><li><a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li><li><a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a></li><li><a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a></li><li><a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a></li><li><a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Diagonal Trap</h1>
<div class="content">
    The <a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a> is a tactic that aims to take advantage of the movement limitations of the
    <a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a> units, for example: <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>, <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>, <a class='doomer' href='/en/Unit/Doomer.aspx'>Doomer</a> or <a class='interceptor' href='/en/Unit/Interceptor.aspx'>Interceptor</a>. 
    <p />
    The <a href='/en/UnitIndex.aspx'>Combat Units</a> with <a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a> can be stuck without any way to escape if they have enemy <a href='/en/UnitIndex.aspx'>Combat Units</a>
    on all the possible movement squares. A unit can only attack to the front, so they become completely 
    vulnerable.
    <p />
    The following example shows a <a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a> on four corners:

    <img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Diagonal Trap Example" />

    And this example shows a <a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a> on the extremity of the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>:
    
    <img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Diagonal Trap Example" />

  You should be very careful when  moving your <a href='/en/UnitIndex.aspx'>Combat Units</a> with <a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a> to an extremity of the
  <a href='/en/Battles/GameBoard.aspx'>Game Board</a>. Not only do they loose 50% mobility, they also become very much open to a <a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a>.

  <h2>How to fight the Diagonal Trap?</h2>
  The best way to fight it is just to avoid completely the enemy's trap. However, if you opponent manages
  to apply the trap, the only way to escape is using other <a href='/en/UnitIndex.aspx'>Combat Units</a> to destroy the ones that
  form the trap.
    </div>

</asp:Content>