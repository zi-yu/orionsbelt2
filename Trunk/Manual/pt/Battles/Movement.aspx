<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Movimento
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Movimentação na Batalha</h1>
<div class="content">
    A movimentação refere-se ao acto de mover <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a> após a fase de <a href='/pt/Battles/Deploy.aspx'>Posicionar</a>.
    Cada unidade de combate tem um tipo de movimento específico, que pode ser um dos seguintes:
    <ul><li><a href='/pt/Battles/Movement.aspx#MovAll'>Movimento Total</a></li><li><a href='/pt/Battles/Movement.aspx#MovNormal'>Movimento Normal</a></li><li><a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a></li><li><a href='/pt/Battles/Movement.aspx#MovFront'>Movimento Frontal</a></li><li><a href='/pt/Battles/Movement.aspx#MovDrop'>Movimento Pára-quedas</a></li><li><a href='/pt/Battles/Movement.aspx#MovNone'>Sem Movimento</a></li></ul>
    Aliando ao tipo de movimento está o <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a>. Estas duas características definem a velocidade de uma unidade.

    <a name="MovAll" id="MovAll"></a><h2><a href='/pt/Battles/Movement.aspx#MovAll'>Movimento Total</a></h2>
    Com o <a href='/pt/Battles/Movement.aspx#MovAll'>Movimento Total</a> uma unidade pode-se mover para qualquer quadrícula adjacente. Exemplo:
    <img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/pt/Battles/Movement.aspx#MovNormal'>Movimento Normal</a></h2>
    Com o <a href='/pt/Battles/Movement.aspx#MovNormal'>Movimento Normal</a> uma unidade pode-se mover para qualquer quadrícula adjacente, excepto as diagonais. Exemplo:
    <img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a></h2>
    Com o <a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a> uma unidade só se pode mover para uma diagonal (cuidado com a <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a>). Exemplo:
    <img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/pt/Battles/Movement.aspx#MovFront'>Movimento Frontal</a></h2>
    Com o <a href='/pt/Battles/Movement.aspx#MovFront'>Movimento Frontal</a> uma unidade só se pode mover em frente. Se precisar de mudar de direcção, terá de usar
    uma rotação. Exemplo:
    <img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/pt/Battles/Movement.aspx#MovDrop'>Movimento Pára-quedas</a></h2>
    Uma unidade com <a href='/pt/Battles/Movement.aspx#MovDrop'>Movimento Pára-quedas</a> é capaz de introduzir uma outra unidade de combate no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>.
    Por exemplo: uma <a class='queen' href='/pt/Unit/Queen.aspx'>Rainha</a> é capaz de  fazer crescer um <a class='egg' href='/pt/Unit/Egg.aspx'>Ovo</a> no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>.

    <a name="MovNone" id="MovNone"></a><h2><a href='/pt/Battles/Movement.aspx#MovNone'>Sem Movimento</a></h2>
    Uma unidade <a href='/pt/Battles/Movement.aspx#MovNone'>Sem Movimento</a> está fixa e não se pode mover. Exemplo:
    <img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a></h2>
    O tipo de <a href='/pt/Battles/Movement.aspx'>Movimento</a> influencia como é que a unidade se move. Mas todas as <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> têm um <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a>
    que influencia o quão rápidas elas são. Em cada turno de uma batalha, um jogador tem 6 pontos de movimentação
    para gastar: pode mover unidades, pode atacar ou pode até nem os gastar.
    <p />
    Se uma unidade tem um <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a> de 2, isso quer dizer que podemos movê-la 3 vezes num turno (6/2=3). Vejemos
    por exemplo a <a class='doomer' href='/pt/Unit/Doomer.aspx'>Aniquiladora</a> e a <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>. Ambas têm <a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a>, mas a <a class='doomer' href='/pt/Unit/Doomer.aspx'>Aniquiladora</a> tem custo 3 e a <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>
    custo 2, o que faz com que a <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> seja mais rápida.

    <a name="MovPoints" id="MovPoints"></a><h2><a href='/pt/Battles/Movement.aspx#MovPoints'>Pontos de Movimento</a></h2>
    Os <a href='/pt/Battles/Movement.aspx#MovPoints'>Pontos de Movimento</a> representam o total de acções que podem ser realizadas num turno de batalha. Em cada turno
    estão disponíveis seis <a href='/pt/Battles/Movement.aspx#MovPoints'>Pontos de Movimento</a> para gastar, e cada acção disponível tem o seu custo:
    <ul><li>Atacar custa 1 ponto</li><li>
    Mover uma unidade de combate terá o custo associado a essa unidade. Todas as <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>
    têm um <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a> definido
  </li><li>Separar um grupo de unidades, custa o dobro do <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a> dessa unidade</li></ul></div>
	
</asp:Content>