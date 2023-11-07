
   /*
    //文 件 名：permission.js
    //功能描述：操作管理Js		 
	//创建时间：2008-11-5
	//创 建 人: 张晓林
	//修改时间：
    //修改描述：
*/

// 功能: 编辑权限操作
// 作者: 张晓林
// 日期: 2008-11-5
function EdmitPermission(permissionId)
{
      var yes=showPage("NewPermission.aspx?PermissionId="+escape(permissionId),"curWindow",800,700,false,true,false);
      if(yes)
      {
        $("#hiddTag").val("Edmit");
        $("#form1").submit();
      }
}

// 功能: 删除权限操作
// 作者: 张晓林
// 日期: 2008-11-5
function DeletePermission(permissionId)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
        $("#hiddTag").val("Delete");
        $("#hiddPermissionId").val(permissionId);
        $("#form1").submit();
    }
}

// 功能: 添加权限操作验证
// 作者: 张晓林
// 日期: 2008-11-5
function AddPermission()
{
   if($("#txtPermissionName").val()=="")
   {
       alert("操作名称不能为空!");
      $("#txtPermissionName").focus(); 
      return false; 
   }       
   $("#hiddTag").val("Add");
   $("#form1").submit();
}
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    var e=e|| event;
    if(e.keyCode==27)
        window.close();

}
