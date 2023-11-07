using System;
using System.IO;
using System.Collections.Generic;
using Workflow.Util;
using iTextSharp.text;
using Workflow.Da.Domain;
using iTextSharp.text.pdf;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
using Workflow.Action.LogCounters;
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
	public class ReportSearchCounter : ReportBase<iTextSharp.text.pdf.PdfPTable, SearchCounterModel>
    {

		public override void CreateReport(SearchCounterModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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

                doc.Add(GetReportSubject(reportSubject));
                Font font = new Font(1, 10);
                Paragraph p = new Paragraph("", font);
                doc.Add(p);
                
				doc.Add(GetReportHeader(u));
				doc.Add(GetOrderItem(u));
								
				doc.Close();
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
		public override PdfPTable GetReportHeader(SearchCounterModel u)
        {
            PdfPTable ptb = new PdfPTable(5);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.FixedHeight = 30;
            pc1.Colspan = 5;
            ptb.AddCell(pc1);

            PdfPCell pcQueryCondition = new PdfPCell(new Paragraph("",FontHeader));
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
		private PdfPTable GetOrderItem(SearchCounterModel u)
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

			int rowCount = 0;
			decimal amount = 0;
			Workflow.Action.LogCounters.DataUnite unite = null;
			foreach (DailyRecordMachine val in u.DailyRecordMachines)
			{
				if (rowCount == 0)
				{
					unite = (Workflow.Action.LogCounters.DataUnite)u.Map[val.MachineTypeId];
					
					PdfPCell pcMachineValue = new PdfPCell(new Paragraph(val.MachineTypeName, FontColumn));
					pcMachineValue.NoWrap = false;
					pcMachineValue.DisableBorderSide(2);
					pcMachineValue.HorizontalAlignment = Element.ALIGN_CENTER;
					ptb.AddCell(pcMachineValue);
				}
				else 
				{
					PdfPCell pcMachineValue = new PdfPCell();
					pcMachineValue.DisableBorderSide(1);
					if(rowCount!=1)
						pcMachineValue.DisableBorderSide(2);
					ptb.AddCell(pcMachineValue);
				}

				PdfPCell pcPaperShapeValue = new PdfPCell(new Paragraph(val.PaperSpecificationName, FontColumnValue));
				pcPaperShapeValue.NoWrap = true;
				pcPaperShapeValue.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcPaperShapeValue);

				PdfPCell pcColorValue = new PdfPCell(new Paragraph(Constants.GetColorType(val.ColorType), FontColumn));
				pcColorValue.NoWrap = true;
				pcColorValue.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcColorValue);

				PdfPCell pcCountValue = new PdfPCell(new Paragraph(val.InWatchCount.ToString(), FontColumn));
				pcCountValue.NoWrap = false;
				pcCountValue.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcCountValue);
				if (rowCount == 0)
				{
					amount = unite.Amount;
					rowCount = unite.UniteCount;
					PdfPCell pcTotalValue = new PdfPCell(new Paragraph(amount.ToString(), FontColumnValue));
					pcTotalValue.DisableBorderSide(2);
					pcTotalValue.NoWrap = false;
					pcTotalValue.HorizontalAlignment = Element.ALIGN_CENTER;
					ptb.AddCell(pcTotalValue);
				}
				else
				{
					PdfPCell pcTotalValue = new PdfPCell();
					pcTotalValue.DisableBorderSide(1);
					if (rowCount != 1)
						pcTotalValue.DisableBorderSide(2);
					ptb.AddCell(pcTotalValue);
				}
				rowCount--;
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
		public override PdfPTable GetReportFooter(SearchCounterModel u)
        {
            return null;
        }
		public override PdfPTable GetReportObject(SearchCounterModel u)
        {
            return null;
        }
		public override PdfPTable GetReportContent(SearchCounterModel u)
        {
            return null;
        }
    }
}
