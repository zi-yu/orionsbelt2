<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Tournois
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zone de Guerre</h2><ul><li><a href='/fr/Battles/Tournaments.aspx'>Tournois</a></li><li><a href='/fr/Battles/Ladder.aspx'>Échelle</a></li><li><a href='/fr/Battles/Friendly.aspx'>Amical</a></li><li><a href='/fr/Battles/ELO.aspx'>Classification ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Tournois</h1>
	<div class="content">
    Les <a href='/fr/Battles/Tournaments.aspx'>Tournois</a> sont les champs de bataille ultime pour les joueurs d'<a href='http://www.orionsbelt.eu'>Orion's Belt</a>. Vous devrez faire face au meilleurs joueurs du jeu et prouver votre valeur pour gagner. Vous pourrez participer à des tournois de type <a href='/fr/Battles/Regicide.aspx'>Régicide</a> et <a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a>.
    Being good at tournaments also increases your <a href='/fr/Commerce/Orions.aspx'>Orions</a>.
    
    <h2>Tournaments Structure</h2>
    Il y plusieurs étapes à un tournoi. Un tournoi commence avec les inscriptions. Si vous avez atteint les pré-requis, vous pourrez participer au tournoi et vous serez placer dans un des 10 groupes. Le tournoi débute avec les groupes, ou vous devrez combattre ceux qui font partie de votre groupe.
    <p />
    Dans l'étape, groupe, les joueurs en 3 premières postions de chaque groupes passent aux finales. Il est possible que d'autres joueurs soient inclus pour en avoir suffisament pour les finales
    <p />
    Si vous perdez durant les finales, vous êtes éliminé.
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>