var lastSelection;

var FillInformation = {

	start : function() {
		Utils.initSpecialMoveImages(false);
		FillInformation.initTDElements();
		FillInformation.initOtherElements('initialTop');
		FillInformation.initOtherElements('initialRight');
		FillInformation.initOtherElements('initialLeft');
		var giveUp = $('giveUp');
		if( giveUp ) {
		    giveUp.addEvent('click', function( e ) {FillInformation.giveUp();});
		}
		if($("battleCalculator") ) {
		    $("elementSelectedQuantInput").addEvent('keyup', function( e ) {Information.fillCalculatorEvent(this, e);});
		    $("elementSelectedRangeInput").addEvent('keyup', function( e ) {Information.fillCalculatorRangeEvent(this, e);});
		}
	},
	
	initTDElements : function(  ) {
		Utils.getTdElements().each( function( td ) {
			td.addEvent('mouseover', function( e ) {
				FillInformation.fillElement(this);
			});
		});
		
		FillInformation.initUltimateElements("9_9");
		FillInformation.initUltimateElements("0_0");
	},
	
	initUltimateElements : function(elem) {
	    var nop = Utils.numberOfPlayers();
	    var e = $(elem);
	    if( e && nop == 2 ) {
		    e.addEvent('mouseover', function( e ) {
				FillInformation.fillElement(this);
			});
		}
	},
	
	initOtherElements : function( name ) {
		var initialTop =  $(name);
		if( initialTop != null) {
			var elements = initialTop.getElements('td');
			elements.each( function( td ) {
				td.addEvent('mouseover', function( e ) {
					FillInformation.fillElement(this);
				});
			});
		}
	},
	
	fillElement : function( element ) {
		if( Utils.hasChilds(element) ) {
			var selectedElement = Utils.getItem( element );
			if( selectedElement != null ) {
				Information.fillAll( selectedElement );
			}
		}
	},
	
	giveUp: function() {
		var answer = Message.raiseConfirm("GiveUp");
		if( answer ) {
		    $("giveUp").disabled = true;
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=giveUp&id="+battleId;
			
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Battle.giveUpCallBack);
		}
	},
	
	giveUpCallBack : function() {}
}