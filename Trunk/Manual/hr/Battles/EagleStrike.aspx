<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Orlov Udar
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Taktike Bitke</h2><ul><li><a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li><li><a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a></li><li><a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a></li><li><a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a></li><li><a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Orlov Udar</h1>
<div class="content">
<a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a> taktika cilja na eliminiranje unutar prvih turnova nekih slabih protivnika <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> koje predstavljaju prijetnju u budućnosti. Ova taktika žrtvuje male grupe <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a> da uništi:
<ul><li>
<a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> - koje mogu uništiti važne <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>, da ne spominjemoo uvijek prisutnu <a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a>
</li><li><a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> - sa velikim bonusom protiv <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinica, <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> je značajna prijetnja</li><li><a class='seeker' href='/hr/Unit/Seeker.aspx'>Tražilac</a> - sa bounusom protiv <a href='/hr/Battles/Medium.aspx'>Srednji</a> je također  velika prijetnja</li><li>Grupe sa velikim količinama <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinica, koje se mogu upotrijebiti kao <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li></ul>
Sve ove <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> mogu napraviti dosta štete našoj <a href='/hr/Universe/Fleet.aspx'>Flota</a>, ali su one jako slabe. Zato mi alociramo male grupe <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a> da ih uništimo. Primjer:


<img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

Kako možete vidjeti, <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a> predstavljaju prijetnju protivnikovim <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a> i <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>. I jako je teško protivniku da zasštiti obje grupe. Čak i ako može, vjerojatno neće moći izvršiti niti jedan drugi potez.

<p />

<a class='kahuna' href='/hr/Unit/Kahuna.aspx'>Kahuna</a> se može upotrijebiti umjesto <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a>, ali neće biti jednako učinkovita.
</div>

</asp:Content>