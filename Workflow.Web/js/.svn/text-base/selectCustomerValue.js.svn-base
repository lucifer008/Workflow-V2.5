// JScript 文件

function setCustomer(customer)
{
    $('#txtMemberCardNo').attr('value',customer.MemberCardNo);
    
}

function selectCustomer()
{
    var str='../customer/SelectCustomer.aspx?fcb=setCustomer';
    window.open(str);
}

//window.opener.<%= Request.QueryString["fcb"]%>(customer);


//function choiceCustomer(rowNum)
//{
//	var tds = $("td", $(".row" + rowNum));
//	var objCustomer = new Object();
//	objCustomer.Id = tds.get(1).innerHTML;
//	objCustomer.Name = tds.get(2).innerHTML;
//	objCustomer.Trade = tds.get(3).innerHTML;
//	objCustomer.CustomerLevel = tds.get(4).innerHTML;
//	objCustomer.SimpleName = $("input:hidden[@id$=simplename"+rowNum+"]").attr("value");
//	objCustomer.TradeId = $("input:hidden[@id$=TradeId"+rowNum+"]").attr("value");
//	objCustomer.CustomerLevelId = $("input:hidden[@id$=CustomerLevelId"+rowNum+"]").attr("value");
//	objCustomer.CustomerType = tds.get(5).innerHTML;
//	objCustomer.LinkMan = tds.get(6).innerHTML;
//	objCustomer.TelNo = tds.get(7).innerHTML;
//	objCustomer.Address = tds.get(8).innerHTML;
//	objCustomer.NeedTicket = tds.get(9).innerHTML;
//	objCustomer.ValidateStatus = tds.get(10).innerHTML;
//	objCustomer.Memo = tds.get(11).innerHTML;		
//	if (window.opener) {
//	window.opener.<%= returnMethod %>(objCustomer);
//	}
//	close();
//}
