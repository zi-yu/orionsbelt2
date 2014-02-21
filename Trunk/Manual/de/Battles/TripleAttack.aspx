<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Dreifach-Attacke
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Dreifach-Attacke</h1>
	<div class="content">
    <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a> ist ein zerstörender Angriff der in der Lage ist drei Gruppen von Einheiten mit 
    nur einem einzigen Schlag zu zerstören. Wenn du eine Gruppe mit <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a> angreifst, 
    erhalten die benachbarten Einheits-Gruppen einen <b>50%</b> Schaden von dem erhaltenen Schaden 
    des Ziels.
    <p>
    Dieser Angriff ist ideal um die<a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> des Feindes zu zerstören und auch um die 
    <i>unreachable</i> Gruppen zu erreichen.
    Hier ein Beispiel eines Angriffs:

    <img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />

    Der ganze <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> des Feindes wird zerstört durch diesen <a class='driller' href='/de/Unit/Driller.aspx'>Bohrer</a>. Das ist so weil der <a class='driller' href='/de/Unit/Driller.aspx'>Bohrer</a> 
    <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a> hat und weil die <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> Gruppen sich exakt auf diesen Positionen befinden, 
    neben dem Ziel liegend, und senkrecht zum <a class='driller' href='/de/Unit/Driller.aspx'>Bohrer</a>.

    </p><p>
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> mit <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a> sind auch in der Lage die <i>unreachable</i> Gruppen zu 
    erreichen. Beachte das folgende Beispiel. Die <a class='fenix' href='/de/Unit/Fenix.aspx'>Fenix</a> des Feindes ist wohl beschützt durch 
    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>, die einen Direktangriff verhindern.
    Dennoch kann der <a class='driller' href='/de/Unit/Driller.aspx'>Bohrer</a> sich einschleichen und der <a class='fenix' href='/de/Unit/Fenix.aspx'>Fenix</a> Schaden zufügen mit <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a>:

    <img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></p></div>
	
</asp:Content>