<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusinessType.aspx.cs" Inherits="BusinessType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>ҵ����������</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/check.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/businessType.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" runat="server" method="post">
    <div align="center" style="width: 99%;" bgcolor="#FFFFFF" id="container">
      <input id="txtAction" name="txtAction" type="hidden"/>
      <input id="txtId" name="txtId" type="hidden"/>
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img alt="" src="../../images/white_main_top_left.gif" /></td>
          <td width="99%">
            <img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
          <td width="10">
            <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td>
                      </td>
                      <td align="left" bgcolor="#eeeeee">
                        ��ҳ -&gt; ϵͳ���� -&gt; �۸���� -&gt; ҵ����������</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        ҵ����������</td>
                    </tr>
                    <tr>
                      <td width="3%">
                      </td>
                      <td align="left">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">
                              ҵ������:</td>
                            <td class="item_content">
                              <select id="sltBusinessTypeName" name="sltBusinessTypeName" onchange="getBusinessProcess(this)">
                                <option value="-1">��ѡ��</option>
                                <%
                                  for (int i = 0; i < model.BusinessTypeMaster.Count; i++)
                                  {   
                                %>
                                <%
                                  if (model.BusinessTypeMaster[i].Id == lngBusinessTypeId)
                                  { %>
                                <option value="<%=model.BusinessTypeMaster[i].Id%>" selected>
                                  <%=model.BusinessTypeMaster[i].Name%>
                                </option>
                                <%}
                                  else
                                  {%>
                                <option value="<%=model.BusinessTypeMaster[i].Id%>">
                                  <%=model.BusinessTypeMaster[i].Name%>
                                </option>
                                <%
                                  }
                                }
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr class="querybuttons">
                            <td colspan="2" nowrap="nowrap">
                              <input id="btnQuery" name="btnQuery" type="button" value="��ѯ" />
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">
                      </td>
                    </tr>
                    <tr>
                      <td width="3%">
                      </td>
                      <td align="left">
                        <input name="btnAddBusinessType" type="button" class="buttons" onclick="showAddBusinessType();"
                          value="�½�ҵ������" id="Button1" /></td>
                      <td width="3%">
                      </td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table id="tabledetail" width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap="nowrap">
                              &nbsp;NO&nbsp;</th>
                            <th width="30%" nowrap="nowrap">
                              ҵ������</th>
                            <th width="40%" nowrap="nowrap">
                              �������</th>
                            <th nowrap="nowrap">
                              ��ע</th>
                            <th width="1%" nowrap="nowrap">
                              &nbsp;</th>
                          </tr>
                          <%  
                            StringBuilder strFactorNames = new StringBuilder();
                            string strSplitChar = ",";
                            int intCruentRow = 0;
                            for (int i = 0; i < model.BusinessTypeList.Count; i++)
                            {
                              //if (model.BusinessTypeList[i].PriceFactorList.Count == 0)
                                //continue;

                              //������ؼ���
                              strFactorNames.Remove(0, strFactorNames.Length);
                              for (int j = 0; j < model.BusinessTypeList[i].PriceFactorList.Count; j++)
                              {
                                //׷��ͬһҵ�������µ����ؼ���
                                if (strFactorNames.ToString() != "")
                                {
                                  strFactorNames.Append(strSplitChar);
                                }
                                //׷��ͬһҵ�������µ����ؼ���
                                strFactorNames.Append(model.BusinessTypeList[i].PriceFactorList[j].Name);
                              }
                          %>
                          <tr>
                            <td align="center">
                              <%=++intCruentRow%>
                            </td>
                            <td align="left">
                              <%=priceAction.Model.BusinessTypeList[i].Name%>
                            </td>
                            <td align="left">
                              <%=strFactorNames.ToString()%>
                            </td>
                            <td>
                              &nbsp;</td>
                            <td align="left" nowrap="nowrap">
                              <a href="#" onclick="showEditBusinessType(<%=model.BusinessTypeList[i].Id %>,'<%=priceAction.Model.BusinessTypeList[i].Name %>');">
                                �༭</a> <a href="#" onclick="deleteBusinessType(<%=model.BusinessTypeList[i].Id %>);">
                                  ɾ��</a>
                            </td>
                          </tr>
                          <%  
                            }
                          %>
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">
                        &nbsp;</td>
                      <td>
                        <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img alt="" src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%">
            <img alt="" src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10">
            <img alt="" src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
