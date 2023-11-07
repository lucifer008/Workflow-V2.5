// JScript 文件
// 名    称: reDo.js
// 功能概要: 返工 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
    $(document).ready(
        function(){
          $("#OrderNo").text(strNo);
          $("#CustomerName").text(strName);
          $("#txtOrderNo").attr("value",strNo);
        }
    );
    function dataCheck()
    {
        if($("#sltDutyMan").attr("selectedIndex")<0)
        {
            alert("至少应该有一个责任人！！！");
            $("#sltDutyMan").focus();
            return false;
        }

        if($("#prophase").attr("selectedIndex")<0 && $("#anaphase").attr("selectedIndex")<0)
        {
            alert("前期或后期至少应该有一个！！！");
            $("#prophase").focus();
            return false;
        }
        if($("#txtReason")[0].value=="")
        {
            alert("您还没有填写返工原因！！！");
            $('#txtReason').focus();
            return false;
        }
        if($("#txtDutyMoney")[0].value=="")
        {
            alert("请填写责任金额!!!");
            $("#txtDutyMoney").focus();
            return false;
        }
        //checkOnlyNum($("#txtDutyMoney"),false,14)
        if(!checkOnlyNum($("#txtDutyMoney"),false,14))
        {
            return false;
        }
        if(parseFloat($("#txtDutyMoney")[0].value)<=0)
        {
            alert("责任金额不能小于等于0!!!");
            $("#txtDutyMoney").focus();
            return false
        }
        if($($("textarea[@name='strReason']")[0]).attr("value").length>200)
        {
            alert("您输入的备注太长!!!");
            $($("textarea[@name='strReason']")[0]).focus();
            return false;
        }  
        return true;
    } 