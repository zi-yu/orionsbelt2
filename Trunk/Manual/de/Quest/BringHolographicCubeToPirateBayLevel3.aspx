<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Holographischen Würfel zur Bucht der Piraten Level 3
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Holographischen Würfel zur Bucht der Piraten Level 3" runat="server" /></h1>
	
	<div class="description">
		Wir führen gerade ein Experiment durch mit Hologramen und müssen ein paar Holographische Würfel besorgen. Plündere alle Beta Force Flotten die du finden kannst und bring 2 Holographische Würfel zu einer Bucht der Piraten Level 3.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +4000</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +3500</li></ul>
	</div>
	
</asp:Content>