// JScript 文件

function doCheckProcess()
{
  //机器
  if ($("#sltMachine").val()==0)
  {
    alert('请选择机器!');
    $("#sltMachine").focus();
    $("#sltMachine").select();
    return false;
  }

  //纸型
  if ($("#sltPaperSpecification").val()==0)
  {
    alert('请选择纸型!');
    $("#sltPaperSpecification").focus();
    $("#sltPaperSpecification").select();
    return false;
  }
 
  //颜色
  if ($("#sltColor").val()==0)
  {
    alert('请选择颜色!');
    $("#sltColor").focus();
    $("#sltColor").select();
    return false;
  }
  
  //数量
  if (!checkOnlyNum($("#txtAmount"),false,5))
  {
    $("#txtAmount").focus()
    $("#txtAmount").select();
    return false;
  }
  var checkbox=$("input:checkbox[@name=chkEmployee]");
  var count=0;
  checkbox.each(function(i,chk){
    if (chk.checked)
    { count++;}
  }
  );
  if (count==0)
  {
    alert('请至少选择一个人员!');
    return false;
  }
  
  //备注
  var memo=$("#txtMemo");
  if(memo.val().length>50)
  {
    alert('您输入的字符数超长!'); 
    memo.focus();
    memo.select();
    return false;
  }
  return true;
}