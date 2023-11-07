// JScript 文件


//=================
//新的获取BusinessType的Ajax方法
function getBusinessProcess(sourceSelect)
{
    $(sourceSelect).attr("disabled",true);
    var sltArr=$("select",$(sourceSelect).parent().parent());      

    
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../../ajax/AjaxEngine.aspx" + "?sltBusinessTypeName=" + sourceSelect.value;

    $.getJSON(url, {a : '13'}, provider.process);
    $(sourceSelect).attr("disabled",false);

}



function processJson(json, sourceSelect){
    if (json.success == null || json.success) 
    {
        data=json;
        reBuildTableRows2(data);    
    } 
    else 
    {
        return;
    }


function reBuildTableRows2(data)
{  
//RowNum,BusinessName,FactorNames,Memo,Edit1,Edit2,DelID  
    var firstRow='<tr><th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th><th width="30%" nowrap="nowrap">业务名称</th><th width="40%" nowrap="nowrap">相关因素</th><th nowrap="nowrap">备注</th><th width="1%" nowrap="nowrap">&nbsp;</th></tr>'
    var nextRow='';
    var factor='';
    for (var i=0;i<data.length;i++)
    {
          nextRow += '<tr>'
          nextRow +='<td align="center">' + (i+1) + '</td>'; //No
          nextRow +='<td align="left">' + data[i].Name + '</td>';   //业务名称
          nextRow +='<td align="left">'
          factor='';
          for (var j=0;j<data[i].PriceFactorList.length;j++)
              factor+=data[i].PriceFactorList[j].Name+ ',';
          
          factor=factor.substring(0,factor.length-1);    
              
          nextRow += factor + '</td>';   //相关因素
          nextRow +='<td ></td>';               //备注
          nextRow +='<td align="left" nowrap="nowrap"><a href="#" onclick="showEditBusinessType('+data[i].Id+','+'\''+ data[i].Name +'\''+');">编辑</a> <a href="#" onclick="deleteBusinessType('+data[i].Id+');">删除</a></td>'             
          nextRow+='</tr>\n'          
    }
    var allRows=firstRow+nextRow;
    $("#tabledetail").html(allRows);
    
}

    
function reBuildTableRows(data)
{  
//RowNum,BusinessName,FactorNames,Memo,Edit1,Edit2,DelID  
    var firstRow='<tr><th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th><th width="30%" nowrap="nowrap">业务名称</th><th width="40%" nowrap="nowrap">相关因素</th><th nowrap="nowrap">备注</th><th width="1%" nowrap="nowrap">&nbsp;</th></tr>'
    var nextRow='';
    
    for (var i=0;i<data.length;i++)
    {
          nextRow += '<tr>'
          nextRow +='<td align="center">' + data[i].RowNum + '</td>'; //No
          nextRow +='<td align="left">' + data[i].BusinessName + '</td>';   //业务名称
          nextRow +='<td align="left">' + data[i].FactorNames + '</td>';   //相关因素
          nextRow +='<td >' + data[i].Memo + '</td>';               //备注
          nextRow +='<td align="left" nowrap="nowrap"><a href="#" onclick="showEditBusinessType('+data[i].Edit1+','+'\''+ data[i].Edit2 +'\''+');">编辑</a> <a href="#" onclick="deleteBusinessType('+data[i].DelID+');">删除</a></td>'             
          nextRow+='</tr>\n'          
    }
    var allRows=firstRow+nextRow;
    $("#tabledetail").html(allRows);   


}


    
}


$("document").ready(function(){
$("input:button[@value=查询]").click(QueryProcess);
$("input:button[@value=新建业务类型]","MainForm").click(showAddBusinessType);

}
);
function QueryProcess(){
  $("#txtAction").attr("value",2);
  var select=$("#sltBusinessTypeName");
  $("#MainForm").submit();
  }
  
  
function reQueryProcess_Ajax()  
{
  var select=document.forms[0]["sltBusinessTypeName"].value; //$("#sltBusinessTypeName");
  
  document.forms[0]["sltBusinessTypeName"].disabled="disabled";
  //alert(select);
  
    $.post("BusinessType_Ajax.aspx",
           { sltBusinessTypeName: select, time: "2pm" },
           function(data){
              //alert("Data Loaded: " + data );
              reBuildTableRows(data);              
           } 
           
    );
  document.forms[0]["sltBusinessTypeName"].disabled="";
  document.forms[0]["sltBusinessTypeName"].focus();
    
}

function reBuildTableRows(data)
{    
    var firstrow='<tr><th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th><th width="30%" nowrap="nowrap">业务名称</th><th width="40%" nowrap="nowrap">相关因素</th><th nowrap="nowrap">备注</th><th width="1%" nowrap="nowrap">&nbsp;</th></tr>'
    var nextrow='';
    
    //分解data
    var rows=data.split("$row");    
    if (rows.length>0)
    {
      for (var i=0;i<rows.length-1;i++)
      {
          var cols=rows[i].split("$col");
          nextrow += '<tr>'
          nextrow +='<td align="center">' + cols[0] + '</td>'; //No
          nextrow +='<td align="left">' + cols[1] + '</td>';   //业务名称
          nextrow +='<td align="left">' + cols[2] + '</td>';   //相关因素
          nextrow +='<td >' + cols[3] + '</td>';               //备注
          nextrow +='<td align="left" nowrap="nowrap"><a href="#" onclick="showEditBusinessType('+cols[4]+','+'\''+ cols[5] +'\''+');">编辑</a> <a href="#" onclick="deleteBusinessType('+cols[6]+');">删除</a></td>'             
          nextrow+='</tr>\n'          
      }      
    }
    
    var allrows=firstrow+nextrow;
    $("#tabledetail").html(allrows);
}


function showAddBusinessType()
{
  $("#txtAction").attr("value",3);
	showPage('AddBusinessType.aspx', "curWindow", 805, 515, false, false);
}
function showEditBusinessType(id,name)
{
  $("#txtAction").attr("value",3);
	showPage('EditBusinessType.aspx?id='+id+'&name='+escape(name), "curWindow", 805, 515, false, false);
}
function deleteBusinessType(id)
{
    if (!confirm("是否要真的删除?")) return;
    $("#txtId").attr("value",id);
    $("#txtAction").attr("value",5);
    $("#MainForm").submit();
}
