using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Workflow.Support.Exception;

namespace Workflow.Support.Report.Base
{
    /// <summary>
    /// 名    称: PDF报表的基类
    /// 功能概要: 凡是创建PDF报表，都需要从此类继承
    /// 作    者: 付强
    /// 创建时间: 2008-11-17
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public abstract class ReportBase<T, U> where T : IElement
    {
        protected const int SUBJECT_FONT_SIZE = 18;
        protected const int CONTENT_FONT_SIZE = 12;
        private string fileName;
        public virtual string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private Document doc = null;
        public virtual Paragraph GetReportSubject(string subject)
        {
            BaseFont bf = BaseFont.CreateFont(@"c:\WINDOWS\fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font f = new Font(bf, SUBJECT_FONT_SIZE);
            Paragraph p = new Paragraph(subject, f);
            p.Font = f;
            p.Alignment = Element.ALIGN_CENTER;
            return p;
        }

        public virtual Font FontBase
        {
            get 
            {
                BaseFont bf = BaseFont.CreateFont(@"c:\WINDOWS\fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                return new Font(bf, CONTENT_FONT_SIZE);
            }
        }
        public abstract T GetReportHeader(U u) ;
        public abstract T GetReportContent(U u);
        public abstract T GetReportFooter(U u) ;
        public abstract T GetReportObject(U u) ;

        public virtual void CreateReport(U u,string title,string subject)
        {
            Rectangle r = PageSize.A4;
            float left = 10;
            float right = 10;
            float top = 50;
            float bottom = 30;
            this.CreateReport(u,title,subject, r, left, right, top, bottom);
        }
        public virtual void CreateReport(U u, Rectangle r,string title,string subject)
        {
            float left = 10;
            float right = 10;
            float top = 50;
            float bottom = 30;
            this.CreateReport(u, title, subject, r, left, right, top, bottom);
        }
        public virtual void CreateReport(U u,string reportTitle,string reportSubject, Rectangle r, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            doc = new Document(r, marginLeft, marginRight, marginTop, marginBottom);
            if(String.IsNullOrEmpty(this.FileName))
            {
                throw new WorkflowException ("报表名称不能为空!");
            }
            PdfWriter.GetInstance(doc,new FileStream(this.FileName,FileMode.Create));
            doc.Open();

            if (!String.IsNullOrEmpty(reportSubject))
            {
                doc.Add(GetReportSubject(reportSubject));
                Font font = new Font(1, CONTENT_FONT_SIZE);
                Paragraph p = new Paragraph("", font);
                doc.Add(p);
            }

            T tHead = this.GetReportHeader(u);
            T tContent = this.GetReportContent(u);
            T tObject = this.GetReportObject(u);
            T tFooter = this.GetReportFooter(u);

            if (null != tHead)
            {
                doc.Add(tHead);
            }
            if (null != tContent)
            {
                doc.Add(tContent);
            }
            if (null != tObject)
            {
                doc.Add(tObject);
            }
            if (null != tFooter)
            {
                doc.Add(tFooter);
            }
            doc.Close();
            

        }
    }
}
