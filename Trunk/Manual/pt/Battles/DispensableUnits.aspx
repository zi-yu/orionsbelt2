<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Carne para Canhão
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalha</h2><ul><li><a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li><li><a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a></li><li><a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a></li><li><a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Carne para Canhão</h1>
	<div class="content">
    A táctica <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> é a <u>táctica mais usada no <a href='http://www.orionsbelt.eu'>Orion's Belt</a></u>! Consiste em usar pequenas quantidades
    de unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> para defender grupos importantes de unidades. Como uma unidade de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> é
    <i>barata</i> e tem muito bom movimento, é ideal para ser sacrificada a proteger <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> mais poderosas.
    Daí o nome <i>carne para canhão</i>.
    <p />
    Normalmente as unidades mais usadas como <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> são unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a>, <a href='/pt/Battles/Movement.aspx#MovAll'>Movimento Total</a> e
    <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a> de 1, como as <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a>, <a class='anubis' href='/pt/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/pt/Unit/Seeker.aspx'>Batedor</a>, <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a> e em último caso até mesmo as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>.

    <p />
    Vejemos o seguinte exemplo:
    
    <img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Exemplo de Carne para Canhão 1" />

    Como podemos ver, temos 2 grupos de <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> a ameaçar um grupo de <a class='spider' href='/pt/Unit/Spider.aspx'>Aranha</a>. Mas não vão conseguir
    atacar porque existem 2 pequenos grupos de <a class='anubis' href='/pt/Unit/Anubis.aspx'>Anubis</a> na linha de fogo. E não é vantajoso ao jogador de
    <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> mover e atacar pois irá destruir muito poucas <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    A táctica <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> é muito importante e usada por todos os jogadores. Mas impedir o
    ataque directo não é a única utilizdade da táctica <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>.

    <h2>Impedir Movimentos Aversários</h2>

    No <a href='http://www.orionsbelt.eu'>Orion's Belt</a> é possível ter somente 1 unidade de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> numa quadrícula. E uma das possíveis vantagens
    é que nenhuma unidade aversária se pode mover para essa quadrícula sem primeiro a destruir. Ou seja,
    podemos usar <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> para impedir unidades adversárias de tomarem uma posição perigosa.
    Retomemos o exemplo anterior, de seguida está uma outra forma de proteger a <a class='spider' href='/pt/Unit/Spider.aspx'>Aranha</a>:

    <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Exemplo de Carne para Canhão 1" />
    
    Este método é especialmente útil contra unidades com <a href='/pt/Battles/Catapult.aspx'>Catapulta</a> que podem atacar por cima da <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>.
    Não sendo possível impedir o ataque directo, poderá ser possível impedir o movimento da unidade adversária
    para a posição de ataque (não esquecer este detalhe quando o adversário tem <a class='vector' href='/pt/Unit/Vector.aspx'>Vector</a> ou <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>).

    <h2>Combater a Carne para Canhão</h2>
    
    Normalmente a única forma de combater a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> é simplesmente um jogo de paciência em que vamos
    destruindo as defesas do adversário até ele cometer um erro ou surgir uma abertura.
    <p />
    Contudo há <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> com abilidades especiais, que são extramemente úteis contra a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>,
    nomeadamente as abilidades: <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a>, <a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a> e <a href='/pt/Battles/Rebound.aspx'>Ricochete</a>, pois podem destruir mais que um grupo
    de unidades por ataque. Por outro lado, unidades com <a href='/pt/Battles/Catapult.aspx'>Catapulta</a> conseguem contornar <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> se
    estiverem ao <a href='/pt/Battles/Range.aspx'>Alcance</a> certo.
    <p />
    Mas a forma mais eficaz de contornar a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> é simplesmente tentar destruir todas
    as unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> do adversário. Sem elas, ele não se vai conseguir proteger e fica muito penalizado.
    Uma unidade extremamente eficaz contra unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> é a <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a>. Com um bónus substancial contra unidades
    de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> e <a href='/pt/Battles/Range.aspx'>Alcance</a> de 2, a <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a> é uma caçadora super optimizada de unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a>.
    
  </div>

</asp:Content>