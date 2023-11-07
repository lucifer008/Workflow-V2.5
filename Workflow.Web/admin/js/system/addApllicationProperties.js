// JScript 文件
/*
//名    称：addApllicationProperties
//功能概要: 应用程序参数维护JS
//作    者: 张晓林
//创建时间: 2009年6月8日9:31:16
//修正履历:
//修正时间:
*/

//初始化数据验证
initCheck=function(){
    if(!confirm("确认初始化吗?")){
        return false;
    }
}

//数据操作验证

var startDateTimeProId="WORK_START_TIME";
var endDateTimeProId="WORK_END_TIME";
checkProcess=function(o){
    if(""==$("#txtPropertyId").val()){
        alert("参数Id不能为空!");
        $("#txtPropertyId").focus();
        return false;
    }
    if(""==$("#txtPropertyValue").val() && ""==$("#propertyValue").val()){
        alert("参数值不能为空!");
        $("#txtPropertyValue").focus();
        return false;
    }
    else{
        var strPpId=$("#ppIdStr").val();
        if(startDateTimeProId!=strPpId && endDateTimeProId!=strPpId){
            if(""!=$("#txtPropertyValue").val()){
                if(!isNumber($("#txtPropertyValue").val())){
                    alert("输入格式有误!请重新输入!");
                    $("#txtPropertyValue").focus();
                    $("#txtPropertyValue").select();
                    return false;
                }
            }
        }
    }
//    if(!isNumber($("#txtPropertyValue").val()))
//    {
//        alert("参数值不能为非数字类型!");
//        $("#txtPropertyValue").focus();
//        return false;
//    }
}

//编辑应用程序参数
edmitApplicationProperty=function(o){
    var applicationPropertyId=$("input[@name=applicationPropertyId]",$(o).parent()).val();
    var propertyId=$($(o).parent().parent()).find(".propertyId").html();
    var propertyValue=$("div[id=divCol]",$(o).parent().parent().html());
    var tag=$("input[@name=propertyId]",$(o).parent()).val();
    if("Matureness_Color"==tag || "Overdue_Color"==tag){ 
        propertyValue=$("input[@name=edmPropertyValue ]",$(o).parent()).val();
    }
    else{ 
        propertyValue=$($(o).parent().parent()).find(".propertyValue").html();
    }
    var url="addApllicationProperties.aspx?ApplictionPropertyId="+applicationPropertyId+"&PropertyId="+escape(propertyId);
        url+="&PropertyValue="+escape(propertyValue)+"&tag="+tag+"&action=edmit";
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes){
        window.navigate("addApllicationProperties.aspx");
    }
}

//删除应用程序参数 
deleteApplicationProperty=function(o){
    if(!confirm("确认删除吗?")){
        return false;
    }
    var applicationPropertyId=$("input[@name=applicationPropertyId]",$(o).parent()).val();
    $("#hiddTag").val("delete");
    $("#hidId").val(applicationPropertyId);
    $("#form1").submit();
}

//回车提交,Esc键关闭窗体
document.onkeydown=function(){
　　var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;		
	if (evt.keyCode==27){
		window.close();
	}
	if(evt.keyCode == 13){
   	    $("#btnSave").click();
       return false;   
	}
}

//功能: 控制只编辑 应用程序参数,隐藏添加应用程序参数功能
//作者: 张晓林
//日期: 2010年2月25日9:29:19
$(document).ready(
function(){
    var edId=$("#hidId").val();
    if(isNaN(edId)) edId=0;
    if(0!=edId){
        $("#tr2").show();
        $("#tr3").show();
    }
    else{
        $("#tr2").hide();
        $("#tr3").hide();
    }   
});

//功能: 选择颜色
//作者: 张晓林
//日期: 2010年5月20日11:08:58
function selectColorValue(){
    var url="SelectColorOptions.aspx?Id=1"
    showPage(url,null,700,700,false,false,false);
}

function callBackBindColor(color){
    //$("#txtPropertyValue").val(color.RGB);
    $("#txtPropertyValue").css("background-color",color.RGB);
    $("#propertyValue").val(color.RGB);
}