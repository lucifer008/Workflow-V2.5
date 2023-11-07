// JScript 文件
// 名    称: AddBuySend.js
// 功能概要: 新增买M送N方案js
// 作    者: 白晓宇
// 创建时间: 2010年4月16日
// 修正履历:
// 修正时间:
// 修正描述:

$(document).ready(function() {
	if (buySendId){
		if ($('#sltBusinessType').val()  && $('#sltBusinessType').val() != -1){
			var selectObj = document.getElementById('sltBusinessType');
			queryPriceSet(selectObj);
			
		}
	}
});

function queryPriceSet(sourceSelect){
    $("#isQuery").val("1");
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + sourceSelect.value;

    $.getJSON(url, {a : '2'}, provider.process);
}
function processJson(json, sourceSelect){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    var sltBusinessType=$("#sltBusinessType"); //处理业务类型
    var btnQuery=$("#btnQuery");  //处理按钮
    var factorMemory=$("#factorMemory").html("");
    factorMemory.append(sltBusinessType);
    for(var i=0; i<data.PriceFactor.length;i++){    
        pf=data.PriceFactor[i];
        var select = $("<select name=factorValuex"+pf.Id+" id=factorValuex"+pf.Id+" onchange='doRelationFactor(this);' ><option value='0' selected='selected'>请选择</option></select>");
        for (var j = 0; j < pf.FactorValueList.length; j++){
            var fv = pf.FactorValueList[j];
            $("<option value='" + fv.Id + "'>" + fv.Text + "</option>").appendTo(select);
        }
        $(select).attr("value","0");
        factorMemory.append(select);
    }
    factorMemory.append(btnQuery);
    //处理按钮
    processPriceSelect();
}
//获取因素的制约关系
function doRelationFactor(sourceSlt){
    if(sourceSlt.value==-1 || sourceSlt.value == 0) return;
    $(sourceSlt).attr("disabled",true);
    var businessTypeId=$("#sltBusinessType")[0].value;
    
    var provider = {};
    provider.source1 = sourceSlt;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+(sourceSlt.id.split('x'))[1]+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);
    
}

function processRelationFactor(json,sourceSlt){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    $(sourceSlt).attr("disabled",false);
    var priceFactor=data.PriceFactor;
    
    for(var i=0;i<priceFactor.length;i++){
        var obj=priceFactor[i];
        
        if(obj.FactorValueList.length>0){
            $("#factorValuex"+obj.Id).html("<option value='0' selected=true>请选择</option>");
            for(var j=0;j<obj.FactorValueList.length;j++)
            {
                $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#factorValuex"+obj.Id));
            }
            $($('option',$("#factorValuex"+obj.Id))[0]).attr('selected',true);
        }
    }
    
   
}

//提交前验证
function submitCheck(){
	var isOk = confirm('确定要添加吗？');
	if (!isOk) return;

	if($('#selectCapaign').val() == -1){
		alert(MESSAGE_CHOICE);
		$('#selectCapaign').focus();
		return false;
	}
	
	if (!$('#campaignName').val().length){
		alert(MESSAGE_EMPTY);
		$('#campaignName').focus();
		return false;
	}
	
	if (!$('#campaignName').val().length){
		alert(MESSAGE_EMPTY);
		$('#campaignName').focus();
		return false;
	}
	
	if (!$('#description').val().length){
		$('#description').focus();
		alert(MESSAGE_EMPTY);
		return false;
	}
	
	if (!$('#factorValuex2') || $('#factorValuex2').val() == 0 || !$('#factorValuex2').val() || $('#factorValuex2').val() == -1){
		alert('请选择机器');
		return false;
	}
	
	if (!$('#factorValuex3') || $('factorValuex3').val() == 0 || !$('#factorValuex2').val() || $('factorValuex3').val() == -1){
		alert('请选择纸质');
		return false;
	}
	
	if (!$('#inputBuyCount').val().length){
		alert(MESSAGE_EMPTY);
		$('#inputBuyCount').focus();
		return;
	} else if (isNaN($('#inputBuyCount').val())){
			$('#inputBuyCount').focus();alert(MESSAGE_NUMERAL);
			return;
	}
	
	if (!$('#inputSendCount').val().length){
		$('#inputSendCount').focus();
		$('#inputSendCount').select();
		alert(MESSAGE_EMPTY);
		return;
	} else if (isNaN($('#inputSendCount').val())){
			$('#inputSendCount').focus();
			$('#inputSendCount').select();
			alert(MESSAGE_NUMERAL);
			return;
	}
	
	if (!$('#inputTotalCount').val().length){
		alert(MESSAGE_EMPTY);
		$('#inputTotalCount').focus();
		return;
	} else if (isNaN($('#inputTotalCount').val())){
			alert(MESSAGE_NUMERAL);
			$('#inputTotalCount').focus();
			$('#inputTotalCount').select();
			return;
	}
	
	if (!$('#inputMemo').val()){
		alert(MESSAGE_EMPTY);
		$('#inputMemo').focus();
		return false;
	}
	
	$('#form1').submit();
}

function processPriceSelect(){
	if (priceInfo && buySendId){
		var priceFactor = priceInfo.split(',');
		for(var i = 0; i < priceFactor.length; i++){
			var factor = document.getElementById(priceFactor[i].split(':')[0]);
			if (factor){
				for(var j = 0 ; j < factor.options.length ;j++){
					if (factor.options[j].value == priceFactor[i].split(':')[1]){
						factor.options[j].selected = true;
					}
				}
			}
		}
	}
}