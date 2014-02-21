<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Contra-Ataque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Contra-Ataque</h1>
	<div class="content">
    O <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> é um ataque que é bom ter mas não é fundamental para de ganhar uma batalha. O que acontece é que quando um grupo de 
    <a href='/pt/UnitIndex.aspx'>Unidades</a> com esta habilidade é atacado, as <a href='/pt/UnitIndex.aspx'>Unidades</a> que sobrevivem desse grupo atacam automáticamente sem que o jogador precise de 
    o indicar ou inclusivé gastar movimentos de ataque.<p />
    Mas este ataque tem algumas limitações, nem todos os ataques são passíveis de ser contra atacados, as imagens seguintes 
    ajudam a perceber essas limitações:

    <div class="block"><img style="margin-right:90px" src="/Resources/Images/strikeBack1.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack4.png" alt="Strike Back" /></div><br /><div class="block"><img style="margin-right:34px" src="/Resources/Images/strikeBack3.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack2.png" alt="Strike Back" /></div><br />
    As <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> são uma unidade que tem a habilidade de <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> e em todos os exemplos vamos efectuar ataques às <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>.
    Na primeira imagem as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> não vão contra atacar porque estão a ser atacadas pela <a class='spider' href='/pt/Unit/Spider.aspx'>Aranha</a> que tem a habilidade de <a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a>,
    logo as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> são paralizadas não efectuando o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a>.<p />
    Na segunda imagem as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> estão a ser atacadas pelas <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>, mas como as <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> têm as <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a> à frente estão a atacar 
    usando a habilidade <a href='/pt/Battles/Catapult.aspx'>Catapulta</a>, logo as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> não conseguem atingir as <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> com o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> porque têm as <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a> 
    no caminho.<p />
    O terceiro ataque também não provoca <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> porque as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> não estão a atacar frontalmente as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>.<p />
    Finalmente, o quarto ataque é o único que vai provocar <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> porque as <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a> estão a atacar frontalmente as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> 
    e não têm qualquer tipo de habilidade que evite o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a>.<p />
    Ainda existem outras duas situação em que o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> não é activo. No caso da unidade com a habilidade de <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> não ter <a href='/pt/Battles/Range.aspx'>Alcance</a> suficiente 
    para responder ao ataque. Por exemplo se as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> forem atacadas a 5 de distância por <a class='nova' href='/pt/Unit/Nova.aspx'>Nova</a> não conseguem responder ao ataque porque só têm 
    <a href='/pt/Battles/Range.aspx'>Alcance</a> de 3. A última situação em que o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> não é activado, é quando a unidade (ex:<a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>) com a habilidade de <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> 
    é atingida com <a href='/pt/Battles/Rebound.aspx'>Ricochete</a>.
  </div>
	
</asp:Content>