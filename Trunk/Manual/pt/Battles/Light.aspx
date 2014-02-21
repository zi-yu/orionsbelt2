<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pequeno Porte
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceitos de Batalha</h2><ul><li><a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a></li><li><a href='/pt/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/pt/Battles/Movement.aspx'>Movimento</a></li><li><a href='/pt/Battles/Rules.aspx'>Regras</a></li></ul><h2>Ataque</h2><ul><li><a href='/pt/Battles/Range.aspx'>Alcance</a></li><li><a href='/pt/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/pt/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/pt/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/pt/Battles/StrikeBack.aspx'>Contra-Ataque</a></li><li><a href='/pt/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/pt/Battles/RemoveAbilityAttack.aspx'>Remoção de Habilidades</a></li><li><a href='/pt/Battles/TripleAttack.aspx'>Ataque Triplo</a></li><li><a href='/pt/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/pt/Battles/Rebound.aspx'>Ricochete</a></li></ul><h2>Categoria</h2><ul><li><a href='/pt/Battles/Light.aspx'>Pequeno Porte</a></li><li><a href='/pt/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/pt/Battles/Heavy.aspx'>Grande Porte</a></li><li><a href='/pt/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/pt/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalha</h2><ul><li><a href='/pt/Battles/TotalAnnihilation.aspx'>Destruição Total</a></li><li><a href='/pt/Battles/Regicide.aspx'>Regicídeo</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Unidades de Pequeno Porte</h1>
<div class="content">
    As unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> são categorizadas por serem as mais rápidas e mais frágeis do jogo. Uma unidade de
    <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> típica tem <a href='/pt/Battles/Movement.aspx#MovAll'>Movimento Total</a> e <a href='/pt/Battles/Movement.aspx#MovCost'>Custo de Movimento</a> de 1, além de ser mais barata que as <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> de <a href='/pt/Battles/Medium.aspx'>Médio Porte</a>
    e <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>.
    <p />
    Qualquer <a href='/pt/Universe/Fleet.aspx'>Armada</a> equilibrada tem uma percentagem substancial de unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a>, isto porque elas são
    indispensáveis como <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a>, uma das <a href='/pt/Battles/BattleTactics.aspx'>Tácticas de Batalha</a> mais usadas no <a href='http://www.orionsbelt.eu'>Orion's Belt</a>.
    <p />
    Mas as unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a> não são usadas somente para serem sacrificadas. Há unidades muito poderosas
    que impõem respeito a unidades de maior envergadura.
    <p />
    Lista de unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a>:
  </div>
	<ul class='imageList'><li><a href='/pt/Unit/Raptor.aspx'><img class='raptor' src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /></a></li><li><a href='/pt/Unit/Rain.aspx'><img class='rain' src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Rain' /></a></li><li><a href='/pt/Unit/Cypher.aspx'><img class='cypher' src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /></a></li><li><a href='/pt/Unit/Reaper.aspx'><img class='reaper' src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Ceifeiro' /></a></li><li><a href='/pt/Unit/Panther.aspx'><img class='panther' src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /></a></li><li><a href='/pt/Unit/Seeker.aspx'><img class='seeker' src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Batedor' /></a></li><li><a href='/pt/Unit/Egg.aspx'><img class='egg' src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Ovo' /></a></li><li><a href='/pt/Unit/Maggot.aspx'><img class='maggot' src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Larva' /></a></li><li><a href='/pt/Unit/DarkRain.aspx'><img class='darkrain' src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Rain Sombria' /></a></li><li><a href='/pt/Unit/Toxic.aspx'><img class='toxic' src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Tóxica' /></a></li><li><a href='/pt/Unit/Anubis.aspx'><img class='anubis' src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /></a></li><li><a href='/pt/Unit/Jumper.aspx'><img class='jumper' src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /></a></li><li><a href='/pt/Unit/Samurai.aspx'><img class='samurai' src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /></a></li><li><a href='/pt/Unit/Interceptor.aspx'><img class='interceptor' src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptador' /></a></li><li><a href='/pt/Unit/Sentry.aspx'><img class='sentry' src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Vigilante' /></a></li></ul>
	
</asp:Content>