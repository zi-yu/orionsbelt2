<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Postrojenja
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Postrojenja</h1><table class='table'><tr><th><a href='/hr/Race/LightHumans.aspx'>Utopians</a></td><th><a href='/hr/Race/DarkHumans.aspx'>Renegades</a></td><th><a href='/hr/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li></td></ul><td><ul><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li></td></ul><td><ul><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Glavno Postrojenje</h2>
<p>
Svaka rasa ima svoje vlastito glavno postrojenje, koje služi da se definira nivo igrača. Glavna posrojenja su :
<ul><li> <a class='commandcenter' href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a> za <a href='/hr/Race/LightHumans.aspx'>Utopians</a></li><li> <a class='darknesshall' href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a> za <a href='/hr/Race/DarkHumans.aspx'>Renegades</a></li><li>T<a class='nest' href='/hr/Facility/Nest.aspx'>Gnijezdo</a> za <a href='/hr/Race/Bugs.aspx'>Levyr</a></li></ul></p>
<h2>Skupljanje Resursa</h2>
<p>
Da unaprijedite vaša <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> i gradite <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> trebaju vam <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> resursi. Ovi resursi mogu biti ekstraktirani u <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planetima koristeći se postrojenjima za ekstraktiranje.
</p>
<h2>Gradnja Jedinica</h2>
<p>
Trebate posebno postrojenje da gradite <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Svaka rasa ima svoje vlastitio postrojenje za gradnju jedinica, i ova psotrojenja imaju 10 nivoa. Svaki nivo otključava drukčije <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Postrojenja za gradnju jedinica su:
<ul><li> <a class='unityard' href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a> za <a href='/hr/Race/LightHumans.aspx'>Utopians</a></li><li> <a class='dominationyard' href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> za <a href='/hr/Race/DarkHumans.aspx'>Renegades</a></li><li><a class='incubator' href='/hr/Facility/Incubator.aspx'>Inkubator</a> za <a href='/hr/Race/Bugs.aspx'>Levyr</a></li></ul>
Uzmite u obzir da trebate imati ovo postrojenje da biste mogli graditi jedinice.
 </p>
<h3>Konstrukcija Ultimativnih Jedinica</h3>
<p>
Za svaku rasu je dostupna ultimativna jedinica. Ovo jedince su jako skupe i mogu biti napravljenje tek na napredim nivoima. Ono što ih ističe je da su one pozicionirane van <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> i imaju jedinstvene sposobnosti:
<ul><li>
<a href='/hr/Race/LightHumans.aspx'>Utopians</a> mogu graditi <a class='blinker' href='/hr/Unit/Blinker.aspx'>Bljeskalica</a> u <a class='blinkerassembler' href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a>.<a class='blinker' href='/hr/Unit/Blinker.aspx'>Bljeskalica</a> može jednostavno micati svaku jedinicu (vašu ili protivnikovu) na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>.
</li><li>
<a href='/hr/Race/DarkHumans.aspx'>Renegades</a> mogu graditi <a class='battlemoon' href='/hr/Unit/BattleMoon.aspx'>Borbeni Mjesec</a> u <a class='battlemoonassembler' href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a>.<a class='battlemoon' href='/hr/Unit/BattleMoon.aspx'>Borbeni Mjesec</a> može napadati bilo koju protivnikovu jedinicu unutar dometa.
</li><li>
<a href='/hr/Race/Bugs.aspx'>Levyr</a> mogu graditi <a class='queen' href='/hr/Unit/Queen.aspx'>Kraljica</a> u <a class='queenhatchery' href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a>.<a class='queen' href='/hr/Unit/Queen.aspx'>Kraljica</a> može poleći jaja u  <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> iz <a class='maggot' href='/hr/Unit/Maggot.aspx'>Crv</a>'s table.
 </li></ul></p>
<h2>Nivo Planeta i Nivo Postrojenja</h2>
<p>
Svaki planet ima dva izrazito povezana nivoa koja određuju <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> koja se mogu graditi.<u>Nivo Planeta</u> pokazuje <a href='/hr/Universe/HotZone.aspx#levels'>Nivo Zone</a> u svemiru gdje se planet nalazi.
 The <u>Nivo Postrojenja</u> pokazuje evolucijsku razinu vašeg planeta. Na <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planetima koristimo se glavnim postrojenjem da odredimo nivo planeta. Na <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> se koritimo se s nivoom <a class='extractor' href='/hr/Facility/Extractor.aspx'>Ekstraktor</a>.
</p>
	</div>
	
</asp:Content>