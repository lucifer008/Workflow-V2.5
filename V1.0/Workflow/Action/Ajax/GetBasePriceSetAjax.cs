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
    class GetBasePriceSetAjax : AjaxProcess
    {


        #region 参数传递
        protected BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
        public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
        {
            set { baseBusinessTypePriceSetAction = value; }
        }
        #endregion

        #region 私有成员变量
        //业务类型ID
        protected BaseBusinessTypePriceSetModel model;

        #endregion

        #region 保存最好一次页面上选择的业务类型

        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            model = baseBusinessTypePriceSetAction.Model;

            if (!StringUtils.IsEmpty(parameters["sltBusinessTypeName"]))
            {
                long lngBusinessTypeId = long.Parse(parameters["sltBusinessTypeName"]);
                
                return QueryProcess2(lngBusinessTypeId);
            }
            else
            {
                return "";
            }           

        }


        private string QueryProcess2(long lngBusinessTypeId)
        {
            
            //设定查询条件
            model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            model.BaseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
            model.BaseBusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
            //查询
            baseBusinessTypePriceSetAction.InitCustomQuery(baseBusinessTypePriceSetAction.Model);
             
            //baseBusinessTypePriceSetAction.Model.BaseBusinessTypePriceSetList[0].

            //BaseBusinessTypePriceSet s = new BaseBusinessTypePriceSet();
            
            IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
            jsonDic.Add(typeof(BaseBusinessTypePriceSetModel), "PriceFactor,BaseBusinessTypePriceSetList");
            jsonDic.Add(typeof(PriceFactor), "DisplayText ");
            jsonDic.Add(typeof(BaseBusinessTypePriceSet), "Id,BusinessType ,Texts,CostPrice,StandardPrice,ActivityPrice,ReservePrice");
            jsonDic.Add(typeof(BusinessType), "Name");
            
            return JSONUtils.ToJSONString(baseBusinessTypePriceSetAction.Model, jsonDic);

        }

    }
}
