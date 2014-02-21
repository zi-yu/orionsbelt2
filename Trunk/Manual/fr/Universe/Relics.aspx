<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Reliques
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Reliques</h1>
<div class="content">
    UNe <a href='/fr/Universe/Relics.aspx'>Relique</a> sont des structures spéciales existants sur l'<a href='/fr/Universe/Default.aspx'>Univers</a>, et elles sont spécifiques aux guerres des <a href='/fr/Universe/Alliance.aspx'>Alliance</a>. Lorsqu'une <a href='/fr/Universe/Alliance.aspx'>Alliance</a> possède une ou plusieurs <a href='/fr/Universe/Relics.aspx'>Reliques</a>,
    touts les membres reçoivent une quantité d'une ressource rare par jour. La quantité donné dépends du nombre de reliques que possède l'alliance et le range spécifique de chaque joueur.
    <p />
    Ce que l'<a href='/fr/Universe/Alliance.aspx'>Alliance</a> reçoit au total dépends de:
    <ul><li>Chaque relique, donnat un nombre K de ressources multiplié par <a href='/fr/Universe/HotZone.aspx#levels'>Niveau de zone</a> de la relique. Si la relique est en guerre, les ressources obtenus diminue jusqu'as huit fois.</li><li>La somme des ressources de toutes les reliques ets multiplié par le % de reiques détenu au total sur l'univers.</li></ul>
    Cela signifie qu'un plus grand nombre de <a href='/fr/Universe/Relics.aspx'>Reliques</a> donnera une plus grande quantité de ressources. K est une constante interne, pouvant changer, à la discrétion des administrateurs. 
    <p />
    Chaque <a href='/fr/Universe/Relics.aspx'>Relique</a> possède sont propre protecteur: un membre d'un alliance ayant conqurérit une relique est responsable de la défendre.
  </div>
	
</asp:Content>