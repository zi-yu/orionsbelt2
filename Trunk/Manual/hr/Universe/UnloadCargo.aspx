<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Istovari Teret
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Istovari Teret</h1>
	<div class="content">
  <p>Možete istovariti teret iz flote samo kada je ta flota blizu planetu, kao na sljedećoj slici :</p>
  <img src="/Resources/Images/UnloadCargo1.png" alt="Fleet near a planet" title="Fleet near a planet" />
  <p>Da istovarite teret flote postoje dva načina:</p>
  <ul>
    <li>
      <p>Ako je slika kao na slici poviše (blizu planeta kojega vi posjedujete), možete ići u izbornik flote na vašem planetu i kliknuti na gumb "Unload Cargo":</p>
      <img src="/Resources/Images/en/UnloadCargo2.png" style="width:450px;" alt="Unload Cargo" title="Unload Cargo" />
    </li>
    <li>
      <p>Alternativno, možete se koristiti mogućnosti pokreta vaše flote:</p>
      <img src="/Resources/Images/en/UnloadCargo3.png" alt="Unload Cargo" title="Unload Cargo" />
      <p>U ovoj mogućnosti flota će krenuti prema planetu i isotvariti će teret automatski.</p>
    </li>
  </ul>
</div>
</asp:Content>