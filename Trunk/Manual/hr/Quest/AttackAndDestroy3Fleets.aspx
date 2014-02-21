<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napadni i uništi tri flote
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Napadni i uništi tri flote" runat="server" /></h1>
	
	<div class="description">
		Započinjanje bitke sa drugom <a href='/hr/Universe/Fleet.aspx'>Flota</a> je laki način pokoravanja <a href='/hr/Universe/Planets.aspx'>Planet</a>.
  Samo trebate imati vašu <a href='/hr/Universe/Fleet.aspx'>Flota</a> odabranu (onu s kojom želite napasti drugog igrača) i klikniti na <a href='/hr/Universe/Fleet.aspx'>Flota</a> s kojom želite započeti bitku. <p />
  Mali pop-up meni će se pojaviti sa opcijom "Slijedi i napadni Flotu", kliknite na  njega i vaša <a href='/hr/Universe/Fleet.aspx'>Flota</a> će automatski slijediti i napasti tu <a href='/hr/Universe/Fleet.aspx'>Flota</a>.
  Jednom kada vaša <a href='/hr/Universe/Fleet.aspx'>Flota</a> dosegne drugu <a href='/hr/Universe/Fleet.aspx'>Flota</a> bitka će početi i izbornik bitke će bit dostupan.<p />
  Vaša <a href='/hr/Universe/Fleet.aspx'>Flota</a> će očito biti nepokretna tokom bitke.
  Jednom kada bitka završi ( i ako vi pobijedite naravno) vi ćete opet moći kontrolirati vašu <a href='/hr/Universe/Fleet.aspx'>Flota</a> normalno, ako izgubite <a href='/hr/Universe/Fleet.aspx'>Flota</a> i sve što je bilo sa njom će biti uništeno (uključujući resurse).
  Zato budite oprezni prije nego napadnete drugu <a href='/hr/Universe/Fleet.aspx'>Flota</a> ako imate resurse koje ne želite izgubiti.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +3500</li><li><a href='/hr/PirateQuests.aspx'>Pirat</a> : +20</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +1500</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>