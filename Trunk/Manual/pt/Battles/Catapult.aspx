<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Catapulta
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Ataque Catapulta</h1>
<div class="content">
    Provavelmente o ataque <a href='/pt/Battles/Catapult.aspx'>Catapulta</a> é o mais imparável de todos os ataques, isto porque mesmo tendo <a href='/pt/UnitIndex.aspx'>Unidades</a> que
    sirvam de <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>, neste caso elas são inúteis. <p />
    A <a href='/pt/Battles/Catapult.aspx'>Catapulta</a> ignora qualquer unidade que esteja à sua frente, seja inimiga ou da mesma <a href='/pt/Universe/Fleet.aspx'>Armada</a>, e possibilita atacar
    qualquer unit inimiga que esteja no <a href='/pt/Battles/Range.aspx'>Alcance</a> da unidade que vai efectuar o disparo. Um exemplo disso é a imagem seguinte:

    <img class="block" src="/Resources/Images/Catapult.png" alt="Catapulta" />

    Este ataque é perfeito para fazer ataques quirurgícos por detrás de uma barreira defensiva.<p />
    Outro factor que torna este ataque bastante interessante, é o <a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a> da unidade atacada ser ignorado no
    caso da unidade que efectua o disparo ter uma unidade entre ela e a unidade atacada.

  </div></h1>
	
</asp:Content>