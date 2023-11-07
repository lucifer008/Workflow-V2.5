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
	public class ReportCustomerPayment : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
	{
		public override void CreateReport(FindFinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
		{
			try
			{
				Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
				if (string.IsNullOrEmpty(this.FileName))
				{
					throw new WorkflowException("�������Ʋ���Ϊ��!");
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
			PdfPTable ptb = new PdfPTable(5);
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

			PdfPCell pc2 = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
			pc2.HorizontalAlignment = 2;
			pc2.Border = 0;
			pc2.Colspan = 2;
			ptb.AddCell(pc2);

			return ptb;
		}
		private PdfPTable GetOrderItem(FindFinanceModel u)
		{

			///�����б���
			///
			float[] ColumnWidth ={ 7,20,20, 20,20, 20, 50 };
			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell cell = new PdfPCell(new Paragraph("No", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("������", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��������", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("�տ���", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("������", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��������", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��ע", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			
			int i = 1;
			decimal amount = 0;
			foreach (Gathering val in u.PrintGatheringList)
			{
				cell = new PdfPCell(new Paragraph(i.ToString(), FontColumnValue));
				cell.NoWrap = true;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.OrderNo, FontColumnValue));
				cell.NoWrap = true;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.GatheringDateTime.ToString("yyyy-MM-dd"), FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.UserName, FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.Amount.ToString(), FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(Constants.GetPayKindLabel(val.PayKind.Trim()), FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.Memo, FontColumnValue));
				cell.NoWrap = false;
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);
				amount += val.Amount;
				i++;
			}
			cell = new PdfPCell(new Paragraph("�ϼ�", FontColumnValue));
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
			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);
			
			cell = new PdfPCell(new Paragraph(amount.ToString(), FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);
			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);
			cell = new PdfPCell(new Paragraph("", FontColumnValue));
			cell.NoWrap = false;
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
		/// ��ȡ�б�������
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
		/// ��ȡ�� ��������
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
