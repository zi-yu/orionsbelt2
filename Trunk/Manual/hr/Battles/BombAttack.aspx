<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napad Bombom
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Napad Bombom</h1>
	<div class="content">
<a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a> je najjači napad u igri, ako je upotrijebljen pravilno. Borbena  jedinica sa  <a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a> nanosi štetu svim protivnikovim jedinicama koje su joj blizu kada napada. Ova sposobnost je izvrsna za eliminirati  protivnikove <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> ili da se nanese šteta velikom broju grupa.
<p />
Ovdje je primjer <a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a> u akciji:

 <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />


U ovome primjeru, šteta koju je jedinica nanijela meti, također će biti nanešena svim drugim grupama jedinica <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> koje su blizu. Nema smanjenja štete.
 </div>
	
</asp:Content>