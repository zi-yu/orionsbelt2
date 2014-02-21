<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Sentry Merc flote rabe jako rijedak element da napajaju svoje flote, Berilij. Donesi 3 uzorka ovoga elementa na bilo koju Akademiju nivoa 3.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Sentry Merc flote rabe jako rijedak element da napajaju svoje flote, Berilij. Donesi 3 uzorka ovoga elementa na bilo koju Akademiju nivoa 3." runat="server" /></h1>
	
	<div class="description">
		Sentry Merc koriste jako rijteki element koji napaja njihove jedinice, Berilij. Donesite 3 uzorka ovoga elementa na bilo koju Akademiju nivoa 3.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +2500</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +3500</li></ul>
	</div>
	
</asp:Content>