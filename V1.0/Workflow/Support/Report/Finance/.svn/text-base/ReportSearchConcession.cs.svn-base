using System;
using System.IO;
using System.Text;
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
    /// 名    称: 优惠查询报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009年5月21日14:18:37
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportSearchConcession : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
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
            float[] ColumnWidth ={ 10, 15, 20, 40 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.FixedHeight = 30;
            pcBlank1.Colspan = 4;
            pcBlank1.NoWrap = false;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.NoWrap = false;
            pc1.Colspan = 3;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);

            PdfPCell pcBlank2 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank2.HorizontalAlignment = 2;
            pcBlank2.Border = 0;
            pcBlank1.Colspan = 4;
            pcBlank2.NoWrap = false;
            pcBlank2.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank2);
            return ptb;
        }
        private PdfPTable GetOrderItem(FindFinanceModel u)
        {

            ///定义列标题
            ///
            float[] ColumnWidth ={ 10, 15, 20, 40 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);
            //ptb.SetWidths(new int[]{10,10,10,10});

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("工单号", FontColumn));
            pH3.NoWrap = true;
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("优惠合计", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pH5 = new PdfPCell(new Paragraph("多收合计", FontColumn));
            pH5.NoWrap = true;
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            decimal paymentConcessionTotal = 0,moreConcessionTotal=0;
            for (int j = 0; j < u.PaymentConcessionPrintList.Count; j++)
            {
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);

                PdfPCell pcOrderNo = new PdfPCell(new Paragraph(u.PaymentConcessionPrintList[j].OrderNo, FontColumnValue));
                pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNo);

                PdfPCell pcPaymentConcession = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.PaymentConcessionPrintList[j].ConcessionAmountTotal), FontColumnValue));
                pcPaymentConcession.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcPaymentConcession);
                PdfPCell pcMoreConcession = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.PaymentConcessionPrintList[j].MoreConcessionAmountTotal), FontColumnValue));
                pcMoreConcession.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMoreConcession);
                paymentConcessionTotal += u.PaymentConcessionPrintList[j].ConcessionAmountTotal;//合计优惠
                moreConcessionTotal += u.PaymentConcessionPrintList[j].MoreConcessionAmountTotal;//合计多收金额
            }

            PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.Colspan = 2;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

            PdfPCell pcPaymentTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(paymentConcessionTotal), FontColumnValue));
            pcPaymentTotal.NoWrap = true;
            pcPaymentTotal.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcPaymentTotal);

            PdfPCell pcMoreTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(moreConcessionTotal), FontColumnValue));
            pcMoreTotal.NoWrap = true;
            pcMoreTotal.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcMoreTotal);
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
