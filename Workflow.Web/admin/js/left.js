// JScript 文件
/*
//名    称：left
//功能概要: 菜单导航JS
//作    者: 张晓林
//创建时间: 2009年6月22日9:19:35
//修正履历:
//修正时间:
*/

//菜单导航链接

var TREE_ITEMS = [
	['快印易后台', null,
		['基础数据维护', null,
		    ['业务类型', 'priceBaseData/addBusinessType.aspx'],
		    ['加工内容', 'priceBaseData/addProcessContent.aspx'],
		    ['机器类型及机器', 'priceBaseData/addMachineType.aspx'],
		    ['纸型', 'priceBaseData/addPaperSpecifiation.aspx'],
		    ['纸质', 'priceBaseData/addPaperType.aspx'],
		    ['其他价格因素及值', 'priceBaseData/addPriceFactor.aspx'],		    
		    ['业务类型包含的价格因素', 'priceBaseData/addBusinessTypePriceFactor.aspx'],
		    ['价格因素之间的依赖关系', 'priceBaseData/addFactorRelation.aspx'],
		    ['价格因素之间的依赖关系值', 'priceBaseData/addFactorRelationValue.aspx']
		],
		['业务基础数据维护', null,
            ['客户级别', 'orderBaseData/addCustomerLevel.aspx'],	    
            ['客户类型', 'orderBaseData/addCustomerType.aspx'],	    
            ['客户行业及子行业', 'orderBaseData/addMasterTrade.aspx'],	  
            ['会员卡级别', 'orderBaseData/addMemberCardLevel.aspx'],	    
            ['印制要求及值', 'orderBaseData/addPrintDemand.aspx'],
            ['挂失方式', 'orderBaseData/addReportLessMode.aspx'],	    
            ['废张原因', 'orderBaseData/addTrashReason.aspx']	
//            ['加工内容业绩比例', 'orderBaseData/addProcessContentAchievementRate.aspx']	
		],
		['系统基础数据维护', null,
            ['ID维护', 'system/idVindicate.aspx'],	    
            ['应用程序参数维护', 'system/addApllicationProperties.aspx'],
            ['公司信息维护', 'system/addCompany.aspx'],
            ['分店信息维护', 'system/addBranchShop.aspx'],
            ['积分信息维护', 'system/setMarking.aspx'] ,
            ['开单默认值维护','system/SetDefaultValue.aspx']
		]		
	]
];

var TREE_TPL = {
	'target'  : 'mainFrame',	// name of the frame links will be opened in
							// other possible values are: _blank, _parent, _search, _self and _top

	'icon_e'  : 'icons/empty.gif', // empty image
	'icon_l'  : 'icons/line.gif',  // vertical line

        'icon_32' : 'icons/base.gif',   // root leaf icon normal
        'icon_36' : 'icons/base.gif',   // root leaf icon selected
	
	'icon_48' : 'icons/base.gif',   // root icon normal
	'icon_52' : 'icons/base.gif',   // root icon selected
	'icon_56' : 'icons/base.gif',   // root icon opened
	'icon_60' : 'icons/base.gif',   // root icon selected
	
	'icon_16' : 'icons/folder.gif', // node icon normal
	'icon_20' : 'icons/folderopen.gif', // node icon selected
	'icon_24' : 'icons/folderopen.gif', // node icon opened
	'icon_28' : 'icons/folderopen.gif', // node icon selected opened

	'icon_0'  : 'icons/page.gif', // leaf icon normal
	'icon_4'  : 'icons/page.gif', // leaf icon selected
	
	'icon_2'  : 'icons/joinbottom.gif', // junction for leaf
	'icon_3'  : 'icons/join.gif',       // junction for last leaf
	'icon_18' : 'icons/plusbottom.gif', // junction for closed node
	'icon_19' : 'icons/plus.gif',       // junctioin for last closed node
	'icon_26' : 'icons/minusbottom.gif',// junction for opened node
	'icon_27' : 'icons/minus.gif'       // junctioin for last opended node
};
