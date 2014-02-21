<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Chair à canon
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tactiques de Combat</h2><ul><li><a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li><li><a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a></li><li><a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a></li><li><a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a></li><li><a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Chair à canon</h1>
	<div class="content">
    La tactique <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> est la <u>plus utilisé sur <a href='http://www.orionsbelt.eu'>Orion's Belt</a></u>! Elle consiste à utiliser une petite quantité d'unités de force <a href='/fr/Battles/Light.aspx'>Légère</a> pour défendre les autres unités plus importantes sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. Les unités <a href='/fr/Battles/Light.aspx'>Légère</a> sont peu coûteuses et très mobiles, donc idéales pour être sacrifiés pour protéger les  <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> plus puissantes.
    C'est pour cette raison que ces unités sont appelées <i>chair à canon</i>.
    <p />
    On utilise normalement les unités <a href='/fr/Battles/Light.aspx'>Légère</a> avec <a href='/fr/Battles/Movement.aspx#MovAll'>Mobilité totale</a> et un <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> de 1 en tant que <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a>. Par exemple:
    <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a>, <a class='anubis' href='/fr/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/fr/Unit/Seeker.aspx'>Ouvrier</a>, <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a> et si vous êtes vraiment désespéré: <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a>.

    <p />
    Analysons l'exemple suivant:

    <img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Exemplo de Carne para Canhão 1" />

    Comme vous pouvez le voir, il y 2 groupes de <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a> menaçant un groupe de <a class='spider' href='/fr/Unit/Spider.aspx'>Araignée</a>. Mais ces groupes ne pourront pas l'attaquer car deux petits groupes d'<a class='anubis' href='/fr/Unit/Anubis.aspx'>Anubis</a> bloque leurs lignes de mires. Et sa ne vaut pas la peine de se déplacer et d'atquer pour détruire un si petit groupe de <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    <p />
    La tactique des <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> est très important et utilisé par tout les joueurs. Cependant, bloquer les attaques adverses n'est pas la seule utilité de la stratégie <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a>.

    <h2>Arrêt du mouvement de l'adversaire</h2>

    Sur <a href='http://www.orionsbelt.eu'>Orion's Belt</a> il est possible d'avoir une seule unité <a href='/fr/Battles/Light.aspx'>Légère</a> sur une case du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. L'avantage de cela est que l'adversaire ne peut pas se déplacer sur cette case sans y détruire l'unité <a href='/fr/Battles/Light.aspx'>Légère</a> qui s'y trouve en premier.
    Cela signifie que les <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> <a href='/fr/Battles/Light.aspx'>Légère</a>  empêche l'adversaire d'être en position d'attaque.
    Analyson l'exemple précédent, en montrant une autre façon de protéger les <a class='spider' href='/fr/Unit/Spider.aspx'>Araignée</a>:

    <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Exemplo de Carne para Canhão 1" />

    Cette méthode est particulièrement utile contre les unités possédant l'aptitude <a href='/fr/Battles/Catapult.aspx'>Catapulte</a>, leur permettant d'ignorer les <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> et attaquer quand même. Donc, si vous ne pouvez empêcher une attaque, il faut considérer prévenir le mouvement permettant l'attaque qui aurait pu être dévastatrice.

    (N'oubliez pas ce conseil lorsque votre adversaire possède l'unité <a class='vector' href='/fr/Unit/Vector.aspx'>Vecteur</a> ou <a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>).

    <h2>Comment combattre la chair à canon?</h2>

    Gagner contre la tactique <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> peut-être un jeu de patience, où il vous faut détruire les 
    <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> de l'adversaire pour créer une ouverture ou obliger l'adversaire à faire une erreur.
    <p />
    Par contre, il y a des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> qui sont particulièrement utiles contre la <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a>. Toutes les unités avec l'aptitude:
    <a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a>, <a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a> et <a href='/fr/Battles/Rebound.aspx'>Ricochet</a> peuvent détruire plus d'un groupe d'unités par attaque. De l'autre côté, les unités ayant <a href='/fr/Battles/Catapult.aspx'>Catapulte</a> et une longue portée <a href='/fr/Battles/Range.aspx'>Portée</a> peuvent ignorer la <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> de l'adversaire pour une attaque directe.
    <p />
    La meilleure façon de combattre les <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> est simplement de les détruires au complet! Si vous détruisez toutes les unités <a href='/fr/Battles/Light.aspx'>Légère</a> de l'adversaire, il ne pourra plus utilisé ;a tactique <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a> et risque certainement de perdre.
    Une bonne unité contre les unités <a href='/fr/Battles/Light.aspx'>Légère</a> est le <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a>. Avec sont bonus contre les unités
    <a href='/fr/Battles/Light.aspx'>Légère</a>et sa <a href='/fr/Battles/Range.aspx'>Portée</a> de 2, le <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a> est <u>L'</u> ultime chasseur d'unités <a href='/fr/Battles/Light.aspx'>Légère</a>!

  </div>

</asp:Content>