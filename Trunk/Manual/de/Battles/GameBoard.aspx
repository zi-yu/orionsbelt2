<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Spielbrett
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Spielbrett</h1>
	<div class="content">
    Das <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> ist Ort wo die Kämpfe stattfinden. 
    <p>
    Die gängigste Form der Schlacht, die 1 gegen 1, hat das Spielbrett 8 Vierecke Höhe mal 8 Vierecke
    Breite die eine Summe von 64 Vierecken ergibt (genauso wie ein Schachbrett). 
    </p><p><img class="block" src="/Resources/Images/GameBoard2.png" alt="1 vs 1 Game Board" /></p><p>
    In der 2 gegen 2 Schalcht, hat das Spielbrett 12 Vierecke Höhe mal 12 Vierecke Breite mit einem 
    kleinen Detail: an jeder Ecke, sind vier Vierecke die der Spieler nicht benutzen kann. 
    Deshalb sind nur 128 Vierecke verfügbar.
    <img class="block" src="/Resources/Images/GameBoard4.png" alt="2 vs 2 Game Board" /></p></div>
</asp:Content>