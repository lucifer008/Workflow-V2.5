// JScript 文件
/*
    //名    称：adjustAchievement
    //功能概要: 绩效调整JS
    //作    者: 张晓林
    //创建时间: 2009年5月7日11:23:38
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
        if(amntSum!=sumMoney)
        {
            alert('您分配的金额之和必须等于该明细的金额!!!');
            return false;
        }
    }
    return true;
}


var tagAction=false;
//功能:检索数据验证
//作者:张晓林
//日期:
function dataQuery()
{
    if($("#txtNo").val()=="")
    {
        alert('请输入调整的订单号!!!');
        $("#txtNo").select();
        $("#txtNo").focus();
        return false;
    }
    return true;
}
 
//前期人员调整数据判断
function checkProphaseProcess(o)
{
    if(prophaseDataCheck(o))
    {
        adjustOrdersPerson();
        //resetOrderItemAmount(o);
        var a=new AverageOrderItemAmount(o);
        a.averageAmount();
    }    
    return false;
}

//后期人员数据判断
function checkAnaphaseProcess(o)
{
   if(anaphaseDataCheck(o))
   {
       adjustOrdersPerson();
       //resetOrderItemAmount(o); 
       var a=new AverageOrderItemAmount(o);
       a.averageAmount();
   }
   return false;
}

//前期移除
function prophaseCanel(o)
{
    if(prophaseDataCheck(o))
    {
        DeleteOrderItemEmployee();
        //resetOrderItemAmount(o); 
        var a=new AverageOrderItemAmount(o);
        a.averageAmount();
    }
    return false;
}

//后期移除
function anaphaseCancel(o)
{
    if(anaphaseDataCheck(o))
    {
      DeleteOrderItemEmployee();
      //resetOrderItemAmount(o); 
      var a=new AverageOrderItemAmount(o);
      a.averageAmount();
    }
    return false;
}

var prophase;//前期
var anaphase;//后期
var ooProphase,ooAnaphase;
//功能:前期添加数据验证
//作者:张晓林
//日期:
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

//功能:后期添加数据验证
//作者:张晓林
//日期:
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

//功能:调整订单明细制作人员
//作者:张晓林
//日期:
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
          personArrayValue+=$(selePerson[0][i]).attr("value").split(',')[1]+",";//$(selePerson[0][i]).attr("value")+",";//IE7与IE6 option 的label不一致
          personArrayText+=$(selePerson[0][i]).text()+",";//IE下支持，FF下不支持.attr("Text")+","; 
          personPositionArrayValue+=$(selePerson[0][i]).attr("value").split(',')[0]+",";//$(selePerson[0][i]).attr("label")+","; //雇员岗位 
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
               ss1+="<Div id=dProphasePhase"+arrValue[i]+" style='color:Blue'>前期<input name='employee"+$("#hiddItemId").val()+"' type='hidden' value='"+arrValue[i]+"' /><input name='position"+$("#hiddItemId").val()+"' type='hidden' value='"+arrPositionId[i]+"' /><br /></Div>"
               ss2+="<Div id=dProphaseEmName"+arrValue[i]+" style='color:Blue'>"+arrText[i]+"<br /></Div>";
               ss3+="<Div id=dProphaseMoney"+arrValue[i]+"><input name='money"+$("#hiddItemId").val()+arrValue[i]+arrPositionId[i]+"' id='positionType"+arrPositionId[i]+"' type='text' style='width:100%;' value='0' /><br /></Div>"   
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
               ss1+="<Div id=dProphasePhase"+arrValue[i]+" style='color:Red'>后加工<input name='employee"+$("#hiddItemId").val()+"' type='hidden' value='"+arrValue[i]+"' /><input name='position"+$("#hiddItemId").val()+"' type='hidden' value='"+arrPositionId[i]+"' /><br /></Div>"
               ss2+="<Div id=dProphaseEmName"+arrValue[i]+" style='color:Red'>"+arrText[i]+"<br /></Div>";
               ss3+="<Div id=dProphaseMoney"+arrValue[i]+"><input name='money"+$("#hiddItemId").val()+arrValue[i]+arrPositionId[i]+"' id='positionType"+arrPositionId[i]+"' type='text' style='width:100%;' value='0' /><br /></Div>"   
           }
        }               
        $(tdPhase).html($(tdPhase).html()+ss1);
        $(tdName).html($(tdName).html()+ss2);
        $(tdMoney).html($(tdMoney).html()+ss3);
        $(anaphase).attr("selectedIndex",-1); 
        anaphase=undefined;
   }
}


//功能: 删除订单明细制作人员
//作者: 张晓林
//日期:
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
           personArrayValue+=$(selectedPerson[0][i]).attr("value").split(',')[1]+",";//$(selectedPerson[0][i]).attr("value")+",";
           personArrayText+=$(selectedPerson[0][i]).text()+",";//IE下支持,FF下不支持attr("Text")+",";   
        }
     }
    deleteOrderItEm();
}

//功能: 按照雇员名称删除雇员
//作者: 张晓林
//日期:
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
    var count=0;//获取选中的人员与订单明细匹配的人员
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


//功能: 获取订单详情
//作者: 张晓林
//日期:
function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}

//功能: 页面回车提交绑定
//作者: 张晓林
//日期:
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

//功能: 平均分配订单明细金额
//作者: 张晓林
//日期: 2010年5月11日14:10:53

var Class={
    create:function(){
        return function(){
            this.initialize.apply(this,arguments)
        };
    }
}
var AverageOrderItemAmount=Class.create();
AverageOrderItemAmount.prototype={
    initialize:function(o){
        this.o=o;
        this.paramOPName="input:hidden[@name=operatePosition]";
        this.paramOIPCRName="input:hidden[@name=orderItemProcessContentRate]";
        this.tds=$(this.o).parent().parent().parent();
        this.operatePositionId=$(this.paramOPName,$(this.o).parent()).val();//操作类型
        this.allOrderItemAmountObject=$("td[id=tMoney]",$(this.tds));//订单明细的所有业绩Amount
        this.orderItemPrcoessContentRate=$(this.paramOIPCRName,$(this.o).parent()).val()//订单明细加工内容的业绩比例(前期)
        this.orderItemAmount=parseFloat($("td[id=tOIAmount]",$(this.tds)).html()); //订单明细总金额
        this.tdAmount=$("td[id=tMoney]",$(this.tds));
        this.arrAmounts=$("input",$(this.tdAmount));//编辑之前text集合
    },
    //获取编辑的集合
    getObjectArr:function(){
        var arr=$("input[id=positionType"+this.operatePositionId+"]",$(this.allOrderItemAmountObject));
        return arr;
    },
    //是否存在前期
    isExistProphase:function(){
        var arr=$("input[id=positionType"+prophasePositionId+"]",$(this.allOrderItemAmountObject));
        if(undefined==arr) return false;
        else return true;
    }
    //是否存在后期
    ,
    isExistAnaphase:function(){
        var arr=$("input[id=positionType"+anaphasePositionId+"]",$(this.allOrderItemAmountObject));
        if(undefined==arr) return false;
        else return true;
    }
    ,
    //前期默认业绩
    getProphaseAchAmount:function(){
        var rate=parseFloat(this.orderItemPrcoessContentRate);
        return parseFloat(this.orderItemAmount*rate).toFixed(1);;
    }
    ,
    //后期默认业绩
    getAnaphaseAchAmount:function(){
        var rate=1-parseFloat(this.orderItemPrcoessContentRate);
        return parseFloat(this.orderItemAmount*rate).toFixed(1);
    }
    ,
    averageAmount:function(){
        var positionTag=parseFloat(this.operatePositionId);
        switch(positionTag)
        {
           case prophasePositionId:
                this.averageProphaseAmount();
                break;
           case anaphasePositionId:
                this.averageAnaphaseAmount();
                break; 
        }
        this.o=undefined;
    },
    //前期业绩分配
    averageProphaseAmount:function(){
        var pm=this.getObjectArr();
        if(undefined==pm){
            
        }
        else{
            if(0==this.getProphaseAchAmount()%pm.length){
                var ach=parseFloat(this.getProphaseAchAmount()/pm.length).toFixed(2);
                for(var i=0;i<pm.length;i++){
                    $(pm[i]).val(ach);
                }
            }
            else{
                var ach=parseFloat(this.getProphaseAchAmount()/pm.length).toFixed(2);
                for(var i=0;i<pm.length-1;i++){
                    $(pm[i]).val(ach);
                }
                var each=parseFloat(this.getProphaseAchAmount()-parseFloat((pm.length-1)*ach)).toFixed(2);
                $(pm[pm.length-1]).val(each);
            }
        }
    },
    //后期业绩分配
    averageAnaphaseAmount:function(){
        var pm=this.getObjectArr();
        if(undefined==pm){
            
        }
        else{
             if(0==this.getAnaphaseAchAmount()%pm.length){
                var ach=parseFloat(this.getAnaphaseAchAmount()/pm.length).toFixed(2);
                for(var i=0;i<pm.length;i++){
                    $(pm[i]).val(ach);
                }
            }
            else{
                var ach=parseFloat(this.getAnaphaseAchAmount()/pm.length).toFixed(2);
                for(var i=0;i<pm.length-1;i++){
                    $(pm[i]).val(ach);
                }
                var each=parseFloat(this.getAnaphaseAchAmount()-parseFloat((pm.length-1)*ach)).toFixed(2);
                $(pm[pm.length-1]).val(each);
            }
        }
    }
}
