<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Carne de Cañon
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalla</h2><ul><li><a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li><li><a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a></li><li><a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a></li><li><a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Carne de Cañon</h1>
	<div class="content">
    La táctica <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> es la <u>táctica más usada en el <a href='http://www.orionsbelt.eu'>Orion's Belt</a></u>! Consiste en usar pequeñas cantidades
    de unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> para defender grupos importantes de unidades. Como una unidade de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> es
    <i>barata</i> y tiene muy buen movimiento, es ideal para ser sacrificada para proteger <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> mas poderosas.
    De ahí el nombre <i>carne de cañon</i>.
    <p />
    Normalmente las unidades mas usadas como <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> son unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a>, <a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a> y
    <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a> de 1, como las <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a>, <a class='anubis' href='/es/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/es/Unit/Seeker.aspx'>Buscador</a>, <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a> y en último caso hasta las <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>.

    <p />
    Veamos el seguiente ejemplo:
    
    <img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Exemplo de Carne para Canhão 1" />

    Como podemos ver, tenemos 2 grupos de <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> amenazando un grupo de <a class='spider' href='/es/Unit/Spider.aspx'>Araña</a>. Pero no van a lograr
    atacar porque existen 2 pequeños grupos de <a class='anubis' href='/es/Unit/Anubis.aspx'>Anubis</a> en la línea de fuego. Y no representa ventajas para el jugador de 
    <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> mover y atacar pues destruíra muy pocas <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    La tactica <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> es muy importante y usada por todos los jogadores. Pero impedir el
    ataque directo no es la única utilidad de la táctica <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>.

    <h2>Impedir Movimentos Aversários</h2>

    En el <a href='http://www.orionsbelt.eu'>Orion's Belt</a> es possible tener solamente 1 unidad de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> en una cuadrícula. Y una de las posibles ventajas
    es que ninguna unidad adversária se puede mover para esa quadrícula sin primero ser destruida. O sea,
    podemos usar <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> para impedir a las unidades adversárias de tomen una posición peligrosa.
    Retomemos o ejemplo anterior, enseguida esta es otra forma de proteger una <a class='spider' href='/es/Unit/Spider.aspx'>Araña</a>:

    <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Exemplo de Carne para Canhão 1" />
    
    Este método es especialmente útil contra unidades con <a href='/es/Battles/Catapult.aspx'>Catapulta</a> que pueden atacar encima de las <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>.
    No siendo posible impedir el ataque directo, podrá ser posible impedir el movimento de la unidad adversária
    para la posición de ataque (no olvidar este detalle cuando el adversário tiene <a class='vector' href='/es/Unit/Vector.aspx'>Vector</a> o <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>).

    <h2>Combater la Carne de Cañon</h2>
    
    Normalmente la única manera de combatir las <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> es simplemente un juego de paciéncia en que vamos
    destruyendo las defensas del adversário hasta que el cometa un error o surja una abertura.
    <p />
    Existen también <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> con habilidades especiales, que son extremamente útiles contra las <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>,
    relativamente a las habilidades: <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a>, <a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a> y <a href='/es/Battles/Rebound.aspx'>Rebote</a>, pués pueden destruir más de un grupo
    de unidades por ataque. Por otro lado, unidades con <a href='/es/Battles/Catapult.aspx'>Catapulta</a> consiguen eludir <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> si
    estuvieran en el <a href='/es/Battles/Range.aspx'>Alcance</a> cierto.
    <p />
    Pero la forma mas eficaz de eludir las <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> es simplemente tratar de destruir todas
    las unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> del adversário. Sin ellas, el no se consigue proteger y queda muy indefenso.
    Una unidad extremamente eficaz contra unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> es la <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a>. Con un "bonus" sustancial contra unidades
    de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> y <a href='/es/Battles/Range.aspx'>Alcance</a> de 2, la <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a> es una cazadora super optimizada de unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a>.
    
  </div>

</asp:Content>