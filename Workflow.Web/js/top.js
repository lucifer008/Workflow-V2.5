// JScript 文件
//名    称：top
//功能概要: 顶部菜单管理JS
//作    者: 张晓林
//创建时间: 2009年12月14日11:57:40
//修正履历:
//修正时间:

function showMenu()
{
	/*top.topFrame.cols = (top.topFrame.cols == "0,*") ? "210,*" : "0,*";
	if (top.topFrame.cols == "0,*")	{
	document.all.image1.src="images/fore.gif";
	}
	else	{
	document.all.image1.src="images/back.gif";
	}*/
}
function showtop()
{
	/*top.leftFrame.rows = (top.leftFrame.rows == "30,*") ? "118,*" : "30,*";
	
	if (top.leftFrame.rows == "30,*")	{
	document.all.image2.src="images/in.gif";
	logo.style.display='none';
	}
	else	{
	document.all.image2.src="images/out.gif";
	logo.style.display='block';
	}*/
}

function exitCurrentUser()
{
    //window.parent.navigate("LoginOut.aspx");//Firefox下不支持
    window.location.href="LoginOut.aspx";
    
}

function changePassword()
{
    window.parent.frames["mainFrame"].navigate("UpdatePassword.aspx");
}

function logoutUser()
{
    var returnVal='false';
    switch(position)
    {
        case master:
        case manager:
        case pubAccunt:
            returnVal='true';
            break;
        default:
            returnVal=accredit();
            break;
        
    } 
    if(returnVal=='true')
    {
        window.parent.frames["mainFrame"].navigate("LogoutUser.aspx");
    }
}

function accredit()
{
     var url="/finance/Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeId="+escape(accreditTypeId);
     return showPage(url,null,280,500,false,true,false,false);
    //return window.showModalDialog('finance/Accredit.aspx',t,'dialogHeigth:100px;dialogWidth:260px;status:no');
}



document.onkeydown=AnyKeyPress;
function AnyKeyPress(){
    var e=event;
    if(e.keyCode==e.ctrlKey && e.keyCode==e.altKey && e.keyCode==107)
    {
        alert('按下了组合键!');
    }
}