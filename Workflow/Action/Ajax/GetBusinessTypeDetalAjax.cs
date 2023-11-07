using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Action;
using Workflow.Support;


namespace Workflow.Action.Ajax
{
    class GetBusinessTypeDetalAjax : AjaxProcess
    {


        #region 对象传递
        public PriceAction priceAction;
        public PriceAction PriceAction
        {
            set { priceAction = value; }
        }
        #endregion

        protected PriceModel model;
        
        
        public string DoProcess(NameValueCollection parameters)
        {

            if (!StringUtils.IsEmpty(parameters["sltBusinessTypeName"]))
            {
                long lngBusinessTypeId = long.Parse (parameters["sltBusinessTypeName"]);
                return QueryProcess2(lngBusinessTypeId);
            }
            else
            {
                return "";
            }           

        }


        private string QueryProcess2(long lngBusinessTypeId)
        {
            model = priceAction.Model;

            priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
            priceAction.Model.BusinessType.Id = lngBusinessTypeId;
            priceAction.ShowSetData(priceAction.Model);
            
            IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
            //jsonDic.Add(typeof(PriceModel), "PriceModel");
            jsonDic.Add(typeof(BusinessType), "Id,Name,PriceFactorList");
            jsonDic.Add(typeof(PriceFactor), "Name");

            return JSONUtils.ToJSONString(priceAction.Model.BusinessTypeList , jsonDic);


        }



        private string QueryProcess(long lngBusinessTypeId)
        {
            model = priceAction.Model;

            priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
            priceAction.Model.BusinessType.Id = lngBusinessTypeId;
            priceAction.InitCustomQuery(priceAction.Model);

            IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
            jsonDic.Add(typeof(TransBusinessDetalData), "RowNum,BusinessName,FactorNames,Memo,Edit1,Edit2,DelID");

            List<TransBusinessDetalData> trlist = new List<TransBusinessDetalData>();
 
            StringBuilder strFactorNames = new StringBuilder();
            string strSplitChar = ",";
            int intCruentRow = 0;


            for (int i = 0; i < model.BusinessTypeList.Count; i++)
            {
                TransBusinessDetalData td = new TransBusinessDetalData();

                intCruentRow += 1;


                //相关因素集合[2]
                strFactorNames.Remove(0, strFactorNames.Length);
                for (int j = 0; j < model.BusinessTypeList[i].PriceFactorList.Count; j++)
                {
                    //追加同一业务类型下的因素集合
                    if (strFactorNames.ToString() != "")
                    {
                        strFactorNames.Append(strSplitChar);
                    }
                    //追加同一业务类型下的因素集合
                    strFactorNames.Append(model.BusinessTypeList[i].PriceFactorList[j].Name);
                }

                //行号[0]
                td.RowNum = intCruentRow.ToString();
                 //业务名称[1]
               td.BusinessName = priceAction.Model.BusinessTypeList[i].Name;
                td.FactorNames = strFactorNames.ToString();
                td.Memo = "";
                td.Edit1 = model.BusinessTypeList[i].Id.ToString();
                td.Edit2 = priceAction.Model.BusinessTypeList[i].Name;
                td.DelID = model.BusinessTypeList[i].Id.ToString();

                trlist.Add(td);
            }

            return JSONUtils.ToJSONString(trlist, jsonDic);

        }






    }

    public class TransBusinessDetalData
    {
        private string rowNum;
        public string RowNum
        {
            get { return rowNum; }
            set { rowNum = value; }
        }

        private string businessName;
        public string BusinessName
        {
            get { return businessName; }
            set { businessName = value; }
        }

        private string factorNames;
        public string FactorNames
        {
            get { return factorNames; }
            set { factorNames = value; }
        }

        private string memo;
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        private string edit1;
        public string Edit1
        {
            get { return edit1; }
            set { edit1 = value; }
        }


        private string edit2;
        public string Edit2
        {
            get { return edit2; }
            set { edit2 = value; }
        }

        private string delID;
        public string DelID
        {
            get { return delID; }
            set { delID = value; }
        }
    
    }
}
