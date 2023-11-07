<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectStandardPrice.aspx.cs"
  Inherits="SelectOnePrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>选择门市价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/mangePrice.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/selectStandardPrice.js"></script>
  <script type="text/javascript" src="../../js/escExit.js"></script>
  <base target="_self"></base>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <input id="txtIdList" type="hidden" name="txtIdList" />
      <input id="txtAction" type="hidden" name="txtAction" />
      <input id="txtPageType" type="hidden" name="txtPageType" value="<%=intPageType%>" />
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
                        首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 选择门市价格</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        选择门市价格<% =strPageTypeName%></td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellspacing="1" cellpadding="3">
                          <tr>
                            <td class="item_caption">
                              业务类型:</td>
                            <td colspan="3" class="item_content">
                              <select id="sltBusinessType" name="sltBusinessType" onchange="doProcess(this);">
                                <option value="0">请选择</option>
                                <%  
                                  for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {
                                %>
                                <option value="<%=model.BusinessTypeList[i].Id %>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%}
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr class="querybuttons" id="trQuery">
                            <td colspan="4">
                              <%--<input name="btnQuery" type="button" class="buttons" value="查询" onclick="doQuery();" />--%>
                              <input name="btnQuery" type="button" class="buttons" value="查询" onclick="doQuery();" />
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table id="tblResult" width="100%" border="1" cellpadding="3" cellspacing="1">
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                        <input name="Submit34" class="buttons" value="下一步" type="button"/>
                        &nbsp;<input name="Submit3342" class="buttons" value="关闭" onclick="window.close();"
                          type="button"/></td>
                    </tr>
                    <tr height="10px">
                      <td colspan="3">
                      </td>
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
