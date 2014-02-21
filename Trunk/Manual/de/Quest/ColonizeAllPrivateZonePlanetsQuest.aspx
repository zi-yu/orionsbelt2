<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bevölkere alle fünf Planeten in deiner Privat-Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bevölkere alle fünf Planeten in deiner Privat-Zone" runat="server" /></h1>
	
	<div class="description">
		Jetzt weisst du wie man <a href='/de/Universe/Planets.aspx'>Planeten</a> besiedelt, dein nächster<a href='/de/Quests.aspx'>Mission</a> ist all Planeten in deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> zu besiedeln.
In deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> gibt es 5 <a href='/de/Universe/Planets.aspx'>Planeten</a>, erforsche und besiedele diese Planeten. <p></p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +50</li></ul>
	</div>
	
</asp:Content>