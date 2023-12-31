
using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace PhookTools
{
    /// <summary>
    /// 索引功能类
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PageIndex : System.Web.UI.IStateManager
    {
        #region ======= 自定义ViewState =======

        private Boolean _isTrackingViewState;
        private StateBag _viewState;
        protected StateBag ViewState
        {
            get
            {
                if (this._viewState == null)
                {
                    this._viewState = new StateBag(false);
                    if (this._isTrackingViewState)
                    {
                        ((IStateManager)this._viewState).TrackViewState();
                    }
                }
                return this._viewState;
            }
        }

        #endregion

        #region ======= 属性 =======

        [Description("获取或设置是否显示跳转索引框。"), DefaultValue(true), NotifyParentProperty(true)]
        public Boolean Visiable
        {
            get { return ViewState["Visiable"] != null ? (Boolean)ViewState["Visiable"] : true; }
            set { ViewState["Visiable"] = value; }
        }

        [Description("获取或设置索引框的类型。"), DefaultValue(0), NotifyParentProperty(true)]
        public PageIndexType PageIndexType
        {
            get { return ViewState["PageIndexType"] != null ? (PageIndexType)ViewState["PageIndexType"] : PageIndexType.TextBox; }
            set { ViewState["PageIndexType"] = value; }
        }

        [Description("获取或设置位于页索引框左边的文字。"), DefaultValue("转到第"), NotifyParentProperty(true)]
        public String LeftText
        {
            get { return ViewState["LeftText"] != null ? (String)ViewState["LeftText"] : "转到第"; }
            set { ViewState["LeftText"] = value; }
        }

        [Description("获取或设置位于页索引框右边的文字。"), DefaultValue("页"), NotifyParentProperty(true)]
        public String RightText
        {
            get { return ViewState["RightText"] != null ? (String)ViewState["RightText"] : "页"; }
            set { ViewState["RightText"] = value; }
        }

        [Description("获取或设置跳转按钮中的文字。"), DefaultValue("GO"), NotifyParentProperty(true)]
        public String ButtonText
        {
            get { return ViewState["ButtonText"] != null ? (String)ViewState["ButtonText"] : "GO"; }
            set { ViewState["ButtonText"] = value; }
        }

        #endregion

        #region ======= IStateManager 成员 =======

        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return this._isTrackingViewState;
            }
        }

        void IStateManager.LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                ((IStateManager)this.ViewState).LoadViewState(savedState);
            }
        }

        object IStateManager.SaveViewState()
        {
            object savedState = null;
            if (this._viewState != null)
            {
                savedState = ((IStateManager)this._viewState).SaveViewState();
            }
            return savedState;
        }

        void IStateManager.TrackViewState()
        {
            this._isTrackingViewState = true;
            if (this._viewState != null)
            {
                ((IStateManager)this._viewState).TrackViewState();
            }
        }

        #endregion
    }
}
