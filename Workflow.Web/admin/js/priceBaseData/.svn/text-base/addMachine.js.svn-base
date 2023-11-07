// JScript 文件
/*
//名    称:addMachine
//功能概要:机器操作JS
//作    者:张晓林
//创建时间:2009年5月4日9:19:23
//修正履历：
//修正时间:
*/

//添加机器数据验证
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
    if("-1"==$("#sltMachinType").attr("value"))
    {
        alert("请选择机器类型!");
        $("#sltMachinType").focus();
        return false;
    }
}


//编辑机器
function edmitMachine(o)
{
    var machineId=$("input[@name=machineId]",$(o).parent()).val();
    var machineTypeId=$("input[@name=machineTypeId]",$(o).parent()).val();
    var machineNo=$($(o).parent().parent()).find(".mNo").html();
    var machineName=$($(o).parent().parent()).find(".mName").html();
    //var machineTypeName=$($($(o).parent().parent()).find(".mMachineTypeName").html()).innerHTML;
    var url="addMachine.aspx?MachineId="+machineId+"&MachineTypeId="+machineTypeId+"&MachineNo="+escape(machineNo)+"&MachineName="+escape(machineName)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        $("#form1").submit();
    }
}

//删除机器
function deleteMachine(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
           var machineId=$("input[@name=machineId]",$(o).parent()).val();
           $("#hidMachineId").val(machineId);
           $("#hiddTag").val("delete");
           $("#form1").submit(); 
    }
}

//获取机器类型详情
function machineDetail(o)
{
    var machineTypeId=$("input[@name=machineTypeId]",$(o).parent().next()).val();
    var url="machineTypeDetail.aspx?MachineTypeId="+machineTypeId;
    yes=showPage(url,null,800,600,false,true,false);
}

loadEdmitData=function()
{
    if(""!=$("#hidMachineId").val())
    {
        $("#sltMachinType").attr("value",machineTypeId);
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
