<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planetas</h1>
<div class="content">
    Os planetas são a alma do teu império. Eles fornecem recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a>, possibilitam-te a construção de
    <a href='/pt/FacilityIndex.aspx'>Edifícios</a> e permitem-te construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>. Quanto mais planetas tiveres, mais poderoso serás. Podes
    ter dois tipos de planetas: planetas na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> e planetas na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>.

    <h2>Planetas da Zona Privada</h2>
    Os planetas na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> são os mais importantes. Neles podes costruir a maior parte dos edifícios
    e ainda por cima nunca os perderás, por isso aposta bem neles. Estes planetas são tanbém os únicos que te
    permitem construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    A única desvantagem dos planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> é que não conseguem gerar recursos raros. Terás de ir
    para a <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> para os obteres.

    <h2>Planetas da Zona Pública</h2>
    Os planetas na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> são idênticos a minas. São muito simples, é somente possível construir um número
    limitado de edifícios (como por exemplo o <a class='extractor' href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a>), e podem ser atacados (ver <a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a>) e 
    pilhados (ver <a href='/pt/Universe/Raids.aspx'>Pilhagem</a>) por outros jogadores.
    <p />
    Apesar dos riscos, estes planetas são essenciais, porque fornecem-te com recursos raros, nomeadamente:
    <a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a>, <a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> e <a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a>. Podes obter estes recursos por intermédio do edifício
    <a class='extractor' href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a>. Sem estes recursos raros não serás capaz de evoluir os teus edifícios e construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>
    mais poderosas.
    <p />
    Nota que só podes ter um máximo de oito planetas na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>. Cada planeta na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> tem um <a href='/pt/Universe/HotZone.aspx#levels'>Nível de Zona</a>.
    Quanto maior o nível, maior será a quantidade re recursos que poderás obter através do <a class='extractor' href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a>.

    <a name="Capacity" id="Capacity"></a><h2>Limite de Recursos</h2>
    Em cada planeta tens um rendimento por recurso a cada dez minutos. Estes rendimentos vão para o teu repositório
    de recursos, que é global a todos os planetas. Contudo, esse repositório tem um limite. Os teus recursos
    não vão passar desse limite, pelo que o tens de aumentar quando necessário. Para o fazer:
    <ul><li>Se fores da raça <a href='/pt/Race/LightHumans.aspx'>Utopianos</a>, tens de construir o <a class='silo' href='/pt/Facility/Silo.aspx'>Armazém</a> e o <a class='commandcenter' href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li>Se fores da raça <a href='/pt/Race/DarkHumans.aspx'>Renegados</a>, tens de construir o <a class='slavewarehouse' href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a> e a <a class='darknesshall' href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li>Se fores da raça <a href='/pt/Race/Bugs.aspx'>Levyr</a>, tens de construir o <a class='nest' href='/pt/Facility/Nest.aspx'>Ninho</a></li></ul></div>
	
</asp:Content>