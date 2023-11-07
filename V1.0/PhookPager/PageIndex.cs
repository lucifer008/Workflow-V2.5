
using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace PhookTools
{
    /// <summary>
    /// ����������
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PageIndex : System.Web.UI.IStateManager
    {
        #region ======= �Զ���ViewState =======

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

        #region ======= ���� =======

        [Description("��ȡ�������Ƿ���ʾ��ת������"), DefaultValue(true), NotifyParentProperty(true)]
        public Boolean Visiable
        {
            get { return ViewState["Visiable"] != null ? (Boolean)ViewState["Visiable"] : true; }
            set { ViewState["Visiable"] = value; }
        }

        [Description("��ȡ����������������͡�"), DefaultValue(0), NotifyParentProperty(true)]
        public PageIndexType PageIndexType
        {
            get { return ViewState["PageIndexType"] != null ? (PageIndexType)ViewState["PageIndexType"] : PageIndexType.TextBox; }
            set { ViewState["PageIndexType"] = value; }
        }

        [Description("��ȡ������λ��ҳ��������ߵ����֡�"), DefaultValue("ת����"), NotifyParentProperty(true)]
        public String LeftText
        {
            get { return ViewState["LeftText"] != null ? (String)ViewState["LeftText"] : "ת����"; }
            set { ViewState["LeftText"] = value; }
        }

        [Description("��ȡ������λ��ҳ�������ұߵ����֡�"), DefaultValue("ҳ"), NotifyParentProperty(true)]
        public String RightText
        {
            get { return ViewState["RightText"] != null ? (String)ViewState["RightText"] : "ҳ"; }
            set { ViewState["RightText"] = value; }
        }

        [Description("��ȡ��������ת��ť�е����֡�"), DefaultValue("GO"), NotifyParentProperty(true)]
        public String ButtonText
        {
            get { return ViewState["ButtonText"] != null ? (String)ViewState["ButtonText"] : "GO"; }
            set { ViewState["ButtonText"] = value; }
        }

        #endregion

        #region ======= IStateManager ��Ա =======

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
