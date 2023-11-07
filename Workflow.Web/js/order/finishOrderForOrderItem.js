// JScript 文件

$().ready(function (){
    if($("#actionTag").val()!="Finish")
    {
        var orderNo=$("#txtOrderNo").val();
        var customerName=$("#txtCustomerName").val();
        createContainer(orderNo,customerName,1,document.forms[0].id);
    }
//    else
//        window.close();
}
);

//function selectEmployee(){
//    var orderNo=$("#txtOrderNo").val();
//    createContainer(orderNo);
//}