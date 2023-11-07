// JScript 文件
/*
//名    称：topclick
//功能概要: 顶部显示/隐藏管理JS
//作    者: 张晓林
//创建时间: 2009年6月22日9:19:35
//修正履历:
//修正时间:
*/

function alt()
{
    var row=$(window.parent.document).find("#fRow");
    var top=$(window.parent.document).find("#imgTop");
    if("120,15,*"==$(row).attr("rows"))
    {
        //window.parent.document.getElementById("fRow").rows=="120,15,*")
        //window.parent.document.getElementById("fRow").rows="1,15,*";
        //document.getElementById("imgTop").src="images/in.gif";
        $(row).attr("rows","1,15,*");
        $(top).attr("src","images/in.gif");
    }
    else
    {
        //window.parent.document.getElementById("fRow").rows="120,15,*";
        //document.getElementById("imgTop").src="images/out.gif";
        $(row).attr("rows","120,15,*");
        $(top).attr("src","images/in.gif");
    }
}