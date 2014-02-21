<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Misije i Profesije
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Quests and Professions</h1>
<div class="description">
    Na početku, imate neke <a href='/hr/Quests.aspx'>Misije</a> koje će vas voditi kroz igru i naučiti vas osnovne koncepte. Nakon toga, možete slijediti <a href='/hr/Quests.aspx'>Misije</a> za danu <a href='/hr/Quests.aspx#Professions'>Profesija</a>. <a href='/hr/Quests.aspx'>Misije</a> su u osnovi način da se zabavite i da budete zaokupljeni dok igrate. Ne morate raditi niti jedan <a href='/hr/Quests.aspx'>Misije</a> da uspijete u <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a>, ali njihovo izvršavanje će vam pomoći da se unaprijedite brže.
    <p />
    Misija je definirana ciljem i nagradom. Ako uspijete izvršiti dane ciljeve dobiti ćete definiranu nagradu, tako je jednostvano.
    <p />
    Igra vam nudi široki izbor misija za igrati: možete napadati druge igrače, <a href='/hr/Universe/Raids.aspx'>Pljačka</a> njihove planete, ili čak prihvatiti <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> ili <a href='/hr/BountyHunterQuests.aspx'>Ucjene</a>.
  </div>
<a name="Types" id="Types"></a>
<h3>Quest Types</h3>
<div class="description">
    Postoje dva različita tipa misije:
    <ul><li><b>Misije Kontrolne Točke</b> - U ovim misijama trebate samo postići cilj da biste mogli dostaviti misiju. Ne trebate ih prihvatiti. Naprimjer: u <a href='/hr/Quest/ColonizeOnePlanetQuest.aspx'>Koloniziraj jedan dodatni planet u svojoj privatnoj zoni</a>, samo trebate <a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a> planet i dostaviti misiju.
  </li><li><b>Misije:Zadatci</b> - ove misije imaju vremenski interval (koji može biti ograničen ili ne). Morate ih prihvatiti i tek nakon toga vaše akcije će se uračunati u završavanje misije. Naprimjer: u <a href='/hr/Quest/FinishABattleQuest.aspx'>Završi bitku u hot zoni</a> trebete prihvaiti misiju, voditi bitku, i tek nakon toga dostaviti misiju.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Professions</h2>
<div class="description">
    Profesija je put koji možete sliljediti da definirate vašega lika u igri. Možete činiti što god da želite, ali također možete slijediti neke određene akcije i postativješt u danoj profesiji. Ovo će vam dopustiti bolje <a href='/hr/Quests.aspx'>Misije</a>  sa boljim nagradama.
    <p />
    Postoje tri glavne profesije, i vi biste trebali odabrati samo jednu od ovih. Možete izvodit akcije za sve <a href='/hr/Quests.aspx#Professions'>Profesije</a> u bilo kojemu trenutku, ali dok to radite nećete se  moći unaprijediti na specifičnoj <a href='/hr/Quests.aspx#Professions'>Profesija</a> i uzeti najveću prednost koju ona nudi. Zato biste trebali odabrati jedno od sljedećeg:
    <ul><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a> - izvršava <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> i fokusira se na ekonomiju</li><li><a href='/hr/PirateQuests.aspx'>Pirat</a> - napadaj, <a href='/hr/Universe/Raids.aspx'>Pljačka</a>, budi loši tip! Ne morate graditi ništa, samo to ukradite!</li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a> - ovo je dobar tip, loviti će svakog <a href='/hr/PirateQuests.aspx'>Pirat</a> da napravi od  <a href='/hr/Universe/Default.aspx'>Svemir</a> sigurnije mjesto</li></ul>
    Također možete slijediti druge sekundarne <a href='/hr/Quests.aspx#Professions'>Profesije</a>:
    <ul><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a> - fokusira se na koloniziranje ili pokoravanje planeta i upravaljenje njima</li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a> - pretražuje svemir za  <a href='/hr/Universe/Arenas.aspx'>Arene</a> i postaje  ultimativni gladijator</li></ul></div>
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>