using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls.WebParts;
using Workflow.Support.Ajax;
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Action.Membercard;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 获取价格
    /// </summary>
    /// <remarks>
    /// 作    者: 付强
    /// 创建时间: 2007-10-7
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    class GetPriceAjax:AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }

        protected SearchMemberCardAction searchMemberCardAction;
        public SearchMemberCardAction SearchMemberCardAction
        {
            set { searchMemberCardAction = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["businessTypeId"]))
            {
                BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
                BusinessTypePriceSet businessTypePriceSet = new BusinessTypePriceSet();

                baseBusinessTypePriceSet.BusinessTypeId = long.Parse(parameters["businessTypeId"]);
                businessTypePriceSet.BusinessTypeId = long.Parse(parameters["businessTypeId"]);
                if (!StringUtils.IsEmpty(parameters["CustomerId"]) && "undefined" != parameters["CustomerId"].ToLower())
                {
                    baseBusinessTypePriceSet.CustomerId = long.Parse(parameters["CustomerId"]);
                    businessTypePriceSet.CustomerId = long.Parse(parameters["CustomerId"]);
                }
                else
                {
                    baseBusinessTypePriceSet.CustomerId = -1;
                    businessTypePriceSet.CustomerId = -1;
                }
                if (!StringUtils.IsEmpty(parameters["MemberCardNo"]) && "undefined" != parameters["MemberCardNo"].ToLower())
                {
                    searchMemberCardAction.Model.MemberCardNo = parameters["MemberCardNo"];
                    searchMemberCardAction.SearchAllMemberCardByCardNo();
                    if (null != searchMemberCardAction.Model.MemberCard)
                    {
                        baseBusinessTypePriceSet.MemberCardId = searchMemberCardAction.Model.MemberCard.Id;
                        businessTypePriceSet.MemberCardId = searchMemberCardAction.Model.MemberCard.Id;
                        baseBusinessTypePriceSet.MemberCardLevelId = searchMemberCardAction.Model.MemberCard.MemberCardLevel.Id;
                        businessTypePriceSet.MemberCardLevelId = searchMemberCardAction.Model.MemberCard.MemberCardLevel.Id;
                    }
                }
                else
                {
                    baseBusinessTypePriceSet.MemberCardId = -1;
                    businessTypePriceSet.MemberCardId = -1;
                    baseBusinessTypePriceSet.MemberCardLevelId = -1;
                    businessTypePriceSet.MemberCardLevelId = -1;


                }
                //if (!StringUtils.IsEmpty(parameters["MemberCardLevelId"]) && "undefined" != parameters["MemberCardLevelId"] &&
                //    0!=int.Parse(parameters["MemberCardLevelId"]))
                //{
                //    baseBusinessTypePriceSet.MemberCardLevelId = long.Parse(parameters["MemberCardLvelId"]);
                //    businessTypePriceSet.MemberCardLevelId = long.Parse(parameters["MemberCardLvelId"]);
                //}
                //else
                //{
                //    baseBusinessTypePriceSet.MemberCardLevelId = -1;
                //    businessTypePriceSet.MemberCardLevelId = -1;
                //}

                if (!StringUtils.IsEmpty(parameters["TradeId"]) && "undefined" != parameters["TradeId"] &&
                    0!=int.Parse(parameters["TradeId"]))
                {
                    baseBusinessTypePriceSet.TradeId = long.Parse(parameters["TradeId"]);
                    businessTypePriceSet.TradeId = long.Parse(parameters["TradeId"]);
                }
                else
                {
                    baseBusinessTypePriceSet.TradeId = -1;
                    businessTypePriceSet.TradeId = -1;
                }

                string[] factorsid = parameters["FactorsId"].ToString().Split(',');
                for (int i = 0; i < factorsid.Length; i++)
                {

                    baseBusinessTypePriceSet[i] = long.Parse(factorsid[i]);
                    businessTypePriceSet[i] = long.Parse(factorsid[i]);

                }

                //判断该业务类型的价格是否与数量有关,如果有关 判断当前数量所处的数量区间
                newOrderAction.Model.BusinessType = new List<BusinessType>();
                newOrderAction.Model.BusinessType= newOrderAction.SelectActiveFactorService.GetbusinessType();

                List<long> fvSegList = new List<long>();
                foreach (BusinessType bt in newOrderAction.Model.BusinessType)
                {
                    if (bt.Id == long.Parse(parameters["businessTypeId"]))
                    { 
                        foreach(PriceFactor pf in bt.PriceFactorList)
                        {
                            if (pf.TargetTable.ToLower().Equals("amount_segment"))
                            {
                                newOrderAction.GetAmountSegmentList();

                                //与数量有关 
                                foreach(AmountSegment aSeg in newOrderAction.Model.AmountSegmentList)
                                {
                                    string[] amoutSeg = aSeg.Name.Split('-');
                                    if (decimal.Parse(amoutSeg[0]) <= decimal.Parse(parameters["Amount"]) &&
                                        decimal.Parse(amoutSeg[1]) >= decimal.Parse(parameters["Amount"]))
                                    {
                                        //baseBusinessTypePriceSet[factorsid.Length] = fv.Id;
                                        //businessTypePriceSet[factorsid.Length] = fv.Id;
                                        fvSegList.Add(aSeg.Id);
                                    }
                                }
                            }
                        }
                    }
                }


                //如果与数量有关
                if (fvSegList.Count > 0)
                {
                    foreach (long fvId in fvSegList)
                    {
                        baseBusinessTypePriceSet[factorsid.Length] = fvId;
                        businessTypePriceSet[factorsid.Length] = fvId;
                        newOrderAction.Model.BaseBusinessTypePriceSet = baseBusinessTypePriceSet;
                        newOrderAction.Model.BusinessTypePriceSet = businessTypePriceSet;
                        newOrderAction.GetPrice();
                        if ((newOrderAction.Model.BusinessTypePriceSet.Id != 0 && newOrderAction.Model.BusinessTypePriceSet.Id!=-1) ||
                            (newOrderAction.Model.BaseBusinessTypePriceSet.Id!=0 && newOrderAction.Model.BaseBusinessTypePriceSet.Id!=-1))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    newOrderAction.Model.BaseBusinessTypePriceSet = baseBusinessTypePriceSet;
                    newOrderAction.Model.BusinessTypePriceSet = businessTypePriceSet;
                    newOrderAction.GetPrice();
                }
                if (newOrderAction.Model.BusinessTypePriceSet.Id != 0)
                {
                    newOrderAction.Model.BaseBusinessTypePriceSet.Id = newOrderAction.Model.BusinessTypePriceSet.Id;
                    newOrderAction.Model.BaseBusinessTypePriceSet.StandardPrice = newOrderAction.Model.BusinessTypePriceSet.StandardPrice;
                }
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(OrderModel), "BaseBusinessTypePriceSet");
                jsonDic.Add(typeof(BaseBusinessTypePriceSet), "Id,StandardPrice");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
                //return (newOrderAction.GetPrice(newOrderAction.Model)).ToString();
            }
            else
            {
                return "-1.0";
            }
        }
    }
}
