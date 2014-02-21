<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Alianza
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Alianças</h1>
<div class="content">
    Una <a href='/es/Universe/Alliance.aspx'>Alianza</a> es un grupo de jugadores que comparten un objetivo común: protección, riqueza o domínio. Necesitas de <a href='/es/Commerce/Orions.aspx'>Orions</a> para crear una alianza.
    Así cuando estuviera creada, puedes convidar jugadores y aceptar jugadores, de la misma manera puedes también cambiar su escalón. Los escalones disponibles son:
    <ul><li>Almirante - el líder</li><li>Vice Almirante - el vice líder</li><li>Sargento - Miembro de la alianza con gran valor</li><li>Miembro - escalón mas bajo</li></ul><h2>Diplomacia de Alianza</h2>
    Las alianzas pueden entrar en guerra, pero también pueden coexistir pacifícamente. Existen multiples grados diplomáticos que un Almirante puede
    definir para cada una de las otras alianzas.
    <ul><li>Confederación - Tus alianzas son aliadas y con objetivos comunes</li><li>Pacto de No Agresión - Las alianzas acuerdan y nose atacan</li><li>Neutra - El nivel por omisión</li><li>Guerra! - Que comienzen las batallas!</li></ul>
    Nota que Aún que tu alianza poueda estar en paz con otra, el juego no te inhibe que seas atacado. Estos estados diplomáticos
    son un acuerdo de caballeros que puede ser quebrado sin grandes complicaciones.
  </div>
	
</asp:Content>