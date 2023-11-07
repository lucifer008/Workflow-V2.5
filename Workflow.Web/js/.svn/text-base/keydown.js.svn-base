//========================================================
//     当文客户名称改变时,设置选择的用户为空
//Writer:         Cry
//create Date:    2008.12.23
//parameters:
//returns:
//========================================================
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    //var e=e|| event;//IE下支持，Firefox下不支持---张晓林
    var e=window.event||arguments[0];
    var element=e.srcElement||src.target;
    if("txtCustomerName"!=element.id){
        if(e.keyCode==13){
            //---添加回车自动计算金额
            try{
                var amountObj=$("input:text[@name=Amount]");
                for(var i=0;i<amountObj.length;i++){
                    if(amountObj[i] && document.activeElement==amountObj[i]){
                        var butObj=$("input:button[@name=btnOrderItemOk]"); 
                        var check = hideControl(butObj[i]);
                        //失去焦点
                        amountObj.blur();
                        
                        //回车如果是最后一条明细 则添加新明细 add by baixiaoyu
                        var table = $("#tbOrderItem");
                        var rowIndex = $(amountObj[i]).parent().parent()[0].rowIndex;
                        var rowCount = 0 || table[0].rows.length;
                        if ((rowIndex+1) == rowCount && check){
							addRow(); 
						}
                        
                        return false;
                    }
                }
                var unitPriceObj=$("input:text[@name=unitPrice]");
                for(var i=0;i<unitPriceObj.length;i++)
                { 
                    if(unitPriceObj[i] && document.activeElement==unitPriceObj[i]){
                        //modifyPriceOnKeydown(unitPriceObj[i]);//IE下支持，Firefox下不支持这种写法---张晓林
                        modifyPriceOnKeydown(unitPriceObj[i],e);
                        return false;
                    }
                }
            }
            catch(ex){
                return false;
                //alert("异常:"+ex);
            }
        }
    }
    //解决输入法反应迟钝问题
//    var customerNameObj=$("#txtCustomerName");
//    if(customerNameObj){
//        if(document.activeElement==customerNameObj[0]){
//            customerNameTimeout=setTimeout('getTxtCustomerNameValue()',100);
//        }
//    }    
}

getTxtCustomerNameValue=function(){
    clearTimeout(customerNameTimeout);
    clearContent($("#txtCustomerName").val());
    if(orderDetailIsHidden){
       
    }
}

$(document).ready(function(){
    customerNameTimeout=setTimeout('getTxtCustomerNameValue()',100);    
});

///名称:CheckCustomer
///功能概要:检查是否未选择客户或者未输入客户之前 选择业务类型明细
///作者;张晓林
///创建时间:2009年10月14日10:36:543
///修正履历:
///修正时间:
function CheckCustomer()
{
    //if(""==$("#txtCustomerName").val()) return false;
    var customerNameObj=$("#txtCustomerName");
    if(customerNameObj){
        if(document.activeElement==customerNameObj[0]){
            customerNameTimeout=getTxtCustomerNameValue();
        }
    }    
}
