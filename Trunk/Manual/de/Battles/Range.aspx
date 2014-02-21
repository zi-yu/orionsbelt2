<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Reichweite
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Reichweite der Kampfeinheiten</h1>
<div class="content">
    <a href='/de/Battles/Range.aspx'>Reichweite</a> die Distanz des Angriffs einer Einheit. Jede Einheit kann angreifen, und manche haben  
    einige sehr mächtige Angriffsstärken.
    <p>
    Das folgende Beispiel zeigt den Unterschied der <a href='/de/Battles/Range.aspx'>Reichweite</a> zwischen zwei <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a>: Die
    <a class='crusader' href='/de/Unit/Crusader.aspx'>Kreuzfahrer</a> und die <a class='krill' href='/de/Unit/Krill.aspx'>Krill</a>. Die <a class='crusader' href='/de/Unit/Crusader.aspx'>Kreuzfahrer</a> hat eine <a href='/de/Battles/Range.aspx'>Reichweite</a> von 6, und deshalb kann sie jede 
    Einheit die sich in ihrer Reihe befindet, angreifen. Auf der anderen eite, hat die <a class='krill' href='/de/Unit/Krill.aspx'>Krill</a> nur 
    eine <a href='/de/Battles/Range.aspx'>Reichweite</a> von 3, und deshalb kann sie nur Einheiten angreifen die maximal in einer Distanz von 3 
    Vierecken stehen.
    </p><p>
    Beachte dass wenn du eine andere Einheit zwischen dem Angreifer und dem Ziel hast, wird der Angriff 
    nicht möglich sein, es sei denn der Angreifer hat<a href='/de/Battles/Catapult.aspx'>Katapult</a>.

    <img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></p></div>
	
</asp:Content>