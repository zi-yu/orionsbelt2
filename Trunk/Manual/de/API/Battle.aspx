<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kämpfe API
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API und Nützliches</h2><ul><li><a href='/de/API/Battle.aspx'>Kämpfe API</a></li><li><a href='/de/API/UniverseXML.aspx'>Universum XML</a></li><li><a href='/de/API/UnitsJSON.aspx'>Einheiten Spezifikationen</a></li><li><a href='/de/API/Utilities.aspx'>Nützliches von der Orion's Belt Gemeinde</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Kämpfe API</h1>
	<div class="content">
    Der <b>Battle API</b> erlaubt Anwendungen von Drittanbietern Schalchten zu spielen auf <a href='http://www.orionsbelt.eu'>Orion's Belt</a> als 
    ein <i>bot</i>. Du kannst diesen API benutzen um künstliche Intelligenz Bots zu erschaffen oder 
    Spiel Clients die in der Lage sind mit anderen Spielern zu kämpfen oder Bots auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>. 
    Beispiel einer Schlacht:
    
    <img src="/Resources/Images/Battle.png" class="block" /><h2>Contents</h2><ul><li><a href="#Apply">How to Apply</a></li><li><a href="#Overview">Overview</a></li><li><a href="#AskBattles">Ask For Battles</a></li><li><a href="#Deploy">Deploy</a></li><li><a href="#TurnMoves">Turn Moves</a></li><li><a href="#More">More Information</a></li></ul><a name="Apply" id="apply"></a><h2>How to Apply</h2>
    Um in der Lage zu sein eine Anwendung zu entwickeln mit der Schlacht API, musst du uns 
    kontaktieren. Dann werden wir für dich die Entwicklungsumgebung vorbereiten und dir beim Start 
    helfen.
    <p>
    Du kannst uns kontaktieren in dem du die Mail <a href="mailto:manual@orionsbelt.eu">manual@orionsbelt.eu</a> benutzt.

    <a name="Overview" id="Overview"></a></p><h2>Überblick</h2>
    Die Schlacht API ist sehr einfach zu bedienen. Du kannst eine Anwendung erzeugen die mit  
    <a href='http://www.orionsbelt.eu'>Orion's Belt</a> kommuniziert und Gefechts-Bewegungen und -Zustände sendet/erhält.
    Du musst deine Anwendung kodieren um Formierungen und Runden zu machen. Die Grundinteraktion ist 
    folgende:
    <ul><li>#1 Du fragst den Server nach Gefechten, ein XML Dokument mit den Gefechten die du zu 
    spielen hast</li><li>#2 Für jedes erhaltene Gefecht wirst du eine HTTP Anfrage senden zu einer 
    bereitgestellten URL mit einer Formierung oder Bewegungen</li><li>#3 Warte eine Zeitlang und 
    kehre zurück zu Schritt #1</li></ul><p>
    Du hast ein XML Dokument zur Verfügung mit der kompletten <a href="UnitsJSON.aspx">Einheiten-
    Spezifikation</a>. Wenn wir dein bot/client konfigurieren, bist du in der Lage ein <a href='/de/Battles/Friendly.aspx'>Freundliches Match</a> zu 
    erzeugen und dein Bot in Aktion zu testen.

    <a name="AskBattles" id="AskBattles"></a></p><h2>Gefecht Anfrage</h2>
    Das erste Mal wenn du nach Gefechten anfragst, wirst du keine erhalten. Du musst eine <a href='/de/Battles/Friendly.aspx'>Freundliches Match</a> 
    mit deinem Bot erzeugen, und nur dann erhälst du einige Gefechte zum spielen. Um nach Gefechten 
    zu fragen musst du eine HTTP Anfrage senden:
    
    <pre class="code">http://<u>server</u>.orionsbelt.eu/Ajax/Battle/BotBattle.ashx?type=<u>botGetBattles</u>&amp;botId=<u>1111</u>&amp;verificationCode=<u>ABC</u></pre>

    Beachte dass du die Anfrage auf den richtigen Server schicken musst. Du hast ein Bot pro Server, 
    also wenn du auf mehr als einem Server registriet bist wirst du dementsprechend handeln müssen. 
    Du musst zusätzlich die Bot ID und den Bot Verifizierungs-Code angeben.

    <a name="Deploy" id="Deploy"></a><h2>Deploy</h2>
    Der erste Teil des Gefechts ist <a href='/de/Battles/Deploy.aspx'>Positionieren</a>. Wenn du nach Gefechten anfragst indem du die vorige URL 
    benutzt erhälst du sowas wie:
    <pre class="code">  &lt;Battles&gt;
    &lt;Battle id='1339260' state='<u>deploy</u>'&gt;
  &lt;ResponseUrl&gt;http://source_server/Ajax/Battle/BotBattle.ashx&lt;/ResponseUrl&gt;
  &lt;Players&gt;
    &lt;Player id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/Player&gt;
    &lt;Player id='1' ownerId='203'&gt;<u>nunos</u>&lt;/Player&gt;
  &lt;/Players&gt;
  &lt;CurrentPlayer id='0' ownerId='1339159'&gt;Bot001&lt;/CurrentPlayer&gt;
  &lt;Units&gt;
    &lt;Unit quantity='10' name='Raptor' code='rp' /&gt;
  &lt;/Units&gt;
    &lt;/Battle&gt;
  &lt;/Battles&gt;
    </pre>
    Dies ist ein sehr einfaches Gefecht zwischen <u>Bot001</u> und <u>nunos</u>, und du müsstest 
    jetzt formieren. Die Kampf- <a href='/de/Universe/Fleet.aspx'>Flotte</a> hat nur den <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a>, keine <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> sind mehr präsent. 
    Du müsstest jetzt eine Anfrage senden zu <u>ResponseUrl</u> und hinweisen dass du <a href='/de/Battles/Deploy.aspx'>Positionieren</a> 
    möchtest:
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botdeploy</u>&amp;id=<u>1234</u>&amp;moves=<u>p:rp-8_1-2;p:rp-8_2-8;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    Der <u>moves</u> Parameter ist der wichtigiste und hat folgendes Format:
    <pre class="code">p:<u>Einheits_Code</u>-<u>Koordinate</u>-<u>Anzahl</u></pre>
    Du müsstest eine Kette bauen wie diese für jeden Einheiten-Block in der <a href='/de/Battles/Deploy.aspx'>Positionieren</a> Zone . Du hast 
    die Einheiten-Codes auf <a href="UnitsJSON.aspx">Einheiten-Spezifikationen</a>. Nach dem Aufruf 
    der korrekten URL, geht das Gefecht weiter.

    <a name="TurnMoves" id="TurnMoves"></a><h2>Runden-Spielzüge</h2>
    Nach dem <a href='/de/Battles/Deploy.aspx'>Positionieren</a> kannst du wieder nach Gefechten fragen, und nun wirst du deine Spielzüge machen 
    müssen. Beachte dass auf diesen Beispielen nur ein Gefecht zurückgegeben wird, aber du hast 
    mehrere Gefecht zu spielen, du würdest mehrere &lt;Battle/&gt; Elemente erhalten. Wenn deine Runde zu spielen ist, wirst du etwas ähnliches erhalten:
    <pre class="code">  &lt;Battles&gt;
    &lt;Battle id='1339264' state='<u>battle</u>'&gt;
  &lt;ResponseUrl&gt;http://source_server/Ajax/Battle/BotBattle.ashx&lt;/ResponseUrl&gt;
  &lt;Players&gt;
    &lt;Player id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/Player&gt;
    &lt;Player id='1' ownerId='204'&gt;<u>tsousa</u>&lt;/Player&gt;
  &lt;/Players&gt;
  &lt;CurrentPlayer id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/CurrentPlayer&gt;
  &lt;Elements&gt;
    &lt;Element coordinate='2_4' canBeMoved='True' canUseSpecialHabilities='True' 
  id='1' ownerId='204' direction='S' quantity='1' remainingDefense='300' code='rp'/&gt;
    &lt;Element coordinate='8_1' canBeMoved='True' canUseSpecialHabilities='True' 
  id='0' ownerId='1339159' direction='N' quantity='1' remainingDefense='300' code='rp'/&gt;
  &lt;/Elements&gt;
    &lt;/Battle&gt;
  &lt;/Battles&gt;
    </pre>
    Beachte das der Status von <u>deploy</u> zu <u>battle</u> gewechselt hat. Jetzt erhälst du die 
    aktuelle <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> Disposition, jede Einheiten-Gruppe, Anzahl, Koordinate, etc.
    Nachdem deine Spielzüge kalkuliert wurden, müsstest du deine Antworten zurücksenden zum Spiel, 
    indem du die angegebene URL benutzt <u>ResponseUrl</u>. Eine Beispiel-URL würde sein:
    
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botbattle</u>&amp;id=<u>1111</u>&amp;moves=<u>r:7_3-n-w;b:7_3-7_2;m:8_3-8_2-5-n;b:8_2-7_2;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    
    Der <u>moves</u> Parameter ist wie eine Liste von Spielzügen mit der folgenden Syntax:
    
    <table class="table" style="width: 100%; margin-top: 10px; margin-bottom: 10px;"><tbody><tr><th>Type</th><th>Syntax</th><th>Description</th></tr><tr><td>Move</td><td><pre>m:<u>unit_coordinate</u>-<u>destination_coordinate</u>-<u>quantity</u>-<u>direction</u>;</pre></td><td>Moves a unit group from one square to another adjacent square</td></tr><tr><td>Rotate</td><td><pre>r:<u>unit_coordinate</u>-<u>current_direction</u>-<u>next_direction</u>;</pre></td><td>Rotates a unit group; direction can be: N, S, E and W</td></tr><tr><td>Attack</td><td><pre>b:<u>unit_coordinate</u>-<u>target_coordinate</u>;</pre></td><td>Attacks the adversary unit group</td></tr></tbody></table>
    
    Dann ist die Runde deines Gegners. Wenn er fertig ist, erhälst du den neuen <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> Status 
    und du musst dann weitere Spielzüge machen. Das geht so weiter bis die Schalcht nicht vorbei ist. 
    Beachte dass deine Spielzüge nicht mehr als 6 <a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a> kosten dürfen.
    
    <a name="More" id="More"></a><h2>Mehr Information</h2>
    Wenn du Fragen oder Vorschläge hast kontaktiere uns bitte, wir würden dir gerne weiterhelfen.
  </div>
	
</asp:Content>