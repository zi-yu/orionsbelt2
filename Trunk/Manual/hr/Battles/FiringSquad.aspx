<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napadački Odred
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Taktike Bitke</h2><ul><li><a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li><li><a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a></li><li><a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a></li><li><a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a></li><li><a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Napadački Odred</h1>
<div class="content">
<a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a> je popularna strategija upotrebljena davno na <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a>. U straim danima bilo je moguće izgradiri <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> jako rano u igri. <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> je jako moćna <a href='/hr/Battles/Heavy.aspx'>Teški</a> jednica koja ima <a href='/hr/Battles/Range.aspx'>Domet</a>  6. Mnogi igrači su se počeli kocentirati na građenje samo crushadera da ih stave u prvi red. Sa <a href='/hr/Battles/Range.aspx'>Domet</a> od 6 oni su mogli dosegnuti sve <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>, zato ih zovemo <i>napadčki odred</i>.
<p /><h2>Primjer Bitke</h2>
<a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a> može biti jako kompelksna taktika tvome protivniku da se brani, ali također ju je moguće jako lagano poremetiti. Analizirajmo sljedeću bitku gdje je jedan od igrača odabrao FiringSquad]:
</div>

	<p><iframe class='battle' src="/Resources/Battles/FiringSquad1.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
	<div class="content">
  <p>
Kako možemo vidjeti, protivnik se ne može oduprijeti moći <a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a>. Ova taktika traži samo velike količine dalekometnih <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> u vašoj <a href='/hr/Universe/Fleet.aspx'>Flota</a> da uspije.
 </p>
  <h2>Promjene u Igri</h2>
  <p>
<a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a> je postala jako prihvaćena taktika, i igra je morala promjeniti neka od svojih pravila da oslabi ovu taktiku:
<ul><li>
Šteta učinjena od strane jedinca će biti oslabljena u odnosu s udaljenosti. Na ovaj način <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> neće moći učiniti toliko štete protivnikovoj obrani.
 </li><li>Stvorili smo nekoliko <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinica sa specijanim bonusom protiv <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinica. </li></ul></p>
  <h2>Kako se boriti protiv Napadačkih Odreda</h2>
  <p>
Čak i sa promjenama u igri, <a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a> izgleda koa idealna, nepobjediva taktika.
Međutim, svaki prosječni igrač može lako pobjediti <a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a>, čak i ako to znači gubitak puno<a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
</p>
  <p>
Sljedeća bitka ilustirira strategiju koja se može upotrijebiti da se porazi <a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a>.
Kako možete vidjeti, potrebna je samo flota sa nekoliko <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinca koji služe kao <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>
i mala količina  <a href='/hr/Battles/Medium.aspx'>Srednji</a> jedinica da se porazi velika količina <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a>.
</p>
</div>
	
	<p><iframe class='battle' src="/Resources/Battles/FiringSquad2.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
</asp:Content>