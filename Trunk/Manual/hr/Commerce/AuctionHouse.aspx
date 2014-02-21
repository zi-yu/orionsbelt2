<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Aukcijska Kuća
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Promet</h2><ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a></li><li><a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a></li><li><a href='/hr/Commerce/Shop.aspx'>Premium Usluge</a></li><li><a href='/hr/Commerce/Markets.aspx'>Marketi</a></li><li><a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Aukcijska Kuća</h1>
	<div class="description">
	<a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a> je mjesto gdje igrač može kupovati ili prodavati stvari drugim igračima. Transakcije se uvijek obavljaju s <a href='/hr/Commerce/Orions.aspx'>Orioni</a> kao novcem za kupnju. <p /><h2>
Što mogu prodati i kako da to prodam?
</h2>
Možete prodavati reusrse i <a href='/hr/UnitIndex.aspx'>Jedinice</a>. Da prodate  <a href='/hr/UnitIndex.aspx'>Jedinice</a> one moraju biti u obranbenoj <a href='/hr/Universe/Fleet.aspx'>Flota</a> Početnog <a href='/hr/Universe/Planets.aspx'>Planet</a>. <p />
Da prodate (stavite na aukciju) potrebno je da odete na  <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a> stranicu i tada nastavite na "Dodaj u Aukcijsku Kuću" stranicu. <p />
Na ovoj stranici možete vidjeti resurse/<a href='/hr/UnitIndex.aspx'>Jedinice</a> koje možete staviti na aukciju, količinu proizvoda, minimalnu količinu ponude, vrijenost za trenutačnu kupnju, vrijeme koje će provesti u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a> i hoće li se predmet koji se stavlja na prodaju oglašavati.
Potrebna polja su količina i početna vrijednost ponude.<p />
Potrebno je da igrač nije mijenjao akaunte u zadnja 3 dana da bi mogao staviti predmete u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a>.<p /><h2>
Kako se prodaja nastavlja?
 </h2>
Tokom vremena koje je odabrano kada je proizvod stavljen u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a>, drugi igrači mogu stavljati ponude ili trenutačno otkupiti proizvod. 
Za trenutačnu kupnju prodavač dobija <a href='/hr/Commerce/Orions.aspx'>Orioni</a> odmah u slučaju davanja ponuda prodavač prima <a href='/hr/Commerce/Orions.aspx'>Orioni</a> kada istekne vrijeme određeno za davanje ponuda. <p />
Sve prodaje imaju proviziju <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a> koja varira od 8% do 25%, što je veća finalna prodajna vrijednost to je manja provizija. Ovo znači da će prodavač primiti vrijednost prodaje (plaćenu od strane drugog igrača) minus <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a> provizija.<p />
U slučaju da proizvod nije prodan, ako je jedinica vraća se u obranbenu <a href='/hr/Universe/Fleet.aspx'>Flota</a> Počernog <a href='/hr/Universe/Planets.aspx'>Planet</a>, ako je resurs ide u skladište resursa sve dok nije dostignut maksimalni limit. <p />
Također postoji stranica gdje igrač može vidjeti proizvode koje je stavio u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a>, i njegove proizvode koji su mu već prodani u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a>. <p /><h2>Kako se kupnja nastavlja? </h2>
Nakon završetka nadmetanja igrač dobija kupljeni proizvod u obranbenu  <a href='/hr/Universe/Fleet.aspx'>Flota</a> Početnog <a href='/hr/Universe/Planets.aspx'>Planet</a>. U sluačaju da je proizvod jedinica pojavljuje se direktno u <a href='/hr/Universe/Fleet.aspx'>Flota</a> i spprema je da bude premještena u drugu <a href='/hr/Universe/Fleet.aspx'>Flota</a> koja može putovati <a href='/hr/Universe/Default.aspx'>Svemir</a>. <p />
U slučaju da je proizvod resurs ili <a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a> ide u skladište obranbene <a href='/hr/Universe/Fleet.aspx'>Flota</a> na Početnom <a href='/hr/Universe/Planets.aspx'>Planet</a>. U slučaju resursa oni mogu biti istovareni iz tereta u skladište, u slučaju <a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a> stvorena je <a href='/hr/Universe/Fleet.aspx'>Flota</a>u orbiti početnog planeta ako igrač nije dosegao limit <a href='/hr/Universe/Fleet.aspx'>Flote</a>, inače igrač ne može istovariti  <a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a>.
	</div>
	
</asp:Content>