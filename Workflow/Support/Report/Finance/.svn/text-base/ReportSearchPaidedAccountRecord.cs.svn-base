using System;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
using Workflow.Action.Finance.Model;
namespace Workflow.Support.Report.Finance
{
    /// <summary>
    /// 功能概要: 应收款付款记录报表
    /// 作    者: 张晓林
    /// 创建时间: 2009年12月22日10:53:05
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class ReportSearchPaidedAccountRecord : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
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
        private bool tag = false;
        public bool Tag
        {
            set { tag = value; }
            get { return tag; }
        }

        public override void CreateReport(FindFinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            try
            {
                Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
                if (String.IsNullOrEmpty(this.FileName))
                {
                    throw new WorkflowException("报表名称不能为空!");
                }
                PdfWriter.GetInstance(doc, new FileStream(this.FileName, FileMode.Create));
                doc.Open();

                if (!String.IsNullOrEmpty(reportSubject))
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
        public override PdfPTable GetReportHeader(FindFinanceModel u)
        {
            float[] ColumnWidth ={ 10, 25, 25, 25, 25, 25, 25 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.FixedHeight = 30;
            pcBlank1.Colspan = 7;
            pcBlank1.NoWrap = false;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.NoWrap = false;
            pc1.Colspan = 4;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 3;
            ptb.AddCell(pc2);

            PdfPCell pcBlank2 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank2.HorizontalAlignment = 2;
            pcBlank2.Border = 0;
            pcBlank2.Colspan = 7;
            pcBlank2.NoWrap = false;
            ptb.AddCell(pcBlank2);
            return ptb;
        }
        private PdfPTable GetOrderItem(FindFinanceModel u)
        {

            ///定义列标题
            ///
            float[] ColumnWidth ={ 10, 25, 25, 25, 25, 25, 25 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("客户名称", FontColumn));
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("收款日期", FontColumn));
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pHProjectName = new PdfPCell(new Paragraph("收款金额", FontColumn));
            pHProjectName.NoWrap = true;
            pHProjectName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHProjectName);

            PdfPCell pH5 = new PdfPCell(new Paragraph("预存金额", FontColumn));
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            PdfPCell pHBalanceDateTime = new PdfPCell(new Paragraph("发票", FontColumn));
            pHBalanceDateTime.NoWrap = true;
            pHBalanceDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHBalanceDateTime);

            PdfPCell phInsertPerson = new PdfPCell(new Paragraph("税费", FontColumn));
            phInsertPerson.NoWrap = true;
            phInsertPerson.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(phInsertPerson);

            decimal paidAmountTotal = 0;
            decimal preDepositiAmountTotal = 0;
            decimal ticketAmountTotal = 0;
            decimal scotAmuntTotal = 0;
            for (int j = 0; j < u.OtherGathingAndRefundMentRecordPrintList.Count; j++)
            {
                decimal pAmount = u.OtherGathingAndRefundMentRecordPrintList[j].PreDepositiAmount;
                if (0 < pAmount) preDepositiAmountTotal += pAmount;
                else pAmount = 0;

                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);

                PdfPCell pcOrderNo = new PdfPCell(new Paragraph(u.OtherGathingAndRefundMentRecordPrintList[j].CustomerName, FontColumnValue));
                pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNo);

                PdfPCell pcCustomerValue = new PdfPCell(new Paragraph(u.OtherGathingAndRefundMentRecordPrintList[j].InsertDateTimeString, FontColumnValue));
                pcCustomerValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcCustomerValue);

                PdfPCell pcProjectName = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.OtherGathingAndRefundMentRecordPrintList[j].PaidAmount), FontColumnValue));
                pcProjectName.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcProjectName);

                PdfPCell pcInsertDateTimeValue = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(pAmount), FontColumnValue));
                pcInsertDateTimeValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcInsertDateTimeValue);

                PdfPCell pcBalanceDateTimeValue = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.OtherGathingAndRefundMentRecordPrintList[j].TicketAmountSum), FontColumnValue));
                pcBalanceDateTimeValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcBalanceDateTimeValue);

                PdfPCell pcInsertPerson = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.OtherGathingAndRefundMentRecordPrintList[j].Amount), FontColumnValue));
                pcInsertPerson.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcInsertPerson);

                paidAmountTotal += u.OtherGathingAndRefundMentRecordPrintList[j].PaidAmount;
                //preDepositiAmountTotal += u.OtherGathingAndRefundMentRecordPrintList[j].PreDepositiAmount;
                ticketAmountTotal += u.OtherGathingAndRefundMentRecordPrintList[j].TicketAmountSum;
                scotAmuntTotal += u.OtherGathingAndRefundMentRecordPrintList[j].Amount;
            }

            PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumnValue));
            pcTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcTotal.Colspan = 3;
            ptb.AddCell(pcTotal);

            PdfPCell pcPaidAmountTotal = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(paidAmountTotal), FontColumnValue));
            pcPaidAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcPaidAmountTotal);

            PdfPCell pcPrepositiAmountTotal = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(preDepositiAmountTotal), FontColumnValue));
            pcPrepositiAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcPrepositiAmountTotal);

            PdfPCell pcTicketAmountTotal = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(ticketAmountTotal), FontColumnValue));
            pcTicketAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcTicketAmountTotal);

            PdfPCell pcScotAmountTotal = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(scotAmuntTotal), FontColumnValue));
            pcScotAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcScotAmountTotal);
            return ptb;
        }
        public override PdfPTable GetReportFooter(FindFinanceModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(FindFinanceModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(FindFinanceModel u)
        {
            return null;
        }
        public override Paragraph GetReportSubject(string subject)
        {
            Font f = new Font(FontBase.BaseFont, 20, Font.BOLD);
            Paragraph p = new Paragraph(subject, f);
            p.Font = f;
            p.Alignment = Element.ALIGN_CENTER;
            return p;
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
    }
}
