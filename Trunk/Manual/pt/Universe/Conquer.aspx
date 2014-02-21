<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Conquistar
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Conquistar</h1>
	
	<div class="content">
    <a href='/pt/Universe/Conquer.aspx'>Conquistar</a> é o acto de conquistar um <a href='/pt/Universe/Planets.aspx'>Planeta</a> que já possui um dono. Para <a href='/pt/Universe/Conquer.aspx'>Conquistar</a> um <a href='/pt/Universe/Planets.aspx'>Planeta</a> tens de mover uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> para o <a href='/pt/Universe/Planets.aspx'>Planeta</a> alvo.
    <p />
    Quando tentas colonizar um <a href='/pt/Universe/Planets.aspx'>Planeta</a> duas coisas podem acontecer:
    <ul><li>O <a href='/pt/Universe/Planets.aspx'>Planeta</a> tem dono mas não tem defesas. Neste caso o <a href='/pt/Universe/Planets.aspx'>Planeta</a> é automaticamente conquistado.</li><li>O <a href='/pt/Universe/Planets.aspx'>Planeta</a> tem dono e tem defesas. Neste caso a batalha vai começar com o dono do <a href='/pt/Universe/Planets.aspx'>Planeta</a>.</li></ul><p />
    Em ambos os casos o menu abaixo vai aparecer:
    <p /><img src="/Resources/Images/pt/Conquer2.png" alt="Conquistar um planeta" /><p />
    Nota que o menu acima tem também a opção "Pilhar Planeta". Podes encontrar mais informação sobre esta opção na página de <a href='/pt/Universe/Raids.aspx'>Pilhagem</a>.
   </div>
	
</asp:Content>