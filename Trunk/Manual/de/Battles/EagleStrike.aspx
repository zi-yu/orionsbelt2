<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Adler Angriff
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Taktiken</h2><ul><li><a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a></li><li><a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a></li><li><a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a></li><li><a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a></li><li><a href='/de/Battles/FiringSquad.aspx'>Erschiessungskommando</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Eagle Strike</h1>
<div class="content">
    Die <a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a> Taktik zielt darauf schwache gegnerische <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> in den Anfangsrunden zu 
    eliminieren die eine zukünftige Bedrohung darstellen. Die Taktik opfert kleine <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> Gruppen um 
    folgende Einheiten zu zerstören:
    <ul><li>
    <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> - können wichtige <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zerstören, nicht zu erwähnen die immer gegenwärtige 
    <a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a>
  </li><li><a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> - mit einem grossen Bonus gegen <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten, ist der <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> is eine grosse 
     Bedrohung</li><li><a class='seeker' href='/de/Unit/Seeker.aspx'>Sucher</a> - mit einem grossen Bonus gegen <a href='/de/Battles/Medium.aspx'>Medium</a> Einheiten, Sind die <a class='seeker' href='/de/Unit/Seeker.aspx'>Sucher</a> auch eine grosse 
    Bedrohung</li><li>Gruppen mit einer grossen Anzahl an <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten, können benutzt werden als 
    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>
  </li></ul>
    All diese <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> können unserer <a href='/de/Universe/Fleet.aspx'>Flotte</a> eineMenge Schaden zufügen,aber sin sind sehr 
    schwach. That's why we stellen wir kleine Gruppen von <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> bereit um sie zu zerstören.
    <p>
    Die Vorbereitung für einen <a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a> beginnt mit dem <a href='/de/Battles/Deploy.aspx'>Positionieren</a>. Du solltest 2/3 Gruppen der 
    <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> in der Front-Reihe positionieren. In deiner ersten Runde, bewege die Gruppen zu einem 
    Viereck. 
    Beispiel:

    <img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

    Wie du sehen kannst, stellen die <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> Gruppen eine Bedrohung dar für die gegnerischen <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> 
    und <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a>. Und es wird sehr schwierig für den Gegner, beide Gruppen zu beschützen. Und auch 
    wenn er es kann, wahrscheinlich wird er dann nicht in der Lage sein andere Bewegungen zu machen.
    
    </p><p>
    
    Die <a class='kahuna' href='/de/Unit/Kahuna.aspx'>Kahuna</a> können auch anstatt der <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> in Betracht gezogen werden, aber sie werden nicht so 
    effizient sein.

  </p></div>

</asp:Content>