// JScript 文件

//检测输入的值是否不合规矩
function checkInputValue()
{

    var input1s= document.forms[0]["input1"]
    //alert(input1s.length);
    //检验每一个值,是否不是数字
    for (var i=0;i<input1s.length;i++)
    {
        if (isNumber(input1s[i].value)==false)
        {
	        alert("卡级别价输入不正确!");
	        input1s[i].focus();   
          return false;
          break;
        }
    }
    
    var input2s= document.forms[0]["input2"]
    //alert(input1s.length);
    //检验每一个值,是否不是数字
    for (var i=0;i<input2s.length;i++)
    {
        if (isNumber(input2s[i].value)==false)
	        {
	            alert("卡级别折扣输入不正确!");
	            input2s[i].focus();   
	            return false;
	        }        
        
        //是否1--100之间
        	var parseval;
	        parseval=parseFloat(input2s[i].value);
	        if (parseval<0 || parseval>100)
	        {
	            alert("卡级别折扣输入不正确!");
	            input2s[i].focus();   
	            return false;
	        }        
        break;
    }
    
    return true;

}



function showPriceSet(intId){
    //pageType 1 会员卡价格 2行业价格 3特殊行业会员价格
    //txtAction标记:1初始化 2查询 3增加 4修改 5删除 6其它
    var pageType = 1;
    var obj=showPage('SetPrice.aspx?ID='+intId+'&pageType='+pageType, "curWindow", 800, 465, false, false);
}
function deletePriceSet(intId){
    if (!confirm("是否要真的删除?")) return;
    $("#txtAction").attr("value",5);
    $("#txtId").attr("value",intId);
    $("#MainForm").submit();
}

function queryQuickly()
{
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        return;
    }
    
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        return;
    }
    
    $("#txtAction").attr("value",2);
    $("#MainForm").submit();
}

function queryPriceSet(){

    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        alert("请先选择业务类型");
        return;
    }
    
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        alert("请先选择卡级别");
        return;
    }
    
    $("#txtAction").attr("value",2);
    $("#MainForm").submit();
}


function savecheck()
{
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        alert("请先选择业务类型");
        return false;
    }
    
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        alert("请先选择卡级别");
        return false;
    }
    
    if (checkInputValue()==false)
      return false;
    
    
    $("#txtAction").attr("value",4);
    
    //alert($("#txtAction").attr("value"));
    
    return true;
}
function showStandardPrice()
{
    var pageType = 1;
    showPage('SelectStandardPrice.aspx?pageType='+pageType, "curWindow", 800, 800, false, false);
    //showPage('EditSpecialPrice.aspx?pageType='+pageType, "curWindow", 800, 800, false, false);
    
}

$(document).ready(function(){
    $("input:button[@value=选择门市价格]").click(showStandardPrice);

    $("input:button[@value=查询]").click(queryPriceSet);
});
