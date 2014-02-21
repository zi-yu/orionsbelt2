<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Área de Visão
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Área de Visão</h1>
	<div class="content">
    A <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> é a área visivel à volta de algo que te pertence (uma <a href='/pt/Universe/Fleet.aspx'>Armada</a>, uma <a href='/pt/Universe/Planets.aspx'>Planeta</a>, etc). Nesta área podes ver tudo o que se move incluindo unidades 
    inimigas.
   <p />
   Existem 3 tipos de <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a>:
   <p /><ul><li>
 <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> uma quadrícula à volta de uma <a href='/pt/Universe/Fleet.aspx'>Armada</a>. Este <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> está presente em <a href='/pt/Universe/Fleet.aspx'>Armadas</a> que possuam apenas [LightUnits].<p /><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></li><li>
 <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> duas quadrículas à volta de uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> (ou <a href='/pt/Universe/Planets.aspx'>Planeta</a>):<p /><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></li><li>
 <a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a> três quadrículas à volta de um <a href='/pt/Universe/Beacon.aspx'>Sentinela</a>:<p /><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></li></ul><p /></div>
</asp:Content>