<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Posicionar
	
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Posicionar</h1>
	<div class="content">
    <a href='/pt/Battles/Deploy.aspx'>Posicionar</a> é a primeira tarefa que um jogador tem de fazer no inicio de uma batalha. Cada jogador começa com um determinado número de unidades 
    as quais têm de ser colocadas em qualquer das 16 quadrículas iniciais (ver imagem abaixo).
    <p /><img class="block" src="/Resources/Images/DeployArea.png" alt="Area de Posicionamento" /><p />
    Na fase de <a href='/pt/Battles/Deploy.aspx'>Posicionar</a> não existem <a href='/pt/Battles/Movement.aspx#MovPoints'>Pontos de Movimento</a> para gastar e o tipo de <a href='/pt/Battles/Movement.aspx'>Movimento</a> de cada unidade não é tido em conta. Podes inserir todas 
    as unidades onde quiseres e separá-las à vontade.
    <p />
    Nas batalhas entre 4 jogadores as mesmas regras são aplicadas. A área para posicionar as unidades é equivalente (ver figura abaixo).
    <p /><img class="block" style="width:510px;" src="/Resources/Images/DeployArea4.png" alt="Area de posicionamento para uma batalha de 4 jogadores" /><p />
    A batalha só começa quando todos os jogadores tiverem posicionado as suas unidades. Quando estás na fase de posicionamento não poderás ver as unidades dos 
    adversários. Essas unidades só serão visiveis quando a batalha começar.
    <p />
    Abaixo está um video de demonstração de como posicionar as unidades:
    <p /></div>
</asp:Content>