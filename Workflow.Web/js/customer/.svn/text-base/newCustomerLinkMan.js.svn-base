// 名    称: newCustomerLinkMan.js
// 功能概要: 客户联系人 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:

//功能 :Esc键 关闭页面
//作者 :陈汝胤
//日期 :2009-1-16

document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    var e=e|| event;
    if(e.keyCode==27)
        window.close();
}

//功能 :增加或修改联系人页面提交
//作者 :陈汝胤
//日期 :2009-1-16
saveLinkMan=function(){
    if(checkSubmit()){
        $("#form1").submit();
        window.returnValue="ok";
        window.close();
    }
}

//功能 :页面数据提交验证
//作者 :陈汝胤
//日期 :2009-1-16
checkSubmit=function(){
    var txtName=$("input:text[@name=txtName]").val();
    if(txtName.length==0){
        $("input:text[@name=txtName]").select();
        alert("联系人名称不能为空!");
        return false;
    }
    if(txtName.length>30){
        $("input:text[@name=txtName]").select();
        alert("联系人名称不能为空!");
        return false;
    }
    var txtAge=$("input:text[@name=txtAge]").val();
    if(isNaN(txtAge)){
        $("input:text[@name=txtAge]").select();
        alert("年龄必须是数字!");
        return false;
    }
    if(txtAge.length>2 || txtAge==0){
        $("input:text[@name=txtAge]").select();
        alert("年纪范围:1-99!");
        return false;
    }
    var txtCompanyPhone=$("input:text[@name=txtCompanyPhone]").val();
    if(!(/^\d+((\-)|(\d))\d+$/.test(txtCompanyPhone))){
        $("input:text[@name=txtCompanyPhone]").select();
        alert("电话号码格式有误!");
        return false;
    }
    if(txtCompanyPhone.length>20){
        $("input:text[@name=txtCompanyPhone]").select();
        alert("电话号码太长了!");
        return false;
    }
    var txtCompanyPhone=$("input:text[@name=txtPosition]").val();
    if(txtCompanyPhone.length>25){
        $("input:text[@name=txtPosition]").select();
        alert("职务信息太多了!");
        return false;
    }
    var txtHobby=$("input:text[@name=txtHobby]").val();
    if(txtHobby.length>50){
        $("input:text[@name=txtHobby]").select();
        alert("爱好信息太多了!");
        return false;
    }
    var txtMobilePhone=$("input:text[@name=txtMobilePhone]").val();
    if(isNaN(txtMobilePhone) || txtMobilePhone.length>20){
        $("input:text[@name=txtMobilePhone]").select();
        alert("移动电话格式有误!");
        return false;
    }
    var txtQQ=$("input:text[@name=txtQQ]").val();
    if(isNaN(txtQQ) || txtQQ.length>12){
        $("input:text[@name=txtQQ]").select();
        alert("QQ格式有误");
        return false;
    }
    var txtEMail=$("input:text[@name=txtEMail]").val();
    if(!(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(txtEMail)) && txtEMail.length>0){
        $("input:text[@name=txtEMail]").select();
        alert("EMail格式有误");
        return false;
    }
    if(txtEMail.length>30){
        $("input:text[@name=txtEMail]").select();
        alert("EMail信息太多了");
        return false;
    }
    var txtAddress=$("input:text[@name=txtAddress]").val();
    if(txtAddress.length>50){
        $("input:text[@name=txtAddress]").select();
        alert("地址信息太多了");
        return false;
    }
    var txtMemo=$("textArea[@name=txtMemo]").html();
    if(txtMemo.length>100){
        $("input:text[@name=txtMemo]").select();
        alert("备注信息太多了");
        return false;
    }
    return true;
}

