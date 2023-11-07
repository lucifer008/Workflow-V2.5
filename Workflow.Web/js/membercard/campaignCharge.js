// JScript 文件
// 名    称: campaignCharge.js
// 功能概要: 会员充值 Js
// 作    者: 张晓林
// 创建时间: 2009年2月11日
// 修正履历: 
// 修正时间:


var dataMembercardDetial;
var data;
$(document).ready(
    function()
    {
        $("#btnSearch").click(searchDataValidator);
        $("#txtMemberCardNo").change(changeMembercard);
        dataMembercardDetial=$("#tr1").html();
        $("#tr1").html("");
    }
);

/*
    名    称：searchDataValidator
    功能概要：检索数据验证，当存在该卡号时，加载该会员卡信息
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
function searchDataValidator()
{
    if($("#txtMemberCardNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":会员卡号");
        $("#txtMemberCardNo").focus();
        return false;
    }
    if(""!=$("#txtMemberCardNo").val())
    {
        var memberCardNo= $("#txtMemberCardNo").val();
        var url="../ajax/AjaxEngine.aspx?MemberCardNo="+escape(memberCardNo);
        $.getJSON(url,{a:'27'},callBackLoadMemberCardDetail);
    }
}
function callBackLoadMemberCardDetail(json)
{
    if(null==json || false==json.success)
    {
        alert("没有该会员卡!");
        $("#txtMemberCardNo").select();
       return;
    }
    else 
    {
       data=json
    }
    $("#tr1").html(dataMembercardDetial);
    $("#membercardlevel").html(data.Name);
    $("#customername").html(data.CustomerName);
    $("#hiddMemberCardId").val(data.Id);
}

function changeMembercard()
{
    if(""==$("#txtMemberCardNo").val())
    {
        if(""!=$("#tr1").html())
        {
           $("#tr1").html("");
        }   
    }
}

/*
    名    称：insertDataValidator
    功能概要：充值数据验证
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
function  insertDataValidator()
{
    if($("#sltCampaign").selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":优惠活动");
        $("#sltCampaign").focus();
        return false;
    }       
    
    if($("#txtChargeSum").val() == "")
    {
        alert(MESSAGE_EMPTY+":充值金额");
        $("#txtChargeSum").focus();
        return false;
    }
    
    if($("#txtJoinDate").val() == "")
    {
        alert(MESSAGE_CHOICE+":开始时间")
        $("#txtJionDate").focus();
        return false;
    }
    
    if($("#txtChargeAmount").val()!=$("#txtChargeSum").val())
    {
		alert("需冲值金额必须和已冲值金额一致!");
		$("#txtChargeSum").focus();
        return false;
    }
    
   return true; 
}
/*
	名    称：getConcessionByCamId
	功能概要：根据每次改变活动Id，获取该活动下的所有优惠方案信息，并将它加载到sltConcession上
	作    者: 张晓林
	创建时间: 2009年3月19日16:38:26   
	修 改 人:	陈汝胤
	修正时间:	2009.5.13
*/
function getConcessionByCamId()
{
    var sltCampaign=$("#sltCampaign")[0];
    if(sltCampaign.value=="-1")
		return;
    var url="../ajax/AjaxEngine.aspx?id="+escape(sltCampaign.value);
    $.getJSON(url,{a:'11'},callBackAllConcession);   
}
var concessionArr=null;
function  callBackAllConcession(data)
{
    if(null==data || false==data.success)
		return;
    var selectedConcession=$("select[@name=sltConcession]")[0];
    concessionArr=new Array();
    var strOption="";
    for(var i=0;i<data.ConcessionList.length;i++)
    {
		var concessionObj=new Object();
		concessionObj.concession=1;
		concessionObj.id=data.ConcessionList[i].Id;
		concessionObj.index=i;
		concessionObj.ChargeAmount=data.ConcessionList[i].ChargeAmount;
		concessionObj.PaperCount=data.ConcessionList[i].PaperCount;
		concessionObj.ActivityPrice=data.ConcessionList[i].ActivityPrice;
		concessionArr.push(concessionObj);
        strOption+="<option value='"+concessionObj.index+"'>"+data.ConcessionList[i].Name+"</option>";
    }
    for(var i=0;i<data.DiscountConcessionList.length;i++)
    {
		var concessionObj=new Object();
		concessionObj.concession=2;
		concessionObj.id=data.DiscountConcessionList[i].Id;
		concessionObj.index=i+data.ConcessionList.length;
		concessionObj.ChargeAmount=data.DiscountConcessionList[i].ChargeAmount;
		concessionArr.push(concessionObj);
		strOption+="<option value='"+concessionObj.index+"'>"+data.DiscountConcessionList[i].Name+"</option>";
    }
    $(selectedConcession).html(strOption);
    getConcessionInfo(0);
}

/*
    名    称：getConcessionInfo
    功能概要：根据每次改变优惠方案Id，获取该优惠方案信息
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历: 陈汝胤
    修正时间: 2009.5.13
    修改描述: 修改新的需求
*/
function getConcessionInfo(index){

	if(concessionArr.length>0){
		$("#txtChargeAmount").val(concessionArr[index].ChargeAmount);
		$("#hidCampaignId").val(concessionArr[index].id);
		$("#hidCampaignType").val(concessionArr[index].concession);
		$("#hidPaperCount").val(concessionArr[index].PaperCount);
		$("#hidActivityPrice").val(concessionArr[index].ActivityPrice);
	}
}

var data1;
function callBackConcession(json)
{
    if(null==json || false==json.success)
    {
       return;
    }
    else 
    {
       data1=json
    }
    var concession=data1.Concession;
    $("#hiddChargeCount").attr("value", concession.ChargeAmount)//优惠方案充值金额
    $("#hiddUnitPrice").val(concession.UnitPrice);//优惠方案优惠价格
    $("#hiddPresentCount").val(concession.PaperCount);//赠送印章数
}

/*
    名    称：compareSum
    功能概要：根据输入的金额验证金额必须大于等于活动金额
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
function compareSum()
{
    if(""!=$("#txtChargeSum").val())
    {
        if(1>parseInt($("#txtChargeSum").val())/parseInt($("#hiddChargeCount").val()))
        {
            alert("充值金额必须大于等于优惠充值金额:"+$("#hiddChargeCount").val());
            $("#txtChargeSum").attr("value", "");
            $("#txtChargeSum").focus();
            return false;                
        }
    }
    return true;
}

/*
    名    称：onkeydown
    功能概要：控制当光标在会员卡号输入框上(txtMemberCardNo),敲回车后提交检索按钮事件,否则提交充值按钮(btnInsert)事件
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
document.onkeydown=function(event_e)
{
	event_e=window.event || arguments[0];
	var element=event_e.srcElement || event_e.target;
    if((13==event_e.keyCode) && ("txtMemberCardNo"==element.id))
    {
        $("#btnSearch").click();
        return false;		 
    }
    else if(event_e.keyCode == 13)
    {
        $("#btnInsert").click();
        return false;
    }
}