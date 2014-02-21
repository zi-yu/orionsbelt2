<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Besitze ein Planet Level 1 in der öffentlichen Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Besitze ein Planet Level 1 in der öffentlichen Zone" runat="server" /></h1>
	
	<div class="description">
		Besitze ein <a href='/de/Universe/Planets.aspx'>Planet</a> in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a>.
  Planeten zu erobern in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> ist genauso wie Planeten zu erobern in der <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a>, es 
  gibt nur einen Haken. Die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> ist eine öffentliche Zone, das bedeutet das du mit anderen 
  Spielern um die Planeten konkurrieren musst .<p>
  Der <a href='/de/Universe/Planets.aspx'>Planet</a> den du erobern willst mag bereits im Besitz eines anderen sein. In dem Fall können zwei 
  Dinge passieren: der <a href='/de/Universe/Planets.aspx'>Planet</a> den du zu erobern versuchst hat keine Verteidigung (der <a href='/de/Universe/Planets.aspx'>Planet</a> hat 
  keine Verteidiguns- <a href='/de/Universe/Fleet.aspx'>Flotte</a>), oder der <a href='/de/Universe/Planets.aspx'>Planet</a> hat Verteidigungen.</p><p>
  Im ersten Fall wirst du unverzüglich zum Besitzer des <a href='/de/Universe/Planets.aspx'>Planet</a> , wie das Erobern in der 
  <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a>. Im zweiten Fall wird die <a href='/de/Universe/Fleet.aspx'>Flotte</a> mit der du versucht hast den Planeten zu erobern,
   in den Kampf gehen mit der Verteidigungs- <a href='/de/Universe/Fleet.aspx'>Flotte</a> des <a href='/de/Universe/Planets.aspx'>Planet</a>. Der Spieler der gewinnt <a href="../Battles/BattleConcepts.aspx">Battle</a> wird zum Besitzer des <a href='/de/Universe/Planets.aspx'>Planet</a>.</p><p>
  Beachte das die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> Planeten anders sind als deine <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> Planeten, auf den <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> Planeten bist du in der Lage nur ein Gebäude zu bauen,
  <a href="../Facility/Extractor.aspx">Extractors</a>.</p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Spielstand : +80</li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a> : +2</li><li><a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> : +3</li></ul>
	</div>
	
</asp:Content>