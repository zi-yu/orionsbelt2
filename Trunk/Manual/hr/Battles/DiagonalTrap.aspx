<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Dijagonalna Zamka
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Taktike Bitke</h2><ul><li><a href='/hr/Battles/DispensableUnits.aspx'>Hrana za Topove</a></li><li><a href='/hr/Battles/KamikazeMenace.aspx'>Prijetnja Kamikaza</a></li><li><a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a></li><li><a href='/hr/Battles/EagleStrike.aspx'>Orlov Udar</a></li><li><a href='/hr/Battles/FiringSquad.aspx'>Napadački Odred</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Dijagonalna Zamka</h1>
<div class="content">
<a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a> je taktika koja cilja da iskotristi limite pokreta <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a> jedinca, na primjer: <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a>, <a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a>, <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> or <a class='interceptor' href='/hr/Unit/Interceptor.aspx'>Presretač</a>. 
<p />
<a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> sa <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a> mogu zapeti bez bilo kakvog načina da pobjegnu ako imaju naprijateljske <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> na svim mogućim kvadratima na koje se mogu pomaknuti. Jedinica može napadati samo naprijed, pa zbog toga postaje kompletno ranjiva. 
<p />
Sljedeći primjer pokazuje <a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a> u četiri kuta:

<img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Diagonal Trap Example" />


A ovaj primjer pokazuje <a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a> na rubu <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>:

<img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Diagonal Trap Example" />

Trebali biste biti jako oprezni kada mičete <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> sa <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a> na rub <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. Ne samo da izgube 50% mobilnosti, već postaju i laka meta za <a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a>.

<h2>Kako se boriti protiv Dijagonalne Zamke</h2>
Najbolji način da se bori protiv nje je da se u potpunosti izbjegne protivnikova zamka. Međutim, ako protivnik uspije primjeniti zamku, jedini način da se pobjegne iz nje je korištenje drugih <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> da unište one koje formiraju zamku.
</div>

</asp:Content>