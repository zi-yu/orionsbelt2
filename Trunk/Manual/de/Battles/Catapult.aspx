<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Katapult
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Katapult Attacke</h1>
<div class="content">
    Wahrscheinlich ist der <a href='/de/Battles/Catapult.aspx'>Katapult</a> Angriff is der unaufhaltbarste von allen, weil auch wenn <a href='/de/UnitIndex.aspx'>Einheiten</a> 
    existieren die als <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> dienen, sind sie in diesem Fall nutzlos. <p>
    Der <a href='/de/Battles/Catapult.aspx'>Katapult</a> ignoriert jede Einheit die sich in ihrer Front befindet, Freund oder Feind, und ist 
    in der Lage jede feindliche Einheit die in ihrer  <a href='/de/Battles/Range.aspx'>Reichweite</a> anzugreifen. Ein Beispiel zeigt das 
    folgende Bild:

    <img class="block" src="/Resources/Images/Catapult.png" alt="Catapult" />

    Dieser Angriff ist perfekt für chirurgische Angriffe hinter einer Verteidigungs-Barriere. </p><p>
    Ein anderes Feature das den Angriff sehr interessant macht, ist das der <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> der 
    attackierten Einheit ignoriert werden kann, wenn die Einheit die  
    schiesst eine andere Einheit zwischen ihr und der angegriffenen Einheit hat.

  </p></div></h1>
	
</asp:Content>