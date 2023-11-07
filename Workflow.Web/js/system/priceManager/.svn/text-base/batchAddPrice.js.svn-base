// JScript 文件
// 名    称: batchAddPrice
// 功能概要: 批量添加门市价格 Js
// 作    者: 张晓林
// 创建时间: 2009年6月23日10:07:12
// 修正履历: 
// 修正时间:

$(document).ready(function(){
    //对价格因素(发票/加工内容)做特殊处理(发票不只能单选)
   var myform=document.forms[0]
    var element;
    for (var j=0;j<myform.length;j++){
        element= myform[j]        
        if (element.title=="发票" || element.title=="加工内容" || element.title=="数量" || element.title=="会员"){
         $(element).removeAttr("multiple");
         var defaultSel="<option value='-1'>请选择</option>";
         $(element).html(defaultSel+$(element).html()); 
         $("input[@name=btnClear]",$(element).parent()).remove();
        }
    }
});


//添加数据验证
function checkProcess(){
  if ("-1"==$("#ddlistBusinessType").val()){
    alert(MESSAGE_BUSINESS_TYPE_EMPTY);
    $("#ddlistBusinessType").focus();
    return false;
  } 
 
  if (!checkBasePriceSet1())
    return false;
  
  //成本价格
  if (!checkNum($("#txtCostPrice"),false,5)){
    $("#txtCostPrice").focus();
    $("#txtCostPrice").select();
    return false;
  }
  var costPrice=parseFloat($("#txtCostPrice").attr("value"));
  var price;
  //标准价格
  if (!checkNum($("#txtStandardPrice"),false,5)){
    $("#txtStandardPrice").focus();
    $("#txtStandardPrice").select();
    return false;
  }
  //标准价格
  price=parseFloat($("#txtStandardPrice").attr("value"));
  if (price<costPrice){
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtStandardPrice").focus();
    $("#txtStandardPrice").select();
    return false;
  }
  
  //活动价格
  if (!checkNum($("#txtActivityPrice"),false,5)){
    $("#txtActivityPrice").focus();
    $("#txtActivityPrice").select();
    return false;
  }
  //活动价格
  price=parseFloat($("#txtActivityPrice").attr("value"));
  if (price<costPrice){
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtActivityPrice").focus();
    $("#txtActivityPrice").select();
    return false;
  }
  
  //备用价格
  if (!checkNum($("#txtReservePrice"),false,5)){
    $("#txtReservePrice").focus();
    $("#txtReservePrice").select();
    return false;
  }
  //备用价格
  price=parseFloat($("#txtReservePrice").attr("value"));
  if (price<costPrice){
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtReservePrice").focus();
    $("#txtReservePrice").select();
    return false;
  }
  return true;
}

//判断是否选择 业务类型价格因素
function checkBasePriceSet1(){
    var myform=document.forms[0]
    var element;
    for (var j=0;j<myform.length;j++){
        element= myform[j]
        var strid= element.id;
        if (element.id.substring(0,11)=="PriceFactor"){
          if (element.value==""){
            alert("请先选择: " +element.title +"!");
            return false;
            break;
          }
          //加工内容与发票每次选择的数目是唯一的，故特殊处理
          else if(element.title=="发票" || element.title=="加工内容" || element.title=="数量" || element.title=="会员"){
                if (element.value=="-1"){
                alert("请先选择: " +element.title +"!");
                return false;
                break;
              }
          }
        }
    }
    return true;
}

//获取因素的制约关系
//修正为：可以选择多个制约因素---张晓林 2009年6月25日9:04:31
var element="";
var slt;
var count=0;
function doRelationFactor(sourceSlt){
    try
    {
        if(sourceSlt.value=="") return;
        var strSeleValue="";//记录选择因素
        element="";
        for(var index=0;index<sourceSlt.length;index++)
        {
            if(sourceSlt[index].selected && sourceSlt[index].value!="")
            {
               strSeleValue+=sourceSlt[index].value+",";
            }
        }
        var arrValue=strSeleValue.substr(0,strSeleValue.length-1).split(',');
        var len=11; //"PriceFactor".length
        var curFactorID=parseInt( sourceSlt.id.substr(len));
        var businessTypeId=$("#ddlistBusinessType")[0].value;
        var nextSltId= curFactorID+1;
        var provider = {};
        for(var i=0;i<arrValue.length;i++)
        {
            provider.source1 = nextSltId;
            provider.process = function(json) {
                window.processRelationFactor(json, provider.source1);
            };
            var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+curFactorID+"&SourceValue="+arrValue[i];//sourceSlt.value;
            $.getJSON(url, {a : '2'}, provider.process);
        }
     }
     catch(ex)
     {
        alert(ex);
     }
}
function processRelationFactor(json,nextSltId){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }  
    var priceFactor=data.PriceFactor;
    var factorStl="";
    if(1==count){
        for(var i=0;i<priceFactor.length;i++){
            var obj=priceFactor[i];
            //影响到的因素的控件ID
            factorStl="PriceFactor" +obj.Id;
            $("#"+factorStl).html("");
        }
    }
    //获取到的可能是多个因素
    for(var i=0;i<priceFactor.length;i++){
        var obj=priceFactor[i];
        //影响到的因素的控件ID
        factorStl="PriceFactor" +obj.Id;// priceFactor[i].id;
        var elHtml="";//$("#"+factorStl).html();
        $("#"+factorStl).html("");
        for(var j=0;j<obj.FactorValueList.length;j++)
        {
//            if(null!=elHtml){
//                if(-1==elHtml.indexOf(obj.FactorValueList[j].Text)){
                    elHtml+="<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>";
                //}
            //}
        }
        if(null==elHtml) elHtml="";
       $("#"+factorStl).html(elHtml);
    }
    //$("#"+$(slt).attr("id")).html(element);
    count++;    
}

function PriceFactor_Changed(selected){
    doRelationFactor(selected);
}

//清空Select选择项
function clearSelected(o){
    var sltPriceFactor=$("select[@name=sltPriceFactor"+o+"]");
    for(var i=0;i<sltPriceFactor.length;i++){
        $(sltPriceFactor[i]).attr("selectedIndex",-1);
    }
}
