using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;

namespace Workflow.Support.Report
{
	/// <summary>
	/// ��    ��: Ӧ�տʱ��κϼƱ���
	/// ���ܸ�Ҫ: 
	/// ��    ��: ������
	/// ����ʱ��: 2008-11-29
	/// ��������: 
	/// ����ʱ��:
	/// </summary>
	public class ReportAccountReceivableTotal : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
	{
		/// <summary>
		/// ��ѯ�ַ�������
		/// </summary>
		private string queryString="��ѯ���� ";
		/// <summary>
		/// ��ȡ�������ò�ѯ�ַ�������
		/// </summary>
		public string QueryString 
		{
			set { queryString = value; }
			get { return queryString; }
		}
		public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
		{
			try
			{
				Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
				if (String.IsNullOrEmpty(this.FileName))
				{
					throw new WorkflowException("�������Ʋ���Ϊ��!");
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
			catch(System.Exception ex)
			{
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
				throw ex;
			}
		}
		public override PdfPTable GetReportHeader(OrderModel u)
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

            PdfPCell pc2 = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
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
		private PdfPTable GetOrderItem(OrderModel u)
		{

			///�����б���
			///
			float [] ColumnWidth={ 10,15,20,40};
			PdfPTable ptb = new PdfPTable(ColumnWidth);
			//ptb.SetWidths(new int[]{10,10,10,10});

			PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
			pH1.NoWrap = true;
			pH1.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("�ͻ�����", FontColumn));
			pH3.NoWrap = true;
			pH3.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("Ӧ�տ�", FontColumn));
			pH4.NoWrap = true;
			pH4.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH4);

            PdfPCell pH5 = new PdfPCell(new Paragraph("��ע", FontColumn));
			pH5.NoWrap = true;
			pH5.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH5);

			decimal arrearageTotal = 0;
			for (int j = 0; j < u.OrderList.Count; j++)
			{
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
				pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcNo);

                PdfPCell pcCusomerName = new PdfPCell(new Paragraph(u.OrderList[j].CustomerName, FontColumnValue));
				pcCusomerName.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcCusomerName);

                PdfPCell pAccountReceviableOweMomeyTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[j].AccountReceviableOweMomeyTotal), FontColumnValue));
				pAccountReceviableOweMomeyTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
				ptb.AddCell(pAccountReceviableOweMomeyTotal);
				arrearageTotal += u.OrderList[j].AccountReceviableOweMomeyTotal;

                PdfPCell pcMemo = new PdfPCell(new Paragraph(u.OrderList[j].Memo, FontColumnValue));
				pcMemo.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcMemo);	
			}

           PdfPCell pcTotal = new PdfPCell(new Paragraph("�ϼ�", FontColumn));
			pcTotal.NoWrap = true;
			pcTotal.Colspan = 2;
			pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pcTotal);

           PdfPCell pcArrearageTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(arrearageTotal), FontColumnValue));
			pcArrearageTotal.NoWrap = true;
			pcArrearageTotal.Colspan = 2;
			pcArrearageTotal.HorizontalAlignment = Element.ALIGN_LEFT;
			ptb.AddCell(pcArrearageTotal);
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
