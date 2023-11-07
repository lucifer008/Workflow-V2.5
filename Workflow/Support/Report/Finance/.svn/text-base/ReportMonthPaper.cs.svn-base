using System;
using System.IO;
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
	/// 名    称: 月报 报表
	/// 功能概要: 
	/// 作    者: 张晓林
	/// 创建时间: 2008-12-9
	/// 修正履历: 
	/// 修正时间:
	/// </summary>
    public class ReportMonthPaper : ReportBase<iTextSharp.text.pdf.PdfPTable, FindFinanceModel>
    {
       /// <summary>
		/// 查询字符串条件
		/// </summary>
		private string queryString="查询条件 ";
		/// <summary>
		/// 获取或者设置查询字符串条件
		/// </summary>
		public string QueryString 
		{
			set { queryString = value; }
			get { return queryString; }
		}

		public override void CreateReport(FindFinanceModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
			catch(System.Exception ex)
			{
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
				throw ex;
			}
		}
        public override PdfPTable GetReportHeader(FindFinanceModel u)
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
       private PdfPTable GetOrderItem(FindFinanceModel u)
		{

			///定义列标题
			///
            float[] ColumnWidth ={ 10, 15, 15, 15,15,15,15};
			PdfPTable ptb = new PdfPTable(ColumnWidth);

			PdfPCell pH1 = new PdfPCell(new Paragraph("日期", FontColumn));
			pH1.NoWrap = true;
			pH1.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH1);

            PdfPCell pH3 = new PdfPCell(new Paragraph("现金", FontColumn));
			pH3.NoWrap = true;
			pH3.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH3);

            PdfPCell pH4 = new PdfPCell(new Paragraph("记账", FontColumn));
			pH4.NoWrap = true;
			pH4.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH4);

            PdfPCell pH5 = new PdfPCell(new Paragraph("发票", FontColumn));
			pH5.NoWrap = true;
			pH5.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH5);

            PdfPCell pH7 = new PdfPCell(new Paragraph("会员卡冲减金额", FontColumn));
            pH7.NoWrap = false;
            pH7.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH7);


            PdfPCell pH8 = new PdfPCell(new Paragraph("当日营业额合计", FontColumn));
            pH8.NoWrap = false;
            pH8.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH8);

            PdfPCell pH6 = new PdfPCell(new Paragraph("税费", FontColumn));
            pH6.NoWrap = true;
            pH6.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH6);

            u.OrderList = u.OrderTempList;

		   decimal CushAmountTotal = 0;//现金合计
           decimal AccountReceviAmoutTotal = 0;//记账合计
           decimal PaidTicketAmountTotal = 0;//发票合计
           decimal membercardDiffAmount = 0;// 会员卡冲减金额合计
           decimal dailyMoneyTotal = 0;
           decimal ScotTotal = 0;//税费合计
           string reqMonth = u.Operator3;//查询日期
           int monthDays = u.FindFinanceAction.HowMonthDay(Convert.ToDateTime(reqMonth).Year, Convert.ToDateTime(reqMonth).Month);
           bool booTag1 = false;
           for (int index = 1; index <= monthDays; index++)
           {
               bool booTag = false;
               
               string year = Convert.ToDateTime(reqMonth).ToString("yyyy");
               string month = Convert.ToDateTime(reqMonth).ToString("MM");
               string beginDateTime = Convert.ToDateTime(year + "-" + month + "-" + index.ToString()).ToString("yyyy-MM-dd");
               string endDateTime = Convert.ToDateTime(year + "-" + month + "-" + index.ToString()).AddDays(+1).ToString("yyyy-MM-dd");
               u.CashHandOverAction.Model.HandOverDateTime = beginDateTime;
               u.FindFinanceAction.Model.NewOrder.CurrentHandOverBeginDate = u.CashHandOverAction.DailyPaperMinHandOverDateTime;

               u.CashHandOverAction.Model.HandOverDateTime = endDateTime;
               u.FindFinanceAction.Model.NewOrder.CurrentHandOverEndDate = u.CashHandOverAction.DailyPaperMinHandOverDateTime;
               u.FindFinanceAction.SearchMonthPaperOrder_ToPrint();
               u.OrderList=u.FindFinanceAction.Model.OrderTempList;
               u.ScotAmount = u.FindFinanceAction.Model.ScotAmount;
               if (1 == u.OrderList.Count)
               {
                   if (booTag1 && index > DateTime.Now.Day)
                   {
                       u.OrderList[0].PaidAmount = 0;
                       u.OrderList[0].AccountReceviableOweMomeyTotal = 0;
                       u.OrderList[0].NotPayTicketAmount = 0;
                       u.OrderList[0].RealPaidAmount = 0;
                   }
                   ScotTotal += u.ScotAmount;
                   membercardDiffAmount += u.OrderList[0].RealPaidAmount;
                   PaidTicketAmountTotal += u.OrderList[0].NotPayTicketAmount;
                   AccountReceviAmoutTotal += u.OrderList[0].AccountReceviableOweMomeyTotal;
                   CushAmountTotal += u.OrderList[0].PaidAmount - u.OrderList[0].RealPaidAmount;
                   dailyMoneyTotal += u.OrderList[0].PaidAmount - u.OrderList[0].RealPaidAmount + u.OrderList[0].AccountReceviableOweMomeyTotal;

                   PdfPCell pcNo = new PdfPCell(new Paragraph((index).ToString(), FontColumnValue));
                   pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
                   ptb.AddCell(pcNo);

                   PdfPCell pcPaidAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[0].PaidAmount-u.OrderList[0].RealPaidAmount), FontColumnValue));//现金
                   pcPaidAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pcPaidAmount);

                   PdfPCell pAccountReceviableOweMomeyTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[0].AccountReceviableOweMomeyTotal).ToString(), FontColumnValue));//记账
                   pAccountReceviableOweMomeyTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pAccountReceviableOweMomeyTotal);

                   PdfPCell pcPayTicketAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[0].NotPayTicketAmount), FontColumnValue));
                   pcPayTicketAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pcPayTicketAmount);

                   PdfPCell pcMemDiffAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[0].RealPaidAmount), FontColumnValue));
                   pcMemDiffAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pcMemDiffAmount);

                   PdfPCell pcCurrentDaiMoneyAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[0].AccountReceviableOweMomeyTotal + (u.OrderList[0].PaidAmount - u.OrderList[0].RealPaidAmount)), FontColumnValue));
                   pcCurrentDaiMoneyAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pcCurrentDaiMoneyAmount);
                   

                   PdfPCell pcScotAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.ScotAmount), FontColumnValue));
                   pcScotAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                   ptb.AddCell(pcScotAmount);
                   booTag = true;
               }
               else 
               {
                   booTag = false;
               }
               if (!booTag) 
               {
                   PdfPCell pcNull = new PdfPCell(new Paragraph(index.ToString(), FontColumnValue));
                   pcNull.NoWrap = true;
                   pcNull.HorizontalAlignment = Element.ALIGN_CENTER;
                   ptb.AddCell(pcNull);
                   for (int j = 0; j < 3;j++ )
                   {
                       PdfPCell pcNull1 = new PdfPCell(new Paragraph("", FontColumnValue));
                       pcNull1.NoWrap = true;
                       pcNull.HorizontalAlignment = Element.ALIGN_RIGHT;
                       ptb.AddCell(pcNull1);
                   }
               }
           }
           PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumn));
		   pcTotal.NoWrap = true;
		   pcTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
		   ptb.AddCell(pcTotal);

           PdfPCell pcCashTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(CushAmountTotal), FontColumnValue));
           pcCashTotal.NoWrap = true;
           pcCashTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcCashTotal);

           PdfPCell pcAccountReceviableTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(AccountReceviAmoutTotal), FontColumnValue));
           pcAccountReceviableTotal.NoWrap = true;
           pcAccountReceviableTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcAccountReceviableTotal);

           PdfPCell pcPayTicketAmountTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(PaidTicketAmountTotal), FontColumnValue));
           pcPayTicketAmountTotal.NoWrap = true;
           pcPayTicketAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcPayTicketAmountTotal);

           PdfPCell pcMemDiffAmountTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(membercardDiffAmount), FontColumnValue));
           pcMemDiffAmountTotal.NoWrap = true;
           pcMemDiffAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcMemDiffAmountTotal);

           PdfPCell pcCurrentDaiMoneyAmountTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(dailyMoneyTotal), FontColumnValue));
           pcCurrentDaiMoneyAmountTotal.NoWrap = true;
           pcCurrentDaiMoneyAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcCurrentDaiMoneyAmountTotal);


           PdfPCell pcScotAmountTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(ScotTotal), FontColumnValue));
           pcScotAmountTotal.NoWrap = true;
           pcScotAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcScotAmountTotal);

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
