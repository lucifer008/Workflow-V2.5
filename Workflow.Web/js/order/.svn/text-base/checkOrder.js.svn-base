// JScript 文件

//功能:核对订单
//作者:张晓林
//日期:2010年1月8日10:36:44
function checkData(){
    $("#btnCheck").attr("disabled",true);
    $("#form1").submit();
}

$(document).ready(function() {
      if(isPrint=='True')
      {
        opener.rVal='true';
        window.close();
      } 

});


//功能:控制Esc建退出弹出窗体，回车提交
//作者:张晓林
//日期:2010年1月20日15:38:32
document.onkeydown=function(event_e)
{
    //Esc建退出
	if (window.event) event_e=window.event;
	var int_keycode=event_e.charCode || event_e.keyCode;
	if (int_keycode==27)	
	{
		window.close();
	}
	//回车提交
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
    if(13==evt.keyCode)
    {
        $("#btnCheck").click();
        return false;
    }
}
