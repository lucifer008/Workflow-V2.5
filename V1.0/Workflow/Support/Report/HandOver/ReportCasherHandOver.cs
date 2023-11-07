using System;
using System.IO;
using Workflow.Util;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Da.Domain;
using iTextSharp.text.pdf;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
namespace Workflow.Support.Report.HandOver
{
    /// <summary>
    /// 名    称: 收银交班 报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009年3月20日18:41:08
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportCasherHandOver : ReportBase<iTextSharp.text.pdf.PdfPTable, CashHandOverModel>
    {
        /// <summary>
        /// 查询字符串条件
        /// </summary>
        private string queryString = "查询条件 ";
        /// <summary>
        /// 获取或者设置查询字符串条件
        /// </summary>
        public string QueryString
        {
            set { queryString = value; }
            get { return queryString; }
        }

        public override void CreateReport(CashHandOverModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            try
            {
                Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
                if (string.IsNullOrEmpty(this.FileName))
                {
                    throw new WorkflowException("报表名称不能为空!");
                }
                PdfWriter.GetInstance(doc, new FileStream(this.FileName, FileMode.Create));
                doc.Open();

                if (!string.IsNullOrEmpty(reportSubject))
                {
                    doc.Add(GetReportSubject(reportSubject));
                    Font font = new Font(1, 10);
                    Paragraph p = new Paragraph("", font);
                    doc.Add(p);
                }
                PdfPTable tHead = this.GetReportHeader(u);
                PdfPTable tOrderItem = this.GetOrderItem(u);
                doc.Add(new PdfPTable(1));
                if (null != tHead)
                {
                    doc.Add(tHead);
                }

                if (null != tOrderItem)
                {
                    doc.Add(tOrderItem);
                }
                doc.Close();
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }

        public override Paragraph GetReportSubject(string subject)
        {
            Font f = new Font(FontBase.BaseFont, 20, Font.BOLD);
            Paragraph p = new Paragraph(subject, f);
            p.Font = f;
            p.Alignment = Element.ALIGN_CENTER;
            return p;
        }

        public override PdfPTable GetReportHeader(CashHandOverModel u)
        {
            PdfPTable ptb = new PdfPTable(5);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.Colspan = 5;
            ptb.AddCell(pc1);

            PdfPCell pc3 = new PdfPCell(new Paragraph("", FontHeader));
            pc3.HorizontalAlignment = 2;
            pc3.Border = 0;
            pc3.Colspan = 5;
            ptb.AddCell(pc3);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 5;
            ptb.AddCell(pc2);
            return ptb;
        }

        private PdfPTable GetOrderItem(CashHandOverModel u)
        {
            PdfPTable ptb = new PdfPTable(5);
            PdfPCell pcHandOverDate = new PdfPCell(new Paragraph("交接日期", FontColumn));
            pcHandOverDate.NoWrap = false;
            pcHandOverDate.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDate);

            PdfPCell pcHandOverDateValue = new PdfPCell(new Paragraph(u.HandOver.InsertDateTime.ToShortDateString(), FontColumnValue));
            pcHandOverDateValue.NoWrap = true;
            pcHandOverDateValue.Colspan = 2;
            pcHandOverDateValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDateValue);

            PdfPCell pcHandOverDateTime = new PdfPCell(new Paragraph("时间:", FontColumn));
            pcHandOverDateTime.NoWrap = true;
            pcHandOverDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDateTime);

            PdfPCell pcHandOverDateTimeValue = new PdfPCell(new Paragraph(u.HandOver.HandOverDateTime.ToString("HH:mm"), FontColumnValue));
            pcHandOverDateTimeValue.NoWrap = true;
            pcHandOverDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDateTimeValue);


            PdfPCell pcHandOverPeople = new PdfPCell(new Paragraph("交班人签字", FontColumn));
            pcHandOverPeople.NoWrap = false;
            pcHandOverPeople.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverPeople);

            PdfPCell pcHandOverPeopleValue = new PdfPCell(new Paragraph(u.HandOver.Employee.Name, FontColumnValue));
            pcHandOverPeopleValue.NoWrap = false;
            pcHandOverPeopleValue.Colspan = 2;
            pcHandOverPeopleValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverPeopleValue);


            PdfPCell pcOtherPeople = new PdfPCell(new Paragraph("接班人签字", FontColumn));
            pcOtherPeople.NoWrap = false;
            pcOtherPeople.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOtherPeople);

            PdfPCell pcOtherPeopleValue = new PdfPCell(new Paragraph(u.HandOver.OtherEmployee.Name, FontColumnValue));
            pcOtherPeopleValue.NoWrap = false;
            pcOtherPeopleValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOtherPeopleValue);

            PdfPCell pcMoneyNo = new PdfPCell(new Paragraph("No", FontColumn));
            pcMoneyNo.NoWrap = false;
            pcMoneyNo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMoneyNo);

            PdfPCell pcMoneyDetail = new PdfPCell(new Paragraph("款项详情", FontColumn));
            pcMoneyDetail.NoWrap = false;
            pcMoneyDetail.Colspan = 4;
            pcMoneyDetail.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMoneyDetail);

            PdfPCell pcMoney = new PdfPCell(new Paragraph("1", FontColumnValue));
            pcMoney.NoWrap = false;
            pcMoney.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMoney);

            PdfPCell pcTicket = new PdfPCell(new Paragraph("发票金额", FontColumn));
            pcTicket.NoWrap = false;
            pcTicket.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTicket);

            PdfPCell pcTicketValue = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.CashHandOver.TicketAmountSum), FontColumnValue));
            pcTicketValue.NoWrap = false;
            pcTicketValue.Colspan = 3;
            pcTicketValue.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcTicketValue);

            PdfPTable ptb21 = new PdfPTable(1);
            PdfPCell pcMoney1 = new PdfPCell(new Paragraph("2", FontColumnValue));
            pcMoney1.NoWrap = false;
            pcMoney1.Border = 0;
            pcMoney1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb21.AddCell(pcMoney1);
            ptb.AddCell(ptb21);

            //预付款
            PdfPTable ptb22=new PdfPTable(1);
            PdfPCell pcPre = new PdfPCell(new Paragraph("预付款", FontColumn));
            pcPre.HorizontalAlignment = Element.ALIGN_CENTER;
            pcPre.Border = 0;
            ptb22.AddCell(pcPre);
            ptb.AddCell(ptb22);

            //工单号列
            PdfPTable ptb23 = new PdfPTable(1);
            PdfPCell pcOrderNo = new PdfPCell(new Paragraph("工单号", FontColumn));
            pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOrderNo.Border = 0;
            ptb23.AddCell(pcOrderNo);
            foreach (Order order in u.OrderList)
            {
                PdfPCell pcOrderNoValue1 = new PdfPCell(new Paragraph(order.No, FontColumnValue));
                pcOrderNoValue1.HorizontalAlignment = Element.ALIGN_CENTER;
                pcOrderNoValue1.Border = 0;
                pcOrderNoValue1.NoWrap = false;
                ptb23.AddCell(pcOrderNoValue1);
            }
            ptb.AddCell(ptb23);

            //预付款列
            decimal preTotal = 0;
            PdfPTable ptb24 = new PdfPTable(1);
            PdfPCell pcPreCl = new PdfPCell(new Paragraph("预付款", FontColumn));
            pcPreCl.HorizontalAlignment = Element.ALIGN_CENTER;
            pcPreCl.NoWrap = false;
            pcPreCl.Border = 0;
            ptb24.AddCell(pcPreCl);
            foreach (Order order in u.OrderList)
            {
                PdfPCell pcPreValue = new PdfPCell(new Paragraph(NumericUtils.ToMoney(order.PrepareMoneyAmount), FontColumnValue));
                pcPreValue.HorizontalAlignment = Element.ALIGN_CENTER;
                pcPreValue.NoWrap = false;
                pcPreValue.Border = 0;
                ptb24.AddCell(pcPreValue);
                preTotal += order.PrepareMoneyAmount;
            }
            ptb.AddCell(ptb24);

            //备注列
            PdfPTable ptb25 = new PdfPTable(1);
            PdfPCell pcSm = new PdfPCell(new Paragraph("备注", FontColumn));
            pcSm.HorizontalAlignment = Element.ALIGN_CENTER;
            pcSm.NoWrap = false;
            pcSm.Border = 0;
            ptb25.AddCell(pcSm);
            foreach (Order order in u.OrderList)
            {
                PdfPCell pcSm1 = new PdfPCell(new Paragraph(order.Memo, FontColumnValue));
                pcSm1.HorizontalAlignment = Element.ALIGN_CENTER;
                pcSm1.NoWrap = false;
                pcSm1.Border = 0;
                ptb25.AddCell(pcSm1);
            }
            ptb.AddCell(ptb25);

            int index = 2;
            index++;

            //结款
            PdfPCell pcPre2 = new PdfPCell(new Paragraph(index.ToString(), FontColumnValue));
            pcPre2.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcPre2);

            PdfPCell pcPayMoneyC = new PdfPCell(new Paragraph("结款", FontColumn));
            pcPayMoneyC.HorizontalAlignment = Element.ALIGN_CENTER;
            pcPayMoneyC.NoWrap = false;
            ptb.AddCell(pcPayMoneyC);

            PdfPCell pcPayMoneyCount = new PdfPCell(new Paragraph("结款共" + u.CashHandOver.PayForCount + "单", FontColumnValue));
            pcPayMoneyCount.HorizontalAlignment = Element.ALIGN_CENTER;
            pcPayMoneyCount.NoWrap = false;
            ptb.AddCell(pcPayMoneyCount);



            PdfPCell pcPayMoney = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.CashHandOver.PayForAmountSum), FontColumnValue));
            pcPayMoney.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcPayMoney.NoWrap = false;
            pcPayMoney.Colspan = 2;
            ptb.AddCell(pcPayMoney);

            ////现金合计

            //PdfPCell pcPre3 = new PdfPCell(new Paragraph(Convert.ToString((index+1)), FontBase));
            //pcPre3.HorizontalAlignment = Element.ALIGN_CENTER;
            //ptb.AddCell(pcPre3);

            //PdfPCell pcCashC = new PdfPCell(new Paragraph("现金合计", FontBase));
            //pcCashC.HorizontalAlignment = Element.ALIGN_CENTER;
            //pcCashC.NoWrap = false;
            //ptb.AddCell(pcCashC);

            //PdfPCell pcCashMemo = new PdfPCell(new Paragraph("预付订金+结款", FontBase));
            //pcCashMemo.HorizontalAlignment = Element.ALIGN_CENTER;
            //pcCashMemo.NoWrap = false;
            //pcCashMemo.Colspan = 2;
            //ptb.AddCell(pcCashMemo);

            //PdfPCell pcCashTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.CashHandOver.PayForAmountSum + u.CashHandOver.CashAmount), FontBase));
            //pcCashTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            //pcCashTotal.NoWrap = false;
            //ptb.AddCell(pcCashTotal);

            //记账合计
            PdfPCell pcPre33 = new PdfPCell(new Paragraph(Convert.ToString(index + 1), FontColumnValue));
            pcPre33.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcPre33);

            PdfPCell pcOweC = new PdfPCell(new Paragraph("记账", FontColumn));
            pcOweC.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOweC.NoWrap = false;
            ptb.AddCell(pcOweC);

            PdfPCell pcOweMoeny = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.CashHandOver.KeepBusinessRecordAmountSum), FontColumnValue));
            pcOweMoeny.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcOweMoeny.NoWrap = false;
            pcOweMoeny.Colspan = 3;
            ptb.AddCell(pcOweMoeny);

            //欠条合计
            PdfPCell pcPre4 = new PdfPCell(new Paragraph(Convert.ToString(index + 2), FontColumnValue));
            pcPre4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcPre4);

            PdfPCell pc = new PdfPCell(new Paragraph("欠条", FontColumn));
            pc.HorizontalAlignment = Element.ALIGN_CENTER;
            pc.NoWrap = false;
            ptb.AddCell(pc);

            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontColumnValue));  //u.CashHandOver.DebtCount + "张", FontBase));
            pc1.HorizontalAlignment = Element.ALIGN_CENTER;
            pc1.NoWrap = false;
            ptb.AddCell(pc1);

            PdfPCell pcDebtMoney = new PdfPCell(new Paragraph("", FontColumnValue));//"欠条合计" + NumericUtils.ToMoney(u.CashHandOver.DebtAmountSum), FontBase));
            pcDebtMoney.HorizontalAlignment = Element.ALIGN_CENTER;
            pcDebtMoney.NoWrap = false;
            pcDebtMoney.Colspan = 2;
            ptb.AddCell(pcDebtMoney);

            //备用金
            PdfPCell pcPre5 = new PdfPCell(new Paragraph(Convert.ToString(index + 3), FontColumnValue));
            pcPre5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcPre5);

            PdfPCell pcStandbyAmountC = new PdfPCell(new Paragraph("备用金", FontColumn));
            pcStandbyAmountC.HorizontalAlignment = Element.ALIGN_CENTER;
            pcStandbyAmountC.NoWrap = false;
            ptb.AddCell(pcStandbyAmountC);

            PdfPCell pcStandbyAmount = new PdfPCell(new Paragraph("", FontColumnValue));//NumericUtils.ToMoney(u.CashHandOver.StandbyAmount), FontBase));
            pcStandbyAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            pcStandbyAmount.NoWrap = false;
            pcStandbyAmount.Colspan = 3;
            ptb.AddCell(pcStandbyAmount);

            //其他
            PdfPCell pcOtherC = new PdfPCell(new Paragraph("其他", FontColumn));
            pcOtherC.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOtherC.NoWrap = false;
            ptb.AddCell(pcOtherC);

            PdfPCell pcOtherValue = new PdfPCell(new Paragraph("", FontColumnValue));
            pcOtherValue.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOtherValue.NoWrap = false;
            pcOtherValue.Colspan = 4;
            ptb.AddCell(pcOtherValue);

            //本次合计
            PdfPCell pcOtherNowCo = new PdfPCell(new Paragraph("本次交班合计", FontColumn));
            pcOtherNowCo.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOtherNowCo.NoWrap = false;
            ptb.AddCell(pcOtherNowCo);


            string str = "发票金额:" + NumericUtils.ToMoney(u.CashHandOver.TicketAmountSum);
            str += " 预收款:"+NumericUtils.ToMoney(preTotal);
            str += " 记账:" + NumericUtils.ToMoney(u.CashHandOver.KeepBusinessRecordAmountSum);
            str += " 结款:" + NumericUtils.ToMoney(u.CashHandOver.PayForAmountSum);
            str += " 欠条:";
            str += " 备用金:";
            PdfPCell pcOtherNow = new PdfPCell(new Paragraph(str, FontColumnValue));
            pcOtherNow.HorizontalAlignment = Element.ALIGN_CENTER;
            pcOtherNow.NoWrap = false;
            pcOtherNow.Colspan = 4;
            ptb.AddCell(pcOtherNow);

            
            return ptb;
        }

        /// <summary>
        /// 获取列标题字体
        /// </summary>
        public virtual Font FontColumn
        {
            get
            {
                Font ft = new Font(FontBase.BaseFont, 12, Font.COURIER);
                return ft;
            }
        }

        /// <summary>
        /// 获取列 内容字体
        /// </summary>
        public virtual Font FontColumnValue
        {
            get
            {
                Font ft = new Font(FontBase.BaseFont, 10, Font.COURIER);
                return ft;
            }
        }

        public virtual Font FontHeader
        {
            get
            {
                Font ft = new Font(FontBase.BaseFont, 15, Font.COURIER);
                return ft;
            }
        }
        public override PdfPTable GetReportFooter(CashHandOverModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(CashHandOverModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(CashHandOverModel u)
        {
            return null;
        }
    }
}
