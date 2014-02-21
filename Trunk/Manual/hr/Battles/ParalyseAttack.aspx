<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napad Paralize
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Napad Paralize</h1>
	<div class="content">
<a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a> je jako snažan napad. Samo jedna jedinica sa ovim napadom može spriječiti upotrebu grupe neprijateljskih jedinica (napad i pokretanje) tokom turna bitke. Ovo može biti jako korisno da se blokiraju važne jedinice i/ili da se unište polako ili da se spriječi prolaz važnih jedinica.
<p />
Budite svjesni da u vašem turnu jedinica više neće biti Paralizirana. Zato ako želite paralizirati jedinicu (specijano jedince sa <a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a> i [ParalyseAttack] - kao<a class='spider' href='/hr/Unit/Spider.aspx'>Pauk</a>) nemojte zaboraviti Paralizirati ciljanu metu prvo ili napasti je sa strane ili straga.
<p />
Ovdje je slika na kojoj možete vidjet <a class='spider' href='/hr/Unit/Spider.aspx'>Pauk</a> kako napada <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a>:
<img class="block" src="/Resources/Images/Paralyse.png" alt="Paralyse Attack" /></div>
</asp:Content>