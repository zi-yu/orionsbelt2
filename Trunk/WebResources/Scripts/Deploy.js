

var lastSelection;

var Positioning = {
	start : function() {
		if( $("isSpectator").value == 0 ) { 
			Positioning.initTDElements();
			Positioning.initBottomElements();
			$('reset').addEvent('click', function( e ) {PositioningReset.reset(this);});
			$('submit').addEvent('click', function( e ) {Positioning.submit();});
		}
	},
	
	initTDElements : function(  ) {
		Utils.getTdElements().each( function( td ) {
			td.addEvent('click', function( e ) {Positioning.selected(this,e);});
			td.addEvent('mouseout', function( e ) {Utils.canMoveOut();});
			td.addEvent('mouseover', function( e ) {Utils.canMoveOverPositioning( this.id, e ) ;});
		});
	},
	
	initBottomElements : function(  ) {
		Positioning.getBottomElements().each( function( td ) {
			if( !td.hasClass("initialBottomIgnore") ) {
				td.addEvent('click', function( e ) {Positioning.selected(this);});
				td.addEvent('mouseout', function( e ) {
					if( lastSelection != null && this.getFirst().get('tag') == "span" ) {
						if( lastSelection.getImageName() == td.id ) {
							this.className = "unitOpacity";
						}
					}
				});
				td.addEvent('mouseover', function( e ) {
					if( lastSelection != null && this.getFirst().get('tag') == "span" ) {
						if( lastSelection.getImageName() == td.id ) {
							this.className = "unitOpacityOver";
						}
					}
				});
				
				td.setStyle("background-image","url("+$("imagePath").value+"/Units/"+td.id.toLowerCase()+".png)");
				td.setStyle("background-repeat","no-repeat");
			}
		});
	},
	
	submit : function() {
		if( Positioning.hasPositioned() ) {
			var moves = $('movesMade');
			$("submit").disabled = true;
			Positioning.gatherUnits(moves);
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=deploy&id="+battleId+"&moves="+moves.value;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Positioning.submitCallBack);
		}
	},
	
	gatherUnits : function( moves ) {
	    if( Utils.numberOfPlayers() == 2 ) {
			Positioning.setUnits2(moves);
		}else{
			Positioning.setUnits4(moves);
		}
	},
	
	setUnits2 : function( moves ) {
		for( var i = 1; i < 9; ++i ) {
			Positioning.addMove( moves, "7_"+i );
			Positioning.addMove( moves, "8_"+i );
		}
	},
	
	setUnits4 : function( moves ) {
		for( var i = 3; i < 11; ++i ) {
			Positioning.addMove( moves, "11_"+i );
			Positioning.addMove( moves, "12_"+i );
		}
	},
	
	submitCallBack : function() {
		window.location = window.location;
	},
	
	addMove: function( moves, coord ) {
		var item = Utils.getItem( $(coord) );
		if( item.hasChildNodes() ) {
			var unit = Unit[item.unitName().toLowerCase()];
			var quant = item.getQuantity();
			moves.value += "p:"+unit.code+"-"+coord+"-"+quant+";";
		} 
	},
	
	hasPositioned : function() {
		var found = false;
		var result = "";
		Positioning.getBottomElements().each( function( td ) {
			if( Utils.hasChilds(td) ) {
				if( td.className != "initialBottomIgnore" ) {
					var item = Utils.getItem(td);
					var unitName = item.unitName();
					result += unitName + " " + item.getQuantity() + "\n";
					found = true;
				}
			}
		});
		if( found ) {
			RaiseError.unitsNotPositioned(result);
		}
		return !found;
	},
	
	selected : function( element, event ) {
		if( Utils.numberOfPlayers() != 2 && !Utils.coordinateValid(element.id) ) {
			return;
		}
		var selectedElement = Utils.getItem( element );
		if( lastSelection == null ) {
			Positioning.noneSelected( selectedElement );
		} else {
		    
			if( Positioning.sameSector(selectedElement) ) {
				Positioning.cleanSelected();
				return;
			}		
			Positioning.oneSelected(selectedElement, event);
		}
	},
	
	noneSelected : function( selectedElement ){
		if( !selectedElement.hasChildNodes() ) {
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
		Tutorial.advance();
	},
	
	oneSelected : function( selectedElement, event ){
		if( Utils.canMoveOverPositioning(selectedElement.id, event ) ) {
			var quant = lastSelection.getQuantity();
			var quantitySelected = Utils.getQuantity();
			
			if( quantitySelected <= quant && quantitySelected > 0 ) {
				var quantRest = quant - quantitySelected;
				
				if( !selectedElement.hasChildNodes() ) {
					selectedElement.removeAll();
				}
				selectedElement.insert( lastSelection, quantitySelected, event );
				selectedElement.node.item = selectedElement;
				
				if( quantRest > 0 ) {
					lastSelection.setQuantity( quantRest );
				}else{
					lastSelection.removeAll();
					lastSelection.node.item = null;
				}
						
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
		}
	},
	
	sameSector : function( selectedElement ){
		return lastSelection.id == selectedElement.id;
	},
	
	cleanSelected : function() {
		if( lastSelection != null ) {
			var empty = "";
			lastSelection.setClass(empty);
			lastSelection = null;
			Utils.getQuantityElement().value = empty;
			Information.fill("minquantity",empty);
			Information.fill("maxquantity",empty);
		}
	},
	
	getBottomElements : function() {
		if( Utils.numberOfPlayers() == 2 ) {
			return $('initialBottom').getElements('td');
		}
		return $('initialBottom4').getElements('td');
	},
	
	saveDeploy : function() {
	    if( Positioning.hasPositioned() ) {
	        var key = $('tournamentId').value + $('currentUser').value;
	        var moves = $('movesMade');
	        Positioning.gatherUnits(moves);
	        Cookie.dispose(key);
	        Cookie.write(key, encodeURI(moves.value) );
	        moves.value = "";
	        RaiseError.deploySaved();
	    }
	},
	
	loadDeploy : function() {
	    var key = $('tournamentId').value + $('currentUser').value;
	    var cookie = decodeURI(Cookie.read(key));
	    if( cookie != "null" && cookie != "" ) {
	        Positioning.cleanBottom();
	        Positioning.clearBoard();
	        var elements = cookie.split(';');
	        for( var e = 0; e < elements.length; ++e ) {
	            var curr = elements[e];
	            if( curr != "" ) {
	                var u = curr.split(':')[1].split('-');
	                var coord = $(u[1]);
                    var img = Positioning.createUnitImage(u[0], u[2])
			        coord.empty();
			        img.inject(coord);
			    }
	        }
	        RaiseError.deployLoaded();
	    }else{
	        RaiseError.noDeploySaved();
	    }
	},
	
	emptyField : function(td) {
	    td.empty();
		td.appendChild( new Element('span') );
	},
	
	createUnitImage : function( type, quant) {
	    var unit = Unit[type]();
	    
	    var img = new Element("img");
	    img.src = $('imagePath').value+"/Units/"+unit.name.toLowerCase()+".png";
	    img.title = quant;
	    img.alt = unit.name.toLowerCase();
	    
	    return img;
	},
	
	cleanBottom : function() {
	    $('initialBottom').getElements('td').each( function(td){
	        if( !td.hasClass('initialBottomIgnore')) {
	            Positioning.emptyField(td);
	            td.className = 'unitOpacity';
	        }
	    });
	},
	
	clearBoard: function(){
	    for( var x = 1; x <= 8; ++x ) {
	        Positioning.emptyField($("7_"+x));
	        Positioning.emptyField($("8_"+x));
	    }
	}
}