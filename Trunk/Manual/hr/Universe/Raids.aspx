<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pljačka
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Raids</h1>
<div class="content">
Pljačkanje se sastoji od napadanja <a href='/hr/Universe/Planets.aspx'>Planet</a> drugog igrača sa jedniom svrhom kranja <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a>
resursa. Ova akcija je uobičajeno izvedena od strane <a href='/hr/PirateQuests.aspx'>Pirat</a> igrača na njihovim <a href='/hr/Quests.aspx'>Misije</a>, ali također može biti učinjena od bilo koga drugoga.
<p />
Kada pljačkate planet dvije stvari se mogu desiti:
<ul><li>Planetarna obranbrna <a href='/hr/Universe/Fleet.aspx'>Flota</a> je prazna i pljačkanje se izvodi</li><li>
Planet ima neku obranu i bitka počinje na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>; samo ako pobijedite pljačkanje se izvodi.
</li></ul>
Čak i ako se pljačkanje uspješno izuvede, možda nećete dobiti niti jedan resurs. Postoji timeout pljačko da se spriječi iskorištavanje, tako da je moguće pljačkati planet svako ~14 sati
<p />
Ako je pljačka uspješno izvršena, neki resursi će biti ukradeni i vaš <a href='/hr/PirateQuests.aspx'>Pirat</a> će narasti. Ukrasti ćete dva tipa resursa. Jedan resurs odabran odabran slučajno i drugi je resurs kojega ciljani planet ima najviše. I to varira po <a href='/hr/Race/Races.aspx'>Rasa</a>: <ul><li>Ako vam je meta <a href='/hr/Race/LightHumans.aspx'>Utopians</a> planet, dobit ćete<a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a></li><li>Ako vam je meta <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> planet, dobit ćete[ <a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>Ako vam je meta <a href='/hr/Race/Bugs.aspx'>Levyr</a> planet, dobit ćete[ <a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
Ukradena količina je mali postotak totalne količine ciljanog igrača, i planeti većeg nivoa daju bolji postotak.
</div></h1>
	
</asp:Content>