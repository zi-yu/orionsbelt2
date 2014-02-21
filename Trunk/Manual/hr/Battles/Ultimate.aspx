<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ultimativni
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ultimativne Jedinice</h1>
<div class="content">
<a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a> su najmoćnije <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> svake rase. Ove jedinice su specijalne zato što one nisu smještene na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. Ali one mogu napadati i biti napadnute. 
<p />
Svaka <a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a> ima jako posebne moći. koje od njih čine ultimativnog čimbenika pobjede.
<p />
<a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a> jedinice:
</div>
	<ul class='imageList'><li><a href='/hr/Unit/Queen.aspx'><img class='queen' src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Kraljica' /></a></li><li><a href='/hr/Unit/Blinker.aspx'><img class='blinker' src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Bljeskalica' /></a></li><li><a href='/hr/Unit/BattleMoon.aspx'><img class='battlemoon' src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Borbeni Mjesec' /></a></li></ul>
	
</asp:Content>