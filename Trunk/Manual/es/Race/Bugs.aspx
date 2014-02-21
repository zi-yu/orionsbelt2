<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Levyr
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Razas</h2><ul><li><a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a href='/es/Race/Bugs.aspx'>Levyr</a></li><li><a href='/es/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Levyr</h1>
	
	<div class="content">
    Los <a href='/es/Race/Bugs.aspx'>Levyr</a> son una raza de insectos.
    Sus únicos recursos  son <a class='elk' href='/es/Intrinsic/Elk.aspx'>Comida</a> y <a class='protol' href='/es/Intrinsic/Protol.aspx'>Protol</a>.
  </div>
	
	<h2>Edificios</h2>
<div class="content"></div>
	<div class="content">
		<ul class='resourceList'><li><a class='protolextractor' href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a class='elkextractor' href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a class='queenhatchery' href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a class='incubator' href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a class='nest' href='/es/Facility/Nest.aspx'>Nido</a></li><li><a class='wormholecreator' href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li><li><a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li></ul>
	</div>
	
	<h2>Unidades de Combate</h2>
<div class="content">
    Los <a href='/es/Race/Bugs.aspx'>Levyr</a> tienen <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> de las mas moviles del juego.

  </div>
	<div class="content">
		<ul class='resourceList'><li><a class='queen' href='/es/Unit/Queen.aspx'>Reina</a></li><li><a class='spider' href='/es/Unit/Spider.aspx'>Araña</a></li><li><a class='hiveprotector' href='/es/Unit/HiveProtector.aspx'>Protector de la Colmena</a></li><li><a class='worm' href='/es/Unit/Worm.aspx'>Gusano</a></li><li><a class='seeker' href='/es/Unit/Seeker.aspx'>Buscador</a></li><li><a class='egg' href='/es/Unit/Egg.aspx'>Huevo</a></li><li><a class='maggot' href='/es/Unit/Maggot.aspx'>Larva</a></li><li><a class='hiveking' href='/es/Unit/HiveKing.aspx'>Rey de la Colmena</a></li><li><a class='stinger' href='/es/Unit/Stinger.aspx'>Aguijón</a></li><li><a class='blackwidow' href='/es/Unit/BlackWidow.aspx'>Viuda Negra</a></li><li><a class='heavyseeker' href='/es/Unit/HeavySeeker.aspx'>Mega Buscador</a></li><li><a class='destroyer' href='/es/Unit/Destroyer.aspx'>Destructor</a></li><li><a class='interceptor' href='/es/Unit/Interceptor.aspx'>Interceptador</a></li></ul>
	</div>
	
</asp:Content>