<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Aliança
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Alianças</h1>
<div class="content">
    Uma <a href='/pt/Universe/Alliance.aspx'>Aliança</a> é um grupo de jogadores que partilham um objectivo comum: protecção, riqueza ou domínio. Precisas de <a href='/pt/Commerce/Orions.aspx'>Orions</a> para criar uma aliança.
    Assim que estiver criada, podes convidar jogadores e aceitar jogadores, tal como mudar o seu escalão. Os escalões disponíveis são:
    <ul><li>Almirante - o líder</li><li>Vice Almirante - o vice líder</li><li>Sargento - an alliance member that is proving to be valuable</li><li>Membro - escalão mais baixo</li></ul>
  Cada <a href='/pt/Universe/Alliance.aspx'>Aliança</a> deve tentar conquistar o máximo de <a href='/pt/Universe/Relics.aspx'>Reliquias</a> possível. As <a href='/pt/Universe/Relics.aspx'>Reliquias</a> providenciam às alianças recursos raros por dia.
  <p /><h2>Diplomacia de Aliança</h2>
    As alianças podem entrar em guerra, mas também podem coexistir pacificamente. Há vários gráus diplomáticos que um Almirante pode
    definir para cada uma das outras alianças.
    <ul><li>Confederação - As tuas alianças são aliadas e com objectivos comuns</li><li>Pacto de Não Agressão - As alianças acordam e não se atacar</li><li>Neutra - O nível por omissão</li><li>Guerra! - Que comecem as batalhas!</li></ul>
    Nota que embora a tua aliança possa estar em paz com outra, o jogo não a inibe de te atacar. Estes estados diplomáticos
    são um acordo de cavalheiros que pode ser quebrado sem grandes complicações.
  </div>
	
</asp:Content>