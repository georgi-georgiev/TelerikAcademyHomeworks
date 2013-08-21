function doSomething() {
	'use strict';
	
	var navigatorName = navigator.appName;
	var addScroll = false;
	
	if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
		addScroll = true;
	}
	
	var positionX = 0;
	var positionY = 0;

	document.onmousemove = mouseMove;
	
	if (navigatorName === 'Netscape') {
		document.captureEvents(Event.MOUSEMOVE)
	}

	function mouseMove(evn) {
		if (navigatorName === 'Netscape') {
			positionX = evn.pageX - 5;
			positionY = evn.pageY;
		} else {
			positionX = event.x - 5;
			positionY = event.y;
		}
		if (navigatorName === 'Netscape') {
			if (document.getElementByID["toolTip"].visibility === 'show') {
				popTip();
			}
		} else {
			if (document.getElementByID["toolTip"].style.visibility === 'visible') {
				popTip();
			}
		}
	}

	function popTip() {
		if (navigatorName === 'Netscape') {
			theLayer = document.getElementByID["toolTip"];
			if ((positionX + 120) > window.innerWidth) {
				positionX = window.innerWidth - 150;
			}
			theLayer.left = positionX + 10;
			theLayer.top = positionY + 15;
			theLayer.visibility = 'show';
		} else {
			theLayer = document.getElementByID["toolTip"];
			if (theLayer) {
				positionX = event.x - 5;
				positionY = event.y;
				if (addScroll) {
					positionX = positionX + document.body.scrollLeft;
					positionY = positionY + document.body.scrollTop;
				}
				if ((positionX + 120) > document.body.clientWidth) {
					positionX = positionX - 150;
				}
				theLayer.style.pixelLeft = positionX + 10;
				theLayer.style.pixelTop = positionY + 15;
				theLayer.style.visibility = 'visible';
			}
		}
	}

	function hideTip() {
		//delete args
		if (navigatorName === 'Netscape') {
			document.getElementByID["toolTip"].visibility = 'hide';
		} else {
			document.getElementByID["toolTip"].style.visibility = 'hidden';
		}
	}

	function hideMenuOne() {
		if (navigatorName === 'Netscape') {
			document.getElementByID["menuOne"].visibility = 'hide';
		} else {
			document.getElementByID["menuOne"].style.visibility = 'hidden';
		}
	}

	function showMenuOne() {
		if (navigatorName === 'Netscape') {
			theLayer = document.getElementByID["menuOne"];
			theLayer.visibility = 'show';
		} else {
			theLayer = document.getElementByID["menuOne"];
			theLayer.style.visibility = 'visible';
		}
	}

	function hideMenuTwo() {
		if (navigatorName === 'Netscape') {
			document.getElementByID["menuTwo"].visibility = 'hide';
		} else {
			document.getElementByID["menuTwo"].style.visibility = 'hidden';
		}
	}

	function showMenuTwo() {
		if (navigatorName === 'Netscape') {
			theLayer = document.getElementByID["menuTwo"];
			theLayer.visibility = 'show';
		} else {
			theLayer = document.getElementByID["menuTwo"];
			theLayer.style.visibility = 'visible';
		}
	}
}