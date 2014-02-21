<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Otkrio sam da Žeteoci rabe specijalnu Kacigu da se kontroliraju. Potrebna mi je ta kaciga. Donesi dvije funkcionalne kacige u bilo koju Akademiju nivoa 5.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Otkrio sam da Žeteoci rabe specijalnu Kacigu da se kontroliraju. Potrebna mi je ta kaciga. Donesi dvije funkcionalne kacige u bilo koju Akademiju nivoa 5." runat="server" /></h1>
	
	<div class="description">
		Otkrio sam da Žetalice rabe specijalnu kacigu da se upravlja s njima. Trevam tu kacigu. Donesite 2 funkcionalne kacige na bilo koju Akademiju nivoa 5.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +7500</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +4500</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +4500</li></ul>
	</div>
	
</asp:Content>