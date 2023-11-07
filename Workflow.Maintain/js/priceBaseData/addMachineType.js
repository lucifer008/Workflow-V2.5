// JScript 文件
/*
//名    称: addMachine
//功能概要: 机器类型JS
//作    者: 张晓林
//创建时间: 2009年5月4日9:19:23
//修正履历：
//修正时间:
*/

//添加机器类型数据验证
function checkProcess()
{
    if(""==$("#txtMachineNo").val())
    {
        alert("编号不能为空!");
        $("#txtMachineNo").focus();
        return false;
    }
    if(""==$("#txtMachineName").val())
    {
        alert("名称不能为空!");
        $("#txtMachineName").focus();
        return false;    
    }
    if("-1"==$("#sltIsNotInWatch").attr("value"))
    {
        alert("请选择是否抄表!");
        $("#sltIsNotInWatch").focus();
        return false;
    }
}

//编辑机器类型
function edmitMachineType(o)
{
    var machineTypeId=$("input[@name=machineTypeId]",$(o).parent()).val();
    var machineNo=$($(o).parent().parent()).find(".mNo").html();
    var machineName=$($(o).parent().parent()).find(".mName").html();
    var machineIsNoInW=$($(o).parent().parent()).find(".mMachinename").html();
    var url="addMachineType.aspx?MachineTypeId="+machineTypeId+"&MachineNo="+escape(machineNo)+"&MachineName="+escape(machineName)+"&MachineIsNoInW="+escape(machineIsNoInW)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate('addMachineType.aspx');
       //$("#form1").submit();
    }
}

//删除机器类型
var machineTypeId=0;
function deleteMachineType(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         machineTypeId=$("input[@name=machineTypeId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=MachineType&BusinessTypeId='+machineTypeId;
         $.getJSON(url ,{a:'1'},window.CheckIsUseCallBack);
    }
}
function CheckIsUseCallBack(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    if("0"==json)
    {
           $("#hidMachineTypeId").val(machineTypeId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该机器类型正在使用,不能删除!");
        return false;
    } 
}
//添加机器
function addMachine()
{
    var url="addMachine.aspx?Tag=1";
    var yes=showPage(url,null,900,800,false,false,false);
    if(yes)
    {
        $("#form1").submit(); 
    }
}

document.onkeydown=function()
{
　　var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;		
	if (evt.keyCode==27)	
	{
		window.close();
	}
	if(evt.keyCode == 13)
	{
   	    $("#btnSave").click();
       return false;   
	}
}
