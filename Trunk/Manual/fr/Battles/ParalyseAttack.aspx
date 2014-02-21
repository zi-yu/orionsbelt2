<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque paralysante
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Attaque paralysante</h1>
	<div class="content">
    <a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a> est une attaque extrêmement puissante. Une seule unité avec ce pouvoir peut empêcher une unité adverse d?être utilisée pour le prochain tour de combat, que ce soit pour bouger ou attaquer. C?est très utile pour pouvoir bloquer des unités importantes et/ou les détruirent lentement ou encore bloquer le passage à des unités plus menaçantes. 
    <p>
    Sachez que l?unité ne sera par contre plus paralysée à votre tour de combat. Donc si vous voulez paralyser une unité (particulièrement celles qui ont les aptitudes 
<a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> et [ParalyseAttack] -  comme l?<a class='spider' href='/fr/Unit/Spider.aspx'>Araignée</a>) n?oubliez pas de paralyser l?unité à votre tour et attaquer celles avec StrikeBack sur les côtés ou par-derrière.
    </p><p>
    Voici l?image d?une <a class='spider' href='/fr/Unit/Spider.aspx'>Araignée</a> qui attaque un <a class='doomer' href='/fr/Unit/Doomer.aspx'>Anihilateur</a>:
    <img class="block" src="/Resources/Images/Paralyse.png" alt="Paralyse Attack" /></p></div>
</asp:Content>