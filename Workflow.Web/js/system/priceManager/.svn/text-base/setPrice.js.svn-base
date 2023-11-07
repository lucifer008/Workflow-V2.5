// JScript 文件
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
    alert(MESSAGE_BUSINESS_TYPE_EMPTY);
    $("#sltBusinessType").focus();
    return false;
  } 
  
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
  
  //新价格
  if (!checkNum($("#txtNewPrice"),true,5))
  {
    $("#txtNewPrice").focus();
    $("#txtNewPrice").select();
    return false;
  }
  if ($("#txtNewPrice").attr("value")!="");
  {
    price=parseFloat($("#txtNewPrice").attr("value"));
    if (price<costPrice)
    {
      //价格不能低于成本价格
      alert(MESSAGE_LESS_COSTPRICE);
      $("#txtNewPrice").focus();
      $("#txtNewPrice").select();
      return false;
    }
  }
  
  //折扣
  if (!checkOnlyNum($("#txtConcession"),true,5))
  {
    $("#txtConcession").focus();
    $("#txtConcession").select();
    return false;
  }
  
  if (($("#txtConcession").attr("value")!=null) && ($("#txtConcession").attr("value")!=""))
  {
    //折扣价格
    var priceConcession=parseInt($("#txtConcession").attr("value"));
    if ((priceConcession>100) ||(priceConcession<=0))
      {
        //无效的折扣信息
        alert(MESSAGE_WRONG_CONCESSION);
        $("#txtConcession").focus();
        $("#txtConcession").select();
        return false;
      }
  }
  //新价格和折扣同时输入的情况下不允许通过
  var newPrice=$("#txtNewPrice").attr("value");
  var concession=$("#txtConcession").attr("value");
//  if ((newPrice!=null && newPrice!="") && (concession!=null && concession!=""))
//  {
//    //价格和折扣不能同时设置,请确认
//    alert(MESSAGE_PRICE_CONCESSION_ALL_NOT_EMPTY);
//    $("#txtNewPrice").focus();
//    $("#txtNewPrice").select();
//    return false;
//  }
  
  //新价格和折扣同时不输入的情况下不允许通过
  if ((newPrice==null || newPrice=="") || (concession==null || concession==""))
  {

    //价格和折扣至少要设置一个,请确认
    alert(MESSAGE_PRICE_CONCESSION_ALL_EMPTY);
    $("#txtNewPrice").focus();
    $("#txtNewPrice").select();
    return false;
  }
  return true;
}
