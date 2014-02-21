<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Reapers Kontroll-Helme zu einer Level 5 Akademy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Reapers Kontroll-Helme zu einer Level 5 Akademy" runat="server" /></h1>
	
	<div class="description">
		Ich habe entdeckt dass die Reapers einen speziellen Helm benutzen um kontrolliert zu werden. Ich brauch diesen Helm. Bring 2 funktionierende Helme zu einer Level 5 Akademie.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +7500</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +4500</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +4500</li></ul>
	</div>
	
</asp:Content>