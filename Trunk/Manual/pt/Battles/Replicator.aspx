<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Replicador
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Replicador</h1>
	<div class="content">
    o <a href='/pt/Battles/Replicator.aspx'>Replicador</a> é o ataque que pode mudar os números da batalha. Quando uma unidade com este ataque especial ataca, ela replica-se um determinado número de vezes equivalente 
    ao número de unidades destruídas. Se destruires 6 unidades, a unidade com <a href='/pt/Battles/Replicator.aspx'>Replicador</a> replica-se 6 vezes.
    <p />
    Este ataque especial só funciona se unidades da mesma category ou acime forem atacadas. Exemplo: uma unidade <a href='/pt/Battles/Medium.aspx'>Médio Porte</a> com <a href='/pt/Battles/Replicator.aspx'>Replicador</a> só se replica se o alvo for da  [Category]  <a href='/pt/Battles/Medium.aspx'>Médio Porte</a> ou <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>.
    <p />
    A única unidade do jogo que possui este ataque é a <a class='stinger' href='/pt/Unit/Stinger.aspx'>Ferrão</a>. O que significa que esta unidade só se replica contra unidades <a href='/pt/Battles/Medium.aspx'>Médio Porte</a> e <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>.
   </div>
</asp:Content>