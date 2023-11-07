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

using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;
using Workflow.Da.Domain;
using Jayrock.Json;
using System.Collections.Generic;
/// <summary>
///  功能概要: 设置开单默认值
///  作    者: 白晓宇
///  创建时间: 2010年06月29日
///  修正履历:
///  修正时间:
/// </summary>
public partial class admin_system_SetDefaultValue : System.Web.UI.Page
{
    #region action
    private SystemAction action;
    /// <summary>
    /// Action
    /// </summary>
    public SystemAction SystemAction
    {
        set { action = value; }
    }

    /// <summary>
    /// Model
    /// </summary>
    protected SystemModel model;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;

        //try
        {
            if (!Page.IsPostBack)
            {
                this.InitData();
            }
            else
            {
                this.SaveData();
            }
        }
        //catch (Exception ex)
        //{
        //    Workflow.Support.Log.LogHelper.WriteInfo(ex, Workflow.Support.Constants.LOGGER_NAME);
        //}
    }

    /// <summary>
    /// 功能概要: 页面数据初始化
    /// 作    者: 白晓宇
    /// 创建时间: 2010-06-29
    /// </summary>
    public void InitData()
    {
        action.GetBusinessTypeList();
        action.GetPriceFactor();
        action.GetDefaultData();
        if (model.ApplicationProperty != null)
        {
            this.hidId.Value = model.ApplicationProperty.Id.ToString();
            this.hidMemo.Value = model.ApplicationProperty.Memo;
            this.ProcessPriceFactorName();
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    public void SaveData()
    {
        long id = long.Parse(hidId.Value);
        action.GetApplicationProperty(id);

        model.ApplicationProperty.Memo = this.hidMemo.Value;
        action.EditApplicationProperty();

        InitData();

    }

    /// <summary>
    /// 处理价格因素的Name
    /// </summary>
    private void ProcessPriceFactorName()
    {
        string json = this.hidMemo.Value;
        if (!String.IsNullOrEmpty(json))
        {
            JsonArray arr = (JsonArray)Jayrock.Json.Conversion.JsonConvert.Import(json);
            IList<PriceFactor> pfList;

            for (int i = 0; i < arr.Length; i++)
            {
                JsonObject obj = (JsonObject)arr[i];
                long num = long.Parse(obj["btid"].ToString());
                foreach (BusinessType bt in model.BusinessTypeList)
                {
                    if (bt.Id == num)
                    {
                        obj.Put("btname", bt.Name);
                    }
                }


                pfList = action.GetPriceFactorList(num);

                for (int j = 0; j < pfList.Count; j++)
                {
                    JsonArray pfa = (JsonArray)obj["pfa"];

                    for (int m = 0; m < pfa.Count; m++)
                    {
                        JsonObject pfObj = (JsonObject)pfa[m];
                        long pfid = long.Parse(pfObj["id"].ToString());
                        long pfValue = long.Parse(pfObj["v"].ToString());
                        if (pfList[j].Id == pfid)
                        {
                            pfList[j].PriceValueId = pfValue;


                            if (pfList[j].TargetTable.Equals("FACTOR_VALUE"))
                            {
                                pfList[j].PriceFactorId = pfList[j].Id;
                            }

                            string name = action.GetFactorValueText(pfList[j]);
                            JsonObject objName = new JsonObject();
                            pfObj.Put("name", name);
                        }
                    }
                    

                }

                // ArrayList arrList = this.GetPriceFactorList(obj);
            }

            json = arr.ToString();
            this.hidMemoName.Value = json;
        }

    }
}
