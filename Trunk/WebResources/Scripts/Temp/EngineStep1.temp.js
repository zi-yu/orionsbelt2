
// Mootools.js
/*
Script: Core.js
	MooTools - My Object Oriented JavaScript Tools.

License:
	MIT-style license.

Copyright:
	Copyright (c) 2006-2007 [Valerio Proietti](http://mad4milk.net/).

Code & Documentation:
	[The MooTools production team](http://mootools.net/developers/).

Inspiration:
	- Class implementation inspired by [Base.js](http://dean.edwards.name/weblog/2006/03/base/) Copyright (c) 2006 Dean Edwards, [GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)
	- Some functionality inspired by [Prototype.js](http://prototypejs.org) Copyright (c) 2005-2007 Sam Stephenson, [MIT License](http://opensource.org/licenses/mit-license.php)
*/

var MooTools = {
	'version': '1.2.0',
	'build': ''
};
      
var Native = function(options){
	options = options || {};

	var afterImplement = options.afterImplement || function(){};
	var generics = options.generics;
	generics = (generics !== false);
	var legacy = options.legacy;
	var initialize = options.initialize;
	var protect = options.protect;
	var name = options.name;

	var object = initialize || legacy;

	object.constructor = Native;
	object.$family = {name: 'native'};
	if (legacy && initialize) object.prototype = legacy.prototype;
	object.prototype.constructor = object;

	if (name){
		var family = name.toLowerCase();
		object.prototype.$family = {name: family};
		Native.typize(object, family);
	}

	var add = function(obj, name, method, force){
		if (!protect || force || !obj.prototype[name]) obj.prototype[name] = method;
		if (generics) Native.genericize(obj, name, protect);
		afterImplement.call(obj, name, method);
		return obj;
	};
	
	object.implement = function(a1, a2, a3){
		if (typeof a1 == 'string') return add(this, a1, a2, a3);
		for (var p in a1) add(this, p, a1[p], a2);
		return this;
	};
	
	object.alias = function(a1, a2, a3){
		if (typeof a1 == 'string'){
			a1 = this.prototype[a1];
			if (a1) add(this, a2, a1, a3);
		} else {
			for (var a in a1) this.alias(a, a1[a], a2);
		}
		return this;
	};

	return object;
};

Native.implement = function(objects, properties){
	for (var i = 0, l = objects.length; i < l; i++) objects[i].implement(properties);
};

Native.genericize = function(object, property, check){
	if ((!check || !object[property]) && typeof object.prototype[property] == 'function') object[property] = function(){
		var args = Array.prototype.slice.call(arguments);
		return object.prototype[property].apply(args.shift(), args);
	};
};

Native.typize = function(object, family){
	if (!object.type) object.type = function(item){
		return ($type(item) === family);
	};
};

Native.alias = function(objects, a1, a2, a3){
	for (var i = 0, j = objects.length; i < j; i++) objects[i].alias(a1, a2, a3);
};

(function(objects){
	for (var name in objects) Native.typize(objects[name], name);
})({'boolean': Boolean, 'native': Native, 'object': Object});

(function(objects){
	for (var name in objects) new Native({name: name, initialize: objects[name], protect: true});
})({'String': String, 'Function': Function, 'Number': Number, 'Array': Array, 'RegExp': RegExp, 'Date': Date});

(function(object, methods){
	for (var i = methods.length; i--; i) Native.genericize(object, methods[i], true);
	return arguments.callee;
})
(Array, ['pop', 'push', 'reverse', 'shift', 'sort', 'splice', 'unshift', 'concat', 'join', 'slice', 'toString', 'valueOf', 'indexOf', 'lastIndexOf'])
(String, ['charAt', 'charCodeAt', 'concat', 'indexOf', 'lastIndexOf', 'match', 'replace', 'search', 'slice', 'split', 'substr', 'substring', 'toLowerCase', 'toUpperCase', 'valueOf']);

function $chk(obj){
	return !!(obj || obj === 0);
};

function $clear(timer){
	clearTimeout(timer);
	clearInterval(timer);
	return null;
};

function $defined(obj){
	return (obj != undefined);
};

function $empty(){};

function $arguments(i){
	return function(){
		return arguments[i];
	};
};

function $lambda(value){
	return (typeof value == 'function') ? value : function(){
		return value;
	};
};

function $extend(original, extended){
	for (var key in (extended || {})) original[key] = extended[key];
	return original;
};

function $unlink(object){
	var unlinked;
	
	switch ($type(object)){
		case 'object':
			unlinked = {};
			for (var p in object) unlinked[p] = $unlink(object[p]);
		break;
		case 'hash':
			unlinked = $unlink(object.getClean());
		break;
		case 'array':
			unlinked = [];
			for (var i = 0, l = object.length; i < l; i++) unlinked[i] = $unlink(object[i]);
		break;
		default: return object;
	}
	
	return unlinked;
};

function $merge(){
	var mix = {};
	for (var i = 0, l = arguments.length; i < l; i++){
		var object = arguments[i];
		if ($type(object) != 'object') continue;
		for (var key in object){
			var op = object[key], mp = mix[key];
			mix[key] = (mp && $type(op) == 'object' && $type(mp) == 'object') ? $merge(mp, op) : $unlink(op);
		}
	}
	return mix;
};

function $pick(){
	for (var i = 0, l = arguments.length; i < l; i++){
		if (arguments[i] != undefined) return arguments[i];
	}
	return null;
};

function $random(min, max){
	return Math.floor(Math.random() * (max - min + 1) + min);
};

function $splat(obj){
	var type = $type(obj);
	return (type) ? ((type != 'array' && type != 'arguments') ? [obj] : obj) : [];
};

var $time = Date.now || function(){
	return new Date().getTime();
};

function $try(){
	for (var i = 0, l = arguments.length; i < l; i++){
		try {
			return arguments[i]();
		} catch(e){}
	}
	return null;
};

function $type(obj){
	if (obj == undefined) return false;
	if (obj.$family) return (obj.$family.name == 'number' && !isFinite(obj)) ? false : obj.$family.name;
	if (obj.nodeName){
		switch (obj.nodeType){
			case 1: return 'element';
			case 3: return (/\S/).test(obj.nodeValue) ? 'textnode' : 'whitespace';
		}
	} else if (typeof obj.length == 'number'){
		if (obj.callee) return 'arguments';
		else if (obj.item) return 'collection';
	}
	return typeof obj;
};

var Hash = new Native({

	name: 'Hash',

	initialize: function(object){
		if ($type(object) == 'hash') object = $unlink(object.getClean());
		for (var key in object) this[key] = object[key];
		return this;
	}

});

Hash.implement({
	
	getLength: function(){
		var length = 0;
		for (var key in this){
			if (this.hasOwnProperty(key)) length++;
		}
		return length;
	},

	forEach: function(fn, bind){
		for (var key in this){
			if (this.hasOwnProperty(key)) fn.call(bind, this[key], key, this);
		}
	},
	
	getClean: function(){
		var clean = {};
		for (var key in this){
			if (this.hasOwnProperty(key)) clean[key] = this[key];
		}
		return clean;
	}

});

Hash.alias('forEach', 'each');

function $H(object){
	return new Hash(object);
};

Array.implement({

	forEach: function(fn, bind){
		for (var i = 0, l = this.length; i < l; i++) fn.call(bind, this[i], i, this);
	}

});

Array.alias('forEach', 'each');

function $A(iterable){
	if (iterable.item){
		var array = [];
		for (var i = 0, l = iterable.length; i < l; i++) array[i] = iterable[i];
		return array;
	}
	return Array.prototype.slice.call(iterable);
};

function $each(iterable, fn, bind){
	var type = $type(iterable);
	((type == 'arguments' || type == 'collection' || type == 'array') ? Array : Hash).each(iterable, fn, bind);
};


/*
Script: Browser.js
	The Browser Core. Contains Browser initialization, Window and Document, and the Browser Hash.

License:
	MIT-style license.
*/

var Browser = new Hash({
	Engine: {name: 'unknown', version: ''},
	Platform: {name: (navigator.platform.match(/mac|win|linux/i) || ['other'])[0].toLowerCase()},
	Features: {xpath: !!(document.evaluate), air: !!(window.runtime)},
	Plugins: {}
});

if (window.opera) Browser.Engine = {name: 'presto', version: (document.getElementsByClassName) ? 950 : 925};
else if (window.ActiveXObject) Browser.Engine = {name: 'trident', version: (window.XMLHttpRequest) ? 5 : 4};
else if (!navigator.taintEnabled) Browser.Engine = {name: 'webkit', version: (Browser.Features.xpath) ? 420 : 419};
else if (document.getBoxObjectFor != null) Browser.Engine = {name: 'gecko', version: (document.getElementsByClassName) ? 19 : 18};
Browser.Engine[Browser.Engine.name] = Browser.Engine[Browser.Engine.name + Browser.Engine.version] = true;

if (window.orientation != undefined) Browser.Platform.name = 'ipod';

Browser.Platform[Browser.Platform.name] = true;

Browser.Request = function(){
	return $try(function(){
		return new XMLHttpRequest();
	}, function(){
		return new ActiveXObject('MSXML2.XMLHTTP');
	});
};

Browser.Features.xhr = !!(Browser.Request());

Browser.Plugins.Flash = (function(){
	var version = ($try(function(){
		return navigator.plugins['Shockwave Flash'].description;
	}, function(){
		return new ActiveXObject('ShockwaveFlash.ShockwaveFlash').GetVariable('$version');
	}) || '0 r0').match(/\d+/g);
	return {version: parseInt(version[0] || 0 + '.' + version[1] || 0), build: parseInt(version[2] || 0)};
})();

function $exec(text){
	if (!text) return text;
	if (window.execScript){
		window.execScript(text);
	} else {
		var script = document.createElement('script');
		script.setAttribute('type', 'text/javascript');
		script.text = text;
		document.head.appendChild(script);
		document.head.removeChild(script);
	}
	return text;
};

Native.UID = 1;

var $uid = (Browser.Engine.trident) ? function(item){
	return (item.uid || (item.uid = [Native.UID++]))[0];
} : function(item){
	return item.uid || (item.uid = Native.UID++);
};

var Window = new Native({

	name: 'Window',

	legacy: (Browser.Engine.trident) ? null: window.Window,

	initialize: function(win){
		$uid(win);
		if (!win.Element){
			win.Element = $empty;
			if (Browser.Engine.webkit) win.document.createElement("iframe"); //fixes safari 2
			win.Element.prototype = (Browser.Engine.webkit) ? window["[[DOMElement.prototype]]"] : {};
		}
		return $extend(win, Window.Prototype);
	},

	afterImplement: function(property, value){
		window[property] = Window.Prototype[property] = value;
	}

});

Window.Prototype = {$family: {name: 'window'}};

new Window(window);

var Document = new Native({

	name: 'Document',

	legacy: (Browser.Engine.trident) ? null: window.Document,

	initialize: function(doc){
		$uid(doc);
		doc.head = doc.getElementsByTagName('head')[0];
		doc.html = doc.getElementsByTagName('html')[0];
		doc.window = doc.defaultView || doc.parentWindow;
		if (Browser.Engine.trident4) $try(function(){
			doc.execCommand("BackgroundImageCache", false, true);
		});
		return $extend(doc, Document.Prototype);
	},

	afterImplement: function(property, value){
		document[property] = Document.Prototype[property] = value;
	}

});

Document.Prototype = {$family: {name: 'document'}};

new Document(document);

/*
Script: Array.js
	Contains Array Prototypes like copy, each, contains, and remove.

License:
	MIT-style license.
*/

Array.implement({

	every: function(fn, bind){
		for (var i = 0, l = this.length; i < l; i++){
			if (!fn.call(bind, this[i], i, this)) return false;
		}
		return true;
	},

	filter: function(fn, bind){
		var results = [];
		for (var i = 0, l = this.length; i < l; i++){
			if (fn.call(bind, this[i], i, this)) results.push(this[i]);
		}
		return results;
	},
	
	clean: function() {
		return this.filter($defined);
	},

	indexOf: function(item, from){
		var len = this.length;
		for (var i = (from < 0) ? Math.max(0, len + from) : from || 0; i < len; i++){
			if (this[i] === item) return i;
		}
		return -1;
	},

	map: function(fn, bind){
		var results = [];
		for (var i = 0, l = this.length; i < l; i++) results[i] = fn.call(bind, this[i], i, this);
		return results;
	},

	some: function(fn, bind){
		for (var i = 0, l = this.length; i < l; i++){
			if (fn.call(bind, this[i], i, this)) return true;
		}
		return false;
	},

	associate: function(keys){
		var obj = {}, length = Math.min(this.length, keys.length);
		for (var i = 0; i < length; i++) obj[keys[i]] = this[i];
		return obj;
	},

	link: function(object){
		var result = {};
		for (var i = 0, l = this.length; i < l; i++){
			for (var key in object){
				if (object[key](this[i])){
					result[key] = this[i];
					delete object[key];
					break;
				}
			}
		}
		return result;
	},

	contains: function(item, from){
		return this.indexOf(item, from) != -1;
	},

	extend: function(array){
		for (var i = 0, j = array.length; i < j; i++) this.push(array[i]);
		return this;
	},

	getLast: function(){
		return (this.length) ? this[this.length - 1] : null;
	},

	getRandom: function(){
		return (this.length) ? this[$random(0, this.length - 1)] : null;
	},

	include: function(item){
		if (!this.contains(item)) this.push(item);
		return this;
	},

	combine: function(array){
		for (var i = 0, l = array.length; i < l; i++) this.include(array[i]);
		return this;
	},

	erase: function(item){
		for (var i = this.length; i--; i){
			if (this[i] === item) this.splice(i, 1);
		}
		return this;
	},

	empty: function(){
		this.length = 0;
		return this;
	},

	flatten: function(){
		var array = [];
		for (var i = 0, l = this.length; i < l; i++){
			var type = $type(this[i]);
			if (!type) continue;
			array = array.concat((type == 'array' || type == 'collection' || type == 'arguments') ? Array.flatten(this[i]) : this[i]);
		}
		return array;
	},

	hexToRgb: function(array){
		if (this.length != 3) return null;
		var rgb = this.map(function(value){
			if (value.length == 1) value += value;
			return value.toInt(16);
		});
		return (array) ? rgb : 'rgb(' + rgb + ')';
	},

	rgbToHex: function(array){
		if (this.length < 3) return null;
		if (this.length == 4 && this[3] == 0 && !array) return 'transparent';
		var hex = [];
		for (var i = 0; i < 3; i++){
			var bit = (this[i] - 0).toString(16);
			hex.push((bit.length == 1) ? '0' + bit : bit);
		}
		return (array) ? hex : '#' + hex.join('');
	}

});

/*
Script: Function.js
	Contains Function Prototypes like create, bind, pass, and delay.

License:
	MIT-style license.
*/

Function.implement({

	extend: function(properties){
		for (var property in properties) this[property] = properties[property];
		return this;
	},

	create: function(options){
		var self = this;
		options = options || {};
		return function(event){
			var args = options.arguments;
			args = (args != undefined) ? $splat(args) : Array.slice(arguments, (options.event) ? 1 : 0);
			if (options.event) args = [event || window.event].extend(args);
			var returns = function(){
				return self.apply(options.bind || null, args);
			};
			if (options.delay) return setTimeout(returns, options.delay);
			if (options.periodical) return setInterval(returns, options.periodical);
			if (options.attempt) return $try(returns);
			return returns();
		};
	},

	pass: function(args, bind){
		return this.create({arguments: args, bind: bind});
	},

	attempt: function(args, bind){
		return this.create({arguments: args, bind: bind, attempt: true})();
	},

	bind: function(bind, args){
		return this.create({bind: bind, arguments: args});
	},

	bindWithEvent: function(bind, args){
		return this.create({bind: bind, event: true, arguments: args});
	},

	delay: function(delay, bind, args){
		return this.create({delay: delay, bind: bind, arguments: args})();
	},

	periodical: function(interval, bind, args){
		return this.create({periodical: interval, bind: bind, arguments: args})();
	},

	run: function(args, bind){
		return this.apply(bind, $splat(args));
	}

});

/*
Script: Number.js
	Contains Number Prototypes like limit, round, times, and ceil.

License:
	MIT-style license.
*/

Number.implement({

	limit: function(min, max){
		return Math.min(max, Math.max(min, this));
	},

	round: function(precision){
		precision = Math.pow(10, precision || 0);
		return Math.round(this * precision) / precision;
	},

	times: function(fn, bind){
		for (var i = 0; i < this; i++) fn.call(bind, i, this);
	},

	toFloat: function(){
		return parseFloat(this);
	},

	toInt: function(base){
		return parseInt(this, base || 10);
	}

});

Number.alias('times', 'each');

(function(math){
	var methods = {};
	math.each(function(name){
		if (!Number[name]) methods[name] = function(){
			return Math[name].apply(null, [this].concat($A(arguments)));
		};
	});
	Number.implement(methods);
})(['abs', 'acos', 'asin', 'atan', 'atan2', 'ceil', 'cos', 'exp', 'floor', 'log', 'max', 'min', 'pow', 'sin', 'sqrt', 'tan']);

/*
Script: String.js
	Contains String Prototypes like camelCase, capitalize, test, and toInt.

License:
	MIT-style license.
*/

String.implement({

	test: function(regex, params){
		return ((typeof regex == 'string') ? new RegExp(regex, params) : regex).test(this);
	},

	contains: function(string, separator){
		return (separator) ? (separator + this + separator).indexOf(separator + string + separator) > -1 : this.indexOf(string) > -1;
	},

	trim: function(){
		return this.replace(/^\s+|\s+$/g, '');
	},

	clean: function(){
		return this.replace(/\s+/g, ' ').trim();
	},

	camelCase: function(){
		return this.replace(/-\D/g, function(match){
			return match.charAt(1).toUpperCase();
		});
	},

	hyphenate: function(){
		return this.replace(/[A-Z]/g, function(match){
			return ('-' + match.charAt(0).toLowerCase());
		});
	},

	capitalize: function(){
		return this.replace(/\b[a-z]/g, function(match){
			return match.toUpperCase();
		});
	},

	escapeRegExp: function(){
		return this.replace(/([-.*+?^${}()|[\]\/\\])/g, '\\$1');
	},

	toInt: function(base){
		return parseInt(this, base || 10);
	},

	toFloat: function(){
		return parseFloat(this);
	},

	hexToRgb: function(array){
		var hex = this.match(/^#?(\w{1,2})(\w{1,2})(\w{1,2})$/);
		return (hex) ? hex.slice(1).hexToRgb(array) : null;
	},

	rgbToHex: function(array){
		var rgb = this.match(/\d{1,3}/g);
		return (rgb) ? rgb.rgbToHex(array) : null;
	},

	stripScripts: function(option){
		var scripts = '';
		var text = this.replace(/<script[^>]*>([\s\S]*?)<\/script>/gi, function(){
			scripts += arguments[1] + '\n';
			return '';
		});
		if (option === true) $exec(scripts);
		else if ($type(option) == 'function') option(scripts, text);
		return text;
	},

	substitute: function(object, regexp){
		return this.replace(regexp || (/\\?\{([^}]+)\}/g), function(match, name){
			if (match.charAt(0) == '\\') return match.slice(1);
			return (object[name] != undefined) ? object[name] : '';
		});
	}

});

/*
Script: Hash.js
	Contains Hash Prototypes. Provides a means for overcoming the JavaScript practical impossibility of extending native Objects.

License:
	MIT-style license.
*/

Hash.implement({

	has: Object.prototype.hasOwnProperty,

	keyOf: function(value){
		for (var key in this){
			if (this.hasOwnProperty(key) && this[key] === value) return key;
		}
		return null;
	},

	hasValue: function(value){
		return (Hash.keyOf(this, value) !== null);
	},

	extend: function(properties){
		Hash.each(properties, function(value, key){
			Hash.set(this, key, value);
		}, this);
		return this;
	},

	combine: function(properties){
		Hash.each(properties, function(value, key){
			Hash.include(this, key, value);
		}, this);
		return this;
	},

	erase: function(key){
		if (this.hasOwnProperty(key)) delete this[key];
		return this;
	},

	get: function(key){
		return (this.hasOwnProperty(key)) ? this[key] : null;
	},

	set: function(key, value){
		if (!this[key] || this.hasOwnProperty(key)) this[key] = value;
		return this;
	},

	empty: function(){
		Hash.each(this, function(value, key){
			delete this[key];
		}, this);
		return this;
	},

	include: function(key, value){
		var k = this[key];
		if (k == undefined) this[key] = value;
		return this;
	},

	map: function(fn, bind){
		var results = new Hash;
		Hash.each(this, function(value, key){
			results.set(key, fn.call(bind, value, key, this));
		}, this);
		return results;
	},

	filter: function(fn, bind){
		var results = new Hash;
		Hash.each(this, function(value, key){
			if (fn.call(bind, value, key, this)) results.set(key, value);
		}, this);
		return results;
	},

	every: function(fn, bind){
		for (var key in this){
			if (this.hasOwnProperty(key) && !fn.call(bind, this[key], key)) return false;
		}
		return true;
	},

	some: function(fn, bind){
		for (var key in this){
			if (this.hasOwnProperty(key) && fn.call(bind, this[key], key)) return true;
		}
		return false;
	},

	getKeys: function(){
		var keys = [];
		Hash.each(this, function(value, key){
			keys.push(key);
		});
		return keys;
	},

	getValues: function(){
		var values = [];
		Hash.each(this, function(value){
			values.push(value);
		});
		return values;
	},
	
	toQueryString: function(base){
		var queryString = [];
		Hash.each(this, function(value, key){
			if (base) key = base + '[' + key + ']';
			var result;
			switch ($type(value)){
				case 'object': result = Hash.toQueryString(value, key); break;
				case 'array':
					var qs = {};
					value.each(function(val, i){
						qs[i] = val;
					});
					result = Hash.toQueryString(qs, key);
				break;
				default: result = key + '=' + encodeURIComponent(value);
			}
			if (value != undefined) queryString.push(result);
		});
		
		return queryString.join('&');
	}

});

Hash.alias({keyOf: 'indexOf', hasValue: 'contains'});

/*
Script: Event.js
	Contains the Event Native, to make the event object completely crossbrowser.

License:
	MIT-style license.
*/

var Event = new Native({

	name: 'Event',

	initialize: function(event, win){
		win = win || window;
		var doc = win.document;
		event = event || win.event;
		if (event.$extended) return event;
		this.$extended = true;
		var type = event.type;
		var target = event.target || event.srcElement;
		while (target && target.nodeType == 3) target = target.parentNode;
		
		if (type.test(/key/)){
			var code = event.which || event.keyCode;
			var key = Event.Keys.keyOf(code);
			if (type == 'keydown'){
				var fKey = code - 111;
				if (fKey > 0 && fKey < 13) key = 'f' + fKey;
			}
			key = key || String.fromCharCode(code).toLowerCase();
		} else if (type.match(/(click|mouse|menu)/i)){
			doc = (!doc.compatMode || doc.compatMode == 'CSS1Compat') ? doc.html : doc.body;
			var page = {
				x: event.pageX || event.clientX + doc.scrollLeft,
				y: event.pageY || event.clientY + doc.scrollTop
			};
			var client = {
				x: (event.pageX) ? event.pageX - win.pageXOffset : event.clientX,
				y: (event.pageY) ? event.pageY - win.pageYOffset : event.clientY
			};
			if (type.match(/DOMMouseScroll|mousewheel/)){
				var wheel = (event.wheelDelta) ? event.wheelDelta / 120 : -(event.detail || 0) / 3;
			}
			var rightClick = (event.which == 3) || (event.button == 2);
			var related = null;
			if (type.match(/over|out/)){
				switch (type){
					case 'mouseover': related = event.relatedTarget || event.fromElement; break;
					case 'mouseout': related = event.relatedTarget || event.toElement;
				}
				if (!(function(){
					while (related && related.nodeType == 3) related = related.parentNode;
					return true;
				}).create({attempt: Browser.Engine.gecko})()) related = false;
			}
		}

		return $extend(this, {
			event: event,
			type: type,
			
			page: page,
			client: client,
			rightClick: rightClick,
			
			wheel: wheel,
			
			relatedTarget: related,
			target: target,
			
			code: code,
			key: key,
			
			shift: event.shiftKey,
			control: event.ctrlKey,
			alt: event.altKey,
			meta: event.metaKey
		});
	}

});

Event.Keys = new Hash({
	'enter': 13,
	'up': 38,
	'down': 40,
	'left': 37,
	'right': 39,
	'esc': 27,
	'space': 32,
	'backspace': 8,
	'tab': 9,
	'delete': 46
});

Event.implement({

	stop: function(){
		return this.stopPropagation().preventDefault();
	},

	stopPropagation: function(){
		if (this.event.stopPropagation) this.event.stopPropagation();
		else this.event.cancelBubble = true;
		return this;
	},

	preventDefault: function(){
		if (this.event.preventDefault) this.event.preventDefault();
		else this.event.returnValue = false;
		return this;
	}

});

/*
Script: Class.js
	Contains the Class Function for easily creating, extending, and implementing reusable Classes.

License:
	MIT-style license.
*/

var Class = new Native({

	name: 'Class',

	initialize: function(properties){
		properties = properties || {};
		var klass = function(empty){
			for (var key in this) this[key] = $unlink(this[key]);
			for (var mutator in Class.Mutators){
				if (!this[mutator]) continue;
				Class.Mutators[mutator](this, this[mutator]);
				delete this[mutator];
			}

			this.constructor = klass;
			if (empty === $empty) return this;
			
			var self = (this.initialize) ? this.initialize.apply(this, arguments) : this;
			if (this.options && this.options.initialize) this.options.initialize.call(this);
			return self;
		};

		$extend(klass, this);
		klass.constructor = Class;
		klass.prototype = properties;
		return klass;
	}

});

Class.implement({

	implement: function(){
		Class.Mutators.Implements(this.prototype, Array.slice(arguments));
		return this;
	}

});

Class.Mutators = {
  
  Implements: function(self, klasses){
  	$splat(klasses).each(function(klass){
  		$extend(self, ($type(klass) == 'class') ? new klass($empty) : klass);
  	});
  },
  
  Extends: function(self, klass){
  	var instance = new klass($empty);
  	delete instance.parent;
  	delete instance.parentOf;

  	for (var key in instance){
  		var current = self[key], previous = instance[key];
  		if (current == undefined){
  			self[key] = previous;
  			continue;
  		}

  		var ctype = $type(current), ptype = $type(previous);
  		if (ctype != ptype) continue;

  		switch (ctype){
  			case 'function': 
  				// this code will be only executed if the current browser does not support function.caller (currently only opera).
  				// we replace the function code with brute force. Not pretty, but it will only be executed if function.caller is not supported.

  				if (!arguments.callee.caller) self[key] = eval('(' + String(current).replace(/\bthis\.parent\(\s*(\))?/g, function(full, close){
  					return 'arguments.callee._parent_.call(this' + (close || ', ');
  				}) + ')');

  				// end "opera" code
  				self[key]._parent_ = previous;
  			  break;
  			case 'object': self[key] = $merge(previous, current);
  		}

  	}

  	self.parent = function(){
  		return arguments.callee.caller._parent_.apply(this, arguments);
  	};

  	self.parentOf = function(descendant){
  		return descendant._parent_.apply(this, Array.slice(arguments, 1));
  	};
  }
  
};


/*
Script: Class.Extras.js
	Contains Utility Classes that can be implemented into your own Classes to ease the execution of many common tasks.

License:
	MIT-style license.
*/

var Chain = new Class({

	chain: function(){
		this.$chain = (this.$chain || []).extend(arguments);
		return this;
	},

	callChain: function(){
		return (this.$chain && this.$chain.length) ? this.$chain.shift().apply(this, arguments) : false;
	},

	clearChain: function(){
		if (this.$chain) this.$chain.empty();
		return this;
	}

});

var Events = new Class({

	addEvent: function(type, fn, internal){
		type = Events.removeOn(type);
		if (fn != $empty){
			this.$events = this.$events || {};
			this.$events[type] = this.$events[type] || [];
			this.$events[type].include(fn);
			if (internal) fn.internal = true;
		}
		return this;
	},

	addEvents: function(events){
		for (var type in events) this.addEvent(type, events[type]);
		return this;
	},

	fireEvent: function(type, args, delay){
		type = Events.removeOn(type);
		if (!this.$events || !this.$events[type]) return this;
		this.$events[type].each(function(fn){
			fn.create({'bind': this, 'delay': delay, 'arguments': args})();
		}, this);
		return this;
	},

	removeEvent: function(type, fn){
		type = Events.removeOn(type);
		if (!this.$events || !this.$events[type]) return this;
		if (!fn.internal) this.$events[type].erase(fn);
		return this;
	},

	removeEvents: function(type){
		for (var e in this.$events){
			if (type && type != e) continue;
			var fns = this.$events[e];
			for (var i = fns.length; i--; i) this.removeEvent(e, fns[i]);
		}
		return this;
	}

});

Events.removeOn = function(string){
	return string.replace(/^on([A-Z])/, function(full, first) {
		return first.toLowerCase();
	});
};

var Options = new Class({

	setOptions: function(){
		this.options = $merge.run([this.options].extend(arguments));
		if (!this.addEvent) return this;
		for (var option in this.options){
			if ($type(this.options[option]) != 'function' || !(/^on[A-Z]/).test(option)) continue;
			this.addEvent(option, this.options[option]);
			delete this.options[option];
		}
		return this;
	}

});

/*
Script: Element.js
	One of the most important items in MooTools. Contains the dollar function, the dollars function, and an handful of cross-browser,
	time-saver methods to let you easily work with HTML Elements.

License:
	MIT-style license.
*/

Document.implement({

	newElement: function(tag, props){
		if (Browser.Engine.trident && props){
			['name', 'type', 'checked'].each(function(attribute){
				if (!props[attribute]) return;
				tag += ' ' + attribute + '="' + props[attribute] + '"';
				if (attribute != 'checked') delete props[attribute];
			});
			tag = '<' + tag + '>';
		}
		return $.element(this.createElement(tag)).set(props);
	},

	newTextNode: function(text){
		return this.createTextNode(text);
	},

	getDocument: function(){
		return this;
	},

	getWindow: function(){
		return this.defaultView || this.parentWindow;
	},

	purge: function(){
		var elements = this.getElementsByTagName('*');
		for (var i = 0, l = elements.length; i < l; i++) Browser.freeMem(elements[i]);
	}

});

var Element = new Native({

	name: 'Element',

	legacy: window.Element,

	initialize: function(tag, props){
		var konstructor = Element.Constructors.get(tag);
		if (konstructor) return konstructor(props);
		if (typeof tag == 'string') return document.newElement(tag, props);
		return $(tag).set(props);
	},

	afterImplement: function(key, value){
		if (!Array[key]) Elements.implement(key, Elements.multi(key));
		Element.Prototype[key] = value;
	}

});

Element.Prototype = {$family: {name: 'element'}};

Element.Constructors = new Hash;

var IFrame = new Native({

	name: 'IFrame',

	generics: false,

	initialize: function(){
		var params = Array.link(arguments, {properties: Object.type, iframe: $defined});
		var props = params.properties || {};
		var iframe = $(params.iframe) || false;
		var onload = props.onload || $empty;
		delete props.onload;
		props.id = props.name = $pick(props.id, props.name, iframe.id, iframe.name, 'IFrame_' + $time());
		iframe = new Element(iframe || 'iframe', props);
		var onFrameLoad = function(){
			var host = $try(function(){
				return iframe.contentWindow.location.host;
			});
			if (host && host == window.location.host){
				var win = new Window(iframe.contentWindow);
				var doc = new Document(iframe.contentWindow.document);
				$extend(win.Element.prototype, Element.Prototype);
			}
			onload.call(iframe.contentWindow, iframe.contentWindow.document);
		};
		(!window.frames[props.id]) ? iframe.addListener('load', onFrameLoad) : onFrameLoad();
		return iframe;
	}

});

var Elements = new Native({

	initialize: function(elements, options){
		options = $extend({ddup: true, cash: true}, options);
		elements = elements || [];
		if (options.ddup || options.cash){
			var uniques = {}, returned = [];
			for (var i = 0, l = elements.length; i < l; i++){
				var el = $.element(elements[i], !options.cash);
				if (options.ddup){
					if (uniques[el.uid]) continue;
					uniques[el.uid] = true;
				}
				returned.push(el);
			}
			elements = returned;
		}
		return (options.cash) ? $extend(elements, this) : elements;
	}

});

Elements.implement({

	filter: function(filter, bind){
		if (!filter) return this;
		return new Elements(Array.filter(this, (typeof filter == 'string') ? function(item){
			return item.match(filter);
		} : filter, bind));
	}

});

Elements.multi = function(property){
	return function(){
		var items = [];
		var elements = true;
		for (var i = 0, j = this.length; i < j; i++){
			var returns = this[i][property].apply(this[i], arguments);
			items.push(returns);
			if (elements) elements = ($type(returns) == 'element');
		}
		return (elements) ? new Elements(items) : items;
	};
};

Window.implement({

	$: function(el, nocash){
		if (el && el.$family && el.uid) return el;
		var type = $type(el);
		return ($[type]) ? $[type](el, nocash, this.document) : null;
	},

	$$: function(selector){
		if (arguments.length == 1 && typeof selector == 'string') return this.document.getElements(selector);
		var elements = [];
		var args = Array.flatten(arguments);
		for (var i = 0, l = args.length; i < l; i++){
			var item = args[i];
			switch ($type(item)){
				case 'element': item = [item]; break;
				case 'string': item = this.document.getElements(item, true); break;
				default: item = false;
			}
			if (item) elements.extend(item);
		}
		return new Elements(elements);
	},

	getDocument: function(){
		return this.document;
	},

	getWindow: function(){
		return this;
	}

});

$.string = function(id, nocash, doc){
	id = doc.getElementById(id);
	return (id) ? $.element(id, nocash) : null;
};

$.element = function(el, nocash){
	$uid(el);
	if (!nocash && !el.$family && !(/^object|embed$/i).test(el.tagName)){
		var proto = Element.Prototype;
		for (var p in proto) el[p] = proto[p];
	};
	return el;
};

$.object = function(obj, nocash, doc){
	if (obj.toElement) return $.element(obj.toElement(doc), nocash);
	return null;
};

$.textnode = $.whitespace = $.window = $.document = $arguments(0);

Native.implement([Element, Document], {

	getElement: function(selector, nocash){
		return $(this.getElements(selector, true)[0] || null, nocash);
	},

	getElements: function(tags, nocash){
		tags = tags.split(',');
		var elements = [];
		var ddup = (tags.length > 1);
		tags.each(function(tag){
			var partial = this.getElementsByTagName(tag.trim());
			(ddup) ? elements.extend(partial) : elements = partial;
		}, this);
		return new Elements(elements, {ddup: ddup, cash: !nocash});
	}

});

Element.Storage = {

	get: function(uid){
		return (this[uid] || (this[uid] = {}));
	}

};

Element.Inserters = new Hash({

	before: function(context, element){
		if (element.parentNode) element.parentNode.insertBefore(context, element);
	},

	after: function(context, element){
		if (!element.parentNode) return;
		var next = element.nextSibling;
		(next) ? element.parentNode.insertBefore(context, next) : element.parentNode.appendChild(context);
	},

	bottom: function(context, element){
		element.appendChild(context);
	},

	top: function(context, element){
		var first = element.firstChild;
		(first) ? element.insertBefore(context, first) : element.appendChild(context);
	}

});

Element.Inserters.inside = Element.Inserters.bottom;

Element.Inserters.each(function(value, key){

	var Key = key.capitalize();

	Element.implement('inject' + Key, function(el){
		value(this, $(el, true));
		return this;
	});

	Element.implement('grab' + Key, function(el){
		value($(el, true), this);
		return this;
	});

});

Element.implement({

	getDocument: function(){
		return this.ownerDocument;
	},

	getWindow: function(){
		return this.ownerDocument.getWindow();
	},

	getElementById: function(id, nocash){
		var el = this.ownerDocument.getElementById(id);
		if (!el) return null;
		for (var parent = el.parentNode; parent != this; parent = parent.parentNode){
			if (!parent) return null;
		}
		return $.element(el, nocash);
	},

	set: function(prop, value){
		switch ($type(prop)){
			case 'object':
				for (var p in prop) this.set(p, prop[p]);
				break;
			case 'string':
				var property = Element.Properties.get(prop);
				(property && property.set) ? property.set.apply(this, Array.slice(arguments, 1)) : this.setProperty(prop, value);
		}
		return this;
	},

	get: function(prop){
		var property = Element.Properties.get(prop);
		return (property && property.get) ? property.get.apply(this, Array.slice(arguments, 1)) : this.getProperty(prop);
	},

	erase: function(prop){
		var property = Element.Properties.get(prop);
		(property && property.erase) ? property.erase.apply(this, Array.slice(arguments, 1)) : this.removeProperty(prop);
		return this;
	},

	match: function(tag){
		return (!tag || Element.get(this, 'tag') == tag);
	},

	inject: function(el, where){
		Element.Inserters.get(where || 'bottom')(this, $(el, true));
		return this;
	},

	wraps: function(el, where){
		el = $(el, true);
		return this.replaces(el).grab(el, where);
	},

	grab: function(el, where){
		Element.Inserters.get(where || 'bottom')($(el, true), this);
		return this;
	},

	appendText: function(text, where){
		return this.grab(this.getDocument().newTextNode(text), where);
	},

	adopt: function(){
		Array.flatten(arguments).each(function(element){
			element = $(element, true);
			if (element) this.appendChild(element);
		}, this);
		return this;
	},

	dispose: function(){
		return (this.parentNode) ? this.parentNode.removeChild(this) : this;
	},

	clone: function(contents, keepid){
		switch ($type(this)){
			case 'element':
				var attributes = {};
				for (var j = 0, l = this.attributes.length; j < l; j++){
					var attribute = this.attributes[j], key = attribute.nodeName.toLowerCase();
					if (Browser.Engine.trident && (/input/i).test(this.tagName) && (/width|height/).test(key)) continue;
					var value = (key == 'style' && this.style) ? this.style.cssText : attribute.nodeValue;
					if (!$chk(value) || key == 'uid' || (key == 'id' && !keepid)) continue;
					if (value != 'inherit' && ['string', 'number'].contains($type(value))) attributes[key] = value;
				}
				var element = new Element(this.nodeName.toLowerCase(), attributes);
				if (contents !== false){
					for (var i = 0, k = this.childNodes.length; i < k; i++){
						var child = Element.clone(this.childNodes[i], true, keepid);
						if (child) element.grab(child);
					}
				}
				return element;
			case 'textnode': return document.newTextNode(this.nodeValue);
		}
		return null;
	},

	replaces: function(el){
		el = $(el, true);
		el.parentNode.replaceChild(this, el);
		return this;
	},

	hasClass: function(className){
		return this.className.contains(className, ' ');
	},

	addClass: function(className){
		if (!this.hasClass(className)) this.className = (this.className + ' ' + className).clean();
		return this;
	},

	removeClass: function(className){
		this.className = this.className.replace(new RegExp('(^|\\s)' + className + '(?:\\s|$)'), '$1').clean();
		return this;
	},

	toggleClass: function(className){
		return this.hasClass(className) ? this.removeClass(className) : this.addClass(className);
	},

	getComputedStyle: function(property){
		if (this.currentStyle) return this.currentStyle[property.camelCase()];
		var computed = this.getWindow().getComputedStyle(this, null);
		return (computed) ? computed.getPropertyValue([property.hyphenate()]) : null;
	},

	empty: function(){
		$A(this.childNodes).each(function(node){
			Browser.freeMem(node);
			Element.empty(node);
			Element.dispose(node);
		}, this);
		return this;
	},

	destroy: function(){
		Browser.freeMem(this.empty().dispose());
		return null;
	},

	getSelected: function(){
		return new Elements($A(this.options).filter(function(option){
			return option.selected;
		}));
	},

	toQueryString: function(){
		var queryString = [];
		this.getElements('input, select, textarea').each(function(el){
			if (!el.name || el.disabled) return;
			var value = (el.tagName.toLowerCase() == 'select') ? Element.getSelected(el).map(function(opt){
				return opt.value;
			}) : ((el.type == 'radio' || el.type == 'checkbox') && !el.checked) ? null : el.value;
			$splat(value).each(function(val){
				if (val) queryString.push(el.name + '=' + encodeURIComponent(val));
			});
		});
		return queryString.join('&');
	},

	getProperty: function(attribute){
		var EA = Element.Attributes, key = EA.Props[attribute];
		var value = (key) ? this[key] : this.getAttribute(attribute, 2);
		return (EA.Bools[attribute]) ? !!value : (key) ? value : value || null;
	},

	getProperties: function(){
		var args = $A(arguments);
		return args.map(function(attr){
			return this.getProperty(attr);
		}, this).associate(args);
	},

	setProperty: function(attribute, value){
		var EA = Element.Attributes, key = EA.Props[attribute], hasValue = $defined(value);
		if (key && EA.Bools[attribute]) value = (value || !hasValue) ? true : false;
		else if (!hasValue) return this.removeProperty(attribute);
		(key) ? this[key] = value : this.setAttribute(attribute, value);
		return this;
	},

	setProperties: function(attributes){
		for (var attribute in attributes) this.setProperty(attribute, attributes[attribute]);
		return this;
	},

	removeProperty: function(attribute){
		var EA = Element.Attributes, key = EA.Props[attribute], isBool = (key && EA.Bools[attribute]);
		(key) ? this[key] = (isBool) ? false : '' : this.removeAttribute(attribute);
		return this;
	},

	removeProperties: function(){
		Array.each(arguments, this.removeProperty, this);
		return this;
	}

});

(function(){

var walk = function(element, walk, start, match, all, nocash){
	var el = element[start || walk];
	var elements = [];
	while (el){
		if (el.nodeType == 1 && (!match || Element.match(el, match))){
			elements.push(el);
			if (!all) break;
		}
		el = el[walk];
	}
	return (all) ? new Elements(elements, {ddup: false, cash: !nocash}) : $(elements[0], nocash);
};

Element.implement({

	getPrevious: function(match, nocash){
		return walk(this, 'previousSibling', null, match, false, nocash);
	},

	getAllPrevious: function(match, nocash){
		return walk(this, 'previousSibling', null, match, true, nocash);
	},

	getNext: function(match, nocash){
		return walk(this, 'nextSibling', null, match, false, nocash);
	},

	getAllNext: function(match, nocash){
		return walk(this, 'nextSibling', null, match, true, nocash);
	},

	getFirst: function(match, nocash){
		return walk(this, 'nextSibling', 'firstChild', match, false, nocash);
	},

	getLast: function(match, nocash){
		return walk(this, 'previousSibling', 'lastChild', match, false, nocash);
	},

	getParent: function(match, nocash){
		return walk(this, 'parentNode', null, match, false, nocash);
	},

	getParents: function(match, nocash){
		return walk(this, 'parentNode', null, match, true, nocash);
	},

	getChildren: function(match, nocash){
		return walk(this, 'nextSibling', 'firstChild', match, true, nocash);
	},

	hasChild: function(el){
		el = $(el, true);
		return (!!el && $A(this.getElementsByTagName(el.tagName)).contains(el));
	}

});

})();

Element.Properties = new Hash;

Element.Properties.style = {

	set: function(style){
		this.style.cssText = style;
	},

	get: function(){
		return this.style.cssText;
	},

	erase: function(){
		this.style.cssText = '';
	}

};

Element.Properties.tag = {get: function(){
	return this.tagName.toLowerCase();
}};

Element.Properties.href = {get: function(){
	return (!this.href) ? null : this.href.replace(new RegExp('^' + document.location.protocol + '\/\/' + document.location.host), '');
}};

Element.Properties.html = {set: function(){
	return this.innerHTML = Array.flatten(arguments).join('');
}};

Native.implement([Element, Window, Document], {

	addListener: function(type, fn){
		if (this.addEventListener) this.addEventListener(type, fn, false);
		else this.attachEvent('on' + type, fn);
		return this;
	},

	removeListener: function(type, fn){
		if (this.removeEventListener) this.removeEventListener(type, fn, false);
		else this.detachEvent('on' + type, fn);
		return this;
	},

	retrieve: function(property, dflt){
		var storage = Element.Storage.get(this.uid);
		var prop = storage[property];
		if ($defined(dflt) && !$defined(prop)) prop = storage[property] = dflt;
		return $pick(prop);
	},

	store: function(property, value){
		var storage = Element.Storage.get(this.uid);
		storage[property] = value;
		return this;
	},

	eliminate: function(property){
		var storage = Element.Storage.get(this.uid);
		delete storage[property];
		return this;
	}

});

Element.Attributes = new Hash({
	Props: {'html': 'innerHTML', 'class': 'className', 'for': 'htmlFor', 'text': (Browser.Engine.trident) ? 'innerText' : 'textContent'},
	Bools: ['compact', 'nowrap', 'ismap', 'declare', 'noshade', 'checked', 'disabled', 'readonly', 'multiple', 'selected', 'noresize', 'defer'],
	Camels: ['value', 'accessKey', 'cellPadding', 'cellSpacing', 'colSpan', 'frameBorder', 'maxLength', 'readOnly', 'rowSpan', 'tabIndex', 'useMap']
});

Browser.freeMem = function(item){
	if (!item) return;
	if (Browser.Engine.trident && (/object/i).test(item.tagName)){
		for (var p in item){
			if (typeof item[p] == 'function') item[p] = $empty;
		}
		Element.dispose(item);
	}
	if (item.uid && item.removeEvents) item.removeEvents();
};

(function(EA){

	var EAB = EA.Bools, EAC = EA.Camels;
	EA.Bools = EAB = EAB.associate(EAB);
	Hash.extend(Hash.combine(EA.Props, EAB), EAC.associate(EAC.map(function(v){
		return v.toLowerCase();
	})));
	EA.erase('Camels');

})(Element.Attributes);

window.addListener('unload', function(){
	window.removeListener('unload', arguments.callee);
	document.purge();
	if (Browser.Engine.trident) CollectGarbage();
});

/*
Script: Element.Event.js
	Contains Element methods for dealing with events, and custom Events.

License:
	MIT-style license.
*/

Element.Properties.events = {set: function(events){
	this.addEvents(events);
}};

Native.implement([Element, Window, Document], {

	addEvent: function(type, fn){
		var events = this.retrieve('events', {});
		events[type] = events[type] || {'keys': [], 'values': []};
		if (events[type].keys.contains(fn)) return this;
		events[type].keys.push(fn);
		var realType = type, custom = Element.Events.get(type), condition = fn, self = this;
		if (custom){
			if (custom.onAdd) custom.onAdd.call(this, fn);
			if (custom.condition){
				condition = function(event){
					if (custom.condition.call(this, event)) return fn.call(this, event);
					return false;
				};
			}
			realType = custom.base || realType;
		}
		var defn = function(){
			return fn.call(self);
		};
		var nativeEvent = Element.NativeEvents[realType] || 0;
		if (nativeEvent){
			if (nativeEvent == 2){
				defn = function(event){
					event = new Event(event, self.getWindow());
					if (condition.call(self, event) === false) event.stop();
				};
			}
			this.addListener(realType, defn);
		}
		events[type].values.push(defn);
		return this;
	},

	removeEvent: function(type, fn){
		var events = this.retrieve('events');
		if (!events || !events[type]) return this;
		var pos = events[type].keys.indexOf(fn);
		if (pos == -1) return this;
		var key = events[type].keys.splice(pos, 1)[0];
		var value = events[type].values.splice(pos, 1)[0];
		var custom = Element.Events.get(type);
		if (custom){
			if (custom.onRemove) custom.onRemove.call(this, fn);
			type = custom.base || type;
		}
		return (Element.NativeEvents[type]) ? this.removeListener(type, value) : this;
	},

	addEvents: function(events){
		for (var event in events) this.addEvent(event, events[event]);
		return this;
	},

	removeEvents: function(type){
		var events = this.retrieve('events');
		if (!events) return this;
		if (!type){
			for (var evType in events) this.removeEvents(evType);
			events = null;
		} else if (events[type]){
			while (events[type].keys[0]) this.removeEvent(type, events[type].keys[0]);
			events[type] = null;
		}
		return this;
	},

	fireEvent: function(type, args, delay){
		var events = this.retrieve('events');
		if (!events || !events[type]) return this;
		events[type].keys.each(function(fn){
			fn.create({'bind': this, 'delay': delay, 'arguments': args})();
		}, this);
		return this;
	},

	cloneEvents: function(from, type){
		from = $(from);
		var fevents = from.retrieve('events');
		if (!fevents) return this;
		if (!type){
			for (var evType in fevents) this.cloneEvents(from, evType);
		} else if (fevents[type]){
			fevents[type].keys.each(function(fn){
				this.addEvent(type, fn);
			}, this);
		}
		return this;
	}

});

Element.NativeEvents = {
	click: 2, dblclick: 2, mouseup: 2, mousedown: 2, contextmenu: 2, //mouse buttons
	mousewheel: 2, DOMMouseScroll: 2, //mouse wheel
	mouseover: 2, mouseout: 2, mousemove: 2, selectstart: 2, selectend: 2, //mouse movement
	keydown: 2, keypress: 2, keyup: 2, //keyboard
	focus: 2, blur: 2, change: 2, reset: 2, select: 2, submit: 2, //form elements
	load: 1, unload: 1, beforeunload: 2, resize: 1, move: 1, DOMContentLoaded: 1, readystatechange: 1, //window
	error: 1, abort: 1, scroll: 1 //misc
};

(function(){

var $check = function(event){
	var related = event.relatedTarget;
	if (related == undefined) return true;
	if (related === false) return false;
	return ($type(this) != 'document' && related != this && related.prefix != 'xul' && !this.hasChild(related));
};

Element.Events = new Hash({

	mouseenter: {
		base: 'mouseover',
		condition: $check
	},

	mouseleave: {
		base: 'mouseout',
		condition: $check
	},

	mousewheel: {
		base: (Browser.Engine.gecko) ? 'DOMMouseScroll' : 'mousewheel'
	}

});

})();

/*
Script: Element.Style.js
	Contains methods for interacting with the styles of Elements in a fashionable way.

License:
	MIT-style license.
*/

Element.Properties.styles = {set: function(styles){
	this.setStyles(styles);
}};

Element.Properties.opacity = {

	set: function(opacity, novisibility){
		if (!novisibility){
			if (opacity == 0){
				if (this.style.visibility != 'hidden') this.style.visibility = 'hidden';
			} else {
				if (this.style.visibility != 'visible') this.style.visibility = 'visible';
			}
		}
		if (!this.currentStyle || !this.currentStyle.hasLayout) this.style.zoom = 1;
		if (Browser.Engine.trident) this.style.filter = (opacity == 1) ? '' : 'alpha(opacity=' + opacity * 100 + ')';
		this.style.opacity = opacity;
		this.store('opacity', opacity);
	},

	get: function(){
		return this.retrieve('opacity', 1);
	}

};

Element.implement({
	
	setOpacity: function(value){
		return this.set('opacity', value, true);
	},
	
	getOpacity: function(){
		return this.get('opacity');
	},

	setStyle: function(property, value){
		switch (property){
			case 'opacity': return this.set('opacity', parseFloat(value));
			case 'float': property = (Browser.Engine.trident) ? 'styleFloat' : 'cssFloat';
		}
		property = property.camelCase();
		if ($type(value) != 'string'){
			var map = (Element.Styles.get(property) || '@').split(' ');
			value = $splat(value).map(function(val, i){
				if (!map[i]) return '';
				return ($type(val) == 'number') ? map[i].replace('@', Math.round(val)) : val;
			}).join(' ');
		} else if (value == String(Number(value))){
			value = Math.round(value);
		}
		this.style[property] = value;
		return this;
	},

	getStyle: function(property){
		switch (property){
			case 'opacity': return this.get('opacity');
			case 'float': property = (Browser.Engine.trident) ? 'styleFloat' : 'cssFloat';
		}
		property = property.camelCase();
		var result = this.style[property];
		if (!$chk(result)){
			result = [];
			for (var style in Element.ShortStyles){
				if (property != style) continue;
				for (var s in Element.ShortStyles[style]) result.push(this.getStyle(s));
				return result.join(' ');
			}
			result = this.getComputedStyle(property);
		}
		if (result){
			result = String(result);
			var color = result.match(/rgba?\([\d\s,]+\)/);
			if (color) result = result.replace(color[0], color[0].rgbToHex());
		}
		if (Browser.Engine.presto || (Browser.Engine.trident && !$chk(parseInt(result)))){
			if (property.test(/^(height|width)$/)){
				var values = (property == 'width') ? ['left', 'right'] : ['top', 'bottom'], size = 0;
				values.each(function(value){
					size += this.getStyle('border-' + value + '-width').toInt() + this.getStyle('padding-' + value).toInt();
				}, this);
				return this['offset' + property.capitalize()] - size + 'px';
			}
			if (Browser.Engine.presto && String(result).test('px')) return result;
			if (property.test(/(border(.+)Width|margin|padding)/)) return '0px';
		}
		return result;
	},

	setStyles: function(styles){
		for (var style in styles) this.setStyle(style, styles[style]);
		return this;
	},

	getStyles: function(){
		var result = {};
		Array.each(arguments, function(key){
			result[key] = this.getStyle(key);
		}, this);
		return result;
	}

});

Element.Styles = new Hash({
	left: '@px', top: '@px', bottom: '@px', right: '@px',
	width: '@px', height: '@px', maxWidth: '@px', maxHeight: '@px', minWidth: '@px', minHeight: '@px',
	backgroundColor: 'rgb(@, @, @)', backgroundPosition: '@px @px', color: 'rgb(@, @, @)',
	fontSize: '@px', letterSpacing: '@px', lineHeight: '@px', clip: 'rect(@px @px @px @px)',
	margin: '@px @px @px @px', padding: '@px @px @px @px', border: '@px @ rgb(@, @, @) @px @ rgb(@, @, @) @px @ rgb(@, @, @)',
	borderWidth: '@px @px @px @px', borderStyle: '@ @ @ @', borderColor: 'rgb(@, @, @) rgb(@, @, @) rgb(@, @, @) rgb(@, @, @)',
	zIndex: '@', 'zoom': '@', fontWeight: '@', textIndent: '@px', opacity: '@'
});

Element.ShortStyles = {margin: {}, padding: {}, border: {}, borderWidth: {}, borderStyle: {}, borderColor: {}};

['Top', 'Right', 'Bottom', 'Left'].each(function(direction){
	var Short = Element.ShortStyles;
	var All = Element.Styles;
	['margin', 'padding'].each(function(style){
		var sd = style + direction;
		Short[style][sd] = All[sd] = '@px';
	});
	var bd = 'border' + direction;
	Short.border[bd] = All[bd] = '@px @ rgb(@, @, @)';
	var bdw = bd + 'Width', bds = bd + 'Style', bdc = bd + 'Color';
	Short[bd] = {};
	Short.borderWidth[bdw] = Short[bd][bdw] = All[bdw] = '@px';
	Short.borderStyle[bds] = Short[bd][bds] = All[bds] = '@';
	Short.borderColor[bdc] = Short[bd][bdc] = All[bdc] = 'rgb(@, @, @)';
});


/*
Script: Element.Dimensions.js
	Contains methods to work with size, scroll, or positioning of Elements and the window object.

License:
	MIT-style license.

Credits:
	- Element positioning based on the [qooxdoo](http://qooxdoo.org/) code and smart browser fixes, [LGPL License](http://www.gnu.org/licenses/lgpl.html).
	- Viewport dimensions based on [YUI](http://developer.yahoo.com/yui/) code, [BSD License](http://developer.yahoo.com/yui/license.html).
*/

(function(){

Element.implement({

	scrollTo: function(x, y){
		if (isBody(this)){
			this.getWindow().scrollTo(x, y);
		} else {
			this.scrollLeft = x;
			this.scrollTop = y;
		}
		return this;
	},

	getSize: function(){
		if (isBody(this)) return this.getWindow().getSize();
		return {x: this.offsetWidth, y: this.offsetHeight};
	},

	getScrollSize: function(){
		if (isBody(this)) return this.getWindow().getScrollSize();
		return {x: this.scrollWidth, y: this.scrollHeight};
	},

	getScroll: function(){
		if (isBody(this)) return this.getWindow().getScroll();
		return {x: this.scrollLeft, y: this.scrollTop};
	},

	getScrolls: function(){
		var element = this, position = {x: 0, y: 0};
		while (element && !isBody(element)){
			position.x += element.scrollLeft;
			position.y += element.scrollTop;
			element = element.parentNode;
		}
		return position;
	},
	
	getOffsetParent: function(){
		var element = this;
		if (isBody(element)) return null; 
		if (!Browser.Engine.trident) return element.offsetParent;
		while ((element = element.parentNode) && !isBody(element)){ 
			if (styleString(element, 'position') != 'static') return element;
		} 
		return null;
	},

	getOffsets: function(){
		var element = this, position = {x: 0, y: 0};
		if (isBody(this)) return position;

		while (element && !isBody(element)){
			position.x += element.offsetLeft;
			position.y += element.offsetTop;

			if (Browser.Engine.gecko){
				if (!borderBox(element)){
					position.x += leftBorder(element);
					position.y += topBorder(element);
				}
				var parent = element.parentNode;
				if (parent && styleString(parent, 'overflow') != 'visible'){
					position.x += leftBorder(parent);
					position.y += topBorder(parent);
				}
			} else if (element != this && (Browser.Engine.trident || Browser.Engine.webkit)){
				position.x += leftBorder(element);
				position.y += topBorder(element);
			}

			element = element.offsetParent;
			if (Browser.Engine.trident){
				while (element && !element.currentStyle.hasLayout) element = element.offsetParent;
			}
		}
		if (Browser.Engine.gecko && !borderBox(this)){
			position.x -= leftBorder(this);
			position.y -= topBorder(this);
		}
		return position;
	},

	getPosition: function(relative){
		if (isBody(this)) return {x: 0, y: 0};
		var offset = this.getOffsets(), scroll = this.getScrolls();
		var position = {x: offset.x - scroll.x, y: offset.y - scroll.y};
		var relativePosition = (relative && (relative = $(relative))) ? relative.getPosition() : {x: 0, y: 0};
		return {x: position.x - relativePosition.x, y: position.y - relativePosition.y};
	},

	getCoordinates: function(element){
		if (isBody(this)) return this.getWindow().getCoordinates();
		var position = this.getPosition(element), size = this.getSize();
		var obj = {left: position.x, top: position.y, width: size.x, height: size.y};
		obj.right = obj.left + obj.width;
		obj.bottom = obj.top + obj.height;
		return obj;
	},

	computePosition: function(obj){
		return {left: obj.x - styleNumber(this, 'margin-left'), top: obj.y - styleNumber(this, 'margin-top')};
	},

	position: function(obj){
		return this.setStyles(this.computePosition(obj));
	}

});

Native.implement([Document, Window], {

	getSize: function(){
		var win = this.getWindow();
		if (Browser.Engine.presto || Browser.Engine.webkit) return {x: win.innerWidth, y: win.innerHeight};
		var doc = getCompatElement(this);
		return {x: doc.clientWidth, y: doc.clientHeight};
	},

	getScroll: function(){
		var win = this.getWindow();
		var doc = getCompatElement(this);
		return {x: win.pageXOffset || doc.scrollLeft, y: win.pageYOffset || doc.scrollTop};
	},

	getScrollSize: function(){
		var doc = getCompatElement(this);
		var min = this.getSize();
		return {x: Math.max(doc.scrollWidth, min.x), y: Math.max(doc.scrollHeight, min.y)};
	},

	getPosition: function(){
		return {x: 0, y: 0};
	},

	getCoordinates: function(){
		var size = this.getSize();
		return {top: 0, left: 0, bottom: size.y, right: size.x, height: size.y, width: size.x};
	}

});

// private methods

var styleString = Element.getComputedStyle;

function styleNumber(element, style){
	return styleString(element, style).toInt() || 0;
};

function borderBox(element){
	return styleString(element, '-moz-box-sizing') == 'border-box';
};

function topBorder(element){
	return styleNumber(element, 'border-top-width');
};

function leftBorder(element){
	return styleNumber(element, 'border-left-width');
};

function isBody(element){
	return (/^(?:body|html)$/i).test(element.tagName);
};

function getCompatElement(element){
	var doc = element.getDocument();
	return (!doc.compatMode || doc.compatMode == 'CSS1Compat') ? doc.html : doc.body;
};

})();

//aliases

Native.implement([Window, Document, Element], {

	getHeight: function(){
		return this.getSize().y;
	},

	getWidth: function(){
		return this.getSize().x;
	},

	getScrollTop: function(){
		return this.getScroll().y;
	},

	getScrollLeft: function(){
		return this.getScroll().x;
	},

	getScrollHeight: function(){
		return this.getScrollSize().y;
	},

	getScrollWidth: function(){
		return this.getScrollSize().x;
	},

	getTop: function(){
		return this.getPosition().y;
	},

	getLeft: function(){
		return this.getPosition().x;
	}

});

/*
Script: Selectors.js
	Adds advanced CSS Querying capabilities for targeting elements. Also includes pseudoselectors support.

License:
	MIT-style license.
*/

Native.implement([Document, Element], {
	
	getElements: function(expression, nocash){
		expression = expression.split(',');
		var items, local = {};
		for (var i = 0, l = expression.length; i < l; i++){
			var selector = expression[i], elements = Selectors.Utils.search(this, selector, local);
			if (i != 0 && elements.item) elements = $A(elements);
			items = (i == 0) ? elements : (items.item) ? $A(items).concat(elements) : items.concat(elements);
		}
		return new Elements(items, {ddup: (expression.length > 1), cash: !nocash});
	}
	
});

Element.implement({
	
	match: function(selector){
		if (!selector) return true;
		var tagid = Selectors.Utils.parseTagAndID(selector);
		var tag = tagid[0], id = tagid[1];
		if (!Selectors.Filters.byID(this, id) || !Selectors.Filters.byTag(this, tag)) return false;
		var parsed = Selectors.Utils.parseSelector(selector);
		return (parsed) ? Selectors.Utils.filter(this, parsed, {}) : true;
	}
	
});

var Selectors = {Cache: {nth: {}, parsed: {}}};

Selectors.RegExps = {
	id: (/#([\w-]+)/),
	tag: (/^(\w+|\*)/),
	quick: (/^(\w+|\*)$/),
	splitter: (/\s*([+>~\s])\s*([a-zA-Z#.*:\[])/g),
	combined: (/\.([\w-]+)|\[(\w+)(?:([!*^$~|]?=)["']?(.*?)["']?)?\]|:([\w-]+)(?:\(["']?(.*?)?["']?\)|$)/g)
};

Selectors.Utils = {
	
	chk: function(item, uniques){
		if (!uniques) return true;
		var uid = $uid(item);
		if (!uniques[uid]) return uniques[uid] = true;
		return false;
	},
	
	parseNthArgument: function(argument){
		if (Selectors.Cache.nth[argument]) return Selectors.Cache.nth[argument];
		var parsed = argument.match(/^([+-]?\d*)?([a-z]+)?([+-]?\d*)?$/);
		if (!parsed) return false;
		var inta = parseInt(parsed[1]);
		var a = (inta || inta === 0) ? inta : 1;
		var special = parsed[2] || false;
		var b = parseInt(parsed[3]) || 0;
		if (a != 0){
			b--;
			while (b < 1) b += a;
			while (b >= a) b -= a;
		} else {
			a = b;
			special = 'index';
		}
		switch (special){
			case 'n': parsed = {a: a, b: b, special: 'n'}; break;
			case 'odd': parsed = {a: 2, b: 0, special: 'n'}; break;
			case 'even': parsed =  {a: 2, b: 1, special: 'n'}; break;
			case 'first': parsed = {a: 0, special: 'index'}; break;
			case 'last': parsed = {special: 'last-child'}; break;
			case 'only': parsed = {special: 'only-child'}; break;
			default: parsed = {a: (a - 1), special: 'index'};
		}
		
		return Selectors.Cache.nth[argument] = parsed;
	},
	
	parseSelector: function(selector){
		if (Selectors.Cache.parsed[selector]) return Selectors.Cache.parsed[selector];
		var m, parsed = {classes: [], pseudos: [], attributes: []};
		while ((m = Selectors.RegExps.combined.exec(selector))){
			var cn = m[1], an = m[2], ao = m[3], av = m[4], pn = m[5], pa = m[6];
			if (cn){
				parsed.classes.push(cn);
			} else if (pn){
				var parser = Selectors.Pseudo.get(pn);
				if (parser) parsed.pseudos.push({parser: parser, argument: pa});
				else parsed.attributes.push({name: pn, operator: '=', value: pa});
			} else if (an){
				parsed.attributes.push({name: an, operator: ao, value: av});
			}
		}
		if (!parsed.classes.length) delete parsed.classes;
		if (!parsed.attributes.length) delete parsed.attributes;
		if (!parsed.pseudos.length) delete parsed.pseudos;
		if (!parsed.classes && !parsed.attributes && !parsed.pseudos) parsed = null;
		return Selectors.Cache.parsed[selector] = parsed;
	},
	
	parseTagAndID: function(selector){
		var tag = selector.match(Selectors.RegExps.tag);
		var id = selector.match(Selectors.RegExps.id);
		return [(tag) ? tag[1] : '*', (id) ? id[1] : false];
	},
	
	filter: function(item, parsed, local){
		var i;
		if (parsed.classes){
			for (i = parsed.classes.length; i--; i){
				var cn = parsed.classes[i];
				if (!Selectors.Filters.byClass(item, cn)) return false;
			}
		}
		if (parsed.attributes){
			for (i = parsed.attributes.length; i--; i){
				var att = parsed.attributes[i];
				if (!Selectors.Filters.byAttribute(item, att.name, att.operator, att.value)) return false;
			}
		}
		if (parsed.pseudos){
			for (i = parsed.pseudos.length; i--; i){
				var psd = parsed.pseudos[i];
				if (!Selectors.Filters.byPseudo(item, psd.parser, psd.argument, local)) return false;
			}
		}
		return true;
	},
	
	getByTagAndID: function(ctx, tag, id){
		if (id){
			var item = (ctx.getElementById) ? ctx.getElementById(id, true) : Element.getElementById(ctx, id, true);
			return (item && Selectors.Filters.byTag(item, tag)) ? [item] : [];
		} else {
			return ctx.getElementsByTagName(tag);
		}
	},
	
	search: function(self, expression, local){
		var splitters = [];
		
		var selectors = expression.trim().replace(Selectors.RegExps.splitter, function(m0, m1, m2){
			splitters.push(m1);
			return ':)' + m2;
		}).split(':)');
		
		var items, match, filtered, item;
		
		for (var i = 0, l = selectors.length; i < l; i++){
			
			var selector = selectors[i];
			
			if (i == 0 && Selectors.RegExps.quick.test(selector)){
				items = self.getElementsByTagName(selector);
				continue;
			}
			
			var splitter = splitters[i - 1];
			
			var tagid = Selectors.Utils.parseTagAndID(selector);
			var tag = tagid[0], id = tagid[1];

			if (i == 0){
				items = Selectors.Utils.getByTagAndID(self, tag, id);
			} else {
				var uniques = {}, found = [];
				for (var j = 0, k = items.length; j < k; j++) found = Selectors.Getters[splitter](found, items[j], tag, id, uniques);
				items = found;
			}
			
			var parsed = Selectors.Utils.parseSelector(selector);
			
			if (parsed){
				filtered = [];
				for (var m = 0, n = items.length; m < n; m++){
					item = items[m];
					if (Selectors.Utils.filter(item, parsed, local)) filtered.push(item);
				}
				items = filtered;
			}
			
		}
		
		return items;
		
	}
	
};

Selectors.Getters = {
	
	' ': function(found, self, tag, id, uniques){
		var items = Selectors.Utils.getByTagAndID(self, tag, id);
		for (var i = 0, l = items.length; i < l; i++){
			var item = items[i];
			if (Selectors.Utils.chk(item, uniques)) found.push(item);
		}
		return found;
	},
	
	'>': function(found, self, tag, id, uniques){
		var children = Selectors.Utils.getByTagAndID(self, tag, id);
		for (var i = 0, l = children.length; i < l; i++){
			var child = children[i];
			if (child.parentNode == self && Selectors.Utils.chk(child, uniques)) found.push(child);
		}
		return found;
	},
	
	'+': function(found, self, tag, id, uniques){
		while ((self = self.nextSibling)){
			if (self.nodeType == 1){
				if (Selectors.Utils.chk(self, uniques) && Selectors.Filters.byTag(self, tag) && Selectors.Filters.byID(self, id)) found.push(self);
				break;
			}
		}
		return found;
	},
	
	'~': function(found, self, tag, id, uniques){
		
		while ((self = self.nextSibling)){
			if (self.nodeType == 1){
				if (!Selectors.Utils.chk(self, uniques)) break;
				if (Selectors.Filters.byTag(self, tag) && Selectors.Filters.byID(self, id)) found.push(self);
			} 
		}
		return found;
	}
	
};

Selectors.Filters = {
	
	byTag: function(self, tag){
		return (tag == '*' || (self.tagName && self.tagName.toLowerCase() == tag));
	},
	
	byID: function(self, id){
		return (!id || (self.id && self.id == id));
	},
	
	byClass: function(self, klass){
		return (self.className && self.className.contains(klass, ' '));
	},
	
	byPseudo: function(self, parser, argument, local){
		return parser.call(self, argument, local);
	},
	
	byAttribute: function(self, name, operator, value){
		var result = Element.prototype.getProperty.call(self, name);
		if (!result) return false;
		if (!operator || value == undefined) return true;
		switch (operator){
			case '=': return (result == value);
			case '*=': return (result.contains(value));
			case '^=': return (result.substr(0, value.length) == value);
			case '$=': return (result.substr(result.length - value.length) == value);
			case '!=': return (result != value);
			case '~=': return result.contains(value, ' ');
			case '|=': return result.contains(value, '-');
		}
		return false;
	}
	
};

Selectors.Pseudo = new Hash({
	
	// w3c pseudo selectors
	
	empty: function(){
		return !(this.innerText || this.textContent || '').length;
	},
	
	not: function(selector){
		return !Element.match(this, selector);
	},
	
	contains: function(text){
		return (this.innerText || this.textContent || '').contains(text);
	},
	
	'first-child': function(){
		return Selectors.Pseudo.index.call(this, 0);
	},
	
	'last-child': function(){
		var element = this;
		while ((element = element.nextSibling)){
			if (element.nodeType == 1) return false;
		}
		return true;
	},
	
	'only-child': function(){
		var prev = this;
		while ((prev = prev.previousSibling)){
			if (prev.nodeType == 1) return false;
		}
		var next = this;
		while ((next = next.nextSibling)){
			if (next.nodeType == 1) return false;
		}
		return true;
	},
	
	'nth-child': function(argument, local){
		argument = (argument == undefined) ? 'n' : argument;
		var parsed = Selectors.Utils.parseNthArgument(argument);
		if (parsed.special != 'n') return Selectors.Pseudo[parsed.special].call(this, parsed.a, local);
		var count = 0;
		local.positions = local.positions || {};
		var uid = $uid(this);
		if (!local.positions[uid]){
			var self = this;
			while ((self = self.previousSibling)){
				if (self.nodeType != 1) continue;
				count ++;
				var position = local.positions[$uid(self)];
				if (position != undefined){
					count = position + count;
					break;
				}
			}
			local.positions[uid] = count;
		}
		return (local.positions[uid] % parsed.a == parsed.b);
	},
	
	// custom pseudo selectors
	
	index: function(index){
		var element = this, count = 0;
		while ((element = element.previousSibling)){
			if (element.nodeType == 1 && ++count > index) return false;
		}
		return (count == index);
	},
	
	even: function(argument, local){
		return Selectors.Pseudo['nth-child'].call(this, '2n+1', local);
	},

	odd: function(argument, local){
		return Selectors.Pseudo['nth-child'].call(this, '2n', local);
	}
	
});

/*
Script: Domready.js
	Contains the domready custom event.

License:
	MIT-style license.
*/

Element.Events.domready = {

	onAdd: function(fn){
		if (Browser.loaded) fn.call(this);
	}

};

(function(){
	
	var domready = function(){
		if (Browser.loaded) return;
		Browser.loaded = true;
		window.fireEvent('domready');
		document.fireEvent('domready');
	};
	
	switch (Browser.Engine.name){

		case 'webkit': (function(){
			(['loaded', 'complete'].contains(document.readyState)) ? domready() : arguments.callee.delay(50);
		})(); break;

		case 'trident':
			var temp = document.createElement('div');
			(function(){
				($try(function(){
					temp.doScroll('left');
					return $(temp).inject(document.body).set('html', 'temp').dispose();
				})) ? domready() : arguments.callee.delay(50);
			})();
		break;
		
		default:
			window.addEvent('load', domready);
			document.addEvent('DOMContentLoaded', domready);

	}
	
})();

/*
Script: JSON.js
	JSON encoder and decoder.

License:
	MIT-style license.

See Also:
	<http://www.json.org/>
*/

var JSON = new Hash({

	encode: function(obj){
		switch ($type(obj)){
			case 'string':
				return '"' + obj.replace(/[\x00-\x1f\\"]/g, JSON.$replaceChars) + '"';
			case 'array':
				return '[' + String(obj.map(JSON.encode).filter($defined)) + ']';
			case 'object': case 'hash':
				var string = [];
				Hash.each(obj, function(value, key){
					var json = JSON.encode(value);
					if (json) string.push(JSON.encode(key) + ':' + json);
				});
				return '{' + string + '}';
			case 'number': case 'boolean': return String(obj);
			case false: return 'null';
		}
		return null;
	},

	$specialChars: {'\b': '\\b', '\t': '\\t', '\n': '\\n', '\f': '\\f', '\r': '\\r', '"' : '\\"', '\\': '\\\\'},

	$replaceChars: function(chr){
		return JSON.$specialChars[chr] || '\\u00' + Math.floor(chr.charCodeAt() / 16).toString(16) + (chr.charCodeAt() % 16).toString(16);
	},

	decode: function(string, secure){
		if ($type(string) != 'string' || !string.length) return null;
		if (secure && !(/^[,:{}\[\]0-9.\-+Eaeflnr-u \n\r\t]*$/).test(string.replace(/\\./g, '@').replace(/"[^"\\\n\r]*"/g, ''))) return null;
		return eval('(' + string + ')');
	}

});

Native.implement([Hash, Array, String, Number], {

	toJSON: function(){
		return JSON.encode(this);
	}

});


/*
Script: Cookie.js
	Class for creating, loading, and saving browser Cookies.

License:
	MIT-style license.

Credits:
	Based on the functions by Peter-Paul Koch (http://quirksmode.org).
*/

var Cookie = new Class({

	Implements: Options,

	options: {
		path: false,
		domain: false,
		duration: false,
		secure: false,
		document: document
	},

	initialize: function(key, options){
		this.key = key;
		this.setOptions(options);
	},

	write: function(value){
		value = encodeURIComponent(value);
		if (this.options.domain) value += '; domain=' + this.options.domain;
		if (this.options.path) value += '; path=' + this.options.path;
		if (this.options.duration){
			var date = new Date();
			date.setTime(date.getTime() + this.options.duration * 24 * 60 * 60 * 1000);
			value += '; expires=' + date.toGMTString();
		}
		if (this.options.secure) value += '; secure';
		this.options.document.cookie = this.key + '=' + value;
		return this;
	},

	read: function(){
		var value = this.options.document.cookie.match('(?:^|;)\\s*' + this.key.escapeRegExp() + '=([^;]*)');
		return (value) ? decodeURIComponent(value[1]) : null;
	},

	dispose: function(){
		new Cookie(this.key, $merge(this.options, {duration: -1})).write('');
		return this;
	}

});

Cookie.write = function(key, value, options){
	return new Cookie(key, options).write(value);
};

Cookie.read = function(key){
	return new Cookie(key).read();
};

Cookie.dispose = function(key, options){
	return new Cookie(key, options).dispose();
};

/*
Script: Swiff.js
	Wrapper for embedding SWF movies. Supports (and fixes) External Interface Communication.

License:
	MIT-style license.

Credits:
	Flash detection & Internet Explorer + Flash Player 9 fix inspired by SWFObject.
*/

var Swiff = new Class({

	Implements: [Options],

	options: {
		id: null,
		height: 1,
		width: 1,
		container: null,
		properties: {},
		params: {
			quality: 'high',
			allowScriptAccess: 'always',
			wMode: 'transparent',
			swLiveConnect: true
		},
		callBacks: {},
		vars: {}
	},

	toElement: function(){
		return this.object;
	},

	initialize: function(path, options){
		this.instance = 'Swiff_' + $time();

		this.setOptions(options);
		options = this.options;
		var id = this.id = options.id || this.instance;
		var container = $(options.container);

		Swiff.CallBacks[this.instance] = {};

		var params = options.params, vars = options.vars, callBacks = options.callBacks;
		var properties = $extend({height: options.height, width: options.width}, options.properties);

		var self = this;

		for (var callBack in callBacks){
			Swiff.CallBacks[this.instance][callBack] = (function(option){
				return function(){
					return option.apply(self.object, arguments);
				};
			})(callBacks[callBack]);
			vars[callBack] = 'Swiff.CallBacks.' + this.instance + '.' + callBack;
		}

		params.flashVars = Hash.toQueryString(vars);
		if (Browser.Engine.trident){
			properties.classid = 'clsid:D27CDB6E-AE6D-11cf-96B8-444553540000';
			params.movie = path;
		} else {
			properties.type = 'application/x-shockwave-flash';
			properties.data = path;
		}
		var build = '<object id="' + id + '"';
		for (var property in properties) build += ' ' + property + '="' + properties[property] + '"';
		build += '>';
		for (var param in params){
			if (params[param]) build += '<param name="' + param + '" value="' + params[param] + '" />';
		}
		build += '</object>';
		this.object =  ((container) ? container.empty() : new Element('div')).set('html', build).firstChild;
	},

	replaces: function(element){
		element = $(element, true);
		element.parentNode.replaceChild(this.toElement(), element);
		return this;
	},

	inject: function(element){
		$(element, true).appendChild(this.toElement());
		return this;
	},

	remote: function(){
		return Swiff.remote.apply(Swiff, [this.toElement()].extend(arguments));
	}

});

Swiff.CallBacks = {};

Swiff.remote = function(obj, fn){
	var rs = obj.CallFunction('<invoke name="' + fn + '" returntype="javascript">' + __flash__argumentsToXML(arguments, 2) + '</invoke>');
	return eval(rs);
};

/*
Script: Fx.js
	Contains the basic animation logic to be extended by all other Fx Classes.

License:
	MIT-style license.
*/

var Fx = new Class({

	Implements: [Chain, Events, Options],

	options: {
		/*
		onStart: $empty,
		onCancel: $empty,
		onComplete: $empty,
		*/
		fps: 50,
		unit: false,
		duration: 500,
		link: 'ignore',
		transition: function(p){
			return -(Math.cos(Math.PI * p) - 1) / 2;
		}
	},

	initialize: function(options){
		this.subject = this.subject || this;
		this.setOptions(options);
		this.options.duration = Fx.Durations[this.options.duration] || this.options.duration.toInt();
		var wait = this.options.wait;
		if (wait === false) this.options.link = 'cancel';
	},

	step: function(){
		var time = $time();
		if (time < this.time + this.options.duration){
			var delta = this.options.transition((time - this.time) / this.options.duration);
			this.set(this.compute(this.from, this.to, delta));
		} else {
			this.set(this.compute(this.from, this.to, 1));
			this.complete();
		}
	},

	set: function(now){
		return now;
	},

	compute: function(from, to, delta){
		return Fx.compute(from, to, delta);
	},

	check: function(caller){
		if (!this.timer) return true;
		switch (this.options.link){
			case 'cancel': this.cancel(); return true;
			case 'chain': this.chain(caller.bind(this, Array.slice(arguments, 1))); return false;
		}
		return false;
	},

	start: function(from, to){
		if (!this.check(arguments.callee, from, to)) return this;
		this.from = from;
		this.to = to;
		this.time = 0;
		this.startTimer();
		this.onStart();
		return this;
	},

	complete: function(){
		if (this.stopTimer()) this.onComplete();
		return this;
	},

	cancel: function(){
		if (this.stopTimer()) this.onCancel();
		return this;
	},

	onStart: function(){
		this.fireEvent('start', this.subject);
	},

	onComplete: function(){
		this.fireEvent('complete', this.subject);
		if (!this.callChain()) this.fireEvent('chainComplete', this.subject);
	},

	onCancel: function(){
		this.fireEvent('cancel', this.subject).clearChain();
	},

	pause: function(){
		this.stopTimer();
		return this;
	},

	resume: function(){
		this.startTimer();
		return this;
	},

	stopTimer: function(){
		if (!this.timer) return false;
		this.time = $time() - this.time;
		this.timer = $clear(this.timer);
		return true;
	},

	startTimer: function(){
		if (this.timer) return false;
		this.time = $time() - this.time;
		this.timer = this.step.periodical(Math.round(1000 / this.options.fps), this);
		return true;
	}

});

Fx.compute = function(from, to, delta){
	return (to - from) * delta + from;
};

Fx.Durations = {'short': 250, 'normal': 500, 'long': 1000};


/*
Script: Fx.CSS.js
	Contains the CSS animation logic. Used by Fx.Tween, Fx.Morph, Fx.Elements.

License:
	MIT-style license.
*/

Fx.CSS = new Class({

	Extends: Fx,

	//prepares the base from/to object

	prepare: function(element, property, values){
		values = $splat(values);
		var values1 = values[1];
		if (!$chk(values1)){
			values[1] = values[0];
			values[0] = element.getStyle(property);
		}
		var parsed = values.map(this.parse);
		return {from: parsed[0], to: parsed[1]};
	},

	//parses a value into an array

	parse: function(value){
		value = $lambda(value)();
		value = (typeof value == 'string') ? value.split(' ') : $splat(value);
		return value.map(function(val){
			val = String(val);
			var found = false;
			Fx.CSS.Parsers.each(function(parser, key){
				if (found) return;
				var parsed = parser.parse(val);
				if ($chk(parsed)) found = {value: parsed, parser: parser};
			});
			found = found || {value: val, parser: Fx.CSS.Parsers.String};
			return found;
		});
	},

	//computes by a from and to prepared objects, using their parsers.

	compute: function(from, to, delta){
		var computed = [];
		(Math.min(from.length, to.length)).times(function(i){
			computed.push({value: from[i].parser.compute(from[i].value, to[i].value, delta), parser: from[i].parser});
		});
		computed.$family = {name: 'fx:css:value'};
		return computed;
	},

	//serves the value as settable

	serve: function(value, unit){
		if ($type(value) != 'fx:css:value') value = this.parse(value);
		var returned = [];
		value.each(function(bit){
			returned = returned.concat(bit.parser.serve(bit.value, unit));
		});
		return returned;
	},

	//renders the change to an element

	render: function(element, property, value, unit){
		element.setStyle(property, this.serve(value, unit));
	},

	//searches inside the page css to find the values for a selector

	search: function(selector){
		if (Fx.CSS.Cache[selector]) return Fx.CSS.Cache[selector];
		var to = {};
		Array.each(document.styleSheets, function(sheet, j){
			var href = sheet.href;
			if (href && href.contains('://') && !href.contains(document.domain)) return;
			var rules = sheet.rules || sheet.cssRules;
			Array.each(rules, function(rule, i){
				if (!rule.style) return;
				var selectorText = (rule.selectorText) ? rule.selectorText.replace(/^\w+/, function(m){
					return m.toLowerCase();
				}) : null;
				if (!selectorText || !selectorText.test('^' + selector + '$')) return;
				Element.Styles.each(function(value, style){
					if (!rule.style[style] || Element.ShortStyles[style]) return;
					value = String(rule.style[style]);
					to[style] = (value.test(/^rgb/)) ? value.rgbToHex() : value;
				});
			});
		});
		return Fx.CSS.Cache[selector] = to;
	}

});

Fx.CSS.Cache = {};

Fx.CSS.Parsers = new Hash({

	Color: {
		parse: function(value){
			if (value.match(/^#[0-9a-f]{3,6}$/i)) return value.hexToRgb(true);
			return ((value = value.match(/(\d+),\s*(\d+),\s*(\d+)/))) ? [value[1], value[2], value[3]] : false;
		},
		compute: function(from, to, delta){
			return from.map(function(value, i){
				return Math.round(Fx.compute(from[i], to[i], delta));
			});
		},
		serve: function(value){
			return value.map(Number);
		}
	},

	Number: {
		parse: parseFloat,
		compute: Fx.compute,
		serve: function(value, unit){
			return (unit) ? value + unit : value;
		}
	},

	String: {
		parse: $lambda(false),
		compute: $arguments(1),
		serve: $arguments(0)
	}

});


/*
Script: Fx.Tween.js
	Formerly Fx.Style, effect to transition any CSS property for an element.

License:
	MIT-style license.
*/

Fx.Tween = new Class({

	Extends: Fx.CSS,

	initialize: function(element, options){
		this.element = this.subject = $(element);
		this.parent(options);
	},

	set: function(property, now){
		if (arguments.length == 1){
			now = property;
			property = this.property || this.options.property;
		}
		this.render(this.element, property, now, this.options.unit);
		return this;
	},

	start: function(property, from, to){
		if (!this.check(arguments.callee, property, from, to)) return this;
		var args = Array.flatten(arguments);
		this.property = this.options.property || args.shift();
		var parsed = this.prepare(this.element, this.property, args);
		return this.parent(parsed.from, parsed.to);
	}

});

Element.Properties.tween = {

	set: function(options){
		var tween = this.retrieve('tween');
		if (tween) tween.cancel();
		return this.eliminate('tween').store('tween:options', $extend({link: 'cancel'}, options));
	},

	get: function(options){
		if (options || !this.retrieve('tween')){
			if (options || !this.retrieve('tween:options')) this.set('tween', options);
			this.store('tween', new Fx.Tween(this, this.retrieve('tween:options')));
		}
		return this.retrieve('tween');
	}

};

Element.implement({

	tween: function(property, from, to){
		this.get('tween').start(arguments);
		return this;
	},

	fade: function(how){
		var fade = this.get('tween'), o = 'opacity', toggle;
		how = $pick(how, 'toggle');
		switch (how){
			case 'in': fade.start(o, 1); break;
			case 'out': fade.start(o, 0); break;
			case 'show': fade.set(o, 1); break;
			case 'hide': fade.set(o, 0); break;
			case 'toggle':
				var flag = this.retrieve('fade:flag', this.get('opacity') == 1);
				fade.start(o, (flag) ? 0 : 1);
				this.store('fade:flag', !flag);
				toggle = true;
			break;
			default: fade.start(o, arguments);
		}
		if (!toggle) this.eliminate('fade:flag');
		return this;
	},

	highlight: function(start, end){
		if (!end){
			end = this.retrieve('highlight:original', this.getStyle('background-color'));
			end = (end == 'transparent') ? '#fff' : end;
		}
		var tween = this.get('tween');
		tween.start('background-color', start || '#ffff88', end).chain(function(){
			this.setStyle('background-color', this.retrieve('highlight:original'));
			tween.callChain();
		}.bind(this));
		return this;
	}

});


/*
Script: Fx.Morph.js
	Formerly Fx.Styles, effect to transition any number of CSS properties for an element using an object of rules, or CSS based selector rules.

License:
	MIT-style license.
*/

Fx.Morph = new Class({

	Extends: Fx.CSS,

	initialize: function(element, options){
		this.element = this.subject = $(element);
		this.parent(options);
	},

	set: function(now){
		if (typeof now == 'string') now = this.search(now);
		for (var p in now) this.render(this.element, p, now[p], this.options.unit);
		return this;
	},

	compute: function(from, to, delta){
		var now = {};
		for (var p in from) now[p] = this.parent(from[p], to[p], delta);
		return now;
	},

	start: function(properties){
		if (!this.check(arguments.callee, properties)) return this;
		if (typeof properties == 'string') properties = this.search(properties);
		var from = {}, to = {};
		for (var p in properties){
			var parsed = this.prepare(this.element, p, properties[p]);
			from[p] = parsed.from;
			to[p] = parsed.to;
		}
		return this.parent(from, to);
	}

});

Element.Properties.morph = {

	set: function(options){
		var morph = this.retrieve('morph');
		if (morph) morph.cancel();
		return this.eliminate('morph').store('morph:options', $extend({link: 'cancel'}, options));
	},

	get: function(options){
		if (options || !this.retrieve('morph')){
			if (options || !this.retrieve('morph:options')) this.set('morph', options);
			this.store('morph', new Fx.Morph(this, this.retrieve('morph:options')));
		}
		return this.retrieve('morph');
	}

};

Element.implement({

	morph: function(props){
		this.get('morph').start(props);
		return this;
	}

});

/*
Script: Fx.Transitions.js
	Contains a set of advanced transitions to be used with any of the Fx Classes.

License:
	MIT-style license.

Credits:
	Easing Equations by Robert Penner, <http://www.robertpenner.com/easing/>, modified and optimized to be used with MooTools.
*/

(function(){

	var old = Fx.prototype.initialize;

	Fx.prototype.initialize = function(options){
		old.call(this, options);
		var trans = this.options.transition;
		if (typeof trans == 'string' && (trans = trans.split(':'))){
			var base = Fx.Transitions;
			base = base[trans[0]] || base[trans[0].capitalize()];
			if (trans[1]) base = base['ease' + trans[1].capitalize() + (trans[2] ? trans[2].capitalize() : '')];
			this.options.transition = base;
		}
	};

})();

Fx.Transition = function(transition, params){
	params = $splat(params);
	return $extend(transition, {
		easeIn: function(pos){
			return transition(pos, params);
		},
		easeOut: function(pos){
			return 1 - transition(1 - pos, params);
		},
		easeInOut: function(pos){
			return (pos <= 0.5) ? transition(2 * pos, params) / 2 : (2 - transition(2 * (1 - pos), params)) / 2;
		}
	});
};

Fx.Transitions = new Hash({

	linear: $arguments(0)

});

Fx.Transitions.extend = function(transitions){
	for (var transition in transitions) Fx.Transitions[transition] = new Fx.Transition(transitions[transition]);
};

Fx.Transitions.extend({

	Pow: function(p, x){
		return Math.pow(p, x[0] || 6);
	},

	Expo: function(p){
		return Math.pow(2, 8 * (p - 1));
	},

	Circ: function(p){
		return 1 - Math.sin(Math.acos(p));
	},

	Sine: function(p){
		return 1 - Math.sin((1 - p) * Math.PI / 2);
	},

	Back: function(p, x){
		x = x[0] || 1.618;
		return Math.pow(p, 2) * ((x + 1) * p - x);
	},

	Bounce: function(p){
		var value;
		for (var a = 0, b = 1; 1; a += b, b /= 2){
			if (p >= (7 - 4 * a) / 11){
				value = - Math.pow((11 - 6 * a - 11 * p) / 4, 2) + b * b;
				break;
			}
		}
		return value;
	},

	Elastic: function(p, x){
		return Math.pow(2, 10 * --p) * Math.cos(20 * p * Math.PI * (x[0] || 1) / 3);
	}

});

['Quad', 'Cubic', 'Quart', 'Quint'].each(function(transition, i){
	Fx.Transitions[transition] = new Fx.Transition(function(p){
		return Math.pow(p, [i + 2]);
	});
});


/*
Script: Request.js
	Powerful all purpose Request Class. Uses XMLHTTPRequest.

License:
	MIT-style license.
*/

var Request = new Class({

	Implements: [Chain, Events, Options],

	options: {
		/*onRequest: $empty,
		onSuccess: $empty,
		onFailure: $empty,
		onException: $empty,*/
		url: '',
		data: '',
		headers: {
			'X-Requested-With': 'XMLHttpRequest',
			'Accept': 'text/javascript, text/html, application/xml, text/xml, */*'
		},
		async: true,
		format: false,
		method: 'post',
		link: 'ignore',
		isSuccess: null,
		emulation: true,
		urlEncoded: true,
		encoding: 'utf-8',
		evalScripts: false,
		evalResponse: false
	},

	initialize: function(options){
		this.xhr = new Browser.Request();
		this.setOptions(options);
		this.options.isSuccess = this.options.isSuccess || this.isSuccess;
		this.headers = new Hash(this.options.headers);
	},

	onStateChange: function(){
		if (this.xhr.readyState != 4 || !this.running) return;
		this.running = false;
		this.status = 0;
		$try(function(){
			this.status = this.xhr.status;
		}.bind(this));
		if (this.options.isSuccess.call(this, this.status)){
			this.response = {text: this.xhr.responseText, xml: this.xhr.responseXML};
			this.success(this.response.text, this.response.xml);
		} else {
			this.response = {text: null, xml: null};
			this.failure();
		}
		this.xhr.onreadystatechange = $empty;
	},

	isSuccess: function(){
		return ((this.status >= 200) && (this.status < 300));
	},

	processScripts: function(text){
		if (this.options.evalResponse || (/(ecma|java)script/).test(this.getHeader('Content-type'))) return $exec(text);
		return text.stripScripts(this.options.evalScripts);
	},

	success: function(text, xml){
		this.onSuccess(this.processScripts(text), xml);
	},
	
	onSuccess: function(){
		this.fireEvent('complete', arguments).fireEvent('success', arguments).callChain();
	},
	
	failure: function(){
		this.onFailure();
	},

	onFailure: function(){
		this.fireEvent('complete').fireEvent('failure', this.xhr);
	},

	setHeader: function(name, value){
		this.headers.set(name, value);
		return this;
	},

	getHeader: function(name){
		return $try(function(){
			return this.xhr.getResponseHeader(name);
		}.bind(this));
	},

	check: function(caller){
		if (!this.running) return true;
		switch (this.options.link){
			case 'cancel': this.cancel(); return true;
			case 'chain': this.chain(caller.bind(this, Array.slice(arguments, 1))); return false;
		}
		return false;
	},

	send: function(options){
		if (!this.check(arguments.callee, options)) return this;
		this.running = true;

		var type = $type(options);
		if (type == 'string' || type == 'element') options = {data: options};

		var old = this.options;
		options = $extend({data: old.data, url: old.url, method: old.method}, options);
		var data = options.data, url = options.url, method = options.method;

		switch ($type(data)){
			case 'element': data = $(data).toQueryString(); break;
			case 'object': case 'hash': data = Hash.toQueryString(data);
		}

		if (this.options.format){
			var format = 'format=' + this.options.format;
			data = (data) ? format + '&' + data : format;
		}

		if (this.options.emulation && ['put', 'delete'].contains(method)){
			var _method = '_method=' + method;
			data = (data) ? _method + '&' + data : _method;
			method = 'post';
		}

		if (this.options.urlEncoded && method == 'post'){
			var encoding = (this.options.encoding) ? '; charset=' + this.options.encoding : '';
			this.headers.set('Content-type', 'application/x-www-form-urlencoded' + encoding);
		}

		if (data && method == 'get'){
			url = url + (url.contains('?') ? '&' : '?') + data;
			data = null;
		}

		this.xhr.open(method.toUpperCase(), url, this.options.async);

		this.xhr.onreadystatechange = this.onStateChange.bind(this);

		this.headers.each(function(value, key){
			if (!$try(function(){
				this.xhr.setRequestHeader(key, value);
				return true;
			}.bind(this))) this.fireEvent('exception', [key, value]);
		}, this);

		this.fireEvent('request');
		this.xhr.send(data);
		if (!this.options.async) this.onStateChange();
		return this;
	},

	cancel: function(){
		if (!this.running) return this;
		this.running = false;
		this.xhr.abort();
		this.xhr.onreadystatechange = $empty;
		this.xhr = new Browser.Request();
		this.fireEvent('cancel');
		return this;
	}

});

(function(){

var methods = {};
['get', 'post', 'put', 'delete', 'GET', 'POST', 'PUT', 'DELETE'].each(function(method){
	methods[method] = function(){
		var params = Array.link(arguments, {url: String.type, data: $defined});
		return this.send($extend(params, {method: method.toLowerCase()}));
	};
});

Request.implement(methods);

})();

Element.Properties.send = {
	
	set: function(options){
		var send = this.retrieve('send');
		if (send) send.cancel();
		return this.eliminate('send').store('send:options', $extend({
			data: this, link: 'cancel', method: this.get('method') || 'post', url: this.get('action')
		}, options));
	},

	get: function(options){
		if (options || !this.retrieve('send')){
			if (options || !this.retrieve('send:options')) this.set('send', options);
			this.store('send', new Request(this.retrieve('send:options')));
		}
		return this.retrieve('send');
	}

};

Element.implement({

	send: function(url){
		var sender = this.get('send');
		sender.send({data: this, url: url || sender.options.url});
		return this;
	}

});


/*
Script: Request.HTML.js
	Extends the basic Request Class with additional methods for interacting with HTML responses.

License:
	MIT-style license.
*/

Request.HTML = new Class({

	Extends: Request,

	options: {
		update: false,
		evalScripts: true,
		filter: false
	},

	processHTML: function(text){
		var match = text.match(/<body[^>]*>([\s\S]*?)<\/body>/i);
		text = (match) ? match[1] : text;
		
		var container = new Element('div');
		
		return $try(function(){
			var root = '<root>' + text + '</root>', doc;
			if (Browser.Engine.trident){
				doc = new ActiveXObject('Microsoft.XMLDOM');
				doc.async = false;
				doc.loadXML(root);
			} else {
				doc = new DOMParser().parseFromString(root, 'text/xml');
			}
			root = doc.getElementsByTagName('root')[0];
			for (var i = 0, k = root.childNodes.length; i < k; i++){
				var child = Element.clone(root.childNodes[i], true, true);
				if (child) container.grab(child);
			}
			return container;
		}) || container.set('html', text);
	},

	success: function(text){
		var options = this.options, response = this.response;
		
		response.html = text.stripScripts(function(script){
			response.javascript = script;
		});
		
		var temp = this.processHTML(response.html);
		
		response.tree = temp.childNodes;
		response.elements = temp.getElements('*');
		
		if (options.filter) response.tree = response.elements.filter(options.filter);
		if (options.update) $(options.update).empty().adopt(response.tree);
		if (options.evalScripts) $exec(response.javascript);
		
		this.onSuccess(response.tree, response.elements, response.html, response.javascript);
	}

});

Element.Properties.load = {
	
	set: function(options){
		var load = this.retrieve('load');
		if (load) send.cancel();
		return this.eliminate('load').store('load:options', $extend({data: this, link: 'cancel', update: this, method: 'get'}, options));
	},

	get: function(options){
		if (options || ! this.retrieve('load')){
			if (options || !this.retrieve('load:options')) this.set('load', options);
			this.store('load', new Request.HTML(this.retrieve('load:options')));
		}
		return this.retrieve('load');
	}

};

Element.implement({
	
	load: function(){
		this.get('load').send(Array.link(arguments, {data: Object.type, url: String.type}));
		return this;
	}

});


/*
Script: Request.JSON.js
	Extends the basic Request Class with additional methods for sending and receiving JSON data.

License:
	MIT-style license.
*/

Request.JSON = new Class({

	Extends: Request,

	options: {
		secure: true
	},

	initialize: function(options){
		this.parent(options);
		this.headers.extend({'Accept': 'application/json', 'X-Request': 'JSON'});
	},

	success: function(text){
		this.response.json = JSON.decode(text, this.options.secure);
		this.onSuccess(this.response.json, text);
	}

});

//MooTools More, <http://mootools.net/more>. Copyright (c) 2006-2008 Valerio Proietti, <http://mad4milk.net>, MIT Style License.

/*
Script: Fx.Slide.js
	Effect to slide an element in and out of view.

License:
	MIT-style license.
*/

Fx.Slide = new Class({

	Extends: Fx,

	options: {
		mode: 'vertical'
	},

	initialize: function(element, options){
		this.addEvent('complete', function(){
			this.open = (this.wrapper['offset' + this.layout.capitalize()] != 0);
			if (this.open && Browser.Engine.webkit419) this.element.dispose().inject(this.wrapper);
		}, true);
		this.element = this.subject = $(element);
		this.parent(options);
		var wrapper = this.element.retrieve('wrapper');
		this.wrapper = wrapper || new Element('div', {
			styles: $extend(this.element.getStyles('margin', 'position'), {'overflow': 'hidden'})
		}).wraps(this.element);
		this.element.store('wrapper', this.wrapper).setStyle('margin', 0);
		this.now = [];
		this.open = true;
	},

	vertical: function(){
		this.margin = 'margin-top';
		this.layout = 'height';
		this.offset = this.element.offsetHeight;
	},

	horizontal: function(){
		this.margin = 'margin-left';
		this.layout = 'width';
		this.offset = this.element.offsetWidth;
	},

	set: function(now){
		this.element.setStyle(this.margin, now[0]);
		this.wrapper.setStyle(this.layout, now[1]);
		return this;
	},

	compute: function(from, to, delta){
		var now = [];
		var x = 2;
		x.times(function(i){
			now[i] = Fx.compute(from[i], to[i], delta);
		});
		return now;
	},

	start: function(how, mode){
		if (!this.check(arguments.callee, how, mode)) return this;
		this[mode || this.options.mode]();
		var margin = this.element.getStyle(this.margin).toInt();
		var layout = this.wrapper.getStyle(this.layout).toInt();
		var caseIn = [[margin, layout], [0, this.offset]];
		var caseOut = [[margin, layout], [-this.offset, 0]];
		var start;
		switch (how){
			case 'in': start = caseIn; break;
			case 'out': start = caseOut; break;
			case 'toggle': start = (this.wrapper['offset' + this.layout.capitalize()] == 0) ? caseIn : caseOut;
		}
		return this.parent(start[0], start[1]);
	},

	slideIn: function(mode){
		return this.start('in', mode);
	},

	slideOut: function(mode){
		return this.start('out', mode);
	},

	hide: function(mode){
		this[mode || this.options.mode]();
		this.open = false;
		return this.set([-this.offset, 0]);
	},

	show: function(mode){
		this[mode || this.options.mode]();
		this.open = true;
		return this.set([0, this.offset]);
	},

	toggle: function(mode){
		return this.start('toggle', mode);
	}

});

Element.Properties.slide = {

	set: function(options){
		var slide = this.retrieve('slide');
		if (slide) slide.cancel();
		return this.eliminate('slide').store('slide:options', $extend({link: 'cancel'}, options));
	},
	
	get: function(options){
		if (options || !this.retrieve('slide')){
			if (options || !this.retrieve('slide:options')) this.set('slide', options);
			this.store('slide', new Fx.Slide(this, this.retrieve('slide:options')));
		}
		return this.retrieve('slide');
	}

};

Element.implement({

	slide: function(how, mode){
		how = how || 'toggle';
		var slide = this.get('slide'), toggle;
		switch (how){
			case 'hide': slide.hide(mode); break;
			case 'show': slide.show(mode); break;
			case 'toggle':
				var flag = this.retrieve('slide:flag', slide.open);
				slide[(flag) ? 'slideOut' : 'slideIn'](mode);
				this.store('slide:flag', !flag);
				toggle = true;
			break;
			default: slide.start(how, mode);
		}
		if (!toggle) this.eliminate('slide:flag');
		return this;
	}

});


/*
Script: Fx.Scroll.js
	Effect to smoothly scroll any element, including the window.

License:
	MIT-style license.
*/

Fx.Scroll = new Class({

	Extends: Fx,

	options: {
		offset: {'x': 0, 'y': 0},
		wheelStops: true
	},

	initialize: function(element, options){
		this.element = this.subject = $(element);
		this.parent(options);
		var cancel = this.cancel.bind(this, false);

		if ($type(this.element) != 'element') this.element = $(this.element.getDocument().body);

		var stopper = this.element;

		if (this.options.wheelStops){
			this.addEvent('start', function(){
				stopper.addEvent('mousewheel', cancel);
			}, true);
			this.addEvent('complete', function(){
				stopper.removeEvent('mousewheel', cancel);
			}, true);
		}
	},

	set: function(){
		var now = Array.flatten(arguments);
		this.element.scrollTo(now[0], now[1]);
	},

	compute: function(from, to, delta){
		var now = [];
		var x = 2;
		x.times(function(i){
			now.push(Fx.compute(from[i], to[i], delta));
		});
		return now;
	},

	start: function(x, y){
		if (!this.check(arguments.callee, x, y)) return this;
		var offsetSize = this.element.getSize(), scrollSize = this.element.getScrollSize();
		var scroll = this.element.getScroll(), values = {x: x, y: y};
		for (var z in values){
			var max = scrollSize[z] - offsetSize[z];
			if ($chk(values[z])) values[z] = ($type(values[z]) == 'number') ? values[z].limit(0, max) : max;
			else values[z] = scroll[z];
			values[z] += this.options.offset[z];
		}
		return this.parent([scroll.x, scroll.y], [values.x, values.y]);
	},

	toTop: function(){
		return this.start(false, 0);
	},

	toLeft: function(){
		return this.start(0, false);
	},

	toRight: function(){
		return this.start('right', false);
	},

	toBottom: function(){
		return this.start(false, 'bottom');
	},

	toElement: function(el){
		var position = $(el).getPosition(this.element);
		return this.start(position.x, position.y);
	}

});


/*
Script: Fx.Elements.js
	Effect to change any number of CSS properties of any number of Elements.

License:
	MIT-style license.
*/

Fx.Elements = new Class({

	Extends: Fx.CSS,

	initialize: function(elements, options){
		this.elements = this.subject = $$(elements);
		this.parent(options);
	},

	compute: function(from, to, delta){
		var now = {};
		for (var i in from){
			var iFrom = from[i], iTo = to[i], iNow = now[i] = {};
			for (var p in iFrom) iNow[p] = this.parent(iFrom[p], iTo[p], delta);
		}
		return now;
	},

	set: function(now){
		for (var i in now){
			var iNow = now[i];
			for (var p in iNow) this.render(this.elements[i], p, iNow[p], this.options.unit);
		}
		return this;
	},

	start: function(obj){
		if (!this.check(arguments.callee, obj)) return this;
		var from = {}, to = {};
		for (var i in obj){
			var iProps = obj[i], iFrom = from[i] = {}, iTo = to[i] = {};
			for (var p in iProps){
				var parsed = this.prepare(this.elements[i], p, iProps[p]);
				iFrom[p] = parsed.from;
				iTo[p] = parsed.to;
			}
		}
		return this.parent(from, to);
	}

});

/*
Script: Drag.js
	The base Drag Class. Can be used to drag and resize Elements using mouse events.

License:
	MIT-style license.
*/

var Drag = new Class({

	Implements: [Events, Options],

	options: {/*
		onBeforeStart: $empty,
		onStart: $empty,
		onDrag: $empty,
		onCancel: $empty,
		onComplete: $empty,*/
		snap: 6,
		unit: 'px',
		grid: false,
		style: true,
		limit: false,
		handle: false,
		invert: false,
		preventDefault: false,
		modifiers: {x: 'left', y: 'top'}
	},

	initialize: function(){
		var params = Array.link(arguments, {'options': Object.type, 'element': $defined});
		this.element = $(params.element);
		this.document = this.element.getDocument();
		this.setOptions(params.options || {});
		var htype = $type(this.options.handle);
		this.handles = (htype == 'array' || htype == 'collection') ? $$(this.options.handle) : $(this.options.handle) || this.element;
		this.mouse = {'now': {}, 'pos': {}};
		this.value = {'start': {}, 'now': {}};
		
		this.selection = (Browser.Engine.trident) ? 'selectstart' : 'mousedown';
		
		this.bound = {
			start: this.start.bind(this),
			check: this.check.bind(this),
			drag: this.drag.bind(this),
			stop: this.stop.bind(this),
			cancel: this.cancel.bind(this),
			eventStop: $lambda(false)
		};
		this.attach();
	},

	attach: function(){
		this.handles.addEvent('mousedown', this.bound.start);
		return this;
	},

	detach: function(){
		this.handles.removeEvent('mousedown', this.bound.start);
		return this;
	},

	start: function(event){
		if (this.options.preventDefault) event.preventDefault();
		this.fireEvent('beforeStart', this.element);
		this.mouse.start = event.page;
		var limit = this.options.limit;
		this.limit = {'x': [], 'y': []};
		for (var z in this.options.modifiers){
			if (!this.options.modifiers[z]) continue;
			if (this.options.style) this.value.now[z] = this.element.getStyle(this.options.modifiers[z]).toInt();
			else this.value.now[z] = this.element[this.options.modifiers[z]];
			if (this.options.invert) this.value.now[z] *= -1;
			this.mouse.pos[z] = event.page[z] - this.value.now[z];
			if (limit && limit[z]){
				for (var i = 2; i--; i){
					if ($chk(limit[z][i])) this.limit[z][i] = $lambda(limit[z][i])();
				}
			}
		}
		if ($type(this.options.grid) == 'number') this.options.grid = {'x': this.options.grid, 'y': this.options.grid};
		this.document.addEvents({mousemove: this.bound.check, mouseup: this.bound.cancel});
		this.document.addEvent(this.selection, this.bound.eventStop);
	},

	check: function(event){
		if (this.options.preventDefault) event.preventDefault();
		var distance = Math.round(Math.sqrt(Math.pow(event.page.x - this.mouse.start.x, 2) + Math.pow(event.page.y - this.mouse.start.y, 2)));
		if (distance > this.options.snap){
			this.cancel();
			this.document.addEvents({
				mousemove: this.bound.drag,
				mouseup: this.bound.stop
			});
			this.fireEvent('start', this.element).fireEvent('snap', this.element);
		}
	},

	drag: function(event){
		if (this.options.preventDefault) event.preventDefault();
		this.mouse.now = event.page;
		for (var z in this.options.modifiers){
			if (!this.options.modifiers[z]) continue;
			this.value.now[z] = this.mouse.now[z] - this.mouse.pos[z];
			if (this.options.invert) this.value.now[z] *= -1;
			if (this.options.limit && this.limit[z]){
				if ($chk(this.limit[z][1]) && (this.value.now[z] > this.limit[z][1])){
					this.value.now[z] = this.limit[z][1];
				} else if ($chk(this.limit[z][0]) && (this.value.now[z] < this.limit[z][0])){
					this.value.now[z] = this.limit[z][0];
				}
			}
			if (this.options.grid[z]) this.value.now[z] -= (this.value.now[z] % this.options.grid[z]);
			if (this.options.style) this.element.setStyle(this.options.modifiers[z], this.value.now[z] + this.options.unit);
			else this.element[this.options.modifiers[z]] = this.value.now[z];
		}
		this.fireEvent('drag', this.element);
	},

	cancel: function(event){
		this.document.removeEvent('mousemove', this.bound.check);
		this.document.removeEvent('mouseup', this.bound.cancel);
		if (event){
			this.document.removeEvent(this.selection, this.bound.eventStop);
			this.fireEvent('cancel', this.element);
		}
	},

	stop: function(event){
		this.document.removeEvent(this.selection, this.bound.eventStop);
		this.document.removeEvent('mousemove', this.bound.drag);
		this.document.removeEvent('mouseup', this.bound.stop);
		if (event) this.fireEvent('complete', this.element);
	}

});

Element.implement({
	
	makeResizable: function(options){
		return new Drag(this, $merge({modifiers: {'x': 'width', 'y': 'height'}}, options));
	}

});

/*
Script: Drag.Move.js
	A Drag extension that provides support for the constraining of draggables to containers and droppables.

License:
	MIT-style license.
*/

Drag.Move = new Class({

	Extends: Drag,

	options: {
		droppables: [],
		container: false
	},

	initialize: function(element, options){
		this.parent(element, options);
		this.droppables = $$(this.options.droppables);
		this.container = $(this.options.container);
		if (this.container && $type(this.container) != 'element') this.container = $(this.container.getDocument().body);
		element = this.element;
		
		var current = element.getStyle('position');
		var position = (current != 'static') ? current : 'absolute';
		if (element.getStyle('left') == 'auto' || element.getStyle('top') == 'auto') element.position(element.getPosition(element.offsetParent));
		
		element.setStyle('position', position);
		
		this.addEvent('start', function(){
			this.checkDroppables();
		}, true);
	},

	start: function(event){
		if (this.container){
			var el = this.element, cont = this.container, ccoo = cont.getCoordinates(el.offsetParent), cps = {}, ems = {};

			['top', 'right', 'bottom', 'left'].each(function(pad){
				cps[pad] = cont.getStyle('padding-' + pad).toInt();
				ems[pad] = el.getStyle('margin-' + pad).toInt();
			}, this);

			var width = el.offsetWidth + ems.left + ems.right, height = el.offsetHeight + ems.top + ems.bottom;
			var x = [ccoo.left + cps.left, ccoo.right - cps.right - width];
			var y = [ccoo.top + cps.top, ccoo.bottom - cps.bottom - height];

			this.options.limit = {x: x, y: y};
		}
		this.parent(event);
	},

	checkAgainst: function(el){
		el = el.getCoordinates();
		var now = this.mouse.now;
		return (now.x > el.left && now.x < el.right && now.y < el.bottom && now.y > el.top);
	},

	checkDroppables: function(){
		var overed = this.droppables.filter(this.checkAgainst, this).getLast();
		if (this.overed != overed){
			if (this.overed) this.fireEvent('leave', [this.element, this.overed]);
			if (overed){
				this.overed = overed;
				this.fireEvent('enter', [this.element, overed]);
			} else {
				this.overed = null;
			}
		}
	},

	drag: function(event){
		this.parent(event);
		if (this.droppables.length) this.checkDroppables();
	},

	stop: function(event){
		this.checkDroppables();
		this.fireEvent('drop', [this.element, this.overed]);
		this.overed = null;
		return this.parent(event);
	}

});

Element.implement({

	makeDraggable: function(options){
		return new Drag.Move(this, options);
	}

});


/*
Script: Hash.Cookie.js
	Class for creating, reading, and deleting Cookies in JSON format.

License:
	MIT-style license.
*/

Hash.Cookie = new Class({

	Extends: Cookie,

	options: {
		autoSave: true
	},

	initialize: function(name, options){
		this.parent(name, options);
		this.load();
	},

	save: function(){
		var value = JSON.encode(this.hash);
		if (!value || value.length > 4096) return false; //cookie would be truncated!
		if (value == '{}') this.dispose();
		else this.write(value);
		return true;
	},

	load: function(){
		this.hash = new Hash(JSON.decode(this.read(), true));
		return this;
	}

});

Hash.Cookie.implement((function(){
	
	var methods = {};
	
	Hash.each(Hash.prototype, function(method, name){
		methods[name] = function(){
			var value = method.apply(this.hash, arguments);
			if (this.options.autoSave) this.save();
			return value;
		};
	});
	
	return methods;
	
})());

/*
Script: Color.js
	Class for creating and manipulating colors in JavaScript. Supports HSB -> RGB Conversions and vice versa.

License:
	MIT-style license.
*/

var Color = new Native({
  
	initialize: function(color, type){
		if (arguments.length >= 3){
			type = "rgb"; color = Array.slice(arguments, 0, 3);
		} else if (typeof color == 'string'){
			if (color.match(/rgb/)) color = color.rgbToHex().hexToRgb(true);
			else if (color.match(/hsb/)) color = color.hsbToRgb();
			else color = color.hexToRgb(true);
		}
		type = type || 'rgb';
		switch (type){
			case 'hsb':
				var old = color;
				color = color.hsbToRgb();
				color.hsb = old;
			break;
			case 'hex': color = color.hexToRgb(true); break;
		}
		color.rgb = color.slice(0, 3);
		color.hsb = color.hsb || color.rgbToHsb();
		color.hex = color.rgbToHex();
		return $extend(color, this);
	}

});

Color.implement({

	mix: function(){
		var colors = Array.slice(arguments);
		var alpha = ($type(colors.getLast()) == 'number') ? colors.pop() : 50;
		var rgb = this.slice();
		colors.each(function(color){
			color = new Color(color);
			for (var i = 0; i < 3; i++) rgb[i] = Math.round((rgb[i] / 100 * (100 - alpha)) + (color[i] / 100 * alpha));
		});
		return new Color(rgb, 'rgb');
	},

	invert: function(){
		return new Color(this.map(function(value){
			return 255 - value;
		}));
	},

	setHue: function(value){
		return new Color([value, this.hsb[1], this.hsb[2]], 'hsb');
	},

	setSaturation: function(percent){
		return new Color([this.hsb[0], percent, this.hsb[2]], 'hsb');
	},

	setBrightness: function(percent){
		return new Color([this.hsb[0], this.hsb[1], percent], 'hsb');
	}

});

function $RGB(r, g, b){
	return new Color([r, g, b], 'rgb');
};

function $HSB(h, s, b){
	return new Color([h, s, b], 'hsb');
};

function $HEX(hex){
	return new Color(hex, 'hex');
};

Array.implement({

	rgbToHsb: function(){
		var red = this[0], green = this[1], blue = this[2];
		var hue, saturation, brightness;
		var max = Math.max(red, green, blue), min = Math.min(red, green, blue);
		var delta = max - min;
		brightness = max / 255;
		saturation = (max != 0) ? delta / max : 0;
		if (saturation == 0){
			hue = 0;
		} else {
			var rr = (max - red) / delta;
			var gr = (max - green) / delta;
			var br = (max - blue) / delta;
			if (red == max) hue = br - gr;
			else if (green == max) hue = 2 + rr - br;
			else hue = 4 + gr - rr;
			hue /= 6;
			if (hue < 0) hue++;
		}
		return [Math.round(hue * 360), Math.round(saturation * 100), Math.round(brightness * 100)];
	},

	hsbToRgb: function(){
		var br = Math.round(this[2] / 100 * 255);
		if (this[1] == 0){
			return [br, br, br];
		} else {
			var hue = this[0] % 360;
			var f = hue % 60;
			var p = Math.round((this[2] * (100 - this[1])) / 10000 * 255);
			var q = Math.round((this[2] * (6000 - this[1] * f)) / 600000 * 255);
			var t = Math.round((this[2] * (6000 - this[1] * (60 - f))) / 600000 * 255);
			switch (Math.floor(hue / 60)){
				case 0: return [br, t, p];
				case 1: return [q, br, p];
				case 2: return [p, br, t];
				case 3: return [p, q, br];
				case 4: return [t, p, br];
				case 5: return [br, p, q];
			}
		}
		return false;
	}

});

String.implement({

	rgbToHsb: function(){
		var rgb = this.match(/\d{1,3}/g);
		return (rgb) ? hsb.rgbToHsb() : null;
	},
	
	hsbToRgb: function(){
		var hsb = this.match(/\d{1,3}/g);
		return (hsb) ? hsb.hsbToRgb() : null;
	}

});


/*
Script: Group.js
	Class for monitoring collections of events

License:
	MIT-style license.
*/

var Group = new Class({

	initialize: function(){
		this.instances = Array.flatten(arguments);
		this.events = {};
		this.checker = {};
	},

	addEvent: function(type, fn){
		this.checker[type] = this.checker[type] || {};
		this.events[type] = this.events[type] || [];
		if (this.events[type].contains(fn)) return false;
		else this.events[type].push(fn);
		this.instances.each(function(instance, i){
			instance.addEvent(type, this.check.bind(this, [type, instance, i]));
		}, this);
		return this;
	},

	check: function(type, instance, i){
		this.checker[type][i] = true;
		var every = this.instances.every(function(current, j){
			return this.checker[type][j] || false;
		}, this);
		if (!every) return;
		this.checker[type] = {};
		this.events[type].each(function(event){
			event.call(this, this.instances, instance);
		}, this);
	}

});


/*
Script: Assets.js
	Provides methods to dynamically load JavaScript, CSS, and Image files into the document.

License:
	MIT-style license.
*/

var Asset = new Hash({

	javascript: function(source, properties){
		properties = $extend({
			onload: $empty,
			document: document,
			check: $lambda(true)
		}, properties);
		
		var script = new Element('script', {'src': source, 'type': 'text/javascript'});
		
		var load = properties.onload.bind(script), check = properties.check, doc = properties.document;
		delete properties.onload; delete properties.check; delete properties.document;
		
		script.addEvents({
			load: load,
			readystatechange: function(){
				if (['loaded', 'complete'].contains(this.readyState)) load();
			}
		}).setProperties(properties);
		
		
		if (Browser.Engine.webkit419) var checker = (function(){
			if (!$try(check)) return;
			$clear(checker);
			load();
		}).periodical(50);
		
		return script.inject(doc.head);
	},

	css: function(source, properties){
		return new Element('link', $merge({
			'rel': 'stylesheet', 'media': 'screen', 'type': 'text/css', 'href': source
		}, properties)).inject(document.head);
	},

	image: function(source, properties){
		properties = $merge({
			'onload': $empty,
			'onabort': $empty,
			'onerror': $empty
		}, properties);
		var image = new Image();
		var element = $(image) || new Element('img');
		['load', 'abort', 'error'].each(function(name){
			var type = 'on' + name;
			var event = properties[type];
			delete properties[type];
			image[type] = function(){
				if (!image) return;
				if (!element.parentNode){
					element.width = image.width;
					element.height = image.height;
				}
				image = image.onload = image.onabort = image.onerror = null;
				event.delay(1, element, element);
				element.fireEvent(name, element, 1);
			};
		});
		image.src = element.src = source;
		if (image && image.complete) image.onload.delay(1);
		return element.setProperties(properties);
	},

	images: function(sources, options){
		options = $merge({
			onComplete: $empty,
			onProgress: $empty
		}, options);
		if (!sources.push) sources = [sources];
		var images = [];
		var counter = 0;
		sources.each(function(source){
			var img = new Asset.image(source, {
				'onload': function(){
					options.onProgress.call(this, counter, sources.indexOf(source));
					counter++;
					if (counter == sources.length) options.onComplete();
				}
			});
			images.push(img);
		});
		return new Elements(images);
	}

});

/*
Script: Sortables.js
	Class for creating a drag and drop sorting interface for lists of items.

License:
	MIT-style license.
*/

var Sortables = new Class({

	Implements: [Events, Options],

	options: {/*
		onSort: $empty,
		onStart: $empty,
		onComplete: $empty,*/
		snap: 4,
		opacity: 1,
		clone: false,
		revert: false,
		handle: false,
		constrain: false
	},

	initialize: function(lists, options){
		this.setOptions(options);
		this.elements = [];
		this.lists = [];
		this.idle = true;
		
		this.addLists($$($(lists) || lists));
		if (!this.options.clone) this.options.revert = false;
		if (this.options.revert) this.effect = new Fx.Morph(null, $merge({duration: 250, link: 'cancel'}, this.options.revert));
	},

	attach: function(){
		this.addLists(this.lists);
		return this;
	},

	detach: function(){
		this.lists = this.removeLists(this.lists);
		return this;
	},

	addItems: function(){
		Array.flatten(arguments).each(function(element){
			this.elements.push(element);
			var start = element.retrieve('sortables:start', this.start.bindWithEvent(this, element));
			(this.options.handle ? element.getElement(this.options.handle) || element : element).addEvent('mousedown', start);
		}, this);
		return this;
	},

	addLists: function(){
		Array.flatten(arguments).each(function(list){
			this.lists.push(list);
			this.addItems(list.getChildren());
		}, this);
		return this;
	},

	removeItems: function(){
		var elements = [];
		Array.flatten(arguments).each(function(element){
			elements.push(element);
			this.elements.erase(element);
			var start = element.retrieve('sortables:start');
			(this.options.handle ? element.getElement(this.options.handle) || element : element).removeEvent('mousedown', start);
		}, this);
		return $$(elements);
	},

	removeLists: function(){
		var lists = [];
		Array.flatten(arguments).each(function(list){
			lists.push(list);
			this.lists.erase(list);
			this.removeItems(list.getChildren());
		}, this);
		return $$(lists);
	},

	getClone: function(event, element){
		if (!this.options.clone) return new Element('div').inject(document.body);
		if ($type(this.options.clone) == 'function') return this.options.clone.call(this, event, element, this.list);
		return element.clone(true).setStyles({
			'margin': '0px',
			'position': 'absolute',
			'visibility': 'hidden',
			'width': element.getStyle('width')
		}).inject(this.list).position(element.getPosition(element.getOffsetParent()));
	},

	getDroppables: function(){
		var droppables = this.list.getChildren();
		if (!this.options.constrain) droppables = this.lists.concat(droppables).erase(this.list);
		return droppables.erase(this.clone).erase(this.element);
	},

	insert: function(dragging, element){
		var where = 'inside';
		if (this.lists.contains(element)){
			this.list = element;
			this.drag.droppables = this.getDroppables();
		} else {
			where = this.element.getAllPrevious().contains(element) ? 'before' : 'after';
		}
		this.element.inject(element, where);
		this.fireEvent('sort', [this.element, this.clone]);
	},

	start: function(event, element){
		if (!this.idle) return;
		this.idle = false;
		this.element = element;
		this.opacity = element.get('opacity');
		this.list = element.getParent();
		this.clone = this.getClone(event, element);
		
		this.drag = new Drag.Move(this.clone, {
			snap: this.options.snap,
			container: this.options.constrain && this.element.getParent(),
			droppables: this.getDroppables(),
			onSnap: function(){
				event.stop();
				this.clone.setStyle('visibility', 'visible');
				this.element.set('opacity', this.options.opacity || 0);
				this.fireEvent('start', [this.element, this.clone]);
			}.bind(this),
			onEnter: this.insert.bind(this),
			onCancel: this.reset.bind(this),
			onComplete: this.end.bind(this)
		});
		
		this.clone.inject(this.element, 'before');
		this.drag.start(event);
	},

	end: function(){
		this.drag.detach();
		this.element.set('opacity', this.opacity);
		if (this.effect){
			var dim = this.element.getStyles('width', 'height');
			var pos = this.clone.computePosition(this.element.getPosition(this.clone.offsetParent));
			this.effect.element = this.clone;
			this.effect.start({
				top: pos.top,
				left: pos.left,
				width: dim.width,
				height: dim.height,
				opacity: 0.25
			}).chain(this.reset.bind(this));
		} else {
			this.reset();
		}
	},

	reset: function(){
		this.idle = true;
		this.clone.destroy();
		this.fireEvent('complete', this.element);
	},

	serialize: function(){
		var params = Array.link(arguments, {modifier: Function.type, index: $defined});
		var serial = this.lists.map(function(list){
			return list.getChildren().map(params.modifier || function(element){
				return element.get('id');
			}, this);
		}, this);
		
		var index = params.index;
		if (this.lists.length == 1) index = 0;
		return $chk(index) && index >= 0 && index < this.lists.length ? serial[index] : serial;
	}

});

/*
Script: Tips.js
	Class for creating nice tips that follow the mouse cursor when hovering an element.

License:
	MIT-style license.
*/

var Tips = new Class({

	Implements: [Events, Options],

	options: {
		onShow: function(tip){
			tip.setStyle('visibility', 'visible');
		},
		onHide: function(tip){
			tip.setStyle('visibility', 'hidden');
		},
		showDelay: 100,
		hideDelay: 100,
		className: null,
		offsets: {x: 16, y: 16},
		fixed: false
	},

	initialize: function(){
		var params = Array.link(arguments, {options: Object.type, elements: $defined});
		this.setOptions(params.options || null);
		
		this.tip = new Element('div').inject(document.body);
		
		if (this.options.className) this.tip.addClass(this.options.className);
		
		var top = new Element('div', {'class': 'tip-top'}).inject(this.tip);
		this.container = new Element('div', {'class': 'tip'}).inject(this.tip);
		var bottom = new Element('div', {'class': 'tip-bottom'}).inject(this.tip);

		this.tip.setStyles({position: 'absolute', top: 0, left: 0, visibility: 'hidden'});
		
		if (params.elements) this.attach(params.elements);
	},
	
	attach: function(elements){
		$$(elements).each(function(element){
			var title = element.retrieve('tip:title', element.get('title'));
			var text = element.retrieve('tip:text', element.get('rel') || element.get('href'));
			var enter = element.retrieve('tip:enter', this.elementEnter.bindWithEvent(this, element));
			var leave = element.retrieve('tip:leave', this.elementLeave.bindWithEvent(this, element));
			element.addEvents({mouseenter: enter, mouseleave: leave});
			if (!this.options.fixed){
				var move = element.retrieve('tip:move', this.elementMove.bindWithEvent(this, element));
				element.addEvent('mousemove', move);
			}
			element.store('tip:native', element.get('title'));
			element.erase('title');
		}, this);
		return this;
	},
	
	detach: function(elements){
		$$(elements).each(function(element){
			element.removeEvent('mouseenter', element.retrieve('tip:enter') || $empty);
			element.removeEvent('mouseleave', element.retrieve('tip:leave') || $empty);
			element.removeEvent('mousemove', element.retrieve('tip:move') || $empty);
			element.eliminate('tip:enter').eliminate('tip:leave').eliminate('tip:move');
			var original = element.retrieve('tip:native');
			if (original) element.set('title', original);
		});
		return this;
	},
	
	elementEnter: function(event, element){
		
		$A(this.container.childNodes).each(Element.dispose);
		
		var title = element.retrieve('tip:title');
		
		if (title){
			this.titleElement = new Element('div', {'class': 'tip-title'}).inject(this.container);
			this.fill(this.titleElement, title);
		}
		
		var text = element.retrieve('tip:text');
		if (text){
			this.textElement = new Element('div', {'class': 'tip-text'}).inject(this.container);
			this.fill(this.textElement, text);
		}
		
		this.timer = $clear(this.timer);
		this.timer = this.show.delay(this.options.showDelay, this);

		this.position((!this.options.fixed) ? event : {page: element.getPosition()});
	},
	
	elementLeave: function(event){
		$clear(this.timer);
		this.timer = this.hide.delay(this.options.hideDelay, this);
	},
	
	elementMove: function(event){
		this.position(event);
	},
	
	position: function(event){
		var size = window.getSize(), scroll = window.getScroll();
		var tip = {x: this.tip.offsetWidth, y: this.tip.offsetHeight};
		var props = {x: 'left', y: 'top'};
		for (var z in props){
			var pos = event.page[z] + this.options.offsets[z];
			if ((pos + tip[z] - scroll[z]) > size[z]) pos = event.page[z] - this.options.offsets[z] - tip[z];
			this.tip.setStyle(props[z], pos);
		}
	},
	
	fill: function(element, contents){
		(typeof contents == 'string') ? element.set('html', contents) : element.adopt(contents);
	},

	show: function(){
		this.fireEvent('show', this.tip);
	},

	hide: function(){
		this.fireEvent('hide', this.tip);
	}

});

/*
Script: SmoothScroll.js
	Class for creating a smooth scrolling effect to all internal links on the page.

License:
	MIT-style license.
*/

var SmoothScroll = new Class({

	Extends: Fx.Scroll,

	initialize: function(options, context){
		context = context || document;
		var doc = context.getDocument(), win = context.getWindow();
		this.parent(doc, options);
		this.links = (this.options.links) ? $$(this.options.links) : $$(doc.links);
		var location = win.location.href.match(/^[^#]*/)[0] + '#';
		this.links.each(function(link){
			if (link.href.indexOf(location) != 0) return;
			var anchor = link.href.substr(location.length);
			if (anchor && $(anchor)) this.useLink(link, anchor);
		}, this);
		if (!Browser.Engine.webkit419) this.addEvent('complete', function(){
			win.location.hash = this.anchor;
		}, true);
	},

	useLink: function(link, anchor){
		link.addEvent('click', function(event){
			this.anchor = anchor;
			this.toElement(anchor);
			event.stop();
		}.bind(this));
	}

});

/*
Script: Slider.js
	Class for creating horizontal and vertical slider controls.

License:
	MIT-style license.
*/

var Slider = new Class({

	Implements: [Events, Options],

	options: {/*
		onChange: $empty,
		onComplete: $empty,*/
		onTick: function(position){
			if(this.options.snap) position = this.toPosition(this.step);
			this.knob.setStyle(this.property, position);
		},
		snap: false,
		offset: 0,
		range: false,
		wheel: false,
		steps: 100,
		mode: 'horizontal'
	},

	initialize: function(element, knob, options){
		this.setOptions(options);
		this.element = $(element);
		this.knob = $(knob);
		this.previousChange = this.previousEnd = this.step = -1;
		this.element.addEvent('mousedown', this.clickedElement.bind(this));
		if (this.options.wheel) this.element.addEvent('mousewheel', this.scrolledElement.bindWithEvent(this));
		var offset, limit = {}, modifiers = {'x': false, 'y': false};
		switch (this.options.mode){
			case 'vertical':
				this.axis = 'y';
				this.property = 'top';
				offset = 'offsetHeight';
				break;
			case 'horizontal':
				this.axis = 'x';
				this.property = 'left';
				offset = 'offsetWidth';
		}
		this.half = this.knob[offset] / 2;
		this.full = this.element[offset] - this.knob[offset] + (this.options.offset * 2);
		this.min = $chk(this.options.range[0]) ? this.options.range[0] : 0;
		this.max = $chk(this.options.range[1]) ? this.options.range[1] : this.options.steps;
		this.range = this.max - this.min;
		this.steps = this.options.steps || this.full;
		this.stepSize = Math.abs(this.range) / this.steps;
		this.stepWidth = this.stepSize * this.full / Math.abs(this.range) ;
		
		this.knob.setStyle('position', 'relative').setStyle(this.property, - this.options.offset);
		modifiers[this.axis] = this.property;
		limit[this.axis] = [- this.options.offset, this.full - this.options.offset];
		this.drag = new Drag(this.knob, {
			snap: 0,
			limit: limit,
			modifiers: modifiers,
			onDrag: this.draggedKnob.bind(this),
			onStart: this.draggedKnob.bind(this),
			onComplete: function(){
				this.draggedKnob();
				this.end();
			}.bind(this)
		});
		if (this.options.snap) {
			this.drag.options.grid = Math.ceil(this.stepWidth);
			this.drag.options.limit[this.axis][1] = this.full;
		}
	},

	set: function(step){
		if (!((this.range > 0) ^ (step < this.min))) step = this.min;
		if (!((this.range > 0) ^ (step > this.max))) step = this.max;
		
		this.step = Math.round(step);
		this.checkStep();
		this.end();
		this.fireEvent('tick', this.toPosition(this.step));
		return this;
	},

	clickedElement: function(event){
		var dir = this.range < 0 ? -1 : 1;
		var position = event.page[this.axis] - this.element.getPosition()[this.axis] - this.half;
		position = position.limit(-this.options.offset, this.full -this.options.offset);
		
		this.step = Math.round(this.min + dir * this.toStep(position));
		this.checkStep();
		this.end();
		this.fireEvent('tick', position);
	},
	
	scrolledElement: function(event){
		var mode = (this.options.mode == 'horizontal') ? (event.wheel < 0) : (event.wheel > 0);
		this.set(mode ? this.step - this.stepSize : this.step + this.stepSize);
		event.stop();
	},

	draggedKnob: function(){
		var dir = this.range < 0 ? -1 : 1;
		var position = this.drag.value.now[this.axis];
		position = position.limit(-this.options.offset, this.full -this.options.offset);
		this.step = Math.round(this.min + dir * this.toStep(position));
		this.checkStep();
	},

	checkStep: function(){
		if (this.previousChange != this.step){
			this.previousChange = this.step;
			this.fireEvent('change', this.step);
		}
	},

	end: function(){
		if (this.previousEnd !== this.step){
			this.previousEnd = this.step;
			this.fireEvent('complete', this.step + '');
		}
	},

	toStep: function(position){
		var step = (position + this.options.offset) * this.stepSize / this.full * this.steps;
		return this.options.steps ? Math.round(step -= step % this.stepSize) : step;
	},

	toPosition: function(step){
		return (this.full * Math.abs(this.min - step)) / (this.steps * this.stepSize) - this.options.offset;
	}

});

/*
Script: Scroller.js
	Class which scrolls the contents of any Element (including the window) when the mouse reaches the Element's boundaries.

License:
	MIT-style license.
*/

var Scroller = new Class({

	Implements: [Events, Options],

	options: {
		area: 20,
		velocity: 1,
		onChange: function(x, y){
			this.element.scrollTo(x, y);
		}
	},

	initialize: function(element, options){
		this.setOptions(options);
		this.element = $(element);
		this.listener = ($type(this.element) != 'element') ? $(this.element.getDocument().body) : this.element;
		this.timer = null;
		this.coord = this.getCoords.bind(this);
	},

	start: function(){
		this.listener.addEvent('mousemove', this.coord);
	},

	stop: function(){
		this.listener.removeEvent('mousemove', this.coord);
		this.timer = $clear(this.timer);
	},

	getCoords: function(event){
		this.page = (this.listener.get('tag') == 'body') ? event.client : event.page;
		if (!this.timer) this.timer = this.scroll.periodical(50, this);
	},

	scroll: function(){
		var size = this.element.getSize(), scroll = this.element.getScroll(), pos = this.element.getPosition(), change = {'x': 0, 'y': 0};
		for (var z in this.page){
			if (this.page[z] < (this.options.area + pos[z]) && scroll[z] != 0)
				change[z] = (this.page[z] - this.options.area - pos[z]) * this.options.velocity;
			else if (this.page[z] + this.options.area > (size[z] + pos[z]) && size[z] + size[z] != scroll[z])
				change[z] = (this.page[z] - size[z] + this.options.area - pos[z]) * this.options.velocity;
		}
		if (change.y || change.x) this.fireEvent('change', [scroll.x + change.x, scroll.y + change.y]);
	}

});

/*
Script: Accordion.js
	An Fx.Elements extension which allows you to easily create accordion type controls.

License:
	MIT-style license.
*/

var Accordion = new Class({

	Extends: Fx.Elements,

	options: {/*
		onActive: $empty,
		onBackground: $empty,*/
		display: 0,
		show: false,
		height: true,
		width: false,
		opacity: true,
		fixedHeight: false,
		fixedWidth: false,
		wait: false,
		alwaysHide: false
	},

	initialize: function(){
		var params = Array.link(arguments, {'container': Element.type, 'options': Object.type, 'togglers': $defined, 'elements': $defined});
		this.parent(params.elements, params.options);
		this.togglers = $$(params.togglers);
		this.container = $(params.container);
		this.previous = -1;
		if (this.options.alwaysHide) this.options.wait = true;
		if ($chk(this.options.show)){
			this.options.display = false;
			this.previous = this.options.show;
		}
		if (this.options.start){
			this.options.display = false;
			this.options.show = false;
		}
		this.effects = {};
		if (this.options.opacity) this.effects.opacity = 'fullOpacity';
		if (this.options.width) this.effects.width = this.options.fixedWidth ? 'fullWidth' : 'offsetWidth';
		if (this.options.height) this.effects.height = this.options.fixedHeight ? 'fullHeight' : 'scrollHeight';
		for (var i = 0, l = this.togglers.length; i < l; i++) this.addSection(this.togglers[i], this.elements[i]);
		this.elements.each(function(el, i){
			if (this.options.show === i){
				this.fireEvent('active', [this.togglers[i], el]);
			} else {
				for (var fx in this.effects) el.setStyle(fx, 0);
			}
		}, this);
		if ($chk(this.options.display)) this.display(this.options.display);
	},

	addSection: function(toggler, element, pos){
		toggler = $(toggler);
		element = $(element);
		var test = this.togglers.contains(toggler);
		var len = this.togglers.length;
		this.togglers.include(toggler);
		this.elements.include(element);
		if (len && (!test || pos)){
			pos = $pick(pos, len - 1);
			toggler.inject(this.togglers[pos], 'before');
			element.inject(toggler, 'after');
		} else if (this.container && !test){
			toggler.inject(this.container);
			element.inject(this.container);
		}
		var idx = this.togglers.indexOf(toggler);
		toggler.addEvent('click', this.display.bind(this, idx));
		if (this.options.height) element.setStyles({'padding-top': 0, 'border-top': 'none', 'padding-bottom': 0, 'border-bottom': 'none'});
		if (this.options.width) element.setStyles({'padding-left': 0, 'border-left': 'none', 'padding-right': 0, 'border-right': 'none'});
		element.fullOpacity = 1;
		if (this.options.fixedWidth) element.fullWidth = this.options.fixedWidth;
		if (this.options.fixedHeight) element.fullHeight = this.options.fixedHeight;
		element.setStyle('overflow', 'hidden');
		if (!test){
			for (var fx in this.effects) element.setStyle(fx, 0);
		}
		return this;
	},

	display: function(index){
		index = ($type(index) == 'element') ? this.elements.indexOf(index) : index;
		if ((this.timer && this.options.wait) || (index === this.previous && !this.options.alwaysHide)) return this;
		this.previous = index;
		var obj = {};
		this.elements.each(function(el, i){
			obj[i] = {};
			var hide = (i != index) || (this.options.alwaysHide && (el.offsetHeight > 0));
			this.fireEvent(hide ? 'background' : 'active', [this.togglers[i], el]);
			for (var fx in this.effects) obj[i][fx] = hide ? 0 : el[this.effects[fx]];
		}, this);
		return this.start(obj);
	}

});
// Blackbird.js
/*
	Blackbird - Open Source JavaScript Logging Utility
	Author: G Scott Olson
	Web: http://blackbirdjs.googlecode.com/
	     http://www.gscottolson.com/blackbirdjs/
	Version: 1.0

	The MIT License - Copyright (c) 2008 Blackbird Project
*/
( function() {
	var NAMESPACE = 'log';
	var IE6_POSITION_FIXED = true; // enable IE6 {position:fixed}
	
	var bbird;
	var outputList;
	var cache = [];
	
	var state = getState();
	var classes = {};
	var profiler = {};
	var IDs = {
		blackbird: 'blackbird',
		checkbox: 'bbVis',
		filters: 'bbFilters',
		controls: 'bbControls',
		size: 'bbSize'
	}
	var messageTypes = { //order of these properties imply render order of filter controls
		debug: true,
		info: true,
		warn: true,
		error: true,
		profile: true
	};
	
	function generateMarkup() { //build markup
		var spans = [];
		for ( type in messageTypes ) {
			spans.push( [ '<span class="', type, '" type="', type, '"></span>'].join( '' ) );
		}

		var newNode = document.createElement( 'DIV' );
		newNode.id = IDs.blackbird;
		newNode.style.display = 'none';
		newNode.innerHTML = [
			'<div class="header">',
				'<div class="left">',
					'<div id="', IDs.filters, '" class="filters" title="click to filter by message type">', spans.join( '' ), '</div>',
				'</div>',
				'<div class="right">',
					'<div id="', IDs.controls, '" class="controls">',
						'<span id="', IDs.size ,'" title="contract" op="resize"></span>',
						'<span class="clear" title="clear" op="clear"></span>',
						'<span class="close" title="close" op="close"></span>',
					'</div>',
				'</div>',
			'</div>',
			'<div class="main">',
				'<div class="left"></div><div class="mainBody">',
					'<ol>', cache.join( '' ), '</ol>',
				'</div><div class="right"></div>',
			'</div>',
			'<div class="footer">',
				'<div class="left"><label for="', IDs.checkbox, '"><input type="checkbox" id="', IDs.checkbox, '" />Visible on page load</label></div>',
				'<div class="right"></div>',
			'</div>'
		].join( '' );
		return newNode;
	}

	function backgroundImage() { //(IE6 only) change <BODY> tag's background to resolve {position:fixed} support
		var bodyTag = document.getElementsByTagName( 'BODY' )[ 0 ];
		
		if ( bodyTag.currentStyle && IE6_POSITION_FIXED ) {
			if (bodyTag.currentStyle.backgroundImage == 'none' ) {
				bodyTag.style.backgroundImage = 'url(about:blank)';
			}
			if (bodyTag.currentStyle.backgroundAttachment == 'scroll' ) {
				bodyTag.style.backgroundAttachment = 'fixed';
			}
		}
	}

	function addMessage( type, content ) { //adds a message to the output list
		content = ( content.constructor == Array ) ? content.join( '' ) : content;
		if ( outputList ) {
			var newMsg = document.createElement( 'LI' );
			newMsg.className = type;
			newMsg.innerHTML = [ '<span class="icon"></span>', content ].join( '' );
			outputList.appendChild( newMsg );
			scrollToBottom();
		} else {
			cache.push( [ '<li class="', type, '"><span class="icon"></span>', content, '</li>' ].join( '' ) );
		}
	}
	
	function clear() { //clear list output
		outputList.innerHTML = '';
	}
	
	function clickControl( evt ) {
		if ( !evt ) evt = window.event;
		var el = ( evt.target ) ? evt.target : evt.srcElement;

		if ( el.tagName == 'SPAN' ) {
			switch ( el.getAttributeNode( 'op' ).nodeValue ) {
				case 'resize': resize(); break;
				case 'clear':  clear();  break;
				case 'close':  hide();   break;
			}
		}
	}
	
	function clickFilter( evt ) { //show/hide a specific message type
		if ( !evt ) evt = window.event;
		var span = ( evt.target ) ? evt.target : evt.srcElement;

		if ( span && span.tagName == 'SPAN' ) {

			var type = span.getAttributeNode( 'type' ).nodeValue;

			if ( evt.altKey ) {
				var filters = document.getElementById( IDs.filters ).getElementsByTagName( 'SPAN' );

				var active = 0;
				for ( entry in messageTypes ) {
					if ( messageTypes[ entry ] ) active++;
				}
				var oneActiveFilter = ( active == 1 && messageTypes[ type ] );

				for ( var i = 0; filters[ i ]; i++ ) {
					var spanType = filters[ i ].getAttributeNode( 'type' ).nodeValue;

					filters[ i ].className = ( oneActiveFilter || ( spanType == type ) ) ? spanType : spanType + 'Disabled';
					messageTypes[ spanType ] = oneActiveFilter || ( spanType == type );
				}
			}
			else {
				messageTypes[ type ] = ! messageTypes[ type ];
				span.className = ( messageTypes[ type ] ) ? type : type + 'Disabled';
			}

			//build outputList's class from messageTypes object
			var disabledTypes = [];
			for ( type in messageTypes ) {
				if ( ! messageTypes[ type ] ) disabledTypes.push( type );
			}
			disabledTypes.push( '' );
			outputList.className = disabledTypes.join( 'Hidden ' );

			scrollToBottom();
		}
	}

	function clickVis( evt ) {
		if ( !evt ) evt = window.event;
		var el = ( evt.target ) ? evt.target : evt.srcElement;

		state.load = el.checked;
		setState();
	}
	
	
	function scrollToBottom() { //scroll list output to the bottom
	    if(outputList){
		outputList.scrollTop = outputList.scrollHeight;
		}
	}
	
	function isVisible() { //determine the visibility
		return ( bbird.style.display == 'block' );
	}

	function hide() { 
	  bbird.style.display = 'none';
	}
			
	function show() {
		var body = document.getElementsByTagName( 'BODY' )[ 0 ];
		body.removeChild( bbird );
		body.appendChild( bbird );
		bbird.style.display = 'block';
	}
	
	//sets the position
	function reposition( position ) {
		if ( position === undefined || position == null ) {
			position = ( state && state.pos === null ) ? 1 : ( state.pos + 1 ) % 4; //set to initial position ('topRight') or move to next position
		}
				
		switch ( position ) {
			case 0: classes[ 0 ] = 'bbTopLeft'; break;
			case 1: classes[ 0 ] = 'bbTopRight'; break;
			case 2: classes[ 0 ] = 'bbBottomLeft'; break;
			case 3: classes[ 0 ] = 'bbBottomRight'; break;
		}
		state.pos = position;
		setState();
	}

	function resize( size ) {
		if ( size === undefined || size === null ) {
			size = ( state && state.size == null ) ? 0 : ( state.size + 1 ) % 2;
	  	}

		classes[ 1 ] = ( size === 0 ) ? 'bbSmall' : 'bbLarge'

		var span = document.getElementById( IDs.size );
		if( span != null){
		    span.title = ( size === 1 ) ? 'small' : 'large';
		    span.className = span.title;	  
        }
		state.size = size;
		setState();
		scrollToBottom();
	}

	function setState() {
		var props = [];
		for ( entry in state ) {
			var value = ( state[ entry ] && state[ entry ].constructor === String ) ? '"' + state[ entry ] + '"' : state[ entry ]; 
			props.push( entry + ':' + value );
		}
		props = props.join( ',' );
		
		var expiration = new Date();
		expiration.setDate( expiration.getDate() + 14 );
		document.cookie = [ 'blackbird={', props, '}; expires=', expiration.toUTCString() ,';' ].join( '' );

		var newClass = [];
		for ( word in classes ) {
			newClass.push( classes[ word ] );
		}
		if(bbird){
		    bbird.className = newClass.join( ' ' );
		}
	}
	
	function getState() {
		var re = new RegExp( /blackbird=({[^;]+})(;|\b|$)/ );
		var match = re.exec( document.cookie );
		return ( match && match[ 1 ] ) ? eval( '(' + match[ 1 ] + ')' ) : { pos:null, size:null, load:null };
	}
	
	//event handler for 'keyup' event for window
	function readKey( evt ) {
		if ( !evt ) evt = window.event;
		var code = 113; //F2 key
					
		if ( evt && evt.keyCode == code ) {
					
			var visible = isVisible();
					
			if ( visible && evt.shiftKey && evt.altKey ) clear();
			else if	 (visible && evt.shiftKey ) reposition();
			else if ( !evt.shiftKey && !evt.altKey ) {
			  ( visible ) ? hide() : show();
			}
		}
	}

	//event management ( thanks John Resig )
	function addEvent( obj, type, fn ) {
		var obj = ( obj.constructor === String ) ? document.getElementById( obj ) : obj;
		if ( obj.attachEvent ) {
			obj[ 'e' + type + fn ] = fn;
			obj[ type + fn ] = function(){ obj[ 'e' + type + fn ]( window.event ) };
			obj.attachEvent( 'on' + type, obj[ type + fn ] );
		} else obj.addEventListener( type, fn, false );
	}
	function removeEvent( obj, type, fn ) {
		var obj = ( obj.constructor === String ) ? document.getElementById( obj ) : obj;
		if ( obj.detachEvent ) {
			obj.detachEvent( 'on' + type, obj[ type + fn ] );
			obj[ type + fn ] = null;
	  } else obj.removeEventListener( type, fn, false );
	}

	window[ NAMESPACE ] = {
		toggle:
			function() { ( isVisible() ) ? hide() : show(); },
		resize:
			function() { resize(); },
		clear:
			function() { clear(); },
		move:
			function() { reposition(); },
		debug: 
			function( msg ) { addMessage( 'debug', msg ); },
		warn:
			function( msg ) { addMessage( 'warn', msg ); },
		info:
			function( msg ) { addMessage( 'info', msg ); },
		error:
			function( msg ) { addMessage( 'error', msg ); },
		profile: 
			function( label ) {
				var currentTime = new Date(); //record the current time when profile() is executed
				
				if ( label == undefined || label == '' ) {
					addMessage( 'error', '<b>ERROR:</b> Please specify a label for your profile statement' );
				}
				else if ( profiler[ label ] ) {
					addMessage( 'profile', [ label, ': ', currentTime - profiler[ label ],	'ms' ].join( '' ) );
					delete profiler[ label ];
				}
				else {
					profiler[ label ] = currentTime;
					addMessage( 'profile', label );
				}
				return currentTime;
			}
	}

	addEvent( window, 'load', 
		/* initialize Blackbird when the page loads */
		function() {
			var body = document.getElementsByTagName( 'BODY' )[ 0 ];
			bbird = body.appendChild( generateMarkup() );
			outputList = bbird.getElementsByTagName( 'OL' )[ 0 ];
		
			backgroundImage();
		
			//add events
			addEvent( IDs.checkbox, 'click', clickVis );
			addEvent( IDs.filters, 'click', clickFilter );
			addEvent( IDs.controls, 'click', clickControl );
			addEvent( document, 'keyup', readKey);

			resize( state.size );
			reposition( state.pos );
			if ( state.load ) {
				show();
				document.getElementById( IDs.checkbox ).checked = true; 
			}

			scrollToBottom();

			window[ NAMESPACE ].init = function() {
				show();
				window[ NAMESPACE ].error( [ '<b>', NAMESPACE, '</b> can only be initialized once' ] );
			}

			addEvent( window, 'unload', function() {
				removeEvent( IDs.checkbox, 'click', clickVis );
				removeEvent( IDs.filters, 'click', clickFilter );
				removeEvent( IDs.controls, 'click', clickControl );
				removeEvent( document, 'keyup', readKey );
			});
		});
})();
// HistoryManager.js
/* 	Class:
		HistoryManager

	Author:
		Neil Jenkins
		
	Version:
		1.1 (2007-09-17)
		
	Version history:
		1.1 Update to allow IE to keep its history even when navigating to a different site and back.
		1.0 Initial release
		
	Description:
		Javascript class for restoring use of the back/forward buttons on web pages that are completely
		dynamic and therefore don't actually navigate to different pages.
		
	Usage:
		Calling new HistoryManager() returns an instance of the History Manager
		e.g. var h = new HistoryManager();

		Public interfaces:

		addState(String: hash)
			This method creates a new history state in the browser (as though a link has been clicked)
			and also sets the location hash to the supplied argument to allow for bookmarking.

			The hash is expected to be a vaild URI hash component; the global function encodeURI() is useful for
			this. Encoding the state of a javascript program into a string is very much specific to each program therefore
			no processing is done by this module; it is left to the subscribing functions to encode and parse the state.
			
			e.g. h.addState('tab3');
		
		addEvent(String: event, Function: callbackFunction)
			This method subscribes functions to be called when the history state changes.
			NB The only event currently available is 'onHistoryChange'.
			   Functions subscribed to this event will be called with the hash of the new state as their argument.
			e.g. h.addEvent('onHistoryChange', functionToCall);
		
		removeEvent(String: event, Function: callbackFunction)
			This method removes functions subscribed to the HistoryManager by the addEvent method		
			e.g. h.removeEvent('onHistoryChange', functionToRemove);

		getCurrentLocation()
			Returns the current hash.
			e.g. var state = h.getCurrentLocation();

	Dependencies:
		mootools: http://mootools.net

	Notes:
		This is a singleton; there can only ever be one instance of the class. Calling new HistoryManger() for a second time
		will simply return a reference to the current instance.
		Supports Gecko, Safari, Opera and IE
*/

var HistoryManager = (function() {

	var HistoryManagerSingleton = new Class({
		
		initialize: function() {
			this._currentLocation = this._getHash();
			
			var historyManager = this;			
			
			if (window.ie) {
				this.addState = this._addStateIE;
				this._iframe = new Element('iframe', {
					src: "javascript:'<html></html>'",
					styles: {
						'position': 'absolute',
						'top': '-1000px'
					}
				}).inject(document.body).contentWindow;
				
				$justForIE = function(hash) {
					historyManager._getHash = function() { return hash; }
					historyManager._monitorDefault.call(historyManager);
					location.hash = hash;
				}
				
				function waitForIframeLoad() {
					if (historyManager._iframe && historyManager._iframe.document && historyManager._iframe.document.body) {
						if (!historyManager._iframe.document.body.innerHTML)
								historyManager.addState(historyManager._currentLocation, true);
					}
					else setTimeout(waitForIframeLoad, 50);
				}
				waitForIframeLoad();
			}
			else if (window.webkit419) {
				this._form = new Element("form", {method: 'get'}).inject(document.body);
				this._historyCounter = history.length;
				this._stateHistory = [];
				this._stateHistory[history.length] = this._getHash();
				
				this.addState = this._addStateSafari;
				this._monitorSafari.periodical(250, this);
			}
			else if (window.opera) {
				this.addState = this._addStateDefault;
	
				$justForOpera = function() {
					historyManager._monitorDefault.call(historyManager);
				}
				new Element('img', {
					src: "javascript:location.href='javascript:$justForOpera();';",
					style: "position: absolute; top: -1000px;"
				}).inject(document.body);
			}
			else {
				this.addState = this._addStateDefault;
				this._monitorDefault.periodical(250, this);
			}
		},
		
		getCurrentLocation: function() {
			return this._currentLocation;
		},
		
		_getHash: function() {
			return location.href.split('#')[1] || '';
		},
		
		_addStateIE: function(hash, override) {
			if (this._currentLocation == hash && !override) return;

			this._currentLocation = hash;
			this._iframe.document.write('<html><body onload="top.$justForIE(\'', hash ,'\');">Loaded</body></html>');
			this._iframe.document.close();
		},
		
		_addStateSafari: function(hash) {
			if (this._currentLocation == hash) return;
	
			this._form.setProperty('action', '#' + hash).submit()
			this._currentLocation = hash;
			this._stateHistory[history.length] = this._getHash();
			this._historyCounter = history.length;
		},
	
		_monitorSafari: function() {	
			if (history.length != this._historyCounter) {
				this._historyCounter = history.length;
				this._currentLocation = this._stateHistory[history.length];
				this.fireEvent('onHistoryChange', [this._stateHistory[history.length]]);
			}
		},
	
		_addStateDefault: function(hash) {
			if (this._currentLocation == hash) return;
			location.hash = '#' + hash;
			this._currentLocation = hash;
		},
	
		_monitorDefault: function() {
			var hash = this._getHash();
	
			if (hash != this._currentLocation) {
				this._currentLocation = hash;
				this.fireEvent('onHistoryChange', [hash]);
			}
		}
	});
	
	HistoryManagerSingleton.implement(new Events);
	
	var singleton;

	return function() {
		return singleton ? singleton : singleton = new HistoryManagerSingleton();
	}
	
})();
// Site.js

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
// Tutorial.js

var Tutorial = {

    getPanel : function() {
        return $("tutorial");
    },

    show : function(tutorial) {
        if( window.overrideTutorial != null ) {
            tutorial = window.overrideTutorial;
        }
        if( this[tutorial] != null ) {
            Information.leftInfofixed = true;
            this[tutorial]();
        } else {
            this.showNoTutorial();
        }
    },
    
    hide : function() {
        this.getPanel().setStyle("display", "none");
        this.autoNext = null;
        Information.leftInfofixed = false;
    },
    
    start : function() {
        if( window.autoStartTutorial != null ) {
            Tutorial.show(window.autoStartTutorial);
        }
    },
    
    advance : function() {
        var next = this.autoNext;
        this.autoNext = null;
    
        if( next != null ) {
            window.tutorialEnabled = true;
            this[next]();
        }
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Quests Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     CheckpointQuest : function() {
        this.showPanel({
            titleToken : "QuestsTutorial",
            contentToken : "QuestsTutorialContent",
            refElemId : $("quests"),
            offsetX : 250,
            offsetY : -150,
            width : 500,
            next : "End"
        });
    },
    
    TaskQuest : function() {
        this.showPanel({
            titleToken : "QuestsTutorial",
            contentToken : "QuestsTaskContent",
            refElemId : $("quests"),
            offsetX : 250,
            offsetY : -150,
            width : 500,
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Home Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    Home : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContent",
            refElemId : $("genericMessages"),
            offsetX : 80,
            offsetY : 0,
            width : 500,
            arrow : "top",
            next : "HomeAH"
        });
    },
    
    HomeAH : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContent2",
            refElemId : $("ahAd"),
            offsetX : -300,
            offsetY : -90,
            width : 250,
            arrow : "right",
            previous : "Home",
            next : "HomeCharts"
        });
    },
    
    HomeCharts : function() {
        this.showPanel({
            titleToken : "HomeTutorial",
            contentToken : "HomeTutorialContentCharts",
            refElemId : $("charts"),
            offsetX :-300,
            offsetY : -90,
            width : 250,
            arrow : "right",
            previous : "HomeAH",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Battle Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     Battle : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 25,
            width : 400,
            next : "BattleSelect"
        });
    },
    
    BattleSelect : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleSelectContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 150,
            width : 400,
            follow : false,
            arrow : "bottom"
        });
        this.autoNext = "BattleUnitSelected";
    },
    
    BattleUnitSelected : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : -90,
            width : 400,
            arrow : "left",
            next : "BattleUnitSelectedStrong"
        });
    },
    
    BattleUnitSelectedStrong : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedStrongContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 40,
            width : 400,
            follow: false,
            arrow : "left",
            previous : "BattleUnitSelected",
            next : "BattleUnitSelectedWeak"
        });
    },
    
    BattleUnitSelectedWeak : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedWeakContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 155,
            width : 400,
            follow: false,
            arrow : "left",
            previous : "BattleUnitSelectedStrong",
            next : "BattleUnitSelectedAttack"
        });
    },
    
    BattleUnitSelectedAttack : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedAttackContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 250,
            width : 400,
            arrow : "left",
            previous : "BattleUnitSelectedWeak",
            next : "BattleUnitSelectedMov"
        });
    },
    
    BattleUnitSelectedMov : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovContent",
            refElemId : $("battleField"),
            offsetX : -10,
            offsetY : 375,
            width : 400,
            arrow : "left",
            previous : "BattleUnitSelectedAttack",
            next : "BattleUnitSelectedMovPoints"
        });
    },
    
    BattleUnitSelectedMovPoints : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovPointsContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 15,
            width : 400,
            arrow : "right"
        });
        this.autoNext = "BattleUnitSelectedMovPoints2";
    },
    
    BattleUnitSelectedMovPoints2 : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSelectedMovPoints2Content",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 15,
            width : 400,
            arrow : "right",
            next : "BattleUnitSplit"
        });
    },
    
    BattleUnitSplit: function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitSplitContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 75,
            width : 400,
            arrow : "right",
            previous : "BattleUnitSelectedMovPoints2",
            next : "BattleUnitDirection"
        });
    },
    
    BattleUnitDirection : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleUnitDirectionContent",
            refElemId : $("battleField"),
            offsetX : 50,
            offsetY : 280,
            width : 400,
            arrow : "right",
            previous : "BattleUnitSplit",
            next : "BattleCalculator"
        });
    },
    
    BattleCalculator : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleCalculatorContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 250,
            width : 400,
            arrow : "bottom",
            previous : "BattleUnitDirection",
            next : "BattleOptions"
        });
    },
    
    BattleOptions : function() {
        this.showPanel({
            titleToken : "BattleTutorial",
            contentToken : "BattleOptionsContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -85,
            width : 400,
            arrow : "right",
            previous : "BattleCalculator",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Regicide Battle Deploy Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     RegicideDeploy : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "RegicideDeployContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -90,
            width : 400,
            next : "BattleDeploy"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Battle Deploy Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     BattleDeploy : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -90,
            width : 400,
            next : "BattleDeploySelect"
        });
    },
    
    BattleDeploySelect : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeploySelectContent",
            refElemId : $("initialContainers"),
            offsetX : 40,
            offsetY : -180,
            width : 400,
            arrow : "bottom"
        });
        this.autoNext = "BattleDeployDrop";
    },
    
    BattleDeployDrop : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployDropContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 150,
            width : 400,
            arrow : "bottom"
        });
        this.autoNext = "BattleDeployDropNext";
    },
    
    BattleDeployDropNext : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployDropNextContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : 80,
            width : 400,
            arrow : "right",
            next : "BattleDeployFinish"
        });
    },
    
    BattleDeployFinish : function() {
        this.showPanel({
            titleToken : "BattleDeployTutorial",
            contentToken : "BattleDeployFinishContent",
            refElemId : $("battleField"),
            offsetX : 40,
            offsetY : -50,
            width : 400,
            arrow : "right",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Private Zone Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     PrivateZone : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "PrivateZoneTutorialContent",
            refElemId : $("universe"),
            offsetX : 180,
            offsetY : 0,
            width : 400,
            next : "HomePlanet"
        });
    },
    
    HomePlanet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "HomePlanetContent",
            refElemId : $("universe"),
            offsetX : 225,
            offsetY : -55,
            arrow : "left",
            width : 300,
            previous: "PrivateZone",
            next : "YourFirstFleet"
        });
    },
    
    YourFirstFleet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "YourFirstFleetContent",
            refElemId : $("universe"),
            offsetX : 80,
            offsetY : -60,
            arrow : "top",
            width : 300,
            previous: "HomePlanet",
            next : "MoveFleet"
        });
    },
    
    MoveFleet : function() {
        this.showPanel({
            titleToken : "PrivateZoneTutorial",
            contentToken : "MoveFleetContent",
            refElemId : $("universe"),
            offsetX : 280,
            offsetY : 0,
            width : 300,
            previous: "YourFirstFleet",
            next : "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Bugs Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     BugsPlanets : function() {
        this.LightHumansPlanets();
        this["LHMainFacilityPanelX"] = 0;
        this["LHBuildPanelX"] = 185;
        this["LHBuildPanelY"] = 220;
        this["LHBuildingInConstructionX"] = 150;
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        DarkHumans Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
     
     DarkHumansPlanets : function() {
        this.LightHumansPlanets();
        this["LHMainFacilityPanelX"] = 0;
        this["LHBuildPanelX"] = 135;
        this["LHBuildPanelY"] = 270;
        this["LHBuildingInConstructionX"] = 150;
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        LightHumans Planets Tutorial
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    LightHumansPlanets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "PlanetsTutorialContent",
            refElemId : $("tutRef"),
            offsetX : 135,
            offsetY : 0,
            width : 400,
            next : "LHResourcesPanel"
        });
    },
    
    LHResourcesPanel : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "ResourcesPanelContent",
            refElemId : $("playerResources"),
            offsetX : 296,
            offsetY : -80,
            arrow: "top",
            width : 400,
            previous : "LightHumansPlanets",
            next : "LHIncomePanel"
        });
    },
    
    LHIncomePanel : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "IncomeContent",
            refElemId : $("tutRef"),
            offsetX : 225,
            offsetY : 115,
            arrow: "right",
            width : 400,
            previous : "LHResourcesPanel",
            next : "LHMainFacilityPanel"
        });
    },
    
    LHMainFacilityPanel : function() {
        var x = this["LHMainFacilityPanelX"] != null ? this["LHMainFacilityPanelX"] : -74;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "MainFacilityContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : 0,
            arrow: "right",
            width : 200,
            previous : "LHIncomePanel",
            next : "LHBuildPanel"
        });
    },
    
    LHBuildPanel : function() {
        var x = this["LHBuildPanelX"] != null ? this["LHBuildPanelX"] : 15;
        var y = this["LHBuildPanelY"] != null ? this["LHBuildPanelY"] : 200;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : y,
            arrow: "right",
            follow : false,
            width : 200
            
        });
        this.autoNext = "LHBuildUpgradeScreen"
    },
    
    LHBuildUpgradeScreen : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityScreenContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next : "LHBuildUpgradeAction"
        });
    },
    
    LHBuildUpgradeAction : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "BuildFacilityActionContent",
            refElemId : $("tutRef"),
            offsetX : 215,
            offsetY : 75,
            arrow: "right",
            follow:false,
            width : 200
        });
        this.autoNext = "LHBuildingInConstruction";
    },
    
    LHBuildingInConstruction : function() {
        var x = this["LHBuildingInConstructionX"] != null ? this["LHBuildingInConstructionX"] : 15;
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "LHBuildingInConstructionContent",
            refElemId : $("tutRef"),
            offsetX : x,
            offsetY : 200,
            width : 200,
            next : "LHGoToFleets"
        });
    },
    
    LHGoToFleets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "LHGoToFleetsContent",
            refElemId : $("tutRef"),
            arrow : "left",
            offsetX : 530,
            offsetY : -125,
            width : 200
        });
        this.autoNext = "OnFleetsScreen";
    },
    
    OnFleetsScreen : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "OnFleetsScreenContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next: "MoveUnitsFromFleets"
        });
    },
    
    MoveUnitsFromFleets : function() {
        this.showPanel({
            titleToken : "PlanetsTutorial",
            contentToken : "MoveUnitsFromFleetsContent",
            refElemId : $("tutRef"),
            offsetX : 138,
            offsetY : 0,
            width : 400,
            next: "End"
        });
    },
    
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Other
     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    
    End : function() {
        this.showPanel({
            titleToken : "TutorialEnd",
            contentToken : "TutorialEndContent",
            refElemId : $("siteFooter"),
            offsetX : 600,
            offsetY : -170
        });
        Information.leftInfofixed = false;
    },
    
    showNoTutorial : function() {
        this.showPanel({
            titleToken : "NoTutorial",
            contentToken : "NoTutorialContent",
            refElemId : $("siteFooter"),
            offsetX : 600,
            offsetY : -170,
            follow: false
        });
    },
    
    showPanel : function(args) {
    
        if( window.tutorialEnabled != null && !window.tutorialEnabled ) {
            return;
        }
    
        var panel = this.getPanel();
        var content = $("tutorialContent");
        var middle = $("middlet");
        
        //~~~~~~~~~~~~~~~~~~~~
        // Prepare anchor for positioning
        //~~~~~~~~~~~~~~~~~~~~
        var anchorId = "followtutorial_" + args.contentToken;       
        var anchor = panel.getFirst();
        anchor.id = anchorId;
        anchor.name = anchorId; 
       
        //~~~~~~~~~~~~~~~~~~~~
        // Set content
        //~~~~~~~~~~~~~~~~~~~~
        content.innerHTML = Language.getToken(args.contentToken);
        $("tutorialTitle").innerHTML = Language.getToken(args.titleToken);
        
        //~~~~~~~~~~~~~~~~~~~~
        // Remove unnecessary arrows
        //~~~~~~~~~~~~~~~~~~~~
        $("left").setStyle("display", "none");
        $("right").setStyle("display", "none");
        $("top").setStyle("display", "none");
        $("bottom").setStyle("display", "none");
        
        if( args.arrow != null ) {
            $(args.arrow).setStyle("display", "block");
        }
        
        //~~~~~~~~~~~~~~~~~~~~
        // Prepare panel
        //~~~~~~~~~~~~~~~~~~~~
        var target = $(args.refElemId);
        var pos = target.getPosition();
        
        var offsetX = args.offsetX ? args.offsetX : 0;
        var offsetY = args.offsetY ? args.offsetY : 0;
        var width = args.width ? args.width : 300;
        var masterWidth = width + 66;
        var height = args.height ? args.height : "auto";
        
        panel.setStyles({
            display: "block",
            top: pos.y + offsetY,
            left: pos.x + offsetX,
            width: masterWidth,
            height: height
        });
        
        middle.setStyles({
            width: width,
            height: height
        });
        
        //~~~~~~~~~~~~~~~~~~~~
        // Nav Links
        //~~~~~~~~~~~~~~~~~~~~
        if( args.next != null || args.previous != null ) {
            var nav = "<div class='nav'>";
            if( args.previous != null ) {
                nav += "<a class='nav' href='javascript:Tutorial."+args.previous+"();'>"+Language.getToken("Previous")+"</a>";
            }
            if( args.next != null ) {
                nav += "<a class='nav' href='javascript:Tutorial."+args.next+"();'>"+Language.getToken("Next")+"</a>";
            }
            nav += "</div>";
            content.innerHTML += nav;
        }
        
        //~~~~~~~~~~~~~~~~~~~~
        // Move browser to panel
        //~~~~~~~~~~~~~~~~~~~~
        if( (args.follow != null && args.follow) || args.follow == null ) {
            window.location.hash = "#" + anchorId;
        }
    }
};

window.addEvent('domready', Tutorial.start);

// AttackUtils.js
var AttackUtils = {
	
	attack : function () {
		if( globalCounter == 1 ) {
			RaiseError.attackFirstMove();
			return;
		}
		
		var isUltimateUnit = lastSelection.isUltimateUnit();
				
		if( isUltimateUnit && !movesObj.hasValidMoves(6) ) {
			RaiseError.ultimateUnitAttack();
			Information.fixed = false;
			return;
		}
			
		if( !lastSelection.hasAttacked ) {
			lastSelection.hasAttacked = true;
			Utils.registerAttack(lastSelection,currentEnemy);
			$("enemy").className = "invisible";
						
			movesObj.decrementMoves(lastSelection.unit().attackCost);
					
			lastSelection.setClass("");
			lastSelection = null;
			Information.eraseAttackInfo();
			Information.fixed = false;
		}
	},
	
	canAttack : function( dst ) {
		if( lastSelection != null && !lastSelection.hasAttacked )  {	
		    var unit = lastSelection.unit();
		    if( !unit.canAttack ) {
		        return false;
		    }
		
			var src = lastSelection.id.split("_");
			var r = unit.range;
			var attack = new Attack( src, dst, r, unit );
			
			var can = attack[lastSelection.getPosition()]();
			if ( can ) {
				Information.fillAttackInfo( src, dst );
			}
			return can;
		}
		return false;
	},
	
	calculatePenalty : function( damage, src, dst) {
		var distance = AttackUtils.penalty(src,dst);
		if( distance < 4 ) {
			return damage;
		}
		var percent = (7 - distance)*0.25;
		
		return Math.round( (percent * damage) + 0.5 );
	},
	
	calculatePenaltyByDistance : function( damage, distance) {
		if( distance < 4 ) {
			return damage;
		}
		var percent = (7 - distance)*0.25;
		
		return Math.round( (percent * damage) + 0.5 );
	},
	
	penalty : function( src, dst) {
		
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);
		
		if( s_x == 9 ) {
			return Math.abs(s_x-d_x);
		}
		
		if( s_y == d_y ) {
			return Math.abs(s_x-d_x);
		}
		return Math.abs(s_y-d_y);
	},
	
	addBonusAttack : function(object, attack, target, terrain ) {
		attack += AttackUtils.addUp( object.attackTargets, target.name );
		attack += AttackUtils.addUp( object.attackTargets, target.category );
		attack += AttackUtils.addUp( object.attackTargets, terrain );
		attack += AttackUtils.addUp( object.attackTargets, target.level );
		attack += AttackUtils.addUp( object.attackTargets, target.type );
		
		return attack;
	},

	addBonusDefense : function(object, defense, target, terrain ) {
		defense += AttackUtils.addUp( object.defenseTargets, target.name );
		defense += AttackUtils.addUp( object.defenseTargets, target.category );
		defense += AttackUtils.addUp( object.defenseTargets, terrain );
		defense += AttackUtils.addUp( object.defenseTargets, target.level );
		defense += AttackUtils.addUp( object.defenseTargets, target.type );
		
		return defense;
	},
	
	addBonusRange : function(object, range, target, terrain ) {
		range += AttackUtils.addUp( object.rangeTargets, target.name );
		range += AttackUtils.addUp( object.rangeTargets, target.category );
		range += AttackUtils.addUp( object.rangeTargets, terrain );
		range += AttackUtils.addUp( object.rangeTargets, target.level );
		range += AttackUtils.addUp( object.rangeTargets, target.type );
		
		return range;
	},

	getAttack : function( target, terrain ) {
		return AttackUtils.addBonusAttack( this,this.baseAttack, target, terrain);
	},

	getDefense : function( target, terrain ){
		return AttackUtils.addBonusDefense( this,this.baseDefense,target, terrain);
	},
	
	getRange : function( target, terrain ){
		return AttackUtils.addBonusRange( this,this.range,target, terrain);
	},
	
	addUp : function( hash, key ){
		if( hash == null ) {
			return 0;
		}
		
		var specific = hash[key];
		if( specific == null ) {
			return 0;
		}
		return specific;
	},
	
	ultimateUnitAttackCoord : function() {
	    if( Utils.numberOfPlayers() == 2 ) {
	        return 9;
	    }
	    return 13;
	}
}
// Information.js

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

// Units.js
if( window.AttackUtils == null ) {
	window.AttackUtils = { getAttack : null, getDefense : null};
}
var Unit = {
	'bozer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Bozer',
		'code' : 'bz',
		'category' : 'Heavy',
		'baseAttack' : 3200,
		'attackCost' : 1,
		'baseDefense' : 2800,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Air':4000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bz': function() {
		return Unit['bozer'];
	},

	'commanderfox': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'CommanderFox',
		'code' : 'cf',
		'category' : 'Heavy',
		'baseAttack' : 50000,
		'attackCost' : 1,
		'baseDefense' : 100000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cf': function() {
		return Unit['commanderfox'];
	},

	'hiveprotector': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HiveProtector',
		'code' : 'hp',
		'category' : 'Medium',
		'baseAttack' : 1000,
		'attackCost' : 1,
		'baseDefense' : 4500,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hp': function() {
		return Unit['hiveprotector'];
	},

	'doomer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Doomer',
		'code' : 'doo',
		'category' : 'Heavy',
		'baseAttack' : 6000,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'doo': function() {
		return Unit['doomer'];
	},

	'cypher': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Cypher',
		'code' : 'cp',
		'category' : 'Light',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cp': function() {
		return Unit['cypher'];
	},

	'stinger': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Stinger',
		'code' : 'sg',
		'category' : 'Medium',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Light':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sg': function() {
		return Unit['stinger'];
	},

	'captainwolf': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'CaptainWolf',
		'code' : 'cw',
		'category' : 'Heavy',
		'baseAttack' : 100000,
		'attackCost' : 1,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cw': function() {
		return Unit['captainwolf'];
	},

	'destroyer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Destroyer',
		'code' : 'dy',
		'category' : 'Medium',
		'baseAttack' : 1100,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : true,
		'range' : 1,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dy': function() {
		return Unit['destroyer'];
	},

	'myst': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Myst',
		'code' : 'mt',
		'category' : 'Medium',
		'baseAttack' : 300,
		'attackCost' : 1,
		'baseDefense' : 200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'mt': function() {
		return Unit['myst'];
	},

	'scarab': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Scarab',
		'code' : 'sc',
		'category' : 'Medium',
		'baseAttack' : 1900,
		'attackCost' : 1,
		'baseDefense' : 2300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sc': function() {
		return Unit['scarab'];
	},

	'toxic': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Toxic',
		'code' : 'tx',
		'category' : 'Light',
		'baseAttack' : 450,
		'attackCost' : 1,
		'baseDefense' : 600,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Organic':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'tx': function() {
		return Unit['toxic'];
	},

	'fist': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Fist',
		'code' : 'ft',
		'category' : 'Heavy',
		'baseAttack' : 4200,
		'attackCost' : 1,
		'baseDefense' : 1800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'ft': function() {
		return Unit['fist'];
	},

	'flag': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Flag',
		'code' : 'fg',
		'category' : 'Special',
		'baseAttack' : 1,
		'attackCost' : 1,
		'baseDefense' : 10000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'fg': function() {
		return Unit['flag'];
	},

	'darktaurus': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkTaurus',
		'code' : 'dt',
		'category' : 'Heavy',
		'baseAttack' : 6800,
		'attackCost' : 1,
		'baseDefense' : 3500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dt': function() {
		return Unit['darktaurus'];
	},

	'egg': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Egg',
		'code' : 'eg',
		'category' : 'Light',
		'baseAttack' : 0,
		'attackCost' : 1,
		'baseDefense' : 1,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 0,
		'movementCost' : 0,
		'movementType' : 'none',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'eg': function() {
		return Unit['egg'];
	},

	'jumper': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Jumper',
		'code' : 'jp',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'jp': function() {
		return Unit['jumper'];
	},

	'battlemoon': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'BattleMoon',
		'code' : 'bm',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 6,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 6,
		'movementType' : 'none',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bm': function() {
		return Unit['battlemoon'];
	},

	'metallicbeard': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'MetallicBeard',
		'code' : 'mb',
		'category' : 'Heavy',
		'baseAttack' : 100000,
		'attackCost' : 1,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'mb': function() {
		return Unit['metallicbeard'];
	},

	'darkcrusader': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkCrusader',
		'code' : 'dc',
		'category' : 'Heavy',
		'baseAttack' : 2800,
		'attackCost' : 1,
		'baseDefense' : 2000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dc': function() {
		return Unit['darkcrusader'];
	},

	'scourge': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Scourge',
		'code' : 'so',
		'category' : 'Medium',
		'baseAttack' : 1450,
		'attackCost' : 1,
		'baseDefense' : 2000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'so': function() {
		return Unit['scourge'];
	},

	'crawler': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Crawler',
		'code' : 'cr',
		'category' : 'Medium',
		'baseAttack' : 2000,
		'attackCost' : 1,
		'baseDefense' : 1800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : true,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':2000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cr': function() {
		return Unit['crawler'];
	},

	'rain': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Rain',
		'code' : 'r',
		'category' : 'Light',
		'baseAttack' : 120,
		'attackCost' : 1,
		'baseDefense' : 70,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':1200

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'r': function() {
		return Unit['rain'];
	},

	'samurai': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Samurai',
		'code' : 's',
		'category' : 'Light',
		'baseAttack' : 150,
		'attackCost' : 1,
		'baseDefense' : 450,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	's': function() {
		return Unit['samurai'];
	},

	'panther': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Panther',
		'code' : 'p',
		'category' : 'Light',
		'baseAttack' : 300,
		'attackCost' : 1,
		'baseDefense' : 300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'p': function() {
		return Unit['panther'];
	},

	'queen': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Queen',
		'code' : 'q',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 4,
		'baseDefense' : 1000000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 4,
		'movementType' : 'drop',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': false,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'q': function() {
		return Unit['queen'];
	},

	'darkrain': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkRain',
		'code' : 'dr',
		'category' : 'Light',
		'baseAttack' : 190,
		'attackCost' : 1,
		'baseDefense' : 20,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':600

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dr': function() {
		return Unit['darkrain'];
	},

	'worm': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Worm',
		'code' : 'w',
		'category' : 'Medium',
		'baseAttack' : 1200,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'w': function() {
		return Unit['worm'];
	},

	'taurus': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Taurus',
		'code' : 't',
		'category' : 'Heavy',
		'baseAttack' : 5000,
		'attackCost' : 1,
		'baseDefense' : 6800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	't': function() {
		return Unit['taurus'];
	},

	'kamikaze': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Kamikaze',
		'code' : 'k',
		'category' : 'Medium',
		'baseAttack' : 4000,
		'attackCost' : 1,
		'baseDefense' : 1,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'k': function() {
		return Unit['kamikaze'];
	},

	'pretorian': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Pretorian',
		'code' : 'h',
		'category' : 'Medium',
		'baseAttack' : 450,
		'attackCost' : 1,
		'baseDefense' : 5550,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'h': function() {
		return Unit['pretorian'];
	},

	'seeker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Seeker',
		'code' : 'sk',
		'category' : 'Light',
		'baseAttack' : 100,
		'attackCost' : 1,
		'baseDefense' : 40,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':500

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sk': function() {
		return Unit['seeker'];
	},

	'nova': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Nova',
		'code' : 'n',
		'category' : 'Heavy',
		'baseAttack' : 2700,
		'attackCost' : 1,
		'baseDefense' : 1900,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Organic':4000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'n': function() {
		return Unit['nova'];
	},

	'maggot': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Maggot',
		'code' : 'm',
		'category' : 'Light',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : true,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'm': function() {
		return Unit['maggot'];
	},

	'blackwidow': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'BlackWidow',
		'code' : 'b',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : true,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'b': function() {
		return Unit['blackwidow'];
	},

	'crusader': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Crusader',
		'code' : 'c',
		'category' : 'Heavy',
		'baseAttack' : 2400,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'c': function() {
		return Unit['crusader'];
	},

	'anubis': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Anubis',
		'code' : 'a',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			'Heavy':1600

		},
		'rangeTargets' : {
			
		}
	},

	'a': function() {
		return Unit['anubis'];
	},

	'hiveking': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HiveKing',
		'code' : 'hk',
		'category' : 'Heavy',
		'baseAttack' : 4000,
		'attackCost' : 1,
		'baseDefense' : 3200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hk': function() {
		return Unit['hiveking'];
	},

	'kahuna': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Kahuna',
		'code' : 'kh',
		'category' : 'Medium',
		'baseAttack' : 1000,
		'attackCost' : 1,
		'baseDefense' : 1300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			'Terrest':400
,'Air':400

		},
		'rangeTargets' : {
			
		}
	},

	'kh': function() {
		return Unit['kahuna'];
	},

	'driller': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Driller',
		'code' : 'd',
		'category' : 'Medium',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'd': function() {
		return Unit['driller'];
	},

	'eagle': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Eagle',
		'code' : 'e',
		'category' : 'Medium',
		'baseAttack' : 1100,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':400

		},
		'defenseTargets' : {
			'Heavy':400

		},
		'rangeTargets' : {
			
		}
	},

	'e': function() {
		return Unit['eagle'];
	},

	'blinker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Blinker',
		'code' : 'bk',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 6,
		'baseDefense' : 1000000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 5,
		'movementType' : 'none',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': false,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bk': function() {
		return Unit['blinker'];
	},

	'sentry': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Sentry',
		'code' : 'st',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'st': function() {
		return Unit['sentry'];
	},

	'vector': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Vector',
		'code' : 'v',
		'category' : 'Medium',
		'baseAttack' : 2000,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'v': function() {
		return Unit['vector'];
	},

	'walker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Walker',
		'code' : 'wk',
		'category' : 'Medium',
		'baseAttack' : 2200,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':2000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'wk': function() {
		return Unit['walker'];
	},

	'titan': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Titan',
		'code' : 'tt',
		'category' : 'Heavy',
		'baseAttack' : 3500,
		'attackCost' : 1,
		'baseDefense' : 2250,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'tt': function() {
		return Unit['titan'];
	},

	'silverbeard': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'SilverBeard',
		'code' : 'sb',
		'category' : 'Heavy',
		'baseAttack' : 50000,
		'attackCost' : 1,
		'baseDefense' : 100000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sb': function() {
		return Unit['silverbeard'];
	},

	'fenix': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Fenix',
		'code' : 'f',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2950,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'f': function() {
		return Unit['fenix'];
	},

	'interceptor': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Interceptor',
		'code' : 'it',
		'category' : 'Light',
		'baseAttack' : 100,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : true,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'it': function() {
		return Unit['interceptor'];
	},

	'reaper': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Reaper',
		'code' : 're',
		'category' : 'Light',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 250,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	're': function() {
		return Unit['reaper'];
	},

	'raptor': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Raptor',
		'code' : 'rp',
		'category' : 'Light',
		'baseAttack' : 280,
		'attackCost' : 1,
		'baseDefense' : 400,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Light':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'rp': function() {
		return Unit['raptor'];
	},

	'spider': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Spider',
		'code' : 'sp',
		'category' : 'Medium',
		'baseAttack' : 1800,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : true,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sp': function() {
		return Unit['spider'];
	},

	'krill': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Krill',
		'code' : 'kr',
		'category' : 'Medium',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'kr': function() {
		return Unit['krill'];
	},

	'heavyseeker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HeavySeeker',
		'code' : 'hr',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hr': function() {
		return Unit['heavyseeker'];
	},

	dummy : function(){}
}
// Utils.js
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

// Item.js
if($("imagePath")){
    var unitPath = $("imagePath").value+"/Units/";
}
function Item(element) {
	this.id = element.id;
	this.node = element;
	this.hasAttacked = false;
	this.space = "span";
	
	this.x = function() {
		return this.id.split('_')[0];
	}
	
	this.y = function() {
		return this.id.split('_')[1];
	}
	
	this.isSpace = function() {
		return this.node.firstChild.nodeName.toLowerCase() == this.space;
	}
	
	this.insertSpace = function() {
		var spanElement = document.createElement(this.space);
		this.node.appendChild( spanElement );
	}
		
	this.getChildId = function() {
		return this.node.firstChild.id;
	}
	
	this.getQuantity = function() {
		return Number(this.node.firstChild.title);
	}
	
	this.setQuantity = function(value) {
		this.node.firstChild.title = value;
	}
	
	this.unitName = function() {
		return this.node.firstChild.alt;
	}
	
	this.unit = function() {
		return Unit[this.unitName()];
	}
	
	this.movementCost = function() {
		return Unit[this.node.firstChild.alt].movementCost;
	}
	
	this.insert = function( element, quantity, e ) {
	    this.setClass("");
		if( !this.hasChildNodes() )	{
			this.node.empty();
			var img = element.getImageElement();
		
			var imgElement = document.createElement("img");
			imgElement.src = element.getImage();
			imgElement.id = element.getChildId();
			imgElement.title = quantity;
			imgElement.alt = element.unitName();
			
			this.resolveEnemy(imgElement,img);
			this.resolveFriendly(imgElement,img);
			this.resolveInfestation(imgElement,img);
			
			this.node.appendChild(imgElement);
		}else{
			this.setQuantity( Number(this.getQuantity()) + Number(quantity) );
		}
	}
	
	this.insertSpecific = function( unit, quantity, e ) {
	    this.setClass("");
		if( !this.hasChildNodes() )	{
			this.node.empty();
			var name = unit.name.toLowerCase();
			var imgElement = new Element("img");
			imgElement.src = Utils.resolveUnitImage(name);
			imgElement.title = quantity;
			imgElement.alt = name;
			this.node.appendChild(imgElement);
		}
	}
	
	this.resolveEnemy = function( src, dst) {
	    var attr = dst.getAttribute("isEnemy");
	    if( attr != null ) {
		    src.setAttribute("isEnemy",attr);
		    if( attr == "true" ) {
		        this.node.addClass("enemyBorder");
		    }
		}
	}
	
	this.resolveFriendly = function( src, dst) {
	    var attr = dst.getAttribute("isFriendly");
	    if( attr != null ) {
		    src.setAttribute("isFriendly",attr);
		}
	}
	
	this.resolveInfestation = function( src, dst) {
	    var attr = dst.getAttribute("isInfestated");
	    if( attr != null ) {
		    src.setAttribute("isInfestated",attr);
		}
	}
	
	this.setClass = function( name ) {
		this.node.className = name;
	}
	
	this.getClass = function() {
		return this.node.className;
	}
	
	this.removeAll = function() {
		this.node.empty();
		this.setClass("");
		this.insertSpace();
	}
	
	this.hasChildNodes = function() {
		return this.node.hasChildNodes() && !this.isSpace();
	}
	
	this.getImage = function() {
		return this.getImageElement().src;
	}
	
	this.getImageElement = function() {
		return this.node.firstChild;		
	}
	
	this.getImageName = function() {
		var img = this.getImage();
		var imgArray = img.split("/");
		var name = imgArray[imgArray.length-1].split(".");
		return name[0];
	}
	
	this.getCleanImageName = function() {
		var name = this.getImageName();
		var pos = name.split("_");
		return pos[0].toLowerCase();
	}
	
	this.getPosition = function() {
		var name = this.getImageName();
		var pos = name.split("_");
		return pos[1];
	}
	
	this.setPosition = function( p ) {
		var pos = this.getCleanImageName();
		
		var image = unitPath + pos + "_" + p + ".png"
		this.node.firstChild.src = image;
	}
	
	this.equals = function( element ) {
		return element.unitName() == this.unitName();
	}
	
	this.isUltimateUnit = function() {
		var name = element.getFirst().getAttribute('isUltimate');
		return name == 'true';
	}
	
	this.isSource = function() {
		return this.id.split("_").length == 1;
	}
	
	this.parseBollAttr = function(attr) {
		if( this.hasChildNodes() ) {
			var img = this.node.firstChild;
			return img.getAttribute(attr) == "true";
		}
		return false;
	}
	
	this.isEnemyUnit = function() {
	    return this.parseBollAttr("isEnemy");
	}
	
	this.isFriendlyUnit = function() {
	    return this.parseBollAttr("isFriendly");
	}
	
	this.isInfestated = function() {
	    return this.parseBollAttr("isinfestated");
	}
	
	this.checkEffects = function() {
		var element = BattleElements[this.id];
		if( element ) {
			if( element.paralysed ) {
				RaiseError.paralysed();
				return true;
			}
		}
		return false;
	}
	
	this.isBlinker = function(){
	    return this.unitName() == "blinker";
	} 
	
	this.isQueen = function(){
	    return this.unitName() == "queen";
	} 
	
	this.canDeployEgg = function() {
	    var dest = this.id.split("_");
        return dest[0] == 7 || dest[0] == 8;
	}

}
// RaiseError.js
var Message = {
	raiseAlert : function( key ) {
		var k = Language.getToken(key);
		var text = k;
		alert(text);
	},
	
	raiseConfirm : function( key ) {
		var k = Language.getToken(key);
		return confirm(k);
	},
	
	messageCallBack : function(responseTree, responseElements, responseHTML, responseJavaScript ) {
        if( responseHTML != '' ) {
            Message.raiseAlert(responseHTML);
        }
    }
}

var RaiseError = {
	
	alreadyAttacked : function() {
		Message.raiseAlert( "AlreadyAttacked");
	},
	
	invalidQuantity : function() {
		Message.raiseAlert("QuantityError");
	},
	
	attackFirstMove : function() {
		Message.raiseAlert("AttackFirstMove");
	},
	
	moves : function() {
		Message.raiseAlert("Moves");
	},
	
	ultimateUnitAttack : function() {
		Message.raiseAlert("UltimateUnitAttack");
	},
	
	unitsNotPositioned : function( result ) { 
		Message.raiseAlert("UnitsNotPositioned");
	},
	
	minimumMove : function(quantitySelected,unitName,minRest) {
		Message.raiseAlert("MinimumMove");
	},
	
	minimumRest : function(quantityRest,unitName,minRest) {
		Message.raiseAlert("MinimumRest");
	},
	
	noMovesToSplit : function(cost) {
	    var k1 = Language.getToken("NoMovesToSplit");
	    var k2 = Language.getToken("NoMovesToSplit2");
	    //alert(k1+" "+cost+" "+k2);
	},
	
	paralysed : function() { 
		Message.raiseAlert("Paralysed");
	},
	
	coolDown : function() { 
		Message.raiseAlert("CoolDown");
	},
	
	fleetInBattle : function() { 
		Message.raiseAlert("FleetInBattle");
	},
	
	cantPassWormHoles : function() {
	    Message.raiseAlert("FleetCantPassWormHole");
	},
	
	deploySaved : function() {
	    Message.raiseAlert("DeploySaved");
	},
	
	deployLoaded: function() {
	    Message.raiseAlert("DeployLoaded");
	},
	
	noDeploySaved: function() {
	    Message.raiseAlert("NoDeploySaved");
	},
	
	unloadCargoFleetInBattle: function() {
	    Message.raiseAlert("UnloadCargoFleetInBattle");
	},
	
	dropCargoFleetInBattle: function() {
	    Message.raiseAlert("DropCargoFleetInBattle");
	},
	
	invalidCoordinate : function() {
	    Message.raiseAlert("InvalidCoordinate");
	},
	
	needToSelectAFleetFirst : function() {
	    Message.raiseAlert("NeedToSelectAFleetFirst");
	},
	
	notDiscoveredCoordinate  : function() {
	    Message.raiseAlert("NotDiscoveredCoordinate");
	},
	
	fleetIsMoving : function() {
	    Message.raiseAlert("FleetIsMoving");
	},
	
	fleetAtMaximum : function() {
	    Message.raiseAlert("FleetAtMaximum");
	}
}
// Undo.js
var undo = new Undo();

function Undo() {
	this.undo = function() {
		var movesMade = $("movesMade");
		if( $("movesMade").value == "" ) {
			return;
		}
		var m = movesMade.value.split(";");
		movesMade.value = "";
		for( var i = 0; i < m.length-2 ; ++i ) {
			movesMade.value += m[i] + ";";
		}
		
		this.parseMove( m[m.length-2] );
	}
	
	this.reset = function() {
		var movesMade = $("movesMade");
		if(movesMade.value == "" ) {
			return;
		}
		
		var m = movesMade.value.split(";");
		movesMade.value = "";
		for( var i = m.length-2; i >= 0; --i ) {
			this.parseMove( m[i] );
		}
	}
	
	this.parseMove = function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		undo[m[0]]( params );
	}

	this.m = function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var position = params[3];
		var dstQuant = Number(dst.getQuantity());
		
		var moveCost = 1;
		if( src.hasChildNodes() ) {
			src.setQuantity( src.getQuantity() + quant );
			moveCost = 2;
		} else {
			src.removeAll();
			src.insert(dst, quant );
		}
		
		src.setPosition(position);
		var cost = src.unit().movementCost * moveCost;
		movesObj.incrementMoves( cost );
		
		src.hasAttacked = dst.hasAttacked;
		BattleElements[src.id] = BattleElements[dst.id];
		Utils.updateSpecialEffectsImages(dst,src);
		if( lastSelection != null ) {
			lastSelection.setClass("");
			lastSelection = null;
		}
		
		if( dstQuant > quant ) {
			dst.setQuantity( dstQuant - quant );
		}else{
			if( dstQuant == quant || dstQuant < quant ) {
				dst.removeAll();
				dst.insertSpace();
				dst.node.item = null;
				delete BattleElements[dst.id];
			}
		}	
	}
	
	this.bk = function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var position = params[3];
		var dstQuant = Number(dst.getQuantity());
		
		if( src.hasChildNodes() ) {
			src.setQuantity( src.getQuantity() + quant );
		} else {
			src.removeAll();
			src.insert(dst, quant );
		}
		
		src.setPosition(position);
		movesObj.incrementMoves( Unit["blinker"].movementCost );
		
		src.hasAttacked = dst.hasAttacked;
		if( lastSelection != null ) {
			lastSelection.setClass("");
			lastSelection = null;
		}
		
		BattleElements[src.id] = BattleElements[dst.id];
		if( dstQuant > quant ) {
			dst.setQuantity( dstQuant - quant );
		}else{
			if( dstQuant == quant || dstQuant < quant ) {
				dst.removeAll();
				dst.insertSpace();
				dst.node.item = null;
				delete BattleElements[dst.id];
			}
		}	
	}
	
	this.e = function( params ) {
	    var dst = Utils.getItem($(params[0]));
	    dst.removeAll();
	    movesObj.incrementMoves( Unit["queen"].movementCost );
	}
	
	this.r = function( params ) {
		var src = Utils.getItem($(params[0]));
		var oldpos = params[1];
		var newpos = params[2];
		
		src.setPosition( oldpos );
		movesObj.incrementMoves( 1 );
	}
	
	this.b = function( params ) {
		var src = Utils.getItem($(params[0]));
		src.hasAttacked = false;
		movesObj.incrementMoves( src.unit().attackCost );
	}
}
// Reset.js

var PositioningReset = {
	
	reset : function() {
		if( $("numberOfPlayers").value == "2" ) {
			PositioningReset.reset2();
		}else{
			PositioningReset.reset4();
		}
	},
	
	reset2 : function() {
		Positioning.cleanSelected();
		for( var i = 1; i < 9; ++i ) {
			PositioningReset.resetSector("7_"+i);
			PositioningReset.resetSector("8_"+i);
		}
	},
	
	reset4 : function() {
		Positioning.cleanSelected();
		for( var i = 3; i < 11; ++i ) {
			PositioningReset.resetSector("11_"+i);
			PositioningReset.resetSector("12_"+i);
		}
	},
	
	resetSector: function( id ){
		var e = $(id);		
		if( Utils.hasChilds(e) ) {
			var item = Utils.getItem(e);
			var newItem = new Item( $(item.unit().name.toLowerCase()) );
			
			newItem.insert( item, item.getQuantity(), null );
			
			item.removeAll();
			item.node.item = null;
		}
	}
}
// Planet.js

var Planet = {

    start : function() {
        try {
            if( window.location.href.indexOf("#") >= 0 ) {
                Planet.onHistoryChanged(window.location.hash);
            }
        } catch(e) {
            log.error(e);
        }
    },

    sendRequest : function(args) {
        if( $('hub').value == '1' ) {
            Message.raiseAlert("YouHaveBattlesToPlay");
            return false;
        }
    
        var url = "../Ajax/Planets/Renderer.ashx?t=" + new Date().getTime().toString();
        var hash = "/";
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
                hash += propName + "_" + args[propName] + "/";
            }
        }
        
        if( args.CallBack == null ) {
            args.CallBack = Planet.planetInfoUpdater;
        }
        Site.HistoryManager.addState(hash);
        Utils.ajaxRequest('get', url, $("planetContent"), args.CallBack);
        
        log.info(args.Panel);
    },
    
    onHistoryChanged : function(newHash) {
        if( $("planetContent") == null ) {
            return;
        }
        if( newHash.indexOf("tutorial") >= 0 || newHash.indexOf("topView") >= 0 ) {
            return;
        }
        newHash = newHash.replace("#","");
        log.debug("Hash: " + newHash);
        if( newHash == "" || newHash == "/" ) {
            if( window.redirectToPlanet && window.redirectToPlanet != null ) {
                window.location = "Default.aspx?Id=" + window.redirectToPlanet;
            } else {
                window.location = "Default.aspx?Id=" + window.planetInfo.PlanetId;
            }
            return;
        }
        var params = newHash.split("/");
        var json = {};
        for( var i = 0; i < params.length; ++i ) {
            var param = params[i];
            if( param == "" ) {
                continue;
            }
            var args = param.split("_");
            if( args[0] != "Action" ){
                json[args[0]] = args[1];
            }
        }
        Planet.sendRequest(json);
	},
    
    destroyFacility : function(planetId, slotName) {
        if( Message.raiseConfirm("ReallyDestroyFacility") ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Action:"Destroy"} );
        }
    },
    
    upgradeFacility : function(planetId, slotName) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Action:"Upgrade"} );
    },
    
    startBuildUnit : function(planetId, unitName) {
        var raw = $(unitName + "_Quantity").value;
        var y=parseInt(raw); 
        if (isNaN(y)){
            Message.raiseAlert("NaN");
            return;
        }
        if( y <= 0 ) {
            Message.raiseAlert("MustBePositiveQuantity");
            return;
        }
        Planet.sendRequest( {Planet:planetId, Panel:"Units", Resource:unitName, Quantity:y, Action:"Build"} );
    },
    
    startBuildFacility : function(planetId, slotName, resourceName) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", SlotName:slotName, Resource:resourceName, Action:"Build"} );
    },
    
    createFleet : function(planetId) {
        Fleet.sendRequest( {Type:'change', Changes:Fleet.changeLog, CallBack: Planet.createFleetCallBack } );
    },
    
    createFleetCallBack : function() {
        var fleetName = $('fleetName').value;
        Planet.sendRequest( {Planet:window.planetInfo.PlanetId, Panel:"Fleets", FleetName:fleetName, CallBack:Planet.fleetCallBack, Action:"CreateFleet"} );      
    },
    
    cancelFacilityQueue : function(planetId, resourceId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", ResourceId:resourceId, Action:"RemoveQueue"} );
    },
    
    cancelUnitQueue : function(planetId, resourceId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Units", ResourceId:resourceId, Action:"RemoveQueue"} );
    },
    
    cancelFacilityProduction : function(planetId, resourceId) {
        if( !Message.raiseConfirm("YouWillLooseResources") ) {
	        return;
	    }
        Planet.sendRequest( {Planet:planetId, Panel:"Facilities", ResourceId:resourceId, Action:"RemoveProduction"} );
    },
    
    cancelUnitProduction : function(planetId, resourceId) {
        if( !Message.raiseConfirm("YouWillLooseResources") ) {
	        return;
	    }
        Planet.sendRequest( {Planet:planetId, Panel:"Units", ResourceId:resourceId, Action:"RemoveProduction"} );
    },
    
    changeName : function(planetId){
        var newName = $("newPlanetName").value;
        log.debug("New Name:" + newName);
        
        if( Utils.checkAndNotifyStringNotEmpty(newName) ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Manage", Action:"ChangeName", NewName:newName} );
        }
    },
    
    abandonPlanet : function(planetId) {
        if( Message.raiseConfirm("ReallyAbandonPlanet") ) {
            Planet.sendRequest( {Planet:planetId, Panel:"Manage", Action:"AbandonPlanet"} );
        }
    },
    
    getQueue : function(planetId) {
        Planet.sendRequest( {Planet:planetId, Panel:"Queue"} );
    },
    
    toHome : function(planetId) {
        Planet.sendRequest({Planet:planetId, Panel:"Facilities"});
    },
    
    toUnits : function(planetId){
        Planet.sendRequest({Planet:planetId, Panel:"Units"});
    },
    
    toPanel : function(planetId, panelName) {
        if( panelName == "Fleets" ) {
            Planet.toFleets(planetId);
            return;
        }
        Planet.sendRequest( {Planet:planetId, Panel:panelName} );
    },
    
    toFleets : function(planetId){
        Planet.sendRequest({Planet:planetId, Panel:"Fleets", CallBack:Planet.fleetCallBack});
    },
    
    fleetCallBack : function() {
        Planet.planetInfoUpdater();
    },
    
    planetInfoUpdater : function() {
                
        if( window.redirectToPlanet && window.redirectToPlanet != null ) {
            window.location = "Default.aspx?Id=" + window.redirectToPlanet;
            return;
        }
        
        Planet.updatePlayerResources();

        var planetHeader = $("planetHeader");
        if( planetHeader != null ) {
            planetHeader.innerHTML = window.planetInfo.PlanetName + " - " + window.planetInfo.PlanetLocation;
            planetHeader.href = "javascript:Planet.toHome(" + window.planetInfo.PlanetId + ");";
        }
        
        var planetNameOnList = $("planetName" + window.planetInfo.PlanetId);
        if( planetNameOnList != null ) {
            planetNameOnList.innerHTML = window.planetInfo.PlanetName;
        }
        
        UniverseUtils.removeAllToolTips();
        Planet.addTooltips();
        Tutorial.advance();
        Fleet.load();
        
        pageTracker._trackPageview(window.location);
        log.profile("ajaxRequest");
    },
    
    updatePlayerResources : function() {
        var resourceList = window.resourceList;
        if( resourceList != null ) {
            for( var propName in resourceList ) {
                var elem = $(propName);
                if( elem != null ) {
                    elem.innerHTML = window.resourceList[propName];
                    Planet.showHideElem(elem, propName, window.resourceList[propName]);
                }
            }
        }
    },
    
    modRegex : /\w+Mod$/,
    
    showHideElem : function(elem, propName, quantity) {
        if( ! Planet.modRegex.test(propName) ){
            return;
        }
        
        if( window.resourceList[propName] == 0 ) {
            elem.getParent().setStyles({display:"none"});
        } else {
            elem.getParent().setStyles({display:"block"});
        }
    },
    
    build : function(planetId, slotName) {
        Planet.sendRequest({Planet:planetId, Panel:"BuildFacility", SlotName:slotName});
    },
    
    upgrade : function(planetId, resourceId) {
        Planet.sendRequest({Planet:planetId, Panel:"UpgradeFacility", ResourceId:resourceId});
    },
    
    unloadCargo: function(planetId,fleetId, cargoId){
        Planet.sendRequest( {Planet:planetId, FleetId:fleetId, Panel:"Fleets", Action:"UnloadFleet", CallBack:Fleet.load} );
    },
    
    addTooltips : function() {
        var tips = window.slotTips;
        if( tips ) {
            for( var slot in tips ) {
                var elem = $(slot);
                var tip = tips[slot];
                if( elem != null ) {
                    if( tip.b.l ) {
                        var html = "<ul>";
                        html += "<li>" + Language.getToken("Level") + " " + tip.b.l + "</li>";
                        html += "<li>" + Language.getToken("State") + ": " + Language.getToken(tip.b.s) + "</li>";
                        html += "</ul>";
                        if( tip.b.m != "" ) {
                            html += "<p style='margin-top:10px;'>" + Language.getToken(tip.b.m) + "</p>";
                        }
                        if( tip.b.rm != "" ) {
                            html += "<p style='margin-top:10px;'>" + tip.b.rm + "</p>";
                        }
                        Utils.insertTip(elem, Language.getToken(tip.t), html );
                    } else {
                        var body = tip.b;
                        log.debug(tip.l);
                        if( tip.l != false ) {
                            body = Language.getToken(tip.b);
                        }
                        Utils.insertTip(elem, Language.getToken(tip.t), body );
                    }
                }
            }
        }
    }
  
};

window.addEvent('domready', Site.startPlanet);
// Attack.js
function Attack( source, dest, range, unit ) {
	this.r = range;
	this.s_x = Number(source[0]);
	this.s_y = Number(source[1]);
	this.d_x = Number(dest[0]);
	this.d_y = Number(dest[1]);
	this.unit = unit;
	
	this.checkPathVert = function( stat, src, dst ) {
	    var hasAbility = BattleElements[this.s_x+"_"+this.s_y].hasAbility;
		//hack para a battle moon
		var c = AttackUtils.ultimateUnitAttackCoord();
		if( stat == c ) { 
			stat = c-1;
		}
	
		for( var i = src; i < dst; ++i ) {
			var item = Utils.getItem($(i+"_"+stat));
			if( item.hasChildNodes() && !(unit.catapult && hasAbility) ) {
				return false;
			}
		}
		return true;
	}
	
	this.checkPathHoriz = function( stat, src, dst ) {
	    var hasAbility = BattleElements[this.s_x+"_"+this.s_y].hasAbility;
		for( var i = src; i < dst; ++i ) {
			var item = Utils.getItem($(stat+"_"+i));
			if( item.hasChildNodes() && !(unit.catapult && hasAbility) ) {
				return false;
			}
		}
		return true;
	}
	
	this.n = function() {
		var v = this.s_x-this.r;
		
		if( v <= 0 && this.d_x == 0 && this.d_y == 0) {
			return this.checkPathVert(this.s_y,this.d_x+1,this.s_x)
		}
		
		if( this.checkPathVert(this.s_y,this.d_x+1,this.s_x) ){
			var first = this.d_x < this.s_x && this.d_x >= v;
			if( this.s_y == AttackUtils.ultimateUnitAttackCoord() ) {
				return first;
			}
			return  first && this.s_y == this.d_y;
		}
		return false;
	}
	
	this.s = function() {
		var v = this.s_x+this.r;
		if( this.checkPathVert(this.s_y,this.s_x+1,this.d_x) ){
			return this.d_x > this.s_x && this.d_x <= v && this.s_y == this.d_y;
		}
		return false;
	}
	
	this.w = function() {
		var v = this.s_y-this.r;
		if( this.checkPathHoriz(this.s_x,this.d_y+1,this.s_y) ) {
			return this.d_y < this.s_y && this.d_y >= v && this.s_x == this.d_x;
		}
		return false;
	}
	
	this.e = function() {
		var v = this.s_y+this.r;
		if( this.checkPathHoriz(this.s_x,this.s_y+1,this.d_y) ) {
			return this.d_y > this.s_y && this.d_y <= v && this.s_x == this.d_x;
		}
		return false;
	}
}
// Replay.js

//movesList
//finalState

var Replay = {
	currentTurn : 0,
	currentMove : -1,
	space : "span",
	
	isTheEnd : function() {
		return movesList.length == Replay.currentTurn;
	},
	
	isTheBeginning : function() {
		return Replay.currentTurn <= 0&& Replay.currentMove < 0;
	},
	
	incrementTurn : function() {
		if( Replay.currentTurn < movesList.length ) {
			++Replay.currentTurn;
		}
		var turnElem = $('turn');
		if( turnElem != null ) {
		    turnElem.innerHTML = Replay.currentTurn;
		}
	},
	
	decrementTurn : function() {
		if( Replay.currentTurn > 0 ) {
			--Replay.currentTurn;
		}
		$('turn').innerHTML = Replay.currentTurn;
	},
		
	forward : function() {
		Utils.hideImage("enemy");
		if( Replay.isTheEnd() ) {
			return;
		}
		
		var mList = movesList[Replay.currentTurn];
				
		Replay.resolveForwarReplay(mList);
	},
	
	resolveForwarReplay : function(mList) {
		var m = mList.split(";");
		if( Replay.currentMove >= m.length-1 ) {
			Replay.nextTurn();
		}else{
			var move = m[++Replay.currentMove];
			if( move != "" ) {
				Replay.parseMoveForward( move );
			}else{
				Replay.nextTurn();
			}
		}
	},
	
	backward : function() {
		Utils.hideImage("enemy");
		if( Replay.isTheBeginning() ) {
			return;
		}
		
		if( Replay.currentMove < 0 ) {
			if( Replay.currentTurn > -1 ) {
				Replay.previousTurn();
				return;
			}
		}
		
		var mList = movesList[Replay.currentTurn]
		if( mList == "") {
			Replay.decrementTurn();
			return;
		}
			
		var m = mList.split(";");
		Replay.parseMoveBackward( m[Replay.currentMove] );
		--Replay.currentMove;
	},
	
	nextTurn : function() {
		Replay.incrementTurn();
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(0);
	},
	
	previousTurn : function() {
		Replay.loadCurrentTurn(1);
		Replay.decrementTurn();		
		var mList = movesList[Replay.currentTurn];
		if( mList != "" ) {
			var m = mList.split(";");
			for( var i = 0; i < m.length ; ++i  ) {
				var move = m[i];
				if( move != "" ) {
					Utils.hideImage("enemy");
					Replay.parseMoveForward( move );
				}
			}
			Replay.currentMove = m.length-2;
		}else{
			Replay.currentMove = -1;
		}
	},
	
	loadLastTurn : function() {
		Replay.currentTurn = movesList.length;
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(0);
		
	},
	
	loadFirstTurn : function() {
		Replay.currentTurn = 0;
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(1);
	},
	
	loadCurrentTurn : function(dec) {
		Utils.hideImage("enemy");
		Replay.cleanBoard();
		
		var current = Replay.currentTurn-dec;
		if( current < 0 ) {
			current = 0;
		}
		
		var turnElem = $('turn');
		if( turnElem != null ) {
		    turnElem.innerHTML = current;
		}
		
		var fs = finalState[current];
		var playerId = $('playerId').value;
			
		var fsList = fs.split(';');
		for( var i = 0; i < fsList.length; ++i ) {
			var fsElement = fsList[i];
			if( fsElement != '' ) {
				Replay.insertElement(fsElement,playerId);
			}
		}
	},
	
	cleanBoard : function() {
		var board;
		if( Utils.numberOfPlayers() == 2 ) {
			board = $('board2').getElements('td');
		}else{
			board = $('board4').getElements('td');
		}
		
		var areCoordinatesToIgnore = Utils.numberOfPlayers() == 4;
		
		board.each( function( td ) {
			if( !(areCoordinatesToIgnore && !Utils.coordinateValid(td.id)) ){
				td.empty();
				var spanElement = document.createElement(Replay.space);
				td.appendChild( spanElement );
				td.className = "";
			}
		});
	},
	
	insertElement : function( state, playerId ) {
		var e = state.split(':');
		var element = e[1].split('-');
		var unit = Unit[element[0]]();
		var td = $(element[1]);
		var quantity = element[2];
		var position = element[3].toLowerCase();
		
		var imgElement = document.createElement("img");
		imgElement.src = unitPath + unit.name.toLowerCase() + "_" + position + ".png"
		imgElement.title = quantity;
		imgElement.alt = unit.name.toLowerCase();	
		
		td.empty();
		td.appendChild(imgElement);	
		
		if( e[0] != playerId ) {
			if( Utils.numberOfPlayers() == 2 ) {
				td.className = "enemyBorder";
			}else{
				td.className = "enemyBorder"+e[0];
			}
		}
	},
	
	parseMoveForward : function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		Replay[m[0]]( params );
	},
	
	parseMoveBackward : function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		Replay[m[0]+"b"]( params );
	},

	m : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var dstQuant = Number(dst.getQuantity());
		var srcQuant = Number(src.getQuantity());
		
		var moveCost = 1;
		if( dst.hasChildNodes() ) {
			dst.setQuantity( dstQuant + quant );
			var sum = srcQuant - quant;
			if( sum == 0 ) {
				Replay.clearItem(src);
			}else{
				src.setQuantity( sum );
			}
		} else {
			if( srcQuant == quant ) {
				dst.removeAll();
				dst.insert(src, quant );
				dst.setClass( src.getClass() );	
				Replay.clearItem(src);
			}else{
				dst.insert(src, quant );
				dst.setClass( src.getClass() );	
				src.setQuantity( srcQuant - quant );
				moveCost = 2;
			}
		}
	},
	
	bk : function( params ) {
	    m(params);
	},
	
	r : function( params ) {
		var src = Utils.getItem($(params[0]));
		var newpos = params[2];
		
		src.setPosition( newpos.toLowerCase() );
	},
	
	b : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		src.hasAttacked = true;
		
		Utils.showImage(dst,"enemy",null);
	},
	
	mb : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var srcQuant = Number(src.getQuantity());
		var dstQuant = Number(dst.getQuantity());
		
		var moveCost = 1;
		if( src.hasChildNodes() ) {
			src.setQuantity( srcQuant + quant );
			
			var sum = dstQuant - quant;
			if( sum == 0 ) {
				Replay.clearItem(dst);
			}else{
				dst.setQuantity( sum );
			}
			
			moveCost = 2;
		} else {
			if( dstQuant == quant ) {
				src.removeAll();
				src.insert(dst, quant );
				src.setClass( dst.getClass() );	
				Replay.clearItem(dst);
			}else{
				src.insert(dst, quant );
				src.setClass( dst.getClass() );	
				dst.setQuantity( dstQuant - quant );
			}
		}	
	},
	
	rb : function( params ) {
		var src = Utils.getItem($(params[0]));
		var oldpos = params[1];
		
		src.setPosition( oldpos.toLowerCase() );
	},
	
	bb : function( params ) {
		var src = Utils.getItem($(params[0]));
		src.hasAttacked = false;
		var dst = Utils.getItem($(params[1]));
		Utils.showImage(dst,"enemy",null);
	},
	
	clearItem : function(item){
		item.removeAll();
		item.setClass("");
		item.insertSpace();
		item.node.item = null;
	}
}
// Moves.js

function Moves() {
	this.moveElement = $("moves");

	this.none = function( src, dst ) {
		return false;
	}
	
	this.all = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		if( d_x <= s_x + 1 && d_x >= s_x - 1 ) {
			if( d_y <= s_y + 1 && d_y >= s_y - 1 ) {
				return true;
			}
		}
		return false;
	}
	this.normal = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		if( d_x <= s_x + 1 && d_x >= s_x - 1 && s_y == d_y ) {
			return true;
		} 
		
		if( d_y <= s_y + 1 && d_y >= s_y - 1 && s_x == d_x ) {
			return true;
		}
		return false;
	}
	
	this.front = function( src, dst ) {
		return this[lastSelection.getPosition()](src,dst);
	}
	
	this.blink = function( src, dst ) {
		var d_x = Number(dst[0]);
		return d_x > 4;
	}
	
	this.diagonal = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		return d_x == s_x+1 && d_y == s_y+1 ||
			d_x == s_x-1 && d_y == s_y-1 ||
			d_x == s_x+1 && d_y == s_y-1 ||
			d_x == s_x-1 && d_y == s_y+1;
	}
	this.drop = function(src,dst){
	    
	}
	
	this.n = function(src, dst) {
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
			
		return d_x == s_x-1 && s_y == d_y;
	}
	this.s = function(src, dst) {
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
			
		return d_x == s_x+1  && s_y == d_y;			
	}
	
	this.w = function(src, dst) {
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		
		return d_y == s_y-1 && s_x == d_x;
	}
	this.e = function(src, dst) {
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		
		return d_y == s_y+1 && s_x == d_x;
	}
	
	this.incrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue + quant;
	}
	
	this.decrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue - quant;
	}
	
	this.hasMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		

		if( m < quant ) {
			RaiseError.moves();
			return false;
		}
		return true;
	}
	
	this.silentHasMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		

		if( m < quant ) {
			return false;
		}
		return true;
	}
	
	this.hasValidMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		
		if( m < quant ) {
			return false;
		}
		return true;
	}
	
	this.decrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue - quant;
	}
}

var movesObj = new Moves();
// Battle.js
var lastSelection;
var blinkSelection;

var Battle = {

    isSpectator: function() {
        var isSpectator = $("isSpectator");
        if( isSpectator == null ) {
            return true;
        }
        return isSpectator.value != 0
    },
    
	start : function() {
		if( !Battle.isSpectator() ) { 
			Battle.initTDElements();
		}
		Utils.initSpecialMoveImages(true);
	},
	
	initTDElements : function(  ) {
		Utils.getTdElements().each( function( td ) {
		    Battle.initTd(td);
		});
		Battle.initUltimateUnits();
		var v = $('reset');
		if( v ) {
			v.addEvent('click', function( e ) {undo.reset();});
			$('undo').addEvent('click', function( e ) {undo.undo();});
			$('submit').addEvent('click', function( e ) {Battle.submit();});
		}
		v = $('giveUp');
		if( v ) {
			v.addEvent('click', function( e ) {Battle.giveUp();});
		}
		if($("battleCalculator") ) {
		    $("elementSelectedQuantInput").addEvent('keyup', function( e ) {Information.fillCalculatorEvent(this, e);});
		    $("elementSelectedRangeInput").addEvent('keyup', function( e ) {Information.fillCalculatorRangeEvent(this, e);});
		}
		$("b").addEvent('click', function( e ) {Battle.setPosition("n");});
		$("d").addEvent('click', function( e ) {Battle.setPosition("w");});
		$("e").addEvent('click', function( e ) {Battle.setPosition("e");});
		$("g").addEvent('click', function( e ) {Battle.setPosition("s");});
		
	},
	
	initTd : function(td){
	    td.addEvent('click', function( e ) {Battle.selected(this,e);});
		td.addEvent('mouseout', function( e ) {Utils.canMoveOut();});
		td.addEvent('mouseover', function( e ) {
			var item = Utils.getItem(this);
			Utils.canMoveOver( item, e ) ;
		});
	},
	
	initUltimateUnits : function() {
	    if( Utils.numberOfPlayers() == 2 ) {
	        var enemyUN = $('0_0');
	        if( enemyUN ) {
	            Battle.initTd(enemyUN);
	        }
	        enemyUN = $('9_9');
	        if( enemyUN ) {
	            Battle.initTd(enemyUN);
	        }
	    }
	},
	
	initialChecksOk : function(selectedElement) {
		if( selectedElement.isEnemyUnit() || selectedElement.isFriendlyUnit() ) {
			return false;
		}
		
		if( selectedElement.checkEffects() ) {
			return false;
		}
		
		if( $("moves").innerHTML == 0 ) {
			if( lastSelection != null ) {
				Utils.resetSelection(null);
			}
			return false;
		}
		
		if( selectedElement.hasAttacked ) {
			RaiseError.alreadyAttacked();
			return false;
		}
		
		return true;
	},
	
	selected : function( element, event ) {
		var selectedElement = Utils.getItem( element );
		
		if( !Battle.isBlinkerSelected() && !Battle.initialChecksOk(selectedElement) ) {
			return;
		}
		
		if( lastSelection == null ) {
			Battle.noneSelected( selectedElement );
		} else {
			if( Battle.sameSector(selectedElement) ) {
				Battle.clearSelected();
				Information.fixed = false;
				return;
			}			
			Battle.oneSelected(selectedElement, event);
		}
	},
	
	isBlinkerSelected : function() {
	    return blinkSelection != null || ( lastSelection != null && lastSelection.isBlinker() );
	},
	
	blinkerInRange : function(selectedElement){
	    if( Battle.isBlinkerSelected() ) {
	        return selectedElement.x() > 4;
	    }
	    return true;
	},
	
	noneSelected : function( selectedElement ){
		if( !selectedElement.hasChildNodes() ) {
			return;
		}
		if( Battle.hasCoolDown(selectedElement) || !Battle.blinkerInRange(selectedElement) ) {
		    return;
		}
		
		selectedElement.setClass("selectedSector");
		var quant = selectedElement.getQuantity();
		var quantity = $("quantity");
		quantity.value = quant;
		quantity.focus();
		
		min = Math.round( 0.5 + (Number(quant) * 0.2) );
		
		Information.fill( "minquantity", min);
		Information.fill( "maxquantity", quant - min)
		Information.fillAll( selectedElement );
		
		lastSelection = selectedElement;
		Information.fixed = true;
		Tutorial.advance();
	},
	
	hasCoolDown : function(selectedElement) {
	    if( BattleElements ) {
		    var json = BattleElements[selectedElement.id];
	        if( json != null && json.coolDown > 0 ) {
	            RaiseError.coolDown();
	            return true;
	        }
	    }
	    return false;
	},
	
	setPosition : function( pos ) {
		if(lastSelection != null && lastSelection.getPosition() != pos && movesObj.hasMoves(1) ) {
			var oldPos = lastSelection.getPosition();
			lastSelection.setPosition( pos );
			Utils.registerRotation( lastSelection, oldPos, pos );			
			movesObj.decrementMoves( 1 );
			
			if( !movesObj.silentHasMoves(1) ) {
				Utils.resetSelection(null);
			}
		}
	},
	
	oneSelected : function( selectedElement, event ){
	    Information.fixed = false;
		var cost = Battle.getCost();
				
		if( movesObj.hasMoves( cost ) ) {
		    if( lastSelection.isQueen() ) {
		        Battle.insertEgg(selectedElement,cost,event);
		        return;
		    }
		    if( blinkSelection != null || lastSelection.isBlinker() ) {
		        Battle.blinkSelected(selectedElement, cost, event)
		    }else{
		        if( Utils.canMoveOver(selectedElement, event ) ) {
			        Battle.moveUnit( selectedElement, cost, event );
		        }
		    }
		}
	},
	
	blinkSelected : function(selectedElement, cost, event) {
	    if( blinkSelection == null ) {
            blinkSelection = lastSelection;
            lastSelection = null;
            Battle.noneSelected(selectedElement);
        }else{
            if( selectedElement.id != blinkSelection.id && Battle.blinkerInRange(selectedElement) ){
                Battle.moveUnit(selectedElement, cost, event);
                Battle.clearBlinkSelected();
            }
        }
	},
	
	insertEgg : function(selectedElement, event) {
	    selectedElement.insertSpecific( Unit["egg"], 1);
	    selectedElement.node.item = selectedElement;
	    
	    if( !selectedElement.hasChildNodes() ) {
			selectedElement.removeAll();
		}
			
	    movesObj.decrementMoves(Unit["queen"].movementCost);
		Utils.registerEgg(selectedElement);
	    lastSelection.setClass("");
		lastSelection = null;
	},
	
	getCost : function() {
	    if( blinkSelection != null ) {
		    return blinkSelection.movementCost();
		}
		return lastSelection.movementCost();
	},
    	
	moveUnit : function( selectedElement, cost, event ){
		var quant = lastSelection.getQuantity();
		var position = lastSelection.getPosition();
		var quantitySelected = Utils.getQuantity();
			
		if( quantitySelected <= quant && quantitySelected > 0 ) {
			var quantRest = quant - quantitySelected;
			
			if( quantRest > 0 ) {
				cost *= 2;
				if( !movesObj.hasMoves( cost ) ) {
					RaiseError.noMovesToSplit(cost);
					return;
				}
			}
			
			if( !Battle.quantityValueCheck(quantRest,quant,quantitySelected)) {
				return;
			}
			
			if( !selectedElement.hasChildNodes() ) {
				selectedElement.removeAll();
			}
			
			selectedElement.insert( lastSelection, quantitySelected, event );
			selectedElement.node.item = selectedElement;
			
			BattleElements[selectedElement.id] = BattleElements[lastSelection.id];
			Utils.updateSpecialEffectsImages(lastSelection,selectedElement);
			
			if( quantRest > 0 ) {
				lastSelection.setQuantity( quantRest );
			}else{
				lastSelection.removeAll();
				lastSelection.node.item = null;
				delete BattleElements[lastSelection.id];
			}
			
			movesObj.decrementMoves(cost);
			Battle.registerMovement(lastSelection,selectedElement,quantitySelected,position);
			
			if( lastSelection.isSource() && quantRest == 0) {
				lastSelection.setClass("unitOpacity");
			}else{
			    lastSelection.setClass("");
			}
			lastSelection = null;
			Tutorial.advance();
		}else{
			RaiseError.invalidQuantity();
		}
	},
	
	registerMovement : function(lastSelection,selectedElement,quantitySelected,position) {
	    if( blinkSelection != null ) {    
	        Utils.registerBlink(lastSelection,selectedElement,quantitySelected,position);
	    }else{
	        Utils.registerMove(lastSelection,selectedElement,quantitySelected,position);
	    }
	},
	
	quantityValueCheck : function(quantRest,quant,quantitySelected) {
		var minRest = Math.round( 0.5+(quant*0.2) );
		
		if( quantitySelected < minRest ) {
			RaiseError.minimumMove(quantitySelected,lastSelection.unitName(),minRest);
			return false;
		}
		
		if( quantRest < minRest && quantRest != 0 ) {
			RaiseError.minimumRest(quantRest,lastSelection.unitName(),minRest);
			return false;
		}
		return true;
	},
	
	submit : function() {
		var answer = Message.raiseConfirm("EndTurn");
		if( answer ) {
			var moves = $("movesMade");
			$("submit").disabled = true;
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=battle&id="+battleId+"&moves="+moves.value;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Battle.submitCallBack);
		}
	},
	
	submitCallBack : function() {
		$('movesMade').value = "";
		FillInformation.start();
	},
	
	giveUp: function() {
		var answer = Message.raiseConfirm("GiveUp");
		if( answer ) {
			$("giveUp").disabled = true;
			$("submit").disabled = true;
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=giveUp&id="+battleId;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Battle.giveUpCallBack);
		}
	},
	
	giveUpCallBack : function() {
	    Cookie.dispose('HasBattles');
		Cookie.dispose('HasUniverseBattles');
	},
	
	getAllMessages : function() {
		var battleId = Utils.queryString("id")
		var url = "../Ajax/Battle/BattleMessages.ashx?id="+battleId;
		
		Utils.ajaxRequest('get', url, $('messages'), Battle.getAllMessagesCallBack);
	},
	
	getAllMessagesCallBack : function() {
	},
		
	sameSector : function( selectedElement ){
		return lastSelection != null && lastSelection.id == selectedElement.id;
	},
	
	clearSelected : function() {
		if( lastSelection != null ) {
			var empty = "";
			lastSelection.setClass("");
			lastSelection = null;
			Utils.getQuantityElement().value = empty;
			Information.fill("minquantity",empty);
			Information.fill("maxquantity",empty);
			Battle.clearBlinkSelected();
		}
	},
	
	clearBlinkSelected : function() {
		if( blinkSelection != null ) {
	        blinkSelection.setClass("");
            blinkSelection = null;
		}
	},
	
	canMove : function canMove(dst) {
		var src = lastSelection.id.split("_");
		
		var id = lastSelection.getChildId().toLowerCase().split("_");
			
		var movType = Unit[id[0]].movementType;
		if( movType == "") {
			return false;
		}
		return movesObj[movType](src,dst);
	}
}

// Deploy.js


var lastSelection;

var Positioning = {
	start : function() {
		if( $("isSpectator").value == 0 ) { 
			Positioning.initTDElements();
			Positioning.initBottomElements();
			$('reset').addEvent('click', function( e ) {PositioningReset.reset(this);});
			$('submit').addEvent('click', function( e ) {Positioning.submit();});
		}
	},
	
	initTDElements : function(  ) {
		Utils.getTdElements().each( function( td ) {
			td.addEvent('click', function( e ) {Positioning.selected(this,e);});
			td.addEvent('mouseout', function( e ) {Utils.canMoveOut();});
			td.addEvent('mouseover', function( e ) {Utils.canMoveOverPositioning( this.id, e ) ;});
		});
	},
	
	initBottomElements : function(  ) {
		Positioning.getBottomElements().each( function( td ) {
			if( !td.hasClass("initialBottomIgnore") ) {
				td.addEvent('click', function( e ) {Positioning.selected(this);});
				td.addEvent('mouseout', function( e ) {
					if( lastSelection != null && this.getFirst().get('tag') == "span" ) {
						if( lastSelection.getImageName() == td.id ) {
							this.className = "unitOpacity";
						}
					}
				});
				td.addEvent('mouseover', function( e ) {
					if( lastSelection != null && this.getFirst().get('tag') == "span" ) {
						if( lastSelection.getImageName() == td.id ) {
							this.className = "unitOpacityOver";
						}
					}
				});
				
				td.setStyle("background-image","url("+$("imagePath").value+"/Units/"+td.id.toLowerCase()+".png)");
				td.setStyle("background-repeat","no-repeat");
			}
		});
	},
	
	submit : function() {
		if( Positioning.hasPositioned() ) {
			var moves = $('movesMade');
			$("submit").disabled = true;
			Positioning.gatherUnits(moves);
			var battleId = Utils.queryString("id")
			var url = "../Ajax/Battle/Battle.ashx?type=deploy&id="+battleId+"&moves="+moves.value;
			Utils.ajaxRequest('get', url, Utils.getBattleDiv(), Positioning.submitCallBack);
		}
	},
	
	gatherUnits : function( moves ) {
	    if( Utils.numberOfPlayers() == 2 ) {
			Positioning.setUnits2(moves);
		}else{
			Positioning.setUnits4(moves);
		}
	},
	
	setUnits2 : function( moves ) {
		for( var i = 1; i < 9; ++i ) {
			Positioning.addMove( moves, "7_"+i );
			Positioning.addMove( moves, "8_"+i );
		}
	},
	
	setUnits4 : function( moves ) {
		for( var i = 3; i < 11; ++i ) {
			Positioning.addMove( moves, "11_"+i );
			Positioning.addMove( moves, "12_"+i );
		}
	},
	
	submitCallBack : function() {
		window.location = window.location;
	},
	
	addMove: function( moves, coord ) {
		var item = Utils.getItem( $(coord) );
		if( item.hasChildNodes() ) {
			var unit = Unit[item.unitName().toLowerCase()];
			var quant = item.getQuantity();
			moves.value += "p:"+unit.code+"-"+coord+"-"+quant+";";
		} 
	},
	
	hasPositioned : function() {
		var found = false;
		var result = "";
		Positioning.getBottomElements().each( function( td ) {
			if( Utils.hasChilds(td) ) {
				if( td.className != "initialBottomIgnore" ) {
					var item = Utils.getItem(td);
					var unitName = item.unitName();
					result += unitName + " " + item.getQuantity() + "\n";
					found = true;
				}
			}
		});
		if( found ) {
			RaiseError.unitsNotPositioned(result);
		}
		return !found;
	},
	
	selected : function( element, event ) {
		if( Utils.numberOfPlayers() != 2 && !Utils.coordinateValid(element.id) ) {
			return;
		}
		var selectedElement = Utils.getItem( element );
		if( lastSelection == null ) {
			Positioning.noneSelected( selectedElement );
		} else {
		    
			if( Positioning.sameSector(selectedElement) ) {
				Positioning.cleanSelected();
				return;
			}		
			Positioning.oneSelected(selectedElement, event);
		}
	},
	
	noneSelected : function( selectedElement ){
		if( !selectedElement.hasChildNodes() ) {
			return;
		}
		
		selectedElement.setClass("selectedSector");
		var quant = selectedElement.getQuantity();
		var quantity = $("quantity");
		quantity.value = quant;
		quantity.focus();
		
		min = Math.round( 0.5 + (Number(quant) * 0.2) );
		
		Information.fill( "minquantity", min);
		Information.fill( "maxquantity", quant - min)
		Information.fillAll( selectedElement );
		
		lastSelection = selectedElement;
		Tutorial.advance();
	},
	
	oneSelected : function( selectedElement, event ){
		if( Utils.canMoveOverPositioning(selectedElement.id, event ) ) {
			var quant = lastSelection.getQuantity();
			var quantitySelected = Utils.getQuantity();
			
			if( quantitySelected <= quant && quantitySelected > 0 ) {
				var quantRest = quant - quantitySelected;
				
				if( !selectedElement.hasChildNodes() ) {
					selectedElement.removeAll();
				}
				selectedElement.insert( lastSelection, quantitySelected, event );
				selectedElement.node.item = selectedElement;
				
				if( quantRest > 0 ) {
					lastSelection.setQuantity( quantRest );
				}else{
					lastSelection.removeAll();
					lastSelection.node.item = null;
				}
						
				if( lastSelection.isSource() && quantRest == 0) {
					lastSelection.setClass("unitOpacity");
				}else{
					lastSelection.setClass("");
				}
				lastSelection = null;
				Tutorial.advance();
			}else{
				RaiseError.invalidQuantity();
			}
		}
	},
	
	sameSector : function( selectedElement ){
		return lastSelection.id == selectedElement.id;
	},
	
	cleanSelected : function() {
		if( lastSelection != null ) {
			var empty = "";
			lastSelection.setClass(empty);
			lastSelection = null;
			Utils.getQuantityElement().value = empty;
			Information.fill("minquantity",empty);
			Information.fill("maxquantity",empty);
		}
	},
	
	getBottomElements : function() {
		if( Utils.numberOfPlayers() == 2 ) {
			return $('initialBottom').getElements('td');
		}
		return $('initialBottom4').getElements('td');
	},
	
	saveDeploy : function() {
	    if( Positioning.hasPositioned() ) {
	        var key = $('tournamentId').value + $('currentUser').value;
	        var moves = $('movesMade');
	        Positioning.gatherUnits(moves);
	        Cookie.dispose(key);
	        Cookie.write(key, encodeURI(moves.value) );
	        moves.value = "";
	        RaiseError.deploySaved();
	    }
	},
	
	loadDeploy : function() {
	    var key = $('tournamentId').value + $('currentUser').value;
	    var cookie = decodeURI(Cookie.read(key));
	    if( cookie != "null" && cookie != "" ) {
	        Positioning.cleanBottom();
	        Positioning.clearBoard();
	        var elements = cookie.split(';');
	        for( var e = 0; e < elements.length; ++e ) {
	            var curr = elements[e];
	            if( curr != "" ) {
	                var u = curr.split(':')[1].split('-');
	                var coord = $(u[1]);
                    var img = Positioning.createUnitImage(u[0], u[2])
			        coord.empty();
			        img.inject(coord);
			    }
	        }
	        RaiseError.deployLoaded();
	    }else{
	        RaiseError.noDeploySaved();
	    }
	},
	
	emptyField : function(td) {
	    td.empty();
		td.appendChild( new Element('span') );
	},
	
	createUnitImage : function( type, quant) {
	    var unit = Unit[type]();
	    
	    var img = new Element("img");
	    img.src = $('imagePath').value+"/Units/"+unit.name.toLowerCase()+".png";
	    img.title = quant;
	    img.alt = unit.name.toLowerCase();
	    
	    return img;
	},
	
	cleanBottom : function() {
	    $('initialBottom').getElements('td').each( function(td){
	        if( !td.hasClass('initialBottomIgnore')) {
	            Positioning.emptyField(td);
	            td.className = 'unitOpacity';
	        }
	    });
	},
	
	clearBoard: function(){
	    for( var x = 1; x <= 8; ++x ) {
	        Positioning.emptyField($("7_"+x));
	        Positioning.emptyField($("8_"+x));
	    }
	}
}
// FillInformationOnly.js
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
// Load.js
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


// UniverseUtils.js

var fleetMovements = [];
var UniverseUtils = {
    sendUniverseRequest : function(url, element, args) {
        if( $('hub').value == '1' ) {
            Message.raiseAlert("YouHaveBattlesToPlay");
            return false;
        }
    
        for( var propName in args ) {
            if( propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if( args.CallBack == null ) {
            args.CallBack = UniverseUtils.genericCallBack;
        }
        Utils.ajaxRequest('get', url, element, args.CallBack);
        return true;
    },
    
    sendRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/Universe.ashx?1=1";
        return UniverseUtils.sendUniverseRequest(url, $('universe'), args);
    },
    
    sendMoveRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/FleetMove.ashx?"+UniverseUtils.getFullCoordinateQueryString();
        return UniverseUtils.sendUniverseRequest(url, null, args);
    },
    
    sendSimpleMoveRequest : function(args) {
        var url = Site.appPath + "Ajax/Universe/FleetMove.ashx?1=1";
        return UniverseUtils.sendUniverseRequest(url, null, args);
    },
    
    getFullCoordinateQueryString : function() {
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var systemDst = UniverseUtils.getDestinySystem();
        var sectorDst= UniverseUtils.getDestinySector();
        return "systemSrc="+systemSrc+"&sectorSrc="+sectorSrc+"&systemDst="+systemDst+"&sectorDst="+sectorDst;
    },
       
    getSourceSystem : function() {
        return UniverseUtils.sourceSelected.getAttribute("system");
    },
    
    getSourceSector : function() {
        return UniverseUtils.sourceSelected.getAttribute("sector");
    },
    
    getSourceCoordinate : function() {
        return UniverseUtils.getSourceSystem() + "_" + UniverseUtils.getSourceSector();
    },
    
    getDestinySystem : function() {
        return UniverseUtils.destinySelected.getAttribute("system");
    },
    
    getDestinySector : function() {
        return UniverseUtils.destinySelected.getAttribute("sector");
    },
    
    getDestinyCoordinate : function() {
        return UniverseUtils.getDestinySystem() + "_" + UniverseUtils.getDestinySector();
    },
    
    sourceTypeKey : function() {
        return UniverseUtils.sourceSelected.getAttribute("type")+"Source";
    },
    
    destinyTypeKey : function() {
        return UniverseUtils.destinySelected.getAttribute("type")+"Destiny";
    },

    isPrivateSector : function() {
        return $("isPrivateSector").value == "1"; 
    },

    load : function() {
        var td = $('universe').getElements('td');
        td.addEvent('click', function( e ) {
            UniverseUtils.selected(this,e);
        });
        UniverseUtils.removeAllToolTips();
        UniverseUtils.addToolTips();
        UniverseDirection.load();
        UniverseUtils.resetSelected();
        UniverseUtils.addRightMenuEvents();
        
    },
    
    addRightMenuEvents  : function() {
        var element = $('zoom1');
        if( element != null ) {
            element.addEvent('click', function( e ) {
                UniverseUtils.zoom1();
            });
            $('zoom2').addEvent('click', function( e ) {
                UniverseUtils.zoom2();
            });
            $('zoom3').addEvent('click', function( e ) {
                UniverseUtils.zoom3();
            });
            $('zoom4').addEvent('click', function( e ) {
                UniverseUtils.zoom4();
            });
        }
        var element = $('moveToButton');
        if( element != null){
            element.addEvent('click', function( e ) {
                UniverseUtils.moveEventWithCoordinates();
            });
        }
    },
    
    addToolTips : function() {
        UniverseUtils.addFleetsToolTip();
        UniverseUtils.addPlanetToolTip();
        UniverseUtils.addArenaToolTip();
        UniverseUtils.addMarketToolTip();
        UniverseUtils.addWormHoleToolTip();
        UniverseUtils.addBattleToolTip();
        UniverseUtils.addBeaconToolTip();
        UniverseUtils.addAcademyToolTip();
        UniverseUtils.addPirateBayToolTip();
        UniverseUtils.addRelicToolTip();
    },
    
    addLine : function(token, value) {
        var body = Language.getToken(token);
        body += ': ' + value + '<br/>';;
        return body;
    },
    
    getAlliance : function(obj){
        return "<span class='"+obj.s+"'>"+obj.a+"</span>";
    },
    
    getTTM: function(fleet) {
        return fleet.ttm != null ? fleet.ttm : 1;
    },
    
    getTTTM: function(fleet) {
        return fleet.tttm != null ? fleet.tttm : 1;
    },
    
    getETA : function(fleet) {
        var s = fleet.c.split(':');
        var d = fleet.d.split(':');
        
        var src = [ Number(s[0]),Number(s[1]),Number(s[2]),Number(s[3]) ];
        var dst = [ Number(d[0]),Number(d[1]),Number(d[2]),Number(d[3]) ];
        var anglePoint = [ Number(src[0]),Number(dst[1]),Number(src[2]),Number(dst[3]) ];
        
        var dst1 = Math.abs( ( ( (src[0]-anglePoint[0]) + (src[1]-anglePoint[1]) )*10 ) + ( (src[2]-anglePoint[2]) + (src[3]-anglePoint[3]) ) );
        var dst2 = Math.abs( ( ( (dst[0]-anglePoint[0]) + (dst[1]-anglePoint[1]) )*7 ) + ( (dst[2]-anglePoint[2]) + (dst[3]-anglePoint[3]) ) );
        
        var ticks =  dst1 > dst2 ? dst1 : dst2;
        var gap = UniverseUtils.getTTM(fleet);
        var tgap = UniverseUtils.getTTTM(fleet);
        var total = (ticks*tgap)-(tgap-gap);
        return Utils.getTimeFromTicks(total);
    },
    
    getFleetToolTipBody : function(fleet ) {
        var body = UniverseUtils.addLine('Owner',fleet.o);
        body += UniverseUtils.addLine('Coordinate', fleet.c );
        body += UniverseUtils.addLine('IsMoving', Language.getToken(fleet.m) );
        
        if( fleet.m ) {
            body += UniverseUtils.addLine('Destination',fleet.d);
            body += UniverseUtils.addLine('ETA',UniverseUtils.getETA(fleet));
            body += UniverseUtils.addLine('TTM',Utils.getTimeFromTicks( UniverseUtils.getTTM(fleet) ));
            fleet.ttm = 1;
        }
        if( fleet.a != ''){
            body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(fleet));
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        body += UniverseUtils.getFleetBeaconInformation(fleet);
        body += UniverseUtils.getToolTipResources(fleet,"Cargo");
        body += UniverseUtils.getFleetToolTipUnits(fleet,"Units");
        return body;
    },
    
    getFleetBeaconInformation : function(fleet ) {
        var body = '';
        if( fleet.lq != null) {
            body += UniverseUtils.addLine("LightQuantity",fleet.lq);
        }
        if( fleet.mq != null ) {
            body += UniverseUtils.addLine("MediumQuantity",fleet.mq);
        }
        if( fleet.hq != null ) {
            body += UniverseUtils.addLine("HeavyQuantity",fleet.hq);
        }
        return body;
    },
    
    getFleetToolTipUnits : function(element,langKey ) {
        var body = '';
        if( element.u != null ) {
            if( element.u.length > 1 ) {
                var body = UniverseUtils.addLine(langKey,'');
                body += "<div class='popupFleetUnits'>";
                for( var i = 0; i < element.u.length; ++i ) {
                    var unit = element.u[i];
                    if( unit.n != 'ignore' ) {
                        body += "<div><img src='"+ Utils.resolveUnitImage(unit.n)+"' alt='' title=''/><br/>"+unit.q+"</div>";
                    }
                }
                body += "</div>";    
            }else{
                var body = UniverseUtils.addLine(langKey,Language.getToken("None"));
            }
        }
        return body;
    },
      
    getToolTipResources : function(element,token) {
        var body = '';
        if( element.i != null ) {
            if( element.i.length > 1 ) {
                var body = UniverseUtils.addLine(token,'');
                body += "<div class='popupPlanetIncome'>";
                for( var i = 0; i < element.i.length; ++i ) {
                    var resource = element.i[i];
                    if( resource.n != 'ignore' ) {
                        body += "<div><img src='"+ Utils.resolveEtcImage("Fill","gif")+"' class='resourceSmall resource"+resource.n+"' alt='' title=''/><br/>"+resource.q+"</div>";
                    }
                }
                body += "</div>";    
            }else{
                var body = UniverseUtils.addLine(token,Language.getToken("None"));
            }
        }
        return body;
    },
    
    getPlanetToolTipFacilities : function(element ) {
        if( element.f != null ) {
            return UniverseUtils.addLine("FacilityLevel", element.f);
        }
        return "";
    },
       
    getBattleToolTipBody : function( battle ) {
        var body = UniverseUtils.addLine('Player1',battle.p1);
        if( battle.a1 != ''){
            body += UniverseUtils.addLine('Alliance',"<span class='"+battle.s1+"'>"+battle.a1+"</span>");
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        body += UniverseUtils.addLine('Player2',battle.p2);
        if( battle.a2 != ''){
            body += UniverseUtils.addLine('Alliance',"<span class='"+battle.s2+"'>"+battle.a2+"</span>");
        }else{
            body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
        }
        return body;
    },
    
    addFleetsToolTip : function() {
        if( fleets ) {
            for( var id in fleets ) {
                var fleet = fleets[id];
                var elem = $(id);
                if( elem != null ) {
                    var body = UniverseUtils.getFleetToolTipBody(fleet);
                    Utils.insertTip(elem, fleet.n, body );
                }
            }
        }
    },
    
    getbeaconInformation : function(planet) {
        var body = UniverseUtils.getPlanetToolTipFacilities(planet);
        body += UniverseUtils.getToolTipResources(planet,"Income");
        body += UniverseUtils.getFleetToolTipUnits(planet,"DefenseFleet");
        return body;
    },
    
    addPlanetToolTip : function() {
        if( planets ) {
            for( var id in planets ) {
                var planet = planets[id];
                var pId = $(id);
                if( pId ) {
                    var body = "";
                    if( planet.o != "") {
                        body += UniverseUtils.addLine('Owner',planet.o);
                    }
                    body += UniverseUtils.addLine('Level',planet.l);               
                    body += UniverseUtils.addLine('Terrain', Language.getToken(planet.pt) );
                    body += UniverseUtils.addLine('Coordinate', planet.c );
                    
                    if( planet.a != ''){
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(planet));
                    }else{
                        body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
                    }
                    
                    body += UniverseUtils.getbeaconInformation(planet);
                    Utils.insertTip(pId, planet.n, body );
                }
            }
        }
    },
    
    addArenaToolTip : function() {
        if( arenas ) {
            for( var id in arenas ) {
                var arena = arenas[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Owner',arena.o);
                    body += UniverseUtils.addLine('IsInBattle',arena.b);
                    body += UniverseUtils.addLine('Coordinate', arena.c );
                    Utils.insertTip(pId, arena.n, body );
                }
            }
        }
    },
    
    addMarketToolTip : function() {
        if( markets ) {
            for( var id in markets  ) {
                var market = markets[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',market.c);
                    body += UniverseUtils.addLine('Level',market.l);
                    body += UniverseUtils.addLine('TradeResource',Language.getToken(market.r));
                    Utils.insertTip(pId, market.n, body );
                }
            }
        }
    },
    
    addWormHoleToolTip : function() {
        if( wormHoles  ) {
            for( var id in wormHoles  ) {
                var wormHole = wormHoles[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',wormHole.c);
                    if( wormHole.o != null ) {
                        body += UniverseUtils.addLine('Owner',wormHole.o);
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(wormHole));
                    }
                    Utils.insertTip(pId, wormHole.n, body );
                }
            }
        }
    },
    
    addBeaconToolTip : function() {
        if( beacons  ) {
            for( var id in beacons  ) {
                var beacon = beacons[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',beacon.c);
                    body += UniverseUtils.addLine('Owner',beacon.o);
                    body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(beacon));
                    Utils.insertTip(pId, beacon.n, body );
                }
            }
        }
    },
    
    addBattleToolTip : function() {
        if( battles ) {
            for( var id in battles ) {
                var battle = battles[id];
                var elem = $(id);
                if( elem != null ) {
                    var body = UniverseUtils.getBattleToolTipBody(battle);
                    Utils.insertTip(elem, battle.n, body );
                }
            }
        }
    },
    
    addAcademyToolTip : function() {
        if( academies  ) {
            for( var id in academies  ) {
                var academy = academies[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',academy.c);
                    body += UniverseUtils.addLine('Level',academy.l);
                    Utils.insertTip(pId, academy.n, body );
                }
            }
        }
    },

    addPirateBayToolTip : function() {
        if( piratebays  ) {
            for( var id in piratebays  ) {
                var piratebay = piratebays[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Coordinate',piratebay.c);
                    body += UniverseUtils.addLine('Level',piratebay.l);
                    Utils.insertTip(pId, piratebay.n, body );
                }
            }
        }
    },
    
    addRelicToolTip : function() {
        if( relics ) {
            for( var id in relics ) {
                var relic = relics[id];
                var pId = $(id);
                if( pId ) {
                    var body = UniverseUtils.addLine('Owner',relic.o);
                    body += UniverseUtils.addLine('IsInBattle',relic.b);
                    body += UniverseUtils.addLine('Coordinate', relic.c );
                    if( relic.a != ''){
                        body += UniverseUtils.addLine('Alliance',UniverseUtils.getAlliance(relic));
                    }else{
                        body += UniverseUtils.addLine('Alliance',Language.getToken('None'));
                    }
                    Utils.insertTip(pId, relic.n, body );
                }
            }
        }
    },
    
    removeAllToolTips : function() {
        $$(".tip-top").each( function(element) {
            var parent = element.getParent();
            parent.dispose();
            if( element.tip != null ) {
                element.tip.dispose();
            }
        });
    },
    
/* ============== Universe Menus ============== */

    toggleMoveTo : function(value){
        var moveToButton = $('moveToButton');
        if(moveToButton != null) { 
            moveToButton.disabled = value;
        }
    },
    
    selected : function( td, e ) {
        if( UniverseUtils.sourceSelected == null ) {
            UniverseUtils.noSelected(td,e);
        }else{
            UniverseUtils.oneSelected(td,e);
        }
    },
    
    noSelected :  function( td, e ) {
        var type = td.getAttribute("type");
        if( type == "fleetsector" ) {
            UniverseUtils.toggleMoveTo(false);
            UniverseUtils.renderFleetMenu(td,e);
            return;
        }
        if( type == "planetsector" ) {
            UniverseUtils.renderPlanetMenu(td,e);
            return;
        }
        if( type == "arenasector" ) {
            UniverseUtils.renderArenaMenu(td,e);
            return;
        }
        if( type == "fleetbattlesector" || type == "planetbattlesector" || type == "relicbattlesector" ) {
            UniverseUtils.renderBattleMenu(td,e);
        }
        if( type == "relicsector" ) {
            UniverseUtils.renderRelicMenu(td,e);
        }
        
    },
    
    oneSelected :  function( td, e ) {
        UniverseUtils.toggleMoveTo(true);
        var type = td.getAttribute("type");
        var srcType = UniverseUtils.sourceSelected.getAttribute("type");
        if( type == "fleetsector" || srcType == "fleetsector" ) {
            UniverseUtils.hideFleetMenu(td,e);
            return;
        }
        
        UniverseUtils.hideMenu(td,e);
    },
    
    resetSourceSelected :function() {
        if( UniverseUtils.sourceSelected != null ) {
            UniverseUtils.unselectSector(UniverseUtils.sourceSelected);
            UniverseUtils.sourceSelected = null;
        }
    },
    
    resetDestinySelected :function() {
        if( UniverseUtils.destinySelected != null ) {
            UniverseUtils.unselectSector(UniverseUtils.destinySelected);
            UniverseUtils.destinySelected = null;
        }
    },
    
    resetSelected : function() {
        UniverseUtils.resetSourceSelected();
        UniverseUtils.resetDestinySelected();
        UniverseUtils.hideAllOptions();
    },
    
    hideAllOptions : function() {
        var options = $("optionMenuText");
        if( options != null ) {
            options.getElements("div").each(  function( div ) {
                div.className = "optionHidden";
            });
        }
    },
    
    renderFleetMenu : function (td, e){
        if( fleets ) {
            var fleet = fleets[td.id];
            if( fleet == null ) {
                return;
            }
            if( fleet.cm ) {
                 if( fleet.m ) {
                    UniverseUtils.selectSector(td);
                    UniverseUtils.sourceSelected = td;
                    Menu.showUniverseMenu(e);
                    UniverseEvents.fleetsectorSourceOnMove();
                }else{
                    UniverseUtils.selectSector(td);
                    UniverseUtils.sourceSelected = td;
                }
            }
        }
    },
    
    renderPlanetMenu : function (td, e){
        if( planets ) {
            var planet = planets[td.id];
            if( planet != null ) {
                if( planet.cw ) {
                    UniverseUtils.sourceSelected = td;
                    Menu.showUniverseMenu(e);
                    UniverseEvents.planetsectorSource();
                }
            }
        }    
    },
    
    genericShowMenu : function (td, e, container, eventMethod){
        if( container ) {
            var element = container[td.id];
            if( element != null ) {
               UniverseUtils.sourceSelected = td;
               Menu.showUniverseMenu(e);
               eventMethod();
            }
        }    
    },
    
    renderArenaMenu : function (td, e){
        UniverseUtils.genericShowMenu(td,e,arenas,UniverseEvents.arenasectorSource);
    },
    
    renderRelicMenu : function (td, e){
        UniverseUtils.genericShowMenu(td,e,relics,UniverseEvents.relicsectorSource);
    },
    
    renderBattleMenu : function (td, e){
        if( battles ) {
            var battle = battles[td.id];
            if( battle != null ) {
               UniverseUtils.sourceSelected = td;
               Menu.showUniverseMenu(e);
               UniverseEvents.fleetbattlesectorSource();
            }
        }    
    },
    
    hideFleetMenu : function(td, e) {
        var optionMenu = $('optionMenu');
        var fleet = fleets[td.id];        
        if( td.id == UniverseUtils.sourceSelected.id || !optionMenu.hasClass("hidden") ) {
            optionMenu.addClass("hidden");
            UniverseUtils.resetSelected();
        }else{
            Menu.showUniverseMenu( e );
            UniverseUtils.selectSector(td);
            UniverseUtils.destinySelected = td;
            var key = UniverseUtils.sourceTypeKey();
            UniverseEvents[key]();
        }
    },
    
    hideMenu : function(td, e) {
        Menu.hideUniverseMenu( e );
        UniverseUtils.resetSelected();
    },
    
/* ============== Universe Menus End ============== */
    
    genericCallBack : function() {
    },
    
    updateDestinyAndMove: function() {
        UniverseUtils.updateDestinyAndMove2(UniverseUtils.getDestinyCoordinate(),1)
    },
    
    updateDestinyAndMove2: function( dst,value ) {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        UniverseUtils.updateTTM(fleet,value);
        fleet.m = true;
        fleet.d = dst.replaceAll("_",":");
        UniverseUtils.hideMenu();
        
        var body = UniverseUtils.getFleetToolTipBody(fleet);
        
        Utils.updateTip($(src), body);
    },
    
    updateTTM: function(fleet,value){
        fleet.ttm = 1;
        fleet.tttm = value;
    },
    
    cancelDestinyAndMove: function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        fleet.m = false;
        fleet.d = "";
        UniverseUtils.hideMenu();
        Utils.updateTip($(src), UniverseUtils.getFleetToolTipBody(fleet));
    },
    
    moveEvent : function() {
        UniverseUtils.sendMoveRequest( {Type:'move'} );
        UniverseUtils.updateDestinyAndMove();
    },
    
    moveUndiscoveredEvent: function() {
        Menu.hideUniverseMenu();
        if( Message.raiseConfirm("MoveUndiscovered") ) {   
            UniverseUtils.sendMoveRequest( {Type:'moveundiscovered'} );
            UniverseUtils.updateDestinyAndMove2(UniverseUtils.getDestinyCoordinate(),4);
        }
    },
    
    moveToValid : function() {
        var x = Number($("x").value);
        var y = Number($("y").value);
        var sx = Number($("sx").value);
        var sy = Number($("sy").value);
        
        return Utils.systemCoordinateValid(x) && Utils.systemCoordinateValid(y) && Utils.sectorCoordinateXValid(sx) && Utils.sectorCoordinateYValid(sy);
    },
    
    moveEventWithCoordinates : function() {
        if( UniverseUtils.sourceSelected == null ) {
            RaiseError.needToSelectAFleetFirst();
            return;
        }
    
        if( UniverseUtils.moveToValid() ) {
            var systemDst = $("x").value+"_"+$("y").value;
            var sectorDst= $("sx").value+"_"+$("sy").value;
            UniverseUtils.sendSimpleMoveRequest( {Type:'coordValid',systemDst:systemDst,sectorDst:sectorDst,CallBack:UniverseUtils.moveEventWithCoordinatesCallBack} );
        }else{
            RaiseError.invalidCoordinate();
        }
    },
    
    moveEventWithCoordinatesCallBack : function( responseTree, responseElements, responseHTML, responseJavaScript ) {
        var systemDst = $("x").value+"_"+$("y").value;
        var sectorDst= $("sx").value+"_"+$("sy").value;
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var ttm = 1;
        if( responseHTML == "False" ) {
            if( Message.raiseConfirm("MoveUndiscovered") ) {
                UniverseUtils.sendSimpleMoveRequest( {Type:'moveundiscovered',systemSrc:systemSrc,sectorSrc:sectorSrc,systemDst:systemDst,sectorDst:sectorDst} );
                UniverseUtils.updateDestinyAndMove2(systemDst+"_"+sectorDst,4);
            }
        }else{
            UniverseUtils.sendSimpleMoveRequest( {Type:'move',systemSrc:systemSrc,sectorSrc:sectorSrc,systemDst:systemDst,sectorDst:sectorDst} );
            UniverseUtils.updateDestinyAndMove2(systemDst+"_"+sectorDst,1);
        }
    },
    
    unloadCargoEvent : function() {
       UniverseUtils.sendMoveRequest( {Type:'moveAndUnload'} );
        UniverseUtils.updateDestinyAndMove();
    },
    
    attackEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'attack'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
        
    },
    
    attackPlanetConquerEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'attackPlanet'} )) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    attackPlanetRaidEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'raidPlanet'} )) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    pursuitAttackEvent : function() {
        $('optionMenu').addClass("hidden");
        var fleet = fleets[UniverseUtils.destinySelected.id];
        if( UniverseUtils.sendMoveRequest( {Type:'pursuitandattack', FleetId:fleet.id } ) ){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    cancelEvent: function() {
        $('optionMenu').addClass("hidden");       
        var fleet = fleets[UniverseUtils.getSourceCoordinate()];
        if( UniverseUtils.sendSimpleMoveRequest( {Type:'cancelmove', FleetId:fleet.id } )){
            UniverseUtils.cancelDestinyAndMove();
        }
    },
       
    transportEvent : function() {
        var fleet = fleets[UniverseUtils.getSourceCoordinate()];
        if( fleet.cpw ) {
            var system = UniverseUtils.getDestinySystem();
            var sector = UniverseUtils.getDestinySector();
            UniverseMap.show(system,sector);       
        }else{
            RaiseError.cantPassWormHoles();
        }
    },
    
    conquerEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'conquer'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    challengeEvent : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'arenaChallenge'} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    showMarketEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
        
        var fleet = fleets[src];
        var market = markets[dst];
        
        var url =Site.appPath + "SimpleMarket.aspx?Fleet="+fleet.id+"&Market="+market.id;
        
        Utils.createIFrame('simpleMarket', url, 'Market', 921,850);
        
        UniverseUtils.hideMenu();
    },
    
    showAcademyEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        
        var url =Site.appPath + "Academy.aspx?" + UniverseUtils.getFullCoordinateQueryString() + "&Fleet="+fleet.id;
              
        Utils.createIFrame('Academy', url, 'Academy', 921,490);
        
        UniverseUtils.hideMenu();
    },
    
    showPirateBayEvent : function() {
    
        var dst = UniverseUtils.getDestinySystem();
        var sys = dst.split('_');
        var url =Site.appPath + "PirateBay.aspx?sysX="+sys[0]+"&sysY="+sys[1];
        
        Utils.createIFrame('PirateBay', url, 'PirateBay', 921,490);
        
        UniverseUtils.hideMenu();
    },
    
    showArenaEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var arena = arenas[src];
        window.location = Site.appPath + "Arenas/ArenaInfo.aspx?ArenaStorage="+arena.id;
    },
    
    viewBattleEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var battle = battles[src];
        window.location = Site.appPath + "Battle/Battle.aspx?id="+battle.bId;
    },
    
    showRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
        
        var fleet = fleets[src];
        var relic = relics[dst];
        
        var url =Site.appPath + "Relic.aspx?"+ UniverseUtils.getFullCoordinateQueryString();
        
        Utils.createIFrame('relic', url, 'Relic', 921,500);
        
        UniverseUtils.hideMenu();
    },
    
    showRelic2Event : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var relic = relics[src];
        
        var systemSrc = UniverseUtils.getSourceSystem();
        var sectorSrc = UniverseUtils.getSourceSector();
        var coordinate = "systemSrc="+systemSrc+"&sectorSrc="+sectorSrc;
        
        var url =Site.appPath + "Relic.aspx?"+ coordinate;
        Utils.createIFrame('relic', url, 'Relic', 921,500);
        
        UniverseUtils.hideMenu();
    },
    
    attackRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        if( UniverseUtils.sendMoveRequest( {Type:'attackRelic', FleetId:fleet.id} ) ){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    conquerRelicEvent : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[src];
        if(UniverseUtils.sendMoveRequest( {Type:'conquerRelic', FleetId:fleet.id} )){
            UniverseUtils.updateDestinyAndMove();
        }
    },
    
    useUltimate : function() {
        if( UniverseUtils.sendMoveRequest( {Type:'useUltimate',CallBack:Message.messageCallBack} ) ) {
            UniverseUtils.updateDestinyAndMove();
        }
        $("ultimateReady").value = 0;
    },
    
    fireDevastation : function() {
        if( Message.raiseConfirm("DevastationUsageConfirmation") ) {
            if( UniverseUtils.sendMoveRequest( {Type:'fireDevastation',CallBack:Message.messageCallBack} ) ){
                UniverseUtils.hideMenu();
                $("ultimateReady").value = 0;
            }
        }
    },
    
    goToMarketEvent : function() {
       UniverseUtils.moveEvent();
    },
    
    goToAcademyEvent : function() {
       UniverseUtils.moveEvent();
    },
    
    goToPirateBayEvent : function() {
       UniverseUtils.moveEvent();
    },
       
    selectSector : function(elem) {
       UniverseSelection.select(elem);
    },
    
    unselectSector : function(elem) {
       UniverseSelection.unselect(elem);
    },
    
    centerInFleet : function(fleetId) {
        UniverseUtils.sendRequest( {Type:'centerfleet', Fleet: fleetId, CallBack:UniverseUtils.load} );
    },
    
    centerInPlanet : function(planetId) {
        UniverseUtils.sendRequest( {Type:'centerplanet', Planet: planetId, CallBack:UniverseUtils.load} );
    },
    
    centerInCoordinate : function(coord) {
        UniverseUtils.sendRequest( {Type:'centercoordinate', Coordinate: coord, CallBack:UniverseUtils.load} );
    },
    
    zoom1 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 0, CallBack:UniverseUtils.load} );
    },
    
    zoom2 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 1, CallBack:UniverseUtils.load} );
    },
    
    zoom3 : function() {
        UniverseUtils.sendRequest( {Type:'zoom', ZoomLevel: 2, CallBack:UniverseUtils.load} );
    },
    
    zoom4 : function() {
        UniverseUtils.  sendRequest( {Type:'zoom', ZoomLevel: 3,CallBack:UniverseUtils.load} );
    },
    
    showPlanetIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(planets, "Planets");
        UniverseUtils.insertIconInfoTip(tipsInfo,"Planets");
    },
    
    showFleetIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(fleets, "Fleets");
        UniverseUtils.insertIconInfoTip(tipsInfo,"Fleets");
    },
    
    showWormHoleIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(wormHoles, "WormHoles");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
    showArenaIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(arenas, "Arenas");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
     showMarketIcons : function() {
        var tipsInfo = UniverseUtils.showSmallIcons(markets, "Markets");
        UniverseUtils.insertGenericIconInfoTip(tipsInfo);
    },
    
    showSmallIcons : function( json, containerName ) {
        UniverseUtils.removeAllToolTips();
        UniverseUtils.removeOlderIcons();
        return UniverseUtils.parseAndShowIcons(json, containerName);
    },
    
    removeOlderIcons : function() {
        $("universeItems").getElements("td").each(function(item){
            if( item.className != "" ) {
                var td = item.getPrevious("td");
                var newItem = new Element("td",{id:item.id});
                if( td != null ) {
                    item.destroy();
                    newItem.inject(td, 'after');
                }else{
                    td = item.getNext("td");
                    item.destroy();
                    newItem.inject(td, 'before');
                }
            }
        });
    },
    
    parseAndShowIcons: function(json, containerName) {
        var tipAgregator = new Hash();
        var owner = $("playerName").value;
        for( var x in json ) {
            var elem = json[x];
            var splitted = x.split('_');
            var sx = Number(splitted[0]);
            var sy = Number(splitted[1]);
            for( var i = 1; i < zoneMapping.length; ++i ) {
                if( elem.on != null && elem.on != owner ) {
                    continue;
                }
                var c = zoneMapping[i];
                
                if( sx >= c[0] && sy >= c[1] && sx <= c[2] &&  sy <= c[3] ) {
                    var id = 's'+i;
                    UniverseUtils.showSmallIcon($(id),json, x, containerName);
                    if( !tipAgregator.has(id) ) {
                        tipAgregator.set(id,[]);
                    }
                    var value = tipAgregator.get(id);
                    value.include(elem);
                    break;
                }
            }
        }
        return tipAgregator;
    },
    
    showSmallIcon : function(elem, json, coord, containerName) {
        if(elem != null && elem.className == ""){
            elem.className = json[coord].uty;
            elem.addEvent('click', function( e ) {
                UniverseUtils.centerInCoordinate(coord);
            });
        }
    },
    
    insertIconInfoTip: function( tipsInfo, titleToken ) {
        tipsInfo.each( function(value,key){
            var title = Language.getToken(titleToken);
            var body = '';
            value.each( function(item){
                body+= "<span class='tipItem'>"+item.n +"</span>: "+ item.c +"<br/>";
            });
            Utils.insertTip($(key),title,body);

        });
    },
    
    insertGenericIconInfoTip: function(tipsInfo){
        tipsInfo.each( function(value,key){
            var title;
            var body = "<span class='tipItem'>"+ Language.getToken('Coordinate') +"</span>: ";
            value.each( function(item){
                title = item.n;
                body+= item.c;
            });
            var elem = $(key);
            if(elem != null){
                Utils.insertTip(elem,title,body);
            }
        });
    }
}

var UniverseMap = {
    show : function(system, sector) {
        $('optionMenu').addClass("hidden");
        
        var isPrivate = UniverseUtils.destinySelected.getAttribute("isprivate");
        if( isPrivate == null ) {
            isPrivate = false;
        }

        var url = "Ajax/Universe/WormHoleMap.ashx?system="+system+"&sector="+sector+"&isPrivate="+isPrivate;
        if( !$("wormHoleMap") ) {
            UniverseMap.addWormHoleMapControl();
        }
        
        Utils.ajaxRequest('get', url, $("wormHoleMap"), UniverseMap.onShow);
    },
    
    onShow : function( responseText, responseXml ) {
        var img = $('wormHoleMap').getElements('img');
        img.addEvent('mouseover', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                if( this.src.indexOf("Private") > 0 ) {
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestPrivateCurrent.png";
                }else{
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestCurrent.png";
                }
            }
        });
        img.addEvent('mouseout', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                if( this.src.indexOf("Private") > 0 ) {
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallestPrivate.png";            
                }else{
                    this.src = $("imagePath").value + "/Universe/WormHoleSmallest.png";
                }
            }
        });
        img.addEvent('click', function( e ) {
            if( this.getAttribute("current") != "true" ) {
                var system = this.getAttribute("system");
                var sector = this.getAttribute("sector");
                UniverseMap.onMove(system, sector);
            }
        });
    },
    
    onHide : function() {
    },
    
    onMove : function( system, sector ) {
        UniverseMap.onHide();
        UniverseUtils.sendMoveRequest( {Type:'transport', wormHoleSystemSrc:system, wormHoleSectorSrc:sector } );
        UniverseUtils.updateDestinyAndMove();
        Utils.closeFrame('wormHoleMapWindow');
    },
    
    addWormHoleMapControl : function() {
        //var e = new Element('div', {id: 'wormHoleMap'});
        var style = {};
        var e = "<div id='wormHoleMap'></div>";
        Utils.createFrame( 'wormHoleMapWindow', 'WormHole', e, style , UniverseUtils.resetDestinySelected );
    }
}

var UniverseEvents = {
    eraseElementClass : function(element){
        $(element).className = "";
    },

    showMove : function() {
        UniverseEvents.eraseElementClass("move");
    },
    
    unloadCargo : function() {
        UniverseEvents.eraseElementClass("unloadCargo");
    },
    
    showUndiscoveredMove : function() {
        UniverseEvents.eraseElementClass("moveUndiscovered");
    },
    
    showUltimateReady : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        if( $("ultimateReady").value == '1' && ultimateInfo.r && ( !ultimateInfo.lm || ( ultimateInfo.lm && ultimateInfo.uc.contains(key) ) ) ) {
            UniverseEvents.eraseElementClass("useUltimate");    
        }
    },
    
    showUltimateNormalReady : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        if( $("ultimateReady").value == '1' && ultimateInfo.r && ( !ultimateInfo.lm || ( ultimateInfo.lm && ultimateInfo.uc.contains(key) ) ) ) {
            UniverseEvents.eraseElementClass("useUltimate");    
        }
    },
    
    showTransport : function() {
        UniverseEvents.eraseElementClass("transport");
    },
    
    showAttack : function() {
        UniverseEvents.eraseElementClass("attack");
    },
    
    showPursuitAndAttack : function() {
        UniverseEvents.eraseElementClass("pursuitAndAttack");
    },
    
    showPlanetConquerAttack : function() {
        UniverseEvents.eraseElementClass("attackPlanetConquer");
    },
    
    showPlanetRaidAttack : function() {
        UniverseEvents.eraseElementClass("attackPlanetRaid");
    },
    
    showCancel : function() {
        UniverseEvents.eraseElementClass("cancel");
    },
    
    showChallenge : function() {
        UniverseEvents.eraseElementClass("challenge");
    },
    
    showConquer : function() {
        UniverseEvents.eraseElementClass("conquer");
    },
    
    showPlanetOptions : function(planet) {
        var baseUrl = 'Planets/Default.aspx?id='+planet.id;
        
        $("viewPlanet").getFirst().href= baseUrl;
        UniverseEvents.eraseElementClass("viewPlanet");
        
        $("viewQueue").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Queue/";
        UniverseEvents.eraseElementClass("viewQueue");
        
        if( planet.p){
            $("buildUnits").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Units/";
            UniverseEvents.eraseElementClass("buildUnits");
        }
        
        $("viewFleets").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Fleets/";
        UniverseEvents.eraseElementClass("viewFleets");
        
        $("viewManage").getFirst().href= baseUrl + "#/Planet_"+planet.id+"/Panel_Manage/";
        UniverseEvents.eraseElementClass("viewManage");
    },
    
    showMarket : function() {
        UniverseEvents.eraseElementClass("market");
    },
    
    showAcademy : function() {
        UniverseEvents.eraseElementClass("academy");
    },
    
    showPirateBay : function() {
        UniverseEvents.eraseElementClass("pirateBay");
    },
    
    showArena : function() {
        UniverseEvents.eraseElementClass("arena");
    },
    
    showToMarket : function() {
        UniverseEvents.eraseElementClass("toMarket");
    },
    
    showToAcademy : function() {
        UniverseEvents.eraseElementClass("toAcademy");
    },
    
    showToPirateBay : function() {
        UniverseEvents.eraseElementClass("toPirateBay");
    },
    
    showBattleLink : function() {
        UniverseEvents.eraseElementClass("viewBattle");
    },
    
    showRelic : function() {
        UniverseEvents.eraseElementClass("showRelic");
    },
    
    showRelic2 : function() {
        UniverseEvents.eraseElementClass("showRelic2");
    },
    
    showAttackRelic : function() {
        UniverseEvents.eraseElementClass("attackRelic");
    },
    
    showConquerRelic : function() {
        UniverseEvents.eraseElementClass("conquerRelic");
    },
    
    showNoOption : function() {
        UniverseEvents.eraseElementClass("noOption");
    },
    
    fleetsectorSourceOnMove : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showCancel();
    },
    
    fleetsectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents[UniverseUtils.destinyTypeKey()]();
    },
    
    planetsectorSource : function() {
        UniverseUtils.hideAllOptions();
        var key = UniverseUtils.getSourceCoordinate();
        var planet = planets[key];
        if( planet.id != 0 ) {
            UniverseEvents.showPlanetOptions(planet);
        }
    },
    
    fleetbattlesectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showBattleLink();
    },
    
    arenasectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showArena();
    },
    
    marketsectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showMarket();
    },
    
    academysectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showAcademy();
    },
    
    pirateBaysectorSource : function() {
        UniverseUtils.hideAllOptions();
        UniverseEvents.showPirateBay();
    },
    
    relicsectorSource : function() {
        UniverseUtils.hideAllOptions();
        var key = UniverseUtils.getSourceCoordinate();
        var relic = relics[key];
        var player = $('playerName').value;
        if(player == relic.on){
            UniverseEvents.showRelic2();
        }else{
            UniverseEvents.showNoOption();
        }
    },
    
    fleetsectorDestiny : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        var fleet = fleets[key];
        if( fleet.ca ) {
            if( fleet.m ) {
                UniverseEvents.showPursuitAndAttack();
            }else{
                UniverseEvents.showAttack();
            }
            UniverseEvents.showUltimateReady();
        }else{
            UniverseEvents.showNoOption();
        }
    },
    
    planetsectorDestiny : function() {
        var key = UniverseUtils.getDestinyCoordinate();
        var planet = planets[key];
        
        if( planet.cm ) {
            UniverseEvents.showMove();
            UniverseEvents.unloadCargo();
        }
        
        if( planet.ca ) {
            UniverseEvents.showPlanetConquerAttack();
            UniverseEvents.showPlanetRaidAttack();
            UniverseEvents.showUltimateReady();
        }
        
        if( planet.cc ) {
            UniverseEvents.showConquer();
        }
        
        if( !planet.ca && !planet.cm && !planet.cc ){
            UniverseEvents.showNoOption();
        }
    },
    
    wormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    privatewormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    normalsectorDestiny : function() {
        UniverseEvents.showMove();
        UniverseEvents.showUltimateNormalReady();
    },
    
    undiscoveredsectorDestiny : function() {
        UniverseEvents.showUndiscoveredMove();
    },
    
    resourcesectorDestiny : function() {
        UniverseEvents.showMove();
    },
    
    arenasectorDestiny : function() {
        UniverseEvents.showChallenge();
    },
    
    marketsectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( markets[dst].a.contains(src) ) {
            UniverseEvents.showMarket();
        }else{
            UniverseEvents.showToMarket();
        }
    },
    
    bugswormholesectorDestiny : function() {
        UniverseEvents.showTransport();
    },
    
    fleetbattlesectorDestiny : function() {
        UniverseEvents.showNoOption();
    },
    
    beaconsectorDestiny : function() {
        UniverseEvents.showNoOption();
    },
    
    academysectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( academies[dst].a.contains(src) ) {
            UniverseEvents.showAcademy();
        }else{
            UniverseEvents.showToAcademy();
        }
    },
    
    piratebaysectorDestiny : function() {
        var src = UniverseUtils.getSourceCoordinate();
        var dst = UniverseUtils.getDestinyCoordinate();
    
        if( piratebays[dst].a.contains(src) ) {
            UniverseEvents.showPirateBay();
        }else{
            UniverseEvents.showToPirateBay();
        }
    },
    
    relicsectorDestiny : function() {
        var key = UniverseUtils.getSourceCoordinate();
        var fleet = fleets[key];
        
        if(fleet!= null){
            var key = UniverseUtils.getDestinyCoordinate();
            var relic = relics[key];
            
            if( relic.cc ) {
                UniverseEvents.showConquerRelic();
            }
            
            if( relic.ca ) {
                UniverseEvents.showAttackRelic();
                UniverseEvents.showUltimateReady();
            }
               
            if( relic.on == fleet.on ) {
                UniverseEvents.showRelic();
            }
        }
       
    }
    
}

var UniverseSelection = {
    changeToSelect : function(elem){
        elem.className = elem.className+"Hover";
    },
    
    changeToUnselect : function(elem){
        elem.className = elem.className.replace("Hover","");
    },

    select : function(elem) {
        var type = elem.getAttribute("type");
        UniverseSelection[type+"Select"](elem);
    },
    
    unselect : function(elem) {
        var type = elem.getAttribute("type");
        UniverseSelection[type+"Unselect"](elem);
    },
    
    fleetsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    fleetsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    planetsectorSelect : function(elem){
    
    },
    
    planetsectorUnselect : function(elem){
    
    },
    
    wormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    wormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    privatewormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    privatewormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    normalsectorSelect : function(elem){
    
    },
    
    normalsectorUnselect : function(elem){
    
    },
    
    undiscoveredsectorSelect : function(elem){
    
    },
    
    undiscoveredsectorUnselect : function(elem){
    
    },
    
    resourcesectorSelect : function(elem){
    
    },
    
    resourcesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    arenasectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    arenasectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    marketsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    marketsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    fleetbattlesectorSelect : function(elem){
    
    },
    
    fleetbattlesectorUnselect : function(elem){
    
    },
    
    bugswormholesectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    bugswormholesectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    beaconsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    beaconsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    academysectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    academysectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    piratebaysectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    piratebaysectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    },
    
    relicsectorSelect : function(elem){
        UniverseSelection.changeToSelect(elem);
    },
    
    relicsectorUnselect : function(elem){
        UniverseSelection.changeToUnselect(elem);
    }
}

var UniverseDirection = {

    b : function() {
    },

    addEvents : function( element ) {
        element.addEvent('click', function( e ) {
            var code = this.getAttribute("code");
            UniverseDirection.updateUniverse(e,code);
        });
        element.addEvent('mouseout', function( e ) {
            this.removeClass('selected');
        });
		element.addEvent('mouseover', function( e ) {
		    this.addClass('selected');
		});
    },
    
    load : function() {
        var v = $("uab");
        if( v ) {
            UniverseDirection.addEvents($("uab"));
            UniverseDirection.addEvents($("uad"));
            UniverseDirection.addEvents($("uae"));
            UniverseDirection.addEvents($("uag"));
        }
    },
    
    updateUniverse : function(e,code) {
        UniverseUtils.sendRequest( {Type:'movemap', Code:code, CallBack:UniverseUtils.load} );
    },
    
    onUpdateUniverseCallBack : function() {
        UniverseUtils.load();
    }
}

window.addEvent('domready', function() {
	if( $("universe") ) {
		UniverseUtils.load();
	}
});

// Menu.js
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
// Fleet.js
var Fleet = {
    fleetLists: null,
    quantityInput: null,
    currentClone: null,
    currentItem: null,
    changeLog: "",

    load: function() {
        Fleet.fleetLists = $$(".fleetUnits, .BattleMoonUnits, .BlinkerUnits, .QueenUnits");

        if (Fleet.fleetLists.length > 0) {
            Fleet.fleetLists.each(function(item) {
                Fleet.setDrag(item);
            });

            $('transferQuantity').addEvent('click', Fleet.transferQuantity);
            $('cancelTransfer').addEvent('click', Fleet.clearTransferInfo);
            $('saveChanges').addEvent('click', Fleet.saveChangesPlanet);
            $('saveChanges').disabled = true;

            Fleet.quantityInput = $('quantity');

            FleetCargo.load();
        }
    },

    sendRequest: function(args) {
        var url = Site.appPath + "Ajax/Fleet/Fleet.ashx?1=1";
        for (var propName in args) {
            if (propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if (args.CallBack == null) {
            args.CallBack = Fleet.genericCallBack;
        }
        Utils.ajaxRequest('get', url, null, args.CallBack);
    },

    setDrag: function(parent) {
        parent.getElements('div').each(function(item) {
            item.addEvent('mousedown', function(e) {
                if (parent == null) {
                    return;
                }

                if (Fleet.isInBattle(parent)) {
                    RaiseError.fleetInBattle();
                    return;
                }

                if (Fleet.isMoving(parent)) {
                    RaiseError.fleetIsMoving();
                    return;
                }

                Fleet.unitClick(this, parent, e);
            });
        });
    },

    isInBattle: function(element) {
        var attr = element.getAttribute('isInBattle');
        return attr == "true";
    },

    isMoving: function(element) {
        var attr = element.getAttribute('isMoving');
        return attr == "true";
    },

    unitClick: function(item, parent, e) {
        var clone = Fleet.getClone(item);

        var drag = clone.makeDraggable({
            droppables: Fleet.fleetLists,
            onDrop: function(element, droppable) {
                if (droppable == null) {
                    clone.dispose();
                    return;
                }
                if (Fleet.isInBattle(droppable)) {
                    RaiseError.fleetInBattle();
                    clone.dispose();
                    droppable.removeClass('fleetUnitsOver');
                    return;
                }

                if (Fleet.isMoving(droppable)) {
                    RaiseError.fleetIsMoving();
                    clone.dispose();
                    droppable.removeClass('fleetUnitsOver');
                    return;
                }

                var p = item.getParent();

                if (droppable && droppable != p && Fleet.isFleetAround(p, droppable)) {
                    Fleet.dropEvent(clone, item, droppable);

                } else {
                    clone.dispose();
                }
            },
            onEnter: function(element, droppable) {
                var p = item.getParent();
                if (droppable != p && Fleet.isFleetAround(p, droppable)) {
                    droppable.addClass('fleetUnitsOver');
                }
            },
            onLeave: function(element, droppable) {
                if (droppable != parent) {
                    droppable.removeClass('fleetUnitsOver');
                }
            }
        });

        drag.start(e);
    },

    chooseClassToAdd: function(droppable) {
        if (droppable.hasClass("BattleMoonUnits")) {
            droppable.addClass('BattleMoonUnitsOver');
            return;
        }
        if (droppable.hasClass("BlinkerUnits")) {
            droppable.addClass('BlinkerUnitsOver');
            return;
        }
        if (droppable.hasClass("QueenUnitsUnits")) {
            droppable.addClass('QueenUnitsUnitsOver');
            return;
        }
        droppable.addClass('fleetUnitsOver');
    },

    chooseClassToRemove: function(droppable) {
        if (droppable.hasClass("BattleMoonUnitsOver")) {
            droppable.removeClass('BattleMoonUnitsOver');
            return;
        }
        if (droppable.hasClass("BlinkerUnitsOver")) {
            droppable.removeClass('BlinkerUnitsOver');
            return;
        }
        if (droppable.hasClass("QueenUnitsUnitsOver")) {
            droppable.removeClass('QueenUnitsUnitsOver');
            return;
        }
        droppable.removeClass('fleetUnitsOver');
    },

    isFleetAround: function(srcFLeet, dstFLeet) {
        if (Fleets) {
            var dst = Fleets[dstFLeet.getAttribute('fleetid')];
            var src = Number(srcFLeet.getAttribute('fleetid'));
            if (!dst.p.contains(src)) {
                return false;
            }
        }
        return true;
    },

    getClone: function(item) {
        var clone = item.clone();
        var name = item.getAttribute("unitName");
        clone.setAttribute("unitName", name);

        clone.setStyles(item.getCoordinates());
        clone.setStyles({ 'opacity': 0.7, 'position': 'absolute' });
        clone.inject(document.body);
        return clone;
    },

    dropEvent: function(clone, item, destiny) {
        if (Fleet.currentClone != null) {
            Fleet.clearTransferInfo();
        }

        var menu = $('quantitySelector');
        Menu.positionByElement(menu, clone, { x: 30, y: 30 });
        menu.removeClass('hidden');
        Fleet.quantityInput.focus();
        Fleet.quantityInput.value = clone.getFirst().getAttribute("quantity");
        Fleet.currentClone = clone;
        Fleet.currentItem = item;
        Fleet.currentDestiny = destiny;
    },

    clearTransferInfo: function() {
        var menu = $('quantitySelector');
        menu.addClass('hidden');

        Fleet.currentClone.dispose();
        Fleet.currentDestiny.removeClass('fleetUnitsOver');
        Fleet.currentClone = null;
        Fleet.currentItem = null;
        Fleet.currentDestiny = null;
    },

    transferQuantity: function(e) {
        var unitName = Fleet.currentClone.getAttribute('unitName');

        var quantityToTransfer = Number(Fleet.quantityInput.value);
        var originalQuantity = Number(Fleet.currentClone.getFirst().getAttribute("quantity"));

        if (quantityToTransfer > 0 && quantityToTransfer <= originalQuantity) {
            var added = Fleet.addQuantity(unitName, quantityToTransfer);
            if (added) {
                if (quantityToTransfer == originalQuantity) {
                    Fleet.currentItem.destroy();
                } else {
                    var newQuant = Number(originalQuantity) - Number(quantityToTransfer);
                    Fleet.changeQuantity(Fleet.currentItem, newQuant);
                }
            } else {
                RaiseError.fleetAtMaximum();
            }
            Fleet.clearTransferInfo();
        } else {
            RaiseError.invalidQuantity();
        }
    },

    addQuantity: function(unitName, quantity) {
        var added = false;

        var elements = Fleet.currentDestiny.getElements('div');

        elements.each(function(item) {
            if (added) {
                return;
            }
            var name = item.getAttribute("unitName");
            if (name == unitName) {
                //alert(unitName);
                Fleet.registerChange(unitName, quantity);
                var unitQuantity = item.getFirst().getAttribute("quantity");
                var total = Number(unitQuantity) + Number(quantity);
                Fleet.changeQuantity(item, total);
                added = true;
            }
        });
        if (added) {
            return true;
        }
        if (elements.length < 8) {
            var clone = Fleet.currentItem.clone();
            clone.addEvent('mousedown', function(e) {
                Fleet.unitClick(this, Fleet.currentDestiny, e);
            });
            Fleet.currentDestiny.adopt(clone);
            Fleet.changeQuantity(clone, quantity);
            Fleet.registerChange(unitName, quantity);
            return true;
        }
        return false;
    },

    changeQuantity: function(elem, quantity) {
        var img = elem.getFirst();
        img.setAttribute("quantity", quantity);
        var span = elem.getElement('span');
        span.empty();
        span.appendText(quantity);
    },

    registerChange: function(unitName, quantity) {
        var srcId = Fleet.currentItem.getParent().getAttribute('fleetId');
        var dstId = Fleet.currentDestiny.getAttribute('fleetId');
        Fleet.changeLog += srcId + "-" + dstId + "-" + unitName + "-" + quantity + ";";
        $('saveChanges').disabled = false;
    },

    genericCallBack: function() {
        Fleet.changeLog = "";
        Fleet.load();
    },

    saveChangesPlanet: function() {
        Fleet.sendRequest({ Type: 'change', Changes: Fleet.changeLog, CargoChanges: FleetCargo.changeLog, IsInPlanet: 1, CallBack: Fleet.saveChangesCallBack });
    },

    saveChangesPlayer: function() {
        Fleet.sendRequest({ Type: 'change', Changes: Fleet.changeLog, CargoChanges: FleetCargo.changeLog, IsInPlanet: 0, CallBack: Fleet.saveChangesCallBack });
    },

    saveChangesCallBack: function() {
        Fleet.changeLog = "";
        Fleet.load();
        Message.raiseAlert("FleetSavedWithSuccess");
    },

    deleteFleet: function(planetId, fleetId, dstFleeId) {
        if (!Message.raiseConfirm("AreYouSureYouWantToDeleteFleet")) {
            return;
        }

        var fleet = $('fleet' + fleetId);
        var dstFleet = $('fleet' + dstFleeId);

        fleet.getElements('.fleetListUnit').each(function(item) {
            var name = item.getAttribute("unitName");
            var unitQuantity = item.getFirst().getAttribute("quantity");
            var added = false;
            var elements = dstFleet.getElements('.fleetListUnit')
            elements.each(function(dstitem) {
                var destinyName = dstitem.getAttribute("unitName");
                if (destinyName == name) {
                    var dstUnitQuantity = dstitem.getFirst().getAttribute("quantity");
                    var total = Number(unitQuantity) + Number(dstUnitQuantity);
                    Fleet.changeQuantity(dstitem, total);
                    added = true;
                }
            });
            if (!added) {
                dstFleet.adopt(item);
            }
        });

        fleet.getParent().dispose();

        Fleet.sendRequest({ Type: 'delete', PlanetId: planetId, FleetId: fleetId });
    },

    deleteEmptyFleet: function(fleetId) {
        if (!Message.raiseConfirm("AreYouSureYouWantToDeleteFleet")) {
            return;
        }
        var fleet = $('fleet' + fleetId);
        fleet.getParent().dispose();
        Fleet.sendRequest({ Type: 'deleteEmpty', FleetId: fleetId });
    },

    dropTradeCargo: function(fleetId, cargoId) {
        var cargoElement = $(cargoId);
        cargoElement.getElements(".cargoList").each(function(elem) {
            var isTradeResource = elem.getAttribute('isTradeResource');
            if (isTradeResource == 'true') {
                elem.destroy();
            }
        });
        if (cargoElement.getElements(".cargoList").length == 0) {
            cargoElement.destroy();
        } else {
            $(cargoId).getElements(".dropTradeFleetCargo").each(function(elem) {
                elem.destroy();
            });
        }

        Fleet.sendRequest({ Type: 'dropfleetcargo', FleetId: fleetId });
    }
}

window.addEvent('domready', function(){
    if( $('fleetList') ) {
        Fleet.load();
    }
});
// Market.js
window.addEvent('domready', function(){
    var market = $('marketTable');
    if( market != null) {
        market.getElements('tr>td>input[type=text]').addEvent('keyup', function(event)
        {
            this.value = ClearAlphas(this.value);
            this.getNext('div').lastChild.innerHTML = this.value * this.parentNode.previousSibling.previousSibling.innerHTML;
        });
    }
});

function ClearAlphas(repString) {
    
    var toReturn="";
    
    for(var iter = 0; iter < repString.length; ++iter)
    {
        var num_test=parseFloat(repString[iter]);
        if(!isNaN(num_test))
        {
            toReturn += repString[iter];
        }
    }
    return toReturn;
}

function AHFilter(){
    var hidden = $('searchChange');
    hidden.value = 1;
}
// Ticker.js

var Ticker = {

    data : [],
    
    tickerPanel : null,
    
    elements : [],

    bootstrap : function(args) {
        if( $("tickerPlaceHolder") == null ) {
            return;
        }
        Ticker.tickerPanel = $("ticker");
        log.debug("Bootstrap Ticker...");
        Ticker.sendRequest(true);
        setInterval('Ticker.fetchData();', 750);
    },
    
    fetchData : function() {
        var value = Ticker.data.pop();
        log.debug("Fetching data... " );
        if( value != null ) {
            log.info(value);
            var newElem = new Element("li", {html:value,styles:{opacity:0}});
            newElem.inject(Ticker.tickerPanel, "top");
            var fx = new Fx.Tween(newElem, {property: 'opacity', duration: 500});
            fx.start(1);
            Ticker.elements.push(newElem);
        }
        
        if( Ticker.elements.length > 25 ) {
            var toRemove = Ticker.elements.shift();
            toRemove.dispose();
        }
    },
    
    updateTicker : function() {
        log.debug("Got response: " + (window.tickerData.length-1) + " items");
        for(var i = 1; i < window.tickerData.length; ++i ) {
            Ticker.data.push(window.tickerData[i]);
        }
        setTimeout('Ticker.sendRequest(false);', 1000 * 5);
    },

    sendRequest : function(bootstrap) {
        log.debug("Sending request to Ticker...");
        var url = "Ajax/Utils/Ticker.ashx";
        if( bootstrap ) {
            url += "?Bootstrap=1";
        }
        Utils.ajaxRequest('get', url, $("tickerPlaceHolder"), Ticker.updateTicker);
    }
  
};

window.addEvent('domready', Ticker.bootstrap);

// Advertising.js

var Advertising = {
   index:0,
   bootstrap: function()
   {
        if(null != window.Auction && 1 < window.Auction.length)
        { 
            for( var i = 0; i < 10; ++i ) {
                Advertising.fetchData();
            }
            setInterval('Advertising.fetchData();', 3000);
        }
   },
   
   fetchData: function()
   {
        if(Advertising.index >= window.Auction.length-1)
        {
            Advertising.index=0;
        }
        var obj = window.Auction[++Advertising.index];
        var table = $('ahAd');
        
        var newTr = new Element("tr", {styles:{opacity:0}});
        var parent = table.getElement('tr').getParent();
	    newTr.inject(parent);
	    
	    var newTd = new Element("td", {html:obj.quant});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:"<img class='smallShip' src='"+Utils.resolveImage(obj.name)+"' alt='obj.name' title='obj.name'/>"});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:obj.bid});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:obj.buy});
	    newTd.inject(newTr);
	    
        var fx = new Fx.Tween(newTr, {property: 'opacity', duration: 1000});
        if(parent.getChildren().length > 11)
        {
            parent.getElements('tr:nth-child(2)').dispose();
        }
        fx.start(1);
        
   }
};

window.addEvent('domready', Advertising.bootstrap);

// CustomElements.js
var checkboxHeight = "25";
var radioHeight = "25";
var selectWidth = "190";

/* No need to change anything after this */

var Custom = {
    init: function() {
        var inputs = document.getElementsByTagName("input");
        var textnode;
        var option;
        var active;
        for (a = 0; a < inputs.length; a++) {
            Custom.initInput(inputs[a]);
        }

        inputs = document.getElementsByTagName("select");
        for (a = 0; a < inputs.length; a++) {
            Custom.initSelect(inputs[a]);
        }
    },

    initInput: function(input) {
        if ((input.type == "checkbox" || input.type == "radio") && input.className == "styled") {
            var span = document.createElement("span");
            span.className = input.type;

            if (input.checked == true) {
                if (input.type == "checkbox") {
                    position = "0 -" + (checkboxHeight * 2) + "px";
                    span.style.backgroundPosition = position;
                } else {
                    position = "0 -" + (radioHeight * 2) + "px";
                    span.style.backgroundPosition = position;
                }
            }
            input.parentNode.insertBefore(span[a], input);
            input.onchange = Custom.clear;
            span.onmousedown = Custom.pushed;
            span.onmouseup = Custom.check;
            document.onmouseup = Custom.clear;
        }
    },

    initSelect: function(select) {
        var value;
        if (select.selectedIndex >= 0) {
            value = select.options[select.selectedIndex].innerHTML;
        } else {
            value = "";
        }

        select.className = "styled";
        var span = document.createElement("span");
        span.className = "select";
        span.id = "select" + select.name;
        span.innerHTML = value;
        select.parentNode.insertBefore(span, select);
        select.correctOnChange = select.onchange;
        select.onchange = Custom.choose;

        Custom.initialChoose(select);

        if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1) {
            var location = window.location + '';
            if (location.indexOf('AuctionHouse') > -1) {
                span.style.margin = "0px 0px 0px 0px";
                return;
            }
            if (location.indexOf('AddToAuction') > -1) {
                span.style.margin = "0px 0px 0px 120px";
                return;
            }
            if (location.indexOf('PaymentType.') > -1) {
                span.style.margin = "0px 0px 0px 190px";
                return;
            }
            if (location.indexOf('SearchPlayers.') > -1 || location.indexOf('CreateFriendly.') > -1) {
                span.style.margin = "0px 0px 0px 40px";
                return;
            }
            if (location.indexOf('CreateArena.') > -1) {
                span.style.margin = "0px 0px 0px 170px";
            }
            if (location.indexOf('Team.') > -1) {
                span.style.margin = "0px 0px 0px 40px";
            }
            if (location.indexOf('PaymentType.aspx?Type=Sms') > -1) {
                span.style.margin = "0px 0px 0px 120px";
                return;
            }
            
        }
    },

    pushed: function() {
        element = this.nextSibling;
        if (element.checked == true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 -" + checkboxHeight * 3 + "px";
        } else if (element.checked == true && element.type == "radio") {
            this.style.backgroundPosition = "0 -" + radioHeight * 3 + "px";
        } else if (element.checked != true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 -" + checkboxHeight + "px";
        } else {
            this.style.backgroundPosition = "0 -" + radioHeight + "px";
        }
    },

    check: function() {
        element = this.nextSibling;
        if (element.checked == true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 0";
            element.checked = false;
        } else {
            if (element.type == "checkbox") {
                this.style.backgroundPosition = "0 -" + checkboxHeight * 2 + "px";
            } else {
                this.style.backgroundPosition = "0 -" + radioHeight * 2 + "px";
                group = this.nextSibling.name;
                inputs = document.getElementsByTagName("input");
                for (a = 0; a < inputs.length; a++) {
                    if (inputs[a].name == group && inputs[a] != this.nextSibling) {
                        inputs[a].previousSibling.style.backgroundPosition = "0 0";
                    }
                }
            }
            element.checked = true;
        }
    },
    clear: function() {
        inputs = document.getElementsByTagName("input");
        for (var b = 0; b < inputs.length; b++) {
            if (inputs[b].type == "checkbox" && inputs[b].checked == true && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 -" + checkboxHeight * 2 + "px";
            } else if (inputs[b].type == "checkbox" && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 0";
            } else if (inputs[b].type == "radio" && inputs[b].checked == true && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 -" + radioHeight * 2 + "px";
            } else if (inputs[b].type == "radio" && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 0";
            }
        }
    },

    choose: function() {
        if (this.correctOnChange != null) {
            this.correctOnChange();
        }

        var o = this.options[this.selectedIndex];
        document.getElementById("select" + this.name).innerHTML = o.innerHTML;
    },

    initialChoose: function(elem) {
        if (elem.selectedIndex >= 0) {
            var o = elem.options[elem.selectedIndex];
            document.getElementById("select" + elem.name).innerHTML = o.innerHTML;
        } else {
            document.getElementById("select" + elem.name).innerHTML = "";
        }
    }
}

window.addEvent('domready', function() {
	Custom.init();
});
// Prices.js
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
// Quests.js

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


// FleetCargo.js
var FleetCargo = {
    fleetCargos: null,
    quantityInput : null,
    currentClone : null,
    currentItem : null,
    changeLog : "",
        
    load : function() {
        FleetCargo.fleetCargos = $$(".fleetCargo");
        
	    if( FleetCargo.fleetCargos.length > 0  ) {
            FleetCargo.fleetCargos.each( function(item){
                FleetCargo.setCargoDrag(item);
            });
            
            $('transferCargoQuantity').addEvent('click',FleetCargo.transferQuantity);
            $('cancelCargoTransfer').addEvent('click',FleetCargo.clearTransferInfo);
            FleetCargo.quantityInput = $('quantityCargo');
        }
    },
   
    setCargoDrag : function(parent) {
        var element = parent.getPrevious('div');
        parent.getElements('div').each(function(item){
            if(item.hasClass('cargoList')){
                item.addEvent('mousedown', function(e) {
                    if(element == null) {
                        return;
                    }
                    
                    if( Fleet.isInBattle(element) ){
                        RaiseError.fleetInBattle();
                        return;
                    }
                    
                    if( Fleet.isMoving(element) ){
                        RaiseError.fleetIsMoving();
                        return;
                    }
                    FleetCargo.resourceClick(this, parent, e );
                });
            }
        });
    },
    
    resourceClick : function(item, parent, e) {
        var clone = Fleet.getClone(item);
		
		var drag = clone.makeDraggable({
			droppables: FleetCargo.fleetCargos,
            onDrop: function(element, droppable){
                if(droppable == null) {
                    clone.dispose();
                    return;
                }
                if( FleetCargo.isInBattle(droppable) ) {
                    RaiseError.fleetInBattle(); 
                    clone.dispose();
                    droppable.removeClass('fleetCargoOver');
                    return;
                }
                
                if( FleetCargo.isMoving(droppable) ) {
                    RaiseError.fleetIsMoving(); 
                    clone.dispose();
                    droppable.removeClass('fleetCargoOver');
                    return;
                }
                            
                var p = item.getParent();
                                
                if (droppable && droppable != p && FleetCargo.isFleetAround(p,droppable) ) {
                    FleetCargo.dropCargoEvent(clone, item, droppable);
                }else{
                    clone.dispose();
                }
            },
            onEnter: function(element, droppable){
                var p = item.getParent();
                if( droppable != p && FleetCargo.isFleetAround(p,droppable) ) { 
                    droppable.addClass('fleetCargoOver');
                }
            },
            onLeave: function(element, droppable){
                if( droppable != parent ) { 
                    droppable.removeClass('fleetCargoOver');
                }
            }
		});
		
		drag.start(e);
    },
    
    
    isInBattle : function(element){
        return Fleet.isInBattle(element.getPrevious());
    },
    
    isMoving : function(element){
        return Fleet.isMoving(element.getPrevious());
    },
    
    isFleetAround : function(src, dst){
        return Fleet.isFleetAround(src.getPrevious(),dst.getPrevious());
    },
    
    clearTransferInfo : function() {
        var menu = $('quantityCargoSelector');
        menu.addClass('hidden');
        
        FleetCargo.currentClone.dispose(); 
        FleetCargo.currentDestiny.removeClass('fleetCargoOver');
        FleetCargo.currentClone = null;
        FleetCargo.currentItem = null;
        FleetCargo.currentDestiny = null;
    },
    
    dropCargoEvent : function( clone, item, destiny ) {
        if( FleetCargo.currentClone != null ) {
            FleetCargo.clearTransferInfo();
        }
    
        var menu = $('quantityCargoSelector');
        Menu.positionByElement(menu,clone,{x: 30, y: 30});
        menu.removeClass('hidden');
        FleetCargo.quantityInput.focus();
        FleetCargo.quantityInput.value = clone.getChildren('span')[0].innerHTML;
        FleetCargo.currentClone = clone;
        FleetCargo.currentItem = item;
        FleetCargo.currentDestiny = destiny;
    },
    
    transferQuantity : function() {
        var resourceName = FleetCargo.currentClone.getFirst().getAttribute("resourceName");
        var quantityToTransfer = Number(FleetCargo.quantityInput.value);
        var originalQuantity = Number(FleetCargo.getQuantity(FleetCargo.currentClone));
        
        if( quantityToTransfer > 0 && quantityToTransfer <= originalQuantity  ) {
            var added = FleetCargo.addQuantity(resourceName,quantityToTransfer);
            if(added){
                if( quantityToTransfer == originalQuantity ) {
                    FleetCargo.currentItem.destroy(); 
                }else{
                    var newQuant = Number(originalQuantity) - Number(quantityToTransfer);
                    FleetCargo.changeQuantity(FleetCargo.currentItem, newQuant);
                }
            }
            FleetCargo.clearTransferInfo();
        }else{
            RaiseError.invalidQuantity();
        }
    },
    
    getQuantity : function(element){
        return FleetCargo.getQuantitySpan(element).innerHTML;
    },
    
    getQuantitySpan : function(element){
        return element.getChildren('span')[0];
    },
    
    addQuantity : function(resourceName,quantity) {
        var added = false;
        
        var elements = FleetCargo.currentDestiny.getElements('.cargoList');
        
        elements.each(function(item){
            if( added ) {
                return;
            }
            var name = item.getFirst().getAttribute("resourcename");     
            if( name == resourceName ) {
                FleetCargo.registerChange(resourceName,quantity);
                var resourceQuantity = FleetCargo.getQuantity(item)
                var total = Number(resourceQuantity)+Number(quantity);
                FleetCargo.changeQuantity(item, total);
                added = true;
            }
        });
        if(added){
            return true;
        }
        
        var clone = FleetCargo.currentItem.clone();
        clone.addEvent('mousedown', function(e) {
            FleetCargo.resourceClick(this, FleetCargo.currentDestiny, e );
        });
        FleetCargo.currentDestiny.adopt(clone);
        FleetCargo.changeQuantity(clone, quantity);
        FleetCargo.registerChange(resourceName,quantity);
        return true;
    },
    
    changeQuantity: function(elem, quantity) {
        var img = elem.getFirst();
        img.setAttribute("quantity", quantity);
        var span = FleetCargo.getQuantitySpan(elem);
        span.empty();
        span.appendText(quantity);
    },
    
    registerChange : function(resourceName, quantity) {
        var srcId = FleetCargo.currentItem.getParent().getPrevious().getAttribute('fleetId');
        var dstId = FleetCargo.currentDestiny.getPrevious().getAttribute('fleetId');
        FleetCargo.changeLog += srcId + "-" + dstId + "-" + resourceName + "-" + quantity + ";";
        $('saveChanges').disabled = false;
    }
}
// Forum.js

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
