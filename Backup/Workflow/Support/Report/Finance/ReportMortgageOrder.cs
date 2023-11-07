using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;

namespace Workflow.Support.Report.Finance
{
    /// <summary>
    ///  ��    �ƣ�ReportMortgageOrder
    ///  ���ܸ�Ҫ��������γ��������ϸ
    ///  ��    �ߣ�������
    ///  ����ʱ�䣺2009��12��8��17:24:15
    ///  ����������
    /// </summary>
    public class ReportMortgageOrder : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
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
            catch (System.Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
        public override PdfPTable GetReportHeader(OrderModel u)
        {
            float[] ColumnWidth ={ 30, 30, 30 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.FixedHeight = 30;
            pcBlank1.Colspan = 3;
            pcBlank1.NoWrap = false;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 3;
            ptb.AddCell(pc2);

            PdfPCell pcBlank2 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank2.HorizontalAlignment = 2;
            pcBlank2.Border = 0;
            pcBlank2.Colspan = 3;
            pcBlank2.NoWrap = false;
            pcBlank2.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank2);
            return ptb;
        }
        private PdfPTable GetOrderItem(OrderModel u)
        {

            ///�����б���
            ///
            float[] ColumnWidth ={ 30, 30, 30 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pHSrcOrderNo = new PdfPCell(new Paragraph("�����������", FontColumn));
            pHSrcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHSrcOrderNo);

            PdfPCell pHOrderNo = new PdfPCell(new Paragraph("���������", FontColumn));
            pHOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHOrderNo);

            PdfPCell pHDiffAmount = new PdfPCell(new Paragraph("������", FontColumn));
            pHDiffAmount.NoWrap = true;
            pHDiffAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHDiffAmount);

           
            if(null!=u.OrderMortgageRecord)
            {
                PdfPCell pcSrcOrderNo = new PdfPCell(new Paragraph(u.OrderMortgageRecord.SrcOrderNo, FontColumnValue));
                pcSrcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcSrcOrderNo);

                PdfPCell pcOrderNo = new PdfPCell(new Paragraph(u.OrderMortgageRecord.OrderNo, FontColumnValue));
                pcOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNo);

                PdfPCell pcDiffAmount = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToAmount(u.OrderMortgageRecord.DiffAmount), FontColumnValue));
                pcDiffAmount.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcDiffAmount);

            }
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
