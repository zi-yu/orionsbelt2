
var Tutorial = {

    getPanel : function() {
        return $("tutorial");
    },

    show : function(tutorial) {
        if( window.overrideTutorial != null ) {
            tutorial = window.overrideTutorial;
        }
        if( this[tutorial] != null ) {
            Information.leftInfofixed = true;
            this[tutorial]();
        } else {
            this.showNoTutorial();
        }
    },
    
    hide : function() {
        this.getPanel().setStyle("display", "none");
        this.autoNext = null;
        Information.leftInfofixed = false;
    },
    
    start : function() {
        if( window.autoStartTutorial != null ) {
            Tutorial.show(window.autoStartTutorial);
        }
    },
    
    advance : function() {
        var next = this.autoNext;
        this.autoNext = null;
    
        if( next != null ) {
            window.tutorialEnabled = true;
            this[next]();
        }
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Quests Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     CheckpointQuest : function() {
        this.showPanel({
            titleToken : "QuestsTutorial",
            contentToken : "QuestsTutorialContent",
            refElemId : $("quests"),
            offsetX : 250,
            offsetY : -150,
            width : 500,
            next : "End"
        });
    },
    
    TaskQuest : function() {
        this.showPanel({
            titleToken : "QuestsTutorial",
            contentToken : "QuestsTaskContent",
            refElemId : $("quests"),
            offsetX : 250,
            offsetY : -150,
            width : 500,
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Home Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    Home : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContent",
            refElemId : $("genericMessages"),
            offsetX : 80,
            offsetY : 0,
            width : 500,
            arrow : "top",
            next : "HomeAH"
        });
    },
    
    HomeAH : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContent2",
            refElemId : $("ahAd"),
            offsetX : -300,
            offsetY : -90,
            width : 250,
            arrow : "right",
            previous : "Home",
            next : "HomeCharts"
        });
    },
    
    HomeCharts : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContentCharts",
            refElemId : $("charts"),
            offsetX :-300,
            offsetY : -90,
            width : 250,
            arrow : "right",
            previous : "HomeAH",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Battle Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     Battle : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 25,
            width : 400,
            next : "BattleSelect"
        });
    },
    
    BattleSelect : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleSelectContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 150,
            width : 400,
            follow : false,
            arrow : "bottom"
        });
        this.autoNext = "BattleUnitSelected";
    },
    
    BattleUnitSelected : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : -90,
            width : 400,
            arrow : "left",
            next : "BattleUnitSelectedStrong"
        });
    },
    
    BattleUnitSelectedStrong : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedStrongContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 40,
            width : 400,
            follow: false,
            arrow : "left",
            previous : "BattleUnitSelected",
            next : "BattleUnitSelectedWeak"
        });
    },
    
    BattleUnitSelectedWeak : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedWeakContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 155,
            width : 400,
            follow: false,
            arrow : "left",
            previous : "BattleUnitSelectedStrong",
            next : "BattleUnitSelectedAttack"
        });
    },
    
    BattleUnitSelectedAttack : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedAttackContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 250,
            width : 400,
            arrow : "left",
            previous : "BattleUnitSelectedWeak",
            next : "BattleUnitSelectedMov"
        });
    },
    
    BattleUnitSelectedMov : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 375,
            width : 400,
            arrow : "left",
            previous : "BattleUnitSelectedAttack",
            next : "BattleUnitSelectedMovPoints"
        });
    },
    
    BattleUnitSelectedMovPoints : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovPointsContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 15,
            width : 400,
            arrow : "right"
        });
        this.autoNext = "BattleUnitSelectedMovPoints2";
    },
    
    BattleUnitSelectedMovPoints2 : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovPoints2Content",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 15,
            width : 400,
            arrow : "right",
            next : "BattleUnitSplit"
        });
    },
    
    BattleUnitSplit: function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSplitContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 75,
            width : 400,
            arrow : "right",
            previous : "BattleUnitSelectedMovPoints2",
            next : "BattleUnitDirection"
        });
    },
    
    BattleUnitDirection : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitDirectionContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 280,
            width : 400,
            arrow : "right",
            previous : "BattleUnitSplit",
            next : "BattleCalculator"
        });
    },
    
    BattleCalculator : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleCalculatorContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 250,
            width : 400,
            arrow : "bottom",
            previous : "BattleUnitDirection",
            next : "BattleOptions"
        });
    },
    
    BattleOptions : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleOptionsContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -85,
            width : 400,
            arrow : "right",
            previous : "BattleCalculator",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Regicide Battle Deploy Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     RegicideDeploy : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "RegicideDeployContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -90,
            width : 400,
            next : "BattleDeploy"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Battle Deploy Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     BattleDeploy : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -90,
            width : 400,
            next : "BattleDeploySelect"
        });
    },
    
    BattleDeploySelect : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeploySelectContent",
            refElemId : $("initialContainers"),
            offsetX : 40,
            offsetY : -180,
            width : 400,
            arrow : "bottom"
        });
        this.autoNext = "BattleDeployDrop";
    },
    
    BattleDeployDrop : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployDropContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 150,
            width : 400,
            arrow : "bottom"
        });
        this.autoNext = "BattleDeployDropNext";
    },
    
    BattleDeployDropNext : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployDropNextContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 80,
            width : 400,
            arrow : "right",
            next : "BattleDeployFinish"
        });
    },
    
    BattleDeployFinish : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployFinishContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -50,
            width : 400,
            arrow : "right",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Private Zone Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     PrivateZone : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "PrivateZoneTutorialContent",
            refElemId : $("universe"),
            offsetX : 180,
            offsetY : 0,
            width : 400,
            next : "HomePlanet"
        });
    },
    
    HomePlanet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "HomePlanetContent",
            refElemId : $("universe"),
            offsetX : 225,
            offsetY : -55,
            arrow : "left",
            width : 300,
            previous: "PrivateZone",
            next : "YourFirstFleet"
        });
    },
    
    YourFirstFleet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "YourFirstFleetContent",
            refElemId : $("universe"),
            offsetX : 80,
            offsetY : -60,
            arrow : "top",
            width : 300,
            previous: "HomePlanet",
            next : "MoveFleet"
        });
    },
    
    MoveFleet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "MoveFleetContent",
            refElemId : $("universe"),
            offsetX : 280,
            offsetY : 0,
            width : 300,
            previous: "YourFirstFleet",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Bugs Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     BugsPlanets : function() {
        this.LightHumansPlanets();
        this["LHMainFacilityPanelX"] = 0;
        this["LHBuildPanelX"] = 185;
        this["LHBuildPanelY"] = 220;
        this["LHBuildingInConstructionX"] = 150;
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        DarkHumans Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     DarkHumansPlanets : function() {
        this.LightHumansPlanets();
        this["LHMainFacilityPanelX"] = 0;
        this["LHBuildPanelX"] = 135;
        this["LHBuildPanelY"] = 270;
        this["LHBuildingInConstructionX"] = 150;
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        LightHumans Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    LightHumansPlanets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "PlanetsTutorialContent",
            refElemId : $("tutRef"),
            offsetX : 135,
            offsetY : 0,
            width : 400,
            next : "LHResourcesPanel"
        });
    },
    
    LHResourcesPanel : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "ResourcesPanelContent",
            refElemId : $("playerResources"),
            offsetX : 296,
            offsetY : -80,
            arrow: "top",
            width : 400,
            previous : "LightHumansPlanets",
            next : "LHIncomePanel"
        });
    },
    
    LHIncomePanel : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "IncomeContent",
            refElemId : $("tutRef"),
            offsetX : 225,
            offsetY : 115,
            arrow: "right",
            width : 400,
            previous : "LHResourcesPanel",
            next : "LHMainFacilityPanel"
        });
    },
    
    LHMainFacilityPanel : function() {
        var x = this["LHMainFacilityPanelX"] != null ? this["LHMainFacilityPanelX"] : -74;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "MainFacilityContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : 0,
            arrow: "right",
            width : 200,
            previous : "LHIncomePanel",
            next : "LHBuildPanel"
        });
    },
    
    LHBuildPanel : function() {
        var x = this["LHBuildPanelX"] != null ? this["LHBuildPanelX"] : 15;
        var y = this["LHBuildPanelY"] != null ? this["LHBuildPanelY"] : 200;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : y,
            arrow: "right",
            follow : false,
            width : 200
            
        });
        this.autoNext = "LHBuildUpgradeScreen"
    },
    
    LHBuildUpgradeScreen : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityScreenContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next : "LHBuildUpgradeAction"
        });
    },
    
    LHBuildUpgradeAction : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityActionContent",
            refElemId : $("tutRef"),
            offsetX : 215,
            offsetY : 75,
            arrow: "right",
            follow:false,
            width : 200
        });
        this.autoNext = "LHBuildingInConstruction";
    },
    
    LHBuildingInConstruction : function() {
        var x = this["LHBuildingInConstructionX"] != null ? this["LHBuildingInConstructionX"] : 15;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "LHBuildingInConstructionContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : 200,
            width : 200,
            next : "LHGoToFleets"
        });
    },
    
    LHGoToFleets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "LHGoToFleetsContent",
            refElemId : $("tutRef"),
            arrow : "left",
            offsetX : 530,
            offsetY : -125,
            width : 200
        });
        this.autoNext = "OnFleetsScreen";
    },
    
    OnFleetsScreen : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "OnFleetsScreenContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next: "MoveUnitsFromFleets"
        });
    },
    
    MoveUnitsFromFleets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "MoveUnitsFromFleetsContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next: "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Other
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    End : function() {
        this.showPanel({
            titleToken : "TutorialEnd",
            contentToken : "TutorialEndContent",
            refElemId : $("siteFooter"),
            offsetX : 600,
            offsetY : -170
        });
        Information.leftInfofixed = false;
    },
    
    showNoTutorial : function() {
        this.showPanel({
            titleToken : "NoTutorial",
            contentToken : "NoTutorialContent",
            refElemId : $("siteFooter"),
            offsetX : 600,
            offsetY : -170,
            follow: false
        });
    },
    
    showPanel : function(args) {
    
        if( window.tutorialEnabled != null && !window.tutorialEnabled ) {
            return;
        }
    
        var panel = this.getPanel();
        var content = $("tutorialContent");
        var middle = $("middlet");
        
        //~~~~~~~~~~~~~~~~~~~~
        // Prepare anchor for positioning
        //~~~~~~~~~~~~~~~~~~~~
        var anchorId = "followtutorial_" + args.contentToken;       
        var anchor = panel.getFirst();
        anchor.id = anchorId;
        anchor.name = anchorId; 
       
        //~~~~~~~~~~~~~~~~~~~~
        // Set content
        //~~~~~~~~~~~~~~~~~~~~
        content.innerHTML = Language.getToken(args.contentToken);
        $("tutorialTitle").innerHTML = Language.getToken(args.titleToken);
        
        //~~~~~~~~~~~~~~~~~~~~
        // Remove unnecessary arrows
        //~~~~~~~~~~~~~~~~~~~~
        $("left").setStyle("display", "none");
        $("right").setStyle("display", "none");
        $("top").setStyle("display", "none");
        $("bottom").setStyle("display", "none");
        
        if( args.arrow != null ) {
            $(args.arrow).setStyle("display", "block");
        }
        
        //~~~~~~~~~~~~~~~~~~~~
        // Prepare panel
        //~~~~~~~~~~~~~~~~~~~~
        var target = $(args.refElemId);
        var pos = target.getPosition();
        
        var offsetX = args.offsetX ? args.offsetX : 0;
        var offsetY = args.offsetY ? args.offsetY : 0;
        var width = args.width ? args.width : 300;
        var masterWidth = width + 66;
        var height = args.height ? args.height : "auto";
        
        panel.setStyles({
            display: "block",
            top: pos.y + offsetY,
            left: pos.x + offsetX,
            width: masterWidth,
            height: height
        });
        
        middle.setStyles({
            width: width,
            height: height
        });
        
        //~~~~~~~~~~~~~~~~~~~~
        // Nav Links
        //~~~~~~~~~~~~~~~~~~~~
        if( args.next != null || args.previous != null ) {
            var nav = "<div class='nav'>";
            if( args.previous != null ) {
                nav += "<a class='nav' href='javascript:Tutorial."+args.previous+"();'>"+Language.getToken("Previous")+"</a>";
            }
            if( args.next != null ) {
                nav += "<a class='nav' href='javascript:Tutorial."+args.next+"();'>"+Language.getToken("Next")+"</a>";
            }
            nav += "</div>";
            content.innerHTML += nav;
        }
        
        //~~~~~~~~~~~~~~~~~~~~
        // Move browser to panel
        //~~~~~~~~~~~~~~~~~~~~
        if( (args.follow != null && args.follow) || args.follow == null ) {
            window.location.hash = "#" + anchorId;
        }
    }
};

window.addEvent('domready', Tutorial.start);
