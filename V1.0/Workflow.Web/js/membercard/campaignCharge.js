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
    
   return true; 
}

/*
    名    称：getConcessionByCamId
    功能概要：根据每次改变活动Id，获取该活动下的所有优惠方案信息，并将它加载到sltConcession上
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
function getConcessionByCamId()
{
    var selectedCampaign=$("select[@name=sltCampaign]")[0];
    var campaignId;
    for(var i=0;i<selectedCampaign.length;i++)
    {
        if(true==selectedCampaign[i].selected && "-1"!=selectedCampaign[i].value)
        {
           campaignId=selectedCampaign[i].value;
           break;
        }
    }
    var url="../ajax/AjaxEngine.aspx?CampaignId="+escape(campaignId);
    $.getJSON(url,{a:'11'},callBackAllConcession);   
}
function  callBackAllConcession(json)
{
    if(null==json || false==json.success)
    {
       return;
    }
    else 
    {
       data1=json
    }
    var selectedConcession=$("select[@name=sltConcession]")[0];
    var strOption="";
    for(var i=0;i<data1.ConcessionList.length;i++)
    {
        strOption+="<option value='"+data1.ConcessionList[i].Id+"'>"+data1.ConcessionList[i].Name+"</option>";
    }
    $(selectedConcession).html(strOption);
    getConcessionInfo();
}

/*
    名    称：getConcessionInfo
    功能概要：根据每次改变优惠方案Id，获取该优惠方案信息
    作    者: 张晓林
    创建时间: 2009年3月19日16:38:26   
    修正履历:
    修正时间:
*/
function getConcessionInfo()
{
    var selectedConcession=$("select[@name=sltConcession]")[0];
    var concessionId=0;
    for(var i=0;i<selectedConcession.length;i++)
    {
        if(true==selectedConcession[i].selected && "-1"!=selectedConcession[i].value)
        {
           concessionId=selectedConcession[i].value;
           break;
        }
    }
    if(0!=concessionId)
    {
        $("#txtChargeSum").val("");
        $("#hiddConcessionId").val(concessionId);
        var url="../ajax/AjaxEngine.aspx?ConcessionId="+escape(concessionId);
        $.getJSON(url,{a:'11'},callBackConcession);       
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