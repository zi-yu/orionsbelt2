
var Manual = {

    init : function() {
        UniverseUtils.removeAllToolTips();
        Manual.addTooltips();
    },
    
    addTooltips : function() {
        var tips = window.unitTips;
        var parent = $("contentPanel");
        log.info("Parent: " + parent);
        if( tips ) {
            for( var unitName in Unit ) {
                var elems = parent.getElements("." + unitName);
                for( var i = 0; i < elems.length; ++i ) {
                    var elem = elems[i];
                    log.debug(unitName + " -> " + elem);
                    if( elem != null ) {
                        var unit = Unit[unitName];
                        var tip = tips[unit.name];
                        
                        if( tip == null ) {
                            log.debug("No tip for: " + unit.name);
                            continue;
                        }
                        
                        var body = "<img src='" + $("imagePath").value + "/Units/" + unit.name.toLowerCase() + ".png' />";
                        body += "<ul>";
                        body += "<li>" + tips["Attack"] + " : " + unit.baseAttack + "</li>";
                        body += "<li>" + tips["Defense"] + " : " + unit.baseDefense + "</li>";
                        body += "<li>" + tips["Range"] + " : " + unit.range + "</li>";
                        body += "<li>" + tips["MovementCost"] + " : " + unit.movementCost + "</li>";
                        body += "</ul>";
                        
                        body = Manual.addAbilities(body, unit);
                        
                        Utils.insertTip(elem, tip.Name, body );
                    }
                }
            }
        }
    },
    
    addAbilities : function(body, unit) {
        if( unit.strikeBack ) {
            body += "<img src='" + $("imagePath").value + "/Icons/strikeback.gif' />";
		}
		
		if( unit.catapult ) {
			body += "<img src='" + $("imagePath").value + "/Icons/catapult.gif' />";
		}
		
		if( unit.triple ) {
			body += "<img src='" + $("imagePath").value + "/Icons/triple.gif' />";
		}
		
		if( unit.replicator ) {
			body += "<img src='" + $("imagePath").value + "/Icons/replicator.gif' />";
		}
		
		if( unit.rebound ) {
			body += "<img src='" + $("imagePath").value + "/Icons/rebound.gif' />";
		}
		
		if( unit.removeAbility ) {
			body += "<img src='" + $("imagePath").value + "/Icons/removeAbility.gif' />";
		}
		
		if( unit.bomb ) {
			body += "<img src='" + $("imagePath").value + "/Icons/bomb.gif' />";
		}
		
		return body;
    }
  
};

window.addEvent('domready', Manual.init);