<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Déposer cargainson
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Déposer cargainson</h1>
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