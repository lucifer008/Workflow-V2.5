
/*
//文 件 名：users.js
//功能描述：用户管理Js		 
//创建时间：2008-11-5
//创 建 人: 张晓林
//修改时间：
//修改描述：
*/

///名    称: UserDataCheck
///功能概要: 添加用户数据验证
///作    者：张晓林
///创建时间:
///修正履历:
///修正时间:
function UserDataCheck()
{
	if(""==$("#txtUserName")[0].value)
	{
		alert("用户名称不能为空");
		$("#txtUserName")[0].select();
		$("#txtUserName")[0].focus();
		return false;
	}
	if(""==$("#txtUserPassword")[0].value)
	{
		alert("密码不能为空");
		$("#txtUserPassword")[0].select();
		$("#txtUserPassword")[0].focus();
		return false;
	}
	
	var UserRoleLength=$("input:checkbox[@name=cbBoxRole]").length;
	var UserRole=$("input:checkbox[@name=cbBoxRole]");
	var Count=0;
	for(var i=0;i<UserRoleLength;i++)
	{
		if(UserRole[i].checked)
		{
			Count++;
		}
	}
	if(Count==0)
	{
		alert("至少选择一个角色!");
		return false;
	}
	
	if(""!=$("#tr1").html())
	{
	
	    if(""==$("#txtMinApplyZero").val())
	    {
	         alert("抹零金额不能为空!");
	         $("#txtMinApplyZero").focus();
	         return false;
	    }
	    
	    if(""==$("#txtMaxApplyZero").val())
	    {
	        alert("抹零金额不能为空!");
	        $("#txtMaxApplyZero").focus();
	        return false;
	    }
	    
	    if(""==$("#txtMinConcessionMoney").val() )
	    {
	         alert("优惠比例不能为空!");
	        $("#txtMinConcessionMoney").focus();
	        return false;
	    }
	     
	    if(""==$("#txtMaxConcessionMoney").val())
	    {
	        alert("优惠比例不能为空!");
	        $("#txtMaxConcessionMoney").focus();
	        return false;
	    }
	    
	     if(""==$("#txtMinDiscountMoney").val())
	    {
	         alert("折让比例不能为空!");
	        $("#txtMinDiscountMoney").focus();
	        return false;
	    }
	    
	    
	    if(""==$("#txtMaxDiscountMoney").val())
	    {
	        alert("折让比例不能为空!");
	        $("#txtMaxDiscountMoney").focus();
	        return false;
	    }
	    
	    if(""==$("#txtMinDiscountMoney").val())
	    {
	         alert("折让比例不能为空!");
	        $("#txtMinDiscountMoney").focus();
	        return false;
	    }
	    
	    if(!isNumber($("#txtMaxApplyZero").val()))
	    {
	        alert("抹零金额格式输入不正确!");
	        $("#txtMaxApplyZero").select();
	        $("#txtMaxApplyZero").focus();
	        return false;
	    }
	    if(!isNumber($("#txtMinApplyZero").val()))
	    {
	        alert("抹零金额格式输入不正确!");
	        $("#txtMinApplyZero").select();
	        $("#txtMinApplyZero").focus();
	        return false;
	    }
	    
	    if(!isNumber($("#txtMaxConcessionMoney").val()))
	    {
	        alert("优惠比例格式输入不正确!");
	        $("#txtMaxConcessionMoney").select();
	        $("#txtMaxConcessionMoney").focus();
	        return false;
	    }
	    if(!isNumber($("#txtMinConcessionMoney").val()))
	    {
	        alert("优惠比例格式输入不正确!");
	        $("#txtMinConcessionMoney").select();
	        $("#txtMinConcessionMoney").focus();
	        return false;
	    }
	    
	    if(!isNumber($("#txtMaxDiscountMoney").val()))
	    {
	        alert("折让比例格式输入不正确!");
	        $("#txtMaxDiscountMoney").select();
	        $("#txtMaxDiscountMoney").focus();
	        return false;
	    }
	    if(!isNumber($("#txtMinDiscountMoney").val()))
	    {
	        alert("优惠比例格式输入不正确!");
	        $("#txtMinDiscountMoney").select();
	        $("#txtMinDiscountMoney").focus();
	        return false;
	    }
	    $("#hiddTag").val("True");   
	}
	return true;
}

///名    称: SelectedCheckBox
///功能概要: 单击Checkbox标签选中CheckBox
///作    者：张晓林
///创建时间:
///修正履历:
///修正时间:
function SelectedCheckBox(obj,userRoleId)
{
    if(!obj.disabled)
    {
        obj.checked=!obj.checked;
    }
    AddRolePermission(userRoleId);
}


///名    称: EdmitUser
///功能概要: 编辑用户链接
///作    者：张晓林
///创建时间:
///修正履历:
///修正时间:
function EdmitUser(userId,roleId)
{
   var o=showPage("NewUsers.aspx?UserId="+escape(userId)+"&RoleId="+escape(roleId),"curWindow",890,566,false,true,null,true);
   if(o=='yes'){
        $("#hiddTag").val("Edmit");
        $("#form1").submit();
   }
}

///名    称: DeleteUser
///功能概要: 删除用户
///作    者：张晓林
///创建时间:
///修正履历:
///修正时间:
var uId,rleId=0;
function DeleteUser(userId){
    var yes=confirm("确认删除?");
    if(yes){
        var url='../../ajax/AjaxEngine.aspx?UserId='+userId; 
        uId= userId; 
        $.getJSON(url,{a:'21'},processJson1);
        $("#hiddTag").val("Delete");
        $("#hiddUserId").val(uId);
        $("#form1").submit();
   }
}
function processJson1(jsoin){}
	
function btnCancelClose(){
    window.close();
    return true;
}

//按下Esc键取消弹出的窗体
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    var e=e|| event;
    if(null!=e && e.keyCode==27)
        window.close();
    if(13==e.keyCode){
        $("#btn").click();
        return false;
    }
}

//检查用户名称是否已经存在
function CheckUserNameIsExist(){
    var userName=$("#txtUserName").val();
    if(""!=userName){
        var url="../../ajax/AjaxEngine.aspx?UserName="+escape(userName)+"&Tag=1";
         $.getJSON(url,{a:'23'},processJson);
    }
}
function processJson(json){
    if(json==null){
        return true;
    } 
    else if(json=="1"){
       alert("该用户名已经存在!请重新输入!");
      $("#txtUserName").focus(); 
      $("#txtUserName").val("");    
      return false; 
    }
    else{
        return true;
    }
}

//判断当选中的角色为:店长，管理元，收银时:必须添加 :抹零，折让，优惠数据
$(document).ready(function() {
    //concessDiscountApplyDetail=$("#tr1").html();
    if(""==$("#hiddUserId").val())//添加
    {
        $("#tr1").html("");
    }
});

//显示 优惠范围
function AddRolePermission(userRoleId){
   var tag=false;
   if(userRoleId==managerId || userRoleId==casherId || userRoleId==masterId){
      tag=true;
   }
   if(tag){ 
       if(""==$("#tr1").html()){
          if(managerId==currentUserRoleId){//当前用户为管理员才能维护优惠信息
            $("#tr1").html(concessDiscountApplyDetail); 
          }
       }
        CheckTag();
   }
}

//当用户的角色为(店长，管理员,经理)中的一个时，显示：设置抹零，优惠,折让，否则不显示
function CheckTag(){
    var UserRoleLength=$("input:checkbox[@name=cbBoxRole]").length;
    var UserRole=$("input:checkbox[@name=cbBoxRole]");
    var Count=0;
    for(var i=0;i<UserRoleLength;i++){
	    if(UserRole[i].checked && (managerId==UserRole[i].value || casherId==UserRole[i].value || masterId==UserRole[i].value) ){
		    Count++;
	    }
    }
    if(0==Count){
        $("#tr1").html("");
    } 
}

///名    称: LoadUserInfo
///功能概要: 绑定用户编辑数据
///作    者：张晓林
///创建时间:
///修正履历: 修改兼容其他浏览器
///修正时间: 2009年9月7日13:53:10
function LoadUserInfo()
{
    try
    {
         var roLength=$("[@name=cbBoxRole]").length;//document.form1.cbBoxRole.length;;
         var roleList= $("[@name=cbBoxRole]");//document.form1.cbBoxRole;
        if(0!=userId)
        {
            $("#hiddUserId").val(userId);
            $("#hiddIsLogin").val(isLogin);
            $("#txtUserName").val(userName);
            $("#txtUserPassword").val(passWord);
            //隐藏密码行
	        var table=document.getElementsByTagName("table")[2];//获取页面第三个table document.all.tags('table')[2];//IE支持,Firefox不支持
	        //table.rows[2].style.display="none";
	        $("#trPassWord").hide();
	        table.rowSpan=3;
	        $("#btnCancel").show();
	        var employeeListLength=$("select[@name=sltEmployee]")[0].length;//document.form1.sltEmployee.options.length;
	        var employeeList=$("#sltEmployee");//document.form1.sltEmployee.options;
	        for(var i=0;i<employeeListLength;i++){
	            if(employeeId==$(employeeList[0][i]).attr("value")){
	              $(employeeList[0][i]).attr("selected",true);//employeeList[i].selected="selected";
	            }
	        }
            for(var i=0;i<roLength;i++){
               for(var j=0;j<arr.length;j++){
                   if($(roleList[i]).attr("value")==arr[j]){
                      $(roleList[i]).attr("checked",true);
                   }
               }
            }
            if(managerId==currentUserRoleId){
                $("#tr1").html(concessDiscountApplyDetail);
                CheckTag();          
            }
            else{
                 $("#tr1").html("");
            }
            //CheckTag();
        }
        if(masterId==currentUserRoleId){//当前用户的职位为店长时,//管理员职位不可用 
          for(var index=0;index<roLength;index++){
             if(managerId==$(roleList[index]).attr("value")){
                 $(roleList[index]).attr("disabled",true);
             }
          }           
        } 
    }
    catch(e)
    {
        alert(e);
    }
}