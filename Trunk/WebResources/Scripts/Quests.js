
var Quests = {

    sendQuestRequest : function(url, element, args) {
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if( args.CallBack == null ) {
            args.CallBack = UniverseUtils.genericCallBack;
        }
        Utils.ajaxRequest('get', url, element, args.CallBack);
    },
    
    sendRequest : function(args) {
        var url = Site.appPath + "Ajax/Quests/Quest.ashx?1=1";
        Quests.sendQuestRequest(url, $('quest'), args);
    },
    
    getQuest : function(info) {
        Quests.sendRequest( {Type:'quest', Info: info, CallBack:Quests.getQuestCallBack} );
    },
       
    getQuest2 : function(info,id) {
        Quests.sendRequest( {Type:'quest', Info: info, Id:id, CallBack:Quests.getQuestCallBack} );
    },
    
    getQuest3 : function(info,target) {
        Quests.sendRequest( {Type:'quest', Info: info, Target:target, CallBack:Quests.getQuestCallBack} );
    },
    
    getQuestCallBack : function(responseTree, responseElements, responseHTML, responseJavaScript) {
        if($("questWindow")== null ){
            var style = { "top": 200, "closeEvent": "Quests.closeFrame();" };
            Utils.createBorder("questWindow", responseHTML, style);
            new Fx.Scroll(window, {}).toElement('globalMenu');
        }
    },
    
    accept : function(info,target) {
        Quests.sendRequest( {Type:'accept', Info: info, Target:target, CallBack:Quests.closeFrame} );
    },
    
    cancel : function(info, id ) {
        Quests.sendRequest( {Type:'cancel', Info: info, Id:id, CallBack:Quests.closeFrame} );
    },
    
    deliver : function(info, id) {
        Quests.sendRequest( {Type:'deliver', Info: info, Id:id, CallBack:Quests.showResult} );
    },
    
    getBounty : function(id) {
        Quests.sendRequest( {Type:'bounty', Id:id, CallBack:Quests.getQuestCallBack} );
    },
    
    acceptBounty : function(id) {
        Quests.sendRequest( {Type:'acceptBounty', Id:id, CallBack:Quests.closeFrame} );
    },
    
    cancelBounty : function(id) {
        Quests.sendRequest( {Type:'cancelBounty', Id:id, CallBack:Quests.closeFrame} );
    },
    
    closeFrame : function() {
        Utils.closeFrame("questWindow");
        window.location = window.location;
    },
    
    showResult : function(responseTree, responseElements, responseHTML, responseJavaScript) {
        $("result").innerHTML = responseHTML;
        if(responseHTML.indexOf('success') != -1 ){
            $("questButtons").dispose();
        } 
    },
    
    deliverAcademyQuestItem: function(id,system,sector) {
        var url = Site.appPath + "Ajax/Quests/Quest.ashx?system="+system+"&sector="+sector;
        var args = {Type:'deliverAcademyQuestItem', Fleet: id};
        Quests.sendQuestRequest(url, $('questsToDeliver'), args);
    }
        
};

