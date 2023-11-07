using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Report.Base;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Support.Exception;
using System.IO;
using Workflow.Support.Log;
using Workflow.Util;
using System.Collections;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;

namespace Workflow.Support.Report.Finance
{
	public class ReportOrderItem : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
	{
		public override void CreateReport(FindFinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
		public override PdfPTable GetReportHeader(FindFinanceModel u)
		{
			PdfPTable ptb = new PdfPTable(6);
			PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
			pc1.HorizontalAlignment = 2;
			pc1.Border = 0;
			pc1.FixedHeight = 30;
			pc1.Colspan = 5;
			ptb.AddCell(pc1);

			PdfPCell pcQueryCondition = new PdfPCell(new Paragraph("", FontHeader));
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
		private PdfPTable GetOrderItem(FindFinanceModel u)
		{

			///定义列标题
			///
			float[] ColumnWidth ={ 7, 20, 45, 15, 15, 30 };
			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell cell = new PdfPCell(new Paragraph("No", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("订单号", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("客户名称", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("数量", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("金额", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("备注", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);


			int i = 1;
			
			decimal itemAmount= 0;
			decimal sumAmount = 0;
			foreach (Order val in u.PrintOrderList)
			{
				cell = new PdfPCell(new Paragraph(i.ToString(), FontColumnValue));
				cell.NoWrap = true;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.No, FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.CustomerName, FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.ItemAmount.ToString(), FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.SumAmount.ToString(), FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.Memo, FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				itemAmount += val.ItemAmount;
				sumAmount += val.SumAmount;
				i++;
			}
			cell = new PdfPCell(new Paragraph("合计", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph(itemAmount.ToString(), FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph(sumAmount.ToString(), FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

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
				Font ft = new Font(FontBase.BaseFont, 10, Font.COURIER);
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
	}
}
