<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Missionen und Berufe
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Missionen und Berufe</h1>
<div class="description">
    Am Anfang, wirst du einige <a href='/de/Quests.aspx'>Missionen</a> haben die dich durch das Spiel führen und dir die 
    Grundkonzepte aufzeigen.
    Danach , kannst du bestimmte <a href='/de/Quests.aspx'>Missionen</a> für eine gegebene <a href='/de/Quests.aspx#Professions'>Beruf</a> erledigen. <a href='/de/Quests.aspx'>Missionen</a> sind im 
    Prinzip ein Weg um dich zu unterhalten und dich beschäftigt zu halten während du spielst. Du 
    musst keine <a href='/de/Quests.aspx'>Missionen</a> erledigen um in <a href='http://www.orionsbelt.eu'>Orion's Belt</a> erfolgreich zu sein, aber du wirst schnell besser 
    werden im Spiel, wenn du es tust.
    <p>
    Eine Mission ist definiert durch ein Ziel und eine Belohnung. Wenn du das definierte Ziel 
    erreichst wirst du die definierte Belohnung erhalten , so einfach ist das.
    </p><p>
    Das Spiel bietet dir eine Menge Auswahl an Missionen: du kannst andere Spieler angreifen, <a href='/de/Universe/Raids.aspx'>Plünderung</a> 
    (plündern) auf ihren Planeten, oder sogar <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> oder <a href='/de/BountyHunterQuests.aspx'>Kopfgelder</a> akzeptieren.
  </p></div>
<a name="Types" id="Types"></a>
<h3>Quest Types</h3>
<div class="description">
    Es gibt zwei verschiedene Arten von Missionen:
    <ul><li><b>Checkpoint Quests</b> - Auf diesen Missionen muss du ein gewisses Ziel erreichen um 
    sie erfolgreich zu beenden. Du musst sie nicht akzeptieren. Beispiel: auf der
    <a href='/de/Quest/ColonizeOnePlanetQuest.aspx'>Besiedle einen weiteren Planeten in deiner Privat-Zone</a>, brauchst du nur zu
    <a href='/de/Universe/Colonize.aspx'>Besiedeln</a> einen Planeten um die Mission zu beenden.
  </li><li><b>Task Quests</b> - Diese Missionen haben ein Zeitintervall (der ev. limitiert ist oder 
    nicht). Du muss sie akzeptieren und nur danach zählen deine Aktionen um die Mission zu beenden. 
    Beispiel: Auf der <a href='/de/Quest/FinishABattleQuest.aspx'>Beende eine Schlacht in der öffentlichen Zone</a>
    musst du die Mission akzeptieren, dann in den Kampf gehen, und nur dann die Mission beenden.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Professions</h2>
<div class="description">
    Eine Profession ist der Pfad den du folgen magst um deinen Charakter im Spiel zu definieren.
    Du kannst machen was du willst, aber du magst auch gewissen Aktionen folgen und effizienter in 
    einer Profession werden. Das wird dir Zugang verschaffen zu besseren <a href='/de/Quests.aspx'>Missionen</a> mit grösseren 
    Belohnungen.
    <p>
    Es gibt 3 Haupt-Professionen, und du solltest nur eine von ihnen wählen.
    Du kannst Aktionen für alle <a href='/de/Quests.aspx#Professions'>Berufe</a> zu jeder gegeben Zeit vollführen, aber wenn du es so 
    tust wirst du nicht in der Lage sein in einer spezifischen <a href='/de/Quests.aspx#Professions'>Beruf</a> besser zu werden
    und die damit verbundenen Vorteile zu ziehen. Deshalb, solltest du eines der folgenden Berufe 
    wählen:
    </p><ul><li><a href='/de/MerchantQuests.aspx'>Händler</a> - macht <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> und konzentriert sich auf deine Wirtschaft</li><li><a href='/de/PirateQuests.aspx'>Pirat</a> - Angreifen, <a href='/de/Universe/Raids.aspx'>Plünderung</a>, der Böse sein! Du muss nichts bauen, nur stehlen
    it!</li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a> - das ist ein guter Typ, er wird jeden <a href='/de/PirateQuests.aspx'>Pirat</a> jagen um das
    <a href='/de/Universe/Default.aspx'>Universum</a> sicherer zu machen</li></ul>
    Du kannst auch folgende sekundäre <a href='/de/Quests.aspx#Professions'>Berufe</a> folgen:
    <ul><li><a href='/de/ColonizerQuests.aspx'>Siedler</a> - richtet sich auf Besiedeln aus oder Planeten erobern und verwalten </li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a> - suche das Universum nach <a href='/de/Universe/Arenas.aspx'>Arenen</a> und werde zum ultimativen Gladiator</li></ul></div>
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>