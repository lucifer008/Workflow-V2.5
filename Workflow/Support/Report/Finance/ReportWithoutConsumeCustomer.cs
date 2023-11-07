using System;
using System.IO;
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
    /// ���ܸ�Ҫ: �����ѿͻ���ѯ����
    /// ��    ��: ������ 
    /// ����ʱ��: 2010��1��25��17:01:53
    /// ��������: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class ReportWithoutConsumeCustomer : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
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
        private bool tag = false;
        public bool Tag
        {
            set { tag = value; }
            get { return tag; }
        }

        public override void CreateReport(FindFinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
            catch (System.Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
        public override PdfPTable GetReportHeader(FindFinanceModel u)
        {
            float[] ColumnWidth ={ 10, 25, 25, 25, 25};

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank1.Border = 0;
            pcBlank1.FixedHeight = 30;
            pcBlank1.Colspan = 5;
            ptb.AddCell(pcBlank1);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.NoWrap = false;
            pc1.Colspan = 3;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 2;
            ptb.AddCell(pc2);

            PdfPCell pcBlank2 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank2.Border = 0;
            pcBlank2.Colspan = 5;
            ptb.AddCell(pcBlank2);
            return ptb;
        }
        private PdfPTable GetOrderItem(FindFinanceModel u)
        {

            ///�����б���
            ///
            float[] ColumnWidth ={ 10, 25, 25, 25, 25 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("�ͻ�����", FontColumn));
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("���һ����ϵ��", FontColumn));
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pHProjectName = new PdfPCell(new Paragraph("��ϵ�绰", FontColumn));
            pHProjectName.NoWrap = true;
            pHProjectName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHProjectName);

            PdfPCell pH5 = new PdfPCell(new Paragraph("���һ������ʱ��", FontColumn));
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);


            for (int j = 0; j < u.CustomerPrintList.Count; j++)
            {
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);

                PdfPCell pcOrderNo = new PdfPCell(new Paragraph(u.CustomerPrintList[j].Name, FontColumnValue));
                pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNo);

                PdfPCell pcCustomerValue = new PdfPCell(new Paragraph(u.CustomerPrintList[j].LastLinkMan, FontColumnValue));
                pcCustomerValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcCustomerValue);

                PdfPCell pcProjectName = new PdfPCell(new Paragraph(u.CustomerPrintList[j].LastTelNo, FontColumnValue));
                pcProjectName.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcProjectName);



                PdfPCell pcInsertPerson = new PdfPCell(new Paragraph(u.CustomerPrintList[j].InsertDateTime.ToString("yyyy-MM-dd HH:mm"), FontColumnValue));
                pcInsertPerson.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcInsertPerson);

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
