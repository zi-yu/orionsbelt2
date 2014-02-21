<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Portée
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Portée des unités de combat</h1>
<div class="content">
    La <a href='/fr/Battles/Range.aspx'>Portée</a> est-ce qui détermine la distance à laquelle peut attaquer une unité. Toutes les unités peuvent attaquer, mais certaines ont des pouvoirs d'attaque très puissants.
    <p />
    L'exemple suivant montre la différence entre la <a href='/fr/Battles/Range.aspx'>Portée</a> de deux <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>: le <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a>
    et le <a class='krill' href='/fr/Unit/Krill.aspx'>Krill</a>. Le <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a> a une <a href='/fr/Battles/Range.aspx'>Portée</a> de 6, et peut attaquer n'importe quel unité en face de lui. Par contre, le <a class='krill' href='/fr/Unit/Krill.aspx'>Krill</a> a seulement une <a href='/fr/Battles/Range.aspx'>Portée</a> de 3, aet à cause de cela, peut seulement attaquer les unités se trouvant àune distance de 3 cases en avant.
    <p />
    À noter que s'il y a une autre unité entre l'attaqunt et la cible, l'attaque ne sera pas possible à moins que l'attaquant possède l'aptitude <a href='/fr/Battles/Catapult.aspx'>Catapulte</a>.

    <img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></div>
	
</asp:Content>