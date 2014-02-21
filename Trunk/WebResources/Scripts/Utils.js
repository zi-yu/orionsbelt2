String.prototype.replaceAll = function(de, para){
    var str = this;
    var pos = str.indexOf(de);
    while (pos > -1){
		str = str.replace(de, para);
		pos = str.indexOf(de);
	}
    return (str);
}

var mouseOverElement;
var currentEnemy;

var Utils = {

    numberOfPlayers: function() {
        return $('numberOfPlayers').value;
    },

    getTdElements: function() {
        if (Utils.numberOfPlayers() == 2) {
            return $('board2').getElements('td');
        }
        return $('board4').getElements('td');
    },

    getBattleDiv: function() {
        if (Utils.numberOfPlayers() == 2) {
            return $('battle');
        }
        return $('battle4');
    },

    hasMoves: function() {
        return $("moves").getText() == 0;
    },

    getQuantityElement: function() {
        return $("quantity");
    },

    getQuantity: function() {
        return Number($("quantity").value);
    },

    isSrcShip: function(element) {
        if (element.hasChildNodes()) {
            if (element.id.indexOf("_") == -1) {
                return true;
            }
        }
        return false;
    },

    canMoveOverPositioning: function(id, event) {
        Utils.hideImage("cannotMove");

        if (lastSelection != null) {

            if (lastSelection.id == id) {
                return false;
            }

            mouseOverElement = Utils.getItem($(id));

            if (!Utils.coordinateValid(id)) {
                return false;
            }

            if (mouseOverElement.isSource()) {
                if (lastSelection.getImageName() == mouseOverElement.id) {
                    return true;
                }
            } else {
                var dest = id.split("_");
                var posCondition;
                if (Utils.numberOfPlayers() == 2) {
                    posCondition = dest[0] == 7 || dest[0] == 8;
                } else {
                    posCondition = dest[0] == 11 || dest[0] == 12;
                }
                if (posCondition) {
                    if (mouseOverElement.hasChildNodes()) {
                        if (!lastSelection.equals(mouseOverElement)) {
                            mouseOverElement.setClass("cannotMoveAbove");
                            return false;
                        }
                        mouseOverElement.setClass("canMoveAbove");
                    } else {
                        mouseOverElement.setClass("canMove");
                    }
                    return true;
                }
            }
        }
        return false;
    },

    coordinateValid: function(id) {
        if (id == "1_1" || id == "1_2" || id == "1_11" || id == "1_12" ||
		    id == "2_1" || id == "2_2" || id == "2_11" || id == "2_12" ||
		    id == "11_1" || id == "11_2" || id == "11_11" || id == "11_12" ||
		    id == "12_1" || id == "12_2" || id == "12_11" || id == "12_12"
		) {
            return false;
        }
        return true;
    },

    systemCoordinateValid: function(x) {
        return x != NaN && x >= 1 && x <= 37;
    },

    sectorCoordinateXValid: function(x) {
        return x != NaN && x >= 1 && x <= 7;
    },

    sectorCoordinateYValid: function(y) {
        return y != NaN && y >= 1 && y <= 10;
    },

    canMoveOver: function(selectedElement, event) {
        Utils.hideImage("enemy");
        Utils.hideImage("cannotMove");
        Information.eraseAttackInfo();

        Information.fillByElement(selectedElement.node);

        if (lastSelection != null) {
            if (lastSelection.id == selectedElement.id) {
                return false;
            }

            mouseOverElement = selectedElement;

            var dest = selectedElement.id.split("_");
            var isEnemyUnit = mouseOverElement.isEnemyUnit();

            if (isEnemyUnit && AttackUtils.canAttack(dest)) {
                currentEnemy = mouseOverElement;
                Utils.showImage(mouseOverElement, "enemy", event);
                return false;
            }

            if (Utils.invalidBlink(selectedElement)) {
                return false;
            }

            if (Utils.canBlink(dest) || Utils.canMove(dest) || lastSelection.isQueen()) {
                var isFriendly = mouseOverElement.isFriendlyUnit();
                if (isEnemyUnit || isFriendly) {
                    Utils.showImage(mouseOverElement, "cannotMove", event);
                    return false;
                }

                if (mouseOverElement.hasChildNodes() && !lastSelection.equals(mouseOverElement)) {
                    Utils.showImage(mouseOverElement, "cannotMove", event);
                    return false;
                }

                if (lastSelection.isQueen()) {
                    if (selectedElement.canDeployEgg()) {
                        mouseOverElement.setClass("canMove");
                        return true;
                    }
                    Utils.showImage(mouseOverElement, "cannotMove", event);
                    return false;
                }

                mouseOverElement.setClass("canMove");
                return true;
            }

        }
        return false;
    },

    canMoveOut: function() {
        if (mouseOverElement != null) {
            if (Utils.numberOfPlayers() == 2 || (Utils.numberOfPlayers() == 4 && Utils.coordinateValid(mouseOverElement.id))) {
                if (!mouseOverElement.isEnemyUnit() && !mouseOverElement.isFriendlyUnit() && !Utils.overCurrentElement() /*&& !Utils.isBlinker(mouseOverElement) && */) {
                    mouseOverElement.setClass("");
                }
                mouseOverElement = null;
            }
        }
    },

    overCurrentElement: function() {
        if (lastSelection != null && lastSelection.id == mouseOverElement.id) {
            return true;
        }
        if (blinkSelection != null && blinkSelection.id == mouseOverElement.id) {
            return true;
        }

        return false;
    },

    canMove: function(dst) {
        if (blinkSelection != null) {
            return false;
        }

        var movType = lastSelection.unit().movementType;
        if (movType == "") {
            return false;
        }

        var src = lastSelection.id.split("_");

        var canMove = movesObj[movType](src, dst);
        if (Utils.numberOfPlayers() == 4) {
            return canMove && Utils.coordinateValid(mouseOverElement.id);
        }
        return canMove;
    },

    canBlink: function(dst) {
        var src = lastSelection.id.split("_");
        return blinkSelection != null && movesObj["blink"](src, dst);
    },

    invalidBlink: function(selectedElement) {
        return blinkSelection != null && Utils.numberOfPlayers() == 2 && selectedElement.id == "9_9";
    },

    registerMove: function(srcItem, dstItem, quantity, position) {
        $("movesMade").value += "m:" + srcItem.id + "-" + dstItem.id + "-" + quantity + "-" + position + ";";
    },

    registerBlink: function(srcItem, dstItem, quantity, position) {
        $("movesMade").value += "bk:" + srcItem.id + "-" + dstItem.id + "-" + quantity + "-" + position + ";";
    },

    registerEgg: function(dstItem) {
        $("movesMade").value += "e:" + dstItem.id + ";";
    },

    registerAttack: function(srcItem, dstItem) {
        $("movesMade").value += "b:" + srcItem.id + "-" + dstItem.id + ";";
    },

    registerRotation: function(srcItem, oldPosition, position) {
        $("movesMade").value += "r:" + srcItem.id + "-" + oldPosition + "-" + position + ";";
    },

    createSpecialMoveImage: function(item, imgId, imgSrc) {
        var t = item.node.getFirst().title;
        var img = new Element("img", { id: imgId, src: imgSrc, title: t });
        img.inject($("battle"));
        Utils.showImage(item, imgId);
        return img;
    },

    initSpecialMoveImages: function(isTurn) {
        var battle = $("battle");
        if (battle == null || $("battle").hasClass("preview")) {
            return;
        }
        for (var element in BattleElements) {
            var item = Utils.getItem($(element));
            var e = BattleElements[element];
            if (e.paralysed != null) {
                Utils.createParalyseImage(element, item, isTurn);
            }

            if (e.infestated == true) {
                Utils.createInfestationImage(element, item);
            }
        }
    },

    createParalyseImage: function(element, item, isTurn) {
        var img = Utils.createSpecialMoveImage(item, element + "paralysed", Utils.resolveBattleImage("Paralyse"));
        if (!Battle.isSpectator()) {
            img.addEvent('click', function(e) {
                if (lastSelection != null) {
                    Battle.selected($(this.parentId), e);
                    return;
                }
                if (isTurn) {
                    RaiseError.paralysed();
                }
            });
        }
    },

    createInfestationImage: function(element, item) {
        var img = Utils.createSpecialMoveImage(item, element + "infestated", Utils.resolveBattleImage("Infestation"));
        if (!Battle.isSpectator()) {
            img.parentId = element;
            img.addEvent('click', function(e) { Battle.selected($(this.parentId), e); });
        }
    },

    updateSpecialEffectsImages: function(lastSelection, selectedElement) {
        var e = BattleElements[selectedElement.id];
        if (e.infestated == true) {
            $(lastSelection.id + "infestated").dispose();
            Utils.createInfestationImage(selectedElement.id, selectedElement);
        }
    },


    getAbsX: function(elt) {
        return parseInt(elt.x) ? elt.x : Utils.getAbsPos(elt, "Left");
    },

    getAbsY: function(elt) {
        return parseInt(elt.y) ? elt.y : Utils.getAbsPos(elt, "Top");
    },

    getAbsPos: function(elt, which) {
        iPos = 0;
        while (elt != null) {
            iPos += elt["offset" + which];
            elt = elt.offsetParent;
        }
        return iPos;
    },

    hideImage: function(image) {
        $(image).className = "invisible";
    },

    showImage: function(mouseOverElement, image, event) {
        var td = mouseOverElement.node;
        var img = $(image);

        x = Utils.getAbsX(td);
        y = Utils.getAbsY(td);
        img.style.left = x + 2 + "px";
        img.style.top = y + 2 + "px";
        img.className = "visible";
        if (event != null) {
            event.cancelBubble = true;
        }
    },

    getItem: function(element) {
        var item = element.item;
        if (item == null) {
            item = new Item(element);
            element.item = item;
        }
        return item;
    },

    hasChilds: function(element) {
        return element.hasChildNodes() && element.getFirst().get('tag') != "span";
    },

    queryString: function(name) {
        name = name.toLowerCase();
        var url = window.location.search.substring(1).toLowerCase();
        var elements = url.split("&");
        for (var i = 0; i < elements.length; ++i) {
            var element = elements[i].split("=");
            if (element[0] == name) {
                return element[1];
            }
        }
    },

    resetSelection: function(s) {
        if (s != null) {
            s.setClass("");
        }
        if (lastSelection != null) {
            lastSelection.setClass("");
            lastSelection = null;
        }
    },

    ajaxRequest: function(method, url, updateElement, callback) {
        if (updateElement) {
            Utils.setLoadingElement(updateElement);
        }

        var ajax = new Request.HTML({
            url: url,
            method: method,
            update: updateElement,
            onComplete: callback,
            cache: false
        });

        if (Browser.Engine.trident) {
            ajax.setHeader('If-Modified-Since', 'Sat, 1 Jan 2000 00:00:00 GMT');
        }
        ajax.send();
    },

    simpleLoadAjaxGet: function(url, updateElement, callback) {
        if (updateElement) {
            Utils.setSimpleLoadingElement(updateElement);
        }

        var ajax = new Request.HTML({
            url: url,
            method: 'get',
            update: updateElement,
            onComplete: callback,
            cache: false
        });

        if (Browser.Engine.trident) {
            ajax.setHeader('If-Modified-Since', 'Sat, 1 Jan 2000 00:00:00 GMT');
        }
        ajax.send();
    },

    simpleLoadAjaxPost: function(url, updateElement, callback, params) {
        if (updateElement) {
            Utils.setSimpleLoadingElement(updateElement);
        }

        var ajax = new Request.HTML({
            url: url,
            method: 'post',
            update: updateElement,
            onComplete: callback,
            cache: false
        });

        if (Browser.Engine.trident) {
            ajax.setHeader('If-Modified-Since', 'Sat, 1 Jan 2000 00:00:00 GMT');
        }
        ajax.send(params);
    },


    setLoadingElement: function(element) {
        var w = element.offsetWidth;
        var h = element.offsetHeight;
        var coords = element.getCoordinates();
        var div = new Element('div', { id: 'loading', styles: { width: w, height: h, left: coords.left, top: coords.top} });
        div.inject(element);


        var loadingBck = new Element('div', { classname: 'loadingBck' });
        var loadingImg = new Element('div', { classname: 'loadingImg' });

        loadingImg.inject(loadingBck);
        loadingBck.inject(div);
        //div.innerHTML = "<div class='loadingBck'><div class='loadingImg'></div></div>";
    },

    setSimpleLoadingElement: function(element) {
        var div = new Element('div', { id: 'simpleLoader' });
        element.empty();
        div.inject(element);
    },

    insertTip: function(element, title, text) {
        var tips = new Tips(element, {
            initialize: function() { },
            onShow: function(toolTip) {
                Utils.hideAllTips();
                toolTip.set({ 'styles': { 'opacity': 1} });
            },
            onHide: function(toolTip) {
                toolTip.set({ 'styles': { 'opacity': 0} });
            }
        });

        element.store(title, text);
        element.store('tip:title', title);
        element.store('tip:text', text);
        element.tip = tips;
    },

    updateTip: function(element, text) {
        element.store('tip:text', text);
    },

    insertFixedTip: function(element, title, text) {
        var tips = new Tips(element);
        element.store(title, text);
        element.store('tip:title', title);
        element.store('tip:text', text);
    },

    hideAllTips: function() {
        $$(".tip-top").each(function(item) {
            item.getParent().set({ 'styles': { 'opacity': 0} });
        });
    },

    getForm: function() {
        var form = $(document.forms[0]);
        if (form == null) {
            throw ("No Form Found!");
        }
        return form;
    },

    doAction: function(type, action, data, askConfirmation) {
        var form = Utils.getForm();

        if (true == askConfirmation && !Message.raiseConfirm("AreYouSure")) {
            return;
        }

        form.doAction_type.value = type;
        form.doAction_action.value = action;
        form.doAction_data.value = data;

        form.submit();
    },

    checkAndNotifyStringNotEmpty: function(str) {
        if (str == null || str == '') {
            Message.raiseAlert("NoInputProvided");
            return false;
        }
        return true;
    },

    resolveUnitImage: function(name) {
        return $("imagePath").value + "/Units/" + name.toLowerCase() + ".png";
    },

    resolveBattleImage: function(name) {
        return $("imagePath").value + "/Battle/" + name + ".png";
    },

    resolveResourceImage: function(name) {
        return $("imagePath").value + "/Resources/" + name + ".png";
    },

    resolveFacilitiesImage: function(race, name) {
        return $("imagePath").value + "/Planets/" + race + "/" + name + "R.png";
    },

    resolveEtcImage: function(name, extension) {
        return $("imagePath").value + "/Etc/" + name + "." + extension;
    },

    resolveImage: function(name) {
        var unit = Unit[name.toLowerCase()];
        if (unit != null) {
            return Utils.resolveUnitImage(name);
        }
        return Utils.resolveResourceImage(name);
    },

    deleteAllMessages: function() {
        if (!Message.raiseConfirm("AreYouSure")) {
            return;
        }

        var url = "Ajax/Utils/Messages.ashx?Action=DeleteAll";
        var link = $("deleteAllMessages");

        link.oldColor = link.getStyle("color");
        link.oldHref = link.href;
        link.setStyle("color", "#ADADAD");
        link.href = "#";

        Utils.ajaxRequest('get', url, null, Utils.afterDeleteAllMessages);

        var sons = $(document.body).getElements(".message");
        var table = null;
        for (var i = 0; i < sons.length; ++i) {
            table = sons[i].getParent();
            sons[i].dispose();
        }

        if (table == null) {
            return;
        }

        var newTr = new Element("tr", { styles: { opacity: 0} });
        var newTd = new Element("td", { html: Language.getToken("NoMessages") });
        newTr.inject(table);
        newTd.inject(newTr);
        var fx = new Fx.Tween(newTr, { property: 'opacity', duration: 1000 });
        fx.start(1);
    },

    afterDeleteAllMessages: function() {
        var link = $("deleteAllMessages");
        link.setStyle("color", link.oldColor);
        link.href = link.oldHref;
    },

    redirectToPlayerPage: function(id) {
        window.location = $("path").value + "PlayerInfo.aspx?PlayerStorage=" + id;
    },

    createFrame: function(elementId, title, innerElement, style, callback) {
        var frame = new Element("div", { id: elementId });
        if (style.className != null) {
            frame.addClass(style.className);
        }

        var fx = new Fx.Tween(frame, { property: 'opacity', duration: 1000 });

        if (style.top != null) {
            frame.setStyles({ "left": 0, "top": style.top, "opacity": 0 });
        } else {
            var size = window.getSize();
            var t = (size.y - 600) / 2;
            if (t < 0) {
                t = 100;
            }
            frame.setStyles({ "left": 0, "top": t, "opacity": 0 });
        }

        var closeEvent;
        if (style.closeEvent != null) {
            closeEvent = style.closeEvent;
        } else {
            closeEvent = "Utils.closeFrame(\"" + elementId + "\");"
        }

        frame.callback = callback;

        var titleFrame = "<table id='informationTable' class='frame'>";
        titleFrame += "<tr><th class='frameTopLeft'></th><th class='frameTopCenter'>" + Language.getToken(title) + "</th><th class='frameTopRightCross' onclick='" + closeEvent + "'></th></tr>";
        titleFrame += "<tr><td class='frameMiddleLeft'></td>";
        titleFrame += "<td class='frameMiddleCenter messageContent'>";
        titleFrame += innerElement;
        titleFrame += "<td class='frameMiddleRight'></td></tr>";
        titleFrame += "<tr><td class='frameBottomLeft'></td><td class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>";
        frame.innerHTML = titleFrame;
        frame.inject($(document.body));

        fx.start(1);

        //	    var indexLevel = 1;
        //  
        //  function dragContainerInit(el){
        //  
        //  	var fadeIn = new fx.Opacity(el.parentNode, {duration:300});
        //	
        //	var dragContainerOptions = {

        //		handle: el, 
        //		
        //		onStart: function(){
        //			var fadeIn = new fx.Opacity(el.parentNode, {duration:300});
        //			fadeIn.custom(1,.5);
        //			indexLevel++; 
        //			el.parentNode.style.zIndex = indexLevel;
        //		}.bind(this),
        //		 
        //		onComplete: function(){
        //			var fadeIn = new fx.Opacity(el.parentNode, {duration:300});
        //			fadeIn.custom(.5,1);
        //		
        //		}.bind(this)
        //	};
        //	
        //  	el.style.cursor = 'move';
        //		
        //	el.parentNode.makeDraggable(dragContainerOptions);
        //  
        //  }

        //  window.onload=function()
        //  {
        //	
        //	/* setup draggables */
        //	
        //	var draggables = document.getElementsBySelector('.dragger');
        //	draggables.each(function(el){dragContainerInit(el);});
        //	
        //	
        //  }
        return frame;
    },

    createBorder: function(elementId, innerElement, style, callback) {
        var frame = new Element("div", { id: elementId });
        if (style.className != null) {
            frame.addClass(style.className);
        }

        var fx = new Fx.Tween(frame, { property: 'opacity', duration: 1000 });

        var top;
        if (style.top != null) {
            top = style.top;
        } else {
            var size = window.getSize();
            var t = (size.y - 600) / 2;
            if (t < 0) {
                t = 100;
            }
            top = t;
        }

        frame.setStyles({ "left": 0, "top": 0, "opacity": 0, "height": document.body.offsetHeight });

        frame.callback = callback;
        frame.innerHTML = innerElement;
        frame.inject($(document.body));

        fx.start(1);

        return frame;
    },

    closeFrame: function(frameName) {
        var frame = $(frameName);
        if (frame.callback != null) {
            frame.callback();
        }
        frame.dispose();
    },

    createIFrame: function(elementId, url, title, iFrameWidth, iFrameHeight, callback) {
        var style = { "className": "iframeWindow" };
        var iFrame = "<iframe id='iframe' src='" + url + "' frameborder='0' marginheight='0' marginwidth='0' width='" + iFrameWidth + "' height='" + iFrameHeight + "'></iframe>";
        Utils.createFrame(elementId, title, iFrame, style, callback);
    },

    changeOrionsPlan: function(elem, service) {
        var option = elem.options[elem.selectedIndex];
        var scale = option.value;
        var scaleField = $("scale");
        if (scaleField != null) {
            scaleField.value = scale;
        }
        if (window.shopItemsScale != null) {
            var orions = window.shopItemsScale[service];
            if (scale == 1) {
                orions = Math.ceil(orions / 3 + orions / 10);
                orions = Math.round(orions / 10) * 10;
            }
            $(service + "Cost").innerHTML = orions;
        }
    },

    getTimeFromTicks: function(ticks) {
        var milliseconds = $('millisPerTick').value * ticks;
        var date = new Date(milliseconds);
        var days = date.getDay();
        var d = milliseconds / 86400000;
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var hoursStr = "";

        if (d > 1) {
            hoursStr += Math.floor(d) + "d ";
        }
        if (hours > 0) {
            hoursStr += hours + "h ";
        }
        if (minutes > 0) {
            hoursStr += minutes + " m"
        }
        return hoursStr;
    },

    showAddUserMedals: function() {
        var list = $("userMedals");
        list.getElements('dd').each(function(son) {
            son.setStyle("display", "block");
        });
    },

    searchPlayer: function(name) {
        var path = "/";
        var pathElement = $("path");
        if (pathElement != null) {
            path = pathElement.value;
        }
        window.location = path + "SearchPlayers.aspx?Name=" + escape(name);
    },

    showHidePayment: function() {
        var curr = $("plusSign");
        var elem = $("bonusTable");
        if (curr.className == "plus") {
            curr.className = "minus";
            $(elem).removeClass("hidden");
            $(elem).addClass("visibleRelative");
        } else {
            curr.className = "plus";
            $(elem).removeClass("visibleRelative");
            $(elem).addClass("hidden");
        }
    }
}
