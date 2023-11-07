// JScript 文件
//功能: 选项卡实现
//作者: 张晓林
//日期: 2010年5月14日9:43:20

function selecedCard(){
    var tag=$("#actionTag").val();
    $("#"+tag).attr("style","background:url(/images/index3-10_r4_c22.jpg)");
}

function bindCardOptionData(o){
    var id=$(o).attr("id");
    $("#actionTag").val(id);
    $(o).attr("disabled",true);
    $("#form1").submit();
}
$(document).ready(function(){
  selecedCard();  
});

function TagSubmit(){
    $("#paginationTag").val("true");
}