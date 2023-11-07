using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Base;

namespace Workflow.Support.Report.Finance
{
    /// <summary>
    /// 名    称: 收银人当班查询 报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-15
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
    public class ReportSearchOrderByCushPerson : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
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

		public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
			catch(System.Exception ex)
			{
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
				throw ex;
			}
		}
		public override PdfPTable GetReportHeader(OrderModel u)
		{
			PdfPTable ptb = new PdfPTable(7);

            PdfPCell pcBlank11 = new PdfPCell(new Paragraph(" ", FontHeader));
            pcBlank11.HorizontalAlignment = 2;
            pcBlank11.Border = 0;
            pcBlank11.FixedHeight = 30;
            pcBlank11.Colspan = 7;
            pcBlank11.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank11);

            PdfPCell pcBlank1 = new PdfPCell(new Paragraph(QueryString, FontHeader));
            pcBlank1.HorizontalAlignment = 2;
            pcBlank1.Border = 0;
            pcBlank1.Colspan = 4;
            pcBlank1.HorizontalAlignment = Element.ALIGN_LEFT;
            ptb.AddCell(pcBlank1);

            PdfPCell pc2 = new PdfPCell(new Paragraph("打印日期:" + DateUtils.ToFormatDateTime(DateTime.Now, DateTimeFormatEnum.DateTimeNoSecondFormat).ToString(), FontHeader));
		    pc2.HorizontalAlignment = 2;
		    pc2.Border = 0;
           pc2.Colspan = 4;
		    ptb.AddCell(pc2);
			return ptb;
		}
		private PdfPTable GetOrderItem(OrderModel u)
		{

			///定义列标题
			///
			float [] ColumnWidth={ 10,15,25,25,25,15,30,30};
			PdfPTable ptb = new PdfPTable(ColumnWidth);
			//ptb.SetWidths(new int[]{10,10,10,10});

			PdfPCell pH1 = new PdfPCell(new Paragraph("No", FontColumn));
			pH1.NoWrap = true;
			pH1.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH1);

            PdfPCell pH11 = new PdfPCell(new Paragraph("工单号", FontColumn));
            pH11.NoWrap = true;
            pH11.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH11);

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

            PdfPCell pH55 = new PdfPCell(new Paragraph("收银人", FontColumn));
            pH55.NoWrap = true;
            pH55.HorizontalAlignment = Element.ALIGN_CENTER;
            ptb.AddCell(pH55);

            PdfPCell pH6 = new PdfPCell(new Paragraph("开单时间", FontColumn));
			pH6.NoWrap = true;
			pH6.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH6);

            PdfPCell pH7 = new PdfPCell(new Paragraph("结算时间", FontColumn));
			pH7.NoWrap = true;
			pH7.HorizontalAlignment = Element.ALIGN_CENTER;
			ptb.AddCell(pH7);

			decimal CushAmountTotal = 0;//现金合计
           decimal AccountReceviAmoutTotal = 0;//记账合计
           decimal PaidTicketAmountTotal = 0;//发票合计
			for (int j = 0; j < u.OrderList.Count; j++)
			{
                PdfPCell pcNo = new PdfPCell(new Paragraph((j + 1).ToString(), FontColumnValue));
				pcNo.HorizontalAlignment = Element.ALIGN_CENTER;
				ptb.AddCell(pcNo);

                PdfPCell pcOrdersNo = new PdfPCell(new Paragraph(u.OrderList[j].No, FontColumnValue));
              pcOrdersNo.HorizontalAlignment = Element.ALIGN_CENTER;
              ptb.AddCell(pcOrdersNo);

              PdfPCell pcPaidAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[j].PaidAmount), FontColumnValue));//现金
              pcPaidAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
              ptb.AddCell(pcPaidAmount);
              CushAmountTotal += u.OrderList[j].PaidAmount;
              PdfPCell pAccountReceviableOweMomeyTotal = null;
              //处理当抹零金额没有添加到数据库的情况
              if (u.OrderList[j].AccountReceviableOweMomeyTotal <=0)
              {
                  pAccountReceviableOweMomeyTotal = new PdfPCell(new Paragraph("0", FontColumnValue));//记账
              }
              else 
              {
                  pAccountReceviableOweMomeyTotal = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[j].AccountReceviableOweMomeyTotal).ToString(), FontColumnValue));//记账
                  AccountReceviAmoutTotal += u.OrderList[j].AccountReceviableOweMomeyTotal;
              }
              
				pAccountReceviableOweMomeyTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
				ptb.AddCell(pAccountReceviableOweMomeyTotal);


              PdfPCell pcPayTicketAmount = new PdfPCell(new Paragraph(NumericUtils.ToMoney(u.OrderList[j].NotPayTicketAmount), FontColumnValue));
              pcPayTicketAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
              ptb.AddCell(pcPayTicketAmount);
              PaidTicketAmountTotal += u.OrderList[j].NotPayTicketAmount;

              PdfPCell pcCashName = new PdfPCell(new Paragraph(u.OrderList[j].CashName, FontColumnValue));
              pcCashName.HorizontalAlignment = Element.ALIGN_RIGHT;
              ptb.AddCell(pcCashName);


              PdfPCell pcInsertDateTime = new PdfPCell(new Paragraph(Workflow.Util.DateUtils.ToFormatDateTime(u.OrderList[j].InsertDateTime, DateTimeFormatEnum.DateTimeNoSecondFormat), FontColumnValue));
              pcInsertDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
              ptb.AddCell(pcInsertDateTime);

              PdfPCell pcBalnceDateTime = new PdfPCell(new Paragraph(Workflow.Util.DateUtils.ToFormatDateTime(u.OrderList[j].BalanceDateTime, DateTimeFormatEnum.DateTimeNoSecondFormat), FontColumnValue));
              pcBalnceDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
              ptb.AddCell(pcBalnceDateTime);
			}

            PdfPCell pcTotal = new PdfPCell(new Paragraph("合计", FontColumn));
			pcTotal.NoWrap = true;
            pcTotal.Colspan = 2;
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
           //pcPayTicketAmountTotal.Colspan = 2;
           pcPayTicketAmountTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
           ptb.AddCell(pcPayTicketAmountTotal);

           PdfPCell pcNull2 = new PdfPCell(new Paragraph("", FontColumnValue));
           pcNull2.NoWrap = true;
           pcNull2.HorizontalAlignment = Element.ALIGN_CENTER;
           ptb.AddCell(pcNull2);

           PdfPCell pcNull3 = new PdfPCell(new Paragraph("", FontColumnValue));
           pcNull3.NoWrap = true;
           pcNull3.Colspan = 2;
           pcNull3.HorizontalAlignment = Element.ALIGN_CENTER;
           ptb.AddCell(pcNull3);

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
    }
}
