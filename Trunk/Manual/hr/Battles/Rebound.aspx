<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Odbijanje
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Povratni</h1>
	<div class="content">
<a href='/hr/Battles/Rebound.aspx'>Povratni</a> je napad gdje se nije potrošilo ništa snage, ako je previše da se uništi prvi set <a href='/hr/UnitIndex.aspx'>Jedinice</a>, ostatak snage napada ide na <a href='/hr/UnitIndex.aspx'>Jedinice</a> koje su odmah iza prvog seta napadnutih <a href='/hr/UnitIndex.aspx'>Jedinice</a>. <p /><img class="block" src="/Resources/Images/Rebound.png" alt="Rebound" />

Na ovoj slici možete vidjeti <a class='fenix' href='/hr/Unit/Fenix.aspx'>Feniks</a> kako napada <a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a>, zamislite kako je napad <a class='fenix' href='/hr/Unit/Fenix.aspx'>Feniks</a> 10000, a obrana  <a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a> je samo 8000, tada će <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> dobiti 2000 štete (10000 - 8000 = 2000). Ali ako <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> nisu bile odmah iza <a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a> neće dobiti ništa štete ako je jedan ili više kvadrta između <a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a> i<a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>.
</div>
	
</asp:Content>