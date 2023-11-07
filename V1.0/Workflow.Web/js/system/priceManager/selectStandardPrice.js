// JScript 文件
$(document).ready(function(){
  //$("input:button[@value=查询]").click(queryPriceSet);
  $("input:button[@value=下一步]").click(goNextPage);
});
function queryPriceSet()
{
  
}
function goNextPage()
{  
   var count=0;
   var strIdList =new Array();
   $("input:checkbox[@name=chk]").each(function(i,checkbox){
    if (checkbox.checked) {
      strIdList[count++]=checkbox.value;
      }
    });
    if (count==0)
    {
      alert('请至少选择一种门市价格');
      return ;
    }
    $("#txtIdList").attr("value",strIdList.toString());
    $("#txtAction").attr("value","6");
    //alert($("#txtIdList").attr("value"));
    $("#MainForm").submit();
}

