
using System;
using System.Web.UI;
using System.ComponentModel;
using System.Text;
using System.Web;

namespace PhookTools
{
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ToolboxData("<{0}:PhookPager runat='server'></{0}:PhookPager>")]
    public partial class PhookPager : System.Web.UI.Control
    {
        protected override void Render(HtmlTextWriter output)
        {
            #region ======= 数据初始化 =======

            // 总页数
            int sumPageCount = this.GetTotalPages();

            if (sumPageCount == 0) return;

            // 当前页码
            int currentPageIndex = this.GetCurrentPageIndex();
            // 显示的页码数
            int showPageNumberCount = this.ShowPageNumberCount;
            // 上翻页码
            int pageUpIndex = this.GetPageUpIndex(currentPageIndex, showPageNumberCount);
            // 下翻页码
            int pageDownIndex = this.GetPageDownIndex(currentPageIndex, showPageNumberCount);

            #endregion

            #region ======= 外层标记 - <SPAN>...</SPAN> =======

            // 外层标记 - <SPAN>...</SPAN>
            output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, this.PagerFontFamily);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontSize, this.PagerFontSize);
            output.RenderBeginTag(HtmlTextWriterTag.Span);

            #endregion

            #region ======= 首页 =======

            // 首页
            if (this.FirstPageDescription.Trim() != "" && this.FirstPageDescription != null)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?{0}=1", this.QueryString));
                output.RenderBeginTag(HtmlTextWriterTag.A);
                output.Write(this.PagerLeftText);
                output.Write(this.FirstPageDescription);
                output.Write(this.PagerRightText);
                output.RenderEndTag();
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 前翻 =======

            // 如果是前 ShowPageNumberCount 页则不显示“前翻”
            if (this.PageUpDescription.Trim() != "" && this.PageUpDescription != null)
            {
                if (currentPageIndex > showPageNumberCount)
                {
                    output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                    output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?{0}={1}", this.QueryString, pageUpIndex.ToString()));
                    output.RenderBeginTag(HtmlTextWriterTag.A);
                    output.Write(this.PagerLeftText);
                    output.Write(this.PageUpDescription);
                    output.Write(this.PagerRightText);
                    output.RenderEndTag();
                    output.Write("&nbsp;&nbsp;");
                }
            }

            #endregion

            #region ======= 页码 =======

            // 呈现页码部分
            this.RenderPageNumber(output, currentPageIndex, showPageNumberCount, sumPageCount);

            #endregion

            #region ======= 后翻 =======

            if (this.PageDownDescription.Trim() != "" && this.PageDownDescription != null)
            {
                // 如果当前后翻页码 <= 总页数则显示“后翻”
                if (pageDownIndex <= sumPageCount)
                {
                    output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                    output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?{0}={1}", this.QueryString, pageDownIndex.ToString()));
                    output.RenderBeginTag(HtmlTextWriterTag.A);
                    output.Write(this.PagerLeftText);
                    output.Write(this.PageDownDescription);
                    output.Write(this.PagerRightText);
                    output.RenderEndTag();
                    output.Write("&nbsp;&nbsp;");
                }
            }

            #endregion

            #region ======= 末页 =======

            // 末页
            if (this.LastPageDescription.Trim() != "" && this.LastPageDescription != null)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?{0}={1}", this.QueryString, sumPageCount.ToString()));
                output.RenderBeginTag(HtmlTextWriterTag.A);
                output.Write(this.PagerLeftText);
                output.Write(this.LastPageDescription);
                output.Write(this.PagerRightText);
                output.RenderEndTag();
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 状态页 =======

            // 状态页 - 1/20页
            output.Write(this.PagerLeftText);
            output.Write(currentPageIndex.ToString());
            output.Write("/");
            output.Write(sumPageCount.ToString());
            output.Write("页");
            output.Write(this.PagerRightText);

            #endregion

            #region ======= 索引页 =======

            // 呈现索引页
            this.RenderPageIndexContent(output, this.PageIndex, sumPageCount, currentPageIndex, this.QueryString, this.SelectedPageNumberColor, this.PagerFontFamily);

            #endregion

            output.RenderEndTag();

            output.Write("<!-- ");
            output.Write("PhookPager V1.0");
            output.Write(" -->");
        }

        #region ======= 自定义视图状态 =======

        protected override void LoadViewState(object savedState)
        {
            Pair p = savedState as Pair;
            if (p != null)
            {
                base.LoadViewState(p.First);
                ((IStateManager)PageIndex).LoadViewState(p.Second);
                return;
            }
            base.LoadViewState(savedState);

        }

		protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object thisState = null;

            if (pageIndex != null)
            {
                thisState = ((IStateManager)pageIndex).SaveViewState();
            }

            if (thisState != null)
            {
                return new Pair(baseState, thisState);
            }
            else
            {
                return baseState;
            }

        }

        protected override void TrackViewState()
        {
            if (pageIndex != null)
            {
                ((IStateManager)pageIndex).TrackViewState();
            }
            base.TrackViewState();
        }

        #endregion
    }
}
