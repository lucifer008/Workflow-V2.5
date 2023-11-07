using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Spring.Context;
using Spring.Context.Support;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Exception;
using Workflow.Action.Finance.Find;
using Workflow.Support.Report.Base;
using Workflow.Action.Finance.Find.Model;

namespace Workflow.Support.Report.Finance
{
    /// <summary>
    /// 日营业报表
    /// </summary>
    /// <remarks>
    /// 作    者：张晓林
    /// 日    期: 2010年4月21日9:30:31
    /// </remarks>
    public class ReportDailyStatistical : ReportBase<iTextSharp.text.Table, DailyStatisticalModel>
    {
        /// <summary>
        /// 查询字符串条件
        /// </summary>
        private string queryString = "查询条件 ";
        private string date;
        public string Date 
        {
            set { date = value; }
            get { return date; }
        }
        /// <summary>
        /// 获取或者设置查询字符串条件
        /// </summary>
        public string QueryString
        {
            set { queryString = value; }
            get { return queryString; }
        }

        public override void CreateReport(DailyStatisticalModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
                Table tHead = this.GetReportHeader(u);
                Table tOrderItem = this.GetOrderItem(u);
                doc.Add(new Table(1));
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
        public override Table GetReportHeader(DailyStatisticalModel u)
        {

            Table ptb = new Table(4);
            ptb.Border = 0;
            Cell pcBlank12 = new Cell(new Paragraph("", FontHeader));
            pcBlank12.HorizontalAlignment = 2;
            pcBlank12.Border = 0;
            pcBlank12.Colspan = 4;
            //pcBlank12.FixedHeight = 30;
            pcBlank12.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank12);

            Cell pcBlank1 = new Cell(new Paragraph(QueryString, FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.Colspan = 2;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            Cell pc2 = new Cell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 2;
            ptb.AddCell(pc2);

            Cell pcBlank11 = new Cell(new Paragraph("", FontBase));
            pcBlank11.HorizontalAlignment = 2;
            pcBlank11.Border = 0;
            pcBlank11.Colspan = 4;
            pcBlank11.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank11);
            return ptb;
        }
        private Table GetOrderItem(DailyStatisticalModel u)
        {
            Table ptb = new Table(5);
            ptb.Border = -1;
            Cell pH1 = new Cell(new Paragraph("业务", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            Cell pH11 = new Cell(new Paragraph("纸型", FontColumn));
            pH11.NoWrap = true;
            pH11.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH11);

            Cell pH3 = new Cell(new Paragraph("数量", FontColumn));
            pH3.NoWrap = true;
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            Cell pH4 = new Cell(new Paragraph("金额", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            Cell pH5 = new Cell(new Paragraph("占收入%", FontColumn));
            pH5.NoWrap = true;
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            decimal amountTotal = 0;//现金合计
            decimal countTotal = 0;//数量合计
            for (int j = 0; j < u.DailyBusionessReportItemList.Count; j++)
            {

                amountTotal += u.DailyBusionessReportItemList[j].Count;
                countTotal += u.DailyBusionessReportItemList[j].Amount;
                int rowSpan=u.DailyBusionessReportItemList[j].TypeSort;
                Cell cBusinoessTypeName = null;
                if (0 != rowSpan) 
                {
                    cBusinoessTypeName = new Cell(new Paragraph(u.DailyBusionessReportItemList[j].Name, FontColumnValue));
                    cBusinoessTypeName.Rowspan = rowSpan;
                    cBusinoessTypeName.HorizontalAlignment = Element.ALIGN_CENTER; ;
                    ptb.AddCell(cBusinoessTypeName);
                }
                Cell cPaperSpacification = new Cell(new Paragraph(u.DailyBusionessReportItemList[j].PaperSpecificationName, FontColumnValue));
                cPaperSpacification.HorizontalAlignment = Element.ALIGN_CENTER; ;
                ptb.AddCell(cPaperSpacification);

                Cell cCount = new Cell(new Paragraph(u.DailyBusionessReportItemList[j].Amount.ToString(), FontColumnValue));
                cCount.HorizontalAlignment = Element.ALIGN_CENTER; ;
                ptb.AddCell(cCount);

                Cell cAmount = new Cell(new Paragraph(u.DailyBusionessReportItemList[j].Count.ToString(), FontColumnValue));
                cAmount.HorizontalAlignment = Element.ALIGN_CENTER; ;
                ptb.AddCell(cAmount);

                Cell cInverseValue = null;
                if (0 != rowSpan)
                {
                    //注入Action
                    IApplicationContext ctx =ContextRegistry.GetContext();
                    DailyStatisticalAction dailyStatisticalAction =ctx.GetObject("dailyStatisticalAction") as DailyStatisticalAction;
                    cInverseValue = new Cell(new Paragraph(dailyStatisticalAction.GetSameBusinessTypeInverse(u.DailyBusionessReportItemList[j].Name,date), FontColumnValue));
                    cInverseValue.Rowspan = rowSpan;
                    cInverseValue.HorizontalAlignment = Element.ALIGN_CENTER; ;
                    ptb.AddCell(cInverseValue);
                }
            }

            Cell pcTotal = new Cell(new Paragraph("合计", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.Colspan = 2;
            pcTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcTotal);

            Cell pcCountTotal = new Cell(new Paragraph(NumericUtils.ToAmount(countTotal), FontColumnValue));
            pcCountTotal.NoWrap = true;
            pcCountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcCountTotal);

            Cell pcAmountTotal = new Cell(new Paragraph(NumericUtils.ToMoney(amountTotal), FontColumnValue));
            pcAmountTotal.NoWrap = true;
            pcAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcAmountTotal);

            Cell pcNull = new Cell(new Paragraph("", FontColumn));
            pcNull.NoWrap = true;
            pcNull.Colspan = 1;
            pcNull.HorizontalAlignment = Element.ALIGN_RIGHT;
            ptb.AddCell(pcNull);
            return ptb;
        }
        public override Table GetReportFooter(DailyStatisticalModel u)
        {
            return null;
        }
        public override Table GetReportObject(DailyStatisticalModel u)
        {
            return null;
        }
        public override Table GetReportContent(DailyStatisticalModel u)
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
