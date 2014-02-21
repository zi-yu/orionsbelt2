<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Turniere
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kriegs-Zone</h2><ul><li><a href='/de/Battles/Tournaments.aspx'>Turniere</a></li><li><a href='/de/Battles/Ladder.aspx'>Rangliste</a></li><li><a href='/de/Battles/Friendly.aspx'>Freundliches Match</a></li><li><a href='/de/Battles/ELO.aspx'>ELO Rangliste</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Turniere</h1>
	<div class="content">
    Die <a href='/de/Battles/Tournaments.aspx'>Turniere</a> sind die ultimativen Schlachtfelder für <a href='http://www.orionsbelt.eu'>Orion's Belt</a> Spieler. Hier wirst du gegen die 
    besten Spieler antreten und du wirst dich selbst beweisen müssen um zu gewinnen. Du kannst an 
    <a href='/de/Battles/Regicide.aspx'>Königsmord</a> und <a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a> Turniere teilnehmen.
    Wenn du gut bist auf Turnieren erhöht das dein <a href='/de/Commerce/Orions.aspx'>Orions</a> Reichtum.
    
    <h2>Turnier Strukturen</h2>
    Es gibt verschiedene Phasen in einem Turnier. Als allererstes  kann man sich auf ein Turnier 
    einschreiben. Wenn du den Anforderungen entspricht
    wirst du in Lage sein dem Turnier beizutreten und du wirst auf einen von zehn Pots plaziert . 
    Sobald das Turnier anfängt, startet die Gruppen-Phase.
    <p>
    In der Gruppen-Phase, kommen die ersten 3 Spieler in die nächste Runde. Wir können vielleicht auch 
    andere Spieler holen für die Playoffs.
    </p><p>
    Nach der Gruppen-Phase haben wir die Playoffs. Wenn du verlierst, bist du draussen!
  </p></div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>