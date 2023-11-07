// 名    称: customerValidate.js
// 功能概要: 客户确认 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:

/*客户确认数据验证*/
function dataValidate()
{
    var cbSelected=$("input:checkbox[@name=cbCutomer]");//document.form1.cbCutomer;//$("input:checkbox[@name=cbCutomer]");
    var cbSelectedLength=$("input:checkbox[@name=cbCutomer]").length;//document.form1.cbCutomer.length;//$("input:checkbox[@name=cbCutomer]").length;
    var tag=false;
    for(var index=0;index<cbSelectedLength;index++)
    {
        if(cbSelected[index].checked)
        {
          tag=true; 
        }
    }
    if(!tag)
    {
        alert("请选择要确认的客户！") 
        return false;            
    }
    return true;
}

function dataValidateConbination()
{
    var cbSelected=$("input:checkbox[@name=cbCutomer]");
    var cbSelectedLength=$("input:checkbox[@name=cbCutomer]").length;
    var count=0;
    for(var index=0;index<cbSelectedLength;index++)
    {
        if(cbSelected[index].checked)
        {
          count++; 
        }
    }
    if(0==count)
    {
        alert("请选择合并的客户!");
        return false;
    }
    if(1==count)
    {
        alert("合并的客户至少多于一项！") 
        return false;            
    }
    return true;
}
 
    
