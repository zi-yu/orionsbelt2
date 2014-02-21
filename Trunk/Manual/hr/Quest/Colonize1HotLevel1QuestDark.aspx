<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Posjeduj jedan planet nivoa 1 na hot zoni
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Posjeduj jedan planet nivoa 1 na hot zoni" runat="server" /></h1>
	
	<div class="description">
		Posjeduj jedan <a href='/hr/Universe/Planets.aspx'>Planet</a> u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>.
Pokoravanje Planeta u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> je isto kao i pokoravanje Planeta u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>, postoji samo jedna kvaka. <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>  je javna zona. što znači da ćete se natjecati sa drugim Igračima za Planete.<p />
<a href='/hr/Universe/Planets.aspx'>Planet</a> kojega želite pokoriti može već biti u nečijem vlasništvu. U ovome slučaju dvije stvari se mogu dogoditi:<a href='/hr/Universe/Planets.aspx'>Planet</a> kojega pokušavate pokoriti nema obrane (<a href='/hr/Universe/Planets.aspx'>Planet</a> nema obranbene <a href='/hr/Universe/Fleet.aspx'>Flota</a>), ili <a href='/hr/Universe/Planets.aspx'>Planet</a> ima obrane.<p />
U prvom slučaju odmah dobijate vlasništvo nad <a href='/hr/Universe/Planets.aspx'>Planet</a> u pitanju, kao što ste ih pokorili u <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>. Udrugom slučaju <a href='/hr/Universe/Fleet.aspx'>Flota</a> koju ste poslali da pokuša pokoriti planet će ući u bitku sa obranom <a href='/hr/Universe/Fleet.aspx'>Flota</a>  <a href='/hr/Universe/Planets.aspx'>Planet</a>. Igrač koji dobije <a href="../Battles/BattleConcepts.aspx">Bitku</a> će biti vlasnik <a href='/hr/Universe/Planets.aspx'>Planet</a>.<p />
Uzmite u obzir da su <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> planeti drukčiji do vaših <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planeta, u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> planetima ćete moći graditi samo jedno Postrojenje <a href="../Facility/Extractor.aspx">Extractors</a>.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a> : +50</li><li>Rezultat : +80</li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a> : +2</li><li><a class='darkrain' href='/hr/Unit/DarkRain.aspx'>Crna Kiša</a> : +3</li></ul>
	</div>
	
</asp:Content>