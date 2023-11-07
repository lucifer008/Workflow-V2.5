// JScript 文件
///功能概要: 行业价格设置--选择门市价格
///作    者：
///创建时间:
///修正履历:
///修正时间:
///

//功能: 查询数据验证 
//作者: 张晓林
//日期: 2010年1月5日17:46:12
function doQuery(){
    var vSltSecodTrade=$("#sltSecondaryTrade").attr("value")
    var vSltBusiType=$("#sltBusinessType").attr("value");
    if(-1==vSltBusiType){
        alert("请选择业务类型!");
        return false;
    }
    if(-1==vSltSecodTrade){
        alert(" 请选择行业!");
        return false;
    }
    $("#btnQuery").attr("disabled",true);
    $("#actionTag").val("1");
    $("#MainForm").submit();
}
function selectedProtent(){
    var vSltSecodTrade=$("#sltSecondaryTrade").attr("value")
    var vSltBusiType=$("#sltBusinessType").attr("value");
    if(-1!=vSltBusiType && -1!=vSltSecodTrade){
        $("#actionTag").val("1");
        $("#btnQuery").attr("disabled",true);
        $("#MainForm").submit();
    }
}

//功能: 全部选择设置价格 
//作者: 张晓林
//日期: 2010年1月5日17:46:12
function allSelectedClick(){
    var cbArr=$("input:hidden[name=cbName]");
    if($("#cbSelected").attr("checked")){
        for(var i=0;i<cbArr.length;i++){
            var cbId=$(cbArr[i]).val();
            var cb=$("#chky"+cbId);
            if(undefined!=cb){
                $("#chky"+cbId).attr("checked",true);
            }
            cb=$("#chkn"+cbId);
            if(undefined!=cb){ 
                $("#chkn"+cbId).attr("checked",true);   
            }
        }
    }
    else{
        for(var i=0;i<cbArr.length;i++){
            var cbId=$(cbArr[i]).val();   
            var cb=$("#chky"+cbId).attr("checked");
            if(cb  && undefined!=cb) $("#chky"+cbId).attr("checked",false);
            cb=$("#chkn"+cbId).attr("checked");
            if(cb  && undefined!=cb) $("#chkn"+cbId).attr("checked",false);   
        }
    }
}

//功能: 保存设置的行业价格 
//作者: 张晓林
//日期: 2010年1月5日17:46:12
function saveCheck(){
    var selRow=0;
    var cbArr=$("input:hidden[name=cbName]");
    for(var i=0;i<cbArr.length;i++){
        var cbId=$(cbArr[i]).val();   
        var cb= undefined!=$("#chky"+cbId).attr("checked")?$("#chky"+cbId).attr("checked"):$("#chkn"+cbId).attr("checked");
        if(cb) selRow=selRow+1;
    }
    if(0==selRow){
        alert("请至少选择一项!");
        return false;
    }
    if(!checkInputValue()) return false;
    $("#actionTag").val("3");
    $("#btnSavePriceSet").attr("disabled",true);
    $("#MainForm").submit();
}
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

function querySettings(sourceSelect){
    var vSltSecodTrade=$("#sltSecondaryTrade").attr("value")
    var vSltBusiType=$("#sltBusinessType").attr("value");
    if(-1==vSltBusiType){
        return false;
    }
    if(-1==vSltSecodTrade){
        return false;
    }
    $("#btnQuery").attr("disabled",true);
    $("#actionTag").val("1");

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
    $("#btnQuery").attr("disabled",false);

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