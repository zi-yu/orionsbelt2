<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ultime
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ultimate Units</h1>
<div class="content">
    <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> units are the most powerful <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> of every race. These units are special because they
    aren't placed on the <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. However, they can attack and be attacked.
    <p />
    Each <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> unit has very special powers, that make them the ultimate winner decider.
    <p />
    <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> units:
  </div>
	<ul class='imageList'><li><a href='/fr/Unit/Queen.aspx'><img class='queen' src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Reine' /></a></li><li><a href='/fr/Unit/Blinker.aspx'><img class='blinker' src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Téléporteur' /></a></li><li><a href='/fr/Unit/BattleMoon.aspx'><img class='battlemoon' src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Lune de Combat' /></a></li></ul>
	
</asp:Content>