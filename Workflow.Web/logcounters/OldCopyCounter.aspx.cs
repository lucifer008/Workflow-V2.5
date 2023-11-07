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
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Util;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: CopyCounter
/// 功能概要: 抄表处理
/// 作    者: 麻少华
/// 创建时间: 2007-10-19
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class CopyCounter : Workflow.Web.PageBase
{
    #region 参数传递
    private LogCountersAction logCountersAction;
    public LogCountersAction LogCountersAction
    {
        set { logCountersAction = value;}
    }
    protected LogCountersModel model;
    #endregion

    #region 私有成员变量
    //抄表记录成功后返回ID的值
    private long lngRecordMachineWatchId=0;
    #endregion

    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void Page_Load(object sender, EventArgs e)
    {
        model = logCountersAction.Model;
        if (!IsPostBack)
        {
            
            InitData();
        }
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        logCountersAction.InitData();
    }

    /// <summary>
    /// 机器抄表处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void DoCheckAction(object sender, EventArgs e)
    {
        PrepareModel();
        SaveLogCounter();
        //跳转到下一个页面
        Server.Transfer("CheckCounter.aspx?RecordMachineWatchId="+lngRecordMachineWatchId.ToString());
    }

    /// <summary>
    /// 准备数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareModel()
    {
        //准备抄表记录数据
        PrepareRecordMachineWatchModel();
        //准备抄表数据
        PrepareMachineWatchRecordLogModel();
        //准备抄表中未完成订单用纸情况数据
        PrepareUncompleteOrdersUsedPaperModel();
    }

    /// <summary>
    /// 准备抄表记录数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareRecordMachineWatchModel()
    {
        //查表时间
        model.RecordMachineWatch = new RecordMachineWatch();
        model.RecordMachineWatch.RecordDateTime = DateTime.Now.Date;
    }

    /// <summary>
    /// 准备抄表数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareMachineWatchRecordLogModel()
    {   
        //机器ID串
        string strMachineId = "";
        string[] strMachineIdList = null;

        //计数器数值串
        string strMachineWatchValue = "";
        string[] strMachineWatchValueList = null;

        //计数器原数值串
        string strMachineWatchOldValue = "";
        string[] strMachineWatchOldValueList = null;

        //计数器ID串
        string strMachineWatchId = "";
        string[] strMachineWatchIdList = null;

        string strTemp1 = "", strTemp2 = "",strTemp3="";
        //记录数
        int intCount = 0;
        StringBuilder strBuf = new StringBuilder();
        //获得机器ID串
        if (!StringUtils.IsEmpty(Request.Form["txtMachineId"]))
        {
            strMachineId = Request.Form["txtMachineId"];
        }
        strMachineIdList = strMachineId.Split(',');

        model.MachineWatchRecordLogList = new List<MachineWatchRecordLog>();
        
        for (int i = 0; i < strMachineIdList.Length; i++)
        {
            //计数器的值
            strBuf.Remove(0, strBuf.Length);
            strBuf.AppendFormat("txtNewNumber{0}", strMachineIdList[i]);
            strTemp1 = strBuf.ToString();
            //计数器ID
            strBuf.Remove(0, strBuf.Length);
            strBuf.AppendFormat("txtMachineWatchId{0}", strMachineIdList[i]);
            strTemp2 = strBuf.ToString();

            //原来计数器的值
            strBuf.Remove(0, strBuf.Length);
            strBuf.AppendFormat("txtOldNumber{0}", strMachineIdList[i]);
            strTemp3 = strBuf.ToString();
            

            if ((!StringUtils.IsEmpty(Request.Form[strTemp1])) 
                && (!StringUtils.IsEmpty(Request.Form[strTemp2]))
                && (!StringUtils.IsEmpty(Request.Form[strTemp3])))
            {
                //计数器数值
                strMachineWatchValue = Request.Form[strTemp1];
                strMachineWatchValueList = strMachineWatchValue.Split(',');

                //计数器ID
                strMachineWatchId = Request.Form[strTemp2];
                strMachineWatchIdList=strMachineWatchId.Split(',');

                //计数器原来的数值
                strMachineWatchOldValue = Request.Form[strTemp3];
                strMachineWatchOldValueList = strMachineWatchOldValue.Split(',');
                
                for (int j = 0; j < strMachineWatchValueList.Length; j++)
                {
                    model.MachineWatchRecordLogList.Add(new MachineWatchRecordLog());
                    //机器
                    model.MachineWatchRecordLogList[intCount].Machine = new Machine();
                    model.MachineWatchRecordLogList[intCount].Machine.Id = long.Parse(strMachineIdList[i]);

                    //机器上的表
                    model.MachineWatchRecordLogList[intCount].MachineWatch = new MachineWatch();
                    model.MachineWatchRecordLogList[intCount].MachineWatch.Id = long.Parse(strMachineWatchIdList[j]);

                    //本次读数
                    model.MachineWatchRecordLogList[intCount].NewNumber = int.Parse(strMachineWatchValueList[j]);
                    //上次读数
                    model.MachineWatchRecordLogList[intCount].LastNumber = int.Parse(strMachineWatchOldValueList[j]);
                    //备注
                    model.MachineWatchRecordLogList[intCount].Memo = "";
                    intCount++;
                }
            }
        }

    }

    /// <summary>
    /// 准备抄表中未完成订单用纸情况数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareUncompleteOrdersUsedPaperModel()
    {
        //订单号
        string strOrderId = "";
        string[] strOrderIdList = null;
        //机器号
        string strMachineId = "";
        string[] strMachineIdList = null;
        //纸型
        string strPaperSpecificationId = "";
        string[] strPaperSpecificationIdList = null;
        //颜色
        string strColorId = "";
        string[] strColorIdList = null;
        //数量
        string strAmount = "";
        string[] strAmountList = null;
        
        StringBuilder strBuf = new StringBuilder();

        //获得订单号
        if (!StringUtils.IsEmpty(Request.Form["sltOrder"]))
        {
            strOrderId = Request.Form["sltOrder"];
        }
        strOrderIdList = strOrderId.Split(',');

        //获得机器号
        if (!StringUtils.IsEmpty(Request.Form["sltMachine"]))
        {
            strMachineId = Request.Form["sltMachine"];
        }
        strMachineIdList = strMachineId.Split(',');

        //获得纸型
        if (!StringUtils.IsEmpty(Request.Form["sltPaperSpecification"]))
        {
            strPaperSpecificationId = Request.Form["sltPaperSpecification"];
        }
        strPaperSpecificationIdList = strPaperSpecificationId.Split(',');

        //获得颜色
        if (!StringUtils.IsEmpty(Request.Form["sltColor"]))
        {
            strColorId = Request.Form["sltColor"];
        }
        strColorIdList = strColorId.Split(',');

        //获得数量
        if (!StringUtils.IsEmpty(Request.Form["txtAmount"]))
        {
            strAmount = Request.Form["txtAmount"];
        }
        strAmountList = strAmount.Split(',');

        model.UncompleteOrdersUsedPaperList = new List<UncompleteOrdersUsedPaper>();
        for (int i = 0; i < strOrderIdList.Length; i++)
        {
            model.UncompleteOrdersUsedPaperList.Add(new UncompleteOrdersUsedPaper());
            //订单
            if (!StringUtils.IsEmpty(strOrderIdList[i]))
            {
                model.UncompleteOrdersUsedPaperList[i].OrdersId = long.Parse(strOrderIdList[i]);
            }
            
            //机器
            model.UncompleteOrdersUsedPaperList[i].Machine = new Machine();
            if (!StringUtils.IsEmpty(strMachineIdList[i]))
            {
                model.UncompleteOrdersUsedPaperList[i].Machine.Id = long.Parse(strMachineIdList[i]);
            }

            //纸型
            model.UncompleteOrdersUsedPaperList[i].PaperSpecification = new PaperSpecification();
            if (!StringUtils.IsEmpty(strPaperSpecificationIdList[i]))
            {
                model.UncompleteOrdersUsedPaperList[i].PaperSpecification.Id = long.Parse(strPaperSpecificationIdList[i]);
            }
            
            //颜色
            if (!StringUtils.IsEmpty(strColorIdList[i]))
            {
                model.UncompleteOrdersUsedPaperList[i].ColorType = strColorIdList[i];
            }
            
            //用纸量
            if (!StringUtils.IsEmpty(strAmountList[i]))
            {
                model.UncompleteOrdersUsedPaperList[i].UsedPaperCount = int.Parse(strAmountList[i]);
            }
        }

    }

    /// <summary>
    /// 保存抄表记录
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void SaveLogCounter()
    {
        lngRecordMachineWatchId = logCountersAction.SaveLogCounters(model);
    }

    /// <summary>
    /// 获得最后一次表的读数
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-22
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void GetLastNumber(long id)
    {
        logCountersAction.GetLastNumber(id);
    }
}
