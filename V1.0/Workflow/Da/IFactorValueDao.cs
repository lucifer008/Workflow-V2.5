using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// ��     ��:IFactorValueDao
    /// ���ܸ�Ҫ:����ֵ�ӿ�
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
	/// </summary>
    public interface IFactorValueDao : IDaoBase<FactorValue>
    {
        IList<FactorValue> GetFactorValueListByPriceFactor(PriceFactor priceFactor);
        string GetFactorValueByFactorValueId(PriceFactor priceFactor, bool common);

        /// <summary>
        /// ��    ��: SearchFactorValue
        /// ���ܸ�Ҫ: ��ȡ��������ֵ�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��15:01:35
        /// ����ʱ��:
        /// </summary>
        IList<FactorValue> SearchFactorValue(FactorValue factorValue);

        /// <summary>
        /// ��    ��: SearchFactorValueRowCount
        /// ���ܸ�Ҫ: ��ȡ��������ֵ��¼��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��15:01:35
        /// ����ʱ��:
        /// </summary>
        long SearchFactorValueRowCount(FactorValue factorValue);

        /// <summary>
        /// ��    ��: GetLastFactorValueByPriceFactorId
        /// ���ܸ�Ҫ: ���ݼ۸�����Id��ȡ��һ��Value,�����
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��16:27:26
        /// ����ʱ��:
        /// </summary>
        FactorValue GetLastFactorValueByPriceFactorId(long priceFactorId);

        /// <summary>
        /// ��    ��: GetLastFactorValueById
        /// ���ܸ�Ҫ: ���ݼ۸�����ֵId Value,�����
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��16:27:26
        /// ����ʱ��:
        /// </summary>
        FactorValue GetLastFactorValueById(long factorValueId); 
    }
}
