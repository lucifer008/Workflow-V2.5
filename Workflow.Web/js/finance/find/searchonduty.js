 
 /// JScript 文件
/// 文 件 名：searchonduty.js
/// 所属模块:财务处理--财务查询---收银当班查询
/// 创建时间：2009-01-17
/// 创 建 人:张晓林
/// 修改时间：
/// 修改描述：


//功能: 显示订单详情  
//作者: 张晓林
//日期: 2009-01-17
function orderDetail(o){
    showPage('../../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}


//功能: 清空选择的项  
//作者: 张晓林
//日期: 2009-01-17
function clearEmplSelected(){
    var sltEmploy=$("select[@name='sltEmployee']");
    for(var i=0;i<sltEmploy.length;i++){
        $(sltEmploy[i]).attr("selectedIndex",-1);
    }
}

//功能: 查询数据验证  
//作者: 张晓林
//日期: 2009-01-17   
function DataCheck(){
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val()){
        if($("#txtBeginDateTime").val()>=$("#txtEndDateTime").val()){
            alert("开始日期不能大于等于结束日期!");
            return false;
        }
                
    }
    //获取人员列表
    var sltEmployeeListOptions=$("select[@name='sltEmployee']")[0];
    var strEmployeeList="";
    for(var index=0;index<sltEmployeeListOptions.length;index++){
        if(sltEmployeeListOptions[index].selected && sltEmployeeListOptions[index].value!=""){
           strEmployeeList+=" "+$(sltEmployeeListOptions[index]).text();
        }
    }
    $("#hiddEmployeeList").val(strEmployeeList);
}