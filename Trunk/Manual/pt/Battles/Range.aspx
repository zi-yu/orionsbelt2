<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Alcance
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Alcance das Unidades de Combate</h1>
<div class="content">
    O <a href='/pt/Battles/Range.aspx'>Alcance</a> define a distância de ataque de uma unidade. Todas as unidades podem atacar, e algumas até têm
    poderes de ataque especiais. 
    <p />
    O seguinte exemplo mostra as diferenças de <a href='/pt/Battles/Range.aspx'>Alcance</a> entre duas <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>: o <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> e a <a class='krill' href='/pt/Unit/Krill.aspx'>Krill</a>.
    O <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> tem <a href='/pt/Battles/Range.aspx'>Alcance</a> de 6, e por isso consegue atingir praticamente toda a coluna em que está.
    Por outro lado, a <a class='krill' href='/pt/Unit/Krill.aspx'>Krill</a> só tem <a href='/pt/Battles/Range.aspx'>Alcance</a> de 3, pelo que só consegue atingir unidades a 3 de distância.
    <p />
    Nota que se houver uma unidade entre o atacante e o alvo, o ataque não é possível, a menos que o
    atacante tenha <a href='/pt/Battles/Catapult.aspx'>Catapulta</a>.
    
    <img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></div>
	
</asp:Content>