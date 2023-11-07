<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetPrice.aspx.cs" Inherits="SetPrice" %>

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
  <script type="text/javascript" src="../../js/system/priceManager/setPrice.js"></script>
  <script type="text/javascript">
<%if (closeSelf) {%>
$().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
//      debugger;
//      opener.$("#AspNetPager1").attr("CurrentPageIndex",3);
      opener.$("#MainForm").submit();
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
    <input id="txtAction" name="txtAction" type="hidden" value="1" />
    <input id="txtId" name="txtId" type="hidden" value="<%=lngCurId%>" />
    <input id="txtPageType" name="txtPageType" type="hidden" value="<%=intPageType%>" />
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img src="../../images/white_main_top_left.gif"/></td>
          <td width="99%">
            <img src="../../images/spacer_10_x_10.gif" height="10"/></td>
          <td width="10">
            <img src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td>
                      </td>
                      <td align="left" bgcolor="#eeeeee">
                        首页 -&gt; 系统管理 -&gt; 价格管理 -&gt;
                        <%=strPageTypeName%>
                      </td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        <%=strPageTypeName%>
                      </td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                          <tr>
                            <td nowrap class="item_caption">
                              业务类型:</td>
                            <td colspan="3" class="item_content">
                              <select id ="sltBusinessType" name="sltBusinessType" onchange="doProcess(this);">
                              <option value="0">不限</option>
                                <%  
                                  for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {
                                    if (model.BusinessTypeList[i].Id == model.BusinessTypePriceSet.BusinessType.Id)
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
                              </select>
                            </td>
                          </tr>
                         <tr id="trQuery" style="display:none">
                          <td colspan="4"></td>
                          </tr>
                          <% 	   
                                    int intPriceFactorCount = model.PriceFactor.Count;
                                    for (int i = 0, j = 0; i < intPriceFactorCount / 2; i++, j++)
                                    {
                                      //初始化的时候不显示
                                      //if (intAction == Workflow.Support.Constants.ACTION_INIT) break;
                          %>
                          <tr name="trName">
                            <td nowrap class="item_caption">
                              <%=model.PriceFactor[j].DisplayText %>
                              :</td>
                            <td class="item_content" align="left">
                              <select name="sltPriceFactor">
                                <option value="0">不限</option>
                                <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                                  {
                                    if (model.PriceFactor[j].FactorValueList[k].Id == model.BusinessTypePriceSet[j])
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
                            <td nowrap class="item_caption">
                              <%=model.PriceFactor[++j].DisplayText %>
                              :</td>
                            <td class="item_content" align="left">
                              <select name="sltPriceFactor">
                                <option value="0">不限</option>
                                <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                                  {
                                    if (model.PriceFactor[j].FactorValueList[k].Id == model.BusinessTypePriceSet[j])
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
                          </tr>
                          <%     
                            }%>
                          <tr>
                            <td nowrap class="item_caption">
                              成本价格:</td>
                            <td nowrap class="item_content">
                              <input id="txtCostPrice" name="txtCostPrice" type="text" class="num" value="<%=model.BusinessTypePriceSet.CostPrice%>"
                                size="10" /></td>
                            <td nowrap class="item_caption">
                              标准价格:</td>
                            <td nowrap class="item_content">
                              <input id="txtStandardPrice" name="txtStandardPrice" type="text" class="num" value="<%=model.BusinessTypePriceSet.StandardPrice%>"
                                size="10" /></td>
                          </tr>
                          <tr>
                            <td nowrap class="item_caption">
                              活动价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtActivityPrice" name="txtActivityPrice" type="text" class="num" value="<%=model.BusinessTypePriceSet.ActivityPrice%>"
                                size="10" /></td>
                            <td nowrap class="item_caption">
                              备用价格:</td>
                            <td nowrap class="item_content">
                              <input id="txtReservePrice" name="txtReservePrice" type="text" class="num" value="<%=model.BusinessTypePriceSet.ReservePrice%>"
                                size="10" /></td>
                          </tr>
                          <tr>
                            <td nowrap class="item_caption">
                              新价格:</td>
                            <td nowrap class="item_content">
                              <input id ="txtNewPrice" name="txtNewPrice" type="text" class="num" size="10" value="<%=model.BusinessTypePriceSet.NewPrice%>" /></td>
                            <td nowrap class="item_caption">
                              折扣:</td>
                            <td nowrap class="item_content">
                              <input id ="txtConcession" name="txtConcession" type="text" class="num" size="10" value="<%=model.BusinessTypePriceSet.PriceConcession%>" />
                              %</td>
                          </tr>
                          <tr>
                            <td nowrap class="item_caption">
                              备注:</td>
                            <td colspan="3" align="left" nowrap>
                              <span class="item_content" style="padding-top: 2px; padding-bottom: 2px;">
                                <textarea name="txtMemo" cols="95" rows="3"></textarea>
                              </span>
                            </td>
                          </tr>
                        </table>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                        <input name="Submit34" class="buttons" value="保存" onclick="savePriceSet();" type="button"/>
                        &nbsp;<input name="Submit3342" class="buttons" value="关闭" onclick="window.close()"
                          type="button"/></td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">
                        &nbsp;</td>
                      <td>
                        <img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%">
            <img src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10">
            <img src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
