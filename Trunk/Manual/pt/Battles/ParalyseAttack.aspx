<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Paralizador
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Paralizador</h1>
	<div class="content">
    <a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a> é um ataque muito poderoso. Uma única unidade com este poder pode prevenir a utilização de qualquer grupo de unidades ([Attack]
    e <a href='/pt/Battles/Movement.aspx'>Movimento</a>) durante 1 turno de batalha. Este ataque pode ser muito útil para bloquear unidades importantes e/ou destrui-las lentamente ou prevenir
    a passagem de outras unidades.
    <p />
    Cuidado que no teu turno as unidades já não estarão mais paralizadas. Portanto se as quiseres atacar (especialmente unidades com
    <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> and [ParalyseAttack] - like <a class='spider' href='/pt/Unit/Spider.aspx'>Aranha</a>) não te esquecças de paralizar primeiro e/ou atacar dos lados ou por trás.
    <p />
    Abaixo está uma imagem do <a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a> quando uma <a class='spider' href='/pt/Unit/Spider.aspx'>Aranha</a> ataca uma <a class='doomer' href='/pt/Unit/Doomer.aspx'>Aniquiladora</a>:
    <img class="block" src="/Resources/Images/Paralyse.png" alt="Ataque paralizante" /></div>
</asp:Content>