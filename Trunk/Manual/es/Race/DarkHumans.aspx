<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Renegados
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Razas</h2><ul><li><a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a href='/es/Race/Bugs.aspx'>Levyr</a></li><li><a href='/es/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Renegados</h1>
	
	<div class="content">
    Las <a href='/es/Race/DarkHumans.aspx'>Renegados</a> es una raza de humanos.
    Sus  únicos recursos son <a class='gold' href='/es/Intrinsic/Gold.aspx'>Oro</a>, <a class='titanium' href='/es/Intrinsic/Titanium.aspx'>Titanio</a> y <a class='uranium' href='/es/Intrinsic/Uranium.aspx'>Uranio</a>.
  </div>
	
	<h2>Edificios</h2>
<div class="content"></div>
	<div class="content">
		<ul class='resourceList'><li><a class='slavewarehouse' href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a class='dominationyard' href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a class='titaniumextractor' href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a class='devotionsanctuary' href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li><li><a class='darknesshall' href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a class='battlemoonassembler' href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a class='devastation' href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a class='nuclearfacility' href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li><li><a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li></ul>
	</div>
	
	<h2>Unidades de Combate</h2>
<div class="content">
    Los <a href='/es/Race/DarkHumans.aspx'>Renegados</a> tienen <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> mas preparadas para atacar que para defender.

  </div>
	<div class="content">
		<ul class='resourceList'><li><a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a></li><li><a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a></li><li><a class='panther' href='/es/Unit/Panther.aspx'>Pantera</a></li><li><a class='vector' href='/es/Unit/Vector.aspx'>Vector</a></li><li><a class='scarab' href='/es/Unit/Scarab.aspx'>Escarabajo</a></li><li><a class='bozer' href='/es/Unit/Bozer.aspx'>Bozer</a></li><li><a class='darkrain' href='/es/Unit/DarkRain.aspx'>Lluvia Sombría</a></li><li><a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a></li><li><a class='toxic' href='/es/Unit/Toxic.aspx'>Toxico</a></li><li><a class='battlemoon' href='/es/Unit/BattleMoon.aspx'>Luna de Batalla</a></li><li><a class='anubis' href='/es/Unit/Anubis.aspx'>Anubis</a></li><li><a class='darktaurus' href='/es/Unit/DarkTaurus.aspx'>Toro Oscuro</a></li><li><a class='darkcrusader' href='/es/Unit/DarkCrusader.aspx'>Cruzador Sombrio</a></li></ul>
	</div>
	
</asp:Content>