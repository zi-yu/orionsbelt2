<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Venenoso
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Venenoso</h1>
	<div class="content">
    o ataque de <a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a> é como envenenar a unidade inimiga. Se a unidade for atingida por um ataque <a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a>, ela vai receber um determinado dano durante  3 turnos (onde nestes 3 turnos
    está incluido o turno do ataque).
    <p />
    O valor de dano é equivalente a 20% do dano feito pela unidade atacante. Se a unidade deu 1000 de dano, então no primeiro turno (turno de ataque) a unidade inimiga levará  1200 e nos 2 turnos seguintes
    levará com 200 de dano por turno.
    <p />
    Este ataque é cumulativo o que significa que a unidade alvo poderá ter várias infestações ao mesmo tempo.
    <p />
    Este ataque é usado pela unidade <a class='blackwidow' href='/pt/Unit/BlackWidow.aspx'>Viúva Negra</a> e <a class='hiveking' href='/pt/Unit/HiveKing.aspx'>Rei da Colmeia</a>.
    <p />
    A imagem que se segue representa um ataque do <a class='hiveking' href='/pt/Unit/HiveKing.aspx'>Rei da Colmeia</a> a usar <a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a> contra <a class='scarab' href='/pt/Unit/Scarab.aspx'>Escaravelho</a>:
    <img class="block" src="/Resources/Images/Infestation.png" alt="Ataque Infestação" /></div>
	
</asp:Content>