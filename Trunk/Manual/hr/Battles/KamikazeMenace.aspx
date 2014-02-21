<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Prijetnja Kamikaza
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Taktike Bitke</h2><ul><li><a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li><li><a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a></li><li><a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a></li><li><a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a></li><li><a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Prijetnja Kamikaza</h1>
<div class="content">
<a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> su jedne od najvažnijih <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> igre. One su jako krhke, ali imaju ogromnu moć razaranja i slobodu pokreta da dosegnu skor svaki kvadrat na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>.
Zbog ovih karakteristika, imati <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> u igri je uvijek <i>prijetnja</i> protivniku,
Međutim, trebate napraviti <i>prijetnju</i> prisutnu u svakom trenutku!
<p />
Ako imate grupu <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> koja je zapela iza nekih drugih <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>  ili je van <a href='/hr/Battles/Range.aspx'>Domet</a>, tada se ne smatraju prijetnjom, bar ne u sljedećim turnovima. Ali dobar <a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a> može nametnuti <a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a> od početka. Analizirajmo sljeći primjer:

<img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Kamikaze Menace Example" />

Kako možemo vidjeti, donji igrač ima dvije grupe <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>, po jednu na svakoj strani <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>, zaštićene <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinicama, i s otvorenom napadačkom rutom.
<p />
Ovaj raspored omogućuje donjem igraču da lako udari protiv preko skoro čitave  <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> sa grupom <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>. I ovo je jako važno, jer on ne mora trošiti <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> sa njima, a protivnik uvijek treba biti svjestan  <i>prijetnje</i> i upotrijebiti <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> da zaštiti svaki svoj potez.
<p />
Ova <i>prijetnja</i> kompletno mijenja protivnikovu strategiju, tjerajući ga da se ponaša opreznije.

<h2>Kako se boriti protiv Prijetnje Kamikaza?</h2>

Jako je lukavo boriti se protiv <a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a> zato što dok se boriši protiv njih dopuštaš protivniku da miče druge <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> u strateško položaje. Međutim neke se stvari trebaju uzeti u obzir:
<ul><li>
Ako imate <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> sa <a href='/hr/Battles/Catapult.aspx'>Katapult</a>, <a href='/hr/Battles/Rebound.aspx'>Odbijanje</a> ili <a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a>, možete ih upotrijebeiti da uništite <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>
</li><li>
Druga strategija nastoji prisliti protivnika da upotrijebi <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a> protiv neke grupe jedinica koja se može žrtvovati:
na ovaj načim moguće je maknuti <a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a> od drugih važnijih <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>
</li></ul></div>

</asp:Content>