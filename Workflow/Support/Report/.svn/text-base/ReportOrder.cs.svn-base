using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Report.Base;
using Workflow.Da.Domain;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Support.Exception;
using System.IO;
using Workflow.Action.Model;
using System.Collections;
using Workflow.Util;


namespace Workflow.Support.Report
{
    /// <summary>
    /// 名    称: 开单报表
    /// 功能概要: 
    /// 作    者: 付强
    /// 创建时间: 2008-11-18
    /// 修正履历: 张晓林
    /// 修正时间: 2009年2月19日16:05:51
    /// 修正描述:调整打印样式，适应套打功能
    /// </summary>
    public class ReportOrder : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
    {
        protected const float ROW_HEIGHT = 20F;
        private bool isDisplayBarCode = false;
        public bool IsDisplayBarCode 
        {
            set { isDisplayBarCode = value; }
            get { return isDisplayBarCode; }
        }
        private bool isDisplayOrderItemEdmit;
        public bool IsDisplayOrderItemEdmit
        {
            set { isDisplayOrderItemEdmit = value; }
            get { return isDisplayOrderItemEdmit; }
        }
        public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            Document doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
            if (String.IsNullOrEmpty(this.FileName))
            {
                throw new WorkflowException("报表名称不能为空!");
            }
            FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate);
            //fs.Lock(0, fs.Length);
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
            PdfPTable tContent = this.GetReportContent(u);
            PdfPTable tOrderItem = this.GetOrderItem(u);
            PdfPTable tCustomerInfo = this.GetOrderCustomerInfo(u);
            PdfPTable tFooter = this.GetReportFooter(u);

            //PdfPTable tObject = this.GetReportObject(u);
            //if (null != tObject)
            //{
            //    doc.Add(tObject);
            //}
            if (null != tHead)
            {
                doc.Add(tHead);
            }
            if (null != tContent)
            {
                doc.Add(tContent);
            }
            if (null != tOrderItem)
            {
                doc.Add(tOrderItem);
            }
            if (null != tCustomerInfo)
            {
                doc.Add(tCustomerInfo);
            }
            if (null != tFooter)
            {
                doc.Add(tFooter);
            }
            //增加打印条码
            if (isDisplayBarCode)
            {
                Barcode39 code=new Barcode39();
                code.Code=u.NewOrder.No.ToUpper();
                code.BarHeight=50;
                System.Drawing.Image b = code.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);

                
                PdfPTable tBmp = this.AddBitmap(b);
                if (null != tBmp)
                {
                    doc.Add(tBmp);
                }
            }
            //fs.Unlock(0, fs.Length);
            doc.Close();
        }
        public override PdfPTable GetReportHeader(OrderModel u)
        {
            PdfPTable ptb = new PdfPTable(2);
            PdfPCell pc1 = new PdfPCell(new Paragraph(new Paragraph("" + u.NewOrder.No, FontBase)));//new Paragraph(new Paragraph("No:" + u.NewOrder.No,FontBase)));
            pc1.HorizontalAlignment = 0;
            pc1.FixedHeight = 16F;//ROW_HEIGHT;//30F比较合适
            pc1.Border = 0;
            PdfPCell pc2 = new PdfPCell(new Paragraph(u.NewOrder.InsertDateTime.ToString(), FontBase));
            pc2.HorizontalAlignment = Element.ALIGN_RIGHT;
            pc2.FixedHeight = 18F;//ROW_HEIGHT;
            pc2.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            return ptb;

        }
        public override PdfPTable GetReportContent(OrderModel u)
        {
            float[] widths ={ 50, 200, 50, 200 };
            PdfPTable ptb = new PdfPTable(widths);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("会员卡号:",FontBase));
            pc1.Border = 0;
            
            pc1.NoWrap = true;
            pc1.HorizontalAlignment = 0;
            pc1.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph(u.NewOrder.MemberCardNo, FontBase));
            pc2.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc2.Colspan = 3;
            pc2.FixedHeight = ROW_HEIGHT;
            pc2.Border = 0;
            ptb.AddCell(pc2);

            PdfPCell pc21 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("客户名称:", FontBase));
            pc21.Border = 0;
            pc21.NoWrap = true;
            pc21.HorizontalAlignment = 0;
            pc21.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc21);

            PdfPCell pc22 = new PdfPCell(new Paragraph(u.NewOrder.CustomerName, FontBase));
            pc22.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc22.FixedHeight = ROW_HEIGHT;
            pc22.Border = 0;
            ptb.AddCell(pc22);

            PdfPCell pc23 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("联系人:", FontBase));
            pc23.Border = 0;
            pc23.HorizontalAlignment = 0;
            pc23.FixedHeight = ROW_HEIGHT;
            pc23.NoWrap = true;
            ptb.AddCell(pc23);

            PdfPCell pc24 = new PdfPCell(new Paragraph(u.NewOrder.LinkManName, FontBase));
            pc24.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc24.FixedHeight = ROW_HEIGHT;
            pc24.Border = 0;
            ptb.AddCell(pc24);

            PdfPCell pc31 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("联系电话:", FontBase));
            pc31.Border = 0;
            pc31.NoWrap = true;
            pc31.FixedHeight = ROW_HEIGHT;
            pc31.HorizontalAlignment = 0;
            pc31.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc31);

            PdfPCell pc32 = new PdfPCell(new Paragraph(u.NewOrder.LastTelNo, FontBase));
            pc32.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc32.FixedHeight = ROW_HEIGHT;
            pc32.Border = 0;
            ptb.AddCell(pc32);

            PdfPCell pc33 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("项目名称:", FontBase));
            pc33.Border = 0;
            pc33.NoWrap = true;
            pc33.FixedHeight = ROW_HEIGHT;
            pc33.HorizontalAlignment = 0;
            ptb.AddCell(pc33);

            PdfPCell pc34 = new PdfPCell(new Paragraph(u.NewOrder.ProjectName, FontBase));
            pc34.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc34.Border = 0;
            pc34.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc34);

            PdfPCell pc41 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("送货方式:", FontBase));
            pc41.Border = 0;
            pc41.NoWrap = true;
            pc41.HorizontalAlignment = 0;
            pc41.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc41);

            string strTmp = "";
            switch (u.NewOrder.DeliveryType)
            {
                case Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE:
                    strTmp = Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_LABEL;
                    break;
                case Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_VALUE:
                    strTmp = Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_LABEL;
                    break;
                case Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE:
                    strTmp = Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL;
                    break;
            }
            PdfPCell pc42 = new PdfPCell(new Paragraph(strTmp, FontBase));
            pc42.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc42.Border = 0;
            pc42.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc42);

            PdfPCell pc43 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("送取货时间:", FontBase));
            pc43.Border = 0;
            pc43.NoWrap = true;
            pc43.HorizontalAlignment = 0;
            pc43.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc43);

            PdfPCell pc44;
            if (u.NewOrder.DeliveryType != Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE)
            {
                string strDateTime = u.NewOrder.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                if (u.NewOrder.DeliveryDateTime.Equals(Constants.NULL_DATE_TIME))
                {
                    strDateTime = "";
                }
                pc44 = new PdfPCell(new Paragraph(strDateTime, FontBase));
            }
            else
            {
                pc44 = new PdfPCell(new Paragraph("", FontBase));
            }
            pc44.HorizontalAlignment = 1;//Element.ALIGN_BOTTOM;
            pc44.Border = 0;
            ptb.AddCell(pc44);

            //PdfPCell pc51 = new PdfPCell(new Paragraph("支付方式:", FontBase));
            //pc51.NoWrap = true;
            //pc51.HorizontalAlignment = 0;
            //pc51.FixedHeight = ROW_HEIGHT;
            //ptb.AddCell(pc51);
            //switch (u.NewOrder.PayType)
            //{
            //    case Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE:
            //        strTmp = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL;
            //        break;
            //    case Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE:
            //        strTmp = Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_LABEL;
            //        break;
            //}
            //PdfPCell pc52 = new PdfPCell(new Paragraph(strTmp, FontBase));
            //pc52.HorizontalAlignment = 0;
            //ptb.AddCell(pc52);
            //PdfPCell pc53 = new PdfPCell(new Paragraph("发票:", FontBase));
            //pc53.NoWrap = true;
            //pc53.HorizontalAlignment = 0;
            //ptb.AddCell(pc53);
            //if ("Y" == u.NewOrder.NeedTicket)
            //{
            //    strTmp = "需要";
            //}
            //else
            //{ 
            //    strTmp = "不需要"; 
            //}
            //PdfPCell pc54 = new PdfPCell(new Paragraph(strTmp, FontBase));
            //pc54.HorizontalAlignment = 0;
            //ptb.AddCell(pc54);

            PdfPCell pc61 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("预收金额:", FontBase));
            pc61.Border = 0;
            pc61.NoWrap = true;
            pc61.HorizontalAlignment = 0;
            pc61.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc61);

            PdfPCell pc62 = new PdfPCell(new Paragraph(u.NewOrder.PrepareMoneyAmount.ToString("C"), FontBase));
            pc62.HorizontalAlignment = 1;
            pc62.FixedHeight = ROW_HEIGHT;
            pc62.Colspan = 3;
            pc62.Border = 0;
            ptb.AddCell(pc62);

            PdfPCell pc71 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("备注:", FontBase));
            pc71.Border = 0;
            pc71.NoWrap = true;
            pc71.FixedHeight = ROW_HEIGHT * 2;
            pc71.HorizontalAlignment = 0;
            ptb.AddCell(pc71);

            PdfPCell pc72 = new PdfPCell(new Paragraph(u.NewOrder.Memo, FontBase));
            pc72.HorizontalAlignment = 1;
            pc72.Border = 0;
            pc72.FixedHeight = ROW_HEIGHT * 2;
            pc72.Colspan = 3;
            ptb.AddCell(pc72);

            return ptb;
        }
        private PdfPTable GetOrderCustomerInfo(OrderModel u)
        {
            string strTemp = "";
            PdfPTable ptb = new PdfPTable(6);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("客户许可\r\n确认签字", FontBase));
            pc1.Border = 0;
            pc1.HorizontalAlignment = Element.ALIGN_LEFT;
            pc1.FixedHeight = ROW_HEIGHT * 2;
            ptb.AddCell(pc1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("1.以上印制及制作要求我已完全审阅并理解，现同意制作。\r\n2.样稿已确认照此印刷.", FontBase));
            pc2.Border = 0;
            pc2.Colspan = 4;
            pc2.FixedHeight = ROW_HEIGHT * 2;
            pc2.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc2);

            PdfPCell pc3 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("客户\r\n签字:", FontBase));
            pc3.Border = 0;
            pc3.FixedHeight = ROW_HEIGHT * 2;
            pc3.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc3);


            PdfPCell pc51 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("支付方式:", FontBase));
            pc51.Border = 0;
            pc51.NoWrap = true;
            pc51.HorizontalAlignment = 0;
            pc51.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc51);
            switch (u.NewOrder.PayType)
            {
                case Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE:
                    strTemp = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL;
                    break;
                case Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE:
                    strTemp = Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_LABEL;
                    break;
            }
            PdfPCell pc52 = new PdfPCell(new Paragraph(strTemp, FontBase));
            pc52.HorizontalAlignment = Element.ALIGN_CENTER;
            pc52.Border = 0;
            pc52.FixedHeight = ROW_HEIGHT;// ROW_HEIGHT;2009年2月21日16:14:26
            ptb.AddCell(pc52);

            strTemp = "";
            if ("Y" == u.NewOrder.NeedTicket)
            {
                strTemp = u.NewOrder.PaidTicketAmount.ToString();
                if(0<u.NewOrder.NotPayTicketAmount)
                {
                    strTemp += " 欠票:" + u.NewOrder.NotPayTicketAmount.ToString();
                }
            }
            else
            {
                strTemp = "不需要";
            }
            PdfPCell pc54 = new PdfPCell(new Paragraph(strTemp, FontBase));
            pc54.HorizontalAlignment = Element.ALIGN_CENTER;
            pc54.FixedHeight = ROW_HEIGHT;
            //pc54.Width = 20F;
            pc54.NoWrap = false;
            pc54.Border = 0;
            pc54.Colspan = 2;
            ptb.AddCell(pc54);

            PdfPCell pcSign = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("客户签收", FontBase));
            pcSign.Border = 0;
            pcSign.Border = 0;
            pcSign.HorizontalAlignment = Element.ALIGN_LEFT;
            pcSign.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcSign);

            PdfPCell pcWrite = new PdfPCell(new Paragraph("", FontBase));
            pcWrite.HorizontalAlignment = Element.ALIGN_LEFT;
            pcWrite.Border = 0;
            pcWrite.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pcWrite);


            PdfPCell pc21 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("开单:", FontBase));
            pc21.Border = 0;
            pc21.HorizontalAlignment = Element.ALIGN_LEFT;
            pc21.FixedHeight = ROW_HEIGHT;

            ptb.AddCell(pc21);
            strTemp = "";
            foreach (User user in u.UserList)
            {
                if (u.NewOrder.NewOrderUserId == user.Id)
                {
                    strTemp = user.Employee.Name;
                    break;
                }
            }

            PdfPCell pc22 = new PdfPCell(new Paragraph(strTemp, FontBase));
            pc22.HorizontalAlignment = Element.ALIGN_CENTER;
            pc22.Border = 0;
            pc22.FixedHeight = ROW_HEIGHT;//ROW_HEIGHT;2009年2月21日16:15:22
            ptb.AddCell(pc22);

            PdfPCell pc23 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("收银:", FontBase));
            pc23.Border = 0;
            pc23.FixedHeight = ROW_HEIGHT;
            pc23.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc23);

            strTemp = "";

            foreach (User user in u.UserList)
            {
                if (u.NewOrder.CashUserId == user.Id && u.NewOrder.Status == Constants.ORDER_STATUS_SUCCESSED_VALUE)
                {
                    strTemp = user.Employee.Name;
                    break;
                }
            }

            PdfPCell pc24 = new PdfPCell(new Paragraph(strTemp, FontBase));
            pc24.HorizontalAlignment = Element.ALIGN_CENTER;
            pc24.Border = 0;
            pc24.FixedHeight = ROW_HEIGHT;
            ptb.AddCell(pc24);

            PdfPCell pc25 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("主管:", FontBase));
            pc25.Border = 0;
            pc25.FixedHeight = ROW_HEIGHT;
            pc25.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc25);

            PdfPCell pc26 = new PdfPCell(new Paragraph("", FontBase));
            pc26.HorizontalAlignment = Element.ALIGN_LEFT;
            pc26.Border = 0;
            pc26.FixedHeight = 2 * ROW_HEIGHT;
            pc26.NoWrap = true;
            ptb.AddCell(pc26);

            PdfPCell pc31 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("前期:", FontBase));
            pc31.Border = 0;
            pc31.HorizontalAlignment = Element.ALIGN_LEFT;
            pc31.FixedHeight = 2 * ROW_HEIGHT;
            pc31.NoWrap = true;
            ptb.AddCell(pc31);

            StringBuilder sb = new StringBuilder();
            if (u.OrderItemEmployee != null)
            {
                foreach (OrderItemEmployee oie in u.OrderItemEmployee)
                {
                    if (oie.PositionId == Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                    {
                        sb.Append(oie.Name);
                        sb.Append(" ");
                    }
                }
            }
            if ("" == sb.ToString()) 
            {
                sb.Append(u.NewOrder.ReceptionEmployee);
            }
            PdfPCell pc32 = new PdfPCell(new Paragraph(sb.ToString(), FontBase));
            pc32.HorizontalAlignment = Element.ALIGN_CENTER;
            pc32.FixedHeight = 2*ROW_HEIGHT;
            pc32.Border = 0;
            pc32.NoWrap=true;
            ptb.AddCell(pc32);

            PdfPCell pc33 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("后期:", FontBase));
            pc33.Border = 0;
            pc33.HorizontalAlignment = Element.ALIGN_LEFT;
            pc33.FixedHeight = 2 * ROW_HEIGHT;
            pc33.NoWrap = true;
            ptb.AddCell(pc33);
            sb.Remove(0, sb.Length);
            if (u.OrderItemEmployee != null)
            {
                foreach (OrderItemEmployee oie in u.OrderItemEmployee)
                {
                    if (oie.PositionId == Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                    {
                        sb.Append(oie.Name);
                        sb.Append(" ");
                    }
                }
            }
            PdfPCell pc34 = new PdfPCell(new Paragraph(sb.ToString(), FontBase));
            pc34.HorizontalAlignment = Element.ALIGN_LEFT;
            pc34.Border = 0;
            pc34.NoWrap=true;
            pc34.FixedHeight = 2 * ROW_HEIGHT;
            ptb.AddCell(pc34);

            PdfPCell pc35 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("送货:", FontBase));
            pc35.Border = 0;
            pc35.FixedHeight = 2 * ROW_HEIGHT;
            pc35.NoWrap=true;
            pc35.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc35);

            PdfPCell pc36 = new PdfPCell(new Paragraph(u.Name, FontBase));
            pc36.Border = 0;
            pc36.FixedHeight = 2 * ROW_HEIGHT;
            pc36.NoWrap=true;
            pc36.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pc36);
            return ptb;
        }
        private PdfPTable GetOrderItem(OrderModel u)
        {
            List<float> aList = new List<float>();
            aList.Add(10);

            aList.Add(35);//80
            aList.Add(60);//80
            aList.Add(60);//80
            aList.Add(60);
            aList.Add(35);
            aList.Add(35);

            aList.Add(35);
            aList.Add(70);
            aList.Add(50);//60
            aList.Add(70);
            aList.Add(75);
            aList.Add(35);
            float[] cellWidth = (float[])aList.ToArray();

            PdfPTable ptb = new PdfPTable(cellWidth);
            
            //PdfPTable ptb = new PdfPTable(u.PriceFactor.Count+6);
            //ptb.SetTotalWidth(700f);
            PdfPCell pH1 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("No", FontBase));
            pH1.Border = 0;
            pH1.NoWrap = false;
            pH1.FixedHeight = 23F;// ROW_HEIGHT;
            pH1.HorizontalAlignment = Element.ALIGN_CENTER;

            ptb.AddCell(pH1);
            PdfPCell pH2 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("业务类型", FontBase));
            pH2.Border = 0;
            pH2.NoWrap = false;
            pH2.HorizontalAlignment = Element.ALIGN_CENTER;
            pH2.FixedHeight = 23F;//ROW_HEIGHT;

            ptb.AddCell(pH2);
            for (int i = 0; i < u.PriceFactor.Count; i++)
            {
                PdfPCell pH = new PdfPCell(new Paragraph("", FontBase));//new Paragraph(u.PriceFactor[i].DisplayText, FontBase));
                pH.Border = 0;
                pH.HorizontalAlignment = Element.ALIGN_CENTER;
                pH.NoWrap = false;
                pH.FixedHeight = 23F;//ROW_HEIGHT;
                ptb.AddCell(pH);
            }
            PdfPCell pH3 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("数量", FontBase));
            pH3.Border = 0;
            pH3.NoWrap = false;
            pH3.FixedHeight = 23F;//ROW_HEIGHT;
            pH3.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("单价", FontBase));
            pH4.Border = 0;
            pH4.NoWrap = false;
            pH4.FixedHeight = 23F;//ROW_HEIGHT;
            pH4.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH4);

            PdfPCell pH5 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("金额", FontBase));
            pH5.Border = 0;
            pH5.FixedHeight = 23F;//ROW_HEIGHT;
            pH5.NoWrap = false;
            pH5.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH5);

            PdfPCell pH6 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("制作要求", FontBase));
            pH6.Border = 0;
            pH6.FixedHeight = 23F;//ROW_HEIGHT;
            pH6.NoWrap = false;
            pH6.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH6);


            PdfPCell pdcNull = new PdfPCell(new Paragraph("", FontBase));
            pdcNull.Border = 0;
            pdcNull.NoWrap = false;
            ptb.AddCell(pdcNull);

            int position = 0;
            decimal sumMoney = 0;
            int le = 0;
            for (int i = 0; i < u.OrderItem.Count; i++)
            {
                PdfPCell pc1 = new PdfPCell(new Paragraph("", FontColumnValue));//new Paragraph((i + 1).ToString(), FontBase));
                pc1.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_CENTER;
                pc1.Border = 0;
                //pc1.FixedHeight = 22F;//ROW_HEIGHT;
                pc1.NoWrap = false;
                ptb.AddCell(pc1);

                PdfPCell pc2 = new PdfPCell(new Paragraph(u.OrderItem[i].Name, FontColumnValue));
                pc2.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_CENTER;
                pc2.Border = 0;
                //pc2.FixedHeight = 22F;//ROW_HEIGHT;
                pc2.NoWrap = false;
                ptb.AddCell(pc2);
                int a = 0;
                for (int n = position; n < u.NewOrder.OrderItemList.Count; n++)
                {
                    if (u.OrderItem[i].Id == u.NewOrder.OrderItemList[n].Id)
                    {
                        int m = 0;
                        for (int k = (int)(u.NewOrder.OrderItemList[n].PriceFactorId % Constants.MAX_ID_BASE); k < u.PriceFactor.Count; k++)
                        {
                            int y = a;
                            for (int x = 0; x < ((u.NewOrder.OrderItemList[n].PriceFactorId % Constants.MAX_ID_BASE) - y - 1); x++)
                            {
                                PdfPCell pc = new PdfPCell(new Paragraph("-", FontColumnValue));
                                pc.HorizontalAlignment =Element.ALIGN_CENTER;
                                pc.Border = 0;
                                //pc.FixedHeight = 22F;//ROW_HEIGHT;
                                pc.NoWrap = false;
                                ptb.AddCell(pc);
                                a++;
                            }
                            if (u.PriceFactor[k - 1].Id == u.NewOrder.OrderItemList[n].PriceFactorId )
                            {
                                PdfPCell pc = new PdfPCell(new Paragraph(u.NewOrder.OrderItemList[n].Name, FontColumnValue));
                                pc.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_CENTER;
                                pc.Border = 0;
                                //pc.FixedHeight = 22F;//ROW_HEIGHT;
                                pc.NoWrap = false;
                                ptb.AddCell(pc);
                                m++;
                                a++;
                                position++;
                            }
                        }
                        if (0 == m)
                        {
                            PdfPCell pc = new PdfPCell(new Paragraph("-", FontColumnValue));
                            pc.HorizontalAlignment = Element.ALIGN_CENTER;
                            pc.Border = 0;
                            pc.NoWrap = false;
                            ptb.AddCell(pc);
                        }
                    }
                }
                if (a < u.PriceFactor.Count)
                {
                    for (int b = 0; b < u.PriceFactor.Count - a; b++)
                    {
                        PdfPCell pc = new PdfPCell(new Paragraph("-", FontColumnValue));
                        pc.HorizontalAlignment = Element.ALIGN_CENTER;
                        pc.Border = 0;
                        pc.NoWrap = false;
                        ptb.AddCell(pc);
                    }
                }
                string sAmount=u.OrderItem[i].Amount == 0 ? "0" : u.OrderItem[i].Amount.ToString();
                PdfPCell pAmount = new PdfPCell(new Paragraph(sAmount, FontColumnValue));
                pAmount.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                pAmount.Border = 0;
                pAmount.NoWrap = false;
                //pAmount.FixedHeight = 22F;//ROW_HEIGHT;
                ptb.AddCell(pAmount);

                string sUnitPrice=u.OrderItem[i].UnitPrice == 0 ? "0.00" : u.OrderItem[i].UnitPrice.ToString("C");
                PdfPCell pUnitPrice = new PdfPCell(new Paragraph(sUnitPrice, FontColumnValue));
                pUnitPrice.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                pUnitPrice.Border = 0;
                //pUnitPrice.FixedHeight = 22F;//ROW_HEIGHT;
                pUnitPrice.NoWrap = false;
                ptb.AddCell(pUnitPrice);

                string sSum=(u.OrderItem[i].Amount * u.OrderItem[i].UnitPrice) == 0 ? "0.00" : (u.OrderItem[i].Amount * u.OrderItem[i].UnitPrice).ToString("C");
                PdfPCell pSum = new PdfPCell(new Paragraph(sSum, FontColumnValue));
                pSum.HorizontalAlignment = Element.ALIGN_LEFT;// Element.ALIGN_RIGHT;
                pSum.Border = 0;
                //pSum.FixedHeight = 22F;//ROW_HEIGHT;
                pSum.NoWrap = false;
                ptb.AddCell(pSum);

                sumMoney += u.OrderItem[i].Amount * u.OrderItem[i].UnitPrice;
                string strPrint = "";
                for (int j = 0; j < u.OrderItemPrintRequireDetailList.Count; j++)
                {
                    if (u.OrderItem[i].Id == u.OrderItemPrintRequireDetailList[j].OrderItemId)
                    {
                        strPrint += u.OrderItemPrintRequireDetailList[j].Name+" ";
                    }
                }
                strPrint = strPrint.Trim();
                if (u.OrderItemPrintRequireDetailList.Count > 0)
                {
                    strPrint += " " + u.OrderItem[i].Memo;
                }
                IList<string> strPrintList = null;
                if (strPrint.Length > 10) 
                {
                    strPrintList = new List<string>();
                    char [] cp=strPrint.ToCharArray();
                    string str1="";
                    for (int index = 0; index < cp.Length;index++ )
                    {
                        if (10==str1.Length)
                        {
                            strPrintList.Add(str1);
                            str1 = "";
                        }
                        else 
                        {
                            str1 += cp[index].ToString();
                        }
                    }
                    if ("" != str1) { strPrintList.Add(str1); }
                    strPrint = strPrint.Substring(0, 10); 
                }
                PdfPCell pPrintRequest = new PdfPCell(new Paragraph(strPrint, FontColumnValue));
                pPrintRequest.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                pPrintRequest.Border = 0;
                pPrintRequest.NoWrap = false;
                ptb.AddCell(pPrintRequest);
                string str = "";
                if (IsDisplayOrderItemEdmit)
                {
                    str =(u.OrderItem[i].Version - 1) + "次修改";
                }
                PdfPCell pEdmitNo = new PdfPCell(new Paragraph(str, FontColumnValue));
                pEdmitNo.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                pEdmitNo.Border = 0;
                pEdmitNo.NoWrap = false;
                //pEdmitNo.FixedHeight = 22F;//ROW_HEIGHT;
                ptb.AddCell(pEdmitNo);
                if(null!=strPrintList)
                {
                    if (strPrintList.Count > 1) 
                    {
                        le += strPrintList.Count - 1;
                        for (int z = 1; z < strPrintList.Count; z++)
                        {
                            for (int c = 0; c < 13; c++)
                            {
                                if (11 == c)
                                {
                                    PdfPCell pcp = new PdfPCell(new Paragraph(strPrintList[z], FontColumnValue));
                                    pcp.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                                    pcp.Border = 0;
                                    pcp.NoWrap = false;
                                    ptb.AddCell(pcp);
                                }
                                else 
                                {
                                    PdfPCell pcpEmpty = new PdfPCell(new Paragraph("", FontColumnValue));
                                    pcpEmpty.HorizontalAlignment = Element.ALIGN_LEFT;//Element.ALIGN_RIGHT;
                                    pcpEmpty.Border = 0;
                                    pcpEmpty.NoWrap = false;
                                    ptb.AddCell(pcpEmpty);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = u.OrderItem.Count+le; i < 15; i++)
            {
                PdfPCell pc1 = new PdfPCell(new Paragraph("", FontColumnValue));//new Paragraph((i + 1).ToString(), FontBase));
                pc1.HorizontalAlignment = Element.ALIGN_CENTER;
                pc1.Border = 0;
                pc1.FixedHeight = 22F;//ROW_HEIGHT;
                pc1.NoWrap = false;
                ptb.AddCell(pc1);

                PdfPCell pc = new PdfPCell(new Paragraph("", FontColumnValue));
                pc.Border = 0;
                pc.FixedHeight = 22F;//ROW_HEIGHT;
                pc.NoWrap = false;
                ptb.AddCell(pc);

                for (int j = 0; j < u.PriceFactor.Count; j++)
                {
                    PdfPCell pcc = new PdfPCell(new Paragraph("", FontColumnValue));
                    pcc.Border = 0;
                    pcc.FixedHeight = 22F;//ROW_HEIGHT;
                    pcc.NoWrap = false;
                    ptb.AddCell(pcc);
                }
                PdfPCell pcAmount = new PdfPCell(new Paragraph("", FontColumnValue));
                pcAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                pcAmount.FixedHeight = 22F;//ROW_HEIGHT;
                pcAmount.Border = 0;
                pcAmount.NoWrap = false;
                ptb.AddCell(pcAmount);

                PdfPCell pcPrice = new PdfPCell(new Paragraph("", FontColumnValue));
                pcPrice.HorizontalAlignment = Element.ALIGN_RIGHT;
                pcPrice.Border = 0;
                pcPrice.FixedHeight = 22F;//ROW_HEIGHT;
                pcPrice.NoWrap = false;
                ptb.AddCell(pcPrice);

                PdfPCell pcMoney = new PdfPCell(new Paragraph("", FontColumnValue));
                pcMoney.HorizontalAlignment = Element.ALIGN_RIGHT;
                pcMoney.Border = 0;
                pcMoney.FixedHeight = 22F;//ROW_HEIGHT;
                pcMoney.NoWrap = false;
                ptb.AddCell(pcMoney);

                PdfPCell pPrintRequest = new PdfPCell(new Paragraph("", FontColumnValue));
                pPrintRequest.HorizontalAlignment = Element.ALIGN_LEFT;
                pPrintRequest.Border = 0;
                pPrintRequest.FixedHeight = 23F;//ROW_HEIGHT;
                pPrintRequest.NoWrap = false;
                ptb.AddCell(pPrintRequest);

                PdfPCell pdcNull1 = new PdfPCell(new Paragraph("", FontColumnValue));
                pdcNull1.Border = 0;
                pdcNull1.NoWrap = false;
                ptb.AddCell(pdcNull1);
            }

            decimal concession = 0;
            StringBuilder sb = new StringBuilder();

            foreach (PaymentConcession pc in u.PaymentConcessionList)
            {
                concession += pc.ConcessionAmount;

                switch (pc.ConcessionType)
                {
                    case Constants.CONCESSION_TYPE_ZERO_VALUE:
                        if (pc.ConcessionAmount > 0)
                        {
                            sb.Append(Constants.CONSESSION_TYPE_ZERO_LABEL + ":");
                            sb.Append(pc.ConcessionAmount.ToString("C") + " ");
                        }
                        break;
                    case Constants.CONCESSION_TYPE_CONCESSION_VALUE:
                        if (pc.ConcessionAmount > 0)
                        {
                            sb.Append(Constants.CONSESSION_TYPE_CONCESSION_LABEL + ":");
                            sb.Append(pc.ConcessionAmount.ToString("C") + " ");
                        }
                        break;
                    case Constants.CONCESSION_TYPE_RENDERUP_VALUE:
                        if (pc.ConcessionAmount > 0)
                        {
                            sb.Append(Constants.CONSESSION_TYPE_RENDERUP_LABEL + ":");
                            sb.Append(pc.ConcessionAmount.ToString("C"));
                        }
                        break;
                }

            }

            //合计
            PdfPCell pNo = new PdfPCell(new Paragraph("", FontBase));
            pNo.HorizontalAlignment = Element.ALIGN_CENTER;
            pNo.Border = 0;
            //pNo.FixedHeight = 25F;//ROW_HEIGHT;
            pNo.NoWrap = false;
            ptb.AddCell(pNo);

            PdfPCell pCountText = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("合计", FontBase));
            pCountText.HorizontalAlignment = Element.ALIGN_CENTER;
            //pCountText.FixedHeight = 25F;//ROW_HEIGHT;
            pCountText.Border = 0;
            pCountText.NoWrap = false;
            ptb.AddCell(pCountText);

            string strCountUpper = "";
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                strCountUpper = "(" + sb.ToString() + ")";
            }
            PdfPCell pCountUpper;
            PdfPCell pCount;

            if (u.PaidAmount<= 0) //开单时 还没实收金额
            {
                decimal reAmount = sumMoney - concession;
                if (u.IsAccounting) 
                {
                    if (u.IsUsePreAmount) reAmount = sumMoney - concession;
                }
                pCountUpper = new PdfPCell(new Paragraph(NumericUtils.ConversionMoney(reAmount.ToString()) +strCountUpper, FontBase));
                pCount = new PdfPCell(new Paragraph(reAmount.ToString("C"), FontBase));
            }
            else
            {
                decimal reAmount = u.PaidAmount;//u.NewOrder.RealPaidAmount;
                if(u.IsAccounting)
                {
                    if (u.IsUsePreAmount) reAmount = sumMoney - concession;
                }
                pCountUpper = new PdfPCell(new Paragraph(NumericUtils.ConversionMoney(reAmount.ToString()) +strCountUpper, FontBase));
                pCount = new PdfPCell(new Paragraph(reAmount.ToString("C"), FontBase));
            }
            pCountUpper.Colspan = u.PriceFactor.Count + 2;
            pCountUpper.HorizontalAlignment = Element.ALIGN_CENTER;//大写金额
            pCountUpper.Border = 0;
            pCountUpper.NoWrap = false;
            //pCountUpper.FixedHeight = 25F;//ROW_HEIGHT;
            ptb.AddCell(pCountUpper);

            pCount.HorizontalAlignment = Element.ALIGN_CENTER;//小写金额
            pCount.Border = 0;
            pCount.NoWrap = false;
            //pCount.FixedHeight = 25F;//ROW_HEIGHT;
            ptb.AddCell(pCount);

            PdfPCell pPrint = new PdfPCell(new Paragraph("", FontBase));
            pPrint.HorizontalAlignment = Element.ALIGN_LEFT;
            pPrint.Border = 0;
            //pPrint.FixedHeight = 25F;//ROW_HEIGHT;
            pPrint.NoWrap = false;
            ptb.AddCell(pPrint);

            PdfPCell pdcNull3 = new PdfPCell(new Paragraph("", FontBase));
            pdcNull3.Border = 0;
            pdcNull3.NoWrap = false;
            ptb.AddCell(pdcNull3);
            return ptb;
        }
        /// <summary>
        ///根据字符长度计算是否换行输出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作者: 张晓林
        /// 日期: 2010年5月4日16:36:24
        /// </remarks>
        private bool IsNewlinePrint(string printStr) 
        {
            bool isNot = true;
            int intLength = printStr.Length;
            char[] cStr = printStr.ToCharArray();
            int j=0;
            for (int i = 0; i < cStr.Length;i++ )
            {
                if (255<System.Convert.ToInt32(cStr[i]))
                {
                    j++;
                }
            }
            if (intLength==j && intLength>4)
            {
                isNot = false;
            }
            else if(4<intLength)
            {
                isNot = false;
            }
            else if(0==intLength)
            {
                isNot = false;
            }
            return isNot;
        }
        public override PdfPTable GetReportFooter(OrderModel u)
        {
            //return null;
            float[] widths ={ 30, 15, 60, 15, 60, 20, 50, 10, 30 };
            PdfPTable ptb = new PdfPTable(widths);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("兰克快印连锁机构", FontBase));
            pc1.Border = 0;
            pc1.Colspan = 9;
            pc1.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc1);

            PdfPCell pc21 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安01店", FontBase));
            pc21.Border = 0;
            pc21.HorizontalAlignment = Element.ALIGN_CENTER;
            pc21.NoWrap = true;
            ptb.AddCell(pc21);

            PdfPCell pc22 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("地址:", FontBase));
            pc22.Border = 0;
            pc22.HorizontalAlignment = Element.ALIGN_CENTER;
            pc22.NoWrap = true;
            ptb.AddCell(pc22);

            PdfPCell pc23 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安市建设东路9号", FontBase));
            pc23.HorizontalAlignment = Element.ALIGN_CENTER;
            pc23.Border = 0;
            ptb.AddCell(pc23);

            PdfPCell pc24 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("电话:", FontBase));
            pc24.Border = 0;
            pc24.HorizontalAlignment = Element.ALIGN_CENTER;
            pc24.NoWrap = true;
            ptb.AddCell(pc24);

            PdfPCell pc25 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("029-85519156 85519157", FontBase));
            pc25.Border = 0;
            pc25.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc25);

            PdfPCell pc26 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("E-mail:", FontBase));
            pc26.Border = 0;
            pc26.HorizontalAlignment = Element.ALIGN_CENTER;
            pc26.NoWrap = true;
            ptb.AddCell(pc26);

            PdfPCell pc27 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("LandKing@126.com", FontBase));
            pc27.Border = 0;
            pc27.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc27);

            PdfPCell pc28 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("QQ:", FontBase));
            pc28.Border = 0;
            pc28.HorizontalAlignment = Element.ALIGN_CENTER;
            pc28.NoWrap = true;
            ptb.AddCell(pc28);

            PdfPCell pc29 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("516362060", FontBase));
            pc29.Border = 0;
            pc29.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc29);

            PdfPCell pc31 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安02店", FontBase));
            pc31.Border = 0;
            pc31.HorizontalAlignment = Element.ALIGN_CENTER;
            pc31.NoWrap = true;
            ptb.AddCell(pc31);
            PdfPCell pc32 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("地址:", FontBase));

            pc32.Border = 0;
            pc32.HorizontalAlignment = Element.ALIGN_CENTER;
            pc32.NoWrap = true;
            ptb.AddCell(pc32);

            PdfPCell pc33 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安市科技路195号.世纪颐园B座1楼\r\n(科技路与高新四路十字口西北角)", FontBase));
            pc33.Border = 0;
            pc33.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc33);

            PdfPCell pc34 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("电话:", FontBase));
            pc34.Border = 0;
            pc34.HorizontalAlignment = Element.ALIGN_CENTER;
            pc34.NoWrap = true;
            ptb.AddCell(pc34);

            PdfPCell pc35 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("029-88327619 88326856", FontBase));
            pc35.Border = 0;
            pc35.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc35);

            PdfPCell pc36 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("E-mail:", FontBase));
            pc36.Border = 0;
            pc36.HorizontalAlignment = Element.ALIGN_CENTER;
            pc36.NoWrap = true;
            ptb.AddCell(pc36);

            PdfPCell pc37 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("LandKing@126.com", FontBase));
            pc37.Border = 0;
            pc37.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc37);

            PdfPCell pc38 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("QQ:", FontBase));
            pc38.Border = 0;
            pc38.HorizontalAlignment = Element.ALIGN_CENTER;
            pc38.NoWrap = true;
            ptb.AddCell(pc38);

            PdfPCell pc39 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("283164676", FontBase));
            pc39.Border = 0;
            pc39.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc39);

            PdfPCell pc41 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安03店", FontBase));
            pc41.Border = 0;
            pc41.HorizontalAlignment = Element.ALIGN_CENTER;
            pc41.NoWrap = true;
            ptb.AddCell(pc41);

            PdfPCell pc42 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("地址:", FontBase));
            pc42.Border = 0;
            pc42.HorizontalAlignment = Element.ALIGN_CENTER;
            pc42.NoWrap = true;
            ptb.AddCell(pc42);

            PdfPCell pc43 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("西安凤城一路10号", FontBase));
            pc43.Border = 0;
            pc43.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc43);

            PdfPCell pc44 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("电话:", FontBase));
            pc44.Border = 0;
            pc44.HorizontalAlignment = Element.ALIGN_CENTER;
            pc44.NoWrap = true;
            ptb.AddCell(pc44);

            PdfPCell pc45 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("029-86562779 86562776", FontBase));
            pc45.Border = 0;
            pc45.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc45);

            PdfPCell pc46 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("E-mail:", FontBase));
            pc46.Border = 0;
            pc46.HorizontalAlignment = Element.ALIGN_CENTER;
            pc46.NoWrap = true;
            ptb.AddCell(pc46);

            PdfPCell pc47 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("LandKing@126.com", FontBase));
            pc47.Border = 0;
            pc47.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc47);

            PdfPCell pc48 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("QQ:", FontBase));
            pc48.Border = 0;
            pc48.HorizontalAlignment = Element.ALIGN_CENTER;
            pc48.NoWrap = true;
            ptb.AddCell(pc48);

            PdfPCell pc49 = new PdfPCell(new Paragraph("", FontBase));//new Paragraph("897081312", FontBase));
            pc49.Border = 0;
            pc49.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pc49);


            return ptb;
        }
        public override PdfPTable GetReportObject(OrderModel u)
        {
            PdfPTable ptb = new PdfPTable(1);
            PdfPCell pc1 = new PdfPCell(new Paragraph("", FontBase));
            PdfPCell pc2 = new PdfPCell(new Paragraph("", FontBase));
            pc1.Border = 0;
            pc2.Border = 0;
            ptb.AddCell(pc1);
            ptb.AddCell(pc2);
            return ptb;
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
    }
}
