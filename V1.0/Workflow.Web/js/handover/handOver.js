/// JScript 文件
/// 功能概要: 交班Js
/// 创建时间：2009年3月27日9:32:50
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

var tagStage=false;
var tagCash=false;
//var handOverDetail="";
//var cashOnlyDetail="<table width='100%' border='1' cellpadding='3' cellspacing='1'>";
//    cashOnlyDetail+="<tr><td nowrap='nowrap' class='item_caption'>交班类型</td>"; 
//    cashOnlyDetail+="<td><a href='#' onclick='return cashHandOver();'>收银交班</a></td></tr>";  
//    cashOnlyDetail+="</table> ";
//    
//var stageOnlyDetail="<table width='100%' border='1' cellpadding='3' cellspacing='1'>";   
//     stageOnlyDetail+="<tr><td nowrap='nowrap' class='item_caption'>交班类型</td>"; 
//     stageOnlyDetail+="<td><a href='#' onclick='return cashHandOver();'>前台交班</a></td></tr>";   
//     stageOnlyDetail+="</table> ";
     
//$(document).ready(function()
//{
////    var handOverDetail="<table width='100%' border='1' cellpadding='3' cellspacing='1'>";
////    handOverDetail+="<tr><td rowspan='2' nowrap='nowrap' class='item_caption'>交班类型</td>";
////    handOverDetail+="<td><a href='#' onclick='return stageHandOver();'>前台交班</a></td></tr>"; 
////    handOverDetail+="<tr><td><a href='#' onclick='return cashHandOver();'>收银交班</a></td></tr>";  
////    handOverDetail+="</table> ";
//    //$("#td2").html(handOverDetail);
//    //handOverDetail=$("#td2").html();
//    //alert($("#td2"));
//    //$("#td2").html(handOverDetail);
//});


/*前台交班*/
function stageHandOver(o)
{
    var tr=$(o).parent().parent();
    //alert($(tr).find(".tdd").hide());
    //alert($(tr).find(".item_caption").attr("rowSpan","1"));
    //return false;
    var yes=showPage('StageHandOver.aspx?Tag=2',null,1000,700,false,true,false);
    if(yes)
    {
        if(!tagCash)
        {
           $($(tr).find(".tdd")).hide();
           tagStage=true;  
        }
        else
        {
           logOutUser();
        }
    }
}

/*收银交班*/
function cashHandOver(o)
{
    var tr=$(o).parent().parent();
    var yes=showPage('CasherHandOver.aspx?Tag=2',null,1000,700,false,true,false);
    if(yes)
    {
        if(!tagStage)
        {
           $(tr).hide();
           tagCash=true; 
        }
        else
        {
           logOutUser();
        }
    }
}

/*注销当前用户*/
function logOutUser()
{
    window.parent.navigate("../LoginOut.aspx");
}