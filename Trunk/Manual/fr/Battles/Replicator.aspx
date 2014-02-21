<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Réplicateur
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Réplicateur</h1>
	<div class="content">
    <a href='/fr/Battles/Replicator.aspx'>Réplicateur</a> est l'attaque qui permet d'augmenter le nombre dans votre armée et tout en abaissant celui de l'adversaire. Quand une unité avec cette aptitude spéciale attaque, il y aura réplication un certain nombre de fois; équivalent au nombre d'unités détruites. Si vous détruisez 6 unités, vous répliquez 6 fois. (en terme de quantité détruit; 6 = 6)
    <p />
    Cette aptitude particulière seulement si l'unité attaquée est au moins de la même catégorie que l'unité attaquante. Exemple : Une unité <a href='/fr/Battles/Medium.aspx'>Médium</a> possédant <a href='/fr/Battles/Replicator.aspx'>Réplicateur</a> se réplique seulement si a cible est une unité <a href='/fr/Battles/Medium.aspx'>Médium</a>
    ou <a href='/fr/Battles/Heavy.aspx'>Lourde</a>.
    <p />
    La seule unité possédant cette attaque est le <a class='stinger' href='/fr/Unit/Stinger.aspx'>Piqueur</a>. La réplication peut seulement se faire sur les unités <a href='/fr/Battles/Medium.aspx'>Médium</a> et <a href='/fr/Battles/Heavy.aspx'>Lourde</a>.
   </div>
</asp:Content>