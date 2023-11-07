// JScript 文件

var factorCount = 0;
var defaultData = new Array();
var modifyBusinessTypeId = null;
var editTag = false;
//Array.prototype.remove = function(i){
//    this.splice(i,1);
//}
//修改指定行数据
function addInfo(currentTd){
    
    var displayTable = $('#tableInfo');
    var sltArr = $("select", $(currentTd).parent().parent());
    //alert(sltArr.length);
    
    var defaultItem = new defaultVvalueObject();
    var pfa = new Array();
    
    for(var i = 0; i < sltArr.length; i++){
        if (sltArr[i].id == "sltBusinessType"){
            defaultItem.btid = sltArr[i].value; 
            if(sltArr[i].value == -1){
                sltArr[i].focus();
                alert('请选择业务类型!');
                return;
            }
        }
        //优化价格因素保存 方便扩展
        if (sltArr[i].id && (i != 0) ){
            if (sltArr[i].value == -1){
                sltArr[i].focus();
                alert('请选择价格因素!');    
                return;
            }
            
            var tempObj = new Object();
            tempObj.id = sltArr[i].id.split('x')[1];
            tempObj.v = sltArr[i].value;
            pfa.push(tempObj);
        }
    }
    defaultItem.pfa = pfa;
    if (editTag){//debugger;
        for(var i = 0; i < defaultData.length; i++){
            if (defaultItem.btid == defaultData[i].btid){
                defaultData.splice(i,1);
                break;
            }
        }
        editTag= false;
         $('#aBtn')[0].innerHTML = '添加';   
         $('#info'+defaultItem.btid).remove();
    }

    //debugger;
    //将数据保存到数组中
    var isExist = isExistItem(defaultItem);
    if (!isExist){
        defaultData.push(defaultItem);
    }else{
        alert('当前项已经存在');
        return;
    }
    
    //添加表格信息显示
    var strHTML = '<tr id="info'+defaultItem.btid+'">';
    var tdArr = $("td", $(currentTd).parent().parent());
    for(var i = 0; i < tdArr.length; i++){
        strHTML += '<td nowrap="nowrap" class="w1">'
        var temp = $('select', $(tdArr[i]));
        if (temp.length){
            for(var j = 0; j < temp[0].options.length; j++){
                if (temp[0].options[j].selected){
                    strHTML += temp[0].options[j].innerHTML;
                }
            }
            
        }else{
           // strHTML += tdArr[i].value;
        }
        
        //加入操作按钮
        if (i == (tdArr.length -1)){
            strHTML += '<a href="#" onclick="removeDefaultItem(this,'+defaultItem.btid+')"> 删除</a>&nbsp;&nbsp;&nbsp;&nbsp;';
            //strHTML += '<a href="#" onclick="modifyDefaultItem(this,'+defaultItem.btid+')">修改 </a>'
        }
        strHTML += '</td>';
    }
    strHTML += '</tr>';
    
    var trObj = $(strHTML);
    trObj.appendTo(displayTable);

   // alert(defaultData.length);
   //排序和填补单元格
    submitForm('add');
    
}
//获取下拉列表的选中文本
function getSelectText(obj){
    //debugger;
    if (obj){
        for(var i = 0; i < obj.options.length; i ++){
            if (obj.options[i].selected){
                return obj.options[i].innerHTML;
            }
        }
    }
    return null;
}

//修改选中项
function modifyDefaultItem(obj, businessTypeId){
    var defaultItem = null;
    for(var i = 0; i < defaultData.length; i++){
        if (businessTypeId == defaultData[i].btid){
            defaultItem = defaultData[i];
            break;
        }
    }
    editTag = true;
    //debugger;
    $('#aBtn')[0].innerHTML = '修改';   
    var businessType = $('#sltBusinessType');
    for(var i = 0 ; i  < businessType[0].options.length; i++){
        if (businessTypeId == businessType[0].options[i].value){
            businessType[0].options[i].selected = true;
        }
    }
    
    doProcess(businessType[0]);
}

function modifyProcess(){
    
}

//删除选中的默认值
//(删除表格中显示的数据
//删除数组中的记录)
function removeDefaultItem(obj,businessTypeId){
    var confirmObj = confirm('确定要删除吗？');
    if (!confirmObj){
        return;
    }
    //删除表格中显示数据
    var trObj = $(obj).parent().parent();
    trObj.remove();

    //删除数据种数据
    for(var i = 0; i < defaultData.length; i++){
        if (businessTypeId == defaultData[i].btid){
            defaultData.splice(i,1);
            break;
        }
    }
    submitForm('del');
}

//是否存在 
function isExistItem(defaultItem){
    if (defaultData && defaultItem){
        for(var i = 0; i < defaultData.length; i++){
            if (defaultItem.btid == defaultData[i].btid){
                return true;
                break;
            }        
        }
        return false;
    }
    return false;
}


//获取动态因素
function doProcess(sourceSelect)
{ 
    $(sourceSelect).attr("disabled",true);
    var sltArr=$("select",$(sourceSelect).parent().parent());
        
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].id!="sltBusinessType" && sltArr[i].id!="sltBusinessType1")
        {
            //$(sltArr[i]).parent().text("-");
            $(sltArr[i]).remove();
        }
    }

    if (sourceSelect.value == -1) {
        var currentTr = $(sourceSelect).parent().parent();
        var pos = $(".no", currentTr).html();
        clearTrContext($("td",currentTr));
        if($(sourceSelect).attr("disabled"))
        {
            $(sourceSelect).attr("disabled",false);
        }
        return;
    }
    
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    
    
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + sourceSelect.value;

    $.getJSON(url, {a : '2'}, provider.process);
    $(sourceSelect).attr("disabled",false);
    
}


function processJson(json, sourceSelect){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    //reBuildTableHeader(data,sourceSelect);
    var currentProcessTr = $(sourceSelect).parent().parent();
    var currentRowNumber=$($("TD",currentProcessTr)[0]).text();
    //var pos = $(".no", currentProcessTr).html();
    clearTrContext($("td",currentProcessTr));
    var currentColumnIndex = 2;
    for (var i = 0; i < data.PriceFactor.length; i++) {
        var pf = data.PriceFactor[i];
        var th = $("#th" + pf.Id);
        if(undefined!=th.attr("index"))
        {
            currentColumnIndex=th.attr("index");
        }
        else
        {
            continue;
        }
        var currentCell = $($("td",currentProcessTr)[currentColumnIndex]);
        currentCell.html("");
        
        //var currentCell=$("<td></td>");
        
        var selectName = currentRowNumber + pf.Id + "f";
        var selectId = currentRowNumber+"x"+pf.Id;
        var select = $("<select name="+selectName+" id="+selectId+" onchange='doRelationFactor(this);' ><option value='-1' selected='selected'>请选择</option></select>");
        
        
        for (var j = 0; j < pf.FactorValueList.length; j++){
            var fv = pf.FactorValueList[j];
            $("<option value='" + fv.Id + "'>" + fv.Text + "</option>").appendTo(select);
        }
        $(select).attr("value","-1");
        
        select.appendTo(currentCell);
        currentColumnIndex++;
    }
    //$(currentProcessTr).focus();
}


function clearTrContext(tr) {
    var begin = 2;
    for (var i = 0; i < factorCount; i++) {
        $(tr[begin + i]).html("-");
    }    
}

//获取因素的制约关系
function doRelationFactor(sourceSlt)
{
    if(sourceSlt.value==-1) return;
    $(sourceSlt).attr("disabled",true);
    var currentProcessTr = $(sourceSlt).parent().parent();
    var currentRowNumber=$($("TD",currentProcessTr)[0]).text();
    
    var businessTypeId=$("select[@name='BusinessType']")[currentRowNumber-1].value;
    var nextSltId=parseInt(sourceSlt.id)+1;
    


    var provider = {};
    provider.source1 = currentRowNumber;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+(sourceSlt.id.split('x'))[1]+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);
    $(sourceSlt).attr("disabled",false);

}
function processRelationFactor(json,currentRowNumber)
{
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }    
    //var factorValueList=data.PriceFactor[0].FactorValueList;
    var priceFactor=data.PriceFactor;
    
    //如果找到制约因素的值，则添加，否则，默认为全部
   
    for(var i=0;i<priceFactor.length;i++)
    {
        var obj=priceFactor[i];
        
        if(obj.FactorValueList.length>0)
        {
            $("#"+currentRowNumber+"x"+obj.Id).html("<option value='-1' selected=true>请选择</option>");
            for(var j=0;j<obj.FactorValueList.length;j++)
            {
                $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#"+currentRowNumber+"x"+obj.Id));
            }
            $($('option',$("#"+currentRowNumber+"x"+obj.Id))[0]).attr('selected',true);
        }
    }
}

//提交信息
function submitForm(type){
    var confirmObj = null;
    if (type == 'del' || type == 'add'){
        confirmObj = true;
    }else{
        confirmObj = confirm('确定要保存吗？');
    }
    if (confirmObj){
        //debugger;
        var strJson =$.toJSON(defaultData);
        //alert(strJson);
        $('#hidMemo').val(strJson);
        $('#form1').submit();
    }else{
        return false;
    }
    
}

//默认值对象
function defaultVvalueObject(businessTypeId,priceFactorArr){
    this.btid = businessTypeId;
    this.pfa =  priceFactorArr;
}

if(window.attachEvent){
	window.attachEvent('onload',pageLoad); 
}
else{
	window.addEventListener('load',pageLoad,false);
}

//页面加载
var defaultNameArray=null;
function pageLoad(){
    try
    {
        var strJson = document.getElementById('hidMemo').value;
        var strNameJson = document.getElementById('hidMemoName').value;
        if (strJson !=""){
            eval("defaultData="+strJson);
        }
        if (strNameJson != ""){
            eval("defaultNameArray="+ strNameJson);
        }
    }catch(e){
        alert(e.message);
    }
    //debugger;
    initDefaultInfo();
}

//初始化已经设置好的信息
function initDefaultInfo(){
    //添加表格信息显示

    
    var table = $('#tableInfo')
    var trArr = $('tr', $(table));
    var thArr = $('th', $(trArr[0]));
    var strHTML = '';
    for(var i = 0; i < defaultData.length; i++){
            strHTML = '<tr id="info'+defaultData[i].btid+'">';
        for(var j = 0; j < thArr.length; j++){
            strHTML += '<td>';
            
            if (j == 1){
               // strHTML += defaultData[i].btid;
                strHTML += defaultNameArray[i].btname  || "-";
            }
            var  priceFactorId = null;
            if (thArr[j].id && thArr[j].index){
                priceFactorId = thArr[j].id.split('thInfo')[1];
            }
            
            var temp =  (j -1);
            
            for(var m = 0; m < defaultData[i].pfa.length; m++){
                if (priceFactorId == defaultData[i].pfa[m].id){
                    strHTML += defaultNameArray[i].pfa[m].name;
                }
            }
            
            if (thArr.length == j + 1){
                 strHTML += '<a href="#" onclick="removeDefaultItem(this,'+defaultData[i].btid+')"> 删除</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                // strHTML += '<a href="#" onclick="modifyDefaultItem(this,'+defaultData[i].btid+')">修改 </a>'
            }
            
            strHTML += '</td>';
        }
        strHTML += '</tr>';
       $(strHTML).appendTo(table);
    } 
    
  
    //排序和填补单元格
    sortTabeNo();
}
////页面加载
//$(document).ready(
//    try
//    {
//        var strJson = document.getElemetnById('hidMemo');
//        eval("defaultData="+strJson);
//    }catch(e){
//        alert(e.message);
//    }
//    debugger;

//)
//
function sortTabeNo(){
    var trArr = $('tr',$('#tableInfo'));
    for(var i = 0; i < trArr.length; i++){
        var tdArr = $('td', $(trArr[i]));
        if (tdArr.length){
            tdArr[0].innerHTML = i;
        }
    }
    
    //填补空单元格
    var tdArr = $('td', $($('#tableInfo')));
    for(var i = 0; i < tdArr.length; i++){
        //debugger;
        if (tdArr[i].innerHTML == ''){
            tdArr[i].innerHTML = '-';
        }
    }
}
