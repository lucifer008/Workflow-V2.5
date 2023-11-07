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
    /// 名    称:ReportOperationRecord
    /// 功能概要:会员卡管理记录报表
    /// 作    者:张晓林
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class ReportOperationRecord : ReportBase<iTextSharp.text.pdf.PdfPTable, MemberCardModel>
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
            PdfPTable ptb = new PdfPTable(7);

            PdfPCell pcNull = new PdfPCell(new Paragraph(" ", FontHeader));
            pcNull.HorizontalAlignment = 2;
            pcNull.Border = 0;
            pcNull.Colspan = 7;
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
            pc2.Colspan = 3;
            ptb.AddCell(pc2);

            return ptb;
        }
        private PdfPTable GetOrderItem(MemberCardModel u)
        {

            ///定义列标题
            ///
            //float [] ColumnWidth={ 10,20,15,20,20};
            float[] ColumnWidth ={ 10, 20, 25, 30, 20, 20,25 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);
            //ptb.SetWidths(new int[]{10,10,10,10});

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pH4 = new PdfPCell(new Paragraph("会员卡号", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pH3 = new PdfPCell(new Paragraph("客户名称", FontColumn));
            pH3.NoWrap = false;
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH5 = new PdfPCell(new Paragraph("操作时间", FontColumn));
            pH5.NoWrap = true;
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            PdfPCell pcTotal = new PdfPCell(new Paragraph("操作人", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

            PdfPCell pcOperate = new PdfPCell(new Paragraph("操作", FontColumn));
            pcOperate.NoWrap = true;
            pcOperate.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOperate);

            PdfPCell pcMemo = new PdfPCell(new Paragraph("备注", FontColumn));
            pcMemo.NoWrap = true;
            pcMemo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMemo);

            int index = 1;
            foreach ( Workflow.Da.Domain.MemberCard mc in u.MemberCardPrintList)
            {
                //NO
                PdfPCell pcNoValue = new PdfPCell(new Paragraph(index.ToString(), FontColumnValue));
                pcNoValue.NoWrap = true;
                pcNoValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNoValue);


                //会员卡号

                PdfPCell pcMemberCardValue = new PdfPCell(new Paragraph(mc.MemberCardNo, FontColumnValue));
                pcMemberCardValue.NoWrap = true;
                pcMemberCardValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMemberCardValue);

                //客户名称
                PdfPCell pcCustomerNameValue = new PdfPCell(new Paragraph(mc.CustomerName, FontColumnValue));
                pcCustomerNameValue.NoWrap = false;
                pcCustomerNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCustomerNameValue);

                //操作时间

                PdfPCell pcInsertDateTimeValue = new PdfPCell(new Paragraph(mc.InsertDateTime.ToString("yyyy-MM-dd HH:mm"), FontColumnValue));
                pcInsertDateTimeValue.NoWrap = true;
                pcInsertDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcInsertDateTimeValue);

                //操作人

                PdfPCell pcInsertUserNameValue = new PdfPCell(new Paragraph(mc.InsertUserName, FontColumnValue));
                pcInsertUserNameValue.NoWrap = true;
                pcInsertUserNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcInsertUserNameValue);

                //操作

                PdfPCell pcOperateValue = new PdfPCell(new Paragraph(Constants.GetMemberCardOperateType(Convert.ToString(mc.OperateType)), FontColumnValue));
                pcOperateValue.NoWrap = true;
                pcOperateValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOperateValue);


                //备注
                PdfPCell pcMemoValue = new PdfPCell(new Paragraph(mc.Memo, FontColumnValue));
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
