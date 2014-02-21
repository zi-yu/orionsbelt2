<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Armadilha Diagonal
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalha</h2><ul><li><a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li><li><a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a></li><li><a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a></li><li><a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Armadilha Diagonal</h1>
<div class="content">
  A <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a> é uma táctica que visa aproveitar as limitações de movimento de todas as unidades com
  <a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a>, como por exemplo: <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>, <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>, <a class='doomer' href='/pt/Unit/Doomer.aspx'>Aniquiladora</a> ou <a class='interceptor' href='/pt/Unit/Interceptor.aspx'>Interceptador</a>. Muitos jogadores chamam
  carinhosamente a esta táctica: <i>prisão de ventre</i>.
  <p />
  As <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> com <a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a> podem ficar presas sem qualquer forma de escapar se tiverem
  <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> adversárias em todas as quadrículas para onde se podem mover. Como só atacam em frente, ficam
  completamente vulneráveis.
  <p />
  O seguinte exemplo mostra uma <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a> nos quatro cantos:

  <img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Exemplo de Armadilha Diagonal" />

  E este exemplo mostra uma <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a> na extremidade do <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>:

  <img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Exemplo de Armadilha Diagonal" />
    
    Deve-se ter sempre muito cuidado em ter <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> com <a href='/pt/Battles/Movement.aspx#MovDiagonal'>Movimento Diagonal</a> numa extremidade do <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>.
    Além de perderem 50% de mobilidade, ficam muito mais abertas a uma <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a>.
    
    <h2>Como combater a Armadilha Diagonal?</h2>
    A melhor forma é evitar por completo cair na <a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a>. Contudo, se o adversário conseguir aplicar 
    a armadilha, a única forma é com outras <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> destruir as unidades que compõem a armadilha.
  </div>

</asp:Content>