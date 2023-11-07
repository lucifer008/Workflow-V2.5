

using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace PhookTools
{
    public partial class PhookPager
    {

        #region ======= 分页外观 =======

        #region ======= 文字样式 =======

        [Browsable(true), Description("获取或设置首页文字。"), Category("分页外观"), DefaultValue("首页")]
        public String FirstPageDescription
        {
            get { return ViewState["FirstPageDescription"] != null ? (String)ViewState["FirstPageDescription"] : "首页"; }
            set { ViewState["FirstPageDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置末页文字。"), Category("分页外观"), DefaultValue("末页")]
        public String LastPageDescription
        {
            get { return ViewState["LastPageDescription"] != null ? (String)ViewState["LastPageDescription"] : "末页"; }
            set { ViewState["LastPageDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置前翻文字。"), Category("分页外观"), DefaultValue("前翻")]
        public String PageUpDescription
        {
            get { return ViewState["PageUpDescription"] != null ? (String)ViewState["PageUpDescription"] : "前翻"; }
            set { ViewState["PageUpDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置后翻文字。"), Category("分页外观"), DefaultValue("后翻")]
        public String PageDownDescription
        {
            get { return ViewState["PageDownDescription"] != null ? (String)ViewState["PageDownDescription"] : "后翻"; }
            set { ViewState["PageDownDescription"] = value; }
        }

        #endregion

        #region ======= 默认样式 =======

        [Browsable(true), Description("获取或设置控件的字体。"), Category("分页外观"), DefaultValue("Verdana")]
        public String PagerFontFamily
        {
            get { return ViewState["PagerFontFamily"] != null ? (String)ViewState["PagerFontFamily"] : "Verdana"; }
            set { ViewState["PagerFontFamily"] = value; }
        }

        [Browsable(true), Description("获取或设置控件的字体大小。"), Category("分页外观"), DefaultValue("12px")]
        public String PagerFontSize
        {
            get { return ViewState["PagerFontSize"] != null ? (String)ViewState["PagerFontSize"] : "12px"; }
            set { ViewState["PagerFontSize"] = value; }
        }

        [Browsable(true), Description("获取或设置控件的字体颜色。"), Category("分页外观"), DefaultValue("Black")]
        public String PagerFontColor
        {
            get { return ViewState["PagerFontColor"] != null ? (String)ViewState["PagerFontColor"] : "#000000"; }
            set { ViewState["PagerFontColor"] = value; }
        }

        [Browsable(true), Description("获取或设置位于控件字体左边的符号。"), Category("分页外观"), DefaultValue("")]
        public String PagerLeftText
        {
            get { return ViewState["PagerLeftText"] != null ? (String)ViewState["PagerLeftText"] : String.Empty; }
            set { ViewState["PagerLeftText"] = value; }
        }

        [Browsable(true), Description("获取或设置位于控件字体右边的符号。"), Category("分页外观"), DefaultValue("")]
        public String PagerRightText
        {
            get { return ViewState["PagerRightText"] != null ? (String)ViewState["PagerRightText"] : String.Empty; }
            set { ViewState["PagerRightText"] = value; }
        }

        #endregion

        #region ======= 页码样式 =======

        [Browsable(true), Description("获取或设置页码的颜色。"), Category("分页外观"), DefaultValue("Black")]
        public String PageNumberColor
        {
            get { return ViewState["PageNumberColor"] != null ? (String)ViewState["PageNumberColor"] : "#000000"; }
            set { ViewState["PageNumberColor"] = value; }
        }

        [Browsable(true), Description("获取或设置当前选中页码的颜色。"), Category("分页外观"), DefaultValue("Red")]
        public String SelectedPageNumberColor
        {
            get { return ViewState["SelectedPageNumberColor"] != null ? (String)ViewState["SelectedPageNumberColor"] : "#FF0000"; }
            set { ViewState["SelectedPageNumberColor"] = value; }
        }

        [Browsable(true), Description("获取或设置位于页码左边的符号。"), Category("分页外观"), DefaultValue("")]
        public String TextBeforePageNumber
        {
            get { return ViewState["TextBeforePageNumber"] != null ? (String)ViewState["TextBeforePageNumber"] : String.Empty; }
            set { ViewState["TextBeforePageNumber"] = value; }
        }

        [Browsable(true), Description("获取或设置位于页码右边的符号。"), Category("分页外观"), DefaultValue("")]
        public String TextAfterPageNumber
        {
            get { return ViewState["TextAfterPageNumber"] != null ? (String)ViewState["TextAfterPageNumber"] : String.Empty; }
            set { ViewState["TextAfterPageNumber"] = value; }
        }

        #endregion

        #region ======= 跳转索引框 =======

        private PageIndex pageIndex;
        [Browsable(true)]
        [Category("分页外观")]
        [Description("获取或设置跳转索引框的样式。")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PageIndex PageIndex
        {
            get
            {
                if (pageIndex == null)
                {
                    pageIndex = new PageIndex();
                    // IsTrackingViewState获取一个值，用于指示服务器控件是否会将更改保存到其视图状态中
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)pageIndex).TrackViewState();
                    }
                }
                return pageIndex;
            }
        }

        private bool recoveryPageIndex;
        [DefaultValue(false)]
        public bool RecoveryPageIndex
        {
            get { return recoveryPageIndex; }
            set { recoveryPageIndex = value; }
        }

        #endregion

        #endregion

        #region ======= 分页数据 =======

        [Browsable(true), Description("获取或设置数据记录总数。"), Category("分页数据"), DefaultValue(100)]
        public Int32 TotalRecordCount
        {
            get { return ViewState["TotalRecordCount"] != null ? (Int32)ViewState["TotalRecordCount"] : 100; }
            set { ViewState["TotalRecordCount"] = value; }
        }

        [Browsable(true), Description("获取或设置每页显示的记录数量。"), Category("分页数据"), DefaultValue(10)]
        public Int32 ShowRecordCount
        {
            get { return ViewState["ShowRecordCount"] != null ? (Int32)ViewState["ShowRecordCount"] : 10; }
            set { ViewState["ShowRecordCount"] = value; }
        }

        [Browsable(true), Description("获取或设置每次显示的页码数量。"), Category("分页数据"), DefaultValue(10)]
        public Int32 ShowPageNumberCount
        {
            get { return ViewState["ShowPageNumberCount"] != null ? (Int32)ViewState["ShowPageNumberCount"] : 10; }
            set { ViewState["ShowPageNumberCount"] = value; }
        }

        [Browsable(true), Description("获取或设置查询字符串集合。（当有多个查询字符串时使用，指定的分页子串必须放在最后，格式如：name=Phook&id）"), Category("分页数据"), DefaultValue("id")]
        public String QueryString
        {
            get { return ViewState["QueryString"] != null ? (String)ViewState["QueryString"] : "id"; }
            set { ViewState["QueryString"] = value; }
        }

        [Browsable(true), Description("获取或设置指定的分页查询字符串。"), Category("分页数据"), DefaultValue("id")]
        public String QueryStringKeyWord
        {
            get { return ViewState["QueryStringKeyWord"] != null ? (String)ViewState["QueryStringKeyWord"] : "id"; }
            set { ViewState["QueryStringKeyWord"] = value; }
        }

        #endregion

    }
}
