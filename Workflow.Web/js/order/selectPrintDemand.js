// JScript 文件
// 名    称: selectPrintDemand.js
// 功能概要: 选择印制要求 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
function doPass()
{
    var url = "../ajax/AjaxEngine.aspx";
    $.getJSON(url, {a : '3'}, passJson);
}

function passJson(json){
    if (json.success == null || json.success) {
        data=json;
    } else {
        var tableDemand=$("#tbMakeDemand");
        $("<tr><td>对不起,没有印制要求的相关数据！！！</td></tr>").appendTo(tableDemand);
        return;
    }
    
    ///动态提取印制要求 付强
    var tableDemand=$("#tbMakeDemand");
    var strTRH="<tr>";
    var strTRT="<td class='w1'><input type='button' class='buttons' value='重置' onclick='resetRadio(this)'></td></tr>";
    var strFirstTD="";
    var strTD;
    var strRadio="";
    if(data.PrintDemandList)
    {
        for(var i=0;i<data.PrintDemandList.length;i++)
        {
            if(data.PrintDemandList[i].PrintDemandDetailList)
            {
                for(var j=0;j<data.PrintDemandList[i].PrintDemandDetailList.length;j++)
                {
                    strFirstTD="<td nowrap class='item_caption w1' rowspan='"+ data.PrintDemandList[i].PrintDemandDetailList.length +"'>"+data.PrintDemandList[i].Name +"</td>";
                    if(data.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList)    
                    {
                        strTD= "<td nowrap class='item_caption w1'>"+ data.PrintDemandList[i].PrintDemandDetailList[j].Name +"</td><td align='left'>"
                        for(var k=0;k<data.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList.length;k++)
                        {
                            strRadio+="<input type='radio' class='radios' name='rdbt"+ data.PrintDemandList[i].PrintDemandDetailList[j].Id +"' id='"+'rdbtn'+i.toString()+j.toString()+k.toString()+"' value='radiobutton' /><label for='"+'rdbtn'+i.toString()+j.toString()+k.toString()+"'>"+ data.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList[k].Name +"</label>";
                        }
                        if(0==j)
                        {
                            $(strTRH+strFirstTD+strTD+strRadio+"</td>"+strTRT).appendTo(tableDemand);
                        }
                        else
                        {
                            $(strTRH+strTD+strRadio+"</td>"+strTRT).appendTo(tableDemand);
                        }
                        strRadio="";

                    }
                    else
                    {
                        strTD="<td nowrap class='item_caption w1' rowspan='"+ data.PrintDemandList[i].PrintDemandDetailList[j].length +"'>"+ data.PrintDemandList[i].Name +"</td><td nowrap class='item_caption w1'>"+ data.PrintDemandList[i].PrintDemandDetailList[j].Name +"</td><td></td>"
                        $(strTRH+strTD+strTRT).appendTo(tableDemand);
                    }
                }
            }
            else
            {
                strTD="<td nowrap class='item_caption w1'>"+ data.PrintDemandList[i].Name +"</td><td></td><td></td>"
                $(strTRH+strTD+strTRT).appendTo(tableDemand);
            }
        }
    }
    else
    {
            var strTD="对不起,没有印制要求的相关数据！！！";
            $(strTRH+strTD+strTRT).appendTo(tableDemand);
    }
}

///重置制作要求 付强
function resetRadio(button)
{
    var rdArr=$("input",$(button).parent().parent());
    for(var i=0;i<rdArr.length;i++)
    {
        $(rdArr[i]).attr("checked",false);
    }
}
$(document).ready(//doPass
    function (){
        var returnValue=opener.getPrintRequest();
        if(returnValue.IdArr)
        {
            for(var i=0;i<returnValue.IdArr.length;i++)
            {
                 $("#" + returnValue.IdArr[i]).attr("checked", true);       
            }
        }
        $("#txtMemo").val(returnValue.Memo);
    }
);

function returnPrintRequire()
{
    var oDemandsArr=new Array();
    var rdoArr=$("input:radio",$());
    var lblArr=$("Label",$());
    var memo=$("#txtMemo").val();
    if(rdoArr!=null)
    {
        for(var i=0;i<rdoArr.length;i++)
        {
            if($(rdoArr[i]).attr("checked"))
            {
               
                var oDemands=new Object();
                //oDemands.name=$(lblArr[i]).attr("innerText");
                oDemands.name=$(lblArr[i]).text();
                oDemands.id=parseInt($(rdoArr[i]).attr("id"));
                oDemandsArr.push(oDemands);
            }
        }
        opener.setPrintRequest(oDemandsArr,memo);
    }
    else
    {
        opener.setPrintRequest(null,memo);
    }
    
    close();
}

