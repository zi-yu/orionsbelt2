<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Piège Diagonale
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tactiques de Combat</h2><ul><li><a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li><li><a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a></li><li><a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a></li><li><a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a></li><li><a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Piège Diagonal</h1>
<div class="content">
    La <a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a> est une tactique dont le but est de prendre avantage des limitations des unités pouvant seulement se déplacer à la diagonale. <a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a> Par exemple, le <a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>, le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a>, le <a class='doomer' href='/fr/Unit/Doomer.aspx'>Anihilateur</a> et l'<a class='interceptor' href='/fr/Unit/Interceptor.aspx'>Intercepteur</a>. 
    <p />
    Les <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> avec <a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a> peuvent être pris au piège sans pouvoir s'échapper si il y a des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> adverses sur chacun des coins par rapport à cet unité. can be stuck without any way to escape if they have enemy <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>
 Une unité ne peut pas attaquer directement les cases diagonales et devient donc complètement vulnérable.
    <p />
    Voici un exemple montrant une <a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a> sur les 4 coins:

    <img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Diagonal Trap Example" />

    Et cet exemple montre une <a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a> sur une extremité du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>:
    
    <img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Diagonal Trap Example" />

  Vous devriez faire très attention lorsque vous déplacez des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> avec <a href='/fr/Battles/Movement.aspx#MovDiagonal'>Mouvement Diagonale</a> à l'extrêmité du
  <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. Non seulement cette unité perd 50% de sa mobilité, elle risque aussi de tomber plus facilement dans une <a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a>.

  <h2>Comment combattre un piège diagonal?</h2>
  La meilleura façon de combattre cette tactique est simplement d'éviter le piège de l'adversaire. Si l'ennemi réussit tout de même à vous attirer dans son piège, la seule façon de sauver l'unité victime est d'utiliser d'autres <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> pour détruire celle qui forment la trappe.
    </div>

</asp:Content>