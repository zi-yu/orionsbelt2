<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring eine Liste der Kriminellen Sigma zur Bucht der Piraten Level 9
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring eine Liste der Kriminellen Sigma zur Bucht der Piraten Level 9" runat="server" /></h1>
	
	<div class="description">
		Die Sigma Force hat eine Liste der meistgesuchten Kriminellen in der Level 9 Zone. Wir wollen dass du diese Liste findest und sie zu einer Bucht der Piraten Level 9 bringst.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +14500</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +7000</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +7000</li></ul>
	</div>
	
</asp:Content>