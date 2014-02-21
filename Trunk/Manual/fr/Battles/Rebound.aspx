<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ricochet
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Rebond</h1>
	<div class="content">
    L’aptitude <a href='/fr/Battles/Rebound.aspx'>Rebond</a> évite le gaspillage de puissance. Si les dégâts totaux pour détruire un groupe d’<a href='/fr/UnitIndex.aspx'>Unités</a> est plus grand que nécessaire, alors la différence est engendrée sur le groupe de <a href='/fr/UnitIndex.aspx'>Unités</a> directement derrière le premier groupe attaquée. <p /><img class="block" src="/Resources/Images/Rebound.png" alt="Rebound" />

   On peut voir un <a class='fenix' href='/fr/Unit/Fenix.aspx'>Fénix</a> qui attaque un <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> dans cette image. Imaginez que L’attaque du <a class='fenix' href='/fr/Unit/Fenix.aspx'>Fénix</a> est de 10000 et la protection du <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> est de seulement 8000. Alors, les <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> vont souffrir de 2000 dégâts. (10000 - 8000 = 2000). Par contre, si les <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> n’était pas directement derrière le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> il n’aurait pas reçu de dégâts.  </div>
	
</asp:Content>