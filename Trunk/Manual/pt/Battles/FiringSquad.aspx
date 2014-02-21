<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pelotão de Fuzilamento
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalha</h2><ul><li><a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li><li><a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a></li><li><a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a></li><li><a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pelotão de Fuzilamento</h1>
<div class="content">
    O <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a> foi uma estratégia de batalha muito utilizada nos primórdios do <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. Na antiguidade
    era possível obter o <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> muito cedo. O <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> é uma unidade <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a> muito poderosa e com 6 de
    <a href='/pt/Battles/Range.aspx'>Alcance</a>, o que fez com que vários jogadores se concentrassem em produzir somente destas unidades e as
    colocassem todas na fila da frente. Com um <a href='/pt/Battles/Range.aspx'>Alcance</a> de 6 elas conseguiam atingir todo o <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>.
    Daí veio o nome de <i>pelotão de fuzilamento</i>.
    <p /><h2>Batalha de Exemplo</h2>
    O <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a> pode ser uma táctica muito complexa de defender por parte do adversário, tal como
    também pode ser muito simples de contra-atacar. Vejamos o seguinte exemplo de uma batalha de
    <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a>:
  </div>

	<p><iframe class='battle' src="/Resources/Battles/FiringSquad1.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
	<div class="content">
  <p>
  Como podemos ver o adversário não consegue resistir ao poder do <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a>. Esta táctica não requer
  grande capacidade de batalha, somente requer ter na <a href='/pt/Universe/Fleet.aspx'>Armada</a> uma enorme quantidade de <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> de longo
  alcance.
    </p>
  <h2>Alterações ao Jogo para Atenuar o Pelotão de Fuzilamento</h2>
  <p>
  O <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a> tornou-se uma táctica tão comum que o jogo teve de levar algumas regras extra para
  atenuar o seu efeito, nomeadamente:
  <ul><li>
  O dano dado pelas unidades levou uma atenuação com base na distância. Desta forma um
  <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> não faria tanto dano nas defesas adversárias
    </li><li>Foram criadas unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> com bónus especial contra unidades de <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>.</li></ul></p>
  <h2>Desvantagens do Pelotão de Fuzilamento</h2>
  <p>
  Aparentemente, mesmo com as alterações ao jogo, o <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a> parece ser uma táctica ideal e sem defesa.
  Contudo as aparências iludem e na verdade qualquer jogador mais experiente consegue vencer facilmente
  um <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a>, embora não se livre de perder uma quantidade razoável de naves.
    </p>
  <p>
  A batalha seguinte ilustra exactamente a estratégia usada para vencer um <a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a>. Como se pode ver,
  uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> com unidades <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> a servir de <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> e uma pequena quantidade de unidades
  <a href='/pt/Battles/Medium.aspx'>Médio Porte</a> consegue vencer uma armada com uma grande quantidade de <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a>.
    </p>
</div>
	
	<p><iframe class='battle' src="/Resources/Battles/FiringSquad2.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
</asp:Content>