<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Utopianos
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Razas</h2><ul><li><a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a href='/es/Race/Bugs.aspx'>Levyr</a></li><li><a href='/es/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Utopianos</h1>
	
	<div class="content">
    Las <a href='/es/Race/LightHumans.aspx'>Utopianos</a> es una raza de  humanos.
    Sus únicos recursos  son <a class='energy' href='/es/Intrinsic/Energy.aspx'>Energía</a>, <a class='serium' href='/es/Intrinsic/Serium.aspx'>Serium</a> y <a class='mithril' href='/es/Intrinsic/Mithril.aspx'>Mithril</a>.
  </div>
	
	<h2>Edificios</h2>
<div class="content"></div>
	<div class="content">
		<ul class='resourceList'><li><a class='deepspacescanner' href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a class='blinkerassembler' href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a class='commandcenter' href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a class='solarpanel' href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a class='mithrilextractor' href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a class='silo' href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a class='seriumextractor' href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a class='unityard' href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li><li><a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li></ul>
	</div>
	
	<h2>Unidades de Combate</h2>
<div class="content">
    Los <a href='/es/Race/LightHumans.aspx'>Utopianos</a> tienen <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> mas preparadas para defender que para atacar. 
  </div>
	<div class="content">
		<ul class='resourceList'><li><a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a></li><li><a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a></li><li><a class='nova' href='/es/Unit/Nova.aspx'>Nova</a></li><li><a class='blinker' href='/es/Unit/Blinker.aspx'>Parpadeante</a></li><li><a class='kahuna' href='/es/Unit/Kahuna.aspx'>Kahuna</a></li><li><a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a></li><li><a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a></li><li><a class='krill' href='/es/Unit/Krill.aspx'>Krill</a></li><li><a class='fenix' href='/es/Unit/Fenix.aspx'>Fénix</a></li><li><a class='taurus' href='/es/Unit/Taurus.aspx'>Toro</a></li><li><a class='samurai' href='/es/Unit/Samurai.aspx'>Samurai</a></li><li><a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a></li></ul>
	</div>
	
</asp:Content>