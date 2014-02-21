<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Spezial
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Spezialeinheiten</h1>
<div class="content">
    Eine [Spezial] Einheit wird normalerweise für bestimmte Zwecke benutzt. Sie können auf Planeten gebaut werden und sind nur verfügbar in bestimmten Spiel-Typen.
    <p>
    Spezialeinheiten Liste:
  </p></div>
	<ul class='imageList'><li><a href='/de/Unit/Flag.aspx'><img class='flag' src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Flagge' /></a></li><li><a href='/de/Unit/Flag.aspx'><img class='flag' src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Flagge' /></a></li></ul>
	
</asp:Content>