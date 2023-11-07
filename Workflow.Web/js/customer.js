// JScript 文件

function preventSelectDisabled(oSelect) {    
     var isOptionDisabled = oSelect.options[oSelect.selectedIndex].disabled;    
     if(isOptionDisabled) {
     oSelect.selectedIndex = oSelect.defaultSelectedIndex;
        return false;
   } else 
    oSelect.defaultSelectedIndex = oSelect.selectedIndex;
    return true;
}

function  comparedTime()
{
  
   var fromTime = document.getElementById(txtFrom).innerHTML.replace(^-/g,"/");
   var toTime = document.getElementById(txtTo).innerHTML.replace(^-/g,"/");
   
   var fromDateTime = new Date(fromTime);
   var toDateTime = new Date(toTime);
   
   if(fromDataTime > toDateTime)
   {
     alert("开始时间不能小于结束时间");
     return false;
   }
   else
   {
     return true;
   }
}
