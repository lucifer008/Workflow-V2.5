using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System.Impl
{
    /// <summary>
    /// ��    ��: SystemServiceImpl
    /// ���ܸ�Ҫ: ϵͳ�������ݹ���ӿ�ʵ��
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:37:08
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class SystemServiceImpl:ISystemService
    {
        #region//ע��Dao
        private IIdGeneratorDao idGeneratorDao;
        public IIdGeneratorDao IdGeneratorDao
        {
            set { idGeneratorDao = value; }
        }
        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

        private ICompanyDao companyDao;
        public ICompanyDao CompanyDao 
        {
            set { companyDao = value; }
        }

        private IBranchShopDao branchShopDao;
        public IBranchShopDao BranchShopDao
        {
            set { branchShopDao = value; }
        }

        private IMarkingSettingDao markingSettingDao;
        public IMarkingSettingDao MarkingSettingDao 
        {
            set { markingSettingDao  = value; }
        }
        #endregion

        #region//Idά��

        /// <summary>
        /// ��    �ƣ�InitIdData
        /// ���ܸ�Ҫ����ʼ��Id����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:46:34
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        [Transaction]
        public void InitIdData() 
        {
            IList<IdGenerator> idGeneratorList=idGeneratorDao.GetAllUserTableName();
            idGeneratorDao.DeleteIdGenerator();
            int index = 1;
            long branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            foreach(IdGenerator idGenerator in idGeneratorList)
            {
                idGenerator.Id = index;
                if (1 == branchShopId)
                {
                    idGenerator.BeginValue = branchShopId;
                    idGenerator.EndValue = 100000000;
                }
                else if(2==branchShopId)
                {
                    idGenerator.BeginValue = 100000000;
                    idGenerator.EndValue = 200000000;
                }
                else
                {
                    idGenerator.BeginValue = 200000000;
                    idGenerator.EndValue = 300000000;
                }
                idGenerator.CurrentValue = idGeneratorDao.GetRecordRowCountByTableName(idGenerator.FlagNo)+1;
                idGenerator.BranchShopId = branchShopId;
                idGenerator.Memo = "";
                idGeneratorDao.InsertIdGenerator(idGenerator);
                index++;
            }
        }

        /// <summary>
        /// ��    �ƣ�UpdateIdGenerator
        /// ���ܸ�Ҫ������Id����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��16:19:48
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateIdGenerator(IdGenerator idGenerator) 
        {
            idGeneratorDao.Update(idGenerator);
        }

        /// <summary>
        /// ��    �ƣ�DeleteIdGenerator
        /// ���ܸ�Ҫ��ɾ��Id����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��16:19:48
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void DeleteIdGenerator(long idGeneratorId) 
        {
            idGeneratorDao.Delete(idGeneratorId);
        }
        #endregion

        #region//Ӧ�ó������ά��
        /// <summary>
        /// ��    �ƣ�AddApplicationProperty
        /// ���ܸ�Ҫ�����Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddApplicationProperty(ApplicationProperty applicationProperty) 
        {
            applicationPropertyDao.Insert(applicationProperty);
        }

        /// <summary>
        /// ��    �ƣ�UpdateApplicationProperty
        /// ���ܸ�Ҫ������Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateApplicationProperty(ApplicationProperty applicationProperty) 
        {
            applicationPropertyDao.Update(applicationProperty);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteApplicationProperty
        /// ���ܸ�Ҫ���߼�ɾ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteApplicationProperty(long applicationPropertyId) 
        {
            applicationPropertyDao.LogicDelete(applicationPropertyId);
        }

        /// <summary>
        /// ��    �ƣ�InitApplicationPropertyData
        /// ���ܸ�Ҫ����ʼ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void InitApplicationPropertyData() 
        {
            applicationPropertyDao.DeletePropertyData("DISPLAY_ORDER_INNER_DAY_COUNT");
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.PropertyId = "DISPLAY_ORDER_INNER_DAY_COUNT";
            applicationProperty.PropertyValue = "7";
            applicationPropertyDao.Insert(applicationProperty);
        }
        #endregion

        #region//��˾ά��
        /// <summary>
        /// ��    �ƣ�AddCompany
        /// ���ܸ�Ҫ����ӹ�˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddCompany(Company company) 
        {
            companyDao.Insert(company);
        }

        /// <summary>
        /// ��    �ƣ�UpdateCompany
        /// ���ܸ�Ҫ�����¹�˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateCompany(Company company) 
        {
            companyDao.Update(company);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteCompany
        /// ���ܸ�Ҫ���߼�ɾ����˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteCompany(long companyId) 
        {
            companyDao.LogicDelete(companyId);
        }
        #endregion

        #region//�ֵ���Ϣά��
        /// <summary>
        /// ��    �ƣ�AddBranchShop
        /// ���ܸ�Ҫ����ӷֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddBranchShop(BranchShop branchShop) 
        {
            branchShopDao.Insert(branchShop);
        }

        /// <summary>
        /// ��    �ƣ�UpdateBranchShop
        /// ���ܸ�Ҫ���޸ķֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateBranchShop(BranchShop branchShop) 
        {
            branchShopDao.Update(branchShop);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteBranchShop
        /// ���ܸ�Ҫ���߼�ɾ���ֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteBranchShop(long branchShopId) 
        {
            branchShopDao.LogicDelete(branchShopId);
        }
        #endregion

        #region//������Ϣά��

        /// <summary>
        /// ��    �ƣ�AddMarkingSetting
        /// ���ܸ�Ҫ�����ӻ���
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddMarkingSetting(MarkingSetting markingSetting) 
        {
            foreach(string str in markingSetting.StrProcessContent.Split(','))
            {
                if ("" != str.Trim())
                {
                    markingSetting.ProcessContentId = Convert.ToInt32(str);
                    if (!markingSettingDao.CheckMarkingSettingIsExist(markingSetting))
                        markingSettingDao.Insert(markingSetting);
                }
            }
        }

        /// <summary>
        /// ��    �ƣ�UpdateMarkingSetting
        /// ���ܸ�Ҫ�����»���
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateMarkingSetting(MarkingSetting markingSetting) 
        {
            markingSettingDao.Update(markingSetting);
        }

        /// <summary>
        /// ��    �ƣ�DeleteMarkingSetting
        /// ���ܸ�Ҫ��ɾ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void DeleteMarkingSetting(MarkingSetting markingSetting) 
        {
            markingSettingDao.Delete(markingSetting.Id);
        }
        #endregion
    }
}
