<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Unload Cargo
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Unload Cargo</h1>
	<div class="content">
  <p>You can only unload cargo from a fleet if that fleet is near a planet, like in the following picture:</p>
  <img src="/Resources/Images/UnloadCargo1.png" alt="Fleet near a planet" title="Fleet near a planet" />
  <p>To unload the cargo of a fleet there are two possible ways:</p>
  <ul>
    <li>
      <p>If the fleet is like in the above image (near a planet that you own), you can go the fleet menu of your planet and click in the button "Unload Cargo":</p>
      <img src="/Resources/Images/en/UnloadCargo2.png" style="width:450px;" alt="Unload Cargo" title="Unload Cargo" />
    </li>
    <li>
      <p>Alternatively, you can also use the movement options of your fleet:</p>
      <img src="/Resources/Images/en/UnloadCargo3.png" alt="Unload Cargo" title="Unload Cargo" />
      <p>In this option the fleet will move towards the planet an it will unload all the cargo automatically.</p>
    </li>
  </ul>
</div>
</asp:Content>