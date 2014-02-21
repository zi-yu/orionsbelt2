<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Descargar Carga
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Descargar Carga</h1>
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