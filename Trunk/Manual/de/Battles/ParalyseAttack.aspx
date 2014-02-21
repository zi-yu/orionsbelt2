<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attacke zum Paralysieren
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Attacke zum Paralysieren</h1>
	<div class="content">
    <a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a> ist ein sehr mächtiger Angriff. Eine einzige Einheit mit dieser Stärke kann die 
    Benutzung von einer Gruppe von feindlichen Einheiten verhindern ( Angriff und Bewegung) während 
    einer Schlacht-Runde. Das kann sehr nützlich sein um wichtige Einheiten zu blocken und/oder sie 
    langsam zerstören oder um das Passieren von wichtigen Einheiten zu verhindern.
    <p>
    Beachte dass die Einheit in deiner Runde nicht mehr paralysiert ist. Also wenn du eine Einheit 
    paralysieren willst (besonders die mit <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> un [ParalyseAttack] - wie die <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a>) 
    dann vergiss nicht die Ziel-Einheit zuerst zu paralysieren, von den Seiten oder von 
    hinten anzugreifen.
    </p><p>
    Hier ist ein Bild das zeigt wie eine <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a> einen <a class='doomer' href='/de/Unit/Doomer.aspx'>Doomer</a> angreift:
    <img class="block" src="/Resources/Images/Paralyse.png" alt="Paralyse Attack" /></p></div>
</asp:Content>