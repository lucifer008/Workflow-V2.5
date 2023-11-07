// JScript 文件
/*
    //名    称：adjustAchievement
    //功能概要: 绩效调整JS
    //作    者:张晓林
    //创建时间:2009年5月7日11:23:38
    //修正履历:
    //修正时间:
*/
//绩效分配数据验证

//Modify: Cry;
//Date: 2009-1-6
function amountCheck()
{
    var orderItem=$("input:hidden[@name=itemid]");
    if(0==orderItem.length) return false;
    for(var i=0;i<orderItem.length;i++)
    {
        var orderItemId=$(orderItem[i]).val();
        var sumMoney=$("td[@name='summoney"+orderItemId+"']").html();
        var employee=$("input:hidden[name=employee"+orderItemId+"]");
        var position=$("input:hidden[name=position"+orderItemId+"]");
        var amntSum=0;
        for(var j=0;j<employee.length;j++)
        {
            var employeeId=$(employee[j]).val();
            var positionId=$(position[j]).val();
            var money=$("input:text[@name=money"+orderItemId+employeeId+positionId+"]");
            if(!checkOnlyNum($(money),false,14)){
                alert('无效数字');
                return false;
            }
            amntSum=fltAdd(amntSum,$(money).val());
        }
        if(amntSum>sumMoney)
        {
            alert('您分配的金额之和不能大于该明细的金额!!!');
            return false;
        }
    }
    return true;
}



///名    称:dataQuery
///功能概要:检索数据验证
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function dataQuery()
{
    if($("#txtNo").val()=="")
    {
        alert('请输入调整的工单号!!!');
        $("#txtNo").select();
        $("#txtNo").focus();
        return false;
    }
    return true;
}

///名    称:checkOrderStatus
///功能概要:检索工单是否已经完成
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function checkOrderStatus()
{
    if($("#txtNo").val()!="")
    {
        var url="../ajax/AjaxEngine.aspx?OrderNo="+$("#txtNo").val();
        $.getJSON(url,{a:'30'},callBackCheck);
    }
}
function callBackCheck(json)
{
    if (json == null || json) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    if("1"==json)
    {
        alert("该工单还没有完成,不能调整业绩!");
        $("#txtNo").val("");
        $("#txtNo").focus();
        return;
    }
}
 
//前期人员调整数据判断
function checkProphaseProcess(o)
{
    if(prophaseDataCheck(o))
    {
        adjustOrdersPerson();
    }    
    return false;
}

//后期人员数据判断
function checkAnaphaseProcess(o)
{
   if(anaphaseDataCheck(o))
   {
       adjustOrdersPerson(); 
   }
   return false;
}

//前期移除
function prophaseCanel(o)
{
    if(prophaseDataCheck(o))
    {
        DeleteOrderItemEmployee();
    }
    return false;
}

//后期移除
function anaphaseCancel(o)
{
    if(anaphaseDataCheck(o))
    {
      DeleteOrderItemEmployee();
    }
    return false;
}

var prophase;//前期
var anaphase;//后期
var ooProphase,ooAnaphase;
///名    称:prophaseDataCheck
///功能概要:前期添加数据验证
///作    者:张晓林
///创建时间:
///修正时间:2009年9月4日9:12:04
///修正履历:兼容各种浏览器--张晓林
prophaseDataCheck=function(o)
{
    prophase=$("select[@name=sltProphase]",$(o).parent())
    
    ooProphase=o;
    var strProphase=$("select[@name=sltProphase] option:selected",$(o).parent()).text();
    //if(0==prophase.length || $(prophase).attr("selectedIndex")<=0)//IE下支持,FF下不支持
    if(""==strProphase)
    {
        alert('请选择调整人员!');
        return false;
    }
    var itemId=$("input[@name=itemid]",$(o).parent().parent().parent()).val();
    $("#hiddItemId").val(itemId);
    return true;
}

///名    称:anaphaseDataCheck
///功能概要:后期添加数据验证
///作    者:张晓林
///创建时间:
///修正时间:2009年9月4日9:12:04
///修正履历:兼容各种浏览器--张晓林
anaphaseDataCheck=function(o)
{
    anaphase=$("select[@name=sltAnaphase]",$(o).parent());
    ooAnaphase=o;
    var strAnaphase=$("select[@name=sltAnaphase] option:selected",$(o).parent()).text();
    //if(0==anaphase.length || $(anaphase).attr("selectedIndex")<=0)//IE下支持,FF下不支持
    if(""==strAnaphase)
    {
        alert('请选择调整人员!');
        return false;
    }
    var itemId=$("input[@name=itemid]",$(o).parent().parent().parent()).val();
    $("#hiddItemId").val(itemId);
    return true;   
}

var personArrayValue;//雇员明细Id字符串
var personArrayText;//雇员明细Name字符串
var personPositionArrayValue;//雇员的岗位字符串

///名    称:adjustOrdersPerson
///功能概要:调整工单明细制作人员
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function adjustOrdersPerson()
{
    personArrayValue=personArrayText=personPositionArrayValue="";
    var selePerson;
    if(undefined!=prophase)//前期
    {
       selePerson= prophase
    }
    else if(undefined!=anaphase)//后加工
    {
        selePerson=anaphase;
    }
    for(var i=0;i<selePerson[0].length;i++)
    {
       if($(selePerson[0][i]).attr("selected"))
       {
          personArrayValue+=$(selePerson[0][i]).attr("value")+",";
          personArrayText+=$(selePerson[0][i]).text()+",";//IE下支持，FF下不支持.attr("Text")+","; 
          personPositionArrayValue+=$(selePerson[0][i]).attr("label")+","; //雇员岗位 
       }
    }
   addOrderItemEmployee();
}

function addOrderItemEmployee()
{
   personArrayText=personArrayText.substring(0,personArrayText.length-1);
   personArrayValue=personArrayValue.substring(0,personArrayValue.length-1);
   personPositionArrayValue=personPositionArrayValue.substring(0,personPositionArrayValue.length-1);
   var arrText=personArrayText.split(',');
   var arrValue=personArrayValue.split(',');
   var arrPositionId=personPositionArrayValue.split(',');
   var ss1="",ss2="",ss3="";
   if(undefined!=prophase)//前期
   {
        var tdPhase=$("td[id=tPosition]",$(ooProphase).parent().parent().parent());//阶段
        var tdName=$("td[id=tEmployeeName]",$(ooProphase).parent().parent().parent());//姓名
        var tdMoney=$("td[id=tMoney]",$(ooProphase).parent().parent().parent());//金额
        for(var i=0;i<arrText.length;i++)
        {
           var strEmployee=$(tdName).html();
           if(-1==strEmployee.indexOf(arrText[i]))
           {
               ss1+="<Div id=dProphasePhase"+arrValue[i]+">前期<input name='employee"+$("#hiddItemId").val()+"' type='hidden' value='"+arrValue[i]+"' /><input name='position"+$("#hiddItemId").val()+"' type='hidden' value='"+arrPositionId[i]+"' /><br /></Div>"
               ss2+="<Div id=dProphaseEmName"+arrValue[i]+">"+arrText[i]+"<br /></Div>";
               ss3+="<Div id=dProphaseMoney"+arrValue[i]+"><input name='money"+$("#hiddItemId").val()+arrValue[i]+arrPositionId[i]+"' type='text' style='width:100%;' value='0' /><br /></Div>"   
           }
        }
        $(tdPhase).html(ss1+$(tdPhase).html());
        $(tdName).html(ss2+$(tdName).html());
        $(tdMoney).html(ss3+$(tdMoney).html());
        $(prophase).attr("selectedIndex",-1);
        prophase=undefined;
   }
   if(undefined!=anaphase)//后期
   {
        var tdPhase=$("td[id=tPosition]",$(ooAnaphase).parent().parent().parent());//阶段
        var tdName=$("td[id=tEmployeeName]",$(ooAnaphase).parent().parent().parent());//姓名
        var tdMoney=$("td[id=tMoney]",$(ooAnaphase).parent().parent().parent());//金额
        for(var i=0;i<arrText.length;i++)
        {
           var strEmployee=$(tdName).html();
           if(-1==strEmployee.indexOf(arrText[i]))
           {
               ss1+="<Div id=dProphasePhase"+arrValue[i]+">后加工<input name='employee"+$("#hiddItemId").val()+"' type='hidden' value='"+arrValue[i]+"' /><input name='position"+$("#hiddItemId").val()+"' type='hidden' value='"+arrPositionId[i]+"' /><br /></Div>"
               ss2+="<Div id=dProphaseEmName"+arrValue[i]+">"+arrText[i]+"<br /></Div>";
               ss3+="<Div id=dProphaseMoney"+arrValue[i]+"><input name='money"+$("#hiddItemId").val()+arrValue[i]+arrPositionId[i]+"' type='text' style='width:100%;' value='0' /><br /></Div>"   
           }
        }               
        $(tdPhase).html($(tdPhase).html()+ss1);
        $(tdName).html($(tdName).html()+ss2);
        $(tdMoney).html($(tdMoney).html()+ss3);
        $(anaphase).attr("selectedIndex",-1); 
        anaphase=undefined;
   }
}


///名    称:DeleteOrderItemEmployee
///功能概要:删除工单明细制作人员
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function DeleteOrderItemEmployee()
{
    personArrayValue=personArrayText="";
    var selectedPerson;
     if(undefined!=prophase)//前期
     {
        selectedPerson=prophase;
     }
     else if(undefined!=anaphase)//后加工
     {
        selectedPerson=anaphase;
     }
     for(var i=0;i<selectedPerson[0].length;i++)
     {
        if($(selectedPerson[0][i]).attr("selected"))
        {
           personArrayValue+=$(selectedPerson[0][i]).attr("value")+",";
           personArrayText+=$(selectedPerson[0][i]).text()+",";//IE下支持,FF下不支持attr("Text")+",";   
        }
     }
    deleteOrderItEm();
}

///名    称:deleteOrderItEm
///功能概要:按照名称删除雇员
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function deleteOrderItEm()
{
   personArrayText=personArrayText.substring(0,personArrayText.length-1);
   personArrayValue=personArrayValue.substring(0,personArrayValue.length-1);
   var arrText=personArrayText.split(',');
   var arrValue=personArrayValue.split(',');
   var ss1="",ss2="",ss3="";
   var tdPhase,tdName,tdMoney;
   if(undefined!=prophase)//前期
   {
        tdPhase=$("td[id=tPosition]",$(ooProphase).parent().parent().parent());//阶段
        tdName=$("td[id=tEmployeeName]",$(ooProphase).parent().parent().parent());//姓名
        tdMoney=$("td[id=tMoney]",$(ooProphase).parent().parent().parent());//金额
        $(prophase).attr("selectedIndex",-1); 
        prophase=undefined;
    }
   if(undefined!=anaphase)//后期
   {
        tdPhase=$("td[id=tPosition]",$(ooAnaphase).parent().parent().parent());//阶段
        tdName=$("td[id=tEmployeeName]",$(ooAnaphase).parent().parent().parent());//姓名
        tdMoney=$("td[id=tMoney]",$(ooAnaphase).parent().parent().parent());//金额  
        $(anaphase).attr("selectedIndex",-1);
        anaphase=undefined; 
    }
    var count=0;//获取选中的人员与工单明细匹配的人员
    for(var i=0;i<arrText.length;i++)
    {
       var strEmployee=$(tdName).html();
       var index=strEmployee.indexOf(arrText[i]);
       if(-1!=index)
       {
          count++;
       }
    }
    if(count>=$("div",tdPhase).length)
    {
        alert('至少应该有一个参与人员!');
        return;
    }
    for(var i=0;i<arrText.length;i++)
    {
       var strEmployee=$(tdName).html();
       var index=strEmployee.indexOf(arrText[i]);
       if(-1!=index)
       {
           if($("div",tdPhase).length>1)
               $("div[id=dProphasePhase"+arrValue[i]+"]",$(tdPhase)).remove();
           if($("div",tdName).length>1)
               $("div[id=dProphaseEmName"+arrValue[i]+"]",$(tdName)).remove();
           if($("div",tdMoney).length>1)
               $("div[id=dProphaseMoney"+arrValue[i]+"]",$(tdMoney)).remove();  
        }
    }
}


///名    称:orderDetail
///功能概要:获取工单详情
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}

///名    称:onkeydown
///功能概要:控制回车提交
///作    者:张晓林
///创建时间:2009年9月2日10:28:57
///修正时间:
///修正履历:
document.onkeydown=function(event_e)
{
    var evt=window.event||arguments[0];
    var element=evt.srcElement||src.target;
    if(13==evt.keyCode)
    {
        if("txtNo"==element.id || "strNo"==element.id)
        {
            $("#btnSearch").click();
            return false;
        }
        else
        {
            $("#btnSave").click();
            return false;
        }
    }
}