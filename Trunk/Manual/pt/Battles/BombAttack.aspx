<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Bomba
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Bomba</h1>
	<div class="content">
    O <a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a> pode ser o ataque mais poderoso do jogo, se usado de forma correcta. Uma unidade de combate
    com <a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a> inflite dano em todas as unidades adversárias que estiverem adjacentes quanto ataca.
    Esta habilidade é excelente para combater a <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a> do adversário, tal como dar dano a um
    grande número de grupos de unidades.
    <p />
    Aqui está um exemplo do <a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a>:

    <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />

    Neste exemplo, o dano dado ao alvo, será também dado a todas as unidades adversárias adjacentes, ou seja,
    todos os grupos de <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> serão destruídos. Não há qualquer atenuação no dano!
  </div>
	
</asp:Content>