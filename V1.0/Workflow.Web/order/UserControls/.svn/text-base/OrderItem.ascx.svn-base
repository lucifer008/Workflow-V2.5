<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderItem.ascx.cs" Inherits="OrderUserControlsOrderItem" %>
<table id="tbOrderItem" name="tbOrderItem" align="left" border="1" cellpadding="0" cellspacing="0" width="100%">
    <tbody>
        <tr>
            <th nowrap="nowrap" class="w1">
                &nbsp;NO&nbsp;</th>
            <th nowrap="nowrap" class="w1">
                &nbsp;业务类型&nbsp;</th>
            <% for (int i = 0; i < model.PriceFactor.Count; i++)
               {
                   if (model.PriceFactor[i].IsDisplay.ToUpper() != Workflow.Support.Constants.TRUE) continue;
            %>
            <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">
                &nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
            <% } %>
            <th nowrap="nowrap" class="w1">
                &nbsp;数量&nbsp;</th>
            <th nowrap="nowrap" class="w1">
                &nbsp;单价&nbsp;</th>
            <th nowrap="nowrap" class="w1">
                &nbsp;金额&nbsp;</th>
            <th align="left" nowrap="nowrap">
                制作要求</th>
            <th nowrap="nowrap" class="w1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
        </tr>
        <tr name="">
            <td align="center" class="no">1</td>
            <td><select name="BusinessType" id="sltBusinessType" onchange="doProcess(this);" >
                    <option value='-1' selected="selected">请选择</option>
            <% 
                System.Collections.Generic.IList<Workflow.Da.Domain.BusinessType> businessTypeList = model.BusinessType;
                for (int i = 0; i < businessTypeList.Count; i++)
               {
            %>
                    <option value='<%= businessTypeList[i].Id %>'><%=businessTypeList[i].Name %></option>
            <% }%>
                </select></td>
            <% for (int i = 0; i < model.PriceFactor.Count; i++)
               {
            %>
            <td>-</td>
            <%} %>
            <td><input type="text" name="Amount" style="text-align:right" maxlength="9" size="10" onkeydown="return inputKeyCheck(event);"/></td>
            <td name="price">-<a href="#"  name="modifyPrice" onclick="modifyPrice(this,2);"></a><input name="unitPrice" type="text" size="10" style="display:none; text-align:right;"  value="0" maxlength="10"/></td>
            <td name="sumMoney">
                -</td>
            <td>
                <a href="#" onclick="showPrintRequest(this);">选择</a><input id="factorid1" name="txtFactorId1" type="hidden" /><input id="factorvalue1" name="txtFactorValue1" type="hidden" /><input id="printRequest1" name="txtPrintRequest1" type="hidden" /><input type="hidden" name="strPrice" /><input type="hidden" name="txtSumMoney" /><input type="hidden" name="priceFactorId1" id="txtPriceFactorId1" /><input type="hidden" name="printDemandMemo" /></td>
            <td>
                <input type="button" onclick="hideControl(this);" name="btnOrderItemOk" value="确定"/>
                <input type='button' style="display:none" onclick='editOrderItem(this);' value='编辑' />
                <input type="button" onclick="delRow(this);" value="删除" /></td>
        </tr>
    </tbody>
</table>
