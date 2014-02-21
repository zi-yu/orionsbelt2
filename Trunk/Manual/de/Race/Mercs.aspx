<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Rassen</h2><ul><li><a href='/de/Race/LightHumans.aspx'>Utopians</a></li><li><a href='/de/Race/DarkHumans.aspx'>Renegades</a></li><li><a href='/de/Race/Bugs.aspx'>Levyr</a></li><li><a href='/de/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>Sie kommen aus den Tiefen des Universums. Sie sind eine Gruppe von Piraten, Söldnern, Dieben... nenne sie wie immer du willst.</p>
  <p>Sie bedeuten Zerstörung. Sie greifen alles an was in ihre Sichtweite kommt. Mit ihren überlegenen Einheiten, gebaut mit Technologie die durch die Jahrzehnte hindurch gestohlen wurde, sind sie ein erbitterter Gegner.</p>
  <p>Geführt von dem rücksichtslosen Metallic Beard und ihren fast unzerstörbaren Einheiten, stellen sie eine echte Bedrohung für alle Rassen im Universum dar.</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/de/Unit/Reaper.aspx'>Reaper</a></li><li><a class='scourge' href='/de/Unit/Scourge.aspx'>Scourge</a></li><li><a class='titan' href='/de/Unit/Titan.aspx'>Titan</a></li><li><a class='silverbeard' href='/de/Unit/SilverBeard.aspx'>Silberbart</a></li><li><a class='metallicbeard' href='/de/Unit/MetallicBeard.aspx'>Metallischer Bart</a></li><li><a class='walker' href='/de/Unit/Walker.aspx'>Walker</a></li><li><a class='sentry' href='/de/Unit/Sentry.aspx'>Sentry</a></li></ul>
	</div>
	
</asp:Content>