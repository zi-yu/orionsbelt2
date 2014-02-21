<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Catapulte
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Catapult Attack</h1>
<div class="content">
  Probablement que l?aptitude <a href='/fr/Battles/Catapult.aspx'>Catapulte</a> est l?attaque la plus difficile à arrêter car, même si il y a des <a href='/fr/UnitIndex.aspx'>Unités</a>
    qui sont considérés comme des <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> elles ne servent plus à rien. <p />
    La<a href='/fr/Battles/Catapult.aspx'>Catapulte</a> permet d?ignorer l?unité qui se trouve en avant pour cibler une unité à sa <a href='/fr/Battles/Range.aspx'>Portée</a>. Voici un exemple:

    <img class="block" src="/Resources/Images/Catapult.png" alt="Catapult" />

  Cette attaque est parfaite pour des attaques de précisions pour éliminer de puisantes unités derrière une barrière de défense. <p />
  Une autre utilité de cette attaque est que l?aptitude <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> de la cible peut être ignoré lorsqu?il y a une unité qui bloque son tir de contre-attaque.

  </div></h1>
	
</asp:Content>