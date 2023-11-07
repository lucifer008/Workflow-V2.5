
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace PhookTools
{
    public partial class PhookPager
    {
        /// <summary>
        /// �õ���ҳ������̬��ǰ���������ܼ�¼����ÿҳ��ʾ�ļ�¼����
        /// </summary>
        /// <returns></returns>
        private Int32 GetTotalPages()
        {
            if (this.ShowRecordCount != 0)
            {
                return (this.TotalRecordCount + this.ShowRecordCount - 1) / this.ShowRecordCount;
            }
            return 0;
        }

        /// <summary>
        /// �õ���ǰѡ�е�ҳ�루��̬��ǰ��������QueryString��
        /// </summary>
        /// <returns></returns>
        private Int32 GetCurrentPageIndex()
        {
            if (this.RecoveryPageIndex)
            {
                return 1;
            }

            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[QueryStringKeyWord] != null)
            {
                return Int32.Parse(HttpContext.Current.Request.QueryString[QueryStringKeyWord]);
            }
            return 1;
        }

        /// <summary>
        /// �õ�ǰ��ҳ�루��̬��ǰ����������ǰҳ�룩
        /// </summary>
        /// <param name="currentPageIndex">��ǰѡ�е�ҳ��</param>
        /// <param name="showPageNumberCount">ÿҳ��ʾ�ķ�ҳҳ������</param>
        /// <returns></returns>
        private Int32 GetPageUpIndex(Int32 currentPageIndex, Int32 showPageNumberCount)
        {
            if (currentPageIndex % showPageNumberCount == 0)
                return (currentPageIndex / showPageNumberCount - 2) * showPageNumberCount + showPageNumberCount;
            else
                return (currentPageIndex / showPageNumberCount - 1) * showPageNumberCount + showPageNumberCount;
        }

        /// <summary>
        /// �õ���ҳ�루��̬��ǰ����������ǰҳ�룩
        /// </summary>
        /// <param name="currentPageIndex">��ǰѡ�е�ҳ��</param>
        /// <param name="showPageNumberCount">ÿҳ��ʾ�ķ�ҳҳ������</param>
        /// <returns></returns>
        private Int32 GetPageDownIndex(Int32 currentPageIndex, Int32 showPageNumberCount)
        {
            if (currentPageIndex % showPageNumberCount == 0)
                return (currentPageIndex / showPageNumberCount) * showPageNumberCount + 1;
            else
                return (currentPageIndex / showPageNumberCount + 1) * showPageNumberCount + 1;
        }

        /// <summary>
        /// ����ҳ�벿��
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="currentPageIndex">��ǰҳ��</param>
        /// <param name="showPageNumberCount">��ʾ��ҳ������</param>
        private void RenderPageNumber(HtmlTextWriter output, Int32 currentPageIndex, Int32 showPageNumberCount, Int32 sumPageCount)
        {
            Int32 firstIndex = 0;
            Int32 endIndex = 0;
            // �����ǰҳ�������� showPageNumberCount ҳ
            if (currentPageIndex % showPageNumberCount != 0)
            {
                firstIndex = currentPageIndex / showPageNumberCount * showPageNumberCount + 1;
                endIndex = firstIndex + showPageNumberCount;
            }
            else
            {
                firstIndex = (currentPageIndex / showPageNumberCount - 1) * showPageNumberCount + 1;
                endIndex = firstIndex + showPageNumberCount;
            }
            RenderPageNumberContent(output, currentPageIndex, firstIndex, endIndex, sumPageCount);
        }

        /// <summary>
        /// ����ҳ������
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="firstIndex">��ʼҳ��</param>
        /// <param name="endIndex">����ҳ��</param>
        /// <param name="sumPageCount">��ҳ��</param>
        private void RenderPageNumberContent(HtmlTextWriter output, Int32 currentPageIndex, Int32 firstIndex, Int32 endIndex, Int32 sumPageCount)
        {
            for (Int32 i = firstIndex; i < endIndex && i <= sumPageCount; i++)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");

                // ��ǰѡ��ҳ��������ɫ���
                if (i == currentPageIndex)
                {
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.SelectedPageNumberColor);
                }
                else
                {
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PageNumberColor);
                }

                output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?{0}={1}", this.QueryString, i.ToString()));
                output.RenderBeginTag(HtmlTextWriterTag.A);
                output.Write(this.TextBeforePageNumber);
                output.Write(i.ToString());
                output.Write(this.TextAfterPageNumber);
                output.RenderEndTag();
                output.Write("&nbsp;&nbsp;");
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="sumPageCount">��ҳ��</param>
        /// <param name="queryString">��ѯ�ַ���</param>
        /// <param name="selectedPageNumberColor">��ǰѡ��ҳ�����ɫ</param>
        public void RenderPageIndexContent(HtmlTextWriter output, PageIndex pageIndex, Int32 sumPageCount, Int32 currentPageIndex, String queryString, String selectedPageNumberColor, String pagerFontFamily)
        {
            if (pageIndex.Visiable)
            {
                String uniqueId = String.Empty;

                switch (pageIndex.PageIndexType)
                {
                    case PageIndexType.TextBox:
                        uniqueId = "txt" + this.UniqueID;
                        output.Write("&nbsp;&nbsp;");
                        // �������
                        output.Write(pageIndex.LeftText);
                        // <input type="text">
                        output.Write("<input type=\"text\" id=\"");
                        output.Write(uniqueId);
                        output.Write("\" style=\"width:22px;color:");
                        // ҳ����ɫ
                        output.Write(selectedPageNumberColor);
                        output.Write(";text-align:center;\" value=\"");
                        output.Write(currentPageIndex.ToString());
                        output.Write("\" ");
                        output.Write("/>");
                        // �ұ�����
                        output.Write(pageIndex.RightText);
                        // <input type="button">
                        output.Write("<input type=\"button\" id=\"btnPhookPageJump\" value=\"");
                        // ��ת��ť����
                        output.Write(pageIndex.ButtonText);
                        output.Write("\" ");
                        // ������ʽ
                        output.Write("style=\"font-family:");
                        output.Write(pagerFontFamily);
                        output.Write(";\" ");
                        // ��֤�����ҳ���Ƿ�Ϊ������
                        output.Write("onclick=\"var str=document.getElementById('");
                        output.Write(uniqueId);
                        output.Write("').value;var reg=");
                        output.Write(@"/^\+?[1-9][0-9]*$/");
                        output.Write(";if(str.length==0||!reg.test(str)){alert('��������ȷ��ҳ�룡');return;};var pageIndex=parseInt(str);if(pageIndex>");
                        // ��ҳ��
                        output.Write(sumPageCount.ToString());
                        output.Write("||pageIndex<=0){alert('ҳ�볬����Χ������������ҳ�룡');}else{window.location.href='?");
                        // ��ѯ�ַ���
                        output.Write(queryString);
                        output.Write("='+pageIndex+'';}\" />");
                        break;

                    case PageIndexType.DropDownList:
                        uniqueId = "opt" + this.UniqueID;
                        output.Write("&nbsp;&nbsp;");
                        // �������
                        output.Write(pageIndex.LeftText);
                        // <select />
                        output.Write("<select id=\"");
                        output.Write(uniqueId);
                        output.Write("\" ");
                        output.Write("style=\"font-family:");
                        output.Write(pagerFontFamily);
                        output.Write(";\" ");
                        output.Write("onchange=\"window.location.href='?");
                        // ��ѯ�ַ���
                        output.Write(queryString);
                        output.Write("='+document.getElementById('");
                        output.Write(uniqueId);
                        output.Write("').value+''\" ></select>");
                        output.Write("<script>function initPageIndexDropDownList(optPhookPageIndex){for(var i=0;i<");
                        // ��ҳ��
                        output.Write(sumPageCount.ToString());
                        output.Write(";i++){optPhookPageIndex.options[i]=new Option('��'+(i+1)+'ҳ',i+1);}}</script>");
                        // ���DropDownList
                        output.Write("<script>initPageIndexDropDownList(document.all('");
                        output.Write(uniqueId);
                        output.Write("'))</script>");
                        // �ұ�����
                        output.Write(pageIndex.RightText);
                        // �ָ�DropDownListѡ����
                        output.Write("<script>document.getElementById('");
                        output.Write(uniqueId);
                        output.Write("')[");
                        output.Write(currentPageIndex);
                        output.Write("-1].selected='selected';</script>");
                        break;
                }
            }
        }
    }
}
