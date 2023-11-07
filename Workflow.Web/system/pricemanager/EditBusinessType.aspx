<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditBusinessType.aspx.cs" Inherits="EditBusinessType" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>编辑业务类型</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/jQuery.js"></script>
<script type="text/javascript" src="../../js/system/priceManager/mangePrice.js" ></script>
<script type="text/javascript" src="../../js/system/priceManager/editBusinessType.js" ></script>
<script type="text/javascript" src="../../js/escExit.js"></script>
<script type="text/javascript">
<%if (closeSelf) {%>
  $().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
      opener.$("#MainForm").submit();
      window.close();
      return;
      }
  });
<%} %>


</script>
</head>
<body>
<form id="MainForm" runat="server" method="post">
<%if (closeSelf) { return; } %>
  <input id="txtAction" name="txtAction" type="hidden" value="1" />
  <div align="center" style="width:99%" bgcolor="#ffffff" id="container">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
      <tr>
        <td width="11"><img alt="" src="../../images/white_main_top_left.gif" /></td>
        <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
        <td width="10"><img alt="" src="../../images/white_main_top_right.gif"width="12" height="11" /></td>
      </tr>
      <tr>
        <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0">
                <tr>
                  <td></td>
                  <td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 编辑业务类型</td>
                  <td></td>
                </tr>
                <tr>
                  <td colspan="3" class="caption" align="center">编辑业务类型</td>
                </tr>
                <tr>
                <td width="3%">&nbsp;</td>
                <td align="center">

                    <table id="tbBusinessType" width="100%" border="1" align="left" cellpadding="3" cellspacing="1" bgcolor="#FFFFFF">
                    <tr>
                      <td width="1%" align="left" nowrap="nowrap" class="item_caption">业务类型:</td>
                      <td colspan="2" align="left"><span class="item_content">
                        <input id="txtBusinessName" name="txtBusinessName" type="text" class="texts" value="<%=priceAction.Model.BusinessType.Name%>"/>
                        <input id="txtBusinessId" name="txtBusinessId" type="hidden" class="texts" value="<%=priceAction.Model.BusinessType.Id%>"/>
                        </span></td>
                    </tr>
                    <tr>
                      <th nowrap >因素</th>
                      <th colspan="2" nowrap>备注</th>
                    </tr>
                    <%  
                        string strCheck = "";    
                        for (int i=0;i<priceAction.Model.PriceFactor.Count;i++)
                        {
                    %>
                    <tr>
                    <td align="left" nowrap>
                    <%
                        strCheck = "";
                        if (priceAction.Model.PriceFactor[i].PriceFactorId != 0)
                        {
                            strCheck = "checked";
                        }   
                     %>
                    <input name="chkFactor" id="chkFactor<%=i%>" type="checkbox" value="<%=priceAction.Model.PriceFactor[i].Id%>" <%=strCheck%>/>
                    <label for="chkFactor<%=i%>">    <%=priceAction.Model.PriceFactor[i].Name%></label> </td>
                      <td colspan="2" align="left"><%=priceAction.Model.PriceFactor[i].DisplayText%></td>
                    </tr>
                    <%
                        }
                    %>
                    </table>
              </td>
              <td width="3%">&nbsp;</td>
            </tr>
            <tr class="emptyButtonsUpperRowHight">
              <td colspan="3"></td>
            </tr>
            <tr>
              <td colspan="3" align="center" class="bottombuttons" style="height: 26px">
                  <input id="btnEditBusinessType" class="buttons" name="btnEditBusinessType" type="button" value="保存" onclick="savePriceSet();"/>
                &nbsp;<input id="btnCancel" name="btnCancel" class="buttons" type="button" value="关闭" onclick="window.close();"/>
                </td>
            </tr>
            <tr height="5">
              <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
              <td bgcolor="#eeeeee">&nbsp;</td>
              <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
            </tr>
          </table></td>
      </tr>
    </table>
    </td>
    </tr>
    <tr>
      <td width="11"><img alt="" src="../../images/white_main_bottom_left.gif" /></td>
      <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"/></td>
      <td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"/></td>
    </tr>
    </table>
  </div>
</form>
</body>
</html>
