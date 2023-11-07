var source;
var factorCount = 0;
var trHtmlText = "";

$(document).ready(function() {
    var table = $("#tblMainTable");
    var lastTr = $("tr:last-child", table);
    trHtmlText = lastTr.html();
//    $('#txtPrepayMoney').hide();
});
function addRow() {
    
    var table = $("#tblMainTable");
    var lastIndex = $("td:first-child", $("tr:last-child", table)).html();
    var tr = $("<tr>" + trHtmlText + "</tr>");
    var sltArr=$("select",tr);
    var txtArr=$("input:text",tr);
    var hiddenArr=$("input:hidden[type!='button']",tr);
    var tdArr=$("td",tr);
    tr.appendTo(table);
//    $(tr.children()[0]);
    lastIndex = parseInt(lastIndex) + 1;
    $("td:first-child", $("tr:last-child", table)).html(lastIndex);
//    
    var inputHideArr=$("input:hidden",tr);
    $(inputHideArr[0]).attr("id","txtOrder"+lastIndex);
    $(inputHideArr[0]).attr("name","txtOrder"+lastIndex);
    $(inputHideArr[1]).attr("id","txtMachine"+lastIndex); 
    $(inputHideArr[1]).attr("name","txtMachine"+lastIndex);
    $(inputHideArr[2]).attr("id","txtPaperSpecification"+lastIndex);
    $(inputHideArr[2]).attr("name","txtPaperSpecification"+lastIndex);    
    $(inputHideArr[3]).attr("id","txtColor"+lastIndex); 
    $(inputHideArr[3]).attr("name","txtColor"+lastIndex);
    //数量
//    $(txtArr[0]).attr("id","txtAmount"+lastIndex);
//    $(txtArr[0]).attr("name","txtAmount"+lastIndex);
}

function refreshRowNo() {
    var table = $("#tblMainTable");
    var trs = $("tr", table);
    trs.each(function(i){
        if (i == 0) return;
        $("td:first-child", $(this)).html(i);
        var hiddenTxt=$("input:hidden",this);
        var txt=$("input:text",this);
        $(hiddenTxt[0]).attr("id","txtOrder"+i);
        $(hiddenTxt[0]).attr("name","txtOrder"+i);
        $(hiddenTxt[1]).attr("id","txtMachine"+i);
        $(hiddenTxt[1]).attr("name","txtMachine"+i);
        $(hiddenTxt[2]).attr("id","txtPaperSpecification"+i);
        $(hiddenTxt[2]).attr("name","txtPaperSpecification"+i);    
        $(hiddenTxt[3]).attr("id","txtColor"+i);
        $(hiddenTxt[3]).attr("name","txtColor"+i);
        $(txt[0]).attr("id","txtAmount"+i);
        $(txt[0]).attr("name","txtAmount"+i);
    });
}
function delRow(button) {
    var table = $("#tblMainTable");
    if ($("tr", table).length <= 2) return;
    $(button).parent().parent().remove();
    refreshRowNo();
    
}
function hideControl(button)
{
    var lastIndex=parseInt($($("td",$(button).parent().parent())[0]).text());
    
    //获得当前行的select控件
    var sltArr=$("select",$(button).parent().parent());
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].options[sltArr[i].selectedIndex].value==0)
        {
            sltArr[i].focus();
            alert('您还没有选择');
            return;
        }
    }
    
    
    //获得当前行的text控件
    var txtArr=$("input[@type='text']",$(button).parent().parent());
    if (!checkOnlyNum($(txtArr),false,5))
    {
      txtArr[0].focus();
      txtArr[0].select();
      return false;
    }
    //判断数字合法性
     
     //移除
    $("span",$(button).parent().parent()).remove();
    
    //select框内容赋值
    for(var i=0;i<sltArr.length;i++)
    {
        var strTmp='<span>'+sltArr[i].options[sltArr[i].selectedIndex].text+'</span>';
        $(strTmp).appendTo(sltArr[i].parentNode);
        $(sltArr[i]).hide();
    }
    //text文本框内容赋值
    for(var i=0;i<txtArr.length;i++)
    {
        var strTmp='<span>'+txtArr[i].value+'</span>';
        $(strTmp).appendTo(txtArr[i].parentNode);
        $(txtArr[i]).hide();
    }
    

    //控制button的显示和隐藏
    $($("input",$(button).parent())[1]).show();
    $(button).hide();
    $("input[@type='text']",$(button).parent().parent()).hide();
    
    //给隐藏控件赋值
    $("#txtOrder"+lastIndex).attr("value",sltArr[0].value);
    $("#txtMachine"+lastIndex).attr("value",sltArr[1].value);
    $("#txtPaperSpecification"+lastIndex).attr("value",sltArr[2].value);
    $("#txtColor"+lastIndex).attr("value",sltArr[3].value);
}
function editItem(button)
{
    var lastIndex=parseInt($($("td",$(button).parent().parent())[0]).text());
    var sltArr=$("select",$(button).parent().parent());
    var spArr=$("span",$(button).parent().parent());
    $(spArr).hide();
    $("span",spArr).hide();
//    $("#factorid"+lastIndex).attr("value","");
//    $("#factorvalue"+lastIndex).attr("value","");
//    $("#txtPriceFactor"+lastIndex).attr("value");
    
    for(var i=0;i<sltArr.length;i++)
    {
        $(spArr[i]).hide();
        $(sltArr[i]).show();
    }
    
    $($("input",$(button).parent())[0]).show();
    $("input[@type='text']",$(button).parent().parent()).show();
    $(button).hide();
}

  function doCheckProcess()
  {
  
    var txtNewNumber =$("input:text[@name^=txtNewNumber]")
    var blnCheck=true;
    var txtOldNumber;
    var ctrName;
    txtNewNumber.each(function(i,txt)
    {
        if (!checkOnlyNum($(txt),false,5))
        { 
          txt.focus();
          txt.select();
          blnCheck=false;
          return false;
        }
        //如果合法则判断是否比原值小,如果比原值小则退出
        ctrName=txt.name.replace('New','Old');
        txtOldNumber=$("input:hidden[@name^="+ctrName+"]",$(txt).parent());
        
        if (parseInt($(txt).val())<parseInt($(txtOldNumber).val()))
        {
          alert('新抄表读数不能小于上次抄表读数,请确认.');
          txt.focus();
          txt.select();
          blnCheck=false;
          return false;
        }
    }
    );
  
    if (!blnCheck)
    {
      return false;
    }
    
    var table = $("#tblMainTable");
    //var blnCheck=true;
    var select=$("select",table);
   //循环检测select框
    select.each(function(i,slt)
    {
      if(slt.value==0)
      {
        alert('请选择!');
        slt.focus();
        blnCheck=false;
        return false;
      }
    }
    );
    
    if (!blnCheck)
    {
      return false;
    }
    //循环检测文本框
    var text=$("input:text[@name=txtAmount]",table);
    text.each(function(i,txt)
    {
       if (!checkOnlyNum($(txt),false,5))
       {
          txt.focus();
          txt.select();
          blnCheck=false;
          return false;
       }
    }
    );
    if (!blnCheck)
    {
      return false;
    }
    
//    alert('submit');
//    return false;
    return true;
  }