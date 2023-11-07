// JScript 文件

//检测
function checkBasePriceSet1()
{
    var myform=document.forms[0]
    var element;

    
    for (var j=0;j<myform.length;j++)
    {
        
        element= myform[j]
        var strid= element.id;
        
        if (element.id.substring(0,11)=="PriceFactor")
        {
          if (element.value==-1)
          {
            alert("请先选择: " +element.title +"!");
            return false;
            break;
          }
        }
    }
    
    return true;

}


//获取因素的制约关系
function doRelationFactor(sourceSlt)
{
    if(sourceSlt.value==-1) return;
    
    var len=11; //"PriceFactor".length
    var curFactorID=parseInt( sourceSlt.id.substr(len));
    
    var businessTypeId=$("#sltBusinessType")[0].value;
    var nextSltId= curFactorID+1;

    var provider = {};
    provider.source1 = nextSltId;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+curFactorID+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);

}
function processRelationFactor(json,nextSltId)
{
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }    
    //var factorValueList=data.PriceFactor[0].FactorValueList;
    var priceFactor=data.PriceFactor;
    var factorStl="";
    
    //获取到的可能是多个因素
    for(var i=0;i<priceFactor.length;i++)
    {
        var obj=priceFactor[i];
        //影响到的因素的控件ID
        factorStl="PriceFactor" +obj.Id;// priceFactor[i].id;
        
        $("#"+factorStl).html("<option value='-1' selected='selected'>请选择</option>");
        for(var j=0;j<obj.FactorValueList.length;j++)
        {
            $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#"+factorStl));
        }
        $("#"+factorStl).attr('selectedIndex',0);        
    
    }    
    

}


function savePriceSet(){
    $("#txtAction").attr("value","4");
    if (!checkProcess())
    {
      return;
    }
    $("#MainForm").submit();
}
function checkProcess(){
  if ($("#sltBusinessType").val()==0)
  {
    //请选择业务类型
    alert(MESSAGE_BUSINESS_TYPE_EMPTY);
    $("#sltBusinessType").focus();
    return false;
  } 
  
  if (checkBasePriceSet1()==false)
      return false;
  
//    var sltPriceFactors;
//    sltPriceFactors=document.forms[0]["sltPriceFactor"]
//    //alert(sltPriceFactors.length);
//    for (var i=0;i<sltPriceFactors.length;i++)
//    {
//      if (sltPriceFactors[i].value==-1)
//      {
//        alert("请先选择: " +sltPriceFactors[i].title +"!");
//        return false;
//      }
//    }


  //成本价格
  if (!checkNum($("#txtCostPrice"),false,5))
  {
    $("#txtCostPrice").focus();
    $("#txtCostPrice").select();
    return false;
  }
  var costPrice=parseFloat($("#txtCostPrice").attr("value"));
  var price;
  
  //标准价格
  if (!checkNum($("#txtStandardPrice"),false,5))
  {
    $("#txtStandardPrice").focus();
    $("#txtStandardPrice").select();
    return false;
  }
  //标准价格
  price=parseFloat($("#txtStandardPrice").attr("value"));
  if (price<costPrice)
  {
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtStandardPrice").focus();
    $("#txtStandardPrice").select();
    return false;
  }
  
  //活动价格
  if (!checkNum($("#txtActivityPrice"),false,5))
  {
    $("#txtActivityPrice").focus();
    $("#txtActivityPrice").select();
    return false;
  }
  //活动价格
  price=parseFloat($("#txtActivityPrice").attr("value"));
  if (price<costPrice)
  {
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtActivityPrice").focus();
    $("#txtActivityPrice").select();
    return false;
  }
  
  //备用价格
  if (!checkNum($("#txtReservePrice"),false,5))
  {
    $("#txtReservePrice").focus();
    $("#txtReservePrice").select();
    return false;
  }
  //备用价格
  price=parseFloat($("#txtReservePrice").attr("value"));
  if (price<costPrice)
  {
    //价格不能低于成本价格
    alert(MESSAGE_LESS_COSTPRICE);
    $("#txtReservePrice").focus();
    $("#txtReservePrice").select();
    return false;
  }
  return true;
}


function PriceFactor_Changed(selected)
{
   // alert(selected.id);
    doRelationFactor(selected);
}

