//功能: 日报操作JS
//作者: 张晓林
//日期: 2008-11-28


//功能: 查询数据验证
//作者: 张晓林
//日期: 2008-11-28
function DataCheck(){
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val()){
        if($("#txtBeginDateTime").val()==$("#txtEndDateTime").val()){
            alert("开始日期和结束日期不能相同!");
            return false;
        }
        else if($("#txtBeginDateTime").val()>$("#txtEndDateTime").val()){
           alert("开始日期不能大于结束日期!");
           return false;
        }
                
    }
    if(""==$("#txtBeginDateTime").val() && ""==$("#txtEndDateTime").val()){
        alert("查询条件不能为空!");
        return false;
    }
    $("#hidDate").val(999);
}

//功能: 订单详情链接
//作者: 张晓林
//日期: 2008-11-28
function orderDetail(o){
    showPage('../../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}

//通过时间获取数据
function getOrderByDate(date){
    $("#txtEndDateTime").val("");
    $("#txtBeginDateTime").val("");
	document.getElementById('hidDate').value=date;
	document.getElementById('actionTag').value="F";
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function getByDate(date){
    $("#action").val("T");
    $("#txtEndDateTime").val("");
    $("#txtBeginDateTime").val("");
    document.getElementById('actionTag').value="T";
	document.getElementById('hidDate').value=date;
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function pagerCheck(){
    $("#hidDate").val(999);
}
