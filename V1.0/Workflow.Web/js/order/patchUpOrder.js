// JScript 文件
// 名    称: patchUpOrder.js
// 功能概要: 拼板 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
 var rowIndex=0;
$(document).ready(
    function()
    {
        var oSelect=$("select[@name='BusinessType']");
        for(var i=0;i<oSelect.length;i++)
        {
            if(oSelect[i].options[oSelect[i].selectedIndex].value!='-1')
            {
                doProcess(oSelect[i]);
                rowIndex=$($($("td",$(oSelect[i]).parent().parent()))[0]).text();
                getSelectArray(parseInt(rowIndex));
                //var k=0;
                //do{k++;}while(!processFlag)
                
                //processFlag=false;
            }
        }
    }

);

$(document).ready(function() {
    if(flag)
    {
        $("input:button[@name='btnBlankOut']").attr("disabled","");
        $("#btn").attr("disabled","none");
    }
});
function blankOutRecord()
{
    //var strOrderNo=strNo;//$("#txtOrderNo").attr("value");
    showPage('BlankOutRecord.aspx?strNo='+strNo,null,1024,1024,false,true);
    close();
}
function getSelectArray(index)
{
   //alert("dtdt");
   var oSelect=$("select[@name='BusinessType']")[index-1];
   var sltArr=$("select",$(oSelect).parent().parent());
   if(sltArr.length<=1)
   {
        setTimeout("getSelectArray("+index+")",500);
        //getSelectArray(index);
   }
   else
   {
        transficationOrderItemFactorValue(strNo,oSelect);
   }
}