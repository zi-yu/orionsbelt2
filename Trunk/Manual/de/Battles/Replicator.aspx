<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Replikator
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Replikator</h1>
	<div class="content">
    <a href='/de/Battles/Replicator.aspx'>Replikator</a> ist der Angriff der die Zahlen auf jeder Seite ändern kann. Wenn eine Einheit mit 
    diesem Special-Move angreift, repliziert sie sich mehrere Male, äquivalent
    zu der Anzahl von Einheiten die du zerstörst. wenn du 6 einheiten zerstörst, wirst du 6 mal 
    replizieren.
    <p>
    Dieser Special-Move funktioniert nur wenn die angegriffene Einheit von der gleichen Kategorie ist 
    wie oben. Beispiel: eine <a href='/de/Battles/Medium.aspx'>Medium</a> Einheit mit <a href='/de/Battles/Replicator.aspx'>Replikator</a> repliziert nur wenn das Ziel eine 
    <a href='/de/Battles/Medium.aspx'>Medium</a> oder <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheit ist.
    </p><p>
    Die einzige Einheit die diese Attacke hat ist der <a class='stinger' href='/de/Unit/Stinger.aspx'>Stachel</a>. Das bedeutet das diese Einheit nur 
    gegen <a href='/de/Battles/Medium.aspx'>Medium</a> und <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten repliziert.
   </p></div>
</asp:Content>