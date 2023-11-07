var MESSAGE_EMPTY = "请务必输入内容";
var MESSAGE_CHOICE = "请务必选择内容";
var MESSAGE_NUMERAL = "数字的格式不正确";
var MESSAGE_EMAIL = "邮箱的格式不正确";
var MESSAGE_IDCARD = "请依15或18位数据的身份证号";
var MESSAGE_AMOUNT = "请输入正确的金额";
var MESSAGE_LESS_COSTPRICE = "价格不能低于成本价格";
var MESSAGE_BUSINESS_TYPE_EMPTY = "请选择业务类型";
var MESSAGE_PRICE_CONCESSION_ALL_EMPTY="价格和折扣至少要设置一个,请确认";
var MESSAGE_PRICE_CONCESSION_ALL_NOT_EMPTY="价格和折扣不能同时设置,请确认";
var MESSAGE_WRONG_CONCESSION="无效的折扣信息";
var MESSAGE_PASSWORD = "两次输入的密码不相等";

/*
    url:页面路径
	name：新窗口的名字
	width：新窗口的宽度
	height：新窗口的高度
	haveToolbar：是否显示工具条
	modal：是否是模态
	arguments：给新窗口的传递的参数
*/
function showPage(url, name, width, height, haveToolBar, modal, arguments,haveStatusBar) {
	if (name == null) name = "_blank";
	if (width == null) width = 800;
	if (height == null) height = 600;
	if (haveToolBar == null) haveToolBar = false;
	if (modal == null) modal = false;
	if(haveStatusBar==null || haveStatusBar==false) 
	{
	    haveStatusBar="no";
	}
	else
	{
	    haveStatusBar='yes';
	}
	
	var isIe = $.browser.msie;
	//var parameters = "width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
	var parameters=arguments;
	try
	{     
	    if (isIe) {
		    if (modal) {
		        //var parameters = "";
	            parameters = "dialogWidth=" + width + "px;dialogHeight=" + height + "px;dialogLeft=" + Math.round((screen.width - width) / 2) + "px;dialogTop=" + Math.round((screen.height - height) / 2) + "px;"+arguments+";status:"+haveStatusBar ;    
    	    
		        if(null==arguments || ""==arguments)
		        {
		            parameters = "dialogWidth=" + width + "px;dialogHeight=" + height + "px;dialogLeft=" + Math.round((screen.width - width) / 2) + "px;dialogTop=" + Math.round((screen.height - height) / 2) + "px;"+"status:"+haveStatusBar ;    
		        }
			    return window.showModalDialog(url,arguments, parameters);
		    } else {
		        //var parameters = "";
		        if(null==arguments || ""==arguments)
		        {
    			    parameters = "scrollbars =yes,width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
		        }
			    return window.open(url, name, parameters);
		    }
	    } else {
		        //var parameters = "";
		        if(null==arguments || ""==arguments)
		        {
        		    parameters = "scrollbars =yes,width=" + width + "px,height=" + height + "px,left=" + Math.round((screen.width - width) / 2) + "px,top=" + Math.round((screen.height - height) / 2) + "px";
		        }
    		    
		    return window.open(url, name, parameters);
	    }
	}
	catch(e)
	{
	    alert(e);
	}
}

function getJSON(jsonStringValue)
{
    return eval("eval(" + jsonStringValue + ")");
}

function preventSelectDisabled(event) {
	if (event == null) event = window.event;
    oSelect = event.srcElement;
	var isOptionDisabled = oSelect.options[oSelect.selectedIndex].disabled;    
	if(isOptionDisabled) {
		oSelect.selectedIndex = oSelect.defaultSelectedIndex;
		return false;
	} else {
		oSelect.defaultSelectedIndex = oSelect.selectedIndex;
		return true;
	}
}

function disabledSelectOption(id) {
	var trade = $("select[@id$=" + id +"]");
    var options = $("option", trade);
    $.each(options, function(i, obj) {
		var option = $(obj);
		if (option.text().indexOf("　") != 0 && option.val() > "0") {
			option.attr("disabled", "true");
			option.css("font-weight", "bold");
		}
    });
    trade.change(preventSelectDisabled);
}

$(function() {
	$.each($("form"), function(i, form) {
		$(form).submit(trimInput);
	});
});

function trimInput() {
    var form = $(this);
	$.each($("input:text", form), function(i, input) {
	    input = $(input);
		input.val($.trim(input.val()));
	});
	
	$.each($("texterea", form), function(i, input) {
	    input = $(input);
		input.val($.trim(input.val()));
	});
}