<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Finde ein Wurmloch in deiner Privat-Zone und benutze es um in die öffentliche Zone zu reisen
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Finde ein Wurmloch in deiner Privat-Zone und benutze es um in die öffentliche Zone zu reisen" runat="server" /></h1>
	
	<div class="description">
		Sobald du alle <a href='/de/Universe/Planets.aspx'>Planeten</a> in deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> besiedelt hast, ist der einzige Weg zusätzliche Planeten zu erobern, die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> zu verlassen. Es gibt nur einen einzigen Weg zur <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a>. Du muss durch das [Wormhole] gehen das sich in deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> befindet, es gibt absolut keinen anderen Weg tausende von Lichtjahren zurückzulegen.
  <p>
  Dein <a href='/de/Quests.aspx'>Mission</a> ist das <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> zu finden wie in dem folgenden Bild und durch das Wurmloch zu gehen um in die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> zu gelangen.
  <img class="block" src="/Resources/Images/en/Wormhole.png" alt="Worm Hole" title="Worm Hole" /></p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>