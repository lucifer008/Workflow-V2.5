// JScript 文件
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
        alert("请先选择卡级别");
        return false;
    }
    if (document.forms[0]["sltBusinessType"].value==-1)
    {
        alert("请先选择业务类型");
        return false;
    }
    $("#txtAction").attr("value",2);
    $("#isQuery").val(1);
    $("#MainForm").submit();
}

function showStandardPrice()
{
    var pageType = 1;
    //showPage('SelectStandardPrice.aspx?pageType='+pageType, "curWindow", 800, 800, false, false);
    showPage('EditSpecialPrice.aspx?pageType='+pageType, "curWindow", 960, 900, false, false);
    
}
$(document).ready(function(){
    $("input:button[@value=选择门市价格]").click(showStandardPrice);
    $("input:button[@value=查询]").click(queryPriceSet);
});


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

//功能: 批量删除会员价格
//作者: 张晓林
//日期: 2010年1月29日16:46:21
function patchDeleteMembercardPrice(){
    var sltCount=0;
    var arrDeleId=$("input:hidden[@name=mebercardPriceId]");
    for(var i=0;i<arrDeleId.length;i++){
        var cbObject=$("input:checkbox[@name=chky"+$(arrDeleId[i]).val()+"]");
        if($(cbObject).attr("checked")){
            sltCount++;
        }
    }
    if(0==sltCount){
        alert("请选择删除的价格!");
        return false;
    }
    var yes=confirm("确认删除吗?");
    if(yes){
        $("#deleteAction").val("PatchDelete");
        $("#btnDelete").attr("disabled",true);
        $("#MainForm").submit();
    }
}

//功能: 删除会员价格
//作者: 张晓林
//日期: 2010年1月29日16:46:21
function deleteMembercardPrice(o){
    var yes=confirm("确认删除吗?");
    if(yes){
        var Id=$("input:hidden[@name=mebercardPriceId]",$(o).parent().parent()).val();
        $("#deleteId").val(Id);
        $("#deleteAction").val("Delete");
        $("#MainForm").submit();
    }
}

//功能: 批量选择与取消
//作者: 张晓林
//日期: 2010年1月15日10:51:46
function allSelectedClick(){
    var cbStatus=$("#cbSelectAll").attr("checked");
    var arrDeleId=$("input:hidden[@name=mebercardPriceId]");
     if(cbStatus){   
        for(var i=0;i<arrDeleId.length;i++){
           var cbObject=$("input:checkbox[@name=chky"+$(arrDeleId[i]).val()+"]");
           $(cbObject).attr("checked",true)
        }
     }
     else{
        for(var i=0;i<arrDeleId.length;i++){
            var cbObject=$("input:checkbox[@name=chky"+$(arrDeleId[i]).val()+"]");
           $(cbObject).attr("checked",false)
        }
     }
}
function selectedAllClick(){
    var cbStatus=$("#cbSelectAll").attr("checked");
    var arrDeleId=$("input:checkbox[@name=chky]");
     if(cbStatus){   
        for(var i=0;i<arrDeleId.length;i++){
           var cbObject=arrDeleId[i];
           $(cbObject).attr("checked",true)
        }
     }
     else{
        for(var i=0;i<arrDeleId.length;i++){
            var cbObject=arrDeleId[i];
           $(cbObject).attr("checked",false)
        }
     }
}

//功能: 编辑会员价格
//作者: 张晓林
//日期: 2010年1月29日16:46:21
function edmitMemberCardPrice(o){
    try
    {
        var divPrice=$("#divPrice",$(o).parent().parent()).hide();
        var edPrice=$("input:text[@name=newPrice]",$(o).parent().parent());
        $(o).hide();
        $(edPrice).show();
        $(edPrice).select();
        $("#btnSave",$(o).parent()).show();
    }
    catch(e){alert(e);}
}

//功能: 保存会员价格
//作者: 张晓林
//日期: 2010年1月30日15:10:03
function saveMembercardPrice(o){
     var edPrice=$("input:text[@name=newPrice]",$(o).parent().parent()).val();
     var Id=$("input:hidden[@name=mebercardPriceId]",$(o).parent().parent()).val();
     $("#deleteId").val(Id);
     $("#edmitPrice").val(edPrice);
     $("#deleteAction").val("Edmit");
     $(o).attr("disabled",true);
     $("#btnSave",$(o).parent().parent()).attr("disabled",true);
     $("#MainForm").submit();
}

//功能: 回车控制操作
//作者: 张晓林
//日期: 2010年1月30日15:10:03
document.onkeydown=function()
{
    //Esc建退出
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
	if (evt.keyCode==27){
		window.close();
	}
	//回车提交
    if(13==evt.keyCode){
        if("newPrice"==element.id){
            saveMembercardPrice(element);
            return false;
        }
    }
}

function showBatchUpdatePrice(){
	showPage('BatchUpdateMemberPrice.aspx?id=1' , "curWindow", 1100, 600, false, false);
}


function arrangUpdatePrice(){
	
	if(isNaN($("#txtNewPrice").val()))
	{
		alert("请输入有效金额!!!");
		$("#txtNewPrice").focus();
		return false;
	}
	$("#isQuery").val("3");
	
	$("#MainForm").submit();
}

function batchUpdatePrice(){
	if(confirm("确定批量修改价格吗?")){
		$("#isQuery").val("4");
		$("#MainForm").submit();
	}
}