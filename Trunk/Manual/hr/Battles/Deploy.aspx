<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Raspoređivanje
	
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Raspoređivanje</h1>
	<div class="content">
<a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a> je prva stvar koju svaki igrač treba napraviti na početku bitke. Svaki igrač počinje sa odeđenim brojem jedinica koje moraju biti smještene na bilo kojemu od 16 početnih kvadrata (vidi sliku ispod):
<p /><img class="block" src="/Resources/Images/DeployArea.png" alt="Deploy Area" /><p />
U <a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a> nema nikakvih <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> za trošiti i <a href='/hr/Battles/Movement.aspx'>Pokret</a> tip svake jedinice nije uzet u obzir.Možete ubaciti sve jedinice gdje god da želiti i rastaviti ih kako hoćete.
<p />
U bitci između 4 igrača ista vrijede ista pravila kao u bitci između dva igrača. Također područje koje imate za raspoređivanje vaših jedinica je isto (pogledaj sliku ispod).

<p /><img class="block" style="width:510px;" src="/Resources/Images/DeployArea4.png" alt="Deploy Area for a 4 players battle" /><p />

Bitka će početi tek kada su svi igrači razmjestili svoje jedinice. Također dok raspoređivate svoje jedinice ne možete vidjeti ne možete vidjeti svoje neprijatelje koji raspoređuju svoje. Nerpijateljske jednice su jedino vidljive kada bitak započne.
<p />
U svakoj bitci, čak i u bitci između 4 igrača, maksimalan broj jednica koje možete imati je 8. Jedina iznimka je <a href='/hr/Battles/Regicide.aspx'>Regicid</a> bitka gdje možete imati 9 jedinica.
Deveta jedinica je <a class='flag' href='/hr/Unit/Flag.aspx'>Zastava</a> koji je automatski dodan u tvoju flotu.
<p />
Ispod je video koji vas uči kako rasporediti svoje jedinice:
<p /></div>
</asp:Content>