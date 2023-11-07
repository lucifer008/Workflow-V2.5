<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPreferentialProject.aspx.cs" Inherits="AddPreferentialProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�Żݷ������</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/activities/addPreferentialProject.js"></script>
<script type="text/javascript" language="javascript">
    
    <% if(ReturnParent && hiddTag.Value == "1"){ %>
        showPage("AddCampaign.aspx?Id="+<%=hiddCampaign.Value %>,"_self");
    <% } if(ReturnParent && hiddTag.Value == "2") { %>
        showPage("ModifyCampaign.aspx?Id="+<%=hiddCampaign.Value %>,"_self");
    <%} %>
</script>
</head>
<body style="text-align:center">
<div align="center" style="width:99%; background-color:#ffffff" id="container">
<form id="form1" runat="server">
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
      <td bgcolor="#FFFFFF"><table width="100%" border="1" cellspacing="0" >
          <tr>
            <td width="3%"></td>
            <td align="left" bgcolor="#eeeeee">��ҳ -&gt; ����� -&gt; �Żݷ������</td>
            <td width="3%"></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">�Żݷ������</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><table width="100%" border="0" cellspacing="1" cellpadding="2">
                <tr>
                  <td width="1%" nowrap="nowrap" class="item_caption">����:</td>
                  <td width="94%"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <td nowrap="nowrap" class="item_caption">˵��:</td>
                  <td><asp:TextBox ID="txtDescription" runat="server" Columns="94" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
              </table></td>
            <td>&nbsp;</td>
          </tr>   
          <tr>
            <td>&nbsp;</td>
            <td align="left">ѡ��ɲ�����Żݷ����Ļ�Ա�������ͼ�����:
                <input type="hidden" id="hiddbaseBusinessTypePriceId" name="hiddbaseBusinessTypePriceId" value="" runat="server" />
                <input type="hidden" id="hiddCount" name="hiddCount" />
                <input type="hidden" name="hiddBaseBusinessTypePriceSerIds" id="hiddBaseBusinessTypePriceSerIds" />
                <input type="hidden" id="hiddUnitPrice" name ="hiddUnitPrice" />                
                <asp:HiddenField ID="hiddCampaign" runat="server" />
                <asp:HiddenField ID="hiddTag" runat="server" />
            </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td width="14%" class="item_caption"><label for="checkbox2">��ӡ��:</label></td>
                  <td colspan="3"><asp:CheckBoxList ID="MemberCardLevel" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList></td>
                </tr>
              </table></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left">ѡ������۸�ָ����ֵ���������ӡ����:</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><input name="Submit" type="button" class="buttons" onclick="SelectedPrice()" value="ѡ��۸�" /></td>
            <td>&nbsp;</td>
          </tr>
           <%
              if (BusinessTypePrice)
              {
                  if (model.BaseBusinessTypePriceSet != null)
                  {
                   %>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td class="item_caption">ҵ������:</td>
                  <td colspan="3" class="item_content"><%= model.BaseBusinessTypePriceSet.BusinessType.Name %>
                  </td>
                </tr>
                <%
                    if (model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count % 2 == 0)
                    {
                        for (int i = 1; i <= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count; i = i + 2)
                        {
                       %>
                <tr>
                  <td class="item_caption"><%= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList[i - 1].Name%></td>
                  <td class="item_content"><%= model.BaseBusinessTypePriceSet.Texts[i - 1]%></td>
                  <td class="item_caption"><%= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList[i].Name%></td>
                  <td class="item_content"><%= model.BaseBusinessTypePriceSet.Texts[i]%></td>
                </tr>
                <%}%>
                <tr>           
                  <td class="item_caption">���м۸�:</td>
                  <td class="item_content" colspan="3"  id="StandardPrice"><%= model.BaseBusinessTypePriceSet.StandardPrice%></td>
                </tr>
              <%} else{

                  for (int i = 1; i <= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count - 1; i = i + 2)
                  {
                        %>
                        <tr>
                  <td class="item_caption"><%= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList[i - 1].Name%></td>
                  <td class="item_content"><%= model.BaseBusinessTypePriceSet.Texts[i - 1]%></td>
                  <td class="item_caption"><%= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList[i].Name%></td>
                  <td class="item_content"><%= model.BaseBusinessTypePriceSet.Texts[i]%></td>
                </tr>
                <%} %>
                <tr>
                  <td class="item_caption"><%= model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList[model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count-1].Name%></td>
                  <td class="item_content"><%= model.BaseBusinessTypePriceSet.Texts[model.BaseBusinessTypePriceSet.BusinessType.PriceFactorList.Count-1]%></td>
                  <td class="item_caption">���м۸�:</td>
                  <td class="item_content" id="StandardPrice"><%= model.BaseBusinessTypePriceSet.StandardPrice%></td>
                </tr>
              <%} %>
                <tr class="emptyButtonsUpperRowHight">
                  <td colspan="4" style="height: 10px"></td>
                </tr>
                <tr>
                  <td width="14%" class="item_caption">��ֵ���:</td>
                  <td width="35%" class="item_content"><input name="txtChargeAmount" id="txtChargeAmount" type="text" class="num" size="10" onchange="chargeAmount()";/></td>
                  <td width="11%" class="item_caption">ӡ �� ��:</td>
                  <td width="40%" class="item_content" id="Amount"></td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">����ӡ����:</td>
                  <td class="item_content"><input name="txtPaperCount" id="txtPaperCount" type="text" class="num" size="10" onchange="paperCount()" /></td>
                  <td class="item_caption">�Żݼ۸�:</td>
                  <td class="item_content" id="tdPrice"></td>
                </tr>
              </table></td>
            <td>&nbsp;</td>
          </tr>         
          <tr>
            <td>&nbsp;</td>
            <td align="left">ָ���ڷǱ�׼����´�ӡʱ�Ĳ��:</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left">
            <% GetBaseBusinessTypePrice(model.BaseBusinessTypePriceSet.BusinessType.Id); %>
               <table width="100%" border="1" cellpadding="3" cellspacing="1" id="BaseTable">
                          <tr>                            
                            <th width="1%" nowrap="nowrap" align="center">ҵ������</th>
                            <%for (int i = 0; i < model.PriceFactor.Count; i++)
                              {
                            %>
                            <th width="1%" nowrap="nowrap" align="center"><%=model.PriceFactor[i].DisplayText%></th>
                            <%  
                              } 
                            %>
                            <th width="1%" nowrap="nowrap" align="center">��׼�۸�</th>
                            <th width="1%" nowrap="nowrap" align="center">���</th>
                            <th nowrap="nowrap" width="1%" align="center"></th>
                          </tr>
                          <% 
                              for (int i = 0; i < model.BaseBusinessTypePriceSetList.Count; i++)
                              {

                                  if (model.BaseBusinessTypePriceSetList[i].Id != Workflow.Util.NumericUtils.ToLong(hiddbaseBusinessTypePriceId.Value))
                                  {
                                      //BaseBusinessTypePriceSetId.Value = BaseBusinessTypePriceSetId.Value + "," + Convert.ToString(model.BaseBusinessTypePriceSetList[i].Id);
                          %>
                          <tr class="<%= model.BaseBusinessTypePriceSetList[i].Id%>">
                            
                            <td align="left"><%=model.BaseBusinessTypePriceSetList[i].BusinessType.Name%></td>
                            <%for (int j = 0; j < model.PriceFactor.Count; j++)
                              {
                            %>
                            <td align="center" nowrap="nowrap"><%=model.BaseBusinessTypePriceSetList[i].Texts[j]%></td>
                            <%
                              } 
                            %>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].StandardPrice%></td>
                            <td align="right"><input type="text" id='<%= model.BaseBusinessTypePriceSetList[i].Id %>' name='<%=model.BaseBusinessTypePriceSetList[i].Id %>' size="10" /></td> 
                            <td><a href="#" onclick='deleted(<%= model.BaseBusinessTypePriceSetList[i].Id %>)'> ɾ��</a></td>                       
                          </tr>
                          <%
                              }
                          }
                          %>
                        </table></td>
            <td>&nbsp;</td>
          </tr>
          <%}
        }%>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>
          <tr>
            <td colspan="3" align="center" class="bottombuttons">
                <asp:Button ID="InsertConcession" Cssclass="buttons" runat="server" Text="����" OnClick="InsertConcessionInfo" OnClientClick="return insertBasePrice('<%=BusinessTypePrice %>');"/>
                &nbsp;
              <input name="Submit3342" class="buttons"	value="����" onclick="Return()" type="button">
              </td>
          </tr>
          <tr height="5">
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
          </tr>
        </table></td>
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
  </form>
</div>
</body>
</html>
