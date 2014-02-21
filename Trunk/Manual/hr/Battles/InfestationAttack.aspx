<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napad Obuzetosti
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Napad Obuzetosti</h1>
	<div class="content">
<a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a> je kao trovanje neprijateljske jedince. Ako je jedinica pogođena sa <a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a> napadom, primiti će određenu količinu štete tokom 3 turna (u ova 3 turna je uključen turn napada).
<p />
Količina štete koje je izvšena je jednaka 20% štete koju radi napadačka jedinica. Ako vam je  jedinica dala 1000 ili više štete,u prvom turnu (turnu napada), meta će primiti 1200. I sljedeća dva turna će primiti 200 štete po turnu.
<p />
Napad je kumulativan što znači da ciljana jedinca može imati više infestacija u istom trenutku.
<p />
Ovim napadom se služe <a class='blackwidow' href='/hr/Unit/BlackWidow.aspx'>Crna Udovica</a> i <a class='hiveking' href='/hr/Unit/HiveKing.aspx'>Kralj Košnice</a>.
<p />
Ovdje je slika koja predstavlja <a class='hiveking' href='/hr/Unit/HiveKing.aspx'>Kralj Košnice</a> kako se koristi Infestacijom protiv <a class='scarab' href='/hr/Unit/Scarab.aspx'>Kornjaš</a>:
<img class="block" src="/Resources/Images/Infestation.png" alt="Infestation Attack" /></div>
	
</asp:Content>