<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Amenaza Kamikaze
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalla</h2><ul><li><a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li><li><a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a></li><li><a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a></li><li><a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Amenaza Kamikaze</h1>
<div class="content">
    Las <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> son de las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> mas importantes del juego. A pesar de ser muy frágiles, tienen una fuerza
    devastadora y un tipo de movimiento que les dá libertad para llegar fácilmente de una punta del <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>
    a la otra. Por estas características, tener <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> en el juego es siempre una <i>amenaza</i> para el adversário.
    Sin embargo, es necesario aplicar esta amenaza directa y constantemente.
    <p />
    Si tuvieramos un grupo de <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> preso o fuera de <a href='/es/Battles/Range.aspx'>Alcance</a>, entonces el no es considerado uma amenaza,
    por lo menos en los próximos turnos. Pero un buen <a href='/es/Battles/Deploy.aspx'>Posicionar</a> puede dar relevancia a la <a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a> si
    esta fuera considerada desde el Inicio. Al analizar el siguiente ejemplo:

    <img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Exemplo de Ameaça Kamikaze" />

    Como podemos ver, el jugador de abajo tiene 2 grupos de <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>, uno de cada lado del <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>,
    protegidos por unidades de <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>, y con una quadrícula libre para que las <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> puedan partir para
    el ataque.
    <p />
    Esta disposición hace que el jugador de abajo consiga alcanzar practicamente todo el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a> con un
    grupo de <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>. Y esto es importante puis, aún no moviendo estos grupos, el adversário tiene que estar
    siempre atento a su <i>amenaza</i> y usar <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> para proteger las unidades que avanzan en el terreno.
    <p />
    Esta amenaza altera completamente ça estratégia del adversário y lo limita de sobremanera.

    <h2>Como combatir la Amenaza Kamikaze?</h2>

    Es complicado combatir las <a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a> pués para hacerlo damos libertad al adversário para posicionar
    estrategicamente otras <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>. Sin embargo hay algunas cosas que pueden ser hechas:
    <ul><li>
    Si hubieran unidades con <a href='/es/Battles/Catapult.aspx'>Catapulta</a>, <a href='/es/Battles/Rebound.aspx'>Rebote</a> o <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a>, pueden ser usadas para destruir
    las <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>
  </li><li>
    Otra estratégia es tratar de forzar al jugador de gastar las <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>, tratando para eso de sacrificar
    un grupo de <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>; de esta forma puede ser posible eliminar las <a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a> para otras <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>
    más importantes
  </li></ul></div>

</asp:Content>