function Handler() {
	this.positioning = function() {
		Positioning.start();
	}
	
	this.battle = function() {
		Battle.start();
	}
	
	this.fill = function() {
		FillInformation.start();
	}
}

var handler = new Handler();
var handlerKey;

window.addEvent('domready', function() {
	if( handlerKey ) {
		handler[handlerKey]();
	}
});

