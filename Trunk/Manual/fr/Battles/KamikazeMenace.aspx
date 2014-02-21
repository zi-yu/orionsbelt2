<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Menace Kamikaze
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tactiques de Combat</h2><ul><li><a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li><li><a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a></li><li><a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a></li><li><a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a></li><li><a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1> Menace Kamikaze</h1>
<div class="content">
    <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> rdt l'une des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> les plus importantes du jeu. Ils sont très fragiles, mais ont une puissance de frappe dévastatrice et une libertés de mouvement leur pemmettant d'atteindre pratiquement toutes les caes sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>.
    À cause de ces caractéristiques, poaaéder des <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> sur le jeu est toujours un <i>menace</i> pour l'adversaire.
    Néanmoins, vous devez vous assurer que cette menace <i>menace</i> soit présente en toute temps!
    <p />
    Si vous avez un groupe de <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> bloqué serrière d'autres <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> où les ennemis sont hors de <a href='/fr/Battles/Range.aspx'>Portée</a>, ils ne sont pas considérés comme une menace pour les prochains tours. Un bon <a href='/fr/Battles/Deploy.aspx'>Déploiement</a> peut renforcir l'effet de la
 <a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a> dès le début. Analysons l'exemple suivant:

    <img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Kamikaze Menace Example" />

    Comme vous pouvez le voir, le joueur du bas possède 2 groupes <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a>, sur chaque côté du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>,
    protégé par des unités <a href='/fr/Battles/Heavy.aspx'>Lourde</a> et ayant une route d'attaque disponible.
    <p />
    Cette disposition permet au joueur de s'attaquer facilement à presques toutes les unités sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> avec un groupe de <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a>. Et cela est très important, car pendant que vous ne dépenser aucun points de mouvement <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a> avec ces derniers,
    L'adversaire doit toujours être conscient de la <i>menace</i> et utiliser de la <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> pour protéger chacun des ses mouvments.
    <p />
    Cette <i>menace</i> change complètement a stratégie de l'adversaire en l'obliigeant d'agir avec précaution.

    <h2>Comment combattre la Menace Kamikae?</h2>

    Il est plutôt embarassant de se défendre contre la stratégie de la <a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a> car le temps que cela prend permet à l'adversaire de déplacer d'autres
    <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> dans des positions stratégiques. Il y a néanmoins certaines choses pouvant être considérés:
    <ul><li>
    Si vous avez des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> avec <a href='/fr/Battles/Catapult.aspx'>Catapulte</a>, <a href='/fr/Battles/Rebound.aspx'>Ricochet</a> et <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a>, vous pouvez les utiliser pour détruire les <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a>
  </li><li>
    Une autre stratégie implique d'obliger l'adversaire à utiliser ses <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> contre un groupe d'unités sacrfiable;
    il est ainsi possible d'éiminer la <a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a> pour protégers des groupes de <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> beaucoup plus importants.
  </li></ul></div>

</asp:Content>