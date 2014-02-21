<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Área de Visión
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Área de Visión</h1>
	<div class="content">
   <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> is the visible area around something that belongs to you (a <a href='/es/Universe/Fleet.aspx'>Flota</a>, a <a href='/es/Universe/Planets.aspx'>Planeta</a>, etc). In this area you can see everything that is moving 
   including enemy units.
   <p />
   There are 3 types of <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a>:
   <p /><ul><li>
 <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> one square arround the <a href='/es/Universe/Fleet.aspx'>Flota</a>. This <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> is present in <a href='/es/Universe/Fleet.aspx'>Flotas</a> with only <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> units.<p /><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></li><li>
 <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> two squares arround the some element in the Universe. This <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> is present in <a href='/es/Universe/Fleet.aspx'>Flota</a>s with, at least, one <a href='/es/Battles/Medium.aspx'>Médio Porte</a> or <a href='/es/Battles/Heavy.aspx'>Gran Porte</a> unit and in <a href='/es/Universe/Planets.aspx'>Planeta</a>.<p /><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></li><li>
 <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> three squares arround the <a href='/es/Universe/Beacon.aspx'>Centinela</a>:<p /><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></li></ul><p /></div>
</asp:Content>