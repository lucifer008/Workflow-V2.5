   /*
///文 件 名：employee.js
//功能描述：雇员管理Js		 
///创建时间：2008-11-5
///创 建 人: 张晓林
///修改时间：
///修改描述：
*/

//编辑雇员
function EdmitEmployeeInfo(employeeId,positionId,employeeName)
{  

  var url="NewEmployee.aspx?EmployeeId="+escape(employeeId)+"&PositionId="+escape(positionId)+"&EmployeeName="+escape(employeeName);
   var yes=showPage(url,"curWindow",890,566,false,true,false);
   if(yes=='yes')
   {
        $("#hiddTag").val("Edmit");
        $("#form1").submit();
   }
}

//删除雇员验证
var emId=0,posId=0;
function DeleteEmployeeInfo(employeeId)
{
    var yes=confirm("确认删除?");
    if(yes)
    {
        var url="../../ajax/AjaxEngine.aspx?EmployeeId="+employeeId+"&Tag=2";
         $.getJSON(url,{a:'23'},processJson);
           emId=employeeId;
        //posId=positionId;
    }
}
function processJson(json)
{
    if(null==json) return;
    else if("0"!=json)
    {
       alert("该雇员正在使用!不能删除!");
       return; 
    }
    $("#hiddEmployeeId").val(emId);
    //$("#hiddPositionId").val(posId);
    $("#hiddTag").val("T");
    $("#form1").submit();
}

function SelectEmployeeByEmployeeId()
{   
    $("#hiddTag").val("FF");
    $("#form1").submit();
 }
 
///
///添加雇员数据验证
///
///
function EmployeeDataCheck()
{
	if(""==$("#txtEmployName")[0].value)
	{
		alert("雇员名称名称不能为空!");
		$("#txtEmployName").select();
		$("#txtEmployName").focus();
		return false;
	}
	
	var PositionLength=$("input:checkbox[@name=cbPosition]").length;//document.form1.cbPosition.length;
	var position=$("input:checkbox[@name=cbPosition]");
	var Count=0;
	for(var i=0;i<PositionLength;i++)
	{
		if(position[i].checked)//document.form1.cbPosition[i].checked)
		{
			Count++;
		}
	}
	if(Count==0)
	{
		alert("至少选择一个所属岗位!");
		return false;
	}
	return true;
}

document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    var evt=window.event||arguments[0];
    var element=evt.srcElement||src.target;
    if(evt.keyCode==27)
    {
        window.close();
    }
    else if(13==evt.keyCode)
    {
        $("#btn").click();
        return false;
    }
}

//点击CheckBox文本选择CheckBox
 function SelectedCheckBox(obj)
 {
    if(!obj.disabled)
    {
        obj.checked=!obj.checked;
    }
 }
 
 //绑定编辑数据
function loadEmployeeEdmitInfo()
{      
    var positionLength=$("input:checkbox[@name=cbPosition]").length;//document.form1.cbPosition.length;
    var position=$("input:checkbox[@name=cbPosition]");//document.form1.cbPosition;
    if(0!=employeeId)
    {
       //隐藏关闭按钮
	    //document.all["btnCancel"].style.display="";
	    $("#btnCancel").show();
        for(var i=0;i<positionLength;i++)
        {  
           for(var index=0;index<positionId.length;index++)
           {
              if(position[i].value==positionId[index])
              {
                  position[i].checked=true;
              }
          } 
        }        
       $("#txtEmployName").val(employeeNameEdmit);
       $("#hiddEmployeeId").val(employeeId);  
    }
    //当前用户为店长时，不能更改比自己更高的职位
   if(master==currentUserPosition)
   {
        for(var index=0;index<positionLength;index++)
        {
             if(manager==position[index].value)
             {
                 position[index].disabled="true";//所有的职位为店长都不可用
             }
        } 
   } 

}

///
/// 名    称: checkEmployeeNameIsExist
/// 功能概要: 检查添加的雇员名称是否已经存在
/// 作    者: 张晓林
/// 创建时间: 2009年9月25日11:17:36
/// 修正履历:
/// 修正时间:
///  
function checkEmployeeNameIsExist()
{
    if(""!=$("#txtEmployName").val())
    {
         var url="../../ajax/AjaxEngine.aspx?EmployeeName="+escape($("#txtEmployName").val())+"&Tag=7";
         $.getJSON(url,{a:'23'},callBackCheckEmName);
    }
}
function callBackCheckEmName(json)
{
    if(null==json) return;
    else if("0"!=json)
    {
       alert("该雇员已经存在!");
       $("#txtEmployName").val("");
       $("#txtEmployName").focus();
       return; 
    }
}