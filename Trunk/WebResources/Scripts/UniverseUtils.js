
var fleetMovements = [];
var UniverseUtils = {
    sendUniverseRequest : function(url, element, args) {
        if( $('hub').value == '1' ) {
            Message.raiseAlert("YouHaveBattlesToPlay");
            return false;
        }
    
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if( args.CallBack == null ) {
            args.CallBack = UniverseUtils.genericCallBack;
        }
        Utils.ajaxRequest('get', url, element, args.CallBack);
        return true;
    },
    
    sendRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/Universe.ashx?1=1";
        return UniverseUtils.sendUniverseRequest(url, $('universe'), args);
    },
    
    sendMoveRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/FleetMove.ashx?"+UniverseUtils.getFullCoordinateQueryString();
        return UniverseUtils.sendUniverseRequest(url, null, args);
    },
    
    sendSimpleMoveRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/FleetMove.ashx?1=1";
        return UniverseUtils.sendUniverseRequest(url, null, args);
    },
    
    getFullCoordinateQueryString : function() {
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var systemDst = UniverseUtils.getDestinySystem();
        var sectorDst= UniverseUtils.getDestinySector();
        return "systemSrc="+systemSrc+"&sectorSrc="+sectorSrc+"&systemDst="+systemDst+"&sectorDst="+sectorDst;
    },
       
    getSourceSystem : function() {
        return UniverseUtils.sourceSelected.getAttribute("system");
    },
    
    getSourceSector : function() {
        return UniverseUtils.sourceSelected.getAttribute("sector");
    },
    
    getSourceCoordinate : function() {
        return UniverseUtils.getSourceSystem() + "_" + UniverseUtils.getSourceSector();
    },
    
    getDestinySystem : function() {
        return UniverseUtils.destinySelected.getAttribute("system");
    },
    
    getDestinySector : function() {
        return UniverseUtils.destinySelected.getAttribute("sector");
    },
    
    getDestinyCoordinate : function() {
        return UniverseUtils.getDestinySystem() + "_" + UniverseUtils.getDestinySector();
    },
    
    sourceTypeKey : function() {
        return UniverseUtils.sourceSelected.getAttribute("type")+"Source";
    },
    
    destinyTypeKey : function() {
        return UniverseUtils.destinySelected.getAttribute("type")+"Destiny";
    },

    isPrivateSector : function() {
        return $("isPrivateSector").value == "1"; 
    },

    load : function() {
        var td = $('universe').getElements('td');
        td.addEvent('click', function( e ) {
            UniverseUtils.selected(this,e);
        });
        UniverseUtils.removeAllToolTips();
        UniverseUtils.addToolTips();
        UniverseDirection.load();
        UniverseUtils.resetSelected();
        UniverseUtils.addRightMenuEvents();
        
    },
    
    addRightMenuEvents  : function() {
        var element = $('zoom1');
        if( element != null ) {
            element.addEvent('click', function( e ) {
                UniverseUtils.zoom1();
            });
            $('zoom2').addEvent('click', function( e ) {
                UniverseUtils.zoom2();
            });
            $('zoom3').addEvent('click', function( e ) {
                UniverseUtils.zoom3();
            });
            $('zoom4').addEvent('click', function( e ) {
                UniverseUtils.zoom4();
            });
        }
        var element = $('moveToButton');
        if( element != null){
            element.addEvent('click', function( e ) {
                UniverseUtils.moveEventWithCoordinates();
            });
        }
    },
    
    addToolTips : function() {
        UniverseUtils.addFleetsToolTip();
        UniverseUtils.addPlanetToolTip();
        UniverseUtils.addArenaToolTip();
        UniverseUtils.addMarketToolTip();
        UniverseUtils.addWormHoleToolTip();
        UniverseUtils.addBattleToolTip();
        UniverseUtils.addBeaconToolTip();
        UniverseUtils.addAcademyToolTip();
        UniverseUtils.addPirateBayToolTip();
        UniverseUtils.addRelicToolTip();
    },
    
    addLine : function(token, value) {
        var body = Language.getToken(token);
        body += ': ' + value + '<br/>';;
        return body;
    },
    
    getAlliance : function(obj){
        return "<span class='"+obj.s+"'>"+obj.a+"</span>";
    },
    
    getTTM: function(fleet) {
        return fleet.ttm != null ? fleet.ttm : 1;
    },
    
    getTTTM: function(fleet) {
        return fleet.tttm != null ? fleet.tttm : 1;
    },
    
    getETA : function(fleet) {
        var s = fleet.c.split(':');
        var d = fleet.d.split(':');
        
        var src = [ Number(s[0]),Number(s[1]),Number(s[2]),Number(s[3]) ];
        var dst = [ Number(d[0]),Number(d[1]),Number(d[2]),Number(d[3]) ];
        var anglePoint = [ Number(src[0]),Number(dst[1]),Number(src[2]),Number(dst[3]) ];
        
        var dst1 = Math.abs( ( ( (src[0]-anglePoint[0]) + (src[1]-anglePoint[1]) )*10 ) + ( (src[2]-anglePoint[2]) + (src[3]-anglePoint[3]) ) );
        var dst2 = Math.abs( ( ( (dst[0]-anglePoint[0]) + (dst[1]-anglePoint[1]) )*7 ) + ( (dst[2]-anglePoint[2]) + (dst[3]-anglePoint[3]) ) );
        
        var ticks =  dst1 > dst2 ? dst1 : dst2;
        var gap = UniverseUtils.getTTM(fleet);
        var tgap = UniverseUtils.getTTTM(fleet);
        var total = (ticks*tgap)-(tgap-gap);
        return Utils.getTimeFromTicks(total);
    },
    
    getFleetToolTipBody : function(fleet ) {
        var body = UniverseUtils.addLine('Owner',fleet.o);
        body += UniverseUtils.addLine('Coordinate', fleet.c );
        body += UniverseUtils.addLine('IsMoving', Language.getToken(fleet.m) );
        
        if( fleet.m ) {
            body += UniverseUtils.addLine('Destination',fleet.d);
            body += UniverseUtils.addLine('ETA',UniverseUtils.getETA(fleet));
            body += UniverseUtils.addLine('TTM',Utils.getTimeFromTicks( UniverseUtils.getTTM(fleet) ));
            fleet.ttm = 1;
        }
        if( fleet.a != ''){
            body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(fleet));
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        body += UniverseUtils.getFleetBeaconInformation(fleet);
        body += UniverseUtils.getToolTipResources(fleet,"Cargo");
        body += UniverseUtils.getFleetToolTipUnits(fleet,"Units");
        return body;
    },
    
    getFleetBeaconInformation : function(fleet ) {
        var body = '';
        if( fleet.lq != null) {
            body += UniverseUtils.addLine("LightQuantity",fleet.lq);
        }
        if( fleet.mq != null ) {
            body += UniverseUtils.addLine("MediumQuantity",fleet.mq);
        }
        if( fleet.hq != null ) {
            body += UniverseUtils.addLine("HeavyQuantity",fleet.hq);
        }
        return body;
    },
    
    getFleetToolTipUnits : function(element,langKey ) {
        var body = '';
        if( element.u != null ) {
            if( element.u.length > 1 ) {
                var body = UniverseUtils.addLine(langKey,'');
                body += "<div class='popupFleetUnits'>";
                for( var i = 0; i < element.u.length; ++i ) {
                    var unit = element.u[i];
                    if( unit.n != 'ignore' ) {
                        body += "<div><img src='"+ Utils.resolveUnitImage(unit.n)+"' alt='' title=''/><br/>"+unit.q+"</div>";
                    }
                }
                body += "</div>";    
            }else{
                var body = UniverseUtils.addLine(langKey,Language.getToken("None"));
            }
        }
        return body;
    },
      
    getToolTipResources : function(element,token) {
        var body = '';
        if( element.i != null ) {
            if( element.i.length > 1 ) {
                var body = UniverseUtils.addLine(token,'');
                body += "<div class='popupPlanetIncome'>";
                for( var i = 0; i < element.i.length; ++i ) {
                    var resource = element.i[i];
                    if( resource.n != 'ignore' ) {
                        body += "<div><img src='"+ Utils.resolveEtcImage("Fill","gif")+"' class='resourceSmall resource"+resource.n+"' alt='' title=''/><br/>"+resource.q+"</div>";
                    }
                }
                body += "</div>";    
            }else{
                var body = UniverseUtils.addLine(token,Language.getToken("None"));
            }
        }
        return body;
    },
    
    getPlanetToolTipFacilities : function(element ) {
        if( element.f != null ) {
            return UniverseUtils.addLine("FacilityLevel", element.f);
        }
        return "";
    },
       
    getBattleToolTipBody : function( battle ) {
        var body = UniverseUtils.addLine('Player1',battle.p1);
        if( battle.a1 != ''){
            body += UniverseUtils.addLine('Alliance',"<span class='"+battle.s1+"'>"+battle.a1+"</span>");
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        body += UniverseUtils.addLine('Player2',battle.p2);
        if( battle.a2 != ''){
            body += UniverseUtils.addLine('Alliance',"<span class='"+battle.s2+"'>"+battle.a2+"</span>");
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        return body;
    },
    
    addFleetsToolTip : function() {
        if( fleets ) {
            for( var id in fleets ) {
                var fleet = fleets[id];
                var elem = $(id);
                if( elem != null ) {
                    var body = UniverseUtils.getFleetToolTipBody(fleet);
                    Utils.insertTip(elem, fleet.n, body );
                }
            }
        }
    },
    
    getbeaconInformation : function(planet) {
        var body = UniverseUtils.getPlanetToolTipFacilities(planet);
        body += UniverseUtils.getToolTipResources(planet,"Income");
        body += UniverseUtils.getFleetToolTipUnits(planet,"DefenseFleet");
        return body;
    },
    
    addPlanetToolTip : function() {
        if( planets ) {
            for( var id in planets ) {
                var planet = planets[id];
                var pId = $(id);
                if( pId ) {
                    var body = "";
                    if( planet.o != "") {
                        body += UniverseUtils.addLine('Owner',planet.o);
                    }
                    body += UniverseUtils.addLine('Level',planet.l);               
                    body += UniverseUtils.addLine('Terrain', Language.getToken(planet.pt) );
                    body += UniverseUtils.addLine('Coordinate', planet.c );
                    
                    if( planet.a != ''){
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(planet));
                    }else{
                        body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
                    }
                    
                    body += UniverseUtils.getbeaconInformation(planet);
                    Utils.insertTip(pId, planet.n, body );
                }
            }
        }
    },
    
    addArenaToolTip : function() {
        if( arenas ) {
            for( var id in arenas ) {
                var arena = arenas[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Owner',arena.o);
                    body += UniverseUtils.addLine('IsInBattle',arena.b);
                    body += UniverseUtils.addLine('Coordinate', arena.c );
                    Utils.insertTip(pId, arena.n, body );
                }
            }
        }
    },
    
    addMarketToolTip : function() {
        if( markets ) {
            for( var id in markets  ) {
                var market = markets[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',market.c);
                    body += UniverseUtils.addLine('Level',market.l);
                    body += UniverseUtils.addLine('TradeResource',Language.getToken(market.r));
                    Utils.insertTip(pId, market.n, body );
                }
            }
        }
    },
    
    addWormHoleToolTip : function() {
        if( wormHoles  ) {
            for( var id in wormHoles  ) {
                var wormHole = wormHoles[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',wormHole.c);
                    if( wormHole.o != null ) {
                        body += UniverseUtils.addLine('Owner',wormHole.o);
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(wormHole));
                    }
                    Utils.insertTip(pId, wormHole.n, body );
                }
            }
        }
    },
    
    addBeaconToolTip : function() {
        if( beacons  ) {
            for( var id in beacons  ) {
                var beacon = beacons[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',beacon.c);
                    body += UniverseUtils.addLine('Owner',beacon.o);
                    body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(beacon));
                    Utils.insertTip(pId, beacon.n, body );
                }
            }
        }
    },
    
    addBattleToolTip : function() {
        if( battles ) {
            for( var id in battles ) {
                var battle = battles[id];
                var elem = $(id);
                if( elem != null ) {
                    var body = UniverseUtils.getBattleToolTipBody(battle);
                    Utils.insertTip(elem, battle.n, body );
                }
            }
        }
    },
    
    addAcademyToolTip : function() {
        if( academies  ) {
            for( var id in academies  ) {
                var academy = academies[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',academy.c);
                    body += UniverseUtils.addLine('Level',academy.l);
                    Utils.insertTip(pId, academy.n, body );
                }
            }
        }
    },

    addPirateBayToolTip : function() {
        if( piratebays  ) {
            for( var id in piratebays  ) {
                var piratebay = piratebays[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',piratebay.c);
                    body += UniverseUtils.addLine('Level',piratebay.l);
                    Utils.insertTip(pId, piratebay.n, body );
                }
            }
        }
    },
    
    addRelicToolTip : function() {
        if( relics ) {
            for( var id in relics ) {
                var relic = relics[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Owner',relic.o);
                    body += UniverseUtils.addLine('IsInBattle',relic.b);
                    body += UniverseUtils.addLine('Coordinate', relic.c );
                    if( relic.a != ''){
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(relic));
                    }else{
                        body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
                    }
                    Utils.insertTip(pId, relic.n, body );
                }
            }
        }
    },
    
    removeAllToolTips : function() {
        $$(".tip-top").each( function(element) {
            var parent = element.getParent();
            parent.dispose();
            if( element.tip != null ) {
                element.tip.dispose();
            }
        });
    },
    
/* ============== Universe Menus ============== */

    toggleMoveTo : function(value){
        var moveToButton = $('moveToButton');
        if(moveToButton != null) { 
            moveToButton.disabled = value;
        }
    },
    
    selected : function( td, e ) {
        if( UniverseUtils.sourceSelected == null ) {
            UniverseUtils.noSelected(td,e);
        }else{
            UniverseUtils.oneSelected(td,e);
        }
    },
    
    noSelected :  function( td, e ) {
        var type = td.getAttribute("type");
        if( type == "fleetsector" ) {
            UniverseUtils.toggleMoveTo(false);
            UniverseUtils.renderFleetMenu(td,e);
            return;
        }
        if( type == "planetsector" ) {
            UniverseUtils.renderPlanetMenu(td,e);
            return;
        }
        if( type == "arenasector" ) {
            UniverseUtils.renderArenaMenu(td,e);
            return;
        }
        if( type == "fleetbattlesector" || type == "planetbattlesector" || type == "relicbattlesector" ) {
            UniverseUtils.renderBattleMenu(td,e);
        }
        if( type == "relicsector" ) {
            UniverseUtils.renderRelicMenu(td,e);
        }
        
    },
    
    oneSelected :  function( td, e ) {
        UniverseUtils.toggleMoveTo(true);
        var type = td.getAttribute("type");
        var srcType = UniverseUtils.sourceSelected.getAttribute("type");
        if( type == "fleetsector" || srcType == "fleetsector" ) {
            UniverseUtils.hideFleetMenu(td,e);
            return;
        }
        
        UniverseUtils.hideMenu(td,e);
    },
    
    resetSourceSelected :function() {
        if( UniverseUtils.sourceSelected != null ) {
            UniverseUtils.unselectSector(UniverseUtils.sourceSelected);
            UniverseUtils.sourceSelected = null;
        }
    },
    
    resetDestinySelected :function() {
        if( UniverseUtils.destinySelected != null ) {
            UniverseUtils.unselectSector(UniverseUtils.destinySelected);
            UniverseUtils.destinySelected = null;
        }
    },
    
    resetSelected : function() {
        UniverseUtils.resetSourceSelected();
        UniverseUtils.resetDestinySelected();
        UniverseUtils.hideAllOptions();
    },
    
    hideAllOptions : function() {
        var options = $("optionMenuText");
        if( options != null ) {
            options.getElements("div").each(  function( div ) {
                div.className = "optionHidden";
            });
        }
    },
    
    renderFleetMenu : function (td, e){
        if( fleets ) {
            var fleet = fleets[td.id];
            if( fleet == null ) {
                return;
            }
            if( fleet.cm ) {
                 if( fleet.m ) {
                    UniverseUtils.selectSector(td);
                    UniverseUtils.sourceSelected = td;
                    Menu.showUniverseMenu(e);
                    UniverseEvents.fleetsectorSourceOnMove();
                }else{
                    UniverseUtils.selectSector(td);
                    UniverseUtils.sourceSelected = td;
                }
            }
        }
    },
    
    renderPlanetMenu : function (td, e){
        if( planets ) {
            var planet = planets[td.id];
            if( planet != null ) {
                if( planet.cw ) {
                    UniverseUtils.sourceSelected = td;
                    Menu.showUniverseMenu(e);
                    UniverseEvents.planetsectorSource();
                }
            }
        }    
    },
    
    genericShowMenu : function (td, e, container, eventMethod){
        if( container ) {
            var element = container[td.id];
            if( element != null ) {
               UniverseUtils.sourceSelected = td;
               Menu.showUniverseMenu(e);
               eventMethod();
            }
        }    
    },
    
    renderArenaMenu : function (td, e){
        UniverseUtils.genericShowMenu(td,e,arenas,UniverseEvents.arenasectorSource);
    },
    
    renderRelicMenu : function (td, e){
        UniverseUtils.genericShowMenu(td,e,relics,UniverseEvents.relicsectorSource);
    },
    
    renderBattleMenu : function (td, e){
        if( battles ) {
            var battle = battles[td.id];
            if( battle != null ) {
               UniverseUtils.sourceSelected = td;
               Menu.showUniverseMenu(e);
               UniverseEvents.fleetbattlesectorSource();
            }
        }    
    },
    
    hideFleetMenu : function(td, e) {
        var optionMenu = $('optionMenu');
        var fleet = fleets[td.id];        
        if( td.id == UniverseUtils.sourceSelected.id || !optionMenu.hasClass("hidden") ) {
            optionMenu.addClass("hidden");
            UniverseUtils.resetSelected();
        }else{
            Menu.showUniverseMenu( e );
            UniverseUtils.selectSector(td);
            UniverseUtils.destinySelected = td;
            var key = UniverseUtils.sourceTypeKey();
            UniverseEvents[key]();
        }
    },
    
    hideMenu : function(td, e) {
        Menu.hideUniverseMenu( e );
        UniverseUtils.resetSelected();
    },
    
/* ============== Universe Menus End ============== */
    
    genericCallBack : function() {
    },
    
    updateDestinyAndMove: function() {
        UniverseUtils.updateDestinyAndMove2(UniverseUtils.getDestinyCoordinate(),1)
    },
    
    updateDestinyAndMove2: function( dst,value ) {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        UniverseUtils.updateTTM(fleet,value);
        fleet.m = true;
        fleet.d = dst.replaceAll("_",":");
        UniverseUtils.hideMenu();
        
        var body = UniverseUtils.getFleetToolTipBody(fleet);
        
        Utils.updateTip($(src), body);
    },
    
    updateTTM: function(fleet,value){
        fleet.ttm = 1;
        fleet.tttm = value;
    },
    
    cancelDestinyAndMove: function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        fleet.m = false;
        fleet.d = "";
        UniverseUtils.hideMenu();
        Utils.updateTip($(src), UniverseUtils.getFleetToolTipBody(fleet));
    },
    
    moveEvent : function() {
        UniverseUtils.sendMoveRequest( {Type:'move'} );
        UniverseUtils.updateDestinyAndMove();
    },
    
    moveUndiscoveredEvent: function() {
        Menu.hideUniverseMenu();
        if( Message.raiseConfirm("MoveUndiscovered") ) {   
            UniverseUtils.sendMoveRequest( {Type:'moveundiscovered'} );
            UniverseUtils.updateDestinyAndMove2(UniverseUtils.getDestinyCoordinate(),4);
        }
    },
    
    moveToValid : function() {
        var x = Number($("x").value);
        var y = Number($("y").value);
        var sx = Number($("sx").value);
        var sy = Number($("sy").value);
        
        return Utils.systemCoordinateValid(x) && Utils.systemCoordinateValid(y) && Utils.sectorCoordinateXValid(sx) && Utils.sectorCoordinateYValid(sy);
    },
    
    moveEventWithCoordinates : function() {
        if( UniverseUtils.sourceSelected == null ) {
            RaiseError.needToSelectAFleetFirst();
            return;
        }
    
        if( UniverseUtils.moveToValid() ) {
            var systemDst = $("x").value+"_"+$("y").value;
            var sectorDst= $("sx").value+"_"+$("sy").value;
            UniverseUtils.sendSimpleMoveRequest( {Type:'coordValid',systemDst:systemDst,sectorDst:sectorDst,CallBack:UniverseUtils.moveEventWithCoordinatesCallBack} );
        }else{
            RaiseError.invalidCoordinate();
        }
    },
    
    moveEventWithCoordinatesCallBack : function( responseTree, responseElements, responseHTML, responseJavaScript ) {
        var systemDst = $("x").value+"_"+$("y").value;
        var sectorDst= $("sx").value+"_"+$("sy").value;
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var ttm = 1;
        if( responseHTML == "False" ) {
            if( Message.raiseConfirm("MoveUndiscovered") ) {
                UniverseUtils.sendSimpleMoveRequest( {Type:'moveundiscovered',systemSrc:systemSrc,sectorSrc:sectorSrc,systemDst:systemDst,sectorDst:sectorDst} );
                UniverseUtils.updateDestinyAndMove2(systemDst+"_"+sectorDst,4);
            }
        }else{
            UniverseUtils.sendSimpleMoveRequest( {Type:'move',systemSrc:systemSrc,sectorSrc:sectorSrc,systemDst:systemDst,sectorDst:sectorDst} );
            UniverseUtils.updateDestinyAndMove2(systemDst+"_"+sectorDst,1);
        }
    },
    
    unloadCargoEvent : function() {
       UniverseUtils.sendMoveRequest( {Type:'moveAndUnload'} );
        UniverseUtils.updateDestinyAndMove();
    },
    
    attackEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'attack'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
        
    },
    
    attackPlanetConquerEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'attackPlanet'} )) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    attackPlanetRaidEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'raidPlanet'} )) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    pursuitAttackEvent : function() {
        $('optionMenu').addClass("hidden");
        var fleet = fleets[UniverseUtils.destinySelected.id];
        if( UniverseUtils.sendMoveRequest( {Type:'pursuitandattack', FleetId:fleet.id } ) ){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    cancelEvent: function() {
        $('optionMenu').addClass("hidden");       
        var fleet = fleets[UniverseUtils.getSourceCoordinate()];
        if( UniverseUtils.sendSimpleMoveRequest( {Type:'cancelmove', FleetId:fleet.id } )){
            UniverseUtils.cancelDestinyAndMove();
        }
    },
       
    transportEvent : function() {
        var fleet = fleets[UniverseUtils.getSourceCoordinate()];
        if( fleet.cpw ) {
            var system = UniverseUtils.getDestinySystem();
            var sector = UniverseUtils.getDestinySector();
            UniverseMap.show(system,sector);       
        }else{
            RaiseError.cantPassWormHoles();
        }
    },
    
    conquerEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'conquer'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    challengeEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'arenaChallenge'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    showMarketEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
        
        var fleet = fleets[src];
        var market = markets[dst];
        
        var url =Site.appPath + "SimpleMarket.aspx?Fleet="+fleet.id+"&Market="+market.id;
        
        Utils.createIFrame('simpleMarket', url, 'Market', 921,850);
        
        UniverseUtils.hideMenu();
    },
    
    showAcademyEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        
        var url =Site.appPath + "Academy.aspx?" + UniverseUtils.getFullCoordinateQueryString() + "&Fleet="+fleet.id;
              
        Utils.createIFrame('Academy', url, 'Academy', 921,490);
        
        UniverseUtils.hideMenu();
    },
    
    showPirateBayEvent : function() {
    
        var dst = UniverseUtils.getDestinySystem();
        var sys = dst.split('_');
        var url =Site.appPath + "PirateBay.aspx?sysX="+sys[0]+"&sysY="+sys[1];
        
        Utils.createIFrame('PirateBay', url, 'PirateBay', 921,490);
        
        UniverseUtils.hideMenu();
    },
    
    showArenaEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var arena = arenas[src];
        window.location = Site.appPath + "Arenas/ArenaInfo.aspx?ArenaStorage="+arena.id;
    },
    
    viewBattleEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var battle = battles[src];
        window.location = Site.appPath + "Battle/Battle.aspx?id="+battle.bId;
    },
    
    showRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
        
        var fleet = fleets[src];
        var relic = relics[dst];
        
        var url =Site.appPath + "Relic.aspx?"+ UniverseUtils.getFullCoordinateQueryString();
        
        Utils.createIFrame('relic', url, 'Relic', 921,500);
        
        UniverseUtils.hideMenu();
    },
    
    showRelic2Event : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var relic = relics[src];
        
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var coordinate = "systemSrc="+systemSrc+"&sectorSrc="+sectorSrc;
        
        var url =Site.appPath + "Relic.aspx?"+ coordinate;
        Utils.createIFrame('relic', url, 'Relic', 921,500);
        
        UniverseUtils.hideMenu();
    },
    
    attackRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        if( UniverseUtils.sendMoveRequest( {Type:'attackRelic', FleetId:fleet.id} ) ){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    conquerRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        if(UniverseUtils.sendMoveRequest( {Type:'conquerRelic', FleetId:fleet.id} )){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    useUltimate : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'useUltimate',CallBack:Message.messageCallBack} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
        $("ultimateReady").value = 0;
    },
    
    fireDevastation : function() {
        if( Message.raiseConfirm("DevastationUsageConfirmation") ) {
            if( UniverseUtils.sendMoveRequest( {Type:'fireDevastation',CallBack:Message.messageCallBack} ) ){
                UniverseUtils.hideMenu();
                $("ultimateReady").value = 0;
            }
        }
    },
    
    goToMarketEvent : function() {
       UniverseUtils.moveEvent();
    },
    
    goToAcademyEvent : function() {
       UniverseUtils.moveEvent();
    },
    
    goToPirateBayEvent : function() {
       UniverseUtils.moveEvent();
    },
       
    selectSector : function(elem) {
       UniverseSelection.select(elem);
    },
    
    unselectSector : function(elem) {
       UniverseSelection.unselect(elem);
    },
    
    centerInFleet : function(fleetId) {
        UniverseUtils.sendRequest( {Type:'centerfleet', Fleet: fleetId, CallBack:UniverseUtils.load} );
    },
    
    centerInPlanet : function(planetId) {
        UniverseUtils.sendRequest( {Type:'centerplanet', Planet: planetId, CallBack:UniverseUtils.load} );
    },
    
    centerInCoordinate : function(coord) {
        UniverseUtils.sendRequest( {Type:'centercoordinate', Coordinate: coord, CallBack:UniverseUtils.load} );
    },
    
    zoom1 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 0, CallBack:UniverseUtils.load} );
    },
    
    zoom2 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 1, CallBack:UniverseUtils.load} );
    },
    
    zoom3 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 2, CallBack:UniverseUtils.load} );
    },
    
    zoom4 : function() {
        UniverseUtils.  sendRequest( {Type:'zoom', ZoomLevel: 3,CallBack:UniverseUtils.load} );
    },
    
    showPlanetIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(planets, "Planets");
        UniverseUtils.insertIconInfoTip(tipsInfo,"Planets");
    },
    
    showFleetIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(fleets, "Fleets");
        UniverseUtils.insertIconInfoTip(tipsInfo,"Fleets");
    },
    
    showWormHoleIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(wormHoles, "WormHoles");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
    showArenaIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(arenas, "Arenas");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
     showMarketIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(markets, "Markets");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
    showSmallIcons : function( json, containerName ) {
        UniverseUtils.removeAllToolTips();
        UniverseUtils.removeOlderIcons();
        return UniverseUtils.parseAndShowIcons(json, containerName);
    },
    
    removeOlderIcons : function() {
        $("universeItems").getElements("td").each(function(item){
            if( item.className != "" ) {
                var td = item.getPrevious("td");
                var newItem = new Element("td",{id:item.id});
                if( td != null ) {
                    item.destroy();
                    newItem.inject(td, 'after');
                }else{
                    td = item.getNext("td");
                    item.destroy();
                    newItem.inject(td, 'before');
                }
            }
        });
    },
    
    parseAndShowIcons: function(json, containerName) {
        var tipAgregator = new Hash();
        var owner = $("playerName").value;
        for( var x in json ) {
            var elem = json[x];
            var splitted = x.split('_');
            var sx = Number(splitted[0]);
            var sy = Number(splitted[1]);
            for( var i = 1; i < zoneMapping.length; ++i ) {
                if( elem.on != null && elem.on != owner ) {
                    continue;
                }
                var c = zoneMapping[i];
                
                if( sx >= c[0] && sy >= c[1] && sx <= c[2] &&  sy <= c[3] ) {
                    var id = 's'+i;
                    UniverseUtils.showSmallIcon($(id),json, x, containerName);
                    if( !tipAgregator.has(id) ) {
                        tipAgregator.set(id,[]);
                    }
                    var value = tipAgregator.get(id);
                    value.include(elem);
                    break;
                }
            }
        }
        return tipAgregator;
    },
    
    showSmallIcon : function(elem, json, coord, containerName) {
        if(elem != null && elem.className == ""){
            elem.className = json[coord].uty;
            elem.addEvent('click', function( e ) {
                UniverseUtils.centerInCoordinate(coord);
            });
        }
    },
    
    insertIconInfoTip: function( tipsInfo, titleToken ) {
        tipsInfo.each( function(value,key){
            var title = Language.getToken(titleToken);
            var body = '';
            value.each( function(item){
                body+= "<span class='tipItem'>"+item.n +"</span>: "+ item.c +"<br/>";
            });
            Utils.insertTip($(key),title,body);

        });
    },
    
    insertGenericIconInfoTip: function(tipsInfo){
        tipsInfo.each( function(value,key){
            var title;
            var body = "<span class='tipItem'>"+ Language.getToken('Coordinate') +"</span>: ";
            value.each( function(item){
                title = item.n;
                body+= item.c;
            });
            var elem = $(key);
            if(elem != null){
                Utils.insertTip(elem,title,body);
            }
        });
    }
}

var UniverseMap = {
    show : function(system, sector) {
        $('optionMenu').addClass("hidden");
        
        var isPrivate = UniverseUtils.destinySelected.getAttribute("isprivate");
        if( isPrivate == null ) {
            isPrivate = false;
        }

        var url = "Ajax/Universe/WormHoleMap.ashx?system="+system+"&sector="+sector+"&isPrivate="+isPrivate;
        if( !$("wormHoleMap") ) {
            UniverseMap.addWormHoleMapControl();
        }
        
        Utils.ajaxRequest('get', url, $("wormHoleMap"), UniverseMap.onShow);
    },
    
    onShow : function( responseText, responseXml ) {
        var img = $('wormHoleMap').getElements('img');
        img.addEvent('mouseover', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                if( this.src.indexOf("Private") > 0 ) {
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestPrivateCurrent.png";
                }else{
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestCurrent.png";
                }
            }
        });
        img.addEvent('mouseout', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                if( this.src.indexOf("Private") > 0 ) {
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestPrivate.png";            
                }else{
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallest.png";
                }
            }
        });
        img.addEvent('click', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                var system = this.getAttribute("system");
                var sector = this.getAttribute("sector");
                UniverseMap.onMove(system, sector);
            }
        });
    },
    
    onHide : function() {
    },
    
    onMove : function( system, sector ) {
        UniverseMap.onHide();
        UniverseUtils.sendMoveRequest( {Type:'transport', wormHoleSystemSrc:system, wormHoleSectorSrc:sector } );
        UniverseUtils.updateDestinyAndMove();
        Utils.closeFrame('wormHoleMapWindow');
    },
    
    addWormHoleMapControl : function() {
        //var e = new Element('div', {id: 'wormHoleMap'});
        var style = {};
        var e = "<div id='wormHoleMap'></div>";
        Utils.createFrame( 'wormHoleMapWindow', 'WormHole', e, style , UniverseUtils.resetDestinySelected );
    }
}

var UniverseEvents = {
    eraseElementClass : function(element){
        $(element).className = "";
    },

    showMove : function() {
        UniverseEvents.eraseElementClass("move");
    },
    
    unloadCargo : function() {
        UniverseEvents.eraseElementClass("unloadCargo");
    },
    
    showUndiscoveredMove : function() {
        UniverseEvents.eraseElementClass("moveUndiscovered");
    },
    
    showUltimateReady : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        if( $("ultimateReady").value == '1' && ultimateInfo.r && ( !ultimateInfo.lm || ( ultimateInfo.lm && ultimateInfo.uc.contains(key) ) ) ) {
            UniverseEvents.eraseElementClass("useUltimate");    
        }
    },
    
    showUltimateNormalReady : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        if( $("ultimateReady").value == '1' && ultimateInfo.r && ( !ultimateInfo.lm || ( ultimateInfo.lm && ultimateInfo.uc.contains(key) ) ) ) {
            UniverseEvents.eraseElementClass("useUltimate");    
        }
    },
    
    showTransport : function() {
        UniverseEvents.eraseElementClass("transport");
    },
    
    showAttack : function() {
        UniverseEvents.eraseElementClass("attack");
    },
    
    showPursuitAndAttack : function() {
        UniverseEvents.eraseElementClass("pursuitAndAttack");
    },
    
    showPlanetConquerAttack : function() {
        UniverseEvents.eraseElementClass("attackPlanetConquer");
    },
    
    showPlanetRaidAttack : function() {
        UniverseEvents.eraseElementClass("attackPlanetRaid");
    },
    
    showCancel : function() {
        UniverseEvents.eraseElementClass("cancel");
    },
    
    showChallenge : function() {
        UniverseEvents.eraseElementClass("challenge");
    },
    
    showConquer : function() {
        UniverseEvents.eraseElementClass("conquer");
    },
    
    showPlanetOptions : function(planet) {
        var baseUrl = 'Planets/Default.aspx?id='+planet.id;
        
        $("viewPlanet").getFirst().href= baseUrl;
        UniverseEvents.eraseElementClass("viewPlanet");
        
        $("viewQueue").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Queue/";
        UniverseEvents.eraseElementClass("viewQueue");
        
        if( planet.p){
            $("buildUnits").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Units/";
            UniverseEvents.eraseElementClass("buildUnits");
        }
        
        $("viewFleets").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Fleets/";
        UniverseEvents.eraseElementClass("viewFleets");
        
        $("viewManage").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Manage/";
        UniverseEvents.eraseElementClass("viewManage");
    },
    
    showMarket : function() {
        UniverseEvents.eraseElementClass("market");
    },
    
    showAcademy : function() {
        UniverseEvents.eraseElementClass("academy");
    },
    
    showPirateBay : function() {
        UniverseEvents.eraseElementClass("pirateBay");
    },
    
    showArena : function() {
        UniverseEvents.eraseElementClass("arena");
    },
    
    showToMarket : function() {
        UniverseEvents.eraseElementClass("toMarket");
    },
    
    showToAcademy : function() {
        UniverseEvents.eraseElementClass("toAcademy");
    },
    
    showToPirateBay : function() {
        UniverseEvents.eraseElementClass("toPirateBay");
    },
    
    showBattleLink : function() {
        UniverseEvents.eraseElementClass("viewBattle");
    },
    
    showRelic : function() {
        UniverseEvents.eraseElementClass("showRelic");
    },
    
    showRelic2 : function() {
        UniverseEvents.eraseElementClass("showRelic2");
    },
    
    showAttackRelic : function() {
        UniverseEvents.eraseElementClass("attackRelic");
    },
    
    showConquerRelic : function() {
        UniverseEvents.eraseElementClass("conquerRelic");
    },
    
    showNoOption : function() {
        UniverseEvents.eraseElementClass("noOption");
    },
    
    fleetsectorSourceOnMove : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showCancel();
    },
    
    fleetsectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents[UniverseUtils.destinyTypeKey()]();
    },
    
    planetsectorSource : function() {
        UniverseUtils.hideAllOptions();
        var key = UniverseUtils.getSourceCoordinate();
        var planet = planets[key];
        if( planet.id != 0 ) {
            UniverseEvents.showPlanetOptions(planet);
        }
    },
    
    fleetbattlesectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showBattleLink();
    },
    
    arenasectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showArena();
    },
    
    marketsectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showMarket();
    },
    
    academysectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showAcademy();
    },
    
    pirateBaysectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showPirateBay();
    },
    
    relicsectorSource : function() {
        UniverseUtils.hideAllOptions();
        var key = UniverseUtils.getSourceCoordinate();
        var relic = relics[key];
        var player = $('playerName').value;
        if(player == relic.on){
            UniverseEvents.showRelic2();
        }else{
            UniverseEvents.showNoOption();
        }
    },
    
    fleetsectorDestiny : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        var fleet = fleets[key];
        if( fleet.ca ) {
            if( fleet.m ) {
                UniverseEvents.showPursuitAndAttack();
            }else{
                UniverseEvents.showAttack();
            }
            UniverseEvents.showUltimateReady();
        }else{
            UniverseEvents.showNoOption();
        }
    },
    
    planetsectorDestiny : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        var planet = planets[key];
        
        if( planet.cm ) {
            UniverseEvents.showMove();
            UniverseEvents.unloadCargo();
        }
        
        if( planet.ca ) {
            UniverseEvents.showPlanetConquerAttack();
            UniverseEvents.showPlanetRaidAttack();
            UniverseEvents.showUltimateReady();
        }
        
        if( planet.cc ) {
            UniverseEvents.showConquer();
        }
        
        if( !planet.ca && !planet.cm && !planet.cc ){
            UniverseEvents.showNoOption();
        }
    },
    
    wormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    privatewormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    normalsectorDestiny : function() {
        UniverseEvents.showMove();
        UniverseEvents.showUltimateNormalReady();
    },
    
    undiscoveredsectorDestiny : function() {
        UniverseEvents.showUndiscoveredMove();
    },
    
    resourcesectorDestiny : function() {
        UniverseEvents.showMove();
    },
    
    arenasectorDestiny : function() {
        UniverseEvents.showChallenge();
    },
    
    marketsectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( markets[dst].a.contains(src) ) {
            UniverseEvents.showMarket();
        }else{
            UniverseEvents.showToMarket();
        }
    },
    
    bugswormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    fleetbattlesectorDestiny : function() {
        UniverseEvents.showNoOption();
    },
    
    beaconsectorDestiny : function() {
        UniverseEvents.showNoOption();
    },
    
    academysectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( academies[dst].a.contains(src) ) {
            UniverseEvents.showAcademy();
        }else{
            UniverseEvents.showToAcademy();
        }
    },
    
    piratebaysectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( piratebays[dst].a.contains(src) ) {
            UniverseEvents.showPirateBay();
        }else{
            UniverseEvents.showToPirateBay();
        }
    },
    
    relicsectorDestiny : function() {
        var key = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[key];
        
        if(fleet!= null){
            var key = UniverseUtils.getDestinyCoordinate();
            var relic = relics[key];
            
            if( relic.cc ) {
                UniverseEvents.showConquerRelic();
            }
            
            if( relic.ca ) {
                UniverseEvents.showAttackRelic();
                UniverseEvents.showUltimateReady();
            }
               
            if( relic.on == fleet.on ) {
                UniverseEvents.showRelic();
            }
        }
       
    }
    
}

var UniverseSelection = {
    changeToSelect : function(elem){
        elem.className = elem.className+"Hover";
    },
    
    changeToUnselect : function(elem){
        elem.className = elem.className.replace("Hover","");
    },

    select : function(elem) {
        var type = elem.getAttribute("type");
        UniverseSelection[type+"Select"](elem);
    },
    
    unselect : function(elem) {
        var type = elem.getAttribute("type");
        UniverseSelection[type+"Unselect"](elem);
    },
    
    fleetsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    fleetsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    planetsectorSelect : function(elem){
    
    },
    
    planetsectorUnselect : function(elem){
    
    },
    
    wormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    wormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    privatewormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    privatewormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    normalsectorSelect : function(elem){
    
    },
    
    normalsectorUnselect : function(elem){
    
    },
    
    undiscoveredsectorSelect : function(elem){
    
    },
    
    undiscoveredsectorUnselect : function(elem){
    
    },
    
    resourcesectorSelect : function(elem){
    
    },
    
    resourcesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    arenasectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    arenasectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    marketsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    marketsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    fleetbattlesectorSelect : function(elem){
    
    },
    
    fleetbattlesectorUnselect : function(elem){
    
    },
    
    bugswormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    bugswormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    beaconsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    beaconsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    academysectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    academysectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    piratebaysectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    piratebaysectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    relicsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    relicsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    }
}

var UniverseDirection = {

    b : function() {
    },

    addEvents : function( element ) {
        element.addEvent('click', function( e ) {
            var code = this.getAttribute("code");
            UniverseDirection.updateUniverse(e,code);
        });
        element.addEvent('mouseout', function( e ) {
            this.removeClass('selected');
        });
		element.addEvent('mouseover', function( e ) {
		    this.addClass('selected');
		});
    },
    
    load : function() {
        var v = $("uab");
        if( v ) {
            UniverseDirection.addEvents($("uab"));
            UniverseDirection.addEvents($("uad"));
            UniverseDirection.addEvents($("uae"));
            UniverseDirection.addEvents($("uag"));
        }
    },
    
    updateUniverse : function(e,code) {
        UniverseUtils.sendRequest( {Type:'movemap', Code:code, CallBack:UniverseUtils.load} );
    },
    
    onUpdateUniverseCallBack : function() {
        UniverseUtils.load();
    }
}

window.addEvent('domready', function() {
	if( $("universe") ) {
		UniverseUtils.load();
	}
});
