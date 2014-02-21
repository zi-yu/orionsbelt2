<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque Vénéneuse
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Attaque Vénéneuse</h1>
	<div class="content">
    <a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a> est un empoisonnement de l'unité adverse. (En réalité, de minuscules larves volatiles et voraces tranperçents vaisseaux et carapaces pour tenter de se nourrir de la matière organique cachée à l?intérieur...) Si une unité avec l?aptitude <a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a> attaque, elle recevra une certaine quantité de dégâts sur une période de 3 tours, incluant celui où l?attaque a été porté.i
    <p>
    La quantité de dégâts subie est l?équivalent de 20 % de l?attaque de l?unité ayant l?aptitude. Si une unité attaque pour 1000 et possède cette aptitude, les dégâts totaux seront à 1200 immédiatement et 200 pour les 2 prochains tours.
    </p><p>
    Cette attaque est cumulative, une unité peut souffrir de plus qu?une seule infestation en même temps.
    </p><p>
    Cette aptitude est distincte à la <a class='blackwidow' href='/fr/Unit/BlackWidow.aspx'>Veuve Noire</a> et le <a class='hiveking' href='/fr/Unit/HiveKing.aspx'>Roi coloniale</a>.
    </p><p>
    Voici l?image d?un <a class='hiveking' href='/fr/Unit/HiveKing.aspx'>Roi coloniale</a> utilisant une infestation contre un <a class='scarab' href='/fr/Unit/Scarab.aspx'>Scarabé</a>:
    <img class="block" src="/Resources/Images/Infestation.png" alt="Infestation Attack" /></p></div>
	
</asp:Content>