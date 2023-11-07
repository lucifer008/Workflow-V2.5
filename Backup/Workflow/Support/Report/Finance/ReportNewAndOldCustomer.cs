using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
using Workflow.Action.Finance.Model;

namespace Workflow.Support.Report.Finance
{
	public class ReportNewAndOldCustomer : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
	{
		/// <summary>
		/// ��ѯ�ַ�������
		/// </summary>
		private string queryString = "��ѯ���� ";
		/// <summary>
		/// ��ȡ�������ò�ѯ�ַ�������
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

			PdfPTable ptb = new PdfPTable(6);
			PdfPCell cell = new PdfPCell(new Paragraph("", FontHeader));
			cell.HorizontalAlignment = Element.ALIGN_LEFT;
			cell.Border = 0;
			cell.Colspan = 3;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("", FontHeader));
			cell.Border = 0;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
			cell.HorizontalAlignment = Element.ALIGN_RIGHT;
			cell.Border = 0;
			cell.Colspan = 2;
			ptb.AddCell(cell);

			return ptb;
		}
		private PdfPTable GetOrderItem(FindFinanceModel u)
		{

			///�����б���
			///
			float[] ColumnWidth ={ 6, 10, 15, 15, 15,30 };
			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell cell = new PdfPCell(new Paragraph("No", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("����", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("������", FontColumn));
			cell.NoWrap = true;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��ӡ��", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("���", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);

			cell = new PdfPCell(new Paragraph("��ע", FontColumn));
			cell.NoWrap = false;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(cell);


			int i = 1;
			
			foreach (Order val in u.OrderList)
			{
				cell = new PdfPCell(new Paragraph(i.ToString(), FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.Status == 1 ? "�¿ͻ�" : "�Ͽͻ�", FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.OrderCount.ToString(), FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.PaperCount.ToString(), FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph(val.SumAmount.ToString(), FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				cell = new PdfPCell(new Paragraph("", FontColumnValue));
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(cell);

				
				i++;
			}

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
		/// ��ȡ�б�������
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
	}
}
