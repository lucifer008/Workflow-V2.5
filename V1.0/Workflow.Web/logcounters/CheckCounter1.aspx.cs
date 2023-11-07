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
using Workflow.Action;
using Workflow.Action.Model;
using System.Text;
using Workflow.Da.Domain;
using System.Collections.Generic;
using Workflow.Support;

/// <summary>
/// 名    称: CheckCounter
/// 功能概要: 核对抄表
/// 作    者: 麻少华
/// 创建时间: 2007-10-19
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class CheckCounter : Workflow.Web.PageBase
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
    private int intRowMax = 10;
    //动作标记
    private int intAction = Constants.ACTION_INIT;
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
        //获得页面动作
        if (!StringUtils.IsEmpty(Request.Form["txtAction"]))
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        if (intAction == Constants.ACTION_DELETE)
        {
            //删除
            DeleteProcess();
            InitData();
        }
        else if (intAction == Constants.ACTION_INIT)
        {
            //初始化
            InitData();
        }
        else if (intAction == Constants.ACTION_INSERT)
        {
            SaveMachineWatchRecordCheckData();
            Response.Redirect("CopyCounter.aspx");
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
        if (!StringUtils.IsEmpty(Request.QueryString["RecordMachineWatchId"]))
        {
            lngRecordMachineWatchId = long.Parse(Request.QueryString["RecordMachineWatchId"]);
        }
        //MachineWatchConversionPaper machineWatchConversionPaper = new MachineWatchConversionPaper();
        //machineWatchConversionPaper.RecordMachineWatchId = lngRecordMachineWatchId;
        logCountersAction.InitCheckData(null, lngRecordMachineWatchId);
    }

    /// <summary>
    /// 删除补单(单条)
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void DeleteProcess()
    {
        long lngId = 0;
        //获得补单用纸ID
        if (!StringUtils.IsEmpty(Request.Form["txtId"]))
        {
            lngId = long.Parse(Request.Form["txtId"]);
            //删除补单用纸
            logCountersAction.DeleteCompensate(lngId);
        }
    }
    
    /// <summary>
    /// 保存每次抄表基本信息记录
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-23
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void SaveMachineWatchRecordCheckData()
    {
        PrepareData();
        logCountersAction.SaveMachineWatchRecordCheckData(model);
    }

    /// <summary>
    /// 准备每次抄表基本信息记录数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-23
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareData()
    {
        //机器ID串
        string strMachineId = "";
        string[] strMachineIdList = null;

        //纸型ID串
        string strPaperSpecification = "";
        string[] strPaperSpecificationList = null;

        //颜色类型串
        string strColorType = "";
        string[] strColorTypeList = null;

        //制作张数
        string strMakeCount = "";
        string[] strMakeCountList = null;

        //废单数
        string strCashCount = "";
        string[] strCashCountList = null;

        //补单数
        string strPatchCount = "";
        string[] strPatchCountList = null;

        //取得机器ID串
        if (!StringUtils.IsEmpty(Request.Form["txtMachineId"]))
        {
            strMachineId = Request.Form["txtMachineId"];
        }
        strMachineIdList = strMachineId.Split(',');

        //取得纸型ID串
        if (!StringUtils.IsEmpty(Request.Form["txtPaperSpecificationId"]))
        {
            strPaperSpecification = Request.Form["txtPaperSpecificationId"];
        }
        strPaperSpecificationList = strPaperSpecification.Split(',');

        //取得颜色类型串
        if (!StringUtils.IsEmpty(Request.Form["txtColorType"]))
        {
            strColorType = Request.Form["txtColorType"];
        }
        strColorTypeList = strColorType.Split(',');

        //取得制作张数
        if (!StringUtils.IsEmpty(Request.Form["txtMakeCount"]))
        {
            strMakeCount = Request.Form["txtMakeCount"];
        }
        strMakeCountList = strMakeCount.Split(',');

        //取得废单数
        if (!StringUtils.IsEmpty(Request.Form["txtCashCount"]))
        {
            strCashCount = Request.Form["txtCashCount"];
        }
        strCashCountList = strCashCount.Split(',');

        //取得补单数
        if (!StringUtils.IsEmpty(Request.Form["txtPatchCount"]))
        {
            strPatchCount = Request.Form["txtPatchCount"];
        }
        strPatchCountList = strPatchCount.Split(',');

        model.DailyRecordMachineList = new List<DailyRecordMachine>();
        for (int i = 0; i < strMachineIdList.Length; i++)
        {
            model.DailyRecordMachineList.Add(new DailyRecordMachine());
            model.DailyRecordMachineList[i].Machine = new Machine();
            model.DailyRecordMachineList[i].Machine.Id = long.Parse(strMachineIdList[i]);
            //对象间的制约关系,临时处理,日后需要处理
            model.DailyRecordMachineList[i].PaperSpecification = new PaperSpecification();
            model.DailyRecordMachineList[i].PaperSpecification.Id = long.Parse(strPaperSpecificationList[i] == "0" ? "1" : strPaperSpecificationList[i]);
            model.DailyRecordMachineList[i].ColorType = strColorTypeList[i];
            model.DailyRecordMachineList[i].MakeCount = int.Parse(strMakeCountList[i]);
            model.DailyRecordMachineList[i].CashCount = int.Parse(strCashCountList[i]);
            model.DailyRecordMachineList[i].PatchCount = int.Parse(strPatchCountList[i]);
            model.DailyRecordMachineList[i].DoWatchDateTime = DateTime.Now;
            model.DailyRecordMachineList[i].InWatchCount = 15;
            model.DailyRecordMachineList[i].Memo = "";
        }
    }

    /// <summary>
    /// 处理责任人一览,中间用逗号分隔,每10个人换行
    /// </summary>
    /// <param name="employeeList"></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-18
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected string DoEmployeeProcess(IList<Employee> employeeList)
    {
        StringBuilder strEmployeeList = new StringBuilder();

        int intCurCount = 0;
        foreach (Employee var in employeeList)
        {
            if ((++intCurCount % intRowMax) == 0)
            {
                strEmployeeList.AppendFormat("{0}<br>,", var.Name);
            }
            else
            {
                strEmployeeList.AppendFormat("{0},", var.Name);
            }

        }
        if (strEmployeeList.Length != 0)
        {
            strEmployeeList.Remove(strEmployeeList.Length - 1, 1);
        }
        return strEmployeeList.ToString();
    }
}
