<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Hrana za Topove
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Taktike Bitke</h2><ul><li><a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li><li><a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a></li><li><a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a></li><li><a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a></li><li><a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Hrana za Topove</h1>
	<div class="content">

<a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> je <u>najupotrebljivanija taktika u <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a></u>! Sastoji se od upotrebe malog broja <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinica da brane druge važnije grupe jedinica na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinica je jako jeftina i ima dobaro kretanje i zbog toga je idealna da bude žrtvovana da zaštiti moćnije <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
Zbog toga se zove <i>hrana za topove</i>.
<p />
Normalno se služimo sa  <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinicama, sa <a href='/hr/Battles/Movement.aspx#MovAll'>Totalni Pokret</a> i <a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a> od 1 kao <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>. Na primjer:
<a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a>, <a class='anubis' href='/hr/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/hr/Unit/Seeker.aspx'>Tražilac</a>, <a class='raptor' href='/hr/Unit/Raptor.aspx'>Raptor</a> i ako ste stvarno očajni: <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>.

<p />
Idemo analizirati sljeći primjer:

<img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Exemplo de Carne para Canhão 1" />

Kako možemo vidjeti, imamo dvije grupe <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> koje prijete grupi <a class='spider' href='/hr/Unit/Spider.aspx'>Pauk</a>. Ali one neće moći napadati zato što dvije male grupe [Anubis stoje na putu. I nije vrijedno pomicati se i napadati da se unište tako male količine <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
<p />
<a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> taktika je jako važna i s njom se koriste svi igrači. Ali onesposobljavanje protivnikovog napada nije jedini način na koji se rabe  <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>.

 <h2>Zaustavljanje protivnikovog pokreta</h2>

U <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> je moguće da imati samo jednu jedinicu od <a href='/hr/Battles/Light.aspx'>Lagani</a> na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> kvadratu. I glavna prednost činjenja toga je se niti jedna protivnikova jedinica ne može pomaknuti na taj kvadrat bez da ne uništi <a href='/hr/Battles/Light.aspx'>Lagani</a> prvo.
To znači: možemo upotrijebiti  <a href='/hr/Battles/Light.aspx'>Lagani</a> <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> da sprijelče protivnikove jedinice da se pomaknu u poziciju za napad. Analizirajm prethodni primjer, koji sada pokazuje drugi način da zaštitimo <a class='spider' href='/hr/Unit/Spider.aspx'>Pauk</a>:

 <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Exemplo de Carne para Canhão 1" />

Ova metoda je naročito korisna protiv jedinica sa <a href='/hr/Battles/Catapult.aspx'>Katapult</a>, koje mogu ignorirati <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> i napasti svakako. Zato ako želite spriječiti napad uzmite u obzir pokret koji će omogućiti napad (nemojte zabotavit ovo kada se borit protiv <a class='vector' href='/hr/Unit/Vector.aspx'>Vector</a> ili <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a>).

<h2>Kako se boriti protiv Hrane za topove</h2>

Borba protiv <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> može biti igra strpljenja, gdje samo idete za tim da unišitite protivnikove <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> sve dok ne napravite otvor, ili protivnik napravi pogrešku.
<p />
Ipak postoje neke <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> koje su posebno korisne protiv <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a>. Sve jedinice sa sposobnostima:<a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a>, <a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a> and <a href='/hr/Battles/Rebound.aspx'>Odbijanje</a> mogu uništiti više od jedne grupe jedinica po napadu. S druge strane, jedinice sa <a href='/hr/Battles/Catapult.aspx'>Katapult</a> u <a href='/hr/Battles/Range.aspx'>Domet</a> mogu zaobići protivnikove <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> za direktni napad.
<p />
Najbolji nalčin da se bori protiv <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> je da ih se sve jednostavno uništi! Ako uništite sve protivnikove <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinice, on neće moći upotrijebiti <a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a> i sigurno će izgubiti.
Jako dobra jedinica protiv <a href='/hr/Battles/Light.aspx'>Lagani</a> je <a class='raptor' href='/hr/Unit/Raptor.aspx'>Raptor</a>. Sa značajnim bonusom napada protiv <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinica <a href='/hr/Battles/Range.aspx'>Domet</a> od dva, <a class='raptor' href='/hr/Unit/Raptor.aspx'>Raptor</a> je <u>the</u> ultimativni lovac na <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinice!

</div>

</asp:Content>