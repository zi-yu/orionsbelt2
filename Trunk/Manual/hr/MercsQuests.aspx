﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1><div class='description'><div class="content">
  <p>Došli su iz dubina Svemira. Oni su grupa pirata, plaćenika, razbijača...zovite ih kako god da želite. </p>
  <p>Oni su destrukcija. Napadaju sve na što im padne pogled. Sa njihovom superiornom tehnologijom koju st ukrali tokom stoljeća, oni su žestok neprijatelj. </p>
  <p>Vođeni od okrutnoga Metalne Brade i njegovoga skoro neuništivoga broda, predstavljaju ozbiljnu prijetnju svim rasam u svemiru.</p>
</div></div><h2>Mercs Misije</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3MercFleets.aspx'>Mercs flote su uočene u zoni nivoa 1. Nađi ih i uništi 3 flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercWrecksToAcademyLevel1.aspx'>Imam izvještaj koji kaže da  Mercs flote imaju određene komponente koje me zanimaju. Donesi mi te komponente na bilo koju Akademiju nivoa 1.</a></td></tr><tr><td colspan='6'><a href='Quest/BringPrimaryBoardToAcademyLevel1.aspx'>Primarne Ploče sadrže detaljne informacije o operacijama Mercsa. Trebaš mi donijeti 2 Primarne Ploče na bilo koju Akademiju levela 1.</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercSiliciumToAcademyLevel1.aspx'>Flota Mercsa uobičajeno prevoze element koji se lako uništi, Silicium, Donesi 2 uzorka ovoga elementa na bilo koju Akademiju nivoa 1.</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercUniformsToAcademyLevel1.aspx'>Trebam  se infiltrirati u Mercs flotu i za to trebam određene predmete. 10 Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 1.</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercSpaceChartToAcademyLevel1.aspx'>Mercs imaju jednu od najboljih karata svemira. Trebamm da mi nabaviš jednu od ovih karata od Mercs Flote. Kada nabaviš jednu, donensi je na Akademiju nivoa 1.</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3SentryMercFleets.aspx'>Sentry Mercs su uočene na zoni nivoa 3. Nađi ih i uništi 3 flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercWrecksToAcademyLevel3.aspx'>Sentry Merc posjeduju određene komponente koje su korisne. Donesi te komponete na bilo koju Akademiju nivoa 3.</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryReactorToAcademyLevel3.aspx'>Sentry Mercs flote sardrže jako brzu jedinicu, Stražara. Trebam 3 njegova Reaktora da na njima napravim "reverse engineer". Donesi mi ih na bilo koju Akademiju nivoa 3.</a></td></tr><tr><td colspan='6'><a href='Quest/BringBeriliumToAcademyLevel3.aspx'>Sentry Merc flote rabe jako rijedak element da napajaju svoje flote, Berilij. Donesi 3 uzorka ovoga elementa na bilo koju Akademiju nivoa 3.</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercUniformsToAcademyLevel3.aspx'>Trebam infiltrirati Sentry Mercs flotu i za to trebam određene predmete. 10 Sentry Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 3.</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercSpaceChartToAcademyLevel3.aspx'>Mercs imaju jednu od najboljih karata svemira. Trebam te da mi nabaviš jednu od ovih karata svemira od Sentry Mercs Flote. Kada je nabaviš, donesi je na bilo koju Akademinu nivoa 3.</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3RogueMercFleets.aspx'>Rogue Mercs flote su uočene u zoni nivoa 5. Pronađi i uništi tri flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercWrecksToAcademyLevel5.aspx'>Rogue Merc flote sadrže određene komponente koje trebam, Donesi te komponente u bilo koju Akademiju nivoa 5.</a></td></tr><tr><td colspan='6'><a href='Quest/BringReaperPropulsionSystemToAcademyLevel5.aspx'>Mora da si primjetio da su Žeteoci ekstremno mobilini. Trebam proučiti njihov pogonski sustav. Donesi mi 3 potpuno funkcionalna pogonska sustava na bilo koju Akademiju nivoa 5.</a></td></tr><tr><td colspan='6'><a href='Quest/BringReaperControlHelmetToAcademyLevel5.aspx'>Otkrio sam da Žeteoci rabe specijalnu Kacigu da se kontroliraju. Potrebna mi je ta kaciga. Donesi dvije funkcionalne kacige u bilo koju Akademiju nivoa 5.</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercUniformsToAcademyLevel5.aspx'>Trebam infiltrirati Rogue Mercs flotu i za to trebam određene predmete. 10 Rogue Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 5.</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercSpaceChartToAcademyLevel5.aspx'>Mercs imaju jednu od najboljih karata svemira. Trebam da mi nabaviš jednu od tih svemirskih karata od Rogue Mercs Flote. Kada je nabaviš, donesi je na bilo  koju akademiju nivoa 5.</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3TechMercFleets.aspx'>Tech Mercs flote su uočene u zoni nivoa 7. Pronađi ih i uništi 3 flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringTeckMercWrecksToAcademyLevel7.aspx'>Teck Merc posjeduju tehnološki napredne jedinice. Trebam neke komponente sa tih jedinica. Donesi te komponente na bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/BringScourgeIonCannonsToAcademyLevel7.aspx'>Bič je najmoćnija jedinica u Tech Mercs floti i mora biti zaustavljena. Trebam njihove Ionske Topove. Donesi 3 Ionska Topa na bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/BringCarbonNanoTubesToAcademyLevel7.aspx'>Tech Mercs rabe novi materijal da pojačaju trup njihovih jedinica. Donesi 3 uzorka Ugjikovih NanoCijevi u bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/BringTechMercUniformsToAcademyLevel7.aspx'>Trebam se infiltrirati u Tech Mercs flotu i za to trebam određene uniforme. 8 Tech Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/BringTechMercSpaceChartToAcademyLevel7.aspx'>Mercs imaju jednu od najboljih karata svemira. Trebam da mi nabaviš jednu od tih karata svemira od
  Tech Mercs flote. Kada je nabaviš dostavi mi je na bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/DestroySilverBeard.aspx'>Locirali smo nemilosrdnu desnu ruku Metalne Brade. Zove se Srebrena Brada. Izvještaji ga lociraju u zonu nivo 7 ali katkada odluta do zona nivo 9 i 10. Nađi ga i donesi njegovu glavu na bilo koju Akademiju nivoa 7.</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3BlackMercFleets.aspx'>Black Mercs su uočene u zoni nivoa 9. Pronađi ih i uništi tri flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercWrecksToAcademyLevel9.aspx'>Trebam neke komponente iz glavnih jedinca Black Mercs-a. Donesi mi te komponente na bilo koju akademiju nivoa 9.</a></td></tr><tr><td colspan='6'><a href='Quest/BringDeutiriumEnergyCapsuleToAcademyLevel9.aspx'>Black Mercs rabe specijalne Deuterijske Energetske Kapsule da napajaju njihove jedinice. Donesi mi 3  Deuterijske Energetske Kapsule na bilo koju Akademiju nivoa 9.</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercUniformsToAcademyLevel9.aspx'>Trebam se infiltrirati u Black Mercs flotu i za to trebam određene predmete, 6 Black Mercs uniformi da budem točan. Donesi mi ih u bilo koju Akademiju nivoa 9.</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercSpaceChartToAcademyLevel9.aspx'>Mercs imaju jednu od najboljih karata svemira. Želim da mi nabaviš jednu od tih svemirskih karata od  Black Mercs Flote. Kada je nabaviš donesi je na bilo koju Akademiju nivoa 9.</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3DarkMercFleets.aspx'>Dark Mercs flote su uočene u zoni nivoa 10. Pronađi ih i uništi 3 flote.</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercWrecksToAcademyLevel10.aspx'>Trebam 4 jako specijalne komponente iz glavnih jedinica Dark Mercs. Donesi te komponente u bilo koju Akademiju nivoa 10.</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercUniformsToAcademyLevel10.aspx'>Trebam se infliltrirati u Dark Mercs flotu i za to trebam određene predmete. 6 Dark Mercs uniformi da budem točan. Donesi mi ih u bilo koju Akademiju nivoa 10.</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercSpaceChartToAcademyLevel10.aspx'>Dark Mercs imaju  najbolju mapu čitavoga svemira. Trebam nabaviti jednu od tih mapa. Kada nabaiš jednu, donesi je na Akademiju nivoa 10.</a></td></tr><tr><td colspan='6'><a href='Quest/DestroyMetallicBeard.aspx'>Ovo je najvažnija misija koju sam ti dao do danas. Moraš pretražiti nivoe 9 i 10 i završiti prijetnju Metalne Brade. Donesi njegovu glavu na bilo koju Akademiju nivoa 10.</a></td></tr></table>
	
</asp:Content>