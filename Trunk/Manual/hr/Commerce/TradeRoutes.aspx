<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trgovačke Rute
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Promet</h2><ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a></li><li><a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a></li><li><a href='/hr/Commerce/Shop.aspx'>Premium Usluge</a></li><li><a href='/hr/Commerce/Markets.aspx'>Marketi</a></li><li><a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Trgovačke Rute</h1>
<div class="content">
<a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačka Ruta</a> je proce utovara trgovačkog dobra na jednom <a href='/hr/Commerce/Markets.aspx'>Market</a> i njegova dostava na drugi <a href='/hr/Commerce/Markets.aspx'>Market</a>. <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> su obično upotrijebljni kao ciljevi u <a href='/hr/MerchantQuests.aspx'>Trgovac</a> <a href='/hr/Quests.aspx'>Misije</a>. Zapravo, jedini način da su utovare trgovačka dobra u <a href='/hr/Commerce/Markets.aspx'>Market</a> je da su u tom trenutku ima trgovačka misija.
<p />
Svaki <a href='/hr/Commerce/Markets.aspx'>Market</a> se bavi sa specifičnim trgovačkim dobrom. Naprimjer, možete imati <a href='/hr/Commerce/Markets.aspx'>Market</a> koji se bavi sa <a class='supplies' href='/hr/Intrinsic/Supplies.aspx'>Zalihe</a>. Možete utovariti <a class='supplies' href='/hr/Intrinsic/Supplies.aspx'>Zalihe</a> u vašu <a href='/hr/Universe/Fleet.aspx'>Flota</a> na tom <a href='/hr/Commerce/Markets.aspx'>Market</a>, ali <a href='/hr/Commerce/Markets.aspx'>Market</a> neće prihvatiti <a class='supplies' href='/hr/Intrinsic/Supplies.aspx'>Zalihe</a> kao trgovačku rutu.
<p />
Također postoje neki <a href='/hr/Quests.aspx'>Misije</a> koji zahtjevaju kompleksnije <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a>: možda ćete morati trgovati na njima više nego jedno trgovačko dobro, ili čak morati obavljati trgovine unutar vremenskog roka  (primjer: <a href='/hr/Quest/Complete10Level1TradeRoutes.aspx'>Završi 10 trgovačkih ruta sa Alatima ili Zalihama unutar 24 sata.</a>).
</div>
	
</asp:Content>