﻿// JScript 文件
//功能: 颜色选择器
//作者: 张晓林
//日期: 2010年5月20日10:51:54

var SelRGB = '#000000';
var DrRGB = '';
var SelGRAY = '120';
var hexch = new Array('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F');

// 声明一个全局对象Namespace，用来注册命名空间
Namespace = new Object();
// 全局对象仅仅存在register函数，参数为名称空间全路径，如"Grandsoft.GEA"
Namespace.register = function(fullNS){
    // 将命名空间切成N部分, 比如Grandsoft、GEA等
   var nsArray = fullNS.split('.');
   var sEval = "";
   var sNS = "";   
   for (var i = 0; i < nsArray.length; i++){
        if (i != 0) sNS += ".";
        sNS += nsArray[i];
        // 依次创建构造命名空间对象（假如不存在的话）的语句
        // 比如先创建Grandsoft，然后创建Grandsoft.GEA，依次下去
        sEval += "if (typeof(" + sNS + ") == 'undefined') " + sNS + " = new Object();"
    }
    if (sEval != "") eval(sEval);  
}
    
// 注册命名空间Grandsoft.GEA, Grandsoft.GCM
Namespace.register("SelectColor");

SelectColor.Obj = function(){}
//SelectColor.Obj.prototype = {
//    getRGB  :function (){    return document.getElementById("RGB");},
//    getGRAY :function (){    return document.getElementById("GRAY");},
//    getGrayTable    :function (){    return document.getElementById("GrayTable");},
//    getSelColor     :function (){    return document.getElementById("SelColor");},
//    getShowColor    :function (){    return document.getElementById("ShowColor");}
//}
var colorObj = new SelectColor.Obj;
SelectColor.ToHex = function (n){ 
    var h, l;
    n = Math.round(n);
    l = n % 16;
    h = Math.floor((n / 16)) % 16;
    return (hexch[h] + hexch[l]);
}

SelectColor.DoColor = function (c, l){ 
    var r, g, b;
    r = '0x' + c.substring(1, 3);
    g = '0x' + c.substring(3, 5);
    b = '0x' + c.substring(5, 7);
    if(l > 120){
        l = l - 120;
        r = (r * (120 - l) + 255 * l) / 120;
        g = (g * (120 - l) + 255 * l) / 120;
        b = (b * (120 - l) + 255 * l) / 120;
    }
    else{
        r = (r * l) / 120;
        g = (g * l) / 120;
        b = (b * l) / 120;
    }
    return '#' + this.ToHex(r) + this.ToHex(g) + this.ToHex(b);
}

SelectColor.GetFirefoxColorValue = function (c){
    var r, g, b;
    var ch = c.substring(4, c.length -1);
    var chs = new Array();
    chs = ch.split(",");
    r = chs [0];//'0x' + ch.substring(1, 3);
    g = chs [1];//'0x' + ch.substring(3, 5);
    b = chs [2];//'0x' + ch.substring(5, 7);

    return '#' + this.ToHex(r) + this.ToHex(g) + this.ToHex(b);
}

//事件
SelectColor.clickColorTable = function (event){

    if(event.srcElement!=null ){
        eventObj = event.srcElement;
        SelRGB = eventObj.style.backgroundColor.toUpperCase();
    }
    else{
        eventObj = event.target
        SelRGB = this.GetFirefoxColorValue(eventObj.style.backgroundColor.toUpperCase());
    }
    //this.EndColor();
    
    var color=new Object();
    color.RGB=SelRGB;
    window.opener.callBackBindColor(color);
    window.close();
}

SelectColor.clickGrayTable = function (event){
    var eventObj;
    if(event.srcElement!=null ){
        eventObj = event.srcElement;
        SelRGB = eventObj.style.backgroundColor.toUpperCase();
    }
    else{
        eventObj = event.target
    }
    SelGRAY = eventObj.title;
    var color=new Object();
    color.RGB=SelRGB;
    window.opener.callBackBindColor(color);
    window.close();
}

//回车提交,Esc键关闭窗体
document.onkeydown=function(){
　　var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;		
	if (evt.keyCode==27){
		window.close();
	}
}
