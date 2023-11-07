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

namespace Workflow.Support.Report.ReportOrderQuery
{
    /// <summary>
    /// 名    称: 工单查询统计报表
    /// 功能概要: 
    /// 作    者: 张晓林
    /// 创建时间: 2009-1-5
    /// 修正履历: 
    /// 修正时间:
    /// </summary>
  public   class ReportOrderQuery : ReportBase<iTextSharp.text.pdf.PdfPTable, OrderModel>
  {
      public override void CreateReport(OrderModel u, string reportTitle, string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
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
          //PdfPTable tContent = this.GetReportContent(u);
          PdfPTable tOrderItem = this.GetOrderItem(u);
          //PdfPTable tFooter = this.GetReportFooter(u);
          PdfPTable tObject = this.GetReportObject(u);
          if (null != tObject)
          {
              doc.Add(tObject);
          }
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
      public override PdfPTable GetReportHeader(OrderModel u)
      {
          float[] widths ={390, 110 };
          PdfPTable ptb = new PdfPTable(widths);

          PdfPCell pcNull = new PdfPCell(new Paragraph("", FontHeader));
          pcNull.HorizontalAlignment = Element.ALIGN_LEFT;
          pcNull.Border = 0;
          pcNull.Colspan = 2;
          pcNull.FixedHeight = 30;
          pcNull.NoWrap = false;
          ptb.AddCell(pcNull);


          PdfPCell pcConditionText = new PdfPCell(new Paragraph("查询条件:" + this.ConditionText, FontHeader));
          pcConditionText.HorizontalAlignment = Element.ALIGN_LEFT;
          pcConditionText.Border = 0;
          pcConditionText.NoWrap = false;
          ptb.AddCell(pcConditionText);

          PdfPCell pc2 = new PdfPCell(new Paragraph("打印时间:" + Workflow.Util.DateUtils.ToFormatDateTime(DateTime.Now, Workflow.Util.DateTimeFormatEnum.DateTimeNoSecondFormat), FontHeader));
          pc2.HorizontalAlignment = Element.ALIGN_RIGHT;
          pc2.Border = 0;
          pc2.NoWrap = true;
          ptb.AddCell(pc2);
          return ptb;
      }

      public override PdfPTable GetReportContent(OrderModel u)
      {
          float[] widths ={ 50, 200, 50, 200 };
          PdfPTable ptb = new PdfPTable(widths);
          PdfPCell pc1 = new PdfPCell(new Paragraph("工单号:", FontColumn));
          pc1.NoWrap = true;
          pc1.HorizontalAlignment = 0;
          ptb.AddCell(pc1);
          PdfPCell pc2 = new PdfPCell(new Paragraph(u.NewOrder.No, FontColumnValue));
          pc2.HorizontalAlignment = 0;
          pc2.Colspan = 3;
          ptb.AddCell(pc2);
          PdfPCell pc21 = new PdfPCell(new Paragraph("起始时间:", FontColumn));
          pc21.NoWrap = true;
          pc21.HorizontalAlignment = 0;
          ptb.AddCell(pc21);
          PdfPCell pc22 = new PdfPCell(new Paragraph(u.NewOrder.BeginBalanceDate, FontColumnValue));
          pc22.HorizontalAlignment = 0;
          ptb.AddCell(pc22);
          PdfPCell pc23 = new PdfPCell(new Paragraph("终止时间:", FontColumn));
          pc23.HorizontalAlignment = 0;
          pc23.NoWrap = true;
          ptb.AddCell(pc23);
          PdfPCell pc24 = new PdfPCell(new Paragraph(u.NewOrder.EndBalanceDate, FontColumnValue));
          pc24.HorizontalAlignment = 0;
          ptb.AddCell(pc24);
          PdfPCell pc31 = new PdfPCell(new Paragraph("会员卡号:", FontColumn));
          pc31.NoWrap = true;
          pc31.HorizontalAlignment = 0;
          ptb.AddCell(pc31);
          PdfPCell pc32 = new PdfPCell(new Paragraph(u.NewOrder.MemberCardNo, FontColumnValue));
          pc32.HorizontalAlignment = 0;
          ptb.AddCell(pc32);
          PdfPCell pc33 = new PdfPCell(new Paragraph("客户名称:", FontColumn));
          pc33.NoWrap = true;
          pc33.HorizontalAlignment = 0;
          ptb.AddCell(pc33);
          PdfPCell pc34 = new PdfPCell(new Paragraph(u.NewOrder.CustomerName, FontColumnValue));
          pc34.HorizontalAlignment = 0;
          ptb.AddCell(pc34);
          PdfPCell pc41 = new PdfPCell(new Paragraph("金额:", FontColumn));
          pc41.NoWrap = true;
          pc41.HorizontalAlignment = 0;
          ptb.AddCell(pc41);
         // PdfPCell pc42 = new PdfPCell(new Paragraph(u.NewOrder.SumAmount.ToString(), FontBase));
          PdfPCell pc42 = new PdfPCell(new Paragraph(u.ComporeCondition + "" + "" + Workflow.Util.NumericUtils.ToMoney(u.NewOrder.SumAmount), FontColumnValue));
          pc42.HorizontalAlignment = 0;
          pc42.Colspan = 3;
          ptb.AddCell(pc42);
          return ptb;  
      }

      private PdfPTable GetOrderItem(OrderModel u)
      {
          PdfPTable ptb = new PdfPTable(9);
          PdfPCell pH1 = new PdfPCell(new Paragraph("NO", FontColumn));
          pH1.NoWrap = true;
          pH1.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pH1);
          PdfPCell pH2 = new PdfPCell(new Paragraph("工单号", FontColumn));
          pH2.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pH2);
          PdfPCell pH3 = new PdfPCell(new Paragraph("客户名称", FontColumn));
              pH3.HorizontalAlignment = Element.ALIGN_CENTER;
              pH3.NoWrap = true;
              ptb.AddCell(pH3);
              PdfPCell pH4 = new PdfPCell(new Paragraph("开单时间", FontColumn));
              pH4 .HorizontalAlignment = Element.ALIGN_CENTER;
              pH4 .NoWrap = true;
              ptb.AddCell(pH4 );
              PdfPCell pH5 = new PdfPCell(new Paragraph("结算时间", FontColumn));
              pH5.HorizontalAlignment = Element.ALIGN_CENTER;
              pH5.NoWrap = true;
              ptb.AddCell(pH5);

              PdfPCell pH6 = new PdfPCell(new Paragraph("消费金额", FontColumn));
              pH6.HorizontalAlignment = Element.ALIGN_CENTER;
              pH6.NoWrap = true;
              ptb.AddCell(pH6);
              PdfPCell pH7 = new PdfPCell(new Paragraph("开单人", FontColumn));
              pH7.HorizontalAlignment = Element.ALIGN_CENTER;
              pH7.NoWrap = true;
              ptb.AddCell(pH7);
              PdfPCell pH8 = new PdfPCell(new Paragraph("收银", FontColumn));
              pH8.HorizontalAlignment = Element.ALIGN_CENTER;
              pH8.NoWrap = true;
              ptb.AddCell(pH8);
              PdfPCell pH9 = new PdfPCell(new Paragraph("备注", FontColumn));
              pH9.HorizontalAlignment = Element.ALIGN_CENTER;
              pH9.NoWrap = true;
              ptb.AddCell(pH9);


              for (int i = 0; i < u.OrderTempList.Count; i++)
              {
                  PdfPCell pc1 = new PdfPCell(new Paragraph((i + 1).ToString(), FontColumnValue));
                  pc1.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc1);
                  PdfPCell pc2 = new PdfPCell(new Paragraph(u.OrderTempList[i].No, FontColumnValue));
                  pc2.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc2);

                  PdfPCell pc3 = new PdfPCell(new Paragraph(u.OrderTempList[i].Name, FontColumnValue));
                  pc3.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc3);
                  PdfPCell pc4 = new PdfPCell(new Paragraph(u.OrderTempList[i].InsertDateTime.ToString(), FontColumnValue));
                  pc4.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc4);
                  PdfPCell pc5 = new PdfPCell(new Paragraph(u.OrderTempList[i].BalanceDateTime.ToString(), FontColumnValue));
                  pc5.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc5);
                  PdfPCell pc6 = new PdfPCell(new Paragraph(Workflow.Util.NumericUtils.ToMoney(u.OrderTempList[i].Sumamount), FontColumnValue));
                  pc6.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc6);
                  PdfPCell pc7 = new PdfPCell(new Paragraph(u.OrderTempList[i].NewOrderName, FontColumnValue));
                  pc7.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc7);
                  PdfPCell pc8 = new PdfPCell(new Paragraph(u.OrderTempList[i].CashName, FontColumnValue));
                  pc8.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc8);
                  PdfPCell pc9 = new PdfPCell(new Paragraph(u.OrderTempList[i].Memo, FontColumnValue));
                  pc9.HorizontalAlignment = Element.ALIGN_CENTER;
                  ptb.AddCell(pc9);

              } 
          return ptb;
      }

      public override PdfPTable GetReportFooter(OrderModel u)
      {
          float[] widths ={ 30, 15, 60, 15, 60, 20, 50, 10, 30 };
          PdfPTable ptb = new PdfPTable(widths);
          PdfPCell pc1 = new PdfPCell(new Paragraph("兰克快印连锁机构", FontColumn));
          pc1.Colspan = 9;
          pc1.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc1);

          PdfPCell pc21 = new PdfPCell(new Paragraph("西安01店", FontColumnValue));
          pc21.HorizontalAlignment = Element.ALIGN_CENTER;
          pc21.NoWrap = true;
          ptb.AddCell(pc21);
          PdfPCell pc22 = new PdfPCell(new Paragraph("地址:", FontColumn));
          pc22.HorizontalAlignment = Element.ALIGN_CENTER;
          pc22.NoWrap = true;
          ptb.AddCell(pc22);
          PdfPCell pc23 = new PdfPCell(new Paragraph("西安市建设东路9号", FontColumnValue));
          pc23.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc23);
          PdfPCell pc24 = new PdfPCell(new Paragraph("电话:", FontColumn));
          pc24.HorizontalAlignment = Element.ALIGN_CENTER;
          pc24.NoWrap = true;
          ptb.AddCell(pc24);
          PdfPCell pc25 = new PdfPCell(new Paragraph("029-85519156 85519157", FontColumnValue));
          pc25.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc25);
          PdfPCell pc26 = new PdfPCell(new Paragraph("E-mail:", FontColumn));
          pc26.HorizontalAlignment = Element.ALIGN_CENTER;
          pc26.NoWrap = true;
          ptb.AddCell(pc26);
          PdfPCell pc27 = new PdfPCell(new Paragraph("LandKing@126.com", FontColumnValue));
          pc27.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc27);
          PdfPCell pc28 = new PdfPCell(new Paragraph("QQ:", FontColumn));
          pc28.HorizontalAlignment = Element.ALIGN_CENTER;
          pc28.NoWrap = true;
          ptb.AddCell(pc28);
          PdfPCell pc29 = new PdfPCell(new Paragraph("516362060", FontColumnValue));
          pc29.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc29);

          PdfPCell pc31 = new PdfPCell(new Paragraph("西安02店", FontColumn));
          pc31.HorizontalAlignment = Element.ALIGN_CENTER;
          pc31.NoWrap = true;
          ptb.AddCell(pc31);
          PdfPCell pc32 = new PdfPCell(new Paragraph("地址:", FontColumn));
          pc32.HorizontalAlignment = Element.ALIGN_CENTER;
          pc32.NoWrap = true;
          ptb.AddCell(pc32);
          PdfPCell pc33 = new PdfPCell(new Paragraph("高新四路西大新区10号", FontColumnValue));
          pc33.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc33);
          PdfPCell pc34 = new PdfPCell(new Paragraph("电话:", FontColumn));
          pc34.HorizontalAlignment = Element.ALIGN_CENTER;
          pc34.NoWrap = true;
          ptb.AddCell(pc34);
          PdfPCell pc35 = new PdfPCell(new Paragraph("029-88373862 88361995", FontColumnValue));
          pc35.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc35);
          PdfPCell pc36 = new PdfPCell(new Paragraph("E-mail:", FontColumn));
          pc36.HorizontalAlignment = Element.ALIGN_CENTER;
          pc36.NoWrap = true;
          ptb.AddCell(pc36);
          PdfPCell pc37 = new PdfPCell(new Paragraph("LandKing@126.com", FontColumnValue));
          pc37.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc37);
          PdfPCell pc38 = new PdfPCell(new Paragraph("QQ:", FontColumn));
          pc38.HorizontalAlignment = Element.ALIGN_CENTER;
          pc38.NoWrap = true;
          ptb.AddCell(pc38);
          PdfPCell pc39 = new PdfPCell(new Paragraph("283164676", FontColumnValue));
          pc39.HorizontalAlignment = Element.ALIGN_CENTER;
          ptb.AddCell(pc39);

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
      private string conditionText;
      public string ConditionText
      {
          set { conditionText = value; }
          get { return conditionText; }
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
