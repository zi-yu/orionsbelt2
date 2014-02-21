var Menu = {
    position: function(elem, event){
        var size = window.getSize();
        var scroll = window.getScroll();
		//var tip = {x: elem.offsetWidth, y: elem.offsetHeight};
		var props = {x: 'left', y: 'top'};
		var offsets = {x: 16, y: 16};
		for (var z in props){
			var pos = event.page[z] + offsets[z];
			if ((pos /*+ tip[z]*/ - scroll[z]) > size[z]) {
			    pos = event.page[z] - offsets[z] /*- tip[z]*/;
            }
			elem.setStyle(props[z], pos);
		}
	},
	
    positionByElement: function(elem, refElem, offsets){
        var size = window.getSize();
        var scroll = window.getScroll();
		var tip = {x: elem.offsetWidth, y: elem.offsetHeight};
		var coords = refElem.getCoordinates();
		var refTip = {x: coords.left, y: coords.top};
		var props = {x: 'left', y: 'top'};
		for (var z in props){
			var pos = refTip[z] + offsets[z];
			if ((pos + tip[z] - scroll[z]) > size[z]) {
			    pos = refTip[z] - offsets[z] - tip[z];
            }
			elem.setStyle(props[z], pos);
		}
	},
	
	showUniverseMenu : function( e ) {
	    var optionMenu = $('optionMenu');
        Menu.position(optionMenu, e);
        optionMenu.removeClass("hidden");
	},
	
	hideUniverseMenu : function( e ) {
	    var optionMenu = $('optionMenu');
        optionMenu.addClass("hidden");
	}
}