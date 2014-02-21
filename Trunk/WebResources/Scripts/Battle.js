var lastSelection;
var blinkSelection;

var Battle = {

    isSpectator: function() {
        var isSpectator = $("isSpectator");
        if( isSpectator == null ) {
            return true;
        }
        return isSpectator.value != 0
    },
    
	start : function() {
		if( !Battle.isSpectator() ) { 
			Battle.initTDElements();
		}
		Utils.initSpecialMoveImages(true);
	},
	
	initTDElements : function(  ) {
		Utils.getTdElements().each( function( td ) {
		    Battle.initTd(td);
		});
		Battle.initUltimateUnits();
		var v = $('reset');
		if( v ) {
			v.addEvent('click', function( e ) {undo.reset();});
			$('undo').addEvent('click', function( e ) {undo.undo();});
			$('submit').addEvent('click', function( e ) {Battle.submit();});
		}
		v = $('giveUp');
		if( v ) {
			v.addEvent('click', function( e ) {Battle.giveUp();});
		}
		if($("battleCalculator") ) {
		    $("elementSelectedQuantInput").addEvent('keyup', function( e ) {Information.fillCalculatorEvent(this, e);});
		    $("elementSelectedRangeInput").addEvent('keyup', function( e ) {Information.fillCalculatorRangeEvent(this, e);});
		}
		$("b").addEvent('click', function( e ) {Battle.setPosition("n");});
		$("d").addEvent('click', function( e ) {Battle.setPosition("w");});
		$("e").addEvent('click', function( e ) {Battle.setPosition("e");});
		$("g").addEvent('click', function( e ) {Battle.setPosition("s");});
		
	},
	
	initTd : function(td){
	    td.addEvent('click', function( e ) {Battle.selected(this,e);});
		td.addEvent('mouseout', function( e ) {Utils.canMoveOut();});
		td.addEvent('mouseover', function( e ) {
			var item = Utils.getItem(this);
			Utils.canMoveOver( item, e ) ;
		});
	},
	
	initUltimateUnits : function() {
	    if( Utils.numberOfPlayers() == 2 ) {
	        var enemyUN = $('0_0');
	        if( enemyUN ) {
	            Battle.initTd(enemyUN);
	        }
	        enemyUN = $('9_9');
	        if( enemyUN ) {
	            Battle.initTd(enemyUN);
	        }
	    }
	},
	
	initialChecksOk : function(selectedElement) {
		if( selectedElement.isEnemyUnit() || selectedElement.isFriendlyUnit() ) {
			return false;
		}
		
		if( selectedElement.checkEffects() ) {
			return false;
		}
		
		if( $("moves").innerHTML == 0 ) {
			if( lastSelection != null ) {
				Utils.resetSelection(null);
			}
			return false;
		}
		
		if( selectedElement.hasAttacked ) {
			RaiseError.alreadyAttacked();
			return false;
		}
		
		return true;
	},
	
	selected : function( element, event ) {
		var selectedElement = Utils.getItem( element );
		
		if( !Battle.isBlinkerSelected() && !Battle.initialChecksOk(selectedElement) ) {
			return;
		}
		
		if( lastSelection == null ) {
			Battle.noneSelected( selectedElement );
		} else {
			if( Battle.sameSector(selectedElement) ) {
				Battle.clearSelected();
				Information.fixed = false;
				return;
			}			
			Battle.oneSelected(selectedElement, event);
		}
	},
	
	isBlinkerSelected : function() {
	    return blinkSelection != null || ( lastSelection != null && lastSelection.isBlinker() );
	},
	
	blinkerInRange : function(selectedElement){
	    if( Battle.isBlinkerSelected() ) {
	        return selectedElement.x() > 4;
	    }
	    return true;
	},
	
	noneSelected : function( selectedElement ){
		if( !selectedElement.hasChildNodes() ) {
			return;
		}
		if( Battle.hasCoolDown(selectedElement) || !Battle.blinkerInRange(selectedElement) ) {
		    return;
		}
		
		selectedElement.setClass("selectedSector");
		var quant = selectedElement.getQuantity();
		var quantity = $("quantity");
		quantity.value = quant;
		quantity.focus();
		
		min = Math.round( 0.5 + (Number(quant) * 0.2) );
		
		Information.fill( "minquantity", min);
		Information.fill( "maxquantity", quant - min)
		Information.fillAll( selectedElement );
		
		lastSelection = selectedElement;
		Information.fixed = true;
		Tutorial.advance();
	},
	
	hasCoolDown : function(selectedElement) {
	    if( BattleElements ) {
		    var json = BattleElements[selectedElement.id];
	        if( json != null && json.coolDown > 0 ) {
	            RaiseError.coolDown();
	            return true;
	        }
	    }
	    return false;
	},
	
	setPosition : function( pos ) {
		if(lastSelection != null && lastSelection.getPosition() != pos && movesObj.hasMoves(1) ) {
			var oldPos = lastSelection.getPosition();
			lastSelection.setPosition( pos );
			Utils.registerRotation( lastSelection, oldPos, pos );			
			movesObj.decrementMoves( 1 );
			
			if( !movesObj.silentHasMoves(1) ) {
				Utils.resetSelection(null);
			}
		}
	},
	
	oneSelected : function( selectedElement, event ){
	    Information.fixed = false;
		var cost = Battle.getCost();
				
		if( movesObj.hasMoves( cost ) ) {
		    if( lastSelection.isQueen() ) {
		        Battle.insertEgg(selectedElement,cost,event);
		        return;
		    }
		    if( blinkSelection != null || lastSelection.isBlinker() ) {
		        Battle.blinkSelected(selectedElement, cost, event)
		    }else{
		        if( Utils.canMoveOver(selectedElement, event ) ) {
			        Battle.moveUnit( selectedElement, cost, event );
		        }
		    }
		}
	},
	
	blinkSelected : function(selectedElement, cost, event) {
	    if( blinkSelection == null ) {
            blinkSelection = lastSelection;
            lastSelection = null;
            Battle.noneSelected(selectedElement);
        }else{
            if( selectedElement.id != blinkSelection.id && Battle.blinkerInRange(selectedElement) ){
                Battle.moveUnit(selectedElement, cost, event);
                Battle.clearBlinkSelected();
            }
        }
	},
	
	insertEgg : function(selectedElement, event) {
	    selectedElement.insertSpecific( Unit["egg"], 1);
	    selectedElement.node.item = selectedElement;
	    
	    if( !selectedElement.hasChildNodes() ) {
			selectedElement.removeAll();
		}
			
	    movesObj.decrementMoves(Unit["queen"].movementCost);
		Utils.registerEgg(selectedElement);
	    lastSelection.setClass("");
		lastSelection = null;
	},
	
	getCost : function() {
	    if( blinkSelection != null ) {
		    return blinkSelection.movementCost();
		}
		return lastSelection.movementCost();
	},
    	
	moveUnit : function( selectedElement, cost, event ){
		var quant = lastSelection.getQuantity();
		var position = lastSelection.getPosition();
		var quantitySelected = Utils.getQuantity();
			
		if( quantitySelected <= quant && quantitySelected > 0 ) {
			var quantRest = quant - quantitySelected;
			
			if( quantRest > 0 ) {
				cost *= 2;
				if( !movesObj.hasMoves( cost ) ) {
					RaiseError.noMovesToSplit(cost);
					return;
				}
			}
			
			if( !Battle.quantityValueCheck(quantRest,quant,quantitySelected)) {
				return;
			}
			
			if( !selectedElement.hasChildNodes() ) {
				selectedElement.removeAll();
			}
			
			selectedElement.insert( lastSelection, quantitySelected, event );
			selectedElement.node.item = selectedElement;
			
			BattleElements[selectedElement.id] = BattleElements[lastSelection.id];
			Utils.updateSpecialEffectsImages(lastSelection,selectedElement);
			
			if( quantRest > 0 ) {
				lastSelection.setQuantity( quantRest );
			}else{
				lastSelection.removeAll();
				lastSelection.node.item = null;
				delete BattleElements[lastSelection.id];
			}
			
			movesObj.decrementMoves(cost);
			Battle.registerMovement(lastSelection,selectedElement,quantitySelected,position);
			
			if( lastSelection.isSource() && quantRest == 0) {
				lastSelection.setClass("unitOpacity");
			}else{
			    lastSelection.setClass("");
			}
			lastSelection = null;
			Tutorial.advance();
		}else{
			RaiseError.invalidQuantity();
		}
	},
	
	registerMovement : function(lastSelection,selectedElement,quantitySelected,position) {
	    if( blinkSelection != null ) {    
	        Utils.registerBlink(lastSelection,selectedElement,quantitySelected,position);
	    }else{
	        Utils.registerMove(lastSelection,selectedElement,quantitySelected,position);
	    }
	},
	
	quantityValueCheck : function(quantRest,quant,quantitySelected) {
		var minRest = Math.round( 0.5+(quant*0.2) );
		
		if( quantitySelected < minRest ) {
			RaiseError.minimumMove(quantitySelected,lastSelection.unitName(),minRest);
			return false;
		}
		
		if( quantRest < minRest && quantRest != 0 ) {
			RaiseError.minimumRest(quantRest,lastSelection.unitName(),minRest);
			return false;
		}
		return true;
	},
	
	submit : function() {
		var answer = Message.raiseConfirm("EndTurn");
		if( answer ) {
			var moves = $("movesMade");
			$("submit").disabled = true;
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=battle&id="+battleId+"&moves="+moves.value;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Battle.submitCallBack);
		}
	},
	
	submitCallBack : function() {
		$('movesMade').value = "";
		FillInformation.start();
	},
	
	giveUp: function() {
		var answer = Message.raiseConfirm("GiveUp");
		if( answer ) {
			$("giveUp").disabled = true;
			$("submit").disabled = true;
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=giveUp&id="+battleId;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Battle.giveUpCallBack);
		}
	},
	
	giveUpCallBack : function() {
	    Cookie.dispose('HasBattles');
		Cookie.dispose('HasUniverseBattles');
	},
	
	getAllMessages : function() {
		var battleId = Utils.queryString("id")
		var url = "../Ajax/Battle/BattleMessages.ashx?id="+battleId;
		
		Utils.ajaxRequest('get', url, $('messages'), Battle.getAllMessagesCallBack);
	},
	
	getAllMessagesCallBack : function() {
	},
		
	sameSector : function( selectedElement ){
		return lastSelection != null && lastSelection.id == selectedElement.id;
	},
	
	clearSelected : function() {
		if( lastSelection != null ) {
			var empty = "";
			lastSelection.setClass("");
			lastSelection = null;
			Utils.getQuantityElement().value = empty;
			Information.fill("minquantity",empty);
			Information.fill("maxquantity",empty);
			Battle.clearBlinkSelected();
		}
	},
	
	clearBlinkSelected : function() {
		if( blinkSelection != null ) {
	        blinkSelection.setClass("");
            blinkSelection = null;
		}
	},
	
	canMove : function canMove(dst) {
		var src = lastSelection.id.split("_");
		
		var id = lastSelection.getChildId().toLowerCase().split("_");
			
		var movType = Unit[id[0]].movementType;
		if( movType == "") {
			return false;
		}
		return movesObj[movType](src,dst);
	}
}
