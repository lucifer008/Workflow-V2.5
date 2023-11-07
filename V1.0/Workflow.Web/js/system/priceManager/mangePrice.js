/// <summary>
/// 名    称: doProcess
/// 功能概要: 选择业务类型选择变化后的处理
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="sourceSelect">业务类型选择Combox</param>
function doProcess(sourceSelect){
    if (sourceSelect.value == 0) {
        initAllRow(sourceSelect);
        $("tr[@name=trDetail]").remove();
        return;
    }
    source = sourceSelect;
    var url = "/Workflow.Web/ajax/AjaxEngine.aspx" + "?Action=Change&BusinessTypeId=" + source.value;
    $.getJSON(url, {a : '4'}, processJson);
}

/// <summary>
/// 名    称: doQuery
/// 功能概要: 页面上客户选择查询后的处理
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="sourceSelect">业务类型选择Combox</param>
function doQuery(){
  if ($("#sltBusinessType").attr("value")==0){
    alert('请选择业务类型!');
    $("#sltBusinessType").focus();
  }
  
  var where =new Array();
  var id = $("#sltBusinessType").attr("value");
  $("select[@name=sltPriceFactor]").each(function(i, select){
    //var command = "objQueryWhere.obj" + i + "='" + $(select).attr("value") + "';";
    //eval(command);
    where[i] = $(select).attr("value");
  });
  var url1 = "/Workflow.Web/ajax/AjaxEngine.aspx" + "?Action=Query&BusinessTypeId=" +id +"&QueryWhere=" + where.toString();
  $.getJSON(url1, {a : '4'}, showProcessJson);
}
/// <summary>
/// 名    称: showProcessJson
/// 功能概要: 页面上的显示(doQuery的回调函数)
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="json">Ajax执行结果</param>
function showProcessJson(json){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    var pf=data.PriceFactor;
    var fs=data.BaseBusinessTypePriceSetList;
    //动态显示表头
    showTableHead(pf);
    showTableDetail(fs);
    //清除所有的表格
    //initTableRow
}

/// <summary>
/// 名    称: processJson
/// 功能概要: 处理选择业务后的前台页面的布局(doProcess的回调函数)
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="json">Ajax执行结果</param>
function processJson(json){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    initAllRow(source)
    if (data.PriceFactor.length==0) return;
    //获得当前Table
    var currentTable = $(source).parent().parent().parent().parent();
    //取得当前检索button所在行的Tr
    var currentTr = $("#trQuery",currentTable);
    var pf;
    for (var i=0;i< data.PriceFactor.length; i++){
      //将要插入的Tr
      var curTr=$("<tr name='trName'></tr>");
      $(curTr).prependTo(currentTable);
      $(currentTr).before($(curTr));
      pf = data.PriceFactor[i];
      $(curTr).append($("<td>"+pf.DisplayText+"</td>").attr("class","item_caption"));
      $("<td></td>").attr("class","item_content").append(getSelectControl(pf)).appendTo(curTr);
      if (i==data.PriceFactor.length-1)
      {
        $(curTr).attr("class","item_caption").append("<td>&nbsp;</td>");
        $(curTr).attr("class","item_content").append("<td>&nbsp;</td>");  
      }
      else
      { 
        pf = data.PriceFactor[++i];
        $(curTr).append($("<td>"+pf.DisplayText+"</td>").attr("class","item_caption"));
        $("<td></td>").attr("class","item_content").append(getSelectControl(pf)).appendTo(curTr);
      }
      
    }  
  }
  
/// <summary>
/// 名    称: showTableHead
/// 功能概要: 显示表头
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="pf">价格因素</param>
  function showTableHead(pf)
  {
      $("tr[@name=trHeadRow]").remove();
      var curTable=$("#tblResult");
      var preThRow=$("<tr name='trHeadRow'></tr>").appendTo(curTable);
      
      //选择框占用列
      preThRow.append("<th width='1%' nowrap>&nbsp;</th>");
      preThRow.append("<th width='1%' nowrap>No</th>");
      preThRow.append("<th width='1%' nowrap>业务类型</th>");
      for(var i=0;i<pf.length;i++){
        preThRow.append("<th width='1%' nowrap>"+pf[i].Name+"</th>");
      }
      preThRow.append("<th width='1%' nowrap>单价</th>");
      preThRow.append("<th nowrap>备注</th>");
  }
  
/// <summary>
/// 名    称: showTableHead
/// 功能概要: 显示明细
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="basePriceSetList">价格设置一览</param>
  function showTableDetail(basePriceSetList)
  {
    var curTable=$("#tblResult");
    var preTrRow;
    //显示之前先清空所有数据
    $("tr[@name=trDetail]",curTable).remove();
    for(i=0;i<basePriceSetList.length;i++){
    //追加一个空行
    preTrRow=$("<tr name='trDetail'></tr>").appendTo(curTable);
    //选择框占用列
    preTrRow.append("<td><input type='checkbox' name='chk' value='"+basePriceSetList[i].Id+"'></td>");
    preTrRow.append("<td align=center>"+(i+1)+"</td>");
      var fv=basePriceSetList[i].Texts;
      var bt=basePriceSetList[i].BusinessType;
      preTrRow.append("<td>"+bt.Name+"</td>");
      for(j=0;j<fv.length;j++){
        preTrRow.append("<td nowrap>"+fv[j]+"</td>");
      }
      //单价
      preTrRow.append("<td align='right'>"+basePriceSetList[i].StandardPrice+"</td>");
      //备注
      preTrRow.append("<td nowrap></td>");
    }
  }
  
/// <summary>
/// 名    称: initAllRow
/// 功能概要: 获得因素值的Select
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// <param name="sourceSelect">业务类型选择Combox</param>
function initAllRow(sourceSelect) {
    //获得当前Table
    var curentTable = $(sourceSelect).parent().parent().parent().parent();
    $("tr[@name=trName]",curentTable).remove();
}
/// <summary>
/// 名    称: getSelectControl
/// 功能概要: 获得因素值的Select
/// 作    者: 麻少华
/// 创建时间: 2007-9-28
/// 修正履历: 
/// 修正时间: 
/// </summary>
function getSelectControl(pf)
{
    var select = $("<select name='sltPriceFactor' id='f" + pf.id + "'></select>");
    select.append("<option value='0' selected='selected'>请选择</option>");
    for (var i = 0; i < pf.FactorValueList.length; i++)
    {
       var fv = pf.FactorValueList[i];
       select.append("<option value='" + fv.Id + "'>" + fv.Text + "</option>");
    }
    //select.attr("selectedIndex","0");
    select.attr("value","0");
    return select;
}

function savePriceSet(){
    if ($("#txtBusinessName").val()=="")
    {
      alert('请输入业务类型');
      $("#txtBusinessName").focus();
      return false;
    }
    var select=$("input:checkbox[@name=chkFactor]");
    var intcount=0;
    select.each(function(i,opt){
      if (opt.checked)
      {intcount++;}
    }
    );
    if (intcount==0)
    {
      alert('请至少选择一种因素');
      return false;
    }
    $("#txtAction").attr("value","3");
    $("#MainForm").submit();
}