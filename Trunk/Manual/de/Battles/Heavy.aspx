<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Schwer
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Heavy Einheiten</h1>
<div class="content">
    <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten sind die stärksten Einheiten von allen. Sie sind die <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> die am 
    mächtigsten sind, sowohl im Angriff, als auch in der Verteidigung, sie werden nur limitiert durch 
    die <a href='/de/Battles/Movement.aspx'>Beweglichkeit</a> und <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a>. <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten sind auch bekannt wegen ihrer grossen 
    <a href='/de/Battles/Range.aspx'>Reichweite</a>.
    <p>
    Natürlich haben wir <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> die <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten sind und die nicht genau diesem Schema 
    folgen. Zum Beispiel den <a class='doomer' href='/de/Unit/Doomer.aspx'>Doomer</a>,
    Die <a class='blackwidow' href='/de/Unit/BlackWidow.aspx'>Schwarze Witwe</a> und der <a class='taurus' href='/de/Unit/Taurus.aspx'>Taurus</a> haben nur eine <a href='/de/Battles/Range.aspx'>Reichweite</a> von 3, aber sie werden 
    kompensiert mit zusätzlicher Freiheit an <a href='/de/Battles/Movement.aspx'>Beweglichkeit</a>, oder extra Kräfte.
    </p><p>
    <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten müssen extra aufpassen auf <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> und <a class='darkrain' href='/de/Unit/DarkRain.aspx'>Dunkler Regen</a>, weil sie einen 
    speziellen Angriffs-Bonus haben..
    </p><p>
    Liste der <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten:
  </p></div>
	<ul class='imageList'><li><a href='/de/Unit/Fist.aspx'><img class='fist' src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Faust' /></a></li><li><a href='/de/Unit/Nova.aspx'><img class='nova' src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /></a></li><li><a href='/de/Unit/HiveKing.aspx'><img class='hiveking' src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Bienenstock König' /></a></li><li><a href='/de/Unit/Bozer.aspx'><img class='bozer' src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /></a></li><li><a href='/de/Unit/Doomer.aspx'><img class='doomer' src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Doomer' /></a></li><li><a href='/de/Unit/Titan.aspx'><img class='titan' src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /></a></li><li><a href='/de/Unit/BlackWidow.aspx'><img class='blackwidow' src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Schwarze Witwe' /></a></li><li><a href='/de/Unit/CaptainWolf.aspx'><img class='captainwolf' src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='Kapitän Wolf' /></a></li><li><a href='/de/Unit/Fenix.aspx'><img class='fenix' src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fenix' /></a></li><li><a href='/de/Unit/Taurus.aspx'><img class='taurus' src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taurus' /></a></li><li><a href='/de/Unit/CommanderFox.aspx'><img class='commanderfox' src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Kommander Fox' /></a></li><li><a href='/de/Unit/HeavySeeker.aspx'><img class='heavyseeker' src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Mega Sucher' /></a></li><li><a href='/de/Unit/SilverBeard.aspx'><img class='silverbeard' src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silberbart' /></a></li><li><a href='/de/Unit/DarkTaurus.aspx'><img class='darktaurus' src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Dunkler Taurus' /></a></li><li><a href='/de/Unit/DarkCrusader.aspx'><img class='darkcrusader' src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Dunkler Kreuzfahrer' /></a></li><li><a href='/de/Unit/MetallicBeard.aspx'><img class='metallicbeard' src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallischer Bart' /></a></li><li><a href='/de/Unit/Crusader.aspx'><img class='crusader' src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Kreuzfahrer' /></a></li></ul>
	
</asp:Content>