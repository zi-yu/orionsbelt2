var Prices = {
    sendRequest : function(args) {
        var  url = Site.appPath + "Ajax/Prices/Prices.ashx?1=1";
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if( args.CallBack == null ) {
            args.CallBack = UniverseUtils.genericCallBack;
        }
        Utils.ajaxRequest('get', url, $("pricesContent"), args.CallBack);
    },
    
    changes : function()
    {
        var option = $("languageChooser").value;
        var  url = Site.appPath + "Ajax/Prices/Prices.ashx?Type=Change&Language="+option;
        Utils.ajaxRequest('get', url, $("pricesContent"));  
     },
     
    getQueryString: function(ji) {
		hu = window.location.search.substring(1);
		gy = hu.split("&");
		for (i=0;i<gy.length;i++) {
			ft = gy[i].split("=");
			if (ft[0] == ji) {
				return ft[1];
			}
		} 
	}

}

window.addEvent('domready', function() {
	if( $("languageChooser") ) {
		$("languageChooser").correctOnChange = Prices.changes;
	}
});

function printPage(url) {
	var form = Prices.getQueryString('Invoice');
	if( form != null ) {
		url += '?Invoice=' + form;
	}
	window.open( url, Language.getToken("Invoice"),'width=1024;menubar=no,scrollbars=yes');
}