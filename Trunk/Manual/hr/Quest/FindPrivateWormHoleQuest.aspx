<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pronađi crvotočinu u svojoj privatnoj zoni i upotrijebi je da putuješ u hot zonu
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Pronađi crvotočinu u svojoj privatnoj zoni i upotrijebi je da putuješ u hot zonu" runat="server" /></h1>
	
	<div class="description">
		Jednonmm kada kolonizirate sve <a href='/hr/Universe/Planets.aspx'>Planeti</a> u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>, jedini način da pokorite još planeta će biti da napustite <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>. Postoji samo jedan put da se dođe do <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>. Trebate proći kroz [Wormhole] koji je u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>, ne postoji drugi način da napravite put od nekoliko milijuna svjetlosnih godina do <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>.
  <p />
  Vaš <a href='/hr/Quests.aspx'>Misija</a> je da se pronađe <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> sličan sljedećoj slici i putujete kroz nju u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>.
  <img class="block" src="/Resources/Images/en/Wormhole.png" alt="Worm Hole" title="Worm Hole" />
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a> : +15</li></ul>
	</div>
	
</asp:Content>