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
    /// 名    称: 订单绩效统计报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-5
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportOrdersAchievement : ReportBase<iTextSharp.text.pdf.PdfPTable, AdjustAchievementModel>
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

        public override void CreateReport(AdjustAchievementModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            try
            {
                Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
                if (String.IsNullOrEmpty(this.FileName))
                {
                    throw new WorkflowException("报表名称不能为空!");
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
            pcNull.FixedHeight = 30;
            pcNull.Border = 0;
            ptb.AddCell(pcNull);

            PdfPCell pc1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Colspan = 2;
            pc1.Border = 0;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Colspan = 2;
            pc2.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            return ptb;
        }
        private PdfPTable GetOrderItem(AdjustAchievementModel u)
        {


            ///定义列标题
            ///
            float[] ColumnWidth ={ 10, 15, 15, 20};
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            #region //添加订单信息
            PdfPCell pHOrderNo = new PdfPCell(new Paragraph("订单号", FontColumn));
            pHOrderNo.NoWrap = true;
            pHOrderNo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHOrderNo);

            PdfPCell pHOrderNoValue = new PdfPCell(new Paragraph(u.NewAchievement.No, FontColumnValue));
            pHOrderNoValue.NoWrap = true;
            pHOrderNoValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHOrderNoValue);

            PdfPCell pHCustomerName = new PdfPCell(new Paragraph("顾客名称", FontColumn));
            pHCustomerName.NoWrap = true;
            pHCustomerName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHCustomerName);

            PdfPCell pHCustomerNameValue = new PdfPCell(new Paragraph(u.NewAchievement.EmployeeName, FontColumnValue));
            pHCustomerNameValue.NoWrap = true;
            pHCustomerNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHCustomerNameValue);

            PdfPCell pHProjectName = new PdfPCell(new Paragraph("项目名称", FontColumn));
            pHProjectName.NoWrap = true;
            pHProjectName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHProjectName);

            PdfPCell pHProjectNameValue = new PdfPCell(new Paragraph(u.NewAchievement.NewOrderName, FontColumnValue));
            pHProjectNameValue.NoWrap = true;
            pHProjectNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHProjectNameValue);

            PdfPCell pHSumAmount = new PdfPCell(new Paragraph("金额", FontColumn));
            pHSumAmount.NoWrap = true;
            pHSumAmount.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHSumAmount);

            PdfPCell pHSumAmountValue = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.NewAchievement.TrashPaper), FontColumnValue));
            pHSumAmountValue.NoWrap = true;
            pHSumAmountValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHSumAmountValue);

            #endregion

            PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
            pH1.NoWrap = true;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH1);

            PdfPCell pHEmployee = new PdfPCell(new Paragraph("员工", FontColumn));
            pHEmployee.NoWrap = true;
            pHEmployee.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHEmployee);

            PdfPCell pH4 = new PdfPCell(new Paragraph("所属部门", FontColumn));
            pH4.NoWrap = true;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pHAchievement = new PdfPCell(new Paragraph("绩效", FontColumn));
            pHAchievement.NoWrap = true;
            pHAchievement.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pHAchievement);

            decimal arrearageTotal = 0;
            for (int j = 0; j < u.AchievementTempList.Count; j++)
            {
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
                pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcNo);



                PdfPCell pcCusomerName = new PdfPCell(new Paragraph(u.AchievementTempList[j].EmployeeName, FontColumnValue));
                pcCusomerName.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCusomerName);

                PdfPCell pcDepartment = new PdfPCell(new Paragraph(u.AchievementTempList[j].PositionName, FontColumnValue));
                pcDepartment.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcDepartment);

                PdfPCell pcAchievement = new PdfPCell(new Paragraph(NumericUtils.ToMoney(Convert.ToDecimal(u.AchievementTempList[j].AchievementValue)), FontColumnValue));
                pcAchievement.HorizontalAlignment = Element.ALIGN_RIGHT;
                ptb.AddCell(pcAchievement);
                arrearageTotal += Convert.ToDecimal(u.AchievementTempList[j].AchievementValue);

            }

            PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumn));
            pcTotal.NoWrap = true;
            pcTotal.Colspan = 1;
            pcTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcTotal);

            PdfPCell pcArrearageTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(arrearageTotal), FontColumnValue));
            pcArrearageTotal.NoWrap = true;
            pcArrearageTotal.Colspan = 3;
            pcArrearageTotal.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcArrearageTotal);
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
