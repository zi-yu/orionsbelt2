<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ligne de vision
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Ligne de vision</h1>
	<div class="content">
   <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> is the visible area around something that belongs to you (a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>, a <a href='/fr/Universe/Planets.aspx'>Planète</a>, etc). In this area you can see everything that is moving 
   including enemy units.
   <p />
   There are 3 types of <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a>:
   <p /><ul><li>
 <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> one square arround the <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>. This <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> is present in <a href='/fr/Universe/Fleet.aspx'>Escadrilles</a> with only <a href='/fr/Battles/Light.aspx'>Légère</a> units.<p /><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></li><li>
 <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> two squares arround the some element in the Universe. This <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> is present in <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>s with, at least, one <a href='/fr/Battles/Medium.aspx'>Médium</a> or <a href='/fr/Battles/Heavy.aspx'>Lourde</a> unit and in <a href='/fr/Universe/Planets.aspx'>Planète</a>.<p /><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></li><li>
 <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> three squares arround the <a href='/fr/Universe/Beacon.aspx'>Satellite</a>:<p /><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></li></ul><p /></div>
</asp:Content>