<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Licht
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Light Einheiten</h1>
<div class="content">
    <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten sind dafür bekannt dass sie die schnellsten aber auch die schwächsten im Spiel   
    sind. Normalerweise, hat eine <a href='/de/Battles/Light.aspx'>Licht</a> Einheit
    <a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a> und <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> von 1, und sind günstiger als <a href='/de/Battles/Medium.aspx'>Medium</a> und <a href='/de/Battles/Heavy.aspx'>Schwer</a> [Kampfeinheiten].
    <p>
    Jede ausgewogene [Flotte] hat einen substantiellen Anteil von <a href='/de/Battles/Light.aspx'>Licht</a> Einheinten, hauptsächlich 
    weil sie nötig sind als <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>, eine der meistbenutzten <a href='/de/Battles/BattleTactics.aspx'>Kampf-Taktiken</a> in <a href='http://www.orionsbelt.eu'>Orion's Belt</a>.
    </p><p>
    Aber <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten sind nicht die einzigen die geopfert werden. Sie sind sehr mächtige 
    Einheiten die ganz leicht jede grössere Einheit niederschlagen kann.
    </p><p>
    <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten:
  </p></div>
	<ul class='imageList'><li><a href='/de/Unit/Raptor.aspx'><img class='raptor' src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /></a></li><li><a href='/de/Unit/Rain.aspx'><img class='rain' src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Regen' /></a></li><li><a href='/de/Unit/Cypher.aspx'><img class='cypher' src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /></a></li><li><a href='/de/Unit/Reaper.aspx'><img class='reaper' src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /></a></li><li><a href='/de/Unit/Panther.aspx'><img class='panther' src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panther' /></a></li><li><a href='/de/Unit/Seeker.aspx'><img class='seeker' src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Sucher' /></a></li><li><a href='/de/Unit/Egg.aspx'><img class='egg' src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Ei' /></a></li><li><a href='/de/Unit/Maggot.aspx'><img class='maggot' src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Made' /></a></li><li><a href='/de/Unit/DarkRain.aspx'><img class='darkrain' src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Dunkler Regen' /></a></li><li><a href='/de/Unit/Toxic.aspx'><img class='toxic' src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxisch' /></a></li><li><a href='/de/Unit/Anubis.aspx'><img class='anubis' src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /></a></li><li><a href='/de/Unit/Jumper.aspx'><img class='jumper' src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Springer' /></a></li><li><a href='/de/Unit/Samurai.aspx'><img class='samurai' src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /></a></li><li><a href='/de/Unit/Interceptor.aspx'><img class='interceptor' src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Abfangjäger' /></a></li><li><a href='/de/Unit/Sentry.aspx'><img class='sentry' src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /></a></li></ul>
	
</asp:Content>