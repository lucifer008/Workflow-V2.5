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
    
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        alert("请先选择卡级别!");
        return false;
    }
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        alert("请先选择业务类型!");
        return false;
    }
    $("#txtAction").attr("value",2);
    $("#MainForm").submit();
}

//function queryPriceSet(){

//    if (document.forms[0]["sltBusinessType"].value==-1)
//    {
//        alert("请先选择业务类型!");
//        return;
//    }
//    
//    if (document.forms[0]["sltMemberCardLevel"].value==-1)
//    { 
//        alert("请先选择卡级别!");
//        return;
//    }
//    
//    $("#txtAction").attr("value",2);
//    $("#MainForm").submit();
//}


function savecheck()
{
    
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        alert("请先选择卡级别");
        return false;
    }
    
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        alert("请先选择业务类型");
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

//功能: 全部选择设置 
//作者: 张晓林
//日期: 2010年1月5日17:46:12
function allSelectedClick(){
    var cbArr=$("input:hidden[name=cbName]");
    if($("#cbSelected").attr("checked")){
        for(var i=0;i<cbArr.length;i++){
            var cbId=$(cbArr[i]).val();   
            var cb=$("#chky"+cbId).attr("checked");
            if(!cb) $("#chky"+cbId).attr("checked",true);
            cb=$("#chkn"+cbId).attr("checked");
            if(!cb) $("#chkn"+cbId).attr("checked",true);   
        }
   }
   else{
        for(var i=0;i<cbArr.length;i++){
            var cbId=$(cbArr[i]).val();   
            var cb=$("#chky"+cbId).attr("checked");
            if(cb) $("#chky"+cbId).attr("checked",false);
            cb=$("#chkn"+cbId).attr("checked");
            if(cb) $("#chkn"+cbId).attr("checked",false);   
        } 
   }
}





function queryPriceSet(sourceSelect){
    if (document.forms[0]["sltMemberCardLevel"].value==-1)
    {
        return false;
    }
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        return false;
    }

    $("#isQuery").val("1");
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + sourceSelect.value;

    $.getJSON(url, {a : '2'}, provider.process);
}
function processJson(json, sourceSelect){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    var sltBusinessType=$("#sltBusinessType"); //处理业务类型
    var btnQuery=$("#btnQuery");  //处理按钮
    var factorMemory=$("#factorMemory").html("");
    factorMemory.append(sltBusinessType);
    for(var i=0; i<data.PriceFactor.length;i++){    
        pf=data.PriceFactor[i];
        var select = $("<select name=factorValuex"+pf.Id+" id=factorValuex"+pf.Id+" onchange='doRelationFactor(this);' ><option value='-1' selected='selected'>请选择</option></select>");
        for (var j = 0; j < pf.FactorValueList.length; j++){
            var fv = pf.FactorValueList[j];
            $("<option value='" + fv.Id + "'>" + fv.Text + "</option>").appendTo(select);
        }
        $(select).attr("value","-1");
        factorMemory.append(select);
    }
    factorMemory.append(btnQuery);
    //处理按钮
}
//获取因素的制约关系
function doRelationFactor(sourceSlt){
    if(sourceSlt.value==-1) return;
    $(sourceSlt).attr("disabled",true);
    var businessTypeId=$("#sltBusinessType")[0].value;
    
    var provider = {};
    provider.source1 = sourceSlt;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+(sourceSlt.id.split('x'))[1]+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);
}

function processRelationFactor(json,sourceSlt){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    $(sourceSlt).attr("disabled",false);
    var priceFactor=data.PriceFactor;
    
    for(var i=0;i<priceFactor.length;i++){
        var obj=priceFactor[i];
        
        if(obj.FactorValueList.length>0){
            $("#factorValuex"+obj.Id).html("<option value='-1' selected=true>请选择</option>");
            for(var j=0;j<obj.FactorValueList.length;j++)
            {
                $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#factorValuex"+obj.Id));
            }
            $($('option',$("#factorValuex"+obj.Id))[0]).attr('selected',true);
        }
    }
}