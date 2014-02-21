<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Besiedle einen weiteren Planeten in deiner Privat-Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Besiedle einen weiteren Planeten in deiner Privat-Zone" runat="server" /></h1>
	
	<div class="description">
		Das Ziel dieser Mission ist zu lernen wie man einen <a href='/de/Universe/Planets.aspx'>Planet</a> erobert. In deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> kannst durch nicht von anderen Spielern geplagt werden, also brauchst du dir keine Sorgen zu machen angegriffen zu werden. <p>
  Suche das Universum mit einer <a href='/de/Universe/Fleet.aspx'>Flotte</a> ab um ein <a href='/de/Universe/Planets.aspx'>Planet</a> zu finden. Dann wähle die <a href='/de/Universe/Fleet.aspx'>Flotte</a>, Klicke 
  auf das oberste Ende des <a href='/de/Universe/Planets.aspx'>Planet</a> und erobere. Das folgende Bild zeigt ein Beispiel, und die Mission 
  ist bereit von dir erledigt zu werden.
  <img class="block" src="/Resources/Images/en/colonize.png" alt="Besiedeln" title="Besiedeln" /></p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +5</li></ul>
	</div>
	
</asp:Content>