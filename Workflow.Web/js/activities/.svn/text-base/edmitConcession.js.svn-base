// JScript 文件

// 名    称: edmitConcession.js
// 功能概要: 优惠活动方案编辑Js
// 作    者: 张晓林
// 创建时间:2009年2月16日9:39:44 
// 修正履历:
// 修正时间:
// 修正描述:

var data;
$(document).ready(function()
{
    $("#InsertConcession").click(insertBasePrice);
    $("input:button[@value=选择价格]").click(SelectedPrice); 
    LoadData();
});

function LoadData()
{
    if(""!=$("#hiddConcessionId").val())
    {
       var obj=new Object();
       obj.BusinessTypeId=$("#hiddbaseBusinessTypePriceId").val();
       obj.ConcessionId =$("#hiddConcessionId").val();
       baseBusinessTypePriceId(obj);
       $("#ttTitle").html("");
       $("#tdTitle").html("");
       $("#tdTitle1").html("");    
       $("#tdTitle").html("首页 -&gt; 活动管理 -&gt; 优惠方案编辑");    
       $("#tdTitle1").html("优惠方案编辑");     
    }
}
//选择价格
function SelectedPrice()
{
    showPage("SelectStandardPrice.aspx?Id=1",null,1000,900,false,false,false);
    $("#tr2").html("");
}

//根据选择的业务类型加载该业务的价格信息
function baseBusinessTypePriceId(obj)
{
    if(obj==null) return;
    objSelect=obj;
    $("#hiddbaseBusinessTypePriceId").attr("value",obj.BusinessTypeId);//业务类型Id
    var url="../ajax/AjaxEngine.aspx?BusinessTypeId="+obj.BusinessTypeId+"&ConcessionId="+(obj.ConcessionId);
    $.getJSON(url,{a:'26'},bingConcessionInfo);
}
function bingConcessionInfo(json)
{
    try
    {
        bingSelectedBusinessTypeInfo(json);
        /**加载编辑数据**/
        bingEdmitConcessionData(data);
    }
    catch(e)
    {
        alert(e);
    }
}
function bingSelectedBusinessTypeInfo(json)
{
    try
    {
        if(null==json || json)
        {
           data=json;
        }
        else
        {
           return;
        }
        
        var businessTypeDetalInfo="";
        var pricePactorList=data.BusinessType.PriceFactorList;
        var businessType=data;
        businessTypeDetalInfo+="<td>&nbsp;</td>";
        var te="<table width='100%' height='100%' border='1' cellspacing='1' cellpadding='3'>";
        te+="<tr><td class='item_caption'>业务类型</td><td align='left'  colspan='3' class='item_content'>"+data.BusinessType.Name+"</td></tr>"
        if (0==pricePactorList.length % 2 )
        {
           for (var i = 1; i <= pricePactorList.length; i = i + 2)
           {
                te+="<tr>";
                te+="<td class='item_caption'>"+pricePactorList[i - 1].Name+"</td>";
                te+="<td class='item_content'>"+businessType.Texts[i-1]+"</td>";
                te+="<td class='item_caption'>"+pricePactorList[i].Name+"</td>";
                te+="<td class='item_content'>"+businessType.Texts[i]+"</td>";
                te+="</tr>";
           }
           te+="<tr><td class='item_caption'>门市价格:</td>"; 
           te+="<td class='item_content' colspan='3' id='StandardPrice'>"+data.ActivityPrice+"</td></tr>";
        }
        else
        {
           for (var i = 1; i <= pricePactorList.length-1; i = i + 2)
           {
                te+="<tr>";
                te+="<td class='item_caption'>"+pricePactorList[i - 1].Name+"</td>";
                te+="<td class='item_content'>"+businessType.Texts[i-1]+"</td>";
                te+="<td class='item_caption'>"+pricePactorList[i].Name+"</td>";
                te+="<td class='item_content'>"+businessType.Texts[i]+"</td>";
                te+="</tr>";
           }
            te+="<tr><td class='item_caption'>"+pricePactorList[pricePactorList.length-1].Name+"</td>";
            te+="<td class='item_content'>"+businessType.Texts[pricePactorList.length-1]+"</td>";
            te+="<td class='item_caption'>门市价格:</td>"; 
            te+="<td class='item_content' id='StandardPrice'>"+data.ActivityPrice+"</td></tr>";
        }

        te+="<tr>";
        te+="<td class='item_caption'>充值金额:</td><td class='item_content'><input name='txtChargeAmount' id='txtChargeAmount' type='text' class='num' size='10'maxlength='10' /></td>";
        te+="<td class='item_caption'>印章数:</td><td class='item_content' id='tdAmount'></td>";
        te+="</tr>";
        te+="<tr>";
        te+="<td class='item_caption'>赠送印张数:</td><td class='item_content'><input name='txtPaperCount' id='txtPaperCount' type='text' class='num' size='10' runat='server'  maxlength='10' /></td>";
        te+="<td class='item_caption'>优惠价格:</td><td class='item_content' id='tdPrice'></td>";
        te+="</tr>";
        te+="</table>";
        businessTypeDetalInfo+="<td align='center'>"+te+"</td>";
        businessTypeDetalInfo+="<td>&nbsp;</td>";
        $("#tr1").html("");
        $("#tr1").html(businessTypeDetalInfo);
        $("#txtChargeAmount").blur(chargeAmount);
        $("#txtPaperCount").blur(paperCount);
    }
    catch(e)
    {
        alert(e);
    }
}
//计算差价
function computeDiffPrice()
{
    try
    {
        if(""!=$("#tdPrice").html())
        {
            var pricePactorList=data.BusinessType.PriceFactorList;
            var businessType=data;
            var diffPriceInfo="<td>&nbsp;</td>";
            var tt="<td align='center'>";
            tt+="<table width='100%' height='100%' border='1' cellspacing='1' cellpadding='3'>";
            tt+="<tr>";
            tt+="<td class='item_caption'>业务类型</td>";
            //设置列标题
            if(0==pricePactorList.length % 2 )
            {
                for(var i=1;i <pricePactorList.length; i=i+2)
               {
                   tt+="<td class='item_caption'>"
                   tt+=pricePactorList[i-1].Name;
                   tt+="</td>";
                   tt+="<td class='item_caption'>"+pricePactorList[i].Name+"</td>";  
               }
               tt+="<td class='item_caption'>门市价格</td>";
               tt+="<td class='item_caption'>差价</td>"; 
            }
            else
            {
               for(var i=1;i <pricePactorList.length-1; i=i+2)
               {
                   tt+="<td class='item_caption'>"
                   tt+=pricePactorList[i-1].Name;
                   tt+="</td>";
                   tt+="<td class='item_caption'>"+pricePactorList[i].Name+"</td>"; 
               }
               tt+="<td class='item_caption'>"+pricePactorList[pricePactorList.length-1].Name+"</td>";
               tt+="<td class='item_caption'>门市价格</td>";
               tt+="<td class='item_caption'>差价</td>"; 
            }
           
            tt+="</tr>";
            //设置列的内容
            tt+="<tr>";
            tt+="<td class='item_content'>"+data.BusinessType.Name+"</td>";
            if(0==pricePactorList.length % 2 )
            {
                for(var i=1;i <pricePactorList.length; i=i+2)
               {
                   tt+="<td class='item_content'>"+businessType.Texts[i-1]+"</td>";
                   tt+="<td class='item_content'>"+businessType.Texts[i]+"</td>";;  
               }
               tt+="<td class='item_content'>"+$("#hiddRoomPrice").val()+"</td>";
               tt+="<td class='item_content'>"+(parseFloat(data.ActivityPrice)-parseFloat($("#tdPrice").html())).toFixed(2)+"</td>"; 
            }
            else
            {
               for(var i=1;i <pricePactorList.length-1; i=i+2)
               {
                   tt+="<td class='item_content'>"+businessType.Texts[i-1]+"</td>";
                   tt+="<td class='item_content'>"+businessType.Texts[i]+"</td>";
               }
               tt+="<td class='item_content'>"+businessType.Texts[pricePactorList.length-1]+"</td>";
               tt+="<td class='item_content'>"+$("#hiddRoomPrice").val()+"</td>";
               tt+="<td class='item_content'>"+(parseFloat(data.ActivityPrice)-parseFloat($("#tdPrice").html())).toFixed(2)+"</td>"; 
            }
            tt+="</tr>";
            tt+="</table>";
            tt+="</td>";
            diffPriceInfo+=tt;
            diffPriceInfo+="<td>&nbsp;</td>";
            $("#tr2").html("");
            $("#tr2").html(diffPriceInfo);
            $("#hiddUnitPrice").val($("#tdPrice").html());//优惠价格
            $("#hiddCount").val($("#tdAmount").html()); //理论印章数
            $("#hiddRoomPrice").val($("#StandardPrice").html());//门市价格
        }
    }
    catch(e)
    {
        alert(e);
    }
}

function bingEdmitConcessionData(obj)
{
    try
    {
        if(""!=$("#hiddConcessionId").val())
        {
            var concession=obj.Concession;
            var memberCardLevel=obj.MemberCardLevelList;
            if(null!=concession && "undefined"!=concession)
            {
                //所属营销活动
                var campaign=$("#ddlCampaign")[0]; 
                for(var i=0;i<campaign.length;i++)
                {
                   if(campaign[i].value==concession.CampaignId)
                   {
                       $(campaign[i]).attr("selected","true");
                       break; 
                   }
                }
                $("#txtName").val(concession.Name);//优惠方案名称
                $("#txtDescription").val(concession.Description);//说明 
                var cbMemberCard=$("input:checkbox[@name=cbMemberLevel]");//卡级别
                for(var i=0;i<memberCardLevel.length;i++)
                {
                   for(var j=0;j<cbMemberCard.length;j++)
                   {
                       if(memberCardLevel[i].Id==cbMemberCard[j].value)
                       {
                           cbMemberCard[j].checked=true;
                       }
                   }
                }
                //充值金额
                $("#txtChargeAmount").val(concession.ChargeAmount);
                $("#txtPaperCount").val(concession.PaperCount);
                chargeAmount();
                paperCount();
                computeDiffPrice();
            }
        }
     }
    catch(e)
    {
        alert(e);
    } 
}
//计算印章数
function chargeAmount()
{
    //印章数=充值金额/门市价格
    var chargeAmount=parseInt($("#txtChargeAmount").attr("value"));
    var standardPrice=parseFloat($("#StandardPrice").html());
    if(!checkOnlyNum($("#txtChargeAmount"),true,chargeAmount.length))
    {
        $("#txtChargeAmount").focus();
        $("#txtChargeAmount").val("");
        return false;
    }
    if(parseFloat(chargeAmount)<parseFloat(standardPrice))
    {
        alert("充值金额不能小于门市价格!");
        $("#txtChargeAmount").focus();
        return false;
    }
     var a =chargeAmount/standardPrice;
    $("#tdAmount").html(parseInt(a));
}

//计算优惠价格
function paperCount()
{
    var paperCount=parseInt($("#txtPaperCount").attr("value"));
    if(!checkOnlyNum($("#txtPaperCount"),true,paperCount.length))
    {
        $("#txtPaperCount").focus();
        $("#txtPaperCount").val("");
        return false;
    }
    var amount=parseInt(parseInt($("#tdAmount").html()));
    var chargeAmount=$("#txtChargeAmount").attr("value");
    if(paperCount>amount)
    {
       alert("赠送的印章数不能大于印章数");
       $("#txtPaperCount").val("");
       return;
    }
    //最终价格=充值金额/(印章数+赠送印章数)
    var a = chargeAmount/ (amount +paperCount);
    if(!isNaN(a))
    {
       $("#tdPrice").html(a.toFixed(2));//保留两位有效数字   
    }
    //显示差价
    computeDiffPrice();
}

//优惠方案添加数据判断   
function insertBasePrice()
{
    var campaign = $("#ddlCampaign")
    if(campaign[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":所属所属营销活动");
        $("#ddlCampaign").focus();
        return false;
    }
    var cbMemberCardLevel=$("input:checkbox[@name=cbMemberLevel]");
    var cbMemberCardLevelLength=$("input:checkbox[@name=cbMemberLevel]").length;
    var count=0;
    for(var i=0;i<cbMemberCardLevelLength;i++)
    {
        if(cbMemberCardLevel[i].checked)
        {
           count++;
        }
    }
	if(count==0)
	{
		alert("至少选择一个卡级别!");
		return false;
	}
	
    if("false"==BusinessTypePrice) 
    {
        alert(MESSAGE_CHOICE+":基本价格");
        return false;
    }
   var ids;
   var rowLength = $("#BaseTable").children().children().length;
   for(var i=1;i< parseInt(rowLength);i++)
   {
        var idName = $("tr", $("#BaseTable")).get(i).className;
        ids = ids + ",";
        ids = ids + idName;
   }
   $("#hiddBaseBusinessTypePriceSerIds").attr("value", ids);
   
   if($("#txtName").val() == "")
   {
        alert(MESSAGE_EMPTY+":名称");
        $("#txtName").focus();
        return false;
   }
   
   if($("#txtChargeAmount").val() == "")
   {
        alert(MESSAGE_EMPTY+":充值金额");
        $("#txtChargeAmount").focus();
        return false;
   }
   else
   {
        var patrnDataNumber = /^(-?\d+)(\.\d+)?$/;
        if(!patrnDataNumber.exec($("#txtChargeAmount").val()))
        {
            alert("充值金额"+MESSAGE_NUMERAL);
            $("#txtChargeAmount").focus();
            return false;
        }
   }
   
   if($("#txtPaperCount").val() == "")
   {
        alert(MESSAGE_EMPTY+":赠送印张数");
        $("#txtPaperCount").focus();
        return false;
   }
   else
   {
        var patrnDataNumber = /^\d+(\.d+)?$/;
        if(!patrnDataNumber.exec($("#txtPaperCount").val()))
        {
            alert("赠送印张数"+MESSAGE_NUMERAL);
            $("#txtPaperCount").focus();
            return false; 
        }
   }       
    $("#hiddCount").attr("value",$("#Amount").html());
    $("#hiddUnitPrice").attr("value", $("#tdPrice").html());
    
   return true;
}

//单击Checkbox标签选中CheckBox
 function SelectedCheckBox(obj)
 {
    if(!obj.disabled)
    {
	    obj.checked=!obj.checked;
	}
}
