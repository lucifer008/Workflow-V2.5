// JScript 文件
function keyevent(o)
{
    var obj=document.getElementById(o.id);
    
    var len = obj.value.length;
    if (len == 3) {
        window.setTimeout("addFlag('" + o.id +"', 4, '-')", 200);
    } else if (len == 6) {
        window.setTimeout("addFlag('" + o.id +"', 7, '-')", 200);
    } else if (len == 10) {
        window.setTimeout("addFlag('" + o.id +"', 10, ' ')", 200);
    } else if (len == 13) {
        window.setTimeout("addFlag('" + o.id +"', 13, ':')", 200);
    } else if (len == 19) {
        window.setTimeout("addFlag('" + o.id +"', 10, ' ')", 200);
    }
    // 2007-01-01 14:32
    
    
}
function addFlag(id, pos, text) 
{
    
    var obj=document.getElementById(id);
    
    if (obj.value.length < pos) return;
    
    obj.value =  obj.value.substring(0, pos) + text + obj.value.substring(pos);
}

//短时间，形如 (13:04:06)
function isTime(str)
{
    //var a = str.match(/^(d)(:)?(d)2(d)$/);
   var reg="(0?[0-9]|[1-2][0-3])(:)(0?[0-9]|[0-5][0-9])";
 //   var reg="((0?[0-9])|([1-2][0-3]))\:([0-5]?[0-9])";//((\s)|(\:([0-5]?[0-9])))"
    //var a = str.match("([0-9]|[01][0-9]|2[0-3])(:([0-9]|[0-5][0-9])){0,2}|(0?[0-9]|1[0-1])");
     var a=str.match(reg);
    if (a == null) {alert('您输入的时间有误！！'); return false;}
    if (a[1]>24 || a[3]>60 || a[4]>60)
    {
        alert("时间格式不对");
        return false
    }
    return true;
}

//短日期，形如 (2003-12-05)
function isDate(str)
{
    //var r = str.match("/^(d)(-│/)(d)2(d)$/");
    var reg="[1-2][0-9]{3}\-(0?[1-9]|10|11|12)\-(0?[1-9]|[1-2][0-9]|30|31)";
    var r = str.match(reg);
    //var r = str.match("/^([1-2]\d{3})[\/|\-](0?[1-9]|10|11|12)[\/|\-]([1-2]?[0-9]|0[1-9]|30|31)$/");
    
    if(r==null){
        //alert('您输入的日期有误！！');
        return false;
    }
    var d= new Date(r[1], r[3]-1, r[4]);
    //return (d.getFullYear()==r[1] && (d.getMonth()+1)==r[3] && d.getDate()==r[4]);
    
    if((d.getFullYear()==r[1] || (d.getMonth()+1)==r[3] || d.getDate()==r[4]))
    {
        //alert("日期格式不正确！！");
        return false;
    }
    return true;
    
}


//长时间，形如 (2003-12-05 13:04)
function isDateTime(str)
{
    var reg ="[1-2][0-9]{3}-[1-9|10|11|12]{1,2}-(0[1-9]|[1][0-9]|2[0-9]|30|31) ([0-1][0-9]|2[0-3]):[0-5][0-9]";
    var r = str.match(reg);
    if(r==null){
        //alert('您输入的日期时间格式有误!! 格式如2008-01-01 08:10');
        return false;
    }
    var d= new Date(r[1], r[3]-1,r[4],r[5],r[6],r[7]);
    //    return (d.getFullYear()==r[1] && (d.getMonth()+1)==r[3] && d.getDate()==r[4] && d.getHours()==r[5] && d.getMinutes()==r[6] && d.getSeconds()==r[7]);
      if(d.getFullYear()==r[1] || (d.getMonth()+1)==r[3] || d.getDate()==r[4] || d.getHours()==r[5] || d.getMinutes()==r[6] || d.getSeconds()==r[7])
      {
        //alert("格式不正确！！");
        return false;
      }
      return true;
}    

function lostFocus(o)
{
    var objStr=document.getElementById(o.id).value.toString();
    if(!isDateTime(objStr))
    {
        o.value="";
        o.setCapture(true);
    }
}
