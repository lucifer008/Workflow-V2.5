using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action;
using Workflow.Action.Model;
using System.Collections.Generic;

/// <summary>
/// 名    称: EditCompensate
/// 功能概要: 编辑补单量
/// 作    者: 麻少华
/// 创建时间: 2007-10-19
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class EditCompensate : Workflow.Web.PageBase
{
    #region 参数传递
    private LogCountersAction logCountersAction;
    public LogCountersAction LogCountersAction
    {
        set { logCountersAction = value; }
    }

    protected LogCountersModel model;
    #endregion

    #region 私有成员变量
    protected long lngRecordMachineWatchId = 0;
    protected long lngId = 0;
    protected bool closeSelf = false;
    #endregion
    
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void Page_Load(object sender, EventArgs e)
    {
        model = logCountersAction.Model;
        if (!IsPostBack)
        {
            if (!StringUtils.IsEmpty(Request.QueryString["Id"]))
            {
                lngId = long.Parse(Request.QueryString["Id"]);
            }

            if (!StringUtils.IsEmpty(Request.QueryString["RecordMachineWatchId"]))
            {
                lngRecordMachineWatchId = long.Parse(Request.QueryString["RecordMachineWatchId"]);
            }
            InitData();
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        logCountersAction.InitEditCompensateData(lngId);
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void SaveCompensate(object sender, EventArgs e)
    {
        //准备数据
        PrepareModel();
        logCountersAction.UpdateCompensate();
        //关闭本页面
        closeSelf = true;
    }

    /// <summary>
    /// 准备数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareModel()
    {
        //准备补单用纸数据
        PrepareCompensateUsedPaperModel();
        //准备补单责任人数据
        PrepareCompensateEmployeeModel();
    }

    /// <summary>
    /// 准备补单用纸数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareCompensateUsedPaperModel()
    {
        string strRecordMachineWatchId = "";
        string strId = "";
        string strMachineId = "";
        string strPaperSpecificationId = "";
        string strColorId = "";
        string strAmount = "";
        string strMemo="";

        //获得机器抄表ID
        if (!StringUtils.IsEmpty(Request.Form["txtRecordMachineWatchId"]))
        {
            strRecordMachineWatchId = Request.Form["txtRecordMachineWatchId"];
        }

        //获得ID号
        if (!StringUtils.IsEmpty(Request.Form["txtId"]))
        {
            strId = Request.Form["txtId"];
        }

        //获得机器号
        if (!StringUtils.IsEmpty(Request.Form["sltMachine"]))
        {
            strMachineId = Request.Form["sltMachine"];
        }
        //获得纸型
        if (!StringUtils.IsEmpty(Request.Form["sltPaperSpecification"]))
        {
            strPaperSpecificationId = Request.Form["sltPaperSpecification"];
        }
        //获得颜色
        if (!StringUtils.IsEmpty(Request.Form["sltColor"]))
        {
            strColorId = Request.Form["sltColor"];
        }
        //获得数量
        if (!StringUtils.IsEmpty(Request.Form["txtAmount"]))
        {
            strAmount = Request.Form["txtAmount"];
        }

        //获得备注
        if (!StringUtils.IsEmpty(Request.Form["txtMemo"]))
        {
            strMemo = Request.Form["txtMemo"];
        }

        //开始赋值
        model.CompensateUsedPaper = new CompensateUsedPaper();
        //设置ID
        model.CompensateUsedPaper.Id = long.Parse(strId);
        //设置抄表记录ID
        model.CompensateUsedPaper.RecordMachineWatchId = long.Parse(strRecordMachineWatchId);
        //设置机器号
        model.CompensateUsedPaper.Machine = new Machine();
        model.CompensateUsedPaper.Machine.Id = long.Parse(strMachineId);
        //设置纸型
        model.CompensateUsedPaper.PaperSpecification = new PaperSpecification();
        model.CompensateUsedPaper.PaperSpecification.Id = long.Parse(strPaperSpecificationId);
        //设置颜色
        model.CompensateUsedPaper.ColorType = strColorId;
        //设置数量
        model.CompensateUsedPaper.UsedPaperCount = int.Parse(strAmount);
        //设置备注
        model.CompensateUsedPaper.Memo = strMemo;
    }

    /// <summary>
    /// 准备补单责任人数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareCompensateEmployeeModel()
    {
        string strEmployeeId = "";
        string[] strEmployeeIdList = null;
        //获得责任人一览
        if (!StringUtils.IsEmpty(Request.Form["chkEmployee"]))
        {
            strEmployeeId = Request.Form["chkEmployee"];
        }
        strEmployeeIdList = strEmployeeId.Split(',');
        //开始赋值
        model.CompensateEmployeeList = new List<CompensateEmployee>();
        for (int i = 0; i < strEmployeeIdList.Length; i++)
        {
            model.CompensateEmployeeList.Add(new CompensateEmployee());
            if (!StringUtils.IsEmpty(strEmployeeIdList[i]))
            {
                model.CompensateEmployeeList[i].EmployeeId = long.Parse(strEmployeeIdList[i]);
            }
        }
    }
}
