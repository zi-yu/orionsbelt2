<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque explosive
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Attaque explosive</h1>
	<div class="content">
    <a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a> est peut-être l'attaque la plus puissante du jeu, si elle est bien utilisée. Une unité de combat avec <a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a>
    inflige ds dégâts sur tous les adversaires à une case adjacente. Cette aptitude est excellente pour éliminer les <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> de l'ennemi ou infliger des dommages collatéraux a un large groupe d'ennemis. 
    <p />
    Voici un exemple de la <a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a> en action :

    <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />
    
    Sur cet exemple, les dégâts infligés à la cible initiale seront aussi infligés sur tous les groupes d'ennemis <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> adjacents. Les dégâts sont maximaux.
  </div>
	
</asp:Content>