<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rückschlag
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Rückprall</h1>
	<div class="content">
    Der <a href='/de/Battles/Rebound.aspx'>Rückprall</a> ist der Angriff wo die Angriffsstärke nicht verschwendet wird. Wenn sie zu gross ist  
    um die erste Reihe von <a href='/de/UnitIndex.aspx'>Einheiten</a> zu zerstören, geht die übriggebliebene Power zu den <a href='/de/UnitIndex.aspx'>Einheiten</a> die 
    unmittelbar hinter der ersten Reihe von den attackierten <a href='/de/UnitIndex.aspx'>Einheiten</a> stehen. <p><img class="block" src="/Resources/Images/Rebound.png" alt="Rebound" />

   In diesem Bild kann man sehen wie die <a class='fenix' href='/de/Unit/Fenix.aspx'>Fenix</a> die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> attackiert, stell dir vor das der 
  <a class='fenix' href='/de/Unit/Fenix.aspx'>Fenix</a> Angriff 10000 ist und der Schutz der <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> nur 8000
   , dann erhält die <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> einen Schaden von 2000 (10000 - 8000 = 2000). Aber wenn die <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> 
   nicht unmittelbar hinter den <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> wären, würden sie keinen Schaden erhalten, wenn dort einen 
  oder mehrere Vierecke stünden zwischen den <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> und <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a>.
  </p></div>
	
</asp:Content>