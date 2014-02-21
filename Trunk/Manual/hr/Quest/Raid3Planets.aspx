<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Opljačkaj 3 planeta
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Opljačkaj 3 planeta" runat="server" /></h1>
	
	<div class="description">
		Pljačkanje <a href='/hr/Universe/Planets.aspx'>Planet</a> je poprilično isto pokoravanju planeta.
  Kada kliknete lijevim gumbom miša ( i imate <a href='/hr/Universe/Fleet.aspx'>Flota</a> odabranu, naravno) na <a href='/hr/Universe/Planets.aspx'>Planet</a> sa vlasnikom dvije mogućnosti se pojave:
  "Napadni i pokori Planet" and "Opljačkaj Planet".
  Već znate što je prvo, ali što s drugim? Pljačkanje?
  Pljačkanje je skoro isto kao i pokoravanje <a href='/hr/Universe/Planets.aspx'>Planet</a>, sva se pravila primjenjuju, samo se jedna stvar mijenja: nagrada.<p />
  S prvom mogućnosti dobiti ćete vlasništvo nad <a href='/hr/Universe/Planets.aspx'>Planet</a>.
  U drugoj mogućnosti vi kradete resurse sa <a href='/hr/Universe/Planets.aspx'>Planet</a>. Ako nema obranbene <a href='/hr/Universe/Fleet.aspx'>Flota</a> na <a href='/hr/Universe/Planets.aspx'>Planet</a>  <a href='/hr/Universe/Raids.aspx'>Pljačka</a> je automatski uspješan, u protivnom počinje bitka, ako dobijete <a href='/hr/Universe/Raids.aspx'>Pljačka</a> će biti uspješan.
  <p />
  Dok ste na niskom nivou Pljačkanje vam možda neće izgledati kao korisna značajka jer ćete vjerojatno imati sve reurse koje trebate, ali kako napredujete kroz igru Pljačkanje će biti sve korisnije i korisnije i vi ćete imati veću potrebu za resursima i postoji više resursa za ukrasti. Naravno ne možete oplječkati planet koji nema vlasnika.<p />
  Uzmite u obzir: Pljačkanje će vam dati pristup Rijetkim Reusrsima, vjerojatnost resursa koje ćete ukrasti ovisi o <a href='/hr/Race/Races.aspx'>Rasa</a> vlasnika <a href='/hr/Universe/Planets.aspx'>Planet</a>.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +5500</li><li><a href='/hr/PirateQuests.aspx'>Pirat</a> : +30</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +600</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>