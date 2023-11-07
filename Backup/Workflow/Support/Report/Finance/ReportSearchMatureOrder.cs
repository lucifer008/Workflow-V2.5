using System;
using System.Collections.Generic;
using System.IO;
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
    ///  名    称：ReportSearchMatureOrder
    ///  功能概要：输出所有满足条件的到期订单
    ///  作    者：张晓林
    ///  创建时间：2009年12月5日9:46:21
    ///  修正履历：
    /// </summary>
    public class ReportSearchMatureOrder : ReportBase<iTextSharp.text.pdf.PdfPTable, FinanceModel>
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

        public override void CreateReport(FinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
        public override PdfPTable GetReportHeader(FinanceModel u)
        {
            float[] ColumnWidth={ 10, 25, 30, 25, 25, 25, 20, 15, 40 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.FixedHeight = 30;
            pcBlank1.Colspan = 9;
            pcBlank1.NoWrap = false;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.NoWrap = false;
            pc1.Colspan = 6;
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
            pcBlank2.Colspan = 9;

            pcBlank2.NoWrap = false;
            pcBlank2.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank2);
            return ptb;
        }
        private PdfPTable GetOrderItem(FinanceModel u)
        {

            ///定义列标题
            ///
            float[] ColumnWidth ={ 10, 25, 30, 25, 25, 25, 20, 15, 40 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("订单号", FontColumn));
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("客户名称", FontColumn));
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pHProjectName = new PdfPCell(new Paragraph("项目名称", FontColumn));
            pHProjectName.NoWrap = true;
            pHProjectName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHProjectName);

            PdfPCell pH5 = new PdfPCell(new Paragraph("开单时间", FontColumn));
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            PdfPCell pHBalanceDateTime = new PdfPCell(new Paragraph("结算时间", FontColumn));
            pHBalanceDateTime.NoWrap = true;
            pHBalanceDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHBalanceDateTime);

            PdfPCell phInsertPerson = new PdfPCell(new Paragraph("开单人", FontColumn));
            phInsertPerson.NoWrap = true;
            phInsertPerson.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(phInsertPerson);

            PdfPCell pHCash = new PdfPCell(new Paragraph("收银", FontColumn));
            pHCash.NoWrap = true;
            pHCash.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHCash);

            PdfPCell pHMemo = new PdfPCell(new Paragraph("备注", FontColumn));
            pHMemo.NoWrap = true;
            pHMemo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHMemo);
            for (int j = 0; j < u.OrderPrintList.Count; j++)
            {
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);

                PdfPCell pcOrderNo = new PdfPCell(new Paragraph(u.OrderPrintList[j].No, FontColumnValue));
                pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNo);

                PdfPCell pcCustomerValue = new PdfPCell(new Paragraph(u.OrderPrintList[j].CustomerName, FontColumnValue));
                pcCustomerValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcCustomerValue);

                PdfPCell pcProjectName = new PdfPCell(new Paragraph(u.OrderPrintList[j].ProjectName, FontColumnValue));
                pcProjectName.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcProjectName);

                PdfPCell pcInsertDateTimeValue = new PdfPCell(new Paragraph(u.OrderPrintList[j].InsertDateTime.ToString("yyyy-MM-dd HH:mm"), FontColumnValue));
                pcInsertDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcInsertDateTimeValue);

                string strBa = "";
                if (Constants.NULL_DATE_TIME != u.OrderPrintList[j].BalanceDateTime) 
                {
                    strBa=u.OrderPrintList[j].BalanceDateTime.ToString("yyyy-MM-dd HH:mm");
                }
                PdfPCell pcBalanceDateTimeValue = new PdfPCell(new Paragraph(strBa, FontColumnValue));
                pcBalanceDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcBalanceDateTimeValue);

                PdfPCell pcInsertPerson = new PdfPCell(new Paragraph(u.OrderPrintList[j].UserName, FontColumnValue));
                pcInsertPerson.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcInsertPerson);

                PdfPCell pcCashValue = new PdfPCell(new Paragraph(u.OrderPrintList[j].CashName, FontColumnValue));
                pcCashValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCashValue);

                PdfPCell pcMemo = new PdfPCell(new Paragraph(u.OrderPrintList[j].Memo, FontColumnValue));
                pcMemo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMemo);
            }
            return ptb;
        }
        public override PdfPTable GetReportFooter(FinanceModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(FinanceModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(FinanceModel u)
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
