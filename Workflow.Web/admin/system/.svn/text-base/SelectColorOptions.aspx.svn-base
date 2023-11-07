<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectColorOptions.aspx.cs" Inherits="admin_system_SelectColorOptions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>颜色选择对话框</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/system/selectColor.js"></script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div align="center" style="width:100%" bgcolor="#ffffff" id="container">
           <center>
            <table style="border: 0;" cellspacing="10" cellpadding="0">
                <tr>
                    <td>
                        <table id="ColorTable" style="border: 0; cursor: pointer;" cellspacing="0" cellpadding="0" onclick="SelectColor.clickColorTable(event)">
                            <script language="JavaScript" type="text/javascript">
                            function wc(r, g, b, n){
                                r = ((r * 16 + r) * 3 * (15 - n) + 0x80 * n) / 15;
                                g = ((g * 16 + g) * 3 * (15 - n) + 0x80 * n) / 15;
                                b = ((b * 16 + b) * 3 * (15 - n) + 0x80 * n) / 15;
                                document.write('<td style="background-color:#' + SelectColor.ToHex(r) + SelectColor.ToHex(g) + SelectColor.ToHex(b) + '; height:8px; width:8px;"></td>');
                            }
                            var cnum = new Array(1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0);
                            for(i = 0; i < 16; i ++){
                                document.write('<tr>');
                                for(j = 0; j < 30; j ++){
                                    n1 = j % 5;
                                    n2 = Math.floor(j / 5) * 3;
                                    n3 = n2 + 3;

                                    wc((cnum[n3] * n1 + cnum[n2] * (5 - n1)),
                                    (cnum[n3 + 1] * n1 + cnum[n2 + 1] * (5 - n1)),
                                    (cnum[n3 + 2] * n1 + cnum[n2 + 2] * (5 - n1)), i);
                                }
                                document.writeln('</tr>');
                            }
                            </script>

                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
