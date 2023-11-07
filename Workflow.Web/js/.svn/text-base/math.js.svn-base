// JScript 文件

//功能 :浮点减法 解决js 浮点运算问题
//作者 :付强
//日期 :2008-12-19
//arg1: 被减数 arg2 减数
function fltSub(arg1,arg2)
{
    if(undefined==arg1 || undefined==arg2) return 0;
    var r1,r1,m,n;
    try{
        r1=arg1.toString().split(".")[1].length;
    }
    catch(e){
        r1=0;
    }
    try{
        r2=arg2.toString().split(".")[1].length;
    }
    catch(e){
        r2=0;
    }
    m=Math.pow(10,Math.max(r1,r2));
    
    n=(r1>r2)?r1:r2;
    return (fltDiv((fltMul(arg1,m)-fltMul(arg2,m)),m)).toFixed(n);
}
//功能 :浮点加法 解决js 浮点运算问题
//作者 :付强
//日期 :2008-12-19
//arg1: arg2 
function fltAdd(arg1,arg2)
{
    if(undefined==arg1 || undefined==arg2) return 0;
    var r1,r2,m,retVal;
    try{
        r1=arg1.toString().split(".")[1].length;
    }
    catch(e){
        r1=0;
    }
    try{
        r2=arg2.toString().split(".")[1].length;
    }
    catch(e){
        r2=0;
    }
    m=Math.pow(10,Math.max(r1,r2));
    return fltDiv((fltMul(arg1,m)+fltMul(arg2,m)),m);
}

//功能 :浮点除法 解决js 浮点运算问题
//作者 :付强
//日期 :2008-12-19
//arg1: arg2 
function fltDiv(arg1,arg2)
{
    if(undefined==arg1 || undefined==arg2) return 0;
    var t1=0,t2=0,r1,r2;
    try{
        t1=arg1.toString().split(".").length;
    }
    catch(e){      
    }
    try{
        t2=arg2.toString().split(".").length;
    }
    catch(e){
    }
    with(Math){
        r1=Number(arg1.toString().replace(".",""));
        r2=Number(arg2.toString().replace(".",""));
        return (r1/r2)*pow(10,t2-t1);
    }
}
//功能 :浮点乘法 解决js 浮点运算问题
//作者 :付强
//日期 :2008-12-19
//arg1: arg2 
function fltMul(arg1,arg2)
{
    if(undefined==arg1 || undefined==arg2) return 0;
    var m=0,s1=arg1.toString(),s2=arg2.toString();
    try{
        m+=s1.split(".")[1].length;
    }
    catch(e){
    }
    try{
        m+=s2.split(".")[1].length;
    }
    catch(e){
    }
    return Number(s1.replace(".",""))*Number(s2.replace(".",""))/Math.pow(10,m);
    
}

//功能 :浮点除法 解决js 浮点运算问题
//作者 :陈汝胤
//日期 :2009.5.31
formatFloat=function(val,pos){
	var m=val.toString().split('.');
	if(m.length<1)
		return val;
	return Math.round(val*Math.pow(10,pos))/Math.pow(10,pos);
}
