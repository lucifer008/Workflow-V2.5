using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;

namespace Workflow.Support.Report.Finance
{
    /// <summary>
    /// 名    称: ReportSmallTicket
    /// 功能概要: 收银打印小票
    /// 作    者: 张晓林
    /// 创建时间: 2010年4月1日15:39:42
    /// 修正履历: 
    /// 修正时间: 
    /// 修正描述:
    /// </summary>
    public class ReportSmallTicket : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
    {
        protected const float ROW_HEIGHT = 20F;
        //private bool isDisplayBarCode = false;
        //public bool IsDisplayBarCode
        //{
        //    set { isDisplayBarCode = value; }
        //    get { return isDisplayBarCode; }
        //}
        public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
            if (String.IsNullOrEmpty(this.FileName))
            {
                throw new WorkflowException("报表名称不能为空!");
            }
            FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate);
            fs.Lock(0, fs.Length);
            PdfWriter.GetInstance(doc, fs);
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

            if (null != tHead)
            {
                doc.Add(tHead);
            }
            if (null != tOrderItem)
            {
                doc.Add(tOrderItem);
            }
            ////增加打印条码
            //if (isDisplayBarCode)
            //{
            //    Barcode39 code = new Barcode39();
            //    code.Code = u.NewOrder.No.ToUpper();
            //    code.BarHeight = 50;
            //    System.Drawing.Image b = code.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);

            //    PdfPTable tBmp = this.AddBitmap(b);
            //    if (null != tBmp)
            //    {
            //        doc.Add(tBmp);
            //    }
            //}
            doc.Close();
        }

        public override PdfPTable GetReportHeader(OrderModel u)
        {
            float[] ColumnWidth ={ 15, 15, 15, 20 };

            PdfPTable ptb = new PdfPTable(ColumnWidth);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontHeader));
            pc1.Colspan = 4;
            pc1.Border = 0;
            pc1.FixedHeight = 10;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph(DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
            pc2.HorizontalAlignment = Element.ALIGN_LEFT;
            pc2.Border = 0;
            pc2.Colspan = 4;
            ptb.AddCell(pc2);

            return ptb;
        }
        private PdfPTable GetOrderItem(OrderModel u)
        {
            float[] ColumnWidth ={ 15, 15, 15, 20 };
            PdfPTable ptb = new PdfPTable(ColumnWidth);

            PdfPCell pcMembercardNoC = new PdfPCell(new Paragraph("卡号", FontHeader));
            pcMembercardNoC.Border = 0;
            pcMembercardNoC.FixedHeight = 10;
            ptb.AddCell(pcMembercardNoC);

            PdfPCell pcMembercardNoV = new PdfPCell(new Paragraph(u.NewOrder.MemberCardNo, FontHeader));
            pcMembercardNoV.Border = 0;
            pcMembercardNoV.FixedHeight = 10;
            ptb.AddCell(pcMembercardNoV);

            PdfPCell pcCodeNoC = new PdfPCell(new Paragraph("条码号", FontHeader));
            pcCodeNoC.Border = 0;
            pcCodeNoC.FixedHeight = 10;
            ptb.AddCell(pcCodeNoC);

            PdfPCell pcCodeNoV = new PdfPCell(new Paragraph(u.NewOrder.CodeNo, FontHeader));
            pcCodeNoV.Border = 0;
            pcCodeNoV.FixedHeight = 10;
            ptb.AddCell(pcCodeNoV);

            PdfPCell pc1 = new PdfPCell(new Paragraph("业务类型:", FontHeader));
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;
            pc1.Border = 0;
            pc1.NoWrap = false;
            ptb.AddCell(pc1);

            PdfPCell pc23 = new PdfPCell(new Paragraph("数量", FontHeader));
            pc23.HorizontalAlignment = Element.ALIGN_LEFT;
            pc23.Border = 0;
            pc23.NoWrap = false;
            ptb.AddCell(pc23);

            PdfPCell pc3 = new PdfPCell(new Paragraph("单价", FontHeader));
            pc3.HorizontalAlignment = Element.ALIGN_LEFT;
            pc3.Border = 0;
            ptb.AddCell(pc3);

            PdfPCell pc5 = new PdfPCell(new Paragraph("总价", FontHeader));
            pc5.HorizontalAlignment = Element.ALIGN_LEFT;
            pc5.Border = 0;
            pc5.NoWrap = false;
            ptb.AddCell(pc5);
            foreach(OrderItem oi in u.OrderItemList)
            {
                PdfPCell pcBusinessType = new PdfPCell(new Paragraph(oi.BusinessTypeName,FontHeader));
                pcBusinessType.HorizontalAlignment = Element.ALIGN_LEFT;
                pcBusinessType.Border = 0;
                pcBusinessType.NoWrap = false;
                ptb.AddCell(pcBusinessType);

                PdfPCell pcOrderItemCount = new PdfPCell(new Paragraph(oi.Amount.ToString(), FontHeader));
                pcOrderItemCount.HorizontalAlignment = Element.ALIGN_LEFT;
                pcOrderItemCount.Border = 0;
                pcOrderItemCount.NoWrap = false;
                ptb.AddCell(pcOrderItemCount);

                PdfPCell pcOrderItemPrice = new PdfPCell(new Paragraph(oi.UnitPrice.ToString(), FontHeader));
                pcOrderItemPrice.HorizontalAlignment = Element.ALIGN_LEFT;
                pcOrderItemPrice.Border = 0;
                pcOrderItemPrice.NoWrap = false;
                ptb.AddCell(pcOrderItemPrice);

                PdfPCell pcOrderItemTotal = new PdfPCell(new Paragraph(oi.CashConsumeAmount.ToString(), FontHeader));
                pcOrderItemTotal.HorizontalAlignment = Element.ALIGN_LEFT;
                pcOrderItemTotal.Border = 0;
                pcOrderItemTotal.NoWrap = false;
                ptb.AddCell(pcOrderItemTotal);
            }
            PdfPCell pcAllAmountColumn = new PdfPCell(new Paragraph("合计",FontHeader));
            pcAllAmountColumn.NoWrap = false;
            pcAllAmountColumn.HorizontalAlignment = Element.ALIGN_LEFT;
            pcAllAmountColumn.Border = 0;
            ptb.AddCell(pcAllAmountColumn);

            PdfPCell pcAllAmountValue = new PdfPCell(new Paragraph(u.NewOrder.SumAmount.ToString(), FontHeader));
            pcAllAmountValue.NoWrap = false;
            pcAllAmountValue.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcAllAmountValue.Border = 0;
            pcAllAmountValue.Colspan = 3;
            ptb.AddCell(pcAllAmountValue);

            PdfPCell pcPaidAmountC = new PdfPCell(new Paragraph("实收", FontHeader));
            pcPaidAmountC.NoWrap = false;
            pcPaidAmountC.HorizontalAlignment = Element.ALIGN_LEFT;
            pcPaidAmountC.Border = 0;
            ptb.AddCell(pcPaidAmountC);

            PdfPCell pcPaidAmountV = new PdfPCell(new Paragraph("", FontHeader));
            pcPaidAmountV.NoWrap = false;
            pcPaidAmountV.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcPaidAmountV.Border = 0;
            pcPaidAmountV.Colspan = 3;
            ptb.AddCell(pcPaidAmountV);

            PdfPCell pcProC = new PdfPCell(new Paragraph("优惠", FontHeader));
            pcProC.NoWrap = false;
            pcProC.HorizontalAlignment = Element.ALIGN_LEFT;
            pcProC.Border = 0;
            ptb.AddCell(pcProC);

            PdfPCell pcProV = new PdfPCell(new Paragraph("", FontHeader));
            pcProV.NoWrap = false;
            pcProV.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcProV.Border = 0;
            pcProV.Colspan = 3;
            ptb.AddCell(pcProV);

            PdfPCell pcRandupC = new PdfPCell(new Paragraph("折让", FontHeader));
            pcRandupC.NoWrap = false;
            pcRandupC.HorizontalAlignment = Element.ALIGN_LEFT;
            pcRandupC.Border = 0;
            ptb.AddCell(pcRandupC);

            PdfPCell pcRandupV = new PdfPCell(new Paragraph("", FontHeader));
            pcRandupV.NoWrap = false;
            pcRandupV.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcRandupV.Border = 0;
            pcRandupV.Colspan = 3;
            ptb.AddCell(pcRandupV);


            PdfPCell pcRC = new PdfPCell(new Paragraph("抹零", FontHeader));
            pcRC.NoWrap = false;
            pcRC.HorizontalAlignment = Element.ALIGN_LEFT;
            pcRC.Border = 0;
            ptb.AddCell(pcRC);

            PdfPCell pcRV = new PdfPCell(new Paragraph("", FontHeader));
            pcRV.NoWrap = false;
            pcRV.HorizontalAlignment = Element.ALIGN_RIGHT;
            pcRV.Border = 0;
            pcRV.Colspan = 3;
            ptb.AddCell(pcRV);

            //PdfPCell pcPaidTicketC = new PdfPCell(new Paragraph("开票", FontHeader));
            //pcPaidTicketC.NoWrap = false;
            //pcPaidTicketC.HorizontalAlignment = Element.ALIGN_RIGHT;
            //pcPaidTicketC.Border = 0;
            //ptb.AddCell(pcPaidTicketC);

            //PdfPCell pcPaidTicketV = new PdfPCell(new Paragraph("", FontHeader));
            //pcPaidTicketV.NoWrap = false;
            //pcPaidTicketV.HorizontalAlignment = Element.ALIGN_RIGHT;
            //pcPaidTicketV.Border = 0;
            //pcPaidTicketV.Colspan = 3;
            //ptb.AddCell(pcPaidTicketV);

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
        public PdfPTable AddBitmap(System.Drawing.Image b)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(b, System.Drawing.Imaging.ImageFormat.Bmp);

            float[] widths ={ 200, 150, 80 };
            PdfPTable ptb = new PdfPTable(widths);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));
            PdfPCell pc2 = new PdfPCell(new Paragraph("", FontBase));
            PdfPCell pc3 = new PdfPCell(image, true);
            pc1.Border = 0;
            pc2.Border = 0;
            pc3.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            ptb.AddCell(pc3);
            return ptb;
        }
    }
}
