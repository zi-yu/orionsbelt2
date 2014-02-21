<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Turniri
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Ratna Zona</h2><ul><li><a href='/hr/Battles/Tournaments.aspx'>Turniri</a></li><li><a href='/hr/Battles/Ladder.aspx'>Ljestvica</a></li><li><a href='/hr/Battles/Friendly.aspx'>Prijateljski</a></li><li><a href='/hr/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Turniri</h1>
	<div class="content">
<a href='/hr/Battles/Tournaments.aspx'>Turniri</a> su ultimativna bojišnica za <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> igrače. Ovdje ćete se suočiti oči u oči sa najboljim igračima i trebate se dokazati da pobjedite. Možete sudjelovati u <a href='/hr/Battles/Regicide.aspx'>Regicid</a> i <a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a> turnirima.
Ako ste dobri na turnirima također povećava vaše <a href='/hr/Commerce/Orions.aspx'>Orioni</a>.

<h2>Strukutra Turnira</h2>
Postoji nekoliko faza turnira. Prvo je turnir otvoren za prijave. Ako ispunite zahtjeve moći ćete u ući i biti ćete smješteni u jedan od 10 lonaca. Kada turnir započne, grupna faza će početi.
<p />
U grupnoj fazi, prva tri igrača će nastaviti u sljedeću rundu. Također bi mogli dobaviti druge igrače ako ih trebamo za doigravanje.
<p />
Nakon grupe imamo doigravanja. Ako izgubite, van ste!
</div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>