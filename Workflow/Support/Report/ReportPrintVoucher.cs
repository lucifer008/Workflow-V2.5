using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;

namespace Workflow.Support.Report
{
	public class ReportPrintVoucher : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
	{
		protected const float ROW_HEIGHT = 20F;
		private bool isDisplayBarCode = false;
		public bool IsDisplayBarCode
		{
			set { isDisplayBarCode = value; }
			get { return isDisplayBarCode; }
		}
		public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
		{
			Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
			if (String.IsNullOrEmpty(this.FileName))
			{
				throw new WorkflowException("报表名称不能为空!");
			}
			FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate);
			fs.Lock(0, fs.Length);
			PdfWriter.GetInstance(doc, fs);
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

			if (null != tHead)
			{
				doc.Add(tHead);
			}
			if (null != tOrderItem)
			{
				doc.Add(tOrderItem);
			}
			//增加打印条码
			//if (isDisplayBarCode)
			//{
			//    Barcode39 code = new Barcode39();
			//    code.Code = u.NewOrder.No.ToUpper();
			//    code.BarHeight = 50;
			//    System.Drawing.Image b = code.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);

			//    PdfPTable tBmp = this.AddBitmap(b);
			//    if (null != tBmp)
			//    {
			//        doc.Add(tBmp);
			//    }
			//}
			doc.Close();
		}

		public override PdfPTable GetReportHeader(OrderModel u)
		{
			float[] ColumnWidth ={ 10, 15, 20, 40 };

			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
			pc1.Colspan = 4;
			pc1.Border = 0;
			pc1.FixedHeight = 10;
			ptb.AddCell(pc1);

			PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
			pc2.HorizontalAlignment = 2;
			pc2.Border = 0;
			pc2.Colspan = 4;
			ptb.AddCell(pc2);

			PdfPCell pc3 = new PdfPCell(new Paragraph("", FontHeader));
			pc3.Colspan = 4;
			pc3.Border = 0;
			pc3.FixedHeight = 10;
			ptb.AddCell(pc3);
			return ptb;
		}
		private PdfPTable GetOrderItem(OrderModel u)
		{
			float[] ColumnWidth ={ 20, 20, 20, 20 };
			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell pc1 = new PdfPCell(new Paragraph("类型:", FontHeader));
			pc1.HorizontalAlignment = 2;
			pc1.Border = 0;
			pc1.NoWrap = false;
			ptb.AddCell(pc1);

			PdfPCell pc2 = new PdfPCell(new Paragraph("打印", FontHeader));
			pc2.Border = 0;
			pc2.NoWrap = false;
			pc2.HorizontalAlignment = Element.ALIGN_LEFT;
			ptb.AddCell(pc2);

			PdfPCell pc23 = new PdfPCell(new Paragraph("数量:", FontHeader));
			pc23.HorizontalAlignment = 2;
			pc23.Border = 0;
			pc23.NoWrap = false;
			ptb.AddCell(pc23);

			PdfPCell pc24 = new PdfPCell(new Paragraph("111", FontHeader));
			pc24.Border = 0;
			pc24.NoWrap = false;
			pc24.HorizontalAlignment = Element.ALIGN_LEFT;
			ptb.AddCell(pc24);
			return ptb;
		}
		public override PdfPTable GetReportFooter(OrderModel u)
		{
			return null;
		}
		public override PdfPTable GetReportObject(OrderModel u)
		{
			return null;
		}
		public override PdfPTable GetReportContent(OrderModel u)
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
		public PdfPTable AddBitmap(System.Drawing.Image b)
		{
			iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(b, System.Drawing.Imaging.ImageFormat.Bmp);

			float[] widths ={ 200, 150, 80 };
			PdfPTable ptb = new PdfPTable(widths);
			PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));
			PdfPCell pc2 = new PdfPCell(new Paragraph("", FontBase));
			PdfPCell pc3 = new PdfPCell(image, true);
			pc1.Border = 0;
			pc2.Border = 0;
			pc3.Border = 0;
			ptb.AddCell(pc1);
			ptb.AddCell(pc2);
			ptb.AddCell(pc3);
			return ptb;
		}
	}
}
