<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Katapult
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Katapult Napad</h1>
<div class="content">
Vjerojatno je <a href='/hr/Battles/Catapult.aspx'>Katapult</a> napad najnezaustavljiviji od svih jedinica, jer čak i kad postoje <a href='/hr/UnitIndex.aspx'>Jedinice</a> koje služe kao <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>, beskorisne su u tom slučaju.
<a href='/hr/Battles/Catapult.aspx'>Katapult</a> ignorira bilo koju jedinici koja je ispred njega, bilo prijateljska ili neprijateljsku, i u mogućnosti je da napadne bilo koju neprijateljsku jedinicu koja mu je unutar <a href='/hr/Battles/Range.aspx'>Domet</a>. Primjer je sljedeća slika:

<img class="block" src="/Resources/Images/Catapult.png" alt="Catapult" />

Ovaj napad je savršen za kiriuške udare iza obranbene barijere.<p />
Druga značajka koja čini ovaj napad vrlo zanimiljivim je da će <a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a> napadnute jedinice biti ignoriran ako je jedinica koja puca ima drugu jedinicu između sebe i napadnute jedinice.
</div></h1>
	
</asp:Content>