<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OldCopyCounter.aspx.cs" Inherits="CopyCounter" %>

<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>机器抄表</title>
  <link href="/Workflow.Web/css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" src="../js/logCounters.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" language="javascript">

  </script>
  
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img alt="" src="../images/white_main_top_left.gif"></td>
          <td width="99%">
            <img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
          <td width="10">
            <img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
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
                        首页 -&gt; 抄表处理 -&gt; 机器抄表</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        机器抄表</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;
                        </td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap="nowrap">
                              机器类型</th>
                            <th width="1%" nowrap="nowrap">
                              机器名称</th>
                            <th width="1%" colspan="12" nowrap="nowrap">
                              抄表详情(计数器/上期读数/本期读数)</th>
                          </tr>
                          <% bool blnNewRow = true;
                             int intEmptyColCount = 0;//空白列数
                             int intMachineWatchRowCount = 0;//每个机器表占用的行数
                             for (int i = 0; i < model.MachineTypeList.Count; i++)
                             {
                               blnNewRow = true;
                               for (int j = 0; j < model.MachineTypeList[i].MachineList.Count; j++)
                               {
                                 if ((model.MachineTypeList[i].MachineWatchList.Count % 4) == 0)
                                 {
                                   intMachineWatchRowCount = (model.MachineTypeList[i].MachineWatchList.Count / 4);
                                 }
                                 else
                                 {
                                   intMachineWatchRowCount = (model.MachineTypeList[i].MachineWatchList.Count / 4) + 1;
                                 }
                          %>
                          <tr>
                            <%
                              if (blnNewRow)
                              {
                            %>
                            <%if (intMachineWatchRowCount != 0)
                              { %>
                            <td align="center" rowspan="<%=(model.MachineTypeList[i].MachineList.Count * intMachineWatchRowCount)%>" nowrap="nowrap">
                              <%=model.MachineTypeList[i].Name%>
                            </td>
                            <%}
                              else
                              { %>
                            <td align="center" rowspan="<%=(model.MachineTypeList[i].MachineList.Count)%>" nowrap="nowrap">
                              <%=model.MachineTypeList[i].Name%>
                            </td>
                            <%
                              } %>
                            <%}
                              blnNewRow = false;
                            %>
                            <%if (intMachineWatchRowCount != 0)
                              { %>
                            <td align="center" rowspan="<%=intMachineWatchRowCount%>" nowrap="nowrap">
                              <%=model.MachineTypeList[i].MachineList[j].Name%>
                              <input name="txtMachineId" value="<%=model.MachineTypeList[i].MachineList[j].Id%>" type="hidden" />
                            </td>
                            <%}
                              else
                              { %>
                            <td align="center" rowspan="1" nowrap="nowrap">
                              <%=model.MachineTypeList[i].MachineList[j].Name%>
                              <input name="txtMachineId" value="<%=model.MachineTypeList[i].MachineList[j].Id%>" type="hidden" />
                              
                            </td>
                            <%
                              }
                            %>
                            <%--固定四项开始--%>
                            <%
                              //得到最新读数
                              GetLastNumber(model.MachineTypeList[i].MachineList[j].Id);
                              intEmptyColCount = (model.MachineTypeList[i].MachineWatchList.Count % 4);
                              for (int k = 0; k < model.MachineTypeList[i].MachineWatchList.Count; k++)
                              {
                            %>
                            <%if (((k % 4) == 0) && (k != 0))
                              //追加新行
                              {  %>
                            <tr>
                              <%} %>
                              <td align="center" nowrap="nowrap">
                                <%=model.MachineTypeList[i].MachineWatchList[k].Name%>
                                <input name="txtMachineWatchId<%=model.MachineTypeList[i].MachineList[j].Id%>" value="<%=model.MachineTypeList[i].MachineWatchList[k].Id%>" type="hidden" />
                              </td>
                              <td align="center" nowrap="nowrap">
                              
                               <%=model.MachineWatchScaleList[k].LastestNumber%>
                              </td>
                              <td align="center" nowrap="nowrap">
                                      <input type="hidden" id="txtOldNumber" name="txtOldNumber<%=model.MachineTypeList[i].MachineList[j].Id%>" value="<%=model.MachineWatchScaleList[k].LastestNumber%>"/>
                                &nbsp;<input type="text" id="txtNewNumber" name="txtNewNumber<%=model.MachineTypeList[i].MachineList[j].Id%>" class="num" size="5" maxlength="8" value="<%=model.MachineWatchScaleList[k].LastestNumber%>" />
                              </td>
                              <%
                                }  
                              %>
                              <%--固定四项结束--%>
                              <%//开始补空行
                                if (intEmptyColCount != 0)
                                {
                              %>
                              <%
                                //现在开始补空行
                                for (int k = 0; k < 4 - intEmptyColCount; k++)
                                {
                              %>
                              <td align="center" nowrap="nowrap">&nbsp;
                                
                              </td>
                              <td align="center" nowrap="nowrap">&nbsp;
                                
                              </td>
                              <td align="center" nowrap="nowrap">&nbsp;
                                
                              </td>
                              <%
                                }
                              } 
                              %>
                            </tr>
                          <%
                            }
                          %>
                          <%  
                            }%>
                        </table>
                      </td>
                      <td width="3%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;
                      </td>
                      <td align="left">
                        <input name="btnAddPaper" type="button" onclick="addRow();"
                          value="新增用纸数量" />
                        </td>
                      <td width="3%">&nbsp;
                      </td>
                    </tr>
                    <tr>
                      <td>&nbsp;
                        </td>
                      <td align="center">
                        <table id="tblMainTable" width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                           <th width="1%" align="center" nowrap="nowrap">
                              No</th>
                            <th width="10%" align="center" nowrap="nowrap">
                              订单</th>
                            <th width="10%" align="center" nowrap="nowrap">
                              机器</th>
                            <th width="10%" align="center" nowrap="nowrap">
                              纸型</th>
                            <th width="10%" align="center" nowrap="nowrap">
                              颜色</th>
                            <th width="10%" align="center" nowrap="nowrap">
                              数量</th>
                            <th width="1%" align="center" nowrap="nowrap">
                              操作</th>
                          </tr>
                          <tr>
                          <td width="1%">1</td>
                            <td align="center" width="1%" nowrap="nowrap">
                            <input id="txtOrder1" name="txtOrder1" type="hidden"/>
                            <select id="sltOrder" name="sltOrder" >
                            <option value="0">请选择</option>
                            
                              <%if (model.OrderList != null)
                                {
                                    foreach (Order varOrder in model.OrderList)
                                    {%>
                               <option value="<%=varOrder.Id%>"><%=varOrder.No%></option>
                               <%
                                  }
                              }%>
                              </select>
                              </td>
                            <td align="center" width="1%" nowrap="nowrap">
                            <input id="txtMachine" name="txtMachine" type="hidden"/>
                            <select id="sltMachine" name="sltMachine" >
                            <option value="0">请选择</option>
                              <%foreach (Machine varMachine in model.MachineList)
                               {%>
                               <option value="<%=varMachine.Id%>"><%=varMachine.Name%></option>
                               <%
                               }
                                %>
                              </select></td>
                            <td align="center" width="1%" nowrap="nowrap">
                            <input id="txtPaperSpecification" name="txtPaperSpecification" type="hidden"/>
                            <select id="sltPaperSpecification" name="sltPaperSpecification" >
                            <option value="0">请选择</option>
                              <%foreach (PaperSpecification varPaperSpecificationList in model.PaperSpecificationList)
                               {%>
                               <option value="<%=varPaperSpecificationList.Id%>"><%=varPaperSpecificationList.Name%></option>
                               <%
                               }
                                %>
                              </select></td>
                            <td align="center" width="1%" nowrap="nowrap">
                            <input id="txtColor" name="txtColor" type="hidden"/>
                            <select id="sltColor" name="sltColor" >
                            <option value="0">请选择</option>
                            <option value="1">黑白</option>
                            <option value="2">彩色</option>
                              </select></td>
                            <td class="num"><input id="txtAmount" name="txtAmount" type="text" size="5" class="num" /></td>
                            <td width="1%" align="center" nowrap="nowrap">
                              <input type="button" onclick="hideControl(this);" name="btnOrderItemOk" value="确定"/>
                              <input type='button' style="display:none" onclick='editItem(this);' value='编辑' />
                              <input type="button" onclick="delRow(this);" value="取消" /></td>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                      <td>&nbsp;
                        </td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td align="right" nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">
                              登记人:</td>
                            <td bgcolor="#FFFFFF" class="item_content">
                              李亚丽</td>
                            <td nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">
                              核对人:</td>
                            <td bgcolor="#FFFFFF" class="item_content">
                              <select name="select2">
                                <option>王朋</option>
                                <option>张芮</option>
                                <option>李建国</option>
                              </select>
                            </td>
                            <td nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">
                              验证密码:</td>
                            <td align="left" bgcolor="#FFFFFF" class="item_content">
                              <input name="textfield4" type="password" class="texts" value="1400" size="10" /></td>
                          </tr>
                        </table>
                      </td>
                      <td>&nbsp;
                        </td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                          <asp:Button ID="btnCheck" CssClass="buttons" OnClientClick="return doCheckProcess();" OnClick="DoCheckAction" runat="server" Text="核对" />
                      </td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                      <td bgcolor="#eeeeee">&nbsp;
                        </td>
                      <td>
                        <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img alt="" src="../images/white_main_bottom_left.gif"></td>
          <td width="99%">
            <img alt="" src="../images/spacer_10_x_10.gif"></td>
          <td width="10">
            <img alt="" src="../images/white_main_bottom_right.gif"></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
