<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Triplo
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Triplo</h1>
	<div class="content">
    O <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a> é um ataque devastador que pode destruir três grupos de unidades com apenas um ataque.
    Quando se ataca com uma unidade que tem <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a>, os grupos adjacentes ao alvo serão atingidos
    com <b>50%</b> do dano recebido pelo alvo.
    <p />
    Este ataque é ideal para destruir a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> do adversário, tal como conseguir atingir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>
    protegidas contra ataques directos. Aquí está um exemplo deste ataque:

    <img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />

    Todos os grupos de <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> do adversário serão destruídos por aquele <a class='driller' href='/pt/Unit/Driller.aspx'>Perfurador</a>. Isto porque o <a class='driller' href='/pt/Unit/Driller.aspx'>Perfurador</a>
    tem <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a> e porque os grupos de <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> estão naquelas posições: adjacentes ao alvo e perpendiculares
    ao <a class='driller' href='/pt/Unit/Driller.aspx'>Perfurador</a>.
    <p />
    As <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> com <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a> são também capazes de contornar a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> do inimigo.
    Vejemos o seguinte exemplo. O grupo de <a class='fenix' href='/pt/Unit/Fenix.aspx'>Fénix</a> do adversário está bem protegido por <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>,
    que impedem um ataque directo. Contudo, uma unidade como o <a class='driller' href='/pt/Unit/Driller.aspx'>Perfurador</a> consegue contornar a muralha defensiva
    e dar dano ao grupo de <a class='fenix' href='/pt/Unit/Fenix.aspx'>Fénix</a> através do seu <a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a>:

    <img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></div>
	
</asp:Content>