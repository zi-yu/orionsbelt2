<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gegenangriff
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gegenangriff</h1>
	<div class="content">
    Es ist gut den<a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> Angriff zu haben, ist aber nicht essentiell um ein Gefecht zu 
    gewinnen. Was passiert ist wenn eine Gruppe von <a href='/de/UnitIndex.aspx'>Einheiten</a> mit dieser Charakteristik attackiert wird
    , werden die <a href='/de/UnitIndex.aspx'>Einheiten</a> in dieser Gruppe die überleben, automatisch angreifen ohne <a href='/de/Battles/Movement.aspx'>Beweglichkeit</a> zu 
    benutzen. 
    <p>
    Aber dieser Angriff hat einige Limitationen. Es wird wahrscheinlich nicht auf jeden Angriff ein 
    Gegenangriff gestartet, die nächsten Bilder helfen dir diese Limitationen zu verstehen:

    </p><div class="block"><img style="margin-right: 90px;" src="/Resources/Images/strikeBack1.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack4.png" alt="Strike Back" /></div><br /><div class="block"><img style="margin-right: 34px;" src="/Resources/Images/strikeBack3.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack2.png" alt="Strike Back" /></div><br />
  Die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> ist eine Einheit die <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> hat und in allen Beispielen, werden wir dir 
  Angriffe auf die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> zeigen.
  Auf dem ersten Bild benutzt <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> kein <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> weil sie von <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a> angegriffen werden 
  die die Fähigkeit [Paralyze] hat, die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> werden kein <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> benutzen weil sie 
  paralysiert sind. <p>
    Auf dem zweiten Bild werden die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> von <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> angegriffen, aber <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> und <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> 
    haben <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a> zwischen ihnen, und so wird die <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> den <a href='/de/Battles/Catapult.aspx'>Katapult</a> benutzen, der die 
    [Pretorian <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> Fähigkeit blockieren wird.</p><p>
    Der dritte Angriff verursacht auch kein <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> weil die <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> nicht 
    frontal angreifen. </p><p>
  Zu guter Letzt, die vierte Attacke ist die einzige die <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> verursacht, weil der 
  <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a> die <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> frontal angreift und nicht die Fähigkeit hat <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> zu verhindern. </p><p>
  Es gibt noch zwei Situationen in denen <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> nicht aktiviert wird. Ein Fall ist wenn die 
  Einheit die <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> hat nicht genügend <a href='/de/Battles/Range.aspx'>Reichweite</a> hat um <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> zu benutzen. Zum Beispiel 
  wenn <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a> von  <a class='nova' href='/de/Unit/Nova.aspx'>Nova</a> attackiert wird in einer <a href='/de/Battles/Range.aspx'>Reichweite</a> von 5, werden sie nicht auf den 
  Angriff antworten weil sie nur eine <a href='/de/Battles/Range.aspx'>Reichweite</a> von 3 haben. Die letzte Situation wo der <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> 
  nicht aktiviert wird, ist wenn die Einheit (z.B.: <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a>) mit  <a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a> von einer 
  <a href='/de/Battles/Rebound.aspx'>Rückprall</a> Attacke getroffen wird.
    </p></div>
	
</asp:Content>