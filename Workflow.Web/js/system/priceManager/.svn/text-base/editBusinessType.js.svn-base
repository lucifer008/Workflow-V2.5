// JScript 文件

function savePriceSet(){
    if ($("#txtBusinessName").val()=="")
    {
      alert('请输入业务类型');
      $("#txtBusinessName").focus();
      return false;
    }
    var select=$("input:checkbox[@name=chkFactor]");
    var intcount=0;
    select.each(function(i,opt){
      if (opt.checked)
      {intcount++;}
    }
    );
    if (intcount==0)
    {
      alert('请至少选择一种因素');
      return false;
    }
    $("#txtAction").attr("value","4");
    $("#MainForm").submit();
}