
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
        /// 得到总页数（动态，前置条件：总记录数、每页显示的记录数）
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
        /// 得到当前选中的页码（动态，前置条件：QueryString）
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
        /// 得到前翻页码（动态，前置条件：当前页码）
        /// </summary>
        /// <param name="currentPageIndex">当前选中的页码</param>
        /// <param name="showPageNumberCount">每页显示的分页页码数量</param>
        /// <returns></returns>
        private Int32 GetPageUpIndex(Int32 currentPageIndex, Int32 showPageNumberCount)
        {
            if (currentPageIndex % showPageNumberCount == 0)
                return (currentPageIndex / showPageNumberCount - 2) * showPageNumberCount + showPageNumberCount;
            else
                return (currentPageIndex / showPageNumberCount - 1) * showPageNumberCount + showPageNumberCount;
        }

        /// <summary>
        /// 得到后翻页码（动态，前置条件：当前页码）
        /// </summary>
        /// <param name="currentPageIndex">当前选中的页码</param>
        /// <param name="showPageNumberCount">每页显示的分页页码数量</param>
        /// <returns></returns>
        private Int32 GetPageDownIndex(Int32 currentPageIndex, Int32 showPageNumberCount)
        {
            if (currentPageIndex % showPageNumberCount == 0)
                return (currentPageIndex / showPageNumberCount) * showPageNumberCount + 1;
            else
                return (currentPageIndex / showPageNumberCount + 1) * showPageNumberCount + 1;
        }

        /// <summary>
        /// 呈现页码部分
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="currentPageIndex">当前页码</param>
        /// <param name="showPageNumberCount">显示的页码数量</param>
        private void RenderPageNumber(HtmlTextWriter output, Int32 currentPageIndex, Int32 showPageNumberCount, Int32 sumPageCount)
        {
            Int32 firstIndex = 0;
            Int32 endIndex = 0;
            // 如果当前页不能整除 showPageNumberCount 页
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
        /// 呈现页码内容
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="firstIndex">开始页码</param>
        /// <param name="endIndex">结束页码</param>
        /// <param name="sumPageCount">总页数</param>
        private void RenderPageNumberContent(HtmlTextWriter output, Int32 currentPageIndex, Int32 firstIndex, Int32 endIndex, Int32 sumPageCount)
        {
            for (Int32 i = firstIndex; i < endIndex && i <= sumPageCount; i++)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");

                // 当前选中页用特殊颜色标记
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
        /// 呈现索引部分
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="sumPageCount">总页数</param>
        /// <param name="queryString">查询字符串</param>
        /// <param name="selectedPageNumberColor">当前选中页码的颜色</param>
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
                        // 左边文字
                        output.Write(pageIndex.LeftText);
                        // <input type="text">
                        output.Write("<input type=\"text\" id=\"");
                        output.Write(uniqueId);
                        output.Write("\" style=\"width:22px;color:");
                        // 页码颜色
                        output.Write(selectedPageNumberColor);
                        output.Write(";text-align:center;\" value=\"");
                        output.Write(currentPageIndex.ToString());
                        output.Write("\" ");
                        output.Write("/>");
                        // 右边文字
                        output.Write(pageIndex.RightText);
                        // <input type="button">
                        output.Write("<input type=\"button\" id=\"btnPhookPageJump\" value=\"");
                        // 跳转按钮文字
                        output.Write(pageIndex.ButtonText);
                        output.Write("\" ");
                        // 字体样式
                        output.Write("style=\"font-family:");
                        output.Write(pagerFontFamily);
                        output.Write(";\" ");
                        // 验证输入的页码是否为正整数
                        output.Write("onclick=\"var str=document.getElementById('");
                        output.Write(uniqueId);
                        output.Write("').value;var reg=");
                        output.Write(@"/^\+?[1-9][0-9]*$/");
                        output.Write(";if(str.length==0||!reg.test(str)){alert('请输入正确的页码！');return;};var pageIndex=parseInt(str);if(pageIndex>");
                        // 总页数
                        output.Write(sumPageCount.ToString());
                        output.Write("||pageIndex<=0){alert('页码超出范围，请重新输入页码！');}else{window.location.href='?");
                        // 查询字符串
                        output.Write(queryString);
                        output.Write("='+pageIndex+'';}\" />");
                        break;

                    case PageIndexType.DropDownList:
                        uniqueId = "opt" + this.UniqueID;
                        output.Write("&nbsp;&nbsp;");
                        // 左边文字
                        output.Write(pageIndex.LeftText);
                        // <select />
                        output.Write("<select id=\"");
                        output.Write(uniqueId);
                        output.Write("\" ");
                        output.Write("style=\"font-family:");
                        output.Write(pagerFontFamily);
                        output.Write(";\" ");
                        output.Write("onchange=\"window.location.href='?");
                        // 查询字符串
                        output.Write(queryString);
                        output.Write("='+document.getElementById('");
                        output.Write(uniqueId);
                        output.Write("').value+''\" ></select>");
                        output.Write("<script>function initPageIndexDropDownList(optPhookPageIndex){for(var i=0;i<");
                        // 总页数
                        output.Write(sumPageCount.ToString());
                        output.Write(";i++){optPhookPageIndex.options[i]=new Option('第'+(i+1)+'页',i+1);}}</script>");
                        // 填充DropDownList
                        output.Write("<script>initPageIndexDropDownList(document.all('");
                        output.Write(uniqueId);
                        output.Write("'))</script>");
                        // 右边文字
                        output.Write(pageIndex.RightText);
                        // 恢复DropDownList选中项
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
