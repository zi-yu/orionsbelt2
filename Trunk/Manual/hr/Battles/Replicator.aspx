<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Replikator
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Replikator</h1>
	<div class="content">
<a href='/hr/Battles/Replicator.aspx'>Replikator</a> je napad koji može promijeniti brojeve na svakoj strani. Kada jeidinica sa ovim specijalnim poktretom napadne , replicira se određeni broj puta, ekvivalnetno broju jedinica koje uništite. Ako uništite 6 jedinca replicirati ćete se 6 puta.
<p />
Ovaj specijalni pokret radi ako je napadnuta jednica iste kategorije ili više. Primjer:<a href='/hr/Battles/Medium.aspx'>Srednji</a> jedinica sa <a href='/hr/Battles/Replicator.aspx'>Replikator</a> replicaira se samo ako je meta  <a href='/hr/Battles/Medium.aspx'>Srednji</a> jedinca ili <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinica.
<p />
Jedina jedinaica koja ima ovaj napad je <a class='stinger' href='/hr/Unit/Stinger.aspx'>Žalac</a>. Što znači da će se ova jedinica replicirati samo protiv <a href='/hr/Battles/Medium.aspx'>Srednji</a> i <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinica.
</div>
</asp:Content>