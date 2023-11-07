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
	['快印易', null,
		['订单管理', null,
		    ['本日订单', 'order/DailyOrder.aspx'],
		    ['订单查询', 'order/SearchOrder.aspx'],
		    ['上门取活', 'order/GetOrder.aspx'],
		    ['前期确认', 'order/PhophaseConfirm.aspx'],
		    ['订单修正', 'finance/SelectAmendmentOrder.aspx'],
		    ['订单冲减', 'finance/MortgageOrder.aspx']
		    
		],
		['业绩管理', null,
		    ['业绩调整',                'achievement/AdjustAchievement.aspx'],
		    ['绩效查询',  				'achievement/SearchAchievement.aspx'],
		    ['订单绩效查询',      'achievement/AchievementComposition.aspx'],
		    ['员工业绩统计',      'achievement/AchievementUselessPaperSum.aspx'],
		    ['店长经理绩效统计',      'achievement/AchievementShoperOrManagerSum.aspx'],
		    ['按照人员统计订单量','finance/find/SearchOrderCountByEmployee.aspx']
		],
		['客户管理', null,
		    ['客户编辑', 'customer/CustomerList.aspx'],
		    ['客户添加', 'customer/NewCustomer.aspx'],
		    ['客户合并', 'customer/CustomerValidate.aspx'],
		    ['客户查询', 'customer/SearchCustomer.aspx']
		],
		['会员管理', null,
		    ['会员编辑',          'membercard/MemberCardList.aspx'],
		    ['会员充值',            'membercard/CampaignCharge.aspx'],
			['卡管理',null,
			    ['发卡',                'membercard/NewMemberCard.aspx'],
			    ['挂失/恢复',                'membercard/ReportLossRecovery.aspx'],
			    ['注销',                'membercard/LogOutMemberCard.aspx'],
			    ['补卡',                'membercard/RepairMemberCard.aspx']
			],
		    ['会员查询',null,
			    ['会员详情查询',      'membercard/SearchMemberCard.aspx'],
			    ['会员消费统计',  'membercard/MemberCardConsumeSum.aspx'],
			    ['会员充值记录',      'membercard/ChargeRecord.aspx'],
			    ['会员管理记录',      'membercard/OperationRecord.aspx'],
			    ['会员换卡记录',      'membercard/SwapMemberCardRecord.aspx'],
			    ['异常消费会员查询',      'finance/find/ExceptionConsumeMember.aspx']
			]
		],
		['抄表处理', null,
		    ['机器抄表',   'logcounters/CopyCounter.aspx'],
		    ['计数器查询', 'logcounters/SearchCounter.aspx']
		],
		['活动管理', null,
		    ['营销活动一览', 'activities/CampaignList.aspx'],
		    ['营销活动添加', 'activities/AddCampaign.aspx'],
		    ['送印张活动一览', 'activities/ConcessionList.aspx'],
		    ['送印张活动添加', 'activities/AddConcession.aspx'],
		    ['打折活动一览', 'activities/DiscountConcessionList.aspx'],
		    ['打折活动添加', 'activities/AddDiscountConcession.aspx'],
		    ['买M送N活动添加', 'activities/AddBuySend.aspx'],
		    ['买M送N活动一览', 'activities/BuySendList.aspx']
		],
		['营销分析', null,
		    ['优惠查询根据订单','finance/find/SearchConcession.aspx'],
		    ['优惠查询根据操作人','finance/find/SearchConcessionByUser.aspx'],
		    ['日报','finance/find/DailyPaper.aspx'],
		    ['月报','finance/find/MonthPaper.aspx'],
		    ['报红订单统计', 'finance/SearchMatureOrder.aspx'],
		    ['日营业报表','finance/find/DailyStatistical.aspx'],
		    ['年度汇总','finance/find/YearPaper.aspx']
		],
		['收银处理', null,
		    ['收银',      'finance/selectOrder.aspx'],
		    ['预收款处理', 'finance/PrePayHandler.aspx']
		],
		['财务处理', null,
		    ['应收款处理',      'finance/RecevableAccount.aspx'],
		    ['发票领取', 'finance/DrawTicket.aspx'],
		    ['帐龄分析','finance/find/AnalyzeDebtTime.aspx'],
	    	['客户付款明细','finance/find/SearchPayment.aspx'],
	    	['客户消费统计','finance/find/OrderSum.aspx'],
	    	['订单消费查询','finance/find/SearchOrderItem.aspx'],
	    	['应收款查询','finance/find/SearchArrear.aspx'],
	    	['应收款按时间段合计','finance/find/AccountReceivableAccordingToTimeSectTotal.aspx'],
	    	['收银当班查询','finance/find/SearchCashOnDuty.aspx'],
	    	['应收款付款记录','finance/find/SearchPaidedAccountRecord.aspx'],
	    	['补领发票记录','finance/find/SearchDrawTicketRecord.aspx'],
	    	['门店营业额查询','finance/find/SearchTurnOver.aspx'],
	    	['预收款查询','finance/find/SearchPrepay.aspx'],
	    	['客户对帐表','finance/find/SearchRepayHistory.aspx'],
	    	['异常价格订单汇总','finance/find/ExceptionPriceOrderView.aspx'],
	    	['波动客户查询','finance/find/ExceptionConsumeCustomer.aspx'],
	    	['新老客户消费统计','finance/find/SearchNewAndOldCustomer.aspx'],
	    	['异常消费会员查询','finance/find/ExceptionConsumeMember.aspx'],
	    	['无消费客户查询','finance/find/WithoutConsumeCustomer.aspx']
		],
		['交班管理', null,
		    ['前台交班', 'handover/StageHandOver.aspx'],
		    ['收银交班', 'handover/CasherHandOver.aspx'],
           //['交班', 'handover/HandOver.aspx'],
		    ['交班查询', 'handover/SearchHandOver.aspx']
		],
		['价格管理', null,
				['业务类型设置', 'system/pricemanager/BusinessType.aspx'],
			    ['门市价格设置', 'system/pricemanager/SalesRoomPriceSetting.aspx'],
			    ['会员卡价格设置', 'system/pricemanager/MemberCarcPriceSettings.aspx'],
			    ['行业价格设置', 'system/pricemanager/TradePriceSetting.aspx'],
			    ['特殊会员价格设置', 'system/pricemanager/SpecialPriceSetting.aspx']
		],
		['操作权限管理', null,
		    ['人员管理', null,
		        ['雇员一览','popedomManagement/employee/UsersEmployeeList.aspx'],
		        ['雇员添加','popedomManagement/employee/NewEmployee.aspx'],
				['用户一览', 'popedomManagement/user/UsersList.aspx'],
			    ['用户添加', 'popedomManagement/user/NewUsers.aspx'],
		    ],
		    ['岗位管理',null,
		        ['岗位一览','popedomManagement/position/PositionList.aspx'],
		        ['岗位添加','popedomManagement/position/NewPosition.aspx'],
		    ],
		    ['角色管理', null,
				['角色一览', 'popedomManagement/role/RoleList.aspx'],
			    ['角色添加', 'popedomManagement/role/ModifyRole.aspx'],
		    ],
//		    ['权限管理', null,
//				['权限一览', ''],
//			    ['权限添加', ''],
//		    ],
		    ['权限组管理', null,
				['权限组一览', 'popedomManagement/PermissionGroupList.aspx'],
			    ['权限组添加', 'popedomManagement/NewPermissionGroup.aspx'],
		    ],
		    ['基本操作管理', null,
				['操作一览', 'popedomManagement/permission/PermissionList.aspx'],
			    ['操作添加', 'popedomManagement/permission/NewPermission.aspx'],
		    ]
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
	'icon_28' : 'icons/folderopen.gif', // node icon selected opened6

	'icon_0'  : 'icons/page.gif', // leaf icon normal
	'icon_4'  : 'icons/page.gif', // leaf icon selected
	
	'icon_2'  : 'icons/joinbottom.gif', // junction for leaf
	'icon_3'  : 'icons/join.gif',       // junction for last leaf
	'icon_18' : 'icons/plusbottom.gif', // junction for closed node
	'icon_19' : 'icons/plus.gif',       // junctioin for last closed node
	'icon_26' : 'icons/minusbottom.gif',// junction for opened node
	'icon_27' : 'icons/minus.gif'       // junctioin for last opended node
};


document.onkeypress=keyPress;
function keyPress()
{
    var e=window.event||arguments[0];
    if(e.ctrlKey && e.shiftKey && e.keyCode==11)
    {
        window.location.href="LoginOut.aspx";
    }

}

