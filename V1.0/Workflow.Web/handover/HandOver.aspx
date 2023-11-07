<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandOver.aspx.cs" Inherits="handover_HandOver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>交班</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" language="javascript" src="../js/handover/handOver.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%;background-color:#ffffff"  id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
          <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
          <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td></td>
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 交班管理 -&gt; 交班</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">交班</td>
                    </tr>
                    <tr id="tr1">
                      <td width="3%">&nbsp;</td>
                      <td align="left" id="td2">
                       <table id="tb1" width="100%" border="1" cellpadding="3" cellspacing="1">
                         <tr>
                             <td rowspan="2" class="item_caption">交班类型</td>
                             <td class="tdd"><a href="#" onclick="stageHandOver(this);">前台交班</a></td>
                         </tr>
                             <tr><td><a href="#" onclick="cashHandOver(this);">收银交班</a></td></tr>
                         </table>     
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td></td>
                      <td align="center"></td>
                      <td></td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                      </td>
                    </tr>
                    <tr height="5">
                      <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                      <td bgcolor="#eeeeee">&nbsp;</td>
                      <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
          <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
          <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
