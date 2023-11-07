function FormatMoney(m,c)
{
    if(d=='undefined')
    {
        return 0.00;
    }
    if(c=='undefined')
    {
        c=2;
    }
    var t=m.toString().split(".");
    
    var p,d="";
    if(t.length<=1)
    {
        for(x=0;x<c;x++)
        {
            d+="0";
        }
    }
    else
    {
        for(i=0;i<c;i++)
        {
            m*=10;
        }
        m=Math.round(m);
        d=m.toString().substr(m.toString().length-c,c);
    }
    var val;
    var returnValue="";
    var p=0;
    for(p=t[0].length;p>1;p-=3)
    {
        if(p-3>=0)
        {
            val=t[0].substr(p-3,3);
        }
        else
        {
            val=t[0].substr(0,p);
        }
        if(val.length>=3)    
        {
            returnValue=","+val+returnValue;
        }
        else
        {
            returnValue=val+returnValue;
        }
    }
    if((p % 3)>0)
    {
        val=t[0].substr(0,p);
        return val+returnValue+"."+d;
    }
    var index=returnValue.indexOf(",");
    if(index==0)
    {
        returnValue=returnValue.substr(1,returnValue.length);
    }
    
    return returnValue+"."+d;
}




/// <summary>
/// 名    称: checkComboxNotEmpty
/// 功能概要: 
/// 作    者: 麻少华
/// 创建时间: 2007-10-05
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="sourceSelect">Combox</param>
function checkComboxNotEmpty(sourceSelect){
    if (sourceSelect==null) return true;
    if (sourceSelect.value == 0) return false;
    return true;
}

/// <summary>
/// 名    称: checkNum
/// 功能概要: 字符判断函数
/// 作    者: 麻少华
/// 创建时间: 2007-10-12
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="objTemp">对象</param>
/// <param name="blnEmpty">是否可以为空</param>
/// <param name="maxLen">最大长度</param>
function checkNum(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	var str=new String(objTemp.val());
	//str = qiong_Delete(str); 
	if(lenb(str)==0)
		if(blnEmpty)
			return true;
		else
		{
		  showMsg("001");
			return false;
		}
		
	//判断是不是Number
	//if(!isNumberInt(str))
	if(!isNumber(str))
	{
		showMsg("004");
		return false;
	}	
	
	var parsevalue=parseInt	(str);	 
		
	if(lenb(parsevalue)>maxLen)
	{
	  showMsg("017");
		return false;
	}
	return true;
}

/// <summary>
/// 名    称: checkOnlyNum
/// 功能概要: 判断是否仅仅是数字
/// 作    者: 麻少华
/// 创建时间: 2007-10-12
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="objTemp">对象</param>
/// <param name="blnEmpty">是否可以为空</param>
/// <param name="maxLen">最大长度</param>
function checkOnlyNum(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	//objTemp.value=trim(objTemp.val());	
	var str=new String(objTemp.val());
	//str = qiong_Delete(str); 
	if(lenb(str)==0)
		if(blnEmpty)
			return true;
		else
		{
			showMsg("001");
			return false;
		}
	for(var i=0;i<str.length;i++)
	{
		if((str.charAt(i)<"0" || str.charAt(i)>"9") && str.charAt(i)!="."  && str.charAt(i)!="-")
		{
		   showMsg("004");
		   return false;
		 }
	}
	
	var isn =isNumber(str);
	if (isn==false)
	{
		   showMsg("004");
		   return false;
	}
	
	return true;
}

/// <summary>
/// 名    称: isNumber
/// 功能概要: 判断一个字符是否是数字
/// 作    者: 麻少华
/// 创建时间: 2007-10-12
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="strTemp">对象值</param>
function isNumber(strTemp)
{
	var strM;
	strM=parseFloat(strTemp);
	if(isNaN(strM))
		return false;
	else
		if(strM==strTemp)
			return true;
		else
			return false;
}

function showMsg(strNO)
{
	var str;
	switch(strNO)
	{
		case "001":
			str="该项目不能省略。";
			break;
		case "002":
			str="输入的文字数超出了最大长度。";
			break;
		case "003":
			str="不能输入英文字母和数字以外的内容。";
			break;
		case "004":
			str="不能输入数字以外的内容。";	
			break;
		case "005":
			str="请选择。";	
			break;
		case "006":
			str="输入的内容无效。";	
			break;
		case "007":
			str="输入的内容位数不正确。";	
			break;
		case "008":
			str="请输入半角文字。";
			break;
		case "009":
			str="请输入全角文字。";
			break;
		case "010":
			str="邮件地址不正确。";
			break;
		case "011":
			str="日期要以'yyyymmdd'或者'yyyy/mm/dd'的形式输入。";
			break;	
		case "012":
			str="年份要输入4位。";
			break;
		case "013":
			str="月份要输入1位或2位。";
			break;
		case "014":
			str="日要输入1位或2位。";
			break;
		case "015":
			str="请输入合适的日期。";
			break;
		case "016":
			str="对应的数据不存在。";
			break;
		case "017":
			str="输入的数据超出了限制。";
			break;
		case "018":
			str="结束No不能比开始No小。";
			break;
		case "019":
			str="请输入未来日期。";
			break;
		case "020":
			str="结束日期应该比开始日期大。";
			break;
		case "021":
			str="请输入半角kana。";
			break;
		case "022":
			str="小数部分的位数不对。";
			break;
		case "023":
			str="服务器没有响应。";
			break;
		case "024":
			str="不能输入未来日期。";
			break;
		case "025":
			str="输入的金额范围不正确。";
			break;
		case "026":
			str="请输入英文数字或半角kana。";
			break;
		case "027":
			str="时间要以'HH:NN'或者是'HHNN'的形式输入。";
			break;
		case "028":
			str="请选择发送者邮箱地址。";
			break;
		case "029":
			str="请输入收件人邮箱地址。";
			break;
		case "030":
			str="请选择邮箱地址。您可以通过双击检索结果行来选择客户邮箱地址。";
			break;
		case "031":
			str="请输入正确的小时数，24小时制。";
			break;
		case "032":
			str="请输入正确的分钟数！";
			break;
		case "033":
			str="请输入发送者邮箱密码。";	
			break;
		case "034":
			str="邮件已经发送成功。";	
			break;
		case "035":
			str="邮件发送失败，请重新发送。";	
			break;
		case "036":
			str="请选择要删除的纪录！";	
			break;
		case "037":
			str="该客户已经选择，请选择其他客户！";	
			break;
	}
	//show_Err(ErrContent,str);
	alert(str);
	
}

//转换成YYYYMMDD格式
	function strDate(str)
	{
		var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
		var r = str.match(reg);
		if(r==null)return false;
		var d= new Date(r[1], r[3]-1,r[4]);
		var newStr=d.getFullYear()+r[2]+(d.getMonth()+1)+r[2]+d.getDate()
		return newStr==str
	}

//转换成YYYYMMDDhhmmss格式
	function strDateTime(str)
	{
		var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
		var r = str.match(reg);
		if(r==null)return false;
		var d= new Date(r[1], r[3]-1,r[4],r[5],r[6],r[7]);
		var newStr=d.getFullYear()+r[2]+(d.getMonth()+1)+r[2]+d.getDate()+" "+d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()
		return newStr==str
	}

//时间有效性判断函数
function verifyDate(textObj)
 {
    var str=textObj.value;
	textObj.value = textObj.value.replace(/\s+/g," ");
    if(str.search(/^\d{4}-\d{1,2}-\d{1,2}$/) == 0)
	{
 	 var y = parseInt(str.split("-")[0]);
     var m = parseInt(str.split("-")[1]);
     var d = parseInt(str.split("-")[2]);
  	switch(m)
	{
      case 1:
      case 3:
      case 5:
      case 7:
      case 8:
      case 10:
      case 12:
       if(d>31)
	   {
		showMsg("015");
        return false;
    	}
		else
		{
        return true;
   		 }
       break;
   case 2:
       if((y%4==0 && d>29) || ((y%4!=0 && d>28)))
	   {
		showMsg("015");
        return false;
    	}
		else
		{
        return true;
    	}
       break;
      case 4:
      case 6:
      case 9:
      case 11:
       if(d>30)
	   {
		showMsg("015");
        return false;
    	}else
		{
        return true;
    	}
       break;
   	default:
		{
		showMsg("015");
		return false;
		}
       
  	}
	}
	else
	{
	 showMsg("015");
     return false;
	}
}
//时间比较函数
		function compareDate(DateOne,DateTwo)
			{

			var OneMonth = DateOne.substring(5,DateOne.lastIndexOf ("-"));
			var OneDay = DateOne.substring(DateOne.length,DateOne.lastIndexOf ("-")+1);
			var OneYear = DateOne.substring(0,DateOne.indexOf ("-"));

			var TwoMonth = DateTwo.substring(5,DateTwo.lastIndexOf ("-"));
			var TwoDay = DateTwo.substring(DateTwo.length,DateTwo.lastIndexOf ("-")+1);
			var TwoYear = DateTwo.substring(0,DateTwo.indexOf ("-"));

			if (Date.parse(OneMonth+"/"+OneDay+"/"+OneYear)>Date.parse(TwoMonth+"/"+TwoDay+"/"+TwoYear))
				{
				//return true;
				}
				else
				{
				return false;
				}

			}

function lenb(strTemp)
{
	var intLength=0;
	var str=new String(strTemp);
	for(var i=0;i<str.length;i++){
		if(str.charCodeAt(i)>255)
			if(charIsKn(str.charAt(i)))
				intLength++;
			else
				intLength+=2;
		else
			intLength++;
	}
	return intLength;
}

function charIsKn(strTemp)
{
	var str=new String(strTemp);
	for(var i=0;i<str.length;i++)
		if(str.charCodeAt(i)>65439 || str.charCodeAt(i)<65382)
			return false
	return true
}

function formatNumber(strTemp,intLen)
{
	var i;
	var str=new String(strTemp);
	for(i=0;i<parseInt(intLen,10);i++)
		str="0"+str;
	return  str.substr(str.length-intLen,intLen);
}

function show_Err(objErr,errText)
{
	try{
	objErr.innerText=errText;
	}
	catch(err)
	{}
	return;
	
}

function clear_Err(objErr)
{
	try{
	objErr.innerText="";
	}
	catch(err)
	{}
	return;
}

function trim(strTemp)  // Delete Two Side Space
{
	var str=new String(strTemp);
	var substr=new String("");
	if(str.length==0) return "";
	try{
		while((str.charAt(0)==" ")||(str.charAt(0)=="　"))
		{
			str=str.substr(1);
		}
		while((str.charAt(str.length-1)==" ")||(str.charAt(str.length-1)=="　"))
		{
			str=str.substr(0,str.length-1);
		}
	}
	catch(err)
	{}
	return str;
}

function asc(strTemp)              //Retrun ascii of the Char
{
	var str=new String(strTemp);
	return str.charCodeAt(0);
}

function isNumberInt(strTemp)     //Check if not integer
{
	var str=new String(strTemp);

	if(!isNumber(str.toString()))
		return false;
	if(str.indexOf("-",0)!=-1)
		return false;
	if(str.indexOf(".",0)!=-1)
		return false;
	return true;
}

function isSignNumberint(strTemp)	//Check if not sign integer
{
	strTemp=qiong_Delete(strTemp);
	var str=new String(strTemp);

	if(!isNumber(str.toString()))
		return false;	
	if(str.indexOf(".",0)!=-1)
		return false;
	return true;
}

function isNumberDbl(strTemp)     //Check if not float  
{
	var str=new String(strTemp);
	var i;
	if(!isNumber(str.toString()))
		return false;
	if(str.indexOf("-",0)!=-1)
		return false;
	return true;
}



function checkDate(strYear,strMonth,strDay)
{
	var objNewDate = new Date(strYear, parseInt(strMonth,10)-1, strDay);
	
	if(parseInt(objNewDate.getDate(),10) - parseInt(strDay,10)!=0 || parseInt(strMonth,10)- parseInt(objNewDate.getMonth()-(-1),10)!=0 || parseInt(strYear,10)-parseInt(objNewDate.getFullYear(),10)!=0)
	{						
		showMsg("015");
		return false;
	}

   if(1900>parseInt(strYear,10))
   {
		showMsg("006");
		return false;
   }
	return true;
}

function fDataFormat(objDate)
{
	var strCeckDate = objDate.value;
	if(lenb(strCeckDate)!=8 && lenb(strCeckDate)!=10 && lenb(strCeckDate)!=0)
	{
		showMsg("011");
		return false;
	}
	if(strCeckDate.length == 8){
		if(!isNumberInt(strCeckDate.substr(0,4)) || !isNumberInt(strCeckDate.substr(4,6)) ||  !isNumberInt(strCeckDate.substr(6,8)))
		{
			showMsg("015");
			return false;
		}

		strYear = strCeckDate.slice(0,4);
		strMonth = strCeckDate.slice(4,6);
		strDate = strCeckDate.slice(6,8);
		strCeckDate = strYear + '/' + strMonth + '/' + strDate;
		objDate.value = strCeckDate;
	}
	
	strCeckDate = objDate.value.split("/");
	bolRet = false;
	if(objDate.value == ""){
		bolRet = true;
	}
	else{
			if(strCeckDate.length!=3){
			showMsg("011");
			return false;
		}
		else{
				if(!isNumberInt(strCeckDate[0]) || !isNumberInt(strCeckDate[1]) ||  !isNumberInt(strCeckDate[2]))
		      {
			      showMsg("015");
			      return false;
		      }
			if(strCeckDate[0].length != 4){
				showMsg("012");
			   return false;
			}
			else{
				if((strCeckDate[1].length < 1) || (strCeckDate[1].length > 2)){
					showMsg("013");
			      return false;
				}
				else{
					if((strCeckDate[2].length < 1) || (strCeckDate[2].length > 2)){
						showMsg("014");
			         return false;
					}
					else{
						objNewDate = new Date(strCeckDate[0], parseInt(strCeckDate[1],10)-1, strCeckDate[2]);
						if((objNewDate.getDate() != strCeckDate[2]) || (strCeckDate[1] != objNewDate.getMonth()+1)){						
							showMsg("015");
		               return false;
						}

                  if(1900>parseInt(strCeckDate[0],10))
                  {
		               showMsg("006");
		               return false;
                  }
                  
					   bolRet = true;
					}
				}
			}
		}
	}
	return bolRet;
}

function onlyInputDate()
{
	if((event.keyCode<asc("0") || event.keyCode>asc("9")) && event.keyCode!=asc("/")) 
		event.returnValue=false;	
}

function onlyInputTime()
{
	if((event.keyCode<asc("0") || event.keyCode>asc("9")) && event.keyCode!=asc(":")) 
		event.returnValue=false;	
}

function onlyInputCharNum()
{
	if(event.keyCode<asc("0") || event.keyCode>asc("9") && event.keyCode<asc("A") || event.keyCode>asc("Z") && event.keyCode<asc("a") || event.keyCode>asc("z"))
		event.returnValue=false;
}

function onlyInputSignNumberint()
{
	if((event.keyCode<asc("0") || event.keyCode>asc("9")) && event.keyCode!=asc("-")) 
		event.returnValue=false;
}

function onlyInputChar()  
{
	if(event.keyCode<asc("A") || event.keyCode>asc("Z") && event.keyCode<asc("a") || event.keyCode>asc("z"))
		event.returnValue=false;
}

function isOnlyCharNum(str)
{
	var i;
	for(i=0;i-str.length<0;i++){
		if(str.charCodeAt(i)<asc("0") || str.charCodeAt(i)>asc("9") && str.charCodeAt(i)<asc("A") || str.charCodeAt(i)>asc("Z") && str.charCodeAt(i)<asc("a") || str.charCodeAt(i)>asc("z")){
			return false;
		}
	}
	return true;
}

function isOnlyCharNumOrKana(str)
{
	var i;
	for(i=0;i-str.length<0;i++){
		if(str.charCodeAt(i)<asc("0") || str.charCodeAt(i)>asc("9") && str.charCodeAt(i)<asc("A") || str.charCodeAt(i)>asc("Z") && str.charCodeAt(i)<65382 || str.charCodeAt(i)>65439){
			return false;
		}
	}
	return true;
}

function onlyInputNum()
{
	if(event.keyCode<asc("0") || event.keyCode>asc("9")) 
		event.returnValue=false;
}

function onlyInputDbl()
{
	if(event.keyCode<asc("0") && event.keyCode!=asc(".") || event.keyCode>asc("9")) 
		event.returnValue=false;
}

function qiong_Delete(strInput)
{
	strInput=new String(strInput);
	if(strInput=="") return "";
	var i,intLen,strTemp,strChar;
	strTemp="";
	intLen =strInput.length;
	for(i=0;i<intLen;i++)
	{
	    strChar = strInput.charAt(i);
	    if (strChar != ",") 
	       strTemp = strTemp + strChar;
	}
	return strTemp;
}

function qiong_Add(strInput)
{
	if(strInput=="")
		return "";
	strInput=qiong_Delete(strInput);
	var strFlag;
	if(strInput.substr(0,1)=="-")
		strFlag="-";
	else
		strFlag="";
	var strTemp="";
	for(var i=0;i<strInput.length;i++)
	{
		if(!(strInput.charAt(i)<"0" && strInput.charAt(i)!="." || strInput.charAt(i)>"9"))
			strTemp=strTemp+strInput.charAt(i);		
	}
	strInput=strTemp;

	if(isNaN(parseFloat(strInput))) return "";
	var strV=new String(strInput);
	var iPos=strV.indexOf(".",0);
	var strLeft,strRight;
	var intLen;
	if(iPos==-1)
	{
		intLen=strV.length ;
		strLeft=strV.toString();
		strRight="";
	}
	else
	{
		intLen=iPos;
		if(iPos==0)
			strLeft="";
		else
			strLeft=strV.substr(0,iPos);
		strRight=strV.substr(iPos+1);
	}
	
	if(strLeft.length<4)
		return strFlag+strLeft+(strRight==""?"":"."+strRight);
	var intCount=Math.round((strLeft.length-1)/3);
	if(intCount*3>strLeft.length-1)
		intCount--;
	for(iPos=0;iPos<intCount;iPos++)
	{
		intLen=strLeft.length-3*(1+iPos)-iPos;
		strLeft=strLeft.substr(0,intLen)+","+strLeft.substr(intLen);

	}
	return strFlag+strLeft+(strRight==""?"":"."+strRight);
	
}

function checkHalfChar(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}
	if(lenb(str)!=str.length)
	{
		showMsg("008");
		return false;
	}
	return true;
}

function checkAllChar(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}	
	if(str.length>maxLen)
	{
		showMsg("002");
		return false;
	}
	if(lenb(str)!=2*str.length)
	{
		showMsg("009");
		return false;
	}	
	return true;
}

function checkTime(objTemp,blnEmpty)
{
	objTemp.value=trim(objTemp.value);
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)==0 && blnEmpty) return true;
	if(str.length!=5 && str.length!=4)
	{
		showMsg("027");
		return false;
	}
	if(str.length==4)
	{
		if(!isNumberInt(str.substr(0,2)) || !isNumberInt(str.substr(2,2)))
		{
			showMsg("004");
			return false;
		}
		objTemp.value=str.substr(0,2)+":"+str.substr(2,2);
		str=objTemp.value;
	}
	else
	{
		if(str.substr(2,1)!=":")
		{
			showMsg("027");
			return false;
		}
		if(!isNumberInt(str.substr(0,2)) || !isNumberInt(str.substr(3,2)))
		{
			showMsg("004");
			return false;
		}
	}
	if(parseInt(str.substr(0,2),10)>23 || parseInt(str.substr(0,2),10)<0 )
	{
		showMsg("006");
		return false;		
	}
	if(parseInt(str.substr(3,2),10)>59 || parseInt(str.substr(3,2),10)<0 )
	{
		showMsg("006");
		return false;	
	}	
	return true;
}

function checkCharNum(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}
	if(!isOnlyCharNum(str))
	{
		showMsg("003");
		return false;
	}
	return true;
}

function checkCharNumAndKana(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}
	if(!isOnlyCharNumOrKana(str.toUpperCase()))
	{
		showMsg("026");
		return false;
	}
	return true;
}

function checkMixChar(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}	
	return true;
}




function checkSignNum(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	str = qiong_Delete(str); 
	if(lenb(str)==0)
		if(blnEmpty)
			return true;
		else
		{
			showMsg("001");
			return false;
		}
	if(!isSignNumberint(str))
	{
		showMsg("004");
		return false;
	}	
	return true;
}

function checkDbl(objTemp,blnEmpty,maxLen)   
{                    
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	str = qiong_Delete(str);                  
	if(lenb(str)==0)
		if(blnEmpty)
			return true;
		else
		{
			showMsg("001");
			return false;
		}
	if(!isNumberDbl(str))
	{
		showMsg("004");
		return false;
	}	
	return true;
}

function checkKana(objTemp,blnEmpty,maxLen)
{
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}	
	if(!charIsKn(str))
	{
		showMsg("021");
		return false;
	}	
	return true;
}


function msgBox(strNO)
{
	var str;
	switch(strNO)
	{
		case "001":
			str="此项目不可省略。";
			break;
		case "002":
			str="对应的数据不存在。";
			break;
		case "003":
		    str="不能输入数字以外的内容。";	
			break;		
		case "004":
			str="该用户已经登录。";
			break;
		case "006":
			str="输入的情报无效。";	
			break;
	}
	alert(str);
}

function MsgUpdate()
{
	//return confirm("要更新？");
	var intValue=window.showModalDialog("MsgBox.htm",0,"help:no;dialogHeight: 125px; dialogWidth: 320px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}


function MsgDelete()
{
	//return confirm("要删除？");
	var intValue= window.showModalDialog("MsgBox.htm",1,"help:no;dialogHeight: 125px; dialogWidth: 310px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}

function MsgPrint()
{
	//return confirm("要打印？");
	var intValue= window.showModalDialog("MsgBox.htm",2,"help:no;dialogHeight: 125px; dialogWidth: 320px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}

function MsgInput()
{
	//return confirm("要输入？");
	var intValue=window.showModalDialog("MsgBox.htm",3,"help:no;dialogHeight: 125px; dialogWidth: 320px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}

function MsgCancel()
{
	//return confirm("要取消？");
	var intValue= window.showModalDialog("MsgBox.htm",4,"help:no;dialogHeight: 125px; dialogWidth: 320px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}

function MsgAbortError(strDes)
{
	var intValue= window.showModalDialog("MsgBox.htm",strDes,"help:no;dialogHeight: 125px; dialogWidth: 320px;status: No;");
	if(intValue==0)
		return true;
	else
		return false;
}

function selectAll(obj)
{
   try
   {
	   obj.select();
   }
   catch(err)
	{}

}

function checkValueRegion(objTemp,minNum,maxNum)   
{
	minNum=parseInt(minNum);
	maxNum=parseInt(maxNum);
	var str=trim(qiong_Delete(objTemp.value));
	if(str=='') str='0';
	var intTemp = parseInt(str);
	if(intTemp < minNum || intTemp >maxNum)
	{
		return false;
	}
	return true;
}

function checkFloatRegion(objTemp,minNum,maxNum)   
{
	minNum=parseFloat(minNum);
	maxNum=parseFloat(maxNum);
	var str=trim(qiong_Delete(objTemp.value));
	if(str=='') str='0';
	var fltTemp = parseFloat(str);
	if(isNaN(minNum)) return false;
	if(isNaN(maxNum)) return false;
	if(isNaN(fltTemp)) return false;
	if(fltTemp < minNum || fltTemp >maxNum)
	{
		return false;
	}
	return true;
}

function checkValue(objTemp,checkNum)  
{
	checkNum=parseInt(checkNum);
	var intTemp = parseInt(trim(qiong_Delete(objTemp.value)));
	if(intTemp != checkNum)
	{
		return false;
	}
	return true;
}

function checkMixTextNum(objTemp,checkLeftLen)  
{
	var str=new String(trim(objTemp.value));
	var i;
	for(i=0;i<parseInt(checkLeftLen);i++){
		if(str.charCodeAt(i)>asc("9") || str.charCodeAt(i)<asc("0"))
		{
			showMsg("004");
			return false;
		}
	}
	return true;
}

function checkCharLength(objTemp,checkLen)
{
	var str=new String(trim(objTemp.value));
	
	checkLen=parseInt(checkLen);
	if(lenb(str) != checkLen)
	{
		showMsg("007");
		return false;
	}
	return true;
}

function dateDiff(objDateEnd,objDateStart)  
{
	var strEnd = new String(trim(objDateEnd.value));
	var strStart = new String(trim(objDateStart.value));
	strEnd = strEnd.replace("/","");
	strStart = strStart.replace("/","");
	if(lenb(strEnd)!=lenb(strStart)) showMsg("006");
	if(strEnd<strStart)
	{
		return -1;  // <
	}
 	if(strEnd>strStart)
	{
		return 1;  // >
	}
	return 0;  //==
}

function checkDblRightLen(objTemp,maxLen)  
{
	var strTemp = new String(qiong_Delete(trim(objTemp.value)));
	var i = strTemp.indexOf(".");
	if(i<0) return true;
	maxLen = parseInt(maxLen);
	i=lenb(strTemp)-(i+1);
	if(i>maxLen)
	{
		showMsg("022");
		return false;
	} 
	return true;	
}

function checkEMail(objTemp,blnEmpty,maxLen)
{
	var strEMail=new String(objTemp.value);
	if(lenb(strEMail)==0)
		if(!blnEmpty)
		{
			showMsg("001");
			return false;
		}
		else
			return true;
	if(strEMail.length!=lenb(strEMail))
	{
		showMsg("008");
		return false;
	}
	if(lenb(strEMail)>maxLen)
	{
		showMsg("002");
		return false;
	}
	if(strEMail.length<8)
	{
		showMsg("010");
		return false;
	}
	
	if(strEMail.indexOf("@")<1)
	{
		showMsg("010");
		return false;
	}
	if(strEMail.indexOf(".")<3)
	{
		showMsg("010");
		return false;
	}
	return true;
}

function onFoucsC(obj,maxLen)
{	
	obj.maxLength=maxLen;
	obj.value=qiong_Delete(obj.value);
	obj.select();	
}

function onBlurC(obj,maxLen)
{
	obj.maxLength=maxLen;
	obj.value=qiong_Add(obj.value);
	clear_Err(ErrContent);	
}

function checkCharNumEX(objTemp,blnEmpty,maxLen,strAllows)
{
	var strAllow=new String(strAllows);
	if(strAllow=="")
		return checkCharNum(objTemp,blnEmpty,maxLen);
		 
	maxLen=parseInt(maxLen);
	objTemp.value=trim(objTemp.value);	
	var str=new String(objTemp.value);
	if(lenb(str)==0 && !blnEmpty)
	{
		showMsg("001");
		return false;
	}
	if(lenb(str)>maxLen)
	{
		showMsg("002");
		return false;
	}
	var i;
	for(i=0;i-str.length<0;i++){
		if(str.charCodeAt(i)<asc("0") || str.charCodeAt(i)>asc("9") && str.charCodeAt(i)<asc("A") || str.charCodeAt(i)>asc("Z") && str.charCodeAt(i)<asc("a") || str.charCodeAt(i)>asc("z")){
			if(!isInstr(str.charAt(i),strAllow))
				{
					showMsg("006");
					return false;
				}
		}
	}
	
	return true;

}

function isInstr(strTofind,strInwhich)
{
	var strTemp;
	strTemp=strInwhich.replace(strTofind,"");
	if(strTemp!=strInwhich)
		return true;
	
	return false;
}

function getCutIndex(strTemp,intLen)
{
	var intLength=0;
	var maxIntLen=parseInt(intLen,10);
	var str=new String(strTemp);
	var i;
	for(i=0;i<str.length;i++)
	{
		if(str.charCodeAt(i)<=255||(charIsKn(str.charAt(i))))
				intLength++;
		else
				intLength+=2;
		if(intLength>maxIntLen) return i;
	}
	return str.length;
}			

function setAddress(objCity,objPost,objAdd1,objAdd2,objAdd3)
{
	var strCity=objCity.value;
	var objAdr=getJisData(strCity);
	if(objAdr!=null)
	{
		objCity.selectedIndex=parseInt(objAdr.jiscod.substr(0,2),10);
		objPost.value=objAdr.poscod;
		var str=objAdr.knnmkj+objAdr.sinmkj;
      if(lenb(str)<=parseInt(40,10))
      {
      	objAdd1.value=str;
			objAdd2.value=objAdr.cynmkj;
		}
      else
      {
      	var index=getCutIndex(str,40);
      	objAdd1.value=str.substr(0,index);	
      	objAdd2.value=str.substr(index,str.length-index);	
      }
		objAdd3.value="";
		objPost.focus();
		return objAdr.jiscod;
	}
	else
	   return '';
}

function setAddressBypost(objCity,objPost,objAdd1,objAdd2,objAdd3)
{
	var objAdr=getPostData();
	if(objAdr!=null)
	{
		objCity.selectedIndex=parseInt(objAdr.jiscod.substr(0,2),10);
		objPost.value=objAdr.poscod;
		var str=objAdr.knnmkj+objAdr.sinmkj;
      if(lenb(str)<=parseInt(40,10))
      {
      	objAdd1.value=str;
			objAdd2.value=objAdr.cynmkj;
		}
      else
      {
      	var index=getCutIndex(str,40);
      	objAdd1.value=str.substr(0,index);	
      	objAdd2.value=str.substr(index,str.length-index)+objAdr.cynmkj;	
      }
		objAdd3.value="";
		objAdd2.focus();
		return objAdr.jiscod;		
	}
	else
	   return '';
}

function setCityIndexByValue(objCity,strJis)
{
	var str;
	var intJis=parseInt(strJis.substr(0,2),10);
	if(!isNaN(intJis))
	{	
		for(var i=1;i<objCity.length;i++)
		{
			str=objCity.options[i].value.substr(0,2);
			if(parseInt(str,10)==intJis)
			{
				objCity.selectedIndex=i;
				return;
			}
		}
	}
	objCity.selectedIndex=0;
}

function showToksearch(strDate)
{
   var objTok=showModalDialog("HF_TOKS.aspx?DATE="+strDate,"","help:no;dialogHeight: 600px; dialogWidth: 700px;status: No;"); 
   return objTok;
}

function getJisData(strID)
{
	var rObj=window.showModalDialog("HF_JISS.aspx?ID="+strID,"","help:no;dialogHeight: 510px; dialogWidth: 580px;status: no;");
	return rObj;
}

function getPostData()
{
	var rObj=window.showModalDialog("HF_POST.aspx","","help:no;dialogHeight: 450px; dialogWidth: 580px;status: no;");
	return rObj;
}

function showNidsearch(strUser,strDate)
{
   var objNid=showModalDialog("IF_NIDS.aspx?USER="+strUser+"&DATE="+strDate,"","help:no;dialogHeight: 600px; dialogWidth: 700px;status: No;"); 
   return objNid;
}

function showErrPage(strErr)
{
   window.showModalDialog("SystemErr.aspx",strErr,"help:no;dialogHeight: 125px; dialogWidth: 330px;status: no;");  
   window.location.href="logon.aspx";
}

function barReplace(str)
{
   var rgx=/-/g;
   return allReplace(str,rgx);
}

function allReplace(str,rgx)
{
   return str.replace(rgx,'');
}

function MessageBox(StrMessage)
{	var Blnreturn;	
	Blnreturn=window.confirm(StrMessage);
	if (Blnreturn)
	{	
	return true;
	}
	else
	{	
	return false;
	}

}


//--------------------------------------文本框格式化日期-------------------------------
function regDateControl(txtName)
{
    var oInput = document.getElementById(txtName);
    oInput.middleChar = "-";
    oInput.selectIndex = 1; //Ä¬ÈÏÑ¡ÖÐÄê
    oInput.maxLength = 10;
    oInput.style.imeMode = "disabled";
	if (oInput.value == "")
    	oInput.value = specialText_GetDate(oInput.middleChar);
	//alert( oInput.value );
    oInput.charWidth = oInput.createTextRange().boundingWidth / oInput.maxLength;

    //×¢²áµ¥»÷ÊÂ¼þ
    oInput.onclick = specialText_ClickEvent;
    oInput.onkeydown = specialText_KeyDownEvent;
    oInput.onfocus = function()
	{
		specialText_SelectYear(this);
	}
    oInput.onblur = function()
    {
		if (this.value != "")
		{
			specialText_validYear(this);
			specialText_validMonth(this);
			specialText_validDate(this);
		}
		oInput.onfocus = function(){return false;}
		oInput.onclick = function(){regDateControl(txtName);}
		oInput.onkeydown = function(){return false;}
    }
    //ÆÁ±ÎÊó±êÓÒ¼üºÍÍÏ¶¯²Ù×÷
    oInput.oncontextmenu = function(){return false;}
    oInput.ondrop = function(){return false;}
	
	oInput.onclick();
}

//Êó±êµ¥»÷£¬¸ù¾ÝÎ»ÖÃ¶ÔÈÕÆÚ½øÐÐ·ÖÌåÑ¡Ôñ
function specialText_ClickEvent()
{
	if (this.value != "")
	{
		event.cancelBubble = true;
		specialText_validYear(this);
		specialText_validMonth(this);
		specialText_validDate(this);
		if(event.offsetX <= specialText_getCharWidth(this.charWidth,4))
			specialText_SelectYear(this);
		else if(event.offsetX > specialText_getCharWidth(this.charWidth,4)
				&& event.offsetX <= specialText_getCharWidth(this.charWidth,7))
			specialText_SelectMonth(this);
		else if(event.offsetX > specialText_getCharWidth(this.charWidth,7))
			specialText_SelectDate(this);
	}
	else
	{
		this.value = specialText_GetDate(this.middleChar);
	}
}
//Ñ¡ÖÐÄê·Ý

function specialText_SelectYear(oInput)
{
    var oRange = oInput.createTextRange();
    oRange.moveStart("character",0);
    oRange.moveEnd("character",-6);
    //´ú±íÑ¡ÖÐÁËÄê
    oInput.selectIndex = 1;
    oRange.select();
}
//Ñ¡ÖÐÔÂ·Ý

function specialText_SelectMonth(oInput)
{
    var oRange = oInput.createTextRange();
    oRange.moveStart("character",5);
    oRange.moveEnd("character",-3);
    //´ú±íÑ¡ÖÐÁËÔÂ

    oInput.selectIndex = 2;
    oRange.select();
}
//Ñ¡ÖÐÈÕÆÚ

function specialText_SelectDate(oInput)
{
    var oRange = oInput.createTextRange();
    oRange.moveStart("character",8);
    //´ú±íÑ¡ÖÐÁËÈÕÆÚ

    oInput.selectIndex = 3;
    oRange.select();
}
//Ð£ÑéÄê·ÝÓÐÐ§ÐÔ

function specialText_validYear(oInput)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strYear = arrValue[0];

    if(parseInt(strYear,10) == 0)
        arrValue[0] = 1900;
    //Èç¹ûÄê·ÝÐ¡ÓÚ4Î»£¬ÔòÔÚ2000»ù´¡ÉÏÔö¼Ó

    else if(strYear.length < 4)
        arrValue[0] = 1900 + parseInt(strYear,10);
    oInput.value = arrValue.join(oInput.middleChar);
}
//Ð£ÑéÔÂ·ÝÓÐÐ§ÐÔ

function specialText_validMonth(oInput)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strMonth = arrValue[1];
    //Èç¹ûÔÂ·ÝÊäÈëÁË0£¬Ôò°´1ÔÂ´¦Àí
    if(parseInt(strMonth,10) == 0)
         arrValue[1] = "01";
    //Èç¹ûÔÂ·ÝÊÇÒ»Î»£¬ÔòÇ°Ãæ²¹0
    else if(strMonth.length < 2)
        arrValue[1] = "0" + strMonth;
    //Èç¹ûÔÂ·Ý´óÓÚ12ÔÂ£¬×Ô¶¯×ªÎª12ÔÂ

    else if(parseInt(strMonth,10) > 12)
        arrValue[1] = "12";
    oInput.value = arrValue.join(oInput.middleChar);
}
//Ð£ÑéÈÕÆÚÓÐÐ§ÐÔ

function specialText_validDate(oInput)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strYear = arrValue[0];
    var strMonth = arrValue[1];
    var strDate = arrValue[2];
    var intMonth = parseInt(strMonth,10);
    if(parseInt(strDate,10) == 0)
        arrValue[2] = "01";
    else if(strDate.length < 2)
        arrValue[2] = "0" + strDate;
    else
    {
        //Èç¹û³¬¹ýÁËÔÂ·ÝµÄ×î´óÌìÊý£¬ÔòÖÃÎª×î´óÌìÊý
        var monthMaxDates = specialText_getMonthDates(strYear,strMonth);
        if(parseInt(strDate,10) > monthMaxDates)
            arrValue[2] = monthMaxDates;
    }
    oInput.value = arrValue.join(oInput.middleChar);
}

function specialText_YearAdd(oInput,isMinus)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strYear = arrValue[0];
    if(isMinus)
    {
        arrValue[0] = parseInt(strYear,10) - 1;
        if(parseInt(arrValue[0],10) < 1)
            arrValue[0] = "0001";
    }
    else
        arrValue[0] = parseInt(strYear,10) + 1;
    oInput.value = arrValue.join(oInput.middleChar);
    specialText_validYear(oInput);
    specialText_SelectYear(oInput);
}

function specialText_MonthAdd(oInput,isMinus)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strMonth = arrValue[1];
    if(isMinus)
    {
        arrValue[1] = parseInt(strMonth,10) - 1;
        if(parseInt(arrValue[1],10) == 0)
            arrValue[1] = "12";
    }
    else
    {
        arrValue[1] = parseInt(strMonth,10) + 1;
        if(parseInt(arrValue[1],10) == 13)
            arrValue[1] = "01";
    }
    oInput.value = arrValue.join(oInput.middleChar);
    specialText_validMonth(oInput);
    specialText_SelectMonth(oInput);
}

function specialText_DateAdd(oInput,isMinus)
{
    var arrValue = oInput.value.split(oInput.middleChar);
    var strYear = arrValue[0];
    var strMonth = arrValue[1];
    var strDate = arrValue[2];
    var monthMaxDates = specialText_getMonthDates(strYear,strMonth);

    if(isMinus)
    {
        arrValue[2] = parseInt(strDate,10) - 1;
        if(parseInt(arrValue[2],10) == 0)
            arrValue[2] = monthMaxDates;
    }
    else
    {
        arrValue[2] = parseInt(strDate,10) + 1;
        if(parseInt(arrValue[2],10) == (monthMaxDates + 1))
            arrValue[2] = "01";
    }
    oInput.value = arrValue.join(oInput.middleChar);
    specialText_validDate(oInput);
    specialText_SelectDate(oInput);
}

function specialText_KeyDownEvent()
{
    //Èç¹û°´ÁËÊý×Ö¼ü
    if((event.keyCode >= 48 && event.keyCode <= 57) ||
       (event.keyCode >= 96 && event.keyCode <= 105))
    {     
        var oRange = document.selection.createRange();
        if(oRange.text.indexOf(this.middleChar) != -1)
            event.returnValue = false;
        else
            event.returnValue = true;
    }
    //Èç¹û°´ÁË·½Ïò¼ü
    else if(event.keyCode >= 37 && event.keyCode <= 40)
    {
        event.returnValue = false;
        var keyCode = event.keyCode;
        //°´ÁË×ó¼ü
        if(keyCode == 37)
        {
            if(this.selectIndex == 1)
            {
                specialText_validYear(this);
                specialText_SelectDate(this);
            }
            else if(this.selectIndex == 2)
            {
                specialText_validMonth(this);
                specialText_SelectYear(this);
            }
            else if(this.selectIndex == 3)
            {
                specialText_validDate(this);
                specialText_SelectMonth(this);
            }
        }
        //°´ÁËÓÒ¼ü
        if(keyCode == 39)
        {
            if(this.selectIndex == 1)
            {
                specialText_validYear(this);
                specialText_SelectMonth(this);
            }
            else if(this.selectIndex == 2)
            {
                specialText_validMonth(this);
                specialText_SelectDate(this);
            }
            else if(this.selectIndex == 3)
            {
                specialText_validDate(this);
                specialText_SelectYear(this);
            }
        }

        //°´ÁËÉÏ¼ü
        if(keyCode == 38)
        {
            if(this.selectIndex == 1)
            {
                specialText_validYear(this);
                specialText_YearAdd(this,true);
            }
            else if(this.selectIndex == 2)
            {
                specialText_validMonth(this);
                specialText_MonthAdd(this,true);
            }
            else if(this.selectIndex == 3)
            {
                specialText_validDate(this);
                specialText_DateAdd(this,true);
            }
        }

        //°´ÁËÏÂ¼ü
        if(keyCode == 40)
        {
            if(this.selectIndex == 1)
            {
                specialText_validYear(this);
                specialText_YearAdd(this,false);
            }
            else if(this.selectIndex == 2)
            {
                specialText_validMonth(this);
                specialText_MonthAdd(this,false);
            }
            else if(this.selectIndex == 3)
            {
                specialText_validDate(this);
                specialText_DateAdd(this,false);
            }
        }
    }
    //Èç¹û°´ÁËF5 »ò TAB£¬²»ÆÁ±Î

    else if(event.keyCode == 116 || event.keyCode == 9)
        event.returnValue = true;
    else
    {
        event.returnValue = false;
        event.keyCode = 0;
    }
}

/*---------------------¸¨Öúº¯Êý-----------------------*/
//µÃµ½Ä¬ÈÏÈÕÆÚ

function specialText_GetDate(middleChar)
{
    var oDate = new Date();
    return oDate.getYear() + middleChar
           + (oDate.getMonth() < 10 ? ("0" + oDate.getMonth()) : oDate.getMonth()) + middleChar
		   + (oDate.getDate() < 10 ? ("0" + oDate.getDate()) : oDate.getDate());
//return "1900" + middleChar
         //  + "01" + middleChar
          // + "01";           
		 //return "";

}

//µÃµ½×Ö·ûÏñËØ¿í¶È

function specialText_getCharWidth(charWidth,charNum)
{
    return charNum * charWidth;
}
//µÃµ½Ä³ÄêÄ³ÔÂµÄ×î´óÌìÊý
function specialText_getMonthDates(strYear,strMonth)
{
    var intMonth = parseInt(strMonth,10);
    if(intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7
       || intMonth == 8 || intMonth == 10 || intMonth == 12)
        return 31;
    //´¦Àí30ÌìµÄÔÂ·Ý

    else if(intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11)
        return 30;
    //´¦Àí2ÔÂ·Ý

    else
    {
        //ÈòÄê
        if(specialText_isLeapYear(strYear))
            return 29;
        //Æ½Äê
        else
            return 28;
    }
}
//ÅÐ¶ÏÊÇ·ñÊÇÈòÄê
function specialText_isLeapYear(strYear)
{
    var intYear = parseInt(strYear,10);
    if((intYear % 4 == 0 && intYear % 100 != 0) ||
       (intYear % 100 == 0 && intYear % 400 == 0))
        return true;
    else
        return false;
}
//--------------------------------------文本框格式化日期-------------------------------

function URLEncode(fld)
		{
		 if (fld == "") return false;
		 var encodedField = "";
		 var s = fld;
		 if (typeof encodeURIComponent == "function")
		 {
		  // Use javascript built-in function
		  // IE 5.5+ and Netscape 6+ and Mozilla
		  encodedField = encodeURIComponent(s);
		 }
		 else 
		 {
		  // Need to mimic the javascript version
		  // Netscape 4 and IE 4 and IE 5.0
		  encodedField = encodeURIComponentNew(s);
		 }
		 //alert ("New encoding: " + encodeURIComponentNew(fld) +
		 //  "\n           escape(): " + escape(fld));
		 return encodedField;
		}
	

	function encodeURIComponentNew(s) {
		  var s = utf8(s);
		  var c;
		  var enc = "";
		  for (var i= 0; i<s.length; i++) {
			if (okURIchars.indexOf(s.charAt(i))==-1)
			  enc += "%"+toHex(s.charCodeAt(i));
			else
			  enc += s.charAt(i);
		  }
		  return enc;
		}
		


