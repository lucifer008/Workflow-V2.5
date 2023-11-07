//时间比较
//Author:Cry Date2008-12-27
//时间格式:　"2008-02-02 7:30"　　　"2008-03-31 8:30"
function CompareDate(d1,d2)
{
   return ((new Date(d1.replace(/-/g,"\/"))) > (new Date(d2.replace(/-/g,"\/"))));
}

//获取时间差.分钟
//Author:Cry Date2008-12-27
//时间格式:　"2008-02-02 7:30"　　　"2008-03-31 8:30"
function minuteDifference(d1,d2)
{
    if(undefined==d2) return null;//处理没有取到服务器时间的情况
    if(CompareDate(d1,d2)){
        return ((new Date(d1.replace(/-/g,"\/"))) - (new Date(d2.replace(/-/g,"\/"))));   
    }
    else{
        return ((new Date(d2.replace(/-/g,"\/"))) - (new Date(d1.replace(/-/g,"\/"))));  
    }
}



