// JScript 文件
// 名    称: selectStandPrice.js
// 功能概要: 选择标准价格Js
// 作    者: 张晓林
// 创建时间:2009年3月5日11:36:30
// 修正履历:
// 修正时间:
// 修正描述:


//选择价格
function choiceRadio(rowNum,selectedBusinessTypeId)
{
    if (window.opener) 
    {
      //获取选中的业务类型信息
       var tds = $("td", $("tr[title=row"+ rowNum +"]"));
       var BaseBusinessTypePriceObj=new Object();
       BaseBusinessTypePriceObj.BusinessTypeId=selectedBusinessTypeId;//业务类型Id
       BaseBusinessTypePriceObj.BusinessTypeName=tds.get(1).innerHTML;//业务类型名称
       BaseBusinessTypePriceObj.MachiningContent=tds.get(2).innerHTML//加工内容
       BaseBusinessTypePriceObj.MachineNo=tds.get(3).innerHTML//机器型号
       BaseBusinessTypePriceObj.PaperQuality=tds.get(4).innerHTML;//纸质
       BaseBusinessTypePriceObj.PaperModel=tds.get(5).innerHTML;//纸型
       BaseBusinessTypePriceObj.Ticket=tds.get(6).innerHTML;//发票
       var strStandardPriceName="#tdStandardPrice"+rowNum;
       BaseBusinessTypePriceObj.StandardPrice=$(strStandardPriceName).html();//标准价格
       //alert($("a",tds.get(1))[0].innerHTML);
        window.opener.baseBusinessTypePriceId(BaseBusinessTypePriceObj);//调用本窗体的窗体的函数
        close(); 
    }
}
