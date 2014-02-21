<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Koloniziraj jedan dodatni planet u svojoj privatnoj zoni
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Koloniziraj jedan dodatni planet u svojoj privatnoj zoni" runat="server" /></h1>
	
	<div class="description">
		Cilj ove misije je da naučite kako pokoriti <a href='/hr/Universe/Planets.aspx'>Planet</a>. U vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> ne mogu vas gnjaviti drugi igrači tako da se ne trebate brinuti o tome da li će vas netko napasti. <p />
  Pretražite svemir sa <a href='/hr/Universe/Fleet.aspx'>Flota</a> i pronađite <a href='/hr/Universe/Planets.aspx'>Planet</a>. Tada odaberite <a href='/hr/Universe/Fleet.aspx'>Flota</a>, kliknite poviše <a href='/hr/Universe/Planets.aspx'>Planet</a> i pokorite ga. Sljedeća slika pokazuje primjer, i vi imatge misiju spremnu da bude dostavljena.
  <img class="block" src="/Resources/Images/en/colonize.png" alt="Colonize" title="Colonize" />
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a> : +5</li></ul>
	</div>
	
</asp:Content>