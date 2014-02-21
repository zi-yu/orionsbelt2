<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trostruki Napad
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Trostruki Napad</h1>
	<div class="content">
<a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a> je razarajući napad koji može uništiti tri grupe jedinica sa samo jednim napadom. Kada upotrijebite grupu koja ima  <a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a> za napad. sve jedinice koje su blizu grupe će dobiti  <b>50%</b> štete učinjene ciljanoj grupi.
<p />
Ovaj napad je idealan za uništavanje neprijateljevih <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> i također da dosegne <i>nedohvatljive</i> grupe.
Ovdje je primjer napada:

<img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />

Sve neprijateljeve <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> će biti uništene od toga <a class='driller' href='/hr/Unit/Driller.aspx'>Bušitelj</a>. To je zato što <a class='driller' href='/hr/Unit/Driller.aspx'>Bušitelj</a> ima <a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a> i zato što su grupe <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> točno na mjestu, blizu mete i okomite u odnosu na <a class='driller' href='/hr/Unit/Driller.aspx'>Bušitelj</a>.

<p />
<a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> sa <a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a> mogu također dosegnuti <i>nedohvatljive</i> grupe. Uzmite u obzir sljedeći primjer. Neprijateljev <a class='fenix' href='/hr/Unit/Fenix.aspx'>Feniks</a> je dobro zaštićen od <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>, što sprječava direktan napad.
Ali, još jednom <a class='driller' href='/hr/Unit/Driller.aspx'>Bušitelj</a> se može prišuljati i nanijeti štetu <a class='fenix' href='/hr/Unit/Fenix.aspx'>Feniks</a> koristeći se <a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a>:

<img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></div>
	
</asp:Content>