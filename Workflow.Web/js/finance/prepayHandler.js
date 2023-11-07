// JScript 文件
/// 功能概要: 预收款处理Js
/// 创建时间：2009-01-17
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：



/// 名    称: setSearchNo
/// 功能概要: 收款设置
/// 创建时间：2009-01-17
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：
function setSearchNo(obj_A)
{        
    $("#strOrderNo").val(obj_A.title);           
    document.getElementById("labNo").innerHTML=obj_A.title; 
    var i=0;
    var str=$($("td", $(obj_A).parent().parent()[0])[5]).text();
    var customerName=$($(obj_A).parent().parent()).find(".customerName").html();
    while(i!=-1)
    {
        i =str.indexOf(',');
        str=str.substr(0,i)+str.substr(i+1,str.length);
        i =str.indexOf(',');
    }
    $("#CustomerName").html(customerName);
    $("#PrepayMoney").focus();
    $("#PrepayMoney").val(str);
}
    
function GetFoucus(obj)
{
  $(obj).select()
}


/// 名    称: orderDetail
/// 功能概要: 订单详情链接
/// 创建时间：2009-01-17
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：
function orderDetail(o)
{
  var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
  showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true);

}



/// 名    称: DataValidate
/// 功能概要: 查询数据验证
/// 创建时间：2009-01-17
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：
function DataValidate()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val())
    {
        if($("#txtBeginDateTime").val()==$("#txtEndDateTime").val())
        {
          alert("开单时间的开始时间不能等于结束时间!"); 
          return false;
        }
        else if($("#txtBeginDateTime").val()>$("#txtEndDateTime").val())
        {
            alert("开单时间的开始时间不能大于结束时间!"); 
            return false;
        }
    }
}



/// 名    称: dataCheck
/// 功能概要: 收取数据验证
/// 创建时间：2009-01-17
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：
function dataCheck()
{
    if($("#labNo").text()=="")
    {
       alert("请选择收款单号");
       return false;
    }
    if($("#PrepayMoney").val()=="")
    {
       alert("请输入预收金额!");
       $("#PrepayMoney").focus();
       return false;
    }
    confirmvalue=checkOnlyNum($("input:text[@name='PrepayMoney']"),false,14);
    if(confirmvalue!=true)
      return false;       
    if (parseFloat($("input:text[@name='PrepayMoney']").val())<0.001)
    {
        alert("预交款金额不正确!!!");
        $("#txtPrepayMoney").select();
        $("#txtPrepayMoney").focus();
        return false;
    }
    var confirmvalue= confirm("确定要交款吗?");
    if(confirmvalue!=true)
      return false;
    return true;
}

/// 名    称: onkeydown
/// 功能概要: 控制回车提交
/// 创建时间：2009年9月2日9:57:43
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

document.onkeydown=function(event_e)
{
    var evt=window.event||arguments[0];
    var element=evt.srcElement||evt.target;
    if(13==evt.keyCode)
    {
        if("PrepayMoney"==element.id)
        {
            $("#btnSave").click();
            return false;
        }
        else
        {
            $("#btnSearch").click();
            return false;
        }
    }
}
