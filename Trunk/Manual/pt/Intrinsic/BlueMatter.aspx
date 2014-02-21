﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Matéria Azul
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Intrínsecos</h2><ul><li><a href='/pt/Intrinsic/Alcohol.aspx' class='alcohol'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceAlcohol' title='Álcool' alt='Álcool' resourceName='Alcohol'/> Álcool</a></li><li><a href='/pt/Intrinsic/Animals.aspx' class='animals'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceAnimals' title='Animais' alt='Animais' resourceName='Animals'/> Animais</a></li><li><a href='/pt/Intrinsic/Argon.aspx' class='argon'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceArgon' title='Argon' alt='Argon' resourceName='Argon'/> Argon</a></li><li><a href='/pt/Intrinsic/CommunicationsArray.aspx' class='communicationsarray'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCommunicationsArray' title='Array de Comunicações' alt='Array de Comunicações' resourceName='CommunicationsArray'/> Array de Comunicações</a></li><li><a href='/pt/Intrinsic/Astatine.aspx' class='astatine'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceAstatine' title='Astatine' alt='Astatine' resourceName='Astatine'/> Astatine</a></li><li><a href='/pt/Intrinsic/Berilium.aspx' class='berilium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceBerilium' title='Berílio' alt='Berílio' resourceName='Berilium'/> Berílio</a></li><li><a href='/pt/Intrinsic/IonCannon.aspx' class='ioncannon'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceIonCannon' title='Canhão de Iões' alt='Canhão de Iões' resourceName='IonCannon'/> Canhão de Iões</a></li><li><a href='/pt/Intrinsic/PositronCannon.aspx' class='positroncannon'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourcePositronCannon' title='Canhão de Positrões' alt='Canhão de Positrões' resourceName='PositronCannon'/> Canhão de Positrões</a></li><li><a href='/pt/Intrinsic/TitanUnitronCannon.aspx' class='titanunitroncannon'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTitanUnitronCannon' title='Canhão Unitron de um Titan' alt='Canhão Unitron de um Titan' resourceName='TitanUnitronCannon'/> Canhão Unitron de um Titan</a></li><li><a href='/pt/Intrinsic/ReaperControlHelmet.aspx' class='reapercontrolhelmet'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceReaperControlHelmet' title='Capacete de Contrôlo de um Reaper' alt='Capacete de Contrôlo de um Reaper' resourceName='ReaperControlHelmet'/> Capacete de Contrôlo de um Reaper</a></li><li><a href='/pt/Intrinsic/TitanControlHelmet.aspx' class='titancontrolhelmet'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTitanControlHelmet' title='Capacete de Contrôlo de um Titã' alt='Capacete de Contrôlo de um Titã' resourceName='TitanControlHelmet'/> Capacete de Contrôlo de um Titã</a></li><li><a href='/pt/Intrinsic/DeutiriumEnergyCapsule.aspx' class='deutiriumenergycapsule'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceDeutiriumEnergyCapsule' title='Cápsula de Energia de Deutério' alt='Cápsula de Energia de Deutério' resourceName='DeutiriumEnergyCapsule'/> Cápsula de Energia de Deutério</a></li><li><a href='/pt/Intrinsic/EscapePod.aspx' class='escapepod'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceEscapePod' title='Cápsula de Fuga' alt='Cápsula de Fuga' resourceName='EscapePod'/> Cápsula de Fuga</a></li><li><a href='/pt/Intrinsic/ElectricCircuit.aspx' class='electriccircuit'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceElectricCircuit' title='Circuito Elétrico' alt='Circuito Elétrico' resourceName='ElectricCircuit'/> Circuito Elétrico</a></li><li><a href='/pt/Intrinsic/Elk.aspx' class='elk'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceElk' title='Comida' alt='Comida' resourceName='Elk'/> Comida</a></li><li><a href='/pt/Intrinsic/TacticalComputer.aspx' class='tacticalcomputer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTacticalComputer' title='Computador Táctico' alt='Computador Táctico' resourceName='TacticalComputer'/> Computador Táctico</a></li><li><a href='/pt/Intrinsic/AirVent.aspx' class='airvent'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceAirVent' title='Conduta de Ar' alt='Conduta de Ar' resourceName='AirVent'/> Conduta de Ar</a></li><li><a href='/pt/Intrinsic/PlasmaConduit.aspx' class='plasmaconduit'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourcePlasmaConduit' title='Conduta de Plasma' alt='Conduta de Plasma' resourceName='PlasmaConduit'/> Conduta de Plasma</a></li><li><a href='/pt/Intrinsic/AntiMatterContainer.aspx' class='antimattercontainer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceAntiMatterContainer' title='Contentor Anti Mátéria' alt='Contentor Anti Mátéria' resourceName='AntiMatterContainer'/> Contentor Anti Mátéria</a></li><li><a href='/pt/Intrinsic/BlueMatterContainer.aspx' class='bluemattercontainer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceBlueMatterContainer' title='Contentor de Matéria Azul' alt='Contentor de Matéria Azul' resourceName='BlueMatterContainer'/> Contentor de Matéria Azul</a></li><li><a href='/pt/Intrinsic/PositronContainer.aspx' class='positroncontainer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourcePositronContainer' title='Contentor de Positrões' alt='Contentor de Positrões' resourceName='PositronContainer'/> Contentor de Positrões</a></li><li><a href='/pt/Intrinsic/Cryptium.aspx' class='cryptium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCryptium' title='Cryptium' alt='Cryptium' resourceName='Cryptium'/> Cryptium</a></li><li><a href='/pt/Intrinsic/HolographicCube.aspx' class='holographiccube'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceHolographicCube' title='Cubo Holográfico' alt='Cubo Holográfico' resourceName='HolographicCube'/> Cubo Holográfico</a></li><li><a href='/pt/Intrinsic/Diamonds.aspx' class='diamonds'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceDiamonds' title='Diamantes' alt='Diamantes' resourceName='Diamonds'/> Diamantes</a></li><li><a href='/pt/Intrinsic/Energy.aspx' class='energy'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceEnergy' title='Energia' alt='Energia' resourceName='Energy'/> Energia</a></li><li><a href='/pt/Intrinsic/QueueSpace.aspx' class='queuespace'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceQueueSpace' title='Espaço na Lista de Espera' alt='Espaço na Lista de Espera' resourceName='QueueSpace'/> Espaço na Lista de Espera</a></li><li><a href='/pt/Intrinsic/ProductionSpace.aspx' class='productionspace'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceProductionSpace' title='Espaço para Produção' alt='Espaço para Produção' resourceName='ProductionSpace'/> Espaço para Produção</a></li><li><a href='/pt/Intrinsic/CaptainWolfShipSpecifications.aspx' class='captainwolfshipspecifications'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCaptainWolfShipSpecifications' title='Especificações da nave do Capitão Lobo' alt='Especificações da nave do Capitão Lobo' resourceName='CaptainWolfShipSpecifications'/> Especificações da nave do Capitão Lobo</a></li><li><a href='/pt/Intrinsic/CommanderFoxShipSpecifications.aspx' class='commanderfoxshipspecifications'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCommanderFoxShipSpecifications' title='Especificações da nave do Comandante Raposa' alt='Especificações da nave do Comandante Raposa' resourceName='CommanderFoxShipSpecifications'/> Especificações da nave do Comandante Raposa</a></li><li><a href='/pt/Intrinsic/JumperStabilizers.aspx' class='jumperstabilizers'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceJumperStabilizers' title='Estabilizadores de um Jumper' alt='Estabilizadores de um Jumper' resourceName='JumperStabilizers'/> Estabilizadores de um Jumper</a></li><li><a href='/pt/Intrinsic/Tools.aspx' class='tools'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTools' title='Ferramentas' alt='Ferramentas' resourceName='Tools'/> Ferramentas</a></li><li><a href='/pt/Intrinsic/CrawlerGyroBalancer.aspx' class='crawlergyrobalancer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCrawlerGyroBalancer' title='Giro-Balanceador de um Rastejante' alt='Giro-Balanceador de um Rastejante' resourceName='CrawlerGyroBalancer'/> Giro-Balanceador de um Rastejante</a></li><li><a href='/pt/Intrinsic/WalkerGiroBalancer.aspx' class='walkergirobalancer'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceWalkerGiroBalancer' title='Giro-Balanceador de um Walker' alt='Giro-Balanceador de um Walker' resourceName='WalkerGiroBalancer'/> Giro-Balanceador de um Walker</a></li><li><a href='/pt/Intrinsic/CrawlerStaticPulse.aspx' class='crawlerstaticpulse'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCrawlerStaticPulse' title='Impulso Estático de um Rastejante' alt='Impulso Estático de um Rastejante' resourceName='CrawlerStaticPulse'/> Impulso Estático de um Rastejante</a></li><li><a href='/pt/Intrinsic/MedicalKit.aspx' class='medicalkit'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMedicalKit' title='Kit Médico' alt='Kit Médico' resourceName='MedicalKit'/> Kit Médico</a></li><li><a href='/pt/Intrinsic/CriminalListAlpha.aspx' class='criminallistalpha'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListAlpha' title='Lista de Criminosos Alpha' alt='Lista de Criminosos Alpha' resourceName='CriminalListAlpha'/> Lista de Criminosos Alpha</a></li><li><a href='/pt/Intrinsic/CriminalListBeta.aspx' class='criminallistbeta'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListBeta' title='Lista de Criminosos Beta' alt='Lista de Criminosos Beta' resourceName='CriminalListBeta'/> Lista de Criminosos Beta</a></li><li><a href='/pt/Intrinsic/CriminalListDelta.aspx' class='criminallistdelta'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListDelta' title='Lista de Criminosos Delta' alt='Lista de Criminosos Delta' resourceName='CriminalListDelta'/> Lista de Criminosos Delta</a></li><li><a href='/pt/Intrinsic/CriminalListGamma.aspx' class='criminallistgamma'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListGamma' title='Lista de Criminosos Gamma' alt='Lista de Criminosos Gamma' resourceName='CriminalListGamma'/> Lista de Criminosos Gamma</a></li><li><a href='/pt/Intrinsic/CriminalListOmega.aspx' class='criminallistomega'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListOmega' title='Lista de Criminosos Omega' alt='Lista de Criminosos Omega' resourceName='CriminalListOmega'/> Lista de Criminosos Omega</a></li><li><a href='/pt/Intrinsic/CriminalListSigma.aspx' class='criminallistsigma'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCriminalListSigma' title='Lista de Criminosos Sigma' alt='Lista de Criminosos Sigma' resourceName='CriminalListSigma'/> Lista de Criminosos Sigma</a></li><li><a href='/pt/Intrinsic/Supplies.aspx' class='supplies'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSupplies' title='Mantimentos' alt='Mantimentos' resourceName='Supplies'/> Mantimentos</a></li><li><a href='/pt/Intrinsic/BlackMercSpaceChart.aspx' class='blackmercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceBlackMercSpaceChart' title='Mapa Espacial dos Black Mercs' alt='Mapa Espacial dos Black Mercs' resourceName='BlackMercSpaceChart'/> Mapa Espacial dos Black Mercs</a></li><li><a href='/pt/Intrinsic/DarkMercSpaceChart.aspx' class='darkmercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceDarkMercSpaceChart' title='Mapa Espacial dos Dark Mercs' alt='Mapa Espacial dos Dark Mercs' resourceName='DarkMercSpaceChart'/> Mapa Espacial dos Dark Mercs</a></li><li><a href='/pt/Intrinsic/MercSpaceChart.aspx' class='mercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMercSpaceChart' title='Mapa Espacial dos Mercs' alt='Mapa Espacial dos Mercs' resourceName='MercSpaceChart'/> Mapa Espacial dos Mercs</a></li><li><a href='/pt/Intrinsic/RogueMercSpaceChart.aspx' class='roguemercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceRogueMercSpaceChart' title='Mapa Espacial dos Rogue Mercs' alt='Mapa Espacial dos Rogue Mercs' resourceName='RogueMercSpaceChart'/> Mapa Espacial dos Rogue Mercs</a></li><li><a href='/pt/Intrinsic/SentryMercSpaceChart.aspx' class='sentrymercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSentryMercSpaceChart' title='Mapa Espacial dos Sentry Mercs' alt='Mapa Espacial dos Sentry Mercs' resourceName='SentryMercSpaceChart'/> Mapa Espacial dos Sentry Mercs</a></li><li><a href='/pt/Intrinsic/TechMercSpaceChart.aspx' class='techmercspacechart'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTechMercSpaceChart' title='Mapa Espacial dos Tech Mercs' alt='Mapa Espacial dos Tech Mercs' resourceName='TechMercSpaceChart'/> Mapa Espacial dos Tech Mercs</a></li><li><a href='/pt/Intrinsic/BlueMatter.aspx' class='bluematter'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceBlueMatter' title='Matéria Azul' alt='Matéria Azul' resourceName='BlueMatter'/> Matéria Azul</a></li><li><a href='/pt/Intrinsic/GreyMatter.aspx' class='greymatter'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceGreyMatter' title='Matéria Cinzenta' alt='Matéria Cinzenta' resourceName='GreyMatter'/> Matéria Cinzenta</a></li><li><a href='/pt/Intrinsic/DarkMatter.aspx' class='darkmatter'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceDarkMatter' title='Matéria Negra' alt='Matéria Negra' resourceName='DarkMatter'/> Matéria Negra</a></li><li><a href='/pt/Intrinsic/RedMatter.aspx' class='redmatter'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceRedMatter' title='Matéria Vermelha' alt='Matéria Vermelha' resourceName='RedMatter'/> Matéria Vermelha</a></li><li><a href='/pt/Intrinsic/Medicine.aspx' class='medicine'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMedicine' title='Medicamentos' alt='Medicamentos' resourceName='Medicine'/> Medicamentos</a></li><li><a href='/pt/Intrinsic/Mercury.aspx' class='mercury'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMercury' title='Mercúrio' alt='Mercúrio' resourceName='Mercury'/> Mercúrio</a></li><li><a href='/pt/Intrinsic/Mithril.aspx' class='mithril'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMithril' title='Mithril' alt='Mithril' resourceName='Mithril'/> Mithril</a></li><li><a href='/pt/Intrinsic/LightEngines.aspx' class='lightengines'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceLightEngines' title='Motores de Velocidade da Luz' alt='Motores de Velocidade da Luz' resourceName='LightEngines'/> Motores de Velocidade da Luz</a></li><li><a href='/pt/Intrinsic/SubLightEngines.aspx' class='sublightengines'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSubLightEngines' title='Motores Sub-Luz' alt='Motores Sub-Luz' resourceName='SubLightEngines'/> Motores Sub-Luz</a></li><li><a href='/pt/Intrinsic/NanoProbe.aspx' class='nanoprobe'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceNanoProbe' title='Nano Sonda' alt='Nano Sonda' resourceName='NanoProbe'/> Nano Sonda</a></li><li><a href='/pt/Intrinsic/CarbonNanoTube.aspx' class='carbonnanotube'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCarbonNanoTube' title='Nano Tubos de Carbono' alt='Nano Tubos de Carbono' resourceName='CarbonNanoTube'/> Nano Tubos de Carbono</a></li><li><a href='/pt/Intrinsic/WalkerCore.aspx' class='walkercore'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceWalkerCore' title='Núcleo de um Walker' alt='Núcleo de um Walker' resourceName='WalkerCore'/> Núcleo de um Walker</a></li><li><a href='/pt/Intrinsic/Gold.aspx' class='gold'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceGold' title='Ouro' alt='Ouro' resourceName='Gold'/> Ouro</a></li><li><a href='/pt/Intrinsic/ScourgeControlPanel.aspx' class='scourgecontrolpanel'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceScourgeControlPanel' title='Painel de Controlo de um Flagelo' alt='Painel de Controlo de um Flagelo' resourceName='ScourgeControlPanel'/> Painel de Controlo de um Flagelo</a></li><li><a href='/pt/Intrinsic/PrimaryBoard.aspx' class='primaryboard'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourcePrimaryBoard' title='Placa Principal' alt='Placa Principal' resourceName='PrimaryBoard'/> Placa Principal</a></li><li><a href='/pt/Intrinsic/CosmicDust.aspx' class='cosmicdust'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceCosmicDust' title='Poeira Cósmica' alt='Poeira Cósmica' resourceName='CosmicDust'/> Poeira Cósmica</a></li><li><a href='/pt/Intrinsic/Prismal.aspx' class='prismal'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourcePrismal' title='Prismal' alt='Prismal' resourceName='Prismal'/> Prismal</a></li><li><a href='/pt/Intrinsic/Protol.aspx' class='protol'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceProtol' title='Protol' alt='Protol' resourceName='Protol'/> Protol</a></li><li><a href='/pt/Intrinsic/Radon.aspx' class='radon'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceRadon' title='Radon' alt='Radon' resourceName='Radon'/> Radon</a></li><li><a href='/pt/Intrinsic/JumperReactor.aspx' class='jumperreactor'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceJumperReactor' title='Reactor de um Jumper' alt='Reactor de um Jumper' resourceName='JumperReactor'/> Reactor de um Jumper</a></li><li><a href='/pt/Intrinsic/SentryReactor.aspx' class='sentryreactor'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSentryReactor' title='Reactor de um Sentry' alt='Reactor de um Sentry' resourceName='SentryReactor'/> Reactor de um Sentry</a></li><li><a href='/pt/Intrinsic/SubSpaceSensors.aspx' class='subspacesensors'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSubSpaceSensors' title='Sensores Sub-Espaço' alt='Sensores Sub-Espaço' resourceName='SubSpaceSensors'/> Sensores Sub-Espaço</a></li><li><a href='/pt/Intrinsic/Serium.aspx' class='serium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSerium' title='Serium' alt='Serium' resourceName='Serium'/> Serium</a></li><li><a href='/pt/Intrinsic/Silicium.aspx' class='silicium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSilicium' title='Silício' alt='Silício' resourceName='Silicium'/> Silício</a></li><li><a href='/pt/Intrinsic/ReaperCoreSystem.aspx' class='reapercoresystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceReaperCoreSystem' title='Sistema de Contrôlo de um Ceifeiro' alt='Sistema de Contrôlo de um Ceifeiro' resourceName='ReaperCoreSystem'/> Sistema de Contrôlo de um Ceifeiro</a></li><li><a href='/pt/Intrinsic/ScourgeCoreSystem.aspx' class='scourgecoresystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceScourgeCoreSystem' title='Sistema de Contrôlo de um Flagelo' alt='Sistema de Contrôlo de um Flagelo' resourceName='ScourgeCoreSystem'/> Sistema de Contrôlo de um Flagelo</a></li><li><a href='/pt/Intrinsic/ExhaustionSystem.aspx' class='exhaustionsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceExhaustionSystem' title='Sistema de Exaustão' alt='Sistema de Exaustão' resourceName='ExhaustionSystem'/> Sistema de Exaustão</a></li><li><a href='/pt/Intrinsic/MystTargetingSystem.aspx' class='mysttargetingsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMystTargetingSystem' title='Sistema de Mira das Myst' alt='Sistema de Mira das Myst' resourceName='MystTargetingSystem'/> Sistema de Mira das Myst</a></li><li><a href='/pt/Intrinsic/FistTargettingSystem.aspx' class='fisttargettingsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceFistTargettingSystem' title='Sistema de Mira de um Punho' alt='Sistema de Mira de um Punho' resourceName='FistTargettingSystem'/> Sistema de Mira de um Punho</a></li><li><a href='/pt/Intrinsic/TitanTargetingSystem.aspx' class='titantargetingsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTitanTargetingSystem' title='Sistema de Mira de um Titã' alt='Sistema de Mira de um Titã' resourceName='TitanTargetingSystem'/> Sistema de Mira de um Titã</a></li><li><a href='/pt/Intrinsic/ScourgePropulsionSystem.aspx' class='scourgepropulsionsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceScourgePropulsionSystem' title='Sistema de Propulsão de um Flagelo' alt='Sistema de Propulsão de um Flagelo' resourceName='ScourgePropulsionSystem'/> Sistema de Propulsão de um Flagelo</a></li><li><a href='/pt/Intrinsic/MystPropulsionSystem.aspx' class='mystpropulsionsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMystPropulsionSystem' title='Sistema de Propulsão de um Myst' alt='Sistema de Propulsão de um Myst' resourceName='MystPropulsionSystem'/> Sistema de Propulsão de um Myst</a></li><li><a href='/pt/Intrinsic/ReaperPropulsionSystem.aspx' class='reaperpropulsionsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceReaperPropulsionSystem' title='Sistema de Propulsão de um Reaper' alt='Sistema de Propulsão de um Reaper' resourceName='ReaperPropulsionSystem'/> Sistema de Propulsão de um Reaper</a></li><li><a href='/pt/Intrinsic/TransportSystem.aspx' class='transportsystem'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTransportSystem' title='Sistema de Transporte' alt='Sistema de Transporte' resourceName='TransportSystem'/> Sistema de Transporte</a></li><li><a href='/pt/Intrinsic/Titanium.aspx' class='titanium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTitanium' title='Titânio' alt='Titânio' resourceName='Titanium'/> Titânio</a></li><li><a href='/pt/Intrinsic/DarkMercUniform.aspx' class='darkmercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceDarkMercUniform' title='Unforme dos Dark Mercs' alt='Unforme dos Dark Mercs' resourceName='DarkMercUniform'/> Unforme dos Dark Mercs</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformAlpha.aspx' class='spaceforceuniformalpha'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformAlpha' title='Uniforme da Space Force Alpha' alt='Uniforme da Space Force Alpha' resourceName='SpaceForceUniformAlpha'/> Uniforme da Space Force Alpha</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformBeta.aspx' class='spaceforceuniformbeta'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformBeta' title='Uniforme da Space Force Beta' alt='Uniforme da Space Force Beta' resourceName='SpaceForceUniformBeta'/> Uniforme da Space Force Beta</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformDelta.aspx' class='spaceforceuniformdelta'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformDelta' title='Uniforme da Space Force Delta' alt='Uniforme da Space Force Delta' resourceName='SpaceForceUniformDelta'/> Uniforme da Space Force Delta</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformGamma.aspx' class='spaceforceuniformgamma'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformGamma' title='Uniforme da Space Force Gamma' alt='Uniforme da Space Force Gamma' resourceName='SpaceForceUniformGamma'/> Uniforme da Space Force Gamma</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformOmega.aspx' class='spaceforceuniformomega'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformOmega' title='Uniforme da Space Force Omega' alt='Uniforme da Space Force Omega' resourceName='SpaceForceUniformOmega'/> Uniforme da Space Force Omega</a></li><li><a href='/pt/Intrinsic/SpaceForceUniformSigma.aspx' class='spaceforceuniformsigma'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSpaceForceUniformSigma' title='Uniforme da Space Force Sigma' alt='Uniforme da Space Force Sigma' resourceName='SpaceForceUniformSigma'/> Uniforme da Space Force Sigma</a></li><li><a href='/pt/Intrinsic/RogueMercUniform.aspx' class='roguemercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceRogueMercUniform' title='Uniforme de um Rogue Mercs' alt='Uniforme de um Rogue Mercs' resourceName='RogueMercUniform'/> Uniforme de um Rogue Mercs</a></li><li><a href='/pt/Intrinsic/BlackMercUniform.aspx' class='blackmercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceBlackMercUniform' title='Uniforme dos Black Mercs' alt='Uniforme dos Black Mercs' resourceName='BlackMercUniform'/> Uniforme dos Black Mercs</a></li><li><a href='/pt/Intrinsic/SentryMercUniform.aspx' class='sentrymercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceSentryMercUniform' title='Uniforme dos Sentry Mercs' alt='Uniforme dos Sentry Mercs' resourceName='SentryMercUniform'/> Uniforme dos Sentry Mercs</a></li><li><a href='/pt/Intrinsic/TechMercUniform.aspx' class='techmercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceTechMercUniform' title='Uniforme dos Tech Mercs' alt='Uniforme dos Tech Mercs' resourceName='TechMercUniform'/> Uniforme dos Tech Mercs</a></li><li><a href='/pt/Intrinsic/MercUniform.aspx' class='mercuniform'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceMercUniform' title='Uniformes de Merc' alt='Uniformes de Merc' resourceName='MercUniform'/> Uniformes de Merc</a></li><li><a href='/pt/Intrinsic/Uranium.aspx' class='uranium'><img src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gif' class='resourceSmall resourceUranium' title='Urânio' alt='Urânio' resourceName='Uranium'/> Urânio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Matéria Azul" runat="server" /></h1>

	<div class="description">
		Matéria Azul
		<img title='BlueMatter' class='resourceSmall resourceBlueMatter' src='http://resources.orionsbelt.eu/Images/Common/Etc/Fill.gig' />
	</div>
	
</asp:Content>