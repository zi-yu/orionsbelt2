<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Diagonale Falle
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Taktiken</h2><ul><li><a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a></li><li><a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a></li><li><a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a></li><li><a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a></li><li><a href='/de/Battles/FiringSquad.aspx'>Erschiessungskommando</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Diagonal Trap</h1>
<div class="content">
    Die <a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a> ist eine Taktik die darauf ausgerichtet ist einen Nutzen zu ziehen aus der 
    limitierten Beweglichkeit der <a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a> Einheiten, zum Beispiel: <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a>, <a class='pretorian' href='/de/Unit/Pretorian.aspx'>Praetorian</a>, 
    <a class='doomer' href='/de/Unit/Doomer.aspx'>Doomer</a> or <a class='interceptor' href='/de/Unit/Interceptor.aspx'>Abfangjäger</a>. 
    <p>
    Die <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> mit <a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a> können steckenbleiben ohne jede Möglichkeit der Flucht wenn 
    sie feindliche <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> auf allen Vierecken haben die ihnen zur Verfügung stehen.
    Eine Einheit kann nur frontal angreifen, deshalb sind sie komplett verwundbar.
    </p><p>
    Das folgende Beispiel zeigt eine <a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a> an allen vier Ecken:

    <img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Diagonal Trap Example" />

    And this example shows a <a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a> on the extremity of the <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>:
    
    <img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Diagonal Trap Example" />

  Du solltest sehr vorsichtig sein wenn du deine <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> mit <a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a> zu den Extremitäten 
  des <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> bewegst. Sie verlieren nicht nur 50% Mobilität, sie werden auch viel anfälliger für 
  eine <a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a>.

  </p><h2>Wie bekämpft man eine Diagonal Falle?</h2>
  Der beste Weg diese Falle zu bekämpfen ist sie total zu vermeiden. Dennoch, wenn dein Gegner es 
  schafft die Falle anzuwenden, ist der einzige Fluchtweg andere <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu benutzen um 
  diejenigen die die Falle aufstellen zu zerstören.
    </div>

</asp:Content>