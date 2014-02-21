<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Fracht abladen
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Fracht abladen</h1>
	<div class="content">
  <p>Du kannst die Fracht einer Flotte nur dann entladen wenn diese Flotte in der Nähe eines Planeten ist, wie in dem folgenden Bild:</p>
  <img src="/Resources/Images/UnloadCargo1.png" alt="Flotte in der Nähe eines Planeten" title="Flotte in der Nähe eines Planeten" />
  <p>Um die Fracht einer Flotte abzuladen, gibt es zwei Möglichkeiten:</p>
  <ul>
    <li>
      <p>Wenn die Flotte wie in dem Bild oben (in der Nähe eines Planeten das du besitzt), kannst du zum Flotten-Menü deines Planeten gehen und den Knopf anklicken "Entlade fracht":</p>
      <img src="/Resources/Images/en/UnloadCargo2.png" style="width: 450px;" alt="Unload Cargo" title="Unload Cargo" />
    </li>
    <li>
      <p>Alternativ dazu, kannst du auch die Bewegungs-Optionen deiner Flotte benutzen:</p>
      <img src="/Resources/Images/en/UnloadCargo3.png" alt="Unload Cargo" title="Unload Cargo" />
      <p>Mit dieser Option wird die Flotte sich auf den Planeten zubewegen und automatisch die Fracht entladen.</p>
    </li>
  </ul>
</div>
</asp:Content>