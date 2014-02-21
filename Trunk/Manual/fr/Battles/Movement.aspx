<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mouvement
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mouvement de Combat</h1>
<div class="content">
    Les mouvments de combats font références à l'acte de bouger les <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> suite au <a href='/fr/Battles/Deploy.aspx'>Déploiement</a>.
    Chaque unité possède sont propre type de mouvement, pouvant être l'une de ces dernières:
    <ul><li><a href='/fr/Battles/Movement.aspx#MovAll'>Mobilité totale</a></li><li><a href='/fr/Battles/Movement.aspx#MovNormal'>Mobilité normale</a></li><li><a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a></li><li><a href='/fr/Battles/Movement.aspx#MovFront'>Mobilité Frontale</a></li><li><a href='/fr/Battles/Movement.aspx#MovDrop'>Mobilité de dépôt</a></li><li><a href='/fr/Battles/Movement.aspx#MovNone'>Aucune mobilité</a></li></ul>
    Le type de mouvement et le <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> définit la vitesse d'une unité.

    <a name="MovAll" id="MovAll"></a><h2><a href='/fr/Battles/Movement.aspx#MovAll'>Mobilité totale</a></h2> 
    Avec <a href='/fr/Battles/Movement.aspx#MovAll'>Mobilité totale</a> une unité peut se déplacer à n'importe quelle case adjacente. Exemple:
    <img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/fr/Battles/Movement.aspx#MovNormal'>Mobilité normale</a></h2>
    Avec <a href='/fr/Battles/Movement.aspx#MovNormal'>Mobilité normale</a>  une unité peut se déplacer à n'importe quelle case adjacente, sauf les diagonales. Exemple:
    <img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a></h2>
    Vace <a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a>une unité peut seulement se déplacer à la diagonale (spyez conscient de la <a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a>). Exemple:
    <img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/fr/Battles/Movement.aspx#MovFront'>Mobilité Frontale</a></h2>
    Avec <a href='/fr/Battles/Movement.aspx#MovFront'>Mobilité Frontale</a>une unité peut seulement bouger vers l'avant. Pour changer de direction, il faudra utiliser la rotation.. Exemple:
    <img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/fr/Battles/Movement.aspx#MovDrop'>Mobilité de dépôt</a></h2>
    Une unité avec <a href='/fr/Battles/Movement.aspx#MovDrop'>Mobilité de dépôt</a> est une unité pouvant déposer d'autres unités sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> en bougant.
    Exemple: la <a class='queen' href='/fr/Unit/Queen.aspx'>Reine</a> peut déposer un <a class='egg' href='/fr/Unit/Egg.aspx'>Oeuf</a> sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>.

    <a name="MovNone" id="MovNone"></a><h2><a href='/fr/Battles/Movement.aspx#MovNone'>Aucune mobilité</a></h2>
    Une unité avec <a href='/fr/Battles/Movement.aspx#MovNone'>Aucune mobilité</a> ne peut plus bouger durant toute la bataille. Exemple:
    <img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a></h2>
    Le type de <a href='/fr/Battles/Movement.aspx'>Mouvement</a> comment une unité bouge sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>, Mais toutes les <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> ont aussi un
    <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> qui se traduit par comments rapides ils sont. À chaque tour de combat, un jour reçoit 6 <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a> à dépenser:
    il peut bouger ses unités, attaquer avec ses unités, ou les ignorer.
    <p />
    Si une unité a un <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> de 2, cela signifie qu'il peut bouger 3 trois fois durant le même tour. (6/2=3). Par exemple, le <a class='doomer' href='/fr/Unit/Doomer.aspx'>Anihilateur</a> a une coût de 3 et L'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a> un coüt de 2. Cela signifie que l'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>
    est plus rapide que le <a class='doomer' href='/fr/Unit/Doomer.aspx'>Anihilateur</a>, même si chaque unité ont le <a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a>.

    <a name="MovPoints" id="MovPoints"></a><h2><a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a></h2>
    Les <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a> représente le nombre d'actions que vous pouvez faire en un seul tour de bataille. À chaque tour vous recevez 6 <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a> à dépenser, et il y a plusieurs actions que vous pouvez faire:
    <ul><li>Une attaque coûte un point de mouvement</li><li>Déplacer une unité de combat dépends de son coût en mouvement. Toutes les <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>
  ont un <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> prédéfinis.</li><li>Séparer un groupe d'unité, coûte le double du coût de mouvement habituel.</li></ul></div>
	
</asp:Content>