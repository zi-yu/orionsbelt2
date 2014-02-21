<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Suprema
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Unidades Supremas</h1>
<div class="content">
    Uma unidade <a href='/pt/Battles/Ultimate.aspx'>Suprema</a> é a unidade de combate mais poderosa de cada raça. Estas unidades são especiais na
    medidada em que não estão presentes no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>. Ainda assim conseguem ser atacadas.
    <p />
    Cada unidade <a href='/pt/Battles/Ultimate.aspx'>Suprema</a> tem poderes muito especiais, que fazem com que sejam muito importantes numa batalha.
    <p />
    Lista de unidades de supremas:
  </div>
	<ul class='imageList'><li><a href='/pt/Unit/Queen.aspx'><img class='queen' src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Rainha' /></a></li><li><a href='/pt/Unit/Blinker.aspx'><img class='blinker' src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Pisca-pisca' /></a></li><li><a href='/pt/Unit/BattleMoon.aspx'><img class='battlemoon' src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Lua de Batalha' /></a></li></ul>
	
</asp:Content>