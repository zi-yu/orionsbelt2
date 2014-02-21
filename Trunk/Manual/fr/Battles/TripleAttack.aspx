<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque triple
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Attaque triple</h1>
	<div class="content">
    <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a> est une attaque dévastatrice pouvant détruire 3 groupes d'unités en même temps, en une seule attaque! Lorsqu'un groupe d'unité utilise <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a> pour attaquer, les groupes adjacents à la cible vont recevoir <b>50 %</b> des dégâts infligés sur la cible principale.
    <p />
    Cette aptitude est l'idéale pour détruire les <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> de l'ennemi et attendre des groupes habituellement <i>hors de portée</i>.
    Voici un exemple :

    <img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />

    Tout les <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> de l'ennemi sont détruit parce que le <a class='driller' href='/fr/Unit/Driller.aspx'>Perçeur</a> a l'aptitude <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a> et que les groupes de 
    <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> sont directement adjacents à la cible du <a class='driller' href='/fr/Unit/Driller.aspx'>Perçeur</a> et perpendiculaire à ce dernier.

    <p />
    <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> avec <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a> peuvent attendre des groupes <i>hors de portée</i> en voici un exemple éloquent : Le <a class='fenix' href='/fr/Unit/Fenix.aspx'>Fénix</a> ennemi est bien protégé par des <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> empêchant une attaque directe.
    Par contre, comme expliqué déjà, le <a class='driller' href='/fr/Unit/Driller.aspx'>Perçeur</a> peut s'introduire à travers la ligne ennemie et infliger des dégâts aux <a class='fenix' href='/fr/Unit/Fenix.aspx'>Fénix</a> avec la <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a>:

    <img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></div>
	
</asp:Content>