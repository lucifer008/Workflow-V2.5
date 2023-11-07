<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaseSetPrice.aspx.cs" Inherits="BaseSetPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>设置价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/check.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/mangePrice.js"></script>
  <script type="text/javascript" language="javascript" src="../../js/escExit.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/baseSetPrice.js"></script>
  <script type="text/javascript">
<%if (closeSelf) {%>
$().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
      opener.location.reload('SalesRoomPriceSetting.aspx');
      window.close();
      return;
    }
  }
  );
<%} %>
  </script>

</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <%if (closeSelf) { return; } %>
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
            <input id="txtAction" name="txtAction" type="hidden" value="1" />
            <input id="txtId" name="txtId" type="hidden" value="<%=lngCurId%>" />
          <td width="11"><img src="../../images/white_main_top_left.gif"/></td>
          <td width="99%"><img src="../../images/spacer_10_x_10.gif" height="10"/></td>
          <td width="10"><img src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td></td>
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt;门市价格设置</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">门市价格设置</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                          <tr>
                            <td nowrap class="item_caption">业务类型:</td>
                            <td colspan="3" class="item_content">
                              <select id ="sltBusinessType"  name="sltBusinessType" onchange="doProcess(this);" >
                              <!--此处的业务类型应该就是选定的项目,不应该允许修改-->

                                <option selected value="<%=model.BaseBusinessTypePriceSet.BusinessType.Id %>">
                                  <%=model.BaseBusinessTypePriceSet.BusinessType.Name%>
                                </option>


                              <!--
                              <option value="0">不限</option>
                                <%  
                                  for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {
                                    if (model.BusinessTypeList[i].Id == model.BaseBusinessTypePriceSet.BusinessType.Id)
                                    {%>
                                <option selected value="<%=model.BusinessTypeList[i].Id %>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%}
                                  else
                                  {%>
                                <option value="<%=model.BusinessTypeList[i].Id %>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%}
                                }%>
                                -->
                                
                              </select>
                            </td>
                          </tr>
                          <tr id="trQuery" style="display:none">
                          <td colspan="4"></td>
                          </tr>
                          <% 	   
                                    int intPriceFactorCount = model.PriceFactor.Count;
                                    int LastAddRow = intPriceFactorCount % 2;
                                    for (int i = 0, j = 0; i < intPriceFactorCount / 2 + LastAddRow; i++, j++)
                                    {
                                     
                          %>

                          <tr name="trName">
                            <td nowrap class="item_caption"><%=model.PriceFactor[j].DisplayText%>:</td>
                            <td class="item_content" align="left">
                              <select name="sltPriceFactor" id="PriceFactor<%=model.PriceFactor[j].Id.ToString()%>" title="<%=model.PriceFactor[j].DisplayText %>"  onchange="PriceFactor_Changed(this)">
                                <option value="-1">请选择</option>
                                <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                                  {
                                    if (model.PriceFactor[j].FactorValueList[k].Id == model.BaseBusinessTypePriceSet[j])
                                    {%>
                                <option selected value="<%=model.PriceFactor[j].FactorValueList[k].Id %>">
                                  <%=model.PriceFactor[j].FactorValueList[k].Text%>
                                </option>
                                <%
                            }
                            else
                            {
                                %>
                                <option value="<%=model.PriceFactor[j].FactorValueList[k].Id %>">
                                  <%=model.PriceFactor[j].FactorValueList[k].Text%>
                                </option>
                                <% 
                            }
                          } %>
                              </select>
                            </td>
                            <%
                              //开始检测是否超出设定因素
                              if (j >= (intPriceFactorCount - 1))
                              { 
                             %>
                            <td nowrap class="item_caption"></td>
                            <td class="item_content" align="left"></td>
                             <%                           
                              }
                              else
                              {   //是否超出设定因素
                             %>
                            
                            <td nowrap class="item_caption"><%=model.PriceFactor[++j].DisplayText%>:</td>
                            <td class="item_content" align="left">
                              <select name="sltPriceFactor" id="PriceFactor<%=model.PriceFactor[j].Id.ToString()%>"  title="<%=model.PriceFactor[j].DisplayText %>" onchange="PriceFactor_Changed(this)">
                                <option value="-1">请选择</option>
                                <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                                  {
                                    if (model.PriceFactor[j].FactorValueList[k].Id == model.BaseBusinessTypePriceSet[j])
                                    {%>
                                <option selected value="<%=model.PriceFactor[j].FactorValueList[k].Id %>">
                                  <%=model.PriceFactor[j].FactorValueList[k].Text%>
                                </option>
                                <%
                              }
                              else
                              {
                                %>
                                <option value="<%=model.PriceFactor[j].FactorValueList[k].Id %>">
                                  <%=model.PriceFactor[j].FactorValueList[k].Text%>
                                </option>
                                <% 
                              }
                            } %>
                              </select>
                            </td>
                            <%
                              }   //是否超出设定因素    
                             %>
                          </tr>
                          <%     
                            }%>
                          <tr>
                            <td nowrap class="item_caption">成本价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtCostPrice" name="txtCostPrice" type="text" class="num" value="<%=model.BaseBusinessTypePriceSet.CostPrice%>" size="10" /></td>
                            <td nowrap class="item_caption">标准价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtStandardPrice" name="txtStandardPrice" type="text" class="num" value="<%=model.BaseBusinessTypePriceSet.StandardPrice%>" size="10" /></td>
                          </tr>
                          <tr>
                            <td nowrap class="item_caption">活动价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtActivityPrice" name="txtActivityPrice" type="text" class="num" value="<%=model.BaseBusinessTypePriceSet.ActivityPrice%>" size="10" /></td>
                            <td nowrap class="item_caption">备用价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtReservePrice" name="txtReservePrice" type="text" class="num" value="<%=model.BaseBusinessTypePriceSet.ReservePrice%>" size="10" />
                            </td>
                          </tr>
                          <tr>
                            <td nowrap class="item_caption">备注:</td>
                            <td colspan="3" align="left" nowrap>
                              <span class="item_content" style="padding-top: 2px; padding-bottom: 2px;">
                                <textarea name="txtMemo" cols="95" rows="3"></textarea>
                              </span>
                            </td>
                          </tr>
                        </table>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3"></td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                        <input name="Submit34" class="buttons" value="保存" onclick="savePriceSet();" type="button"/>
                        &nbsp;<input name="Submit3342" class="buttons" value="关闭" onclick="window.close()" type="button"/>
                      </td>
                    </tr>
                    <tr height="5">
                      <td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">&nbsp;</td>
                      <td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11"><img src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%"><img src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10"><img src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
