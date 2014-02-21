<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ricochete
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ricochete</h1>
	<div class="content">
   O <a href='/pt/Battles/Rebound.aspx'>Ricochete</a> é o caso em que a força do ataque não é desperdiçada , se for demasiado para destruir o primeiro conjunto de <a href='/pt/UnitIndex.aspx'>Unidades</a>, 
   a restante força do ataque passa para o conjunto de <a href='/pt/UnitIndex.aspx'>Unidades</a> que esteja imediatamente atrás do conjunto de <a href='/pt/UnitIndex.aspx'>Unidades</a> atacadas.<p /><img class="block" src="/Resources/Images/Rebound.png" alt="Ricochete" />

    Nesta imagem pode-se ver as <a class='fenix' href='/pt/Unit/Fenix.aspx'>Fénix</a> a atacar as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>, imagine-se que o ataque das <a class='fenix' href='/pt/Unit/Fenix.aspx'>Fénix</a> é de 10000 e a defesa das
    <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> é só de 8000, então as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> iríam sofre dano de 2000 (10000 - 8000 = 2000). Mas se as <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> não estivessem
    imediatamente atrás das <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> já não sofreriam dano algum, bastaria existir um quadrado entre as <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a> e <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>.
  </div>
	
</asp:Content>