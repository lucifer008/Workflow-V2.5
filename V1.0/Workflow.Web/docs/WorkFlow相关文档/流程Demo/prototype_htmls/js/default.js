/**
	url:ҳ��·��
	name���´��ڵ�����
	width���´��ڵĿ��
	height���´��ڵĸ߶�
	haveToolbar���Ƿ���ʾ������
	modal���Ƿ���ģ̬
	arguments�����´��ڵĴ��ݵĲ���
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
