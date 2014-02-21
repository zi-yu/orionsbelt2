<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Misiones y Profesiones
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Misiones y Actividades</h1>
<div class="description">
    En el Inicio, hay <a href='/es/Quests.aspx'>Misiones</a> Disponibles que te guian mientras aprendes los conceptos básicos
    del juego. Posteriormente a esta parte inicial, es posible seguir <a href='/es/Quests.aspx'>Misiones</a> específicas de determinadas <a href='/es/Quests.aspx#Professions'>Profesiones</a>.
    Las <a href='/es/Quests.aspx'>Misiones</a> son básicamente una forma de entrenerte y ocuparte mientras juegas. No es obligatório de hacer <a href='/es/Quests.aspx'>Misiones</a>
    para tener Éxito, pero seguir las <a href='/es/Quests.aspx'>Misiones</a> te ayuda a evolucionar más rapidamente.
    <p />
    Una <a href='/es/Quests.aspx'>Misión</a> es definida por un objetivo y una recompensa. Se consiguieras alcanzar el objetivo de la <a href='/es/Quests.aspx'>Misión</a>,
    entonces ganas la recompensa asociada, así de simple.
    <p />
    El juego ofrece una variedad interesante de <a href='/es/Quests.aspx'>Misiones</a> para jugar: puedes atacar otros jugadores, hacer
    <a href='/es/Universe/Raids.aspx'>Saqueo</a> a ses planetas, aceptar <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> o hasta <a href='/es/BountyHunterQuests.aspx'>Bondades</a>.
  </div>
<a name="Types" id="Types"></a>
<h3>Tipos de Misiones</h3>
<div class="description">
    Hay dos tipos diferentes de misiones:
    <ul><li><b>Misiones de Meta</b> - En estas misiones sólo necesitas alcanzar una determinada meta.
    Por ejemplo: en la missão <a href='/es/Quest/ColonizeOnePlanetQuest.aspx'>Colonizar otro planeta en tu zona privada</a>, solo te basta <a href='/es/Universe/Colonize.aspx'>Colonizar</a> un planeta y entregar la misión.
  </li><li><b>Misiones de Tarea</b> - Estas misiones tienen un intervalo de tiempo (que puede tener limite ou não). Las tienes que
    aceptar y sólo despues tus acciones cuentan para completar la misión. Ejemplo:
    En la missão <a href='/es/Quest/FinishABattleQuest.aspx'>Hacer una batalha en la zona pública</a>, tiens que aceptar la misión primero, despuis hacer una batalha y sólo después
    entregar la misión.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Actividades</h2>
<div class="description">
    Una <a href='/es/Quests.aspx#Professions'>Profesión</a> es un camino que puedes seguir para definirte mejor como jugador. Puedes hacer
    lo que quieras en el juego, pero también puedes seguir un camino específico y quedar perito en una
    determinada profesión. De esta forma vas a tener aceeso a las <a href='/es/Quests.aspx'>Misiones</a> mas avanzadas y con recompesas mejores.
    <p />
    Existen tres profesiones principales, y debes escojer una de ellas. Puedes hacer <a href='/es/Quests.aspx'>Misiones</a> para todas las
    <a href='/es/Quests.aspx#Professions'>Profesiones</a> en cualquier momento, pero de esa forma no vas a conseguir evolucionar solamente en una profesión
    y sacar el mejor partido de eso. Por lo tanto, deves escojer una de las siguientes profesiones principales:
    <ul><li><a href='/es/MerchantQuests.aspx'>Comerciante</a> - efectua <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> y concentrate en acciones económicas</li><li><a href='/es/PirateQuests.aspx'>Pirata</a> - ataca, efectua <a href='/es/Universe/Raids.aspx'>Saqueos</a>, tornate un villano! No tienes que construir nada, roba lo que necesitas!</li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a> - estos son los buenos da la história, ellos cazan cualquier <a href='/es/PirateQuests.aspx'>Pirata</a> para transformar el <a href='/es/Universe/Default.aspx'>Universo</a> un lugar mas seguro</li></ul>
    También puedes seguir otras profesiones secundárias:
    <ul><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a> - enfocate en colonizar, conquistar y administrar planetas</li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a> - busca <a href='/es/Universe/Arenas.aspx'>Arenas</a> en el universo y tranformate en un gladiador supremo</li></ul></div>
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>