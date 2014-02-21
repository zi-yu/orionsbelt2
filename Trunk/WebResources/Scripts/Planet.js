
var Planet = {

    start : function() {
        try {
            if( window.location.href.indexOf("#") >= 0 ) {
                Planet.onHistoryChanged(window.location.hash);
            }
        } catch(e) {
            log.error(e);
        }
    },

    sendRequest : function(args) {
        if( $('hub').value == '1' ) {
            Message.raiseAlert("YouHaveBattlesToPlay");
            return false;
        }
    
        var url = "../Ajax/Planets/Renderer.ashx?t=" + new Date().getTime().toString();
        var hash = "/";
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
                hash += propName + "_" + args[propName] + "/";
            }
        }
        
        if( args.CallBack == null ) {
            args.CallBack = Planet.planetInfoUpdater;
        }
        Site.HistoryManager.addState(hash);
        Utils.ajaxRequest('get', url, $("planetContent"), args.CallBack);
        
        log.info(args.Panel);
    },
    
    onHistoryChanged : function(newHash) {
        if( $("planetContent") == null ) {
            return;
        }
        if( newHash.indexOf("tutorial") >= 0 || newHash.indexOf("topView") >= 0 ) {
            return;
        }
        newHash = newHash.replace("#","");
        log.debug("Hash: " + newHash);
        if( newHash == "" || newHash == "/" ) {
            if( window.redirectToPlanet && window.redirectToPlanet != null ) {
                window.location = "Default.aspx?Id=" + window.redirectToPlanet;
            } else {
                window.location = "Default.aspx?Id=" + window.planetInfo.PlanetId;
            }
            return;
        }
        var params = newHash.split("/");
        var json = {};
        for( var i = 0; i < params.length; ++i ) {
            var param = params[i];
            if( param == "" ) {
                continue;
            }
            var args = param.split("_");
            if( args[0] != "Action" ){
                json[args[0]] = args[1];
            }
        }
        Planet.sendRequest(json);
	},
    
    destroyFacility : function(planetId, slotName) {
        if( Message.raiseConfirm("ReallyDestroyFacility") ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Action:"Destroy"} );
        }
    },
    
    upgradeFacility : function(planetId, slotName) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Action:"Upgrade"} );
    },
    
    startBuildUnit : function(planetId, unitName) {
        var raw = $(unitName + "_Quantity").value;
        var y=parseInt(raw); 
        if (isNaN(y)){
            Message.raiseAlert("NaN");
            return;
        }
        if( y <= 0 ) {
            Message.raiseAlert("MustBePositiveQuantity");
            return;
        }
        Planet.sendRequest( {Planet:planetId, Panel:"Units", Resource:unitName, Quantity:y, Action:"Build"} );
    },
    
    startBuildFacility : function(planetId, slotName, resourceName) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Resource:resourceName, Action:"Build"} );
    },
    
    createFleet : function(planetId) {
        Fleet.sendRequest( {Type:'change', Changes:Fleet.changeLog, CallBack: Planet.createFleetCallBack } );
    },
    
    createFleetCallBack : function() {
        var fleetName = $('fleetName').value;
        Planet.sendRequest( {Planet:window.planetInfo.PlanetId, Panel:"Fleets", FleetName:fleetName, CallBack:Planet.fleetCallBack, Action:"CreateFleet"} );      
    },
    
    cancelFacilityQueue : function(planetId, resourceId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", ResourceId:resourceId, Action:"RemoveQueue"} );
    },
    
    cancelUnitQueue : function(planetId, resourceId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Units", ResourceId:resourceId, Action:"RemoveQueue"} );
    },
    
    cancelFacilityProduction : function(planetId, resourceId) {
        if( !Message.raiseConfirm("YouWillLooseResources") ) {
	        return;
	    }
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", ResourceId:resourceId, Action:"RemoveProduction"} );
    },
    
    cancelUnitProduction : function(planetId, resourceId) {
        if( !Message.raiseConfirm("YouWillLooseResources") ) {
	        return;
	    }
        Planet.sendRequest( {Planet:planetId, Panel:"Units", ResourceId:resourceId, Action:"RemoveProduction"} );
    },
    
    changeName : function(planetId){
        var newName = $("newPlanetName").value;
        log.debug("New Name:" + newName);
        
        if( Utils.checkAndNotifyStringNotEmpty(newName) ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Manage", Action:"ChangeName", NewName:newName} );
        }
    },
    
    abandonPlanet : function(planetId) {
        if( Message.raiseConfirm("ReallyAbandonPlanet") ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Manage", Action:"AbandonPlanet"} );
        }
    },
    
    getQueue : function(planetId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Queue"} );
    },
    
    toHome : function(planetId) {
        Planet.sendRequest({Planet:planetId, Panel:"Facilities"});
    },
    
    toUnits : function(planetId){
        Planet.sendRequest({Planet:planetId, Panel:"Units"});
    },
    
    toPanel : function(planetId, panelName) {
        if( panelName == "Fleets" ) {
            Planet.toFleets(planetId);
            return;
        }
        Planet.sendRequest( {Planet:planetId, Panel:panelName} );
    },
    
    toFleets : function(planetId){
        Planet.sendRequest({Planet:planetId, Panel:"Fleets", CallBack:Planet.fleetCallBack});
    },
    
    fleetCallBack : function() {
        Planet.planetInfoUpdater();
    },
    
    planetInfoUpdater : function() {
                
        if( window.redirectToPlanet && window.redirectToPlanet != null ) {
            window.location = "Default.aspx?Id=" + window.redirectToPlanet;
            return;
        }
        
        Planet.updatePlayerResources();

        var planetHeader = $("planetHeader");
        if( planetHeader != null ) {
            planetHeader.innerHTML = window.planetInfo.PlanetName + " - " + window.planetInfo.PlanetLocation;
            planetHeader.href = "javascript:Planet.toHome(" + window.planetInfo.PlanetId + ");";
        }
        
        var planetNameOnList = $("planetName" + window.planetInfo.PlanetId);
        if( planetNameOnList != null ) {
            planetNameOnList.innerHTML = window.planetInfo.PlanetName;
        }
        
        UniverseUtils.removeAllToolTips();
        Planet.addTooltips();
        Tutorial.advance();
        Fleet.load();
        
        pageTracker._trackPageview(window.location);
        log.profile("ajaxRequest");
    },
    
    updatePlayerResources : function() {
        var resourceList = window.resourceList;
        if( resourceList != null ) {
            for( var propName in resourceList ) {
                var elem = $(propName);
                if( elem != null ) {
                    elem.innerHTML = window.resourceList[propName];
                    Planet.showHideElem(elem, propName, window.resourceList[propName]);
                }
            }
        }
    },
    
    modRegex : /\w+Mod$/,
    
    showHideElem : function(elem, propName, quantity) {
        if( ! Planet.modRegex.test(propName) ){
            return;
        }
        
        if( window.resourceList[propName] == 0 ) {
            elem.getParent().setStyles({display:"none"});
        } else {
            elem.getParent().setStyles({display:"block"});
        }
    },
    
    build : function(planetId, slotName) {
        Planet.sendRequest({Planet:planetId, Panel:"BuildFacility", SlotName:slotName});
    },
    
    upgrade : function(planetId, resourceId) {
        Planet.sendRequest({Planet:planetId, Panel:"UpgradeFacility", ResourceId:resourceId});
    },
    
    unloadCargo: function(planetId,fleetId, cargoId){
        Planet.sendRequest( {Planet:planetId, FleetId:fleetId, Panel:"Fleets", Action:"UnloadFleet", CallBack:Fleet.load} );
    },
    
    addTooltips : function() {
        var tips = window.slotTips;
        if( tips ) {
            for( var slot in tips ) {
                var elem = $(slot);
                var tip = tips[slot];
                if( elem != null ) {
                    if( tip.b.l ) {
                        var html = "<ul>";
                        html += "<li>" + Language.getToken("Level") + " " + tip.b.l + "</li>";
                        html += "<li>" + Language.getToken("State") + ": " + Language.getToken(tip.b.s) + "</li>";
                        html += "</ul>";
                        if( tip.b.m != "" ) {
                            html += "<p style='margin-top:10px;'>" + Language.getToken(tip.b.m) + "</p>";
                        }
                        if( tip.b.rm != "" ) {
                            html += "<p style='margin-top:10px;'>" + tip.b.rm + "</p>";
                        }
                        Utils.insertTip(elem, Language.getToken(tip.t), html );
                    } else {
                        var body = tip.b;
                        log.debug(tip.l);
                        if( tip.l != false ) {
                            body = Language.getToken(tip.b);
                        }
                        Utils.insertTip(elem, Language.getToken(tip.t), body );
                    }
                }
            }
        }
    }
  
};

window.addEvent('domready', Site.startPlanet);