
var Information = {

    fixed : false,
    leftInfofixed : false, 

	fillAll : function( selectedElement ) {
	
	    var idl = selectedElement.unitName();
		var unit = selectedElement.unit();
		var quant = selectedElement.getQuantity();
		
		if($("battleCalculator") && !Information.fixed ) {
		    Information.fillCalculator( unit, quant, unit.range );
		}
	
	    if( !this.fillEnabled() || Information.leftInfofixed ) {
	        return;
	    }
			
		Information.fill( "shipType",unit.name );
		Information.fill( "baseAttack",unit.baseAttack );
		Information.fill( "baseDefense",unit.baseDefense );
		Information.fill( "movementCost",unit.movementCost );
		Information.fill( "range",unit.range );
		Information.fillRemainDefense(selectedElement, unit);
		if(unit.category == 'Ultimate'){
		    Information.fill( "unitQuant", 1 );
		}else{
		    Information.fill( "unitQuant", quant );
		}
	    if( Utils.numberOfPlayers() == 2 ) {
		    Information.fillSpecials( selectedElement, unit );
		    Information.fillStrongAgainst( unit );
		    Information.fillWeakerAgainst( unit );
		    HowTo.resolveHowToMove( unit );
		    HowTo.resolveHowToAttack( unit );
		}
	},
	
	fillRemainDefense : function(selectedElement, unit) {
        var json = BattleElements[selectedElement.id];
	    if( json != null ) {
	        Information.fill( "hitPoints", json.remainingDefense );
	    }else{
    		Information.fill( "hitPoints", unit.baseDefense );
        }
	},
	
	fillByElement : function( selectedElement ) {
	    if(!this.fillEnabled()) {
	        return;
	    }
		if( Utils.hasChilds(selectedElement) ) {
			Information.fillAll(Utils.getItem(selectedElement));
		}
	},
		
	fill : function( id, value ) {
		var elem = $(id);
		if( elem != null ) {
		    if( elem.hasChildNodes() ) {
			    elem.empty();
		    }
		    elem.appendText(value);
		}
	},
	
	fillEnabled : function () {
	    return $("leftBattleMenu") != null;
	},
	
	fillSpecials : function( selectedElement, unit ) {
		var elem = $("specials");
		if( elem != null && elem.hasChildNodes() ) {
			elem.empty();
		}
		
		if( selectedElement.hasAttacked ) {
			Information.insertIcon( elem, "cantAttack");
		}else{
			Information.insertIcon( elem, "attack");
		}
		
		Information.fillAbilities(elem, unit);
	},
	
	fillAbilities : function(elem, unit) {
	    if( unit.strikeBack ) {
			Information.insertIcon( elem, "strikeBack");
		}
		
		if( unit.catapult ) {
			Information.insertIcon( elem, "catapult");
		}
		
		if( unit.triple ) {
			Information.insertIcon( elem, "triple");
		}
		
		if( unit.replicator ) {
			Information.insertIcon( elem, "replicator");
		}
		
		if( unit.rebound ) {
			Information.insertIcon( elem, "rebound");
		}
		
		if( unit.removeAbility ) {
			Information.insertIcon( elem, "removeAbility");
		}
		
		if( unit.bomb ) {
			Information.insertIcon( elem, "bomb");
		}
		
		if( unit.infestation ) {
			Information.insertIcon( elem, "infestation");
		}
		
		if( unit.paralyse ) {
			Information.insertIcon( elem, "paralyse");
		}
	},
	
	fillAttackInfo : function( parentID, targetID ) {
		var image = $( parentID[0] + "_" + parentID[1] ).firstChild;
			
		var srcUnit = lastSelection.unit();
		var terrain = boardInformation.terrain;
		var quant = Number(lastSelection.getQuantity());
		
		var target = Utils.getItem($(targetID[0] + "_" + targetID[1]));
		var targetUnit = target.unit();
		var tquant = target.getQuantity();
		
		var attack = quant*srcUnit.getAttack(targetUnit,terrain);
		attack = AttackUtils.calculatePenalty(Math.round(attack),parentID,targetID);
		var d = attack/targetUnit.getDefense(srcUnit,terrain) - 0.5;
				
		Information.fill( "damage", Math.round(d) );
	},
	
	eraseAttackInfo : function() {
		Information.fill( "damage", "" );
	},
	
	insertIcon : function( elem, name ) {
	    if( elem == null ) {
	        return;
	    }
	    var icon = $("imagePath").value + "/Icons/"+name+".gif";
		var img = new Element("img",{'src':icon,"alt":"","title":""});
		elem.appendChild(img);
	},
	
	fillStrongAgainst : function( unit ) {
	    var elements = Information.getStrongElements( unit );
	    var weakerUnits = Information.findWeakerUnits(elements);
	    Information.renderImages(weakerUnits, 'strongAgainst');
	},
	
	fillWeakerAgainst : function( unit ) {
	    var elements = [ unit.level, unit.type, unit.category ];
	    var strongUnits = Information.findStrongerUnits(elements);
	    Information.renderImages(strongUnits, 'weakerAgainst');
	},
	
	findWeakerUnits : function( elements ) {
	    var weakerUnits = [];
	    var possibleTypes = ['level','type','category'];
	    boardInformation.enemyUnits.each( function(unitName, index){
            possibleTypes.each(
                function(item, index){
                    var elem = Unit[unitName][item];
                    if( elements.contains(elem) ){
                        weakerUnits.include(unitName)
                    }
                }	
            ); 
	    });
	    return weakerUnits;
	},
	
	findStrongerUnits : function( elements ) {
	    var strongerUnits = [];
	    boardInformation.enemyUnits.each( function(unitName, index){
            for( var target in Unit[unitName].attackTargets ) {
                if( elements.contains(target) ){
                    strongerUnits.include(unitName)
                    break;
                } 
            }
	    });
	    return strongerUnits;
	},
	
	getStrongElements : function( unit ) {
	    var elements = [];
	    for( var propName in unit.attackTargets ) {
	        elements.include(propName);
	    }
	    return elements;
	},
	
	renderImages : function( weakerUnits, targetElement ) {
	    var container = $(targetElement);
	    container.empty();
	    weakerUnits.each( function(item, index){
	        Information.renderUnitImage(item, container);
	    });
	},
	
	renderUnitImage : function( item, container ){
	    var unitName = Unit[item].name;
	    var imgsPath = $("imagePath").value;
	    var imgSrc = imgsPath + "/Units/" + unitName.toLowerCase() + '.png';
        
        var elem = new Element('img', {'src': imgSrc,'title': name,'alt': name,'class':'unitSmall'});
        
        var manual = "../Manual.aspx?path=Unit/"+unitName+".aspx";
        var anchor = new Element('a', {'href': manual});
        
        anchor.adopt(elem);
        container.adopt(anchor);
	},
	
	renderUnitImageForManual : function( item, container ){
	    var unitName = Unit[item].name;
	    var imgsPath = $("imagePath").value;
	    var imgSrc = imgsPath + "/Units/" + unitName.toLowerCase() + '.png';
        
        var elem = new Element('img', {'src': imgSrc,'title': name,'alt': name,'class':'unitSmall'});
        
        var manual = "../Manual.aspx?path=Unit/"+unitName+".aspx";
        var anchor = new Element('a', {'href': manual});
        
        anchor.adopt(elem);
        container.adopt(anchor);
	},
	
	renderImage : function( name, container, extention, path ){
	    var imgsPath = $("imagePath").value;
	    if( path.length == 0 ) {
	        path = '/'
	    }else{
	        path = '/'+path+'/';
	    }
	    var imgSrc = imgsPath + path + name.toLowerCase() + '.' + extention;
        var elem = new Element('img', {'src': imgSrc,'title': name,'class':'unitSmall'});
        container.adopt(elem);
	},
	
	fillCalculator : function( unit, quant, range ) {
	    if( range < 0 || range > unit.range ) {
	        range = unit.range;
	    }
	    var elem = $('elementSelectedImg');
	    elem.empty();
	    Information.renderImage(unit.name, elem, 'png', 'Units');
	    $('elementSelectedQuantInput').value = quant;
	    $("elementSelectedRangeInput").value = range;
	    	    
	    $('enemyElements').getElements('div').each(function(item){
	        var children = item.childNodes;
	        if( children.length == 2 ) {
	            Information.fillElementDestroyed(children, item, unit, quant, range);
	        }
	    });
    },
    
    fillElementDestroyed : function( children, item, unit, quant, range ) {
        var type = children[0].getAttribute('type');
        var target = Unit[type];
        var attack = unit.getAttack(target,boardInformation.terrain)*quant;
        var defense = target.getDefense(unit, boardInformation.terrain);
        
        attack = AttackUtils.calculatePenaltyByDistance(Math.round(attack),range);
        var a = Math.round((attack/defense)-0.5);
	    
        var div = children[1];
        div.empty();
        if( a > 10000 ) {
            div.appendText('9999+');
        }else{
            div.appendText(a)
        }
    },
    
    getCalculatorSelectElementUnit : function() {
        var unitName = $("elementSelectedImg").getFirst().getAttribute("title").toLowerCase();    
        return Unit[unitName];
    }, 
    
    fillCalculatorEvent : function(input, e) {
        e.stop();
        var quant = parseInt(input.value);
        var range = $("elementSelectedRangeInput").value;
	    var length = input.value.length;
	    if( isNaN(quant) || length > 4 ){
	       Information.eraseLastChar(input, length);
	    }else{
	        if( length != 0 ) {
                var unit = Information.getCalculatorSelectElementUnit();
                Information.fillCalculator(unit,quant,range);
            }
        }
	},
	
	fillCalculatorRangeEvent : function(input, e) {
	    e.stop();
	    var quant = $("elementSelectedQuantInput").value;
	    var range = parseInt(input.value);
	    var length = input.value.length;
	    if( isNaN(range) || length > 1 ){
	       Information.eraseLastChar(input, length);
	    }else{
	        if( length != 0 ) {
                var unit = Information.getCalculatorSelectElementUnit();
                Information.fillCalculator(unit,quant,range);
            }
        }
	},
	
	eraseLastChar : function(input, length) {
	    if( length != 0 ) {
	        input.value = input.value.substring(0,length-1);
	    }
	}
}

var HowTo = {

    moveImg : 'arrow',
    attackImg : 'enemy',
    dummyUnit : 'rain',

    renderCenter : function(unitName, elemName){
        var elem = $(elemName);
        elem.empty();
        Information.renderUnitImage(unitName, elem, 'Units');
    },
    
    renderGifImage : function( item, elemName ){
	    Information.renderImage(item, $(elemName), 'gif', 'Battle' );
	}, 
		
	front : function(ext) {
        HowTo.renderGifImage(HowTo.moveImg, ext+'b');
    },
    
    clearAll : function(ext) {
        $(ext+'a').empty();
        $(ext+'b').empty();
        $(ext+'c').empty();
        $(ext+'d').empty();
        $(ext+'e').empty();
        $(ext+'f').empty();
        $(ext+'g').empty();
        $(ext+'h').empty();
    },
    
    none : function(ext) {
    },
    
    drop : function(ext) {
    },
    
    all : function(ext) {
        HowTo.renderGifImage(HowTo.moveImg, ext+'a');
        HowTo.renderGifImage(HowTo.moveImg, ext+'b');
        HowTo.renderGifImage(HowTo.moveImg, ext+'c');
        HowTo.renderGifImage(HowTo.moveImg, ext+'d');
        HowTo.renderGifImage(HowTo.moveImg, ext+'e');
        HowTo.renderGifImage(HowTo.moveImg, ext+'f');
        HowTo.renderGifImage(HowTo.moveImg, ext+'g');
        HowTo.renderGifImage(HowTo.moveImg, ext+'h');
    },
    
    diagonal : function(ext) {
        HowTo.renderGifImage(HowTo.moveImg, ext+'a');
        HowTo.renderGifImage(HowTo.moveImg, ext+'c');
        HowTo.renderGifImage(HowTo.moveImg, ext+'f');
        HowTo.renderGifImage(HowTo.moveImg, ext+'h');
    },
    
    normal : function(ext) {
        HowTo.renderGifImage(HowTo.moveImg, ext+'b');
        HowTo.renderGifImage(HowTo.moveImg, ext+'d');
        HowTo.renderGifImage(HowTo.moveImg, ext+'e');
        HowTo.renderGifImage(HowTo.moveImg, ext+'g');
    },
    
    resolveHowToMove : function(unit){
        HowTo.clearAll('hm');
        HowTo.renderCenter(unit.name.toLowerCase(),'hmcenter');
        HowTo[unit.movementType]('hm');
    },
    
    resolveHowToAttack : function(unit){
        HowTo.clearAll('ha');
        HowTo.renderCenter(unit.name.toLowerCase(),'hag');
        if( unit.canAttack ) {
            if( unit.range == 1 ) {
                $('hacenter').empty();
                HowTo.renderGifImage(HowTo.attackImg, 'hacenter');
            }else{
                HowTo.renderGifImage(HowTo.attackImg, 'hab');
                HowTo.renderDummyUnit( unit.catapult );
            }
        }
    },
    
    renderDummyUnit : function( catapult ) {
        if( catapult ){
            HowTo.renderCenter(HowTo.dummyUnit,'hacenter');
        }else{
            $('hacenter').empty();
        }
    }
}
