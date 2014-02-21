<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Déploiement
	
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Déploiement</h1>
	<div class="content">
    Le <a href='/fr/Battles/Deploy.aspx'>Déploiement</a> est le première chose que chaque joueurs doit faire au début d'un combat. Chaque joueur commence alors avec un certain nombre d'unités qui doivent être placés dans les 16 premières cases du jeu. (voir l'image plus bas:)
    <p /><img class="block" src="/Resources/Images/DeployArea.png" alt="Deploy Area" /><p />
    Durant le <a href='/fr/Battles/Deploy.aspx'>Déploiement</a>, il n'y a pas de <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a> à dépenser et le type de <a href='/fr/Battles/Movement.aspx'>Mouvement</a> de chaque unité n'est pas considéré. Vous pouvez donc mettre vos unités ou bon vous semble et les diviser à votre guise.
    <p />
    Les même règles s'appliquent aux combats entre 4 ou 2 joueurs. L'endroit pour le déploiement de vos unités est semblable (voir l'image en bas).
    <p /><img class="block" style="width:510px;" src="/Resources/Images/DeployArea4.png" alt="Deploy Area for a 4 players battle" /><p />
   Le combat commence seulement quand tout les jours ont terminé le déploiement de leurs unités. Par ailleurs, durant votre déploiement, vous ne pouvez pas voir le déploiement de l'adversaire. Les unités de l'adversaire seront visibles sur le plateau de jeu seulement quand le combat commence.
    <p />
    Dans chaque bataille, même dans les batailles à 4, le type d'unités maximale différentes qu'un joueur peut avoir est de 8. La seule exceptions sont les combats <a href='/fr/Battles/Regicide.aspx'>Régicide</a> ou la limite monte à 9 à cause du <a class='flag' href='/fr/Unit/Flag.aspx'>Drapeau</a> considéré comme la neuvième unité rajouté automatiquement.
    <p />
    En bas ce trouve un vidéo pour apprendre comment faire un déploiement de vos unités:
    <p /></div>
</asp:Content>