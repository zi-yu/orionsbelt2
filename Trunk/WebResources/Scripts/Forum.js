
var Forum = {
    currentElement: null,
    previousHash: null,

    init: function() {
        Site.HistoryManager.addEvent('onHistoryChange', Forum.onHistoryChanged);

        try {
            if (window.location.href.indexOf("#") >= 0) {
                Forum.onHistoryChanged(window.location.hash);
            }
        } catch (e) {
            log.error(e);
        }
    },

    sendForumRequest: function(url, element, args, type) {
        var hash = "/";
        var params = '1=1';
        for (var propName in args) {
            if (propName != 'CallBack') {
                params += "&" + propName + "=" + args[propName];
                if (propName != "Text" && propName != "Description") {
                    hash += propName + "_" + args[propName] + "/";
                }
            }
        }
        if (args.CallBack == null) {
            args.CallBack = Forum.genericCallBack;
        }
        Site.HistoryManager.addState(hash);
        Forum.previousHash = hash;

        new Fx.Scroll(window, {}).toElement(element);
        Forum.currentElement = element;

        if (type == 'get') {
            url += '?' + params;
            Utils.simpleLoadAjaxGet(url, element, args.CallBack);
        } else {
            Utils.simpleLoadAjaxPost(url, element, args.CallBack, params);
        }
        return true;
    },


    genericCallBack: function(a, b, c, d) {
        Forum.currentElement.setStyle("opacity", 0);
        var fx = new Fx.Tween(Forum.currentElement, { property: 'opacity', duration: 500 });
        fx.start(1);

    },

    sendRequest: function(args, element) {
        var url = Site.appPath + "Ajax/Forum/Forum.ashx";
        return Forum.sendForumRequest(url, $(element), args, 'get');
    },

    sendPostRequest: function(args, element) {
        var url = Site.appPath + "Ajax/Forum/Forum.ashx";
        return Forum.sendForumRequest(url, $(element), args, 'post');
    },

    getMethod: function(params) {
        var method = params[1];
        var methodSplit = method.split("_");
        if (methodSplit[0] == "Type") {
            return methodSplit[1];
        }
        return null;
    },

    getParam: function(params) {
        var method = params[2];
        var methodSplit = method.split("_");
        if (methodSplit.length == 2) {
            return methodSplit[1];
        }
        return null;
    },

    onHistoryChanged: function(newHash) {
        newHash = newHash.replace("#", "");

        if (newHash == "" || newHash == "/") {
            window.location = "Forum.aspx";
            return;
        }

        if (Forum.previousHash == newHash) {
            return;
        }

        var params = newHash.split("/");
        var method = Forum.getMethod(params);
        var param = Forum.getParam(params);

        if (method != undefined && method != null && param != "undefined") {
            if (param == null) {
                Forum[method]();
            } else {
                Forum[method](param);
            }
        }
    },

    insertAtCursor: function(field, myValue) {
        var myField = $(field);
        myValue = " " + myValue;
        //IE support
        if (document.selection) {
            myField.focus();
            sel = document.selection.createRange();
            sel.text = myValue;
            return;
        }
        //MOZILLA/NETSCAPE support
        if (myField.selectionStart || myField.selectionStart == '0') {
            var startPos = myField.selectionStart;
            var endPos = myField.selectionEnd;
            myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
        } else {
            myField.value += myValue;
        }
    },

    showCreateTopic: function() {
        Forum.sendRequest({ Type: 'showCreateTopic' }, "createTopic");
    },

    showCreateThread: function() {
        Forum.sendRequest({ Type: 'showCreateThread' }, "createThread");
    },

    showCreatePost: function() {
        Forum.sendRequest({ Type: 'showCreatePost' }, "createPost");
    },

    showTopics: function() {
        Forum.sendRequest({ Type: 'showTopics' }, "forum");
    },

    showTopic: function(id) {
        Forum.sendRequest({ Type: 'showTopic', TopicId: id }, "forum");
    },

    showThread: function(id) {
        Forum.sendRequest({ Type: 'showThread', ThreadId: id }, "forum");
    },

    showEditPost: function(id) {
        Forum.sendRequest({ Type: 'showEditPost', PostId: id }, "createPost");
    },

    closeCreateTopic: function() {
        Forum.sendRequest({ Type: 'closeCreateTopic' }, "createTopic");
    },

    closeCreateThread: function() {
        Forum.sendRequest({ Type: 'closeCreateThread' }, "createThread");
    },

    closeCreatePost: function() {
        Forum.sendRequest({ Type: 'closeCreatePost' }, "createPost");
    },

    closeEditPost: function() {
        Forum.sendRequest({ Type: 'closeEditPost' }, "createPost");
    },

    createTopic: function() {
        Forum.sendPostRequest({ Type: 'createTopic', Name: $('topicName').value, Description: $('topicDescription').value }, "publicforum");
    },

    createThread: function() {
        Forum.sendPostRequest({ Type: 'createThread', Title: $('threadTitle').value, Description: $('threadDescription').value, TopicId: $("topicId").value }, "forumTopic");
    },

    createPost: function() {
        Forum.sendPostRequest({ Type: 'createPost', Text: $('postTextArea').value, ThreadId: $("threadId").value }, "forumThread");
    },

    eraseTopic: function(id) {
        if (confirm(Language.getToken("EraseTopic"))) {
            Forum.sendRequest({ Type: 'eraseTopic', TopicId: id }, "publicforum");
        }
    },

    eraseThread: function(id) {
        if (confirm(Language.getToken("EraseThread"))) {
            Forum.sendRequest({ Type: 'eraseThread', ThreadId: id }, "forumTopic");
        }
    },

    erasePost: function(id) {
        if (confirm(Language.getToken("ErasePost"))) {
            Forum.sendRequest({ Type: 'erasePost', PostId: id }, "forumThread");
        }
    },

    editPost: function(id) {
        Forum.sendPostRequest({ Type: 'editPost', PostId: id, Text: $('postTextArea').value }, "forumThread");
    }

};

window.addEvent('domready', Forum.init);
