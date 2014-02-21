<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Domet
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Domet Borbenih Jedinica</h1>
<div class="content">
<a href='/hr/Battles/Range.aspx'>Domet</a>definira napadačku udaljenost jedince. Sve jedince mogu napadati, a neke čak imaju neke jako moćne napadačke sposobnosti.
<p />
Sljedeći primjer pokazuje razliku <a href='/hr/Battles/Range.aspx'>Domet</a> između dvije <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>:  <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> i <a class='krill' href='/hr/Unit/Krill.aspx'>Krill</a>.
<a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> ima <a href='/hr/Battles/Range.aspx'>Domet</a> od 6, i zbog toga može napasti bilo koju jedincu ispred sebe. S druge strane, <a class='krill' href='/hr/Unit/Krill.aspx'>Krill</a> ima samo domet 3, i zbog toga on može napadati samo jedinice koje su maksimalno udaljene 3 kvadrata.
<p />
Uzmite u obzir ako imate neku drugu jednicu između napadača i mete, napad neće biti moguće izvršiti, osim ako napadač ima <a href='/hr/Battles/Catapult.aspx'>Katapult</a>.

<img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></div>
	
</asp:Content>