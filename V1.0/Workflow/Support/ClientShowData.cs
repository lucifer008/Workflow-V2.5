using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Support
{
    public class ClientShowData
    {


        //model.BusinessTypePriceSetList[i].Id

        private long businessTypePriceSetListId;
        public long BusinessTypePriceSetListId
        {
            get
            {
                return businessTypePriceSetListId;
            }
            set
            {
                businessTypePriceSetListId = value;
            }
        }

        private string baseBusinessTypePriceSetId;
        public string BaseBusinessTypePriceSetId
        {
            get
            {
                return baseBusinessTypePriceSetId;
            }
            set
            {
                baseBusinessTypePriceSetId = value;
            }
        }


        private bool isCheck;
        public bool IsCheck
        {
            get
            {
                return isCheck;
            }
            set
            {
                isCheck = value;
            }
        }

        private decimal newPrice;
        public decimal NewPrice
        {
            get
            {
                return newPrice;
            }
            set
            {
                newPrice = value;
            }
        }


        private decimal priceConcession;
        public decimal PriceConcession
        {
            get
            {
                return priceConcession;
            }
            set
            {
                priceConcession = value;
            }
        }


        private Workflow.Da.Domain.BusinessTypePriceSet businessTypePriceSet;
        public Workflow.Da.Domain.BusinessTypePriceSet BusinessTypePriceSet
        {
            get
            {
                return businessTypePriceSet;
            }
            set
            {
                businessTypePriceSet = value;
                BusinessTypePriceSetListId = value.Id;
                BaseBusinessTypePriceSetId = value.BaseBusinessTypePriceSetId.ToString();
                IsCheck = value.IsSeted;
                NewPrice = value.NewPrice;
                priceConcession = value.PriceConcession;
            }
        }

        public string ChkName
        {
            get
            {
                if (IsCheck == true)
                    return "chky" + BaseBusinessTypePriceSetId;
                else
                    return "chkn" + BaseBusinessTypePriceSetId;
            }
        }
        public ClientShowData()
        { }

        public ClientShowData(long iBusinessTypePriceSetListId,string iBaseBusinessTypePriceSetId,bool iIsCheck,decimal iNewPrice,decimal iPriceConcession)
        {
            BusinessTypePriceSetListId = iBusinessTypePriceSetListId;
            BaseBusinessTypePriceSetId = iBaseBusinessTypePriceSetId;
            IsCheck = iIsCheck;
            NewPrice = iNewPrice;
            priceConcession = iPriceConcession;
        }

        public ClientShowData(Workflow.Da.Domain.BusinessTypePriceSet iBusinessTypePriceSet)
        {
            BusinessTypePriceSet = iBusinessTypePriceSet;
        }

    }
}


