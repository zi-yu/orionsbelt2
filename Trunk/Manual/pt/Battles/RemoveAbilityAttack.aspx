<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Remoção de Habilidades
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Remoção de Habilidades</h1>
	<div class="content">
    Este ataque é muito util embora seja complicado de executar porque a única unidade que o pode fazer é o <a class='hiveking' href='/pt/Unit/HiveKing.aspx'>Rei da Colmeia</a>. Quando uma unidade com <a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a> ataca,
    o alvo perde todos os ataques especiais durante 1 turno. Isto significa que a unidade só pode executar ataques normais.
    <p />
    Se este ataque for bem usado, algumas das unidades com grande poder de devastação (como os <a class='taurus' href='/pt/Unit/Taurus.aspx'>Touro</a>) vão perder tudo o que as torna poderosas.
   </div>
</asp:Content>