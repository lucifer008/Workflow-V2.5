// JScript 文件
/*
//名    称：leftclick
//功能概要: 左菜单管理JS
//作    者: 张晓林
//创建时间: 2009年6月22日9:19:35
//修正履历:
//修正时间:
*/


function alt()
{
    var col=$(window.parent.document).find("#fCol");
    var src=$(window.parent.document).find("#imgLeft");
    if("200,15,*"==col.attr("cols"))
    {
        //window.parent.document.getElementById("fCol").cols="1,15,*";
        //document.getElementById("imgLeft").src="images/fore.gif";
        col.attr("cols","1,15,*");
        src.attr("src","images/fore.gif");
    }
    else
    {
        //window.parent.document.getElementById("fCol").cols="200,15,*";
        //document.getElementById("imgLeft").src="images/back.gif";
        col.attr("cols","200,15,*");
        col.attr("src","images/back.gif");
    }
}