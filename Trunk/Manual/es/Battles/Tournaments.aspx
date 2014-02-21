<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Torneos
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batallas</h2><ul><li><a href='/es/Battles/Tournaments.aspx'>Torneos</a></li><li><a href='/es/Battles/Ladder.aspx'>Escala</a></li><li><a href='/es/Battles/Friendly.aspx'>Amistoso</a></li><li><a href='/es/Battles/ELO.aspx'>Clasificación ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Torneos</h1>
	<div class="content">
 Los <a href='/es/Battles/Tournaments.aspx'>Torneos</a> son el campo de batalla supremo para los jugadores de <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. Aquí puedes batallaer con los mejores jugadores y tendrás que probar que tan bueno eres para ganar. Puedes participar   en torneos de <a href='/es/Battles/Regicide.aspx'>Regicidio</a> y <a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a>.
 Más alla del prestigío, ganar batallas de <a href='/es/Battles/Tournaments.aspx'>Torneos</a> también  te dá <a href='/es/Commerce/Orions.aspx'>Orions</a>.

    <h2>Estructura de los Torneos</h2>
 Hay varias fases en un torneo. Primero el torneo comienza con la fase de inscripciones. Si las restricciones del torneo lo permiten, te puedes inscribir y serás colocado en uno de los diez potes.   Cuando el torneo avanza, se inicia la fase de grupos.
    <p />
 En la fase de grupos los 3 primeros jugadores pasan a la proxima fase. También puede suceder el repechaje de algunos jugadores si fuera necesario.
    <p />
 Después de la fase de grupos vienen las eliminatorias. Si pierdes, sales de la competencia!
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>