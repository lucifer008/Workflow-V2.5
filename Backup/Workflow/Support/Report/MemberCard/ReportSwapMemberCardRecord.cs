using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
namespace Workflow.Support.Report.MemberCard
{
    /// <summary>
    /// 名    称: 会员换卡记录 报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月2日15:55:15
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportSwapMemberCardRecord : ReportBase<iTextSharp.text.pdf.PdfPTable, MemberCardModel>
    {
        /// <summary>
        /// 查询字符串条件
        /// </summary>
        private string queryString = "查询条件 ";
        /// <summary>
        /// 获取或者设置查询字符串条件
        /// </summary>
        public string QueryString
        {
            set { queryString = value; }
            get { return queryString; }
        }

        public override void CreateReport(MemberCardModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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

                if (!string.IsNullOrEmpty(reportSubject))
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
        public override PdfPTable GetReportHeader(MemberCardModel u)
        {
            PdfPTable ptb = new PdfPTable(6);

            PdfPCell pcNull = new PdfPCell(new Paragraph(" ", FontHeader));
            pcNull.HorizontalAlignment = 2;
            pcNull.Border = 0;
            pcNull.Colspan = 6;
            pcNull.FixedHeight = 30;
            pcNull.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcNull);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.Colspan = 4;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 2;
            ptb.AddCell(pc2);

            return ptb;
        }
        private PdfPTable GetOrderItem(MemberCardModel u)
        {

            ///定义列标题
            ///
            //float [] ColumnWidth={ 10,20,15,20,20};
            float[] ColumnWidth ={ 10, 20, 15,15, 20,20 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);
            //ptb.SetWidths(new int[]{10,10,10,10});

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("客户名称", FontColumn));
            pH3.NoWrap = false;
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("原卡号", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pH5 = new PdfPCell(new Paragraph("新卡号", FontColumn));
            pH5.NoWrap = true;
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            PdfPCell pcTotal = new PdfPCell(new Paragraph("时间", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

            PdfPCell pcMemo = new PdfPCell(new Paragraph("备注", FontColumn));
            pcMemo.NoWrap = true;
            pcMemo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMemo);

            int index=1;
            foreach(ChangeMemberCard cm in u.ChangeMemberCardListPrint)
            {
                //NO
                PdfPCell pcNoValue = new PdfPCell(new Paragraph(index.ToString(), FontColumnValue));
                pcNoValue.NoWrap = true;
                pcNoValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNoValue);

                //客户名称
                PdfPCell pcCustomerNameValue = new PdfPCell(new Paragraph(cm.CustomerName, FontColumnValue));
                pcCustomerNameValue.NoWrap = false;
                pcCustomerNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCustomerNameValue);

                //原卡号

                PdfPCell pcOldMemberCardValue = new PdfPCell(new Paragraph(cm.OldMemberCardNo, FontColumnValue));
                pcOldMemberCardValue.NoWrap = true;
                pcOldMemberCardValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOldMemberCardValue);

                //新卡号

                PdfPCell pcNewMemberCardValue = new PdfPCell(new Paragraph(cm.NewMemberCardNo, FontColumnValue));
                pcNewMemberCardValue.NoWrap = true;
                pcNewMemberCardValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNewMemberCardValue);

                //时间

                PdfPCell pcInsertDateTimeValue = new PdfPCell(new Paragraph(cm.InsertDateTime.ToString("yyyy-MM-dd HH:mm"), FontColumnValue));
                pcInsertDateTimeValue.NoWrap = true;
                pcInsertDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcInsertDateTimeValue);

                //备注
                PdfPCell pcMemoValue = new PdfPCell(new Paragraph(cm.Memo, FontColumnValue));
                pcMemoValue.NoWrap = true;
                pcMemoValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMemoValue);

                index++;
            }
            return ptb;
        }
        public override PdfPTable GetReportFooter(MemberCardModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(MemberCardModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(MemberCardModel u)
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
