<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Reliquias
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Reliquias</h1>
<div class="content">
    Uma <a href='/pt/Universe/Relics.aspx'>Relíquia</a> é um compomente especial no <a href='/pt/Universe/Default.aspx'>Universo</a>, que serve especialmente para guerras de <a href='/pt/Universe/Alliance.aspx'>Aliança</a>. 
    Quando uma <a href='/pt/Universe/Alliance.aspx'>Aliança</a> tem uma ou mais <a href='/pt/Universe/Relics.aspx'>Reliquias</a>, todos os membros da aliança irão receber um tipo de recursos raros por dia. Quando recebem
    depende de quantas reliquias a aliança controla e do posto de cada membro.
    <p />
    O total que as reliquias fornecem, é dado pela seguinte informação:
    <ul><li>Cada reliquia contribuirá com K multiplicado pelo seu <a href='/pt/Universe/HotZone.aspx#levels'>Nível de Zona</a>; se a reliquia estiver em batalha, então a sua produção decresce até oito vezes</li><li>A soma da contribuição de todas as reliquias é então multiplicada pela percentagem total de reliquias que a aliança tem</li></ul>
    Isto significa que quanto mais <a href='/pt/Universe/Relics.aspx'>Reliquias</a>, mais recursos serão obtidos. K é uma constante interna, que pode ser alvo de alterações.
    <p />
    Cada <a href='/pt/Universe/Relics.aspx'>Relíquia</a> tem o seu próprio proector: um membro da aliança que a conquista e que é responsável por a defender.
  </div>
	
</asp:Content>