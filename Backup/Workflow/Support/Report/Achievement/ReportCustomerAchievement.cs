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
using Workflow.Action.Achievement.Model;

namespace Workflow.Support.Report.Achievement
{
    /// <summary>
    /// ��    ��: Ա����Чͳ�Ʊ���
    /// ���ܸ�Ҫ: 
    /// ��    ��: ������
    /// ����ʱ��: 2009-1-5
    /// ��������: 
    /// ����ʱ��:
    /// </summary>
    public class ReportCustomerAchievement : ReportBase<iTextSharp.text.pdf.PdfPTable, AdjustAchievementModel>
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

        public override void CreateReport(AdjustAchievementModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
        public override PdfPTable GetReportHeader(AdjustAchievementModel u)
        {

            PdfPTable ptb = new PdfPTable(4);

            PdfPCell pcNull = new PdfPCell(new Paragraph(" ", FontHeader));
            pcNull.HorizontalAlignment = 2;
            pcNull.Colspan = 4;
            pcNull.Border = 0;
            pcNull.FixedHeight = 30;
            ptb.AddCell(pcNull);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Colspan = 2;
            pc1.Border = 0;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell pc2 = new PdfPCell(new Paragraph("��ӡ����:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Colspan = 2;
            pc2.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            return ptb;
        }
        private PdfPTable GetOrderItem(AdjustAchievementModel u)
        {


            ///�����б���
            ///
            float[] ColumnWidth ={ 10, 15, 15, 20 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pHEmployee = new PdfPCell(new Paragraph("Ա��", FontColumn));
            pHEmployee.NoWrap = true;
            pHEmployee.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHEmployee);

            PdfPCell pHAchievement = new PdfPCell(new Paragraph("��Ч", FontColumn));
            pHAchievement.NoWrap = true;
            pHAchievement.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHAchievement);


            PdfPCell pH4 = new PdfPCell(new Paragraph("�ϸ�", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            decimal arrearageTotal = 0;
            decimal arrearageTrashTotal = 0;
            for (int j = 0; j < u.AchievementTempList.Count; j++)
            {
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);



                PdfPCell pcCusomerName = new PdfPCell(new Paragraph(u.AchievementTempList[j].EmployeeName, FontColumnValue));
                pcCusomerName.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCusomerName);

                PdfPCell pcAchievement = new PdfPCell(new Paragraph(NumericUtils.ToMoney(Convert.ToDecimal(u.AchievementTempList[j].AchievementValue)), FontColumnValue));
                pcAchievement.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcAchievement);

                PdfPCell pcDepartment = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.AchievementTempList[j].TrashPaper), FontColumnValue));
                pcDepartment.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcDepartment);

                arrearageTotal += u.AchievementTempList[j].AchievementValue;
                arrearageTrashTotal += u.AchievementTempList[j].TrashPaper;
            }
            PdfPCell pcTotal = new PdfPCell(new Paragraph("�ϼ�", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.Colspan = 2;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

            PdfPCell pcArrearageTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(arrearageTotal), FontColumnValue));
            pcArrearageTotal.NoWrap = true;
            pcArrearageTotal.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcArrearageTotal);

            PdfPCell pcArrearageTrashTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(arrearageTrashTotal), FontColumnValue));
            pcArrearageTrashTotal.NoWrap = true;
            pcArrearageTrashTotal.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcArrearageTrashTotal);
            return ptb;
        }
        public override PdfPTable GetReportFooter(AdjustAchievementModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(AdjustAchievementModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(AdjustAchievementModel u)
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
