<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attackiere und zerstöre 3 Planeten
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Attackiere und zerstöre 3 Planeten" runat="server" /></h1>
	
	<div class="description">
		In die Schlacht mit einer anderen <a href='/de/Universe/Fleet.aspx'>Flotte</a> gehen ist genauso einfach wie ein <a href='/de/Universe/Planets.aspx'>Planet</a> zu erobern.
  Du musst nur deine <a href='/de/Universe/Fleet.aspx'>Flotte</a> selektiert haben (die die du benutzen willst um den anderen Spieler 
  anzugreifen) und klicke auf <a href='/de/Universe/Fleet.aspx'>Flotte</a> wenn kämpfen möchtest. <p>
  Ein kleines pop-up Menü erscheint mit der folgenden Option "Flotte verfolgen und angreifen", Klicke 
  es an und deine <a href='/de/Universe/Fleet.aspx'>Flotte</a> wird automatisch die andere <a href='/de/Universe/Fleet.aspx'>Flotte</a> angreifen und verfolgen.
  Sobald deine <a href='/de/Universe/Fleet.aspx'>Flotte</a> die andere <a href='/de/Universe/Fleet.aspx'>Flotte</a> erreicht fängt der Kampf an und wird zugänglich sein im Kampf-
  Menü.</p><p>
  Deine <a href='/de/Universe/Fleet.aspx'>Flotte</a> ist natürlich für die Dauer der Schlacht bewegungsunfähig.
  Sobald die Schlacht vorbei (und wenn du gewinnst natürlich) erlangst du wieder die normale Kontrolle 
  über deine <a href='/de/Universe/Fleet.aspx'>Flotte</a>,
  wenn du deine <a href='/de/Universe/Fleet.aspx'>Flotte</a> verlierst wird alles was in der Flotte war zerstört (Ressourcen inklusive).
  Also sei vorsichtig bevor du eine andere <a href='/de/Universe/Fleet.aspx'>Flotte</a> angreifst denn du könntest Ressourcen die du nicht 
  riskieren willst, verlieren.</p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +3500</li><li><a href='/de/PirateQuests.aspx'>Pirat</a> : +20</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +1500</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>