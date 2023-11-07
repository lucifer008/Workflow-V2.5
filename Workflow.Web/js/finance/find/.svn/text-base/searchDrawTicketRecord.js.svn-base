// JScript 文件
/// <summary>
/// 功能概要: 补领发票记录JS
/// 作    者: 张晓林
/// 创建时间: 2009年12月29日
/// 修正履历:
/// 修正时间:
/// </summary>


//功能: 发票领取记录查询验证  
//作者: 张晓林
//日期: 2009年12月29日
function queryDataCheck(){
    var beginDate=$("#txtBeginDateTime").val();
    var endDate=$("#txtEndDateTime").val();
    if(""!=beginDate && ""!=endDate){
        if(beginDate>endDate){
            alert("开始时间不能大于结束时间!");
            return false;
        }
    }
}