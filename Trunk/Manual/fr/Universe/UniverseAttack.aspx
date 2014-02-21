<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Attaque</h1>
	<div class="content">
    In order to attack something in the <a href='/fr/Universe/Default.aspx'>Univers</a>, you must have a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> with units inside.
    <p />
    To attack another player simply select your <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> and click above the other player <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> or <a href='/fr/Universe/Planets.aspx'>Planète</a>.
    <p />
    If you click over a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>, the following menu will appear:
    <p /><img src="/Resources/Images/en/AttackFleet.png" alt="Attack a Fleet" /><p />
    After you click in the option 'Attack', the <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> will start moving and engage the enemy <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>.
    <p />
    If the target <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> is moving, a diferent option will appear:
    <p /><img src="/Resources/Images/en/AttackPursuit.png" alt="Pursuit a Fleet" /><p />
    This means that your <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> will pursuit the target <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> until it is attacked.
    <p />
    When your <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> attacks a <a href='/fr/Universe/Planets.aspx'>Planète</a>, the following options will appear:
    <img src="/Resources/Images/en/Conquer2.png" alt="Attack a Planet" /><p />
    These options mean:
    <ul><li>Attack <a href='/fr/Universe/Planets.aspx'>Planète</a> and <a href='/fr/Universe/Conquer.aspx'>Conquérir</a>: If there is no defense you <a href='/fr/Universe/Conquer.aspx'>Conquérir</a> the <a href='/fr/Universe/Planets.aspx'>Planète</a> immediattly. Otherside, a [Battle] is started</li><li>Raid <a href='/fr/Universe/Planets.aspx'>Planète</a>: If there is no defense units, you steal the resources without a [Battle]. Otherside, a [Battle] is started and you only steal the resources if you win it. In this case, the <a href='/fr/Universe/Planets.aspx'>Planète</a> isn't conquered.</li></ul></div>
</asp:Content>