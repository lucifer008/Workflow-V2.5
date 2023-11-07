// JScript 文件
function savePriceSet(){
  if(!checkProcess())
  {
    return false;
  }
  $("#txtAction").attr("value",3);
  $("#MainForm").submit();
}

function checkProcess(){

  if ($("#sltTargetId").val()==0)
  {
    alert('请选择');
    $("#sltTargetId").focus();
    return false;
  } 
  var newPrice;
  var priceConcession;
  var blnCheck=true;
  $("input:text[name=txtNewPrice]").each(function(i,txt){
    newPrice=txt.value;
    if (newPrice!=null && newPrice!='')
    {
      if (!checkNum($("#txtNewPrice"+i),false,5))
      {
        $("#txtNewPrice"+i).focus();
        $("#txtNewPrice"+i).select();
        blnCheck=false;
        return false;
      }
    }
    
    priceConcession=$("#txtPriceConcession"+i).val();
    if ((newPrice!=null && newPrice!='') && (priceConcession!=null && priceConcession!=''))
    {
      //价格和折扣不能同时设置,请确认
      alert(MESSAGE_PRICE_CONCESSION_ALL_NOT_EMPTY);
      $("#txtPriceConcession"+i).focus();
      $("#txtPriceConcession"+i).select();
      blnCheck=false;
      return false;
    }
    
    priceConcession=$("#txtPriceConcession"+i).val();
    if ((newPrice==null || newPrice=='') && (priceConcession==null || priceConcession==''))
    {
      //价格和折扣至少要设置一个,请确认
      alert(MESSAGE_PRICE_CONCESSION_ALL_EMPTY);
      $("#txtNewPrice"+i).focus();
      blnCheck=false;
      return false;
    }
      
    priceConcession=$("#txtPriceConcession"+i).val();
    if (priceConcession!=null && priceConcession!='')
    {
      if (!checkNum($("#txtPriceConcession"+i),false,5))
      {
        $("#txtPriceConcession"+i).focus();
        $("#txtPriceConcession"+i).select();
        blnCheck=false;
        return false;
      }
      if ((priceConcession>100) ||(priceConcession<=0))
      {
        //无效的折扣信息
        alert(MESSAGE_WRONG_CONCESSION);
        $("#txtPriceConcession"+i).focus();
        $("#txtPriceConcession"+i).select();
        blnCheck=false;
        return false;
      }
  }
  });
  if (!blnCheck) return false;
  return true;
}
