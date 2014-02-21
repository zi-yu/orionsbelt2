﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1><div class='description'><div class="content">
  <p>They come from the depths of the Universe. They are a group of pirates, mercenaries, thugs... call them whatever you like.</p>
  <p>They are destruction. They attack everything they put their eyes on. With their superior units, built with technology stolen through the centuries, they are a fierce enemy.</p>
  <p>Lead by the ruthless Metallic Beard and it's almost indestructible ship, they oppose a serious threat to all the races in the universe.</p>
</div></div><h2>Misiones de Mercs</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3MercFleets.aspx'>Attack end destroy 3 Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercWrecksToAcademyLevel1.aspx'>Bring Merc Wrecks to a level 1 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringPrimaryBoardToAcademyLevel1.aspx'>Bring Primary Boards to a level 1 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercSiliciumToAcademyLevel1.aspx'>Bring Silicium to a level 1 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercUniformsToAcademyLevel1.aspx'>Bring Merc Uniforms to a level 1 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercSpaceChartToAcademyLevel1.aspx'>Bring a Merc Space Chart to a level 1 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3SentryMercFleets.aspx'>Attack end destroy 3 Sentry Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercWrecksToAcademyLevel3.aspx'>Bring Sentry Merc Wrecks to a level 3 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryReactorToAcademyLevel3.aspx'>Bring Sentry Reactors to a level 3 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringBeriliumToAcademyLevel3.aspx'>Bring Berilium to a level 3 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercUniformsToAcademyLevel3.aspx'>Bring Sentry Merc Uniforms to a level 3 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringSentryMercSpaceChartToAcademyLevel3.aspx'>Bring Sentry Merc Space Chart to a level 3 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3RogueMercFleets.aspx'>Attack end destroy 3 Rogue Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercWrecksToAcademyLevel5.aspx'>Bring Rogue Merc Wrecks to a level 5 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringReaperPropulsionSystemToAcademyLevel5.aspx'>Bring Reapers Propulsion Systems to a level 5 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringReaperControlHelmetToAcademyLevel5.aspx'>Bring Reapers Control Helmets to a level 5 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercUniformsToAcademyLevel5.aspx'>Bring Rogue Merc Uniforms to a level 5 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringRogueMercSpaceChartToAcademyLevel5.aspx'>Bring Rogue Merc Space Chart to a level 5 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3TechMercFleets.aspx'>Attack end destroy 3 Tech Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringTeckMercWrecksToAcademyLevel7.aspx'>Bring Tech Mercs Wrecks to a level 7 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringScourgeIonCannonsToAcademyLevel7.aspx'>Bring Scourge Ion Cannons to a level 7 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringCarbonNanoTubesToAcademyLevel7.aspx'>Bring Carbon NanoTubes to a level 7 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringTechMercUniformsToAcademyLevel7.aspx'>Bring Tech Mercs Uniforms to a level 7 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringTechMercSpaceChartToAcademyLevel7.aspx'>Bring to a level 7 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/DestroySilverBeard.aspx'>Destroy Silver Beard</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3BlackMercFleets.aspx'>Attack and destroy 3 Black Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercWrecksToAcademyLevel9.aspx'>Bring Black Merc Wrecks to a level 9 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringDeutiriumEnergyCapsuleToAcademyLevel9.aspx'>Bring a Deuterium Energy Capsule to a level 9 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercUniformsToAcademyLevel9.aspx'>Bring a Black Merc Uniforms to a level 9 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringBlackMercSpaceChartToAcademyLevel9.aspx'>Bring Black Merc space chart to a level 9 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3DarkMercFleets.aspx'>Attack end destroy 3 Dark Merc Fleets</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercWrecksToAcademyLevel10.aspx'>Bring Dark Merc Wrecks to a level 10 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercUniformsToAcademyLevel10.aspx'>Bring Dark Merc Uniforms to a level 10 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/BringDarkMercSpaceChartToAcademyLevel10.aspx'>Bring a Dark Merc Space Chart to a level 10 Academy</a></td></tr><tr><td colspan='6'><a href='Quest/DestroyMetallicBeard.aspx'>Destroy Metallic Beard</a></td></tr></table>
	
</asp:Content>