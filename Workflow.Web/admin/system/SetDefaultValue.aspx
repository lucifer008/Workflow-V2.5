<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDefaultValue.aspx.cs"
    Inherits="admin_system_SetDefaultValue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置开单默认值</title>
    <link type="text/css" rel="Stylesheet" href="../css/css.css" />

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script type="text/javascript" src="../js/default.js"></script>

    <script type="text/javascript" src="../js/check.js"></script>

    <script type="text/javascript" src="../js/system/SetDefaultValue.js"></script>
    
    <script type="text/javascript" src="../js/json.js"></script>

</head>
<body>
    <form id="form1" runat="server" method="post">
        <input type="hidden" id="hiddTag" name="actionTag" />
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_top_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                 <td width="11"></td>
                    <td width="99%" bgcolor="#FFFFFF">
 
                                    <table width="100%" border="0" cellspacing="0">
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left" bgcolor="#eeeeee">
                                                首页 -&gt;系统基础数据维护-&gt;开单默认值维护</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">
                                                开单默认值维护</td>
                                        </tr>
                                        <tr>
                                            <td width="3%">
                                                &nbsp;</td>
                                            <td align="center">
                                                <table id="tbOrderItem" name="tbOrderItem" align="left" border="1" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                   
                                                        <tr>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;NO&nbsp;</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;业务类型&nbsp;</th>
                                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
                                                            %>
                                                            <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">
                                                                &nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                                                            <% } %>
                                                            <th nowrap="nowrap" class="w1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                            
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                        
                                                            <td nowrap="nowrap" class="w1">
                                                            1</td>  
                                                         
                                                          <td nowrap="nowrap" class="w1">
                                                           
                                                             
                                                            <%--构建Select对象--%>   
                                                            <select name="BusinessType" id="sltBusinessType" onchange="doProcess(this);" style="">
                                                                <option value="-1" selected="selected">请选择</option>
                                                               <%for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                                          {%>
                                                                <option value="<%=model.BusinessTypeList[i].Id %>" ><%=model.BusinessTypeList[i].Name %></option>
                                                                <%} %>
                                                            </select>
                                                            
                                                          </td>
                                                            
                                                             <% for (int j = 0; j < model.PriceFactor.Count; j++)
                                                               {
                                                            %>
                                                            <td nowrap="nowrap" class="w1" index="<%=j+2 %>" id="th<%=model.PriceFactor[j].Id %>">
                                                                &nbsp;&nbsp;</td>
                                                            <% } %>
                                                            
                                                          <td>&nbsp;
                                                                <a id="aBtn" href="#" onclick="addInfo(this)">添加</a>
                                                          </td>
                                                        </tr>
                                                        
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                        <tr>
                                            <td colspan="3"></td>
                                        </tr>
                                         <td width="3%">
                                                &nbsp;</td>
                                            <td >
                                                <table id="tableInfo" align="left" border="1" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;NO&nbsp;</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;业务类型&nbsp;</th>
                                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
                                                            %>
                                                            <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="thInfo<%=model.PriceFactor[i].Id %>">
                                                                &nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                                                            <% } %>
                                                            <th nowrap="nowrap" class="w1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                            
                                                        </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                            <input type="button" onclick="submitForm()" value="保存" style="display:none;" visible="false" />
                                                    
                                                <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick="window.close();"
                                                    value="关闭" visible="false" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server">
                                            <td width="3%">
                                                &nbsp;</td>
                                            <td width="94%" align="center">
                                            </td>
                                            <td width="3%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr height="5">
                                            <td>
                                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                            <td bgcolor="#eeeeee">
                                                &nbsp;</td>
                                            <td>
                                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                        </tr>
                                    </table>
                    </td>
                 <td width="10"></td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_bottom_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif" /></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_bottom_right.gif" /></td>
                </tr>
            </table>
            
            <script type="text/javascript">
                var selectList = document.getElementsByName('BusinessType');
                //alert(selectList.length);
                if (selectList && selectList.length){
                    for(var i = 0; i < selectList.length; i++){
                        doProcess(selectList[0]);
                    }
                }
            </script>
            
            <input type="hidden" id="hidId" runat="server" />
            <input type="hidden" id="hidMemo" runat="server" />
            <input type="hidden" id="hidMemoName" runat="server" />
        </div>
    </form>
</body>
</html>
