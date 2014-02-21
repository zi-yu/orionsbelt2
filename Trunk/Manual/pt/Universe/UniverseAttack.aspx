<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Ataque</h1>
	<div class="content">
    De modo a atacar alguma coisa no <a href='/pt/Universe/Default.aspx'>Universo</a>, tens de ter uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> com unidades.
    <p />
    Para atacar outro jogador simplesmente selecciona a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> e clica sobre a <a href='/pt/Universe/Fleet.aspx'>Armada</a> ou <a href='/pt/Universe/Planets.aspx'>Planeta</a> do jogador inimigo.
    <p />
    Se clicares sobre a <a href='/pt/Universe/Fleet.aspx'>Armada</a>, a seguinte opção aparece:
    <p /><img src="/Resources/Images/pt/AttackFleet.png" alt="Atacar Aramada" /><p />
    Depois de clicares na opção 'Ataque', a <a href='/pt/Universe/Fleet.aspx'>Armada</a> vai iniciar o movimento e atacar a <a href='/pt/Universe/Fleet.aspx'>Armada</a> inimiga.
    <p />
    Se a <a href='/pt/Universe/Fleet.aspx'>Armada</a> alvo se estiver a mover, uma opção diferente aparece:
    <p /><img src="/Resources/Images/pt/AttackPursuit.png" alt="Perseguir a Armada" /><p />
    Isto significa que a <a href='/pt/Universe/Fleet.aspx'>Armada</a> vai perseguir a <a href='/pt/Universe/Fleet.aspx'>Armada</a> inimiga até que a possa atacar.
    <p />
    Quando uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> ataca um <a href='/pt/Universe/Planets.aspx'>Planeta</a>, as opções seguintes aparecem:
    <img src="/Resources/Images/pt/Conquer2.png" alt="Attack a Planet" /><p />
    Estas opções significam:
    <ul><li>Atacar <a href='/pt/Universe/Planets.aspx'>Planeta</a> e <a href='/pt/Universe/Conquer.aspx'>Conquistar</a>: Se não existe defesa tu <a href='/pt/Universe/Conquer.aspx'>Conquistar</a> o <a href='/pt/Universe/Planets.aspx'>Planeta</a> de imediato. Caso contrário uma [Battle] começa</li><li>Pilhar <a href='/pt/Universe/Planets.aspx'>Planeta</a>: Se não existirem unidades de defesa, roubas os recursos ao dono do <a href='/pt/Universe/Planets.aspx'>Planeta</a> sem [Battle]. Caso contrário uma [Battle] é começada e só roubas os recursos caso a venças. Neste caso, o <a href='/pt/Universe/Planets.aspx'>Planeta</a> não é conquistado.</li></ul></div>
</asp:Content>