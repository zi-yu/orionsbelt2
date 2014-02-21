<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Überfalle 3 Planeten
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Überfalle 3 Planeten" runat="server" /></h1>
	
	<div class="description">
		Ein <a href='/de/Universe/Planets.aspx'>Planet</a> zu plündern funktioniert im Prinzip genauso wie ein Planet zu erobern.
  Wenn du denn linken Mausknopf benutzt (und eine <a href='/de/Universe/Fleet.aspx'>Flotte</a> selektiert hast, natürlich) und auf ein <a href='/de/Universe/Planets.aspx'>Planet</a> klickst der einen Besitzer hat erscheinen zwei Optionen:
  "Planet angreifen und erobern" und "Planet plündern".
  Die erste Option kennst du bereits, was ist mit der zweiten? Plündern?
  Plündern ist fast das Gleiche wie ein <a href='/de/Universe/Planets.aspx'>Planet</a> zu plündern, alle Regeln sind gleich , nur eine ändert sich: die Prämie.<p>
  Mit der ersten Option wirst du zum zum Besitzer des <a href='/de/Universe/Planets.aspx'>Planet</a>.
  Mit der zweiten Option stiehlst du die Ressourcen des <a href='/de/Universe/Planets.aspx'>Planet</a>. Wenn keine <a href='/de/Universe/Fleet.aspx'>Flotte</a> der Verteidigung 
  auf dem <a href='/de/Universe/Planets.aspx'>Planet</a> ist, ist die <a href='/de/Universe/Raids.aspx'>Plünderung</a> automatisch erfolgreich, andernfalls wird eine Schlacht 
  anfangen, wenn du gewinnst wird die <a href='/de/Universe/Raids.aspx'>Plünderung</a> erfolgreich sein.</p><p>
  Wenn du auf einem niedrigen Level plünderst mag es nicht wie ein nützliches Feature erscheinen weil du vielleicht alle Ressourcen hast die du brauchst, aber als du weiter im Spiel vorankommst wird Plündern immer nützlicher werden mit der Zeit und weil du immer mehr Ressourcen brauchen wirst und immer mehr Ressourcen da sind zum stehlen.
  Selbstverständlich kannst du keinen <a href='/de/Universe/Planets.aspx'>Planet</a> plündern ohne einen Besitzer.</p><p>
  Note: Plündern verschafft dir Zugang zu den seltenen Ressourcen, und die Wahrscheinlicht der 
  gestohlenen Ressourcen hängen von der <a href='/de/Race/Races.aspx'>Rasse</a> des <a href='/de/Universe/Planets.aspx'>Planet</a> Besitzers.</p>
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +5500</li><li><a href='/de/PirateQuests.aspx'>Pirat</a> : +30</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +600</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>