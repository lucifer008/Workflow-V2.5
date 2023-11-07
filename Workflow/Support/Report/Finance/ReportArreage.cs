using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Support.Report.Base;
using Workflow.Action.Finance.Model;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Workflow.Support.Report.Finance
{
    public class ReportData
    {
        private decimal shouldPay;
        public decimal ShouldPay
        {
            set { shouldPay = value; }
            get { return shouldPay; }
        }

        private decimal concession;
        public decimal Concession
        {
            set { concession = value; ; }
            get { return concession; }
        }

        private decimal payMoney;
        public decimal PayMoney
        {
            set { payMoney = value; }
            get { return payMoney; }
        }

        private string customerName;
        public string CustomerName
        {
            set { customerName = value; }
            get { return customerName; }
        }
    }

    /// <summary>
    /// 名    称：ReportArreage
    /// 功能概要: 应收款处理报表
    /// 作    者:
    /// 创建时间:
    /// 修正履历：
    /// 修正时间:
    /// </summary>
    public class ReportArreage : ReportBase<iTextSharp.text.pdf.PdfPTable, FinanceModel>
    {
        protected const float ROW_HEIGHT = 22F;
        public ReportData rData=new ReportData();
        static BaseFont bf = BaseFont.CreateFont(@"c:\WINDOWS\fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        static Font cFont = new Font(bf, 9);
        //static Font bFont = new Font(bf, 10, Font.BOLD);

        public override iTextSharp.text.pdf.PdfPTable GetReportHeader(FinanceModel u)
        {
            PdfPTable ptb = new PdfPTable(2);
            PdfPCell pc1 = new PdfPCell(new Paragraph(new Paragraph("" , FontBase)));
            pc1.HorizontalAlignment = 0;
            pc1.FixedHeight = 40F;
            pc1.Border = 0;
            PdfPCell pc2 = new PdfPCell(new Paragraph(new Paragraph("", FontBase)));
            pc2.HorizontalAlignment = 0;
            pc2.FixedHeight = 40F;
            pc2.Border = 0;

            PdfPCell pc3 = new PdfPCell(new Paragraph(new Paragraph("", FontBase)));
            pc3.HorizontalAlignment = 0;
            pc3.FixedHeight = 20F;
            pc3.Border = 0;
            PdfPCell pc4 = new PdfPCell(new Paragraph(new Paragraph("打印日期:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), FontBase)));
            pc4.HorizontalAlignment = 2;
            pc4.FixedHeight = 20F;
            pc4.Border = 0;

            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            ptb.AddCell(pc3);
            ptb.AddCell(pc4);

            return ptb;
        }

        public override iTextSharp.text.pdf.PdfPTable GetReportContent(FinanceModel u)
        {
            float[] nWidth ={ 60, 500 };
            PdfPTable ptb = new PdfPTable(nWidth);
            PdfPCell pc11 = new PdfPCell(new Paragraph("客户名称:", cFont));
            pc11.HorizontalAlignment = 0;
            pc11.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc11);
            PdfPCell pc12 = new PdfPCell(new Paragraph(this.rData.CustomerName, cFont));
            pc12.HorizontalAlignment = 0;
            pc12.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc12);
            PdfPCell pc21 = new PdfPCell(new Paragraph("应付:", cFont));
            pc21.HorizontalAlignment = 0;
            pc21.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc21);
            PdfPCell pc22 = new PdfPCell(new Paragraph(this.rData.ShouldPay.ToString("C"), cFont));
            pc22.HorizontalAlignment=0;
            pc22.FixedHeight=ROW_HEIGHT;
            ptb.AddCell(pc22);

            PdfPCell pc31 = new PdfPCell(new Paragraph("本次折让:", cFont));
            pc31.HorizontalAlignment=0;
            pc31.FixedHeight=ROW_HEIGHT;
            ptb.AddCell(pc31);
            PdfPCell pc32 = new PdfPCell(new Paragraph(this.rData.Concession.ToString("C"), cFont));
            pc32.HorizontalAlignment = 0;
            pc32.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc32);

            PdfPCell pc41 = new PdfPCell(new Paragraph("本次支付:", cFont));
            pc41.HorizontalAlignment = 0;
            pc41.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc41);
            PdfPCell pc42 = new PdfPCell(new Paragraph((this.rData.PayMoney-this.rData.Concession).ToString("C"), cFont));
            pc42.HorizontalAlignment = 0;
            pc42.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc42);

            PdfPCell pc51 = new PdfPCell(new Paragraph("还欠:", cFont));
            pc51.HorizontalAlignment = 0;
            pc51.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc51);
            PdfPCell pc52 = new PdfPCell(new Paragraph((this.rData.ShouldPay - this.rData.PayMoney).ToString("C"), cFont));
            pc52.HorizontalAlignment = 0;
            pc52.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc52);
            return ptb;
        }

        public override iTextSharp.text.pdf.PdfPTable GetReportFooter(FinanceModel u)
        {
            PdfPTable ptb = new PdfPTable(2);
            return ptb;
        }

        public override iTextSharp.text.pdf.PdfPTable GetReportObject(FinanceModel u)
        {
            float[] nWidth ={ 20, 40, 80, 80, 50, 50, 50, 50, 50, 50, 50 };

            PdfPTable ptb = new PdfPTable(nWidth);
            PdfPCell pcNo = new PdfPCell(new Paragraph("No", cFont));
            pcNo.HorizontalAlignment = 1;
            pcNo.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcNo);

            PdfPCell pcOrderNo = new PdfPCell(new Paragraph("订单号", cFont));
            pcOrderNo.HorizontalAlignment = 1;
            pcOrderNo.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcOrderNo);

            PdfPCell pcNewTime = new PdfPCell(new Paragraph("开单时间", cFont));
            pcNewTime.HorizontalAlignment = 1;
            pcNewTime.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcNewTime);

            PdfPCell pcCloseTime = new PdfPCell(new Paragraph("结算时间", cFont));
            pcCloseTime.HorizontalAlignment = 1;
            pcCloseTime.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcCloseTime);

            PdfPCell pcTotalMoney = new PdfPCell(new Paragraph("总额", cFont));
            pcTotalMoney.HorizontalAlignment = 1;
            pcTotalMoney.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcTotalMoney);

            PdfPCell pcConcession = new PdfPCell(new Paragraph("优惠金额", cFont));
            pcConcession.HorizontalAlignment = 1;
            pcConcession.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcConcession);

            PdfPCell pcZeroMoney = new PdfPCell(new Paragraph("抹零金额", cFont));
            pcZeroMoney.HorizontalAlignment = 1;
            pcZeroMoney.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcZeroMoney);

            PdfPCell pcRender = new PdfPCell(new Paragraph("折让金额", cFont));
            pcRender.HorizontalAlignment = 1;
            pcRender.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcRender);

            PdfPCell pcPaid = new PdfPCell(new Paragraph("已付款额", cFont));
            pcPaid.HorizontalAlignment = 1;
            pcPaid.FixedHeight=ROW_HEIGHT;
            ptb.AddCell(pcPaid);

            PdfPCell pcArreage = new PdfPCell(new Paragraph("应收款额", cFont));
            pcArreage.HorizontalAlignment = 1;
            pcArreage.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcArreage);

            PdfPCell pcCurrent = new PdfPCell(new Paragraph("本次结欠", cFont));
            pcCurrent.HorizontalAlignment = 1;
            pcCurrent.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcCurrent);


            for (int i = 0; i < u.OrderList.Count; i++)
            {
                if (!u.OrderList[i].Selected)
                    continue;
                PdfPCell p1 = new PdfPCell(new Paragraph(i.ToString(), cFont));
                p1.HorizontalAlignment = 1;
                p1.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p1);

                PdfPCell p2 = new PdfPCell(new Paragraph(u.OrderList[i].No, cFont));
                p2.HorizontalAlignment = 1;
                p2.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p2);

                PdfPCell p3 = new PdfPCell(new Paragraph(u.OrderList[i].InserDateTimeStrings, cFont));
                p3.HorizontalAlignment = 1;
                p3.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p3);

                PdfPCell p4 = new PdfPCell(new Paragraph(u.OrderList[i].BalanceDateTime.ToString("yyyy-MM-dd HH:mm:ss") , cFont));
                p4.HorizontalAlignment = 1;
                p4.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p4);

                PdfPCell p5 = new PdfPCell(new Paragraph(u.OrderList[i].SumAmount.ToString(), cFont));
                p5.HorizontalAlignment = 1;
                p5.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p5);

                PdfPCell p6 = new PdfPCell(new Paragraph(u.OrderList[i].Concession.ToString(), cFont));
                p6.HorizontalAlignment = 1;
                p6.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p6);

                PdfPCell p7 = new PdfPCell(new Paragraph(u.OrderList[i].Zero.ToString(), cFont));
                p7.HorizontalAlignment = 1;
                p7.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p7);

                PdfPCell p8 = new PdfPCell(new Paragraph(u.OrderList[i].RenderUp.ToString(), cFont));
                p8.HorizontalAlignment = 1;
                p8.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p8);

                PdfPCell p9 = new PdfPCell(new Paragraph(u.OrderList[i].PaidAmount.ToString(), cFont));
                p9.HorizontalAlignment = 1;
                p9.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p9);

                decimal x=0;
                x = u.OrderList[i].SumAmount-u.OrderList[i].PaidAmount - u.OrderList[i].Zero - u.OrderList[i].Concession - u.OrderList[i].RenderUp;

                PdfPCell p10 = new PdfPCell(new Paragraph(x.ToString(), cFont));
                p10.HorizontalAlignment = 1;
                p10.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p10);

                PdfPCell p11 = new PdfPCell(new Paragraph(u.OrderList[i].CurrentMoney.ToString(), cFont));
                p11.HorizontalAlignment = 1;
                p11.FixedHeight = ROW_HEIGHT;
                ptb.AddCell(p11);
            }
            PdfPCell pcIsTicketColumn = new PdfPCell(new Paragraph("是否要票", cFont));
            pcIsTicketColumn.HorizontalAlignment = Element.CREATOR;
            pcIsTicketColumn.NoWrap = true;
            pcIsTicketColumn.FixedHeight = ROW_HEIGHT;
            pcIsTicketColumn.Colspan = 2;
            ptb.AddCell(pcIsTicketColumn);

            string sText = "要";
            if (!u.IsAccounting) sText = "不要";
            PdfPCell pcIsTicketColumnValue = new PdfPCell(new Paragraph(sText, cFont));
            pcIsTicketColumnValue.HorizontalAlignment = Element.ALIGN_LEFT;
            pcIsTicketColumnValue.FixedHeight = ROW_HEIGHT;
            if (!u.IsAccounting) pcIsTicketColumnValue.Colspan = 9;
            else pcIsTicketColumnValue.Colspan = 4;
            ptb.AddCell(pcIsTicketColumnValue);

            if (u.IsAccounting)
            {
                PdfPCell pcTicketColumn = new PdfPCell(new Paragraph("发票金额", cFont));
                pcTicketColumn.HorizontalAlignment = Element.ALIGN_CENTER;
                pcTicketColumn.FixedHeight = ROW_HEIGHT;
                pcTicketColumn.Colspan = 2;
                ptb.AddCell(pcTicketColumn);

                PdfPCell pcTicketColumnValue = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.PaidAmount), cFont));
                pcTicketColumnValue.HorizontalAlignment = Element.ALIGN_LEFT;
                pcTicketColumnValue.FixedHeight = ROW_HEIGHT;
                pcTicketColumnValue.Colspan = 3;
                ptb.AddCell(pcTicketColumnValue);
            }
            return ptb;
        }
    }
}
