// JScript 文件
// 名    称: blankOutRecord.js
// 功能概要: 废张 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 

function showRealFacture()
{
    showPage('RealFactureOrder.aspx?strNo='+strNo,null,1024,1024,false,false,true);
    close();
}
 
function saveBlankOutRecard()
{
    var chkArr=$("input:checkbox[@name='chkEmployee']");
    var m=0;
    for(var i=0;i<chkArr.length;i++)
    {

        if($(chkArr[i]).attr("checked"))
        {
            m++;
        }

    }
     if(m<=0)
    {
        alert("不能没有一个责任人!!!");
        return  false
    }
    
    var txtArr=$("input:text[@name='blankOutNum']");
    for(var i=0;i<txtArr.length;i++)
    {
        if(txtArr[i].value=="")
        {
            alert("请填写废稿数量!!!");
            $(txtArr[i]).select();
            $(txtArr[i]).focus();
            return false;
        }
        if(parseFloat(txtArr[i].value)<=0)
        {
            alert("废稿数量不能等于或小于0!!!");
            $(txtArr[i]).select();
            $(txtArr[i]).focus();
            return false;
        }
       if(!checkOnlyNum($(txtArr[i]),false,14))
       {
            $(txtArr[i]).select();
            $(txtArr[i]).focus();
            return false;
       }        }
    var sltArr=$("select[@name='BlankOutReason']");
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].options[sltArr[i].selectedIndex].value=="0")
        {
            alert("请选择废稿原因!!!");
            sltArr[i].focus();
            return false;
        }
    }
    return true;
}
function onChecked(o)
{
    var rowIndex=parseInt($($("td",$(o).parent().parent())[0]).text());
    var name="input:hidden[@name='employeeId"+ (rowIndex-1).toString() +"']";
    var txt=$(name,$(o).parent().parent())[0];
    if($(o).attr("checked"))
    {
        if(-1 == $(txt)[0].value.indexOf($(o).val()))
        {
            $(txt)[0].value=$(txt)[0].value+ $(o).val()+',';
        }
    }
    else
    {
        var index=$(txt)[0].value.indexOf($(o).val());
        if(-1 < index)
        {
            $($(txt)[0]).val($(txt)[0].value.substring(0,index) + $(txt)[0].value.substring(index+1+$(o).val().length));
        }
    }
    
}
function onChecked(o)
{
    var rowIndex=parseInt($($("td",$(o).parent().parent())[0]).text());
    var name="input:hidden[@name='employeeId"+ (rowIndex-1).toString() +"']";
    var txt=$(name,$(o).parent().parent())[0];
    if($(o).attr("checked"))
    {
        if(-1 == $(txt)[0].value.indexOf($(o).val()))
        {
            $(txt)[0].value=$(txt)[0].value+ $(o).val()+',';
        }
    }
    else
    {
        var index=$(txt)[0].value.indexOf($(o).val());
        if(-1 < index)
        {
            $($(txt)[0]).val($(txt)[0].value.substring(0,index) + $(txt)[0].value.substring(index+1+$(o).val().length));
        }
    }
    
}   
function onReasonChange(o)
{
    var slt=$("select[@name='BlankOutReason']",$(o).parent().parent());
    var txt=$("input:hidden[@name='Reason']",$(o).parent().parent());
    
    $(txt)[0].value=$(slt[0])[0].options[$(slt[0])[0].selectedIndex].value;
}     