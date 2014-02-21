<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Alliance
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Alliances</h1>
<div class="content">
    Une <a href='/fr/Universe/Alliance.aspx'>Alliance</a>  est une groupe de joueurs ayant un but commun: se protéger, s'enrichir et peut-être même dominer. Vous avez besoin d'<a href='/fr/Commerce/Orions.aspx'>Orions</a> pour créer une alliance.
    Par la suite, vous pouvez inviter et accpter d'autres joueurs et leur donner un rang dans votre alliance. Les rangs disponibles sont::
    <ul><li>Admiral - Grand commandeur, de l'alliance, le chef.</li><li>Vice Admiral - Étant ;es seconds au commandement, on pourrait pratiquement les considérer comme des chefs.</li><li>Vétéran - un membre ancien et profondément investit dans le bien-être de l'alliance.</li><li>Membre - un nouveau ou quelqu'un qui n'a pas fait ses preuves.</li></ul>
    Chaque <a href='/fr/Universe/Alliance.aspx'>Alliance</a> devrait essayer de capturer le plus de <a href='/fr/Universe/Relics.aspx'>Reliques</a> possible. Les <a href='/fr/Universe/Relics.aspx'>Reliques</a> génèrent un revenus de ressources rares dans l'alliance, qui sera redistribuée entre les membres.
    <p /><h2>Alliance Diplomacy</h2>
    Les alliances peuvent s'engager dans des guerres contres d'autres pour tentet d'obtenir la suprématie, mais peuvent aussi s'entraider. Il y a plusieurs niveaux diplomatiques existant entre les alliances, et c'est l'admiral qui en décide::
    <ul><li>Conféderation - Ces alliances ne font qu'un.</li><li>Pacte de non-agression - Les joueurs entre ces alliances ne s'attaquent pas</li><li>Neutre - Le niveau diplomatique par défaut</li><li>Guerre! - Que le jeu commence!</li></ul>
    Il est bien important de comprendre que même si vous êtes en paix avec une autre alliance, le jeu n'emp^che pas les attaques entre les joueurs concernés. Ces états diplomatiques sont des arrangements pouvant être brisés sans pré-avis.
  </div>
	
</asp:Content>