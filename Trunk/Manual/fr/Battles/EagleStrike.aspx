<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque de l'aigle
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tactiques de Combat</h2><ul><li><a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li><li><a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a></li><li><a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a></li><li><a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a></li><li><a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>L'ataque de l'aigle</h1>
<div class="content">
    La tactique <a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a> a pour but d'élimiiner certaines <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> adversaes plutôt faible qui pourrait devenir ue menace plus tard dans le combat, dès les premiers tours.
    present a threat in the future. Il faut sacrifier un petit groupes d'aigles pour détruire:
    <ul><li>
    Le <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> - qui peut détruire des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> importantes, sans mentionner la <a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a> toujours présente!
  </li><li><a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> - Cette unité possède un gros bonus contre les unités <a href='/fr/Battles/Heavy.aspx'>Lourde</a> et le <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> est donc une menace.</li><li><a class='seeker' href='/fr/Unit/Seeker.aspx'>Ouvrier</a> - Cete unité possède un gros bonus contre les unités <a href='/fr/Battles/Medium.aspx'>Médium</a>, le <a class='seeker' href='/fr/Unit/Seeker.aspx'>Ouvrier</a> est donc aussi une menace</li><li>DEs groupes considérable d'unités <a href='/fr/Battles/Light.aspx'>Légère</a> pouvant êtres utilisés en tant que <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li></ul>
    Toutes ces <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> peuvent faire une grande différence dans une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>  mais sont très faibles. C'est pour cette raison qu'un petit groupe d'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a> peut les détruire.
    <p />
    La préparation pour un <a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a> commence au <a href='/fr/Battles/Deploy.aspx'>Déploiement</a>. Vous devriez placer 2-3 groupes d'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>
    au front. Au premier tour, vous bougez ensuite ces unités d'une case. Exemple:

    <img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

   Comme vous pouvez le voir, les groupes d'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a> sont une menace pour les <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> et <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> de l'adversaire. Il sera difficile pour l'adversaire de protéger les 2 groupes. Et même si il le peut, ce sera probablement la seule chose qu'il fera en terme de mouvement.
    
    <p />
    
    Le <a class='kahuna' href='/fr/Unit/Kahuna.aspx'>Kahuna</a> peut aussi être utilisé à la place de l'<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>, mais il ne sera pas aussi efficace.

  </div>

</asp:Content>