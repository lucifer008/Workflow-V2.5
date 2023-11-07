using System;
using System.IO;
using System.Collections.Generic;
using Workflow.Util;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Da.Domain;
using iTextSharp.text.pdf;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
namespace Workflow.Support.Report.Logcounters
{
    /// <summary>
    /// 名    称：ReportSearchCounter
    /// 功能概要: 计数器查询报表
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月27日10:09:49
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class ReportSearchCounter : ReportBase<iTextSharp.text.pdf.PdfPTable, LogCountersModel>
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

        public override void CreateReport(LogCountersModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
        public override PdfPTable GetReportHeader(LogCountersModel u)
        {
            PdfPTable ptb = new PdfPTable(5);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.FixedHeight = 30;
            pc1.Colspan = 5;
            ptb.AddCell(pc1);

            PdfPCell pcQueryCondition = new PdfPCell(new Paragraph(queryString,FontHeader));
            pcQueryCondition.Border = 0;
            pcQueryCondition.Colspan = 3;
            ptb.AddCell(pcQueryCondition);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 2;
            ptb.AddCell(pc2);

            return ptb;
        }
        private PdfPTable GetOrderItem(LogCountersModel u)
        {

            ///定义列标题
            ///
            float[] ColumnWidth ={ 20, 20, 30, 20,30 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcMachine = new PdfPCell(new Paragraph("机器", FontColumn));
            pcMachine.NoWrap = false;
            pcMachine.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMachine);

            PdfPCell pcPaperShape = new PdfPCell(new Paragraph("纸型", FontColumnValue));
            pcPaperShape.NoWrap = true;
            pcPaperShape.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcPaperShape);

            PdfPCell pcColor = new PdfPCell(new Paragraph("颜色:", FontColumn));
            pcColor.NoWrap = true;
            pcColor.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcColor);

            PdfPCell pcCount= new PdfPCell(new Paragraph("数量", FontColumn));
            pcCount.NoWrap = false;
            pcCount.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcCount);

            PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumnValue));
            pcTotal.NoWrap = true;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

         
            foreach (DailyRecordMachine dm in u.DailyRecordMachineTempList)
            {
                PdfPCell pcMachineValue = new PdfPCell(new Paragraph(dm.MachineName, FontColumn));
                pcMachineValue.NoWrap = false;
                pcMachineValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMachineValue);

                PdfPCell pcPaperShapeValue = new PdfPCell(new Paragraph(dm.PaperSharpe, FontColumnValue));
                pcPaperShapeValue.NoWrap = true;
                pcPaperShapeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcPaperShapeValue);

                PdfPCell pcColorValue = new PdfPCell(new Paragraph(dm.ColorType, FontColumn));
                pcColorValue.NoWrap = true;
                pcColorValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcColorValue);

                PdfPCell pcCountValue = new PdfPCell(new Paragraph(dm.InWatchCount.ToString(), FontColumn));
                pcCountValue.NoWrap = false;
                pcCountValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCountValue);

                PdfPCell pcTotalValue = new PdfPCell(new Paragraph("合计", FontColumnValue));
                pcTotalValue.NoWrap = true;
                pcTotalValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcTotalValue);
            }
            return ptb;
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
        public override PdfPTable GetReportFooter(LogCountersModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(LogCountersModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(LogCountersModel u)
        {
            return null;
        }
    }
}
