
var Site = {

    appPath: $("path").value,

    start: function() {
        Site.prepareFriendlies();
        Site.prepareTickCountdown();
        Site.prepareHistoryManager();
        log.resize();
    },

    startPlanet: function() {
        Site.HistoryManager.addEvent('onHistoryChange', Planet.onHistoryChanged);
        Planet.addTooltips();
        Planet.start();
    },

    prepareHistoryManager: function() {
        Site.HistoryManager = new HistoryManager();
    },

    onHistoryChanged: function(newHash) {
        alert(newHash);
    },

    tickUpdateTime: 1000,

    decrementTick: function() {
        var elem = $("tickCountdown");
        var start = elem.getAttribute("start");

        elem.innerHTML = Site.parseMillis(start);
        elem.setAttribute("start", start - Site.tickUpdateTime);
    },

    parseMillis: function(millis) {
        var seconds = Math.round(millis / 1000);

        var minutes = Math.floor(seconds / 60);
        if (minutes > 0) {
            seconds = seconds - minutes * 60;
        }

        if (seconds <= 0 && minutes <= 0) {
            return "00:00";
        }

        var secondsPart = seconds;
        if (seconds < 10) {
            secondsPart = "0" + seconds;
        }

        var minutesPart = minutes;
        if (minutes < 10) {
            minutesPart = "0" + minutes;
        }

        return minutesPart + ":" + secondsPart;
    },

    prepareTickCountdown: function() {
        if ($("tickCountdown")) {
            Site.decrementTick.periodical(Site.tickUpdateTime);
            Site.decrementTick();
        }
    },

    prepareFriendlies: function() {
        var so = $('searchOpponent');
        if (so) {
            Site.friendlyStart(so);
        }
    },

    friendlyStart: function(so) {
        var name = $('opponentId').value;
        var n = $(name).value;
        if (n != "") {
            Site.getPrincipalFriendlyList(n);
        }
    },

    logout: function() {
        var url = Site.appPath + "Ajax/Logout.aspx";

        var ajax = new Request.HTML({
            url: url,
            method: 'get',
            onComplete: function(r) {
                window.location = Site.appPath + "Login.aspx";
            }
        });

        if (window.ie) {
            ajax.setHeader('If-Modified-Since', 'Sat, 1 Jan 2000 00:00:00 GMT');
        }
        ajax.send();
    },

    getPrincipalFriendlyList: function(name) {
        var url = Site.appPath + "Ajax/SearchPlayer.ashx?type=" + $("searchType").value + "&name=" + name;

        Utils.ajaxRequest('get', url, $('results'), Site.searchOpponentCallBack);
    },

    searchOpponent: function() {
        var name = $('opponentId').value;
        var n = $(name).value;
        Site.getPrincipalFriendlyList(n);
    },

    searchOpponentCallBack: function() {
        var opponent = $('opponent');
        $('opponentUser').value = opponent.options[opponent.selectedIndex].value;

        opponent.addEvent('change', function(e) { Site.opponentChanged(); });
        Custom.initSelect(opponent);
    },

    opponentChanged: function() {
        var opponent = $('opponent');
        $('opponentUser').value = opponent.options[opponent.selectedIndex].value;
    },

    botOpponentChanged: function() {
        var opponent = $('botOpponent');
        $('opponentUser').value = opponent.options[opponent.selectedIndex].value;
    },

    selectTab: function(tabName) {
        var tab = $(tabName);
        var ul = tab.getParent();
        ul.getElements('li').each(function(item) {
            if (tab == item) {
                item.className = "selected";
                $(item.id + "Content").className = "visible";
            } else {
                item.className = "";
                $(item.id + "Content").className = "";
            }
        });
    },

    onUltimateChange: function(element) {
        for (var i = 0; i < selectedCheckBox.length; ++i) {
            var id = selectedCheckBox[i];
            if (element.id != id) {
                $(id).checked = false;
            }
        }
    },

    onOpponentUltimateChange: function(element) {
        for (var i = 0; i < selectedOpponentCheckBox.length; ++i) {
            var id = selectedOpponentCheckBox[i];
            if (element.id != id) {
                $(id).checked = false;
            }
        }
    },

    onBattleTypeChange: function(element) {
        for (var i = 0; i < selectedBattleTypeCheckBox.length; ++i) {
            var id = selectedBattleTypeCheckBox[i];
            if (element.id != id) {
                $(id).checked = false;
            }
        }
    },

    viewPlayer: function() {
        var result = $('opponentUser').value;
        if (result != "") {
            window.location = Site.appPath + "PlayerInfo.aspx?PlayerStorage=" + result;
        } else {
            Message.raiseAlert("SelectPlayerFirst");
        }
    },

    changeCastState: function(element) {
        var hasVoted = $(element + "HasVoted");
        var castVote = $(element + "CastVote");

        hasVoted.className = 'red';

        hasVoted.innerHTML = Language.getToken("Yes");
        castVote.dispose();

        var w = window.open("VotePage.aspx?vote=" + element);
    },

    lores: ['previewLightHumans', 'previewDarkHumans', 'previewBugs'],

    changeRace: function(id, className) {
        var lore = $(id + "Lore");
        if (className.indexOf("Hover") > -1) {
            Site.lores.each(function(l) {
                $(l).className = l;
                $(l+"Lore").removeClass("loreVisible");
            });

            $(id).className = className;
            lore.addClass("loreVisible");
        }
    }
};

window.addEvent('domready', Site.start);