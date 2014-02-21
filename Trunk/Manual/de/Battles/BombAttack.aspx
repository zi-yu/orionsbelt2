<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bombenattacke
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Bombenattacke</h1>
	<div class="content">
    <a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a> ist wahrscheinlich die mächtigste Attacke im Spiel, wenn ordnungsgemäss ausgeführt. 
    Eine Kampfeinheit die mit <a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a> angreift fügt allen gegnerischen Einheiten Schaden zu die in 
    der Nähe sind. 
    Diese Fähigkeit ist exzellent um die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> des Gegners zu eliminieren oder einer 
    grossen Anzahl von Gruppen Schaden zuzufügen.
    <p>
    Hier ist ein Beispiel einer <a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a> in Aktion:

    <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />
    
    In diesem Beispiel, wird der Schaden dem die Einheit dem Ziel zufügt, auch allen benachbarten 
    Gruppen die <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> haben, zugefügt. Es gibt keine Schadensverminderung.
  </p></div>
	
</asp:Content>