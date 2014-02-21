<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Chuva de Águias
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalha</h2><ul><li><a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li><li><a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a href='/pt/Battles/DiagonalTrap.aspx'>Armadilha Diagonal</a></li><li><a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a></li><li><a href='/pt/Battles/FiringSquad.aspx'>Pelotão de Fuzilamento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Chuva de Águias</h1>
<div class="content">
    A táctica <a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a> tem como objectivo eliminar nos primeiros turnos algumas <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> adversárias
    frágeis mas que podem ser uma ameaça no decorrer no jogo. Está táctica sacrifica pequenos grupos de <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>
    e visa atacar:
    <ul><li><a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a> - que no futuro podem destruir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> importantes, já para não mencionar a sempre 
  presente <a href='/pt/Battles/KamikazeMenace.aspx'>Ameaça Kamikaze</a></li><li><a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> - Com um grande bónus contra unidades de <a href='/pt/Battles/Heavy.aspx'>Grande Porte</a>, a <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> é uma ameaça muito relevante</li><li><a class='seeker' href='/pt/Unit/Seeker.aspx'>Batedor</a> - Com um grande bónus contra unidades de <a href='/pt/Battles/Medium.aspx'>Médio Porte</a>, o <a class='seeker' href='/pt/Unit/Seeker.aspx'>Batedor</a> também é uma ameaça relevante</li><li>Grupos com grandes quantidades de unidades de <a href='/pt/Battles/Light.aspx'>Pequeno Porte</a>, que possam ser usados para <a href='/pt/Battles/DispensableUnits.aspx'>Carne para Canhão</a></li></ul>
    Todas estas <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> podem fazer grandes estragos na nossa <a href='/pt/Universe/Fleet.aspx'>Armada</a>, mas têm como desvantagem ser muito
    frágeis. Daí a alocação de pequenos grupos de <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> para as destruir.
    <p />
    A preparação para a <a href='/pt/Battles/EagleStrike.aspx'>Chuva de Águias</a> começa no <a href='/pt/Battles/Deploy.aspx'>Posicionar</a> e consiste em colocar 2/3 grupos de <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> na
    linha da frente. Na primeira jogada esses 3 grupos são movidos uma quadrícula. Ver exemplo:
    
    <img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

    Como se pode ver os grupos de <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a> colocam em cheque tanto o grupo de <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a> como o grupo de <a class='kamikaze' href='/pt/Unit/Kamikaze.aspx'>Suicida</a>.
    E vai ser muito complicado ao adversário proteger ambos os grupos. E mesmo que o consiga, provavelmente não
    consegue fazer nenhuma movimentação de ataque.

    <p />

    A <a class='kahuna' href='/pt/Unit/Kahuna.aspx'>Kahuna</a> também pode ser considerada em vez da <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>, mas não será tão eficaz.

  </div>

</asp:Content>