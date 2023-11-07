/**
	url:页面路径
	name：新窗口的名字
	width：新窗口的宽度
	height：新窗口的高度
	haveToolbar：是否显示工具条
	modal：是否是模态
	arguments：给新窗口的传递的参数
*/
function showPage(url, name, width, height, haveToolBar, modal, arguments) {
	if (name == null) name = "_blank";
	if (width == null) width = 800;
	if (height == null) height = 600;
	if (haveToolBar == null) haveToolBar = false;
	if (modal == null) modal = false;
	
	var isIe = $.browser.msie;
	var parameters = "width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
	
	if (isIe) {
		if (modal) {
			var parameters = "dialogWidth=" + width + "px;dialogHeight=" + height + "px;dialogLeft=" + Math.round((screen.width - width) / 2) + "px;dialogTop=" + Math.round((screen.height - height) / 2) + "px;";
			return window.showModalDialog(url,arguments, parameters);
		} else {
			var parameters = "width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
			return window.open(url, name, parameters);
		}
	} else {
		var parameters = "width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
		return window.open(url, name, parameters);
	}
}
