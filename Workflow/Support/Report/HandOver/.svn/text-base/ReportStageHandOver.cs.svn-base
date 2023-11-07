using System;
using System.IO;
using Workflow.Util;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Da.Domain;
using iTextSharp.text.pdf;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;
namespace Workflow.Support.Report.HandOver
{
    /// <summary>
    /// 名    称: ReportStageHandOver
    /// 功能概要: 前台交班 报表
    /// 作    者: 张晓林
    /// 创建时间: 2009年3月20日18:41:08
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportStageHandOver : ReportBase<iTextSharp.text.pdf.PdfPTable, StageHandOverModel>
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

        public override void CreateReport(StageHandOverModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
        public override PdfPTable GetReportHeader(StageHandOverModel u)
        {
            PdfPTable ptb = new PdfPTable(8);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
            pc1.HorizontalAlignment = 2;
            pc1.Border = 0;
            pc1.FixedHeight = 30;
            pc1.Colspan = 8;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = 2;
            pc2.Border = 0;
            pc2.Colspan = 8;
            ptb.AddCell(pc2);

            return ptb;
        }
        private PdfPTable GetOrderItem(StageHandOverModel u)
        {

            ///定义列标题
            ///
            float[] ColumnWidth ={ 20, 20,30,20,20,20,20,30 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcHandOverDate = new PdfPCell(new Paragraph("交接日期", FontColumn));
            pcHandOverDate.NoWrap = false;
            pcHandOverDate.HorizontalAlignment = Element.ALIGN_CENTER;
            pcHandOverDate.Colspan = 2;
            ptb.AddCell(pcHandOverDate);

            PdfPCell pcHandOverDateValue = new PdfPCell(new Paragraph(u.HandOver.InsertDateTime.ToShortDateString(),FontColumnValue));
            pcHandOverDateValue.NoWrap = true;
            pcHandOverDateValue.HorizontalAlignment = Element.ALIGN_CENTER;
            pcHandOverDateValue.Colspan = 3;
            ptb.AddCell(pcHandOverDateValue);

            PdfPCell pcHandOverDateTime = new PdfPCell(new Paragraph("时间:", FontColumn));
            pcHandOverDateTime.NoWrap = true;
            pcHandOverDateTime.Colspan = 1;
            pcHandOverDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDateTime);

            PdfPCell pcHandOverDateTimeValue = new PdfPCell(new Paragraph(u.HandOver.HandOverDateTime.ToString("HH:mm"), FontColumnValue));
            pcHandOverDateTimeValue.NoWrap = true;
            pcHandOverDateTimeValue.Colspan = 2;
            pcHandOverDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverDateTimeValue);


            PdfPCell pcHandOverPeople = new PdfPCell(new Paragraph("交班人签字", FontColumn));
            pcHandOverPeople.NoWrap = false;
            pcHandOverPeople.Colspan = 2;
            pcHandOverPeople.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcHandOverPeople);

            PdfPCell pcHandOverPeopleValue = new PdfPCell(new Paragraph(u.HandOver.Employee.Name, FontColumnValue));
            pcHandOverPeopleValue.NoWrap = true;
            pcHandOverPeopleValue.HorizontalAlignment = Element.ALIGN_CENTER;
            pcHandOverPeopleValue.Colspan = 3;
            ptb.AddCell(pcHandOverPeopleValue);

            PdfPCell pcSuccessor = new PdfPCell(new Paragraph("接班人签字:", FontColumn));
            pcSuccessor.NoWrap = false;
            pcSuccessor.Colspan = 1;
            pcSuccessor.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcSuccessor);

            PdfPCell pcSuccessorValue = new PdfPCell(new Paragraph(u.HandOver.OtherEmployee.Name, FontColumnValue));
            pcSuccessorValue.NoWrap = true;
            pcSuccessorValue.Colspan = 2;
            pcSuccessorValue.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcSuccessorValue);

            PdfPCell pcNewMemberCard = new PdfPCell(new Paragraph("新办会员卡", FontColumn));
            pcNewMemberCard.NoWrap = false;
            pcNewMemberCard.Colspan = 2;
            pcNewMemberCard.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcNewMemberCard);

            PdfPCell pcNewMemberCardValue = new PdfPCell(new Paragraph(u.StrMemberCardList, FontColumnValue));
            pcNewMemberCardValue.NoWrap = false;
            pcNewMemberCardValue.Colspan = 6;
            pcNewMemberCardValue.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcNewMemberCardValue);

            Paragraph pp ;
            if (0==u.OrderList.Count || 1==u.OrderList.Count)
            {
                pp = new Paragraph("已转单", FontColumn);
            }
            else 
            {
                pp = new Paragraph("", FontColumn);
            }
            PdfPCell pcDeliverCo = new PdfPCell(pp);
            pcDeliverCo.NoWrap = true;
            pcDeliverCo.DisableBorderSide(2);
            pcDeliverCo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcDeliverCo);


            PdfPCell pcOrdersNo = new PdfPCell(new Paragraph("订单号", FontColumn));
            pcOrdersNo.NoWrap = true;
            pcOrdersNo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOrdersNo);

            PdfPCell pcCustomerName = new PdfPCell(new Paragraph("客户名称", FontColumn));
            pcCustomerName.NoWrap = false;
            pcCustomerName.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcCustomerName);

            PdfPCell pcOrdersStatus = new PdfPCell(new Paragraph("订单状态", FontColumn));
            pcOrdersStatus.NoWrap = true;
            pcOrdersStatus.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOrdersStatus);

            PdfPCell pcOrdersInsertDate = new PdfPCell(new Paragraph("开单时间", FontColumn));
            pcOrdersInsertDate.NoWrap = false;
            pcOrdersInsertDate.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOrdersInsertDate);

            PdfPCell pcDeliveryType = new PdfPCell(new Paragraph("取送方式", FontColumn));
            pcDeliveryType.NoWrap = true;
            pcDeliveryType.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcDeliveryType);

            PdfPCell pcDeliveryDate = new PdfPCell(new Paragraph("送货时间", FontColumn));
            pcDeliveryDate.NoWrap = false;
            pcDeliveryDate.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcDeliveryDate);

            PdfPCell pcMemo = new PdfPCell(new Paragraph("备注", FontColumn));
            pcMemo.NoWrap = false;
            pcMemo.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcMemo);

            int index = 1;
            int count2 =0;
            count2 = u.OrderList.Count / 2;
            foreach (Order order in u.OrderList)
            {
                string strDeliver = "";
                if(count2==index)
                {
                    strDeliver = "已转单";
                }
                PdfPCell pcProcessesOrder = new PdfPCell(new Paragraph(strDeliver, FontColumnValue));
                pcProcessesOrder.NoWrap = true;
                pcProcessesOrder.HorizontalAlignment = Element.ALIGN_CENTER;

                if (index > 1)
                {
                    if (index == u.OrderList.Count)
                    {
                        pcProcessesOrder.DisableBorderSide(1);
                    }
                    else
                    {
                        pcProcessesOrder.DisableBorderSide(1);
                        pcProcessesOrder.DisableBorderSide(2);
                    }
                }
                else 
                {
                    pcProcessesOrder.DisableBorderSide(1);
                    pcProcessesOrder.DisableBorderSide(2);
                }
                ptb.AddCell(pcProcessesOrder);

                PdfPCell pcOrderNoValue = new PdfPCell(new Paragraph(order.No, FontColumnValue));
                pcOrderNoValue.NoWrap = true;
                pcOrderNoValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderNoValue);

                PdfPCell pcCustomerNameValue = new PdfPCell(new Paragraph(order.CustomerName, FontColumn));
                pcCustomerNameValue.NoWrap = false;
                pcCustomerNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcCustomerNameValue);


                PdfPCell pcOrderStatusValue = new PdfPCell(new Paragraph(Constants.GetOrderStatus(order.Status), FontColumnValue));
                pcOrderStatusValue.NoWrap = true;
                pcOrderStatusValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderStatusValue);

                PdfPCell pcOrderInsertDateTimeValue = new PdfPCell(new Paragraph(order.InsertDateTime.ToString("yyyy-MM-dd HH:mm"), FontColumnValue));
                pcOrderInsertDateTimeValue.NoWrap = false;
                pcOrderInsertDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcOrderInsertDateTimeValue);

                PdfPCell pcDeliveryTypeValue = new PdfPCell(new Paragraph(Constants.GetDeliveryType(order.DeliveryType), FontColumnValue));
                pcDeliveryTypeValue.NoWrap = true;
                pcDeliveryTypeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcDeliveryTypeValue);

                string strDeliveryDate = "";
                if (null != order.DeliveryDateTime && "9999-12-31" != order.DeliveryDateTime.ToString("yyyy-MM-dd"))
                {
                    strDeliveryDate =order.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                }

                PdfPCell pcDeliveryDateTimeValue = new PdfPCell(new Paragraph(strDeliveryDate, FontColumnValue));
                pcDeliveryDateTimeValue.NoWrap = false;
                pcDeliveryDateTimeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcDeliveryDateTimeValue);

                PdfPCell pcMemoValue = new PdfPCell(new Paragraph(order.Memo, FontColumnValue));
                pcMemoValue.NoWrap = false;
                pcMemoValue.HorizontalAlignment = Element.ALIGN_CENTER;
                ptb.AddCell(pcMemoValue);

                index++;
            }

            PdfPCell pcOther = new PdfPCell(new Paragraph("其他",FontColumn));
            pcOther.NoWrap = false;
            pcOther.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pcOther);

            PdfPCell pcOtherValue = new PdfPCell(new Paragraph(u.HandOver.Memo, FontColumnValue));
            pcOtherValue.NoWrap = false;
            pcOtherValue.Colspan = 7;
            pcOtherValue.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcOtherValue);
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
        public override PdfPTable GetReportFooter(StageHandOverModel u)
        {
            return null;
        }
        public override PdfPTable GetReportObject(StageHandOverModel u)
        {
            return null;
        }
        public override PdfPTable GetReportContent(StageHandOverModel u)
        {
            return null;
        }
    }
}
