<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Marketi
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Promet</h2><ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a></li><li><a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a></li><li><a href='/hr/Commerce/Shop.aspx'>Premium Usluge</a></li><li><a href='/hr/Commerce/Markets.aspx'>Marketi</a></li><li><a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Marketi</h1>
	<div class="description">
	<a href='/hr/Commerce/Markets.aspx'>Marketi</a> su posvuda u <a href='/hr/Universe/Default.aspx'>Svemir</a> i imaju dva cilja: kupnju <a href='/hr/IntrinsicIndex.aspx'>Resursi</a> i uspostavljanje <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> da se završe <a href='/hr/MerchantQuests.aspx'>Trgovac</a> <a href='/hr/Quests.aspx'>Misije</a>. <p />
Da kupite <a href='/hr/IntrinsicIndex.aspx'>Resursi</a> potrebno je pomaknuti <a href='/hr/Universe/Fleet.aspx'>Flota</a> prema <a href='/hr/Commerce/Markets.aspx'>Market</a> i obaviti kupnju. <a href='/hr/IntrinsicIndex.aspx'>Resursi</a> će biti smješteni u sladište  <a href='/hr/Universe/Fleet.aspx'>Flota</a>, tada trebate pomaknuti <a href='/hr/Universe/Fleet.aspx'>Flota</a> prema <a href='/hr/Universe/Planets.aspx'>Planet</a> koji posjedujete i istovariti teret. Rijetki <a href='/hr/IntrinsicIndex.aspx'>Resursi</a> nisu uvijek dostupni u <a href='/hr/Commerce/Markets.aspx'>Marketi</a>, dvaput dnevne rijetki <a href='/hr/IntrinsicIndex.aspx'>Resursi</a> se smještaju u  <a href='/hr/Commerce/Markets.aspx'>Marketi</a> koji ih nemaju. <p />Da se uspostave <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> potrebno je transportirati resurse između <a href='/hr/Commerce/Markets.aspx'>Marketi</a>.
Resursi koji se upotrebljavaju u <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> su: 
<ul><li>
<a class='supplies' href='/hr/Intrinsic/Supplies.aspx'>Zalihe</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 1 
    </li><li>
  <a class='tools' href='/hr/Intrinsic/Tools.aspx'>Alati</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 1 
    </li><li>
  <a class='alcohol' href='/hr/Intrinsic/Alcohol.aspx'>Alkohol</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 3 i 5 
    </li><li>
  <a class='medicine' href='/hr/Intrinsic/Medicine.aspx'>Lijekovi</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 3 i 5 
    </li><li>
  <a class='mercury' href='/hr/Intrinsic/Mercury.aspx'>Živa</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 7 
    </li><li>
  <a class='diamonds' href='/hr/Intrinsic/Diamonds.aspx'>Dijamanti</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 7
    </li><li>
  <a class='animals' href='/hr/Intrinsic/Animals.aspx'>Životinje</a>, pronađeni u nekim<a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 10 
    </li><li>
  <a class='cosmicdust' href='/hr/Intrinsic/CosmicDust.aspx'>Kozmička Prašina</a>, pronađeni u nekim <a href='/hr/Commerce/Markets.aspx'>Marketi</a> u području nivoa 10 
    </li></ul>
	</div>
</asp:Content>