<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ameaça Kamikaze
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalha</h2><ul><li><a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li><li><a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a></li><li><a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a></li><li><a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ameaça Kamikaze</h1>
<div class="content">
    As <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> são das <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> mais importantes do jogo. Apesar de serem muito frágeis, têm um força
    devastadora e um tipo de movimento que lhes dá liberdade para chegar facilmente de uma ponta do <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>
    à outra. Por estas características, ter <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> em jogo é sempre uma <i>ameaça</i> para o adversário.
    Contudo, é preciso aplicar esta ameaça directa e constantemente.
    <p />
    Se tivermos um grupo de <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> preso ou fora de <a href='/pt/Battles/Range.aspx'>Alcance</a>, então ele não é considerado uma ameaça,
    pelo menos nos próximos turnos. Mas um bom <a href='/pt/Battles/Deploy.aspx'>Posicionar</a> pode dar relevância à <a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a> se
    esta for considerada logo de início. Analisemos o seguinte exemplo:

    <img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Exemplo de Ameaça Kamikaze" />

    Como podemos ver, o jogador de baixo tem 2 grupos de <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>, um de cada lado do <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>,
    protegidos por unidades de <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>, e com uma quadrícula livre para que as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> possam partir para
    o ataque.
    <p />
    Esta disposição faz com que o jogador de baixo consiga atingir praticamente todo o <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a> com um
    groupo de <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>. E isto é importante pois, mesmo não mexendo nestes grupos, o adversário tem de estar
    sempre atento à sua <i>ameaça</i> e usar <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> para proteger as unidades que avança no terreno.
    <p />
    Esta ameaça altera completamente a estratégia do adversário e limita-o imenso.

    <h2>Como combater a Ameaça Kamikaze?</h2>

    É complicado combater a <a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a> pois para o fazer damos liberdade ao adversário para posicionar
    estrategicamente outras <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>. Contudo há algumas coisas que podem ser feitas:
    <ul><li>
    Se houver unidades com <a href='/pt/Battles/Catapult.aspx'>Catapulta</a>, <a href='/pt/Battles/Rebound.aspx'>Ricochete</a> ou <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a>, podem ser usadas para destruir
    as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>
  </li><li>
    Outra estratégia é tentar forçar o jogador a gastar as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>, tentando para isso sacrificar
    um grupo de <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>; desta forma pode ser possível eliminar a <a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a> para outras <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>
    mais importantes
  </li></ul></div>

</asp:Content>