<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Descarregar Carga
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/pt/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/pt/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Acções no Universo</h2><ul><li><a href='/pt/Universe/Travel.aspx'>Viajar</a></li><li><a href='/pt/Universe/LineOfSight.aspx'>Área de Visão</a></li><li><a href='/pt/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/pt/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/pt/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/pt/Universe/Raids.aspx'>Pilhagem</a></li><li><a href='/pt/Universe/UnloadCargo.aspx'>Descarregar Carga</a></li><li><a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a></li></ul><h2>Elementos do Universo</h2><ul><li><a href='/pt/Universe/Planets.aspx'>Planetas</a></li><li><a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/pt/Universe/Fleet.aspx'>Armada</a></li><li><a href='/pt/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/pt/Universe/Beacon.aspx'>Sentinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Outros</h2><ul><li><a href='/pt/Universe/Alliance.aspx'>Aliança</a></li><li><a href='/pt/Universe/Relics.aspx'>Reliquias</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Descarregar Carga</h1>
	<div class="content">
  <p>Só podes descarrega a carga de uma armada se a armada estiver ao lado de um planeta teu (tal como podes ver na figura seguinte):</p>
  <img src="/Resources/Images/UnloadCargo1.png" alt="Fleet near a planet" title="Fleet near a planet" />
  <p>Para descarregar a carga existem duas maneiras possiveis:</p>
  <ul>
    <li>
      <p>Se a armada estiver como na imagem acima (próxima de um aplaneta teu), vais ao menu fleet desse planet e clicas no botão "Descarregar Carga". </p>
      <img src="/Resources/Images/pt/UnloadCargo2.png" style="width:450px;" alt="Unload Cargo" title="Unload Cargo" />
    </li>
    <li>
      <p>Em alternativa podes usar o menu de movimento da tua fleet, tal como na imagem seguinte:</p>
      <img src="/Resources/Images/pt/UnloadCargo3.png" alt="Unload Cargo" title="Unload Cargo" />
      <p>Nesta opção, a fleet vai-se mover para o teu planet e quando lá chegar irá descarregar automaticamente os recursos.</p>
    </li>
  </ul>
</div>
</asp:Content>