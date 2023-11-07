--功能:计算自上次抄表以来某种机器打印某种纸型(黑白或彩色)的数量
--参数:	@MachineId bigint,		--机器类型ID
--		@PaperSpcId bigint,		--纸型ID
--		@Color	int,			--黑白?彩色
--		@LogCounterId bigint,		--上次抄表记录Id	
--		@CloseStatus int		--工单的结算状态
--作者:付强
--日期:2009-5-5


alter PROCEDURE Get_Machine_Paper_Counter
	@MachineId bigint,		--机器类型ID
	@PaperSpcId bigint,		--纸型ID
	@Color	int,			--黑白/彩色
	@LogCounterId bigint,	--上次抄表记录Id	
	@CloseStatus int,		--结算状态的工单
	@CompanyId	bigint,		--公司ID
	@BranchShopId bigint	--分店ID
as
	declare @returnCount bigint					--返回值 某种机器某种纸型的数量
	declare @lastLogDateTime  varchar(20)		--上次抄表时间

	declare @mPriceFactorId bigint				--机器类型价格因素Id
	declare @pPriceFactorId bigint				--纸型价格因素Id
	declare @pcPriceFactorId bigint				--加工内容因素Id
	
	set @mPriceFactorId=(select id from price_factor where target_table='MACHINE_TYPE' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @pPriceFactorId=(select id from price_factor where target_table='PAPER_SPECIFICATION' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @pcPriceFactorId=(select id from price_factor where target_table='PROCESS_CONTENT' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @returnCount=0

	--获取上次抄表时间
	set @lastLogDateTime=(select RECORD_DATE_TIME from RECORD_MACHINE_WATCH where id=@LogCounterId and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)

	--获取自上次抄表以来结算了的工单
	declare @orderItemId as bigint
	declare @ordersId as bigint
	declare @amount as decimal(14,2)
	declare @tmpCount bigint
	declare myCur cursor for
	select a.id,a.orders_Id as ordersId,a.amount from order_item a
	inner join orders b on a.orders_id=b.id
	where b.status=@CloseStatus and b.BALANCE_DATE_TIME>=@lastLogDateTime and b.BALANCE_DATE_TIME<getdate() and b.Company_Id=@CompanyId and b.Branch_Shop_Id=@BranchShopId
	open myCur
	fetch next from myCur into @orderItemId,@ordersId,@amount
	while @@FETCH_STATUS=0
	begin
		declare @processContentId bigint
		declare pcCur cursor for
		select A.Id from process_content a
		inner join business_type b on b.id=a.business_type_id
		where b.need_record_machine='Y' and color_type=@Color and b.Company_Id=@CompanyId and b.Branch_Shop_Id=@BranchShopId
		open pcCur
		fetch next from pcCur into @processContentId
		while @@FETCH_STATUS=0
		begin
			set @tmpCount=(select count(*) from dbo.ORDER_ITEM_FACTOR_VALUE  
				where order_item_id=@orderItemId and ((price_factor_id=@pcPriceFactorId and [value]=@processContentId ) or
				(price_factor_id=@mPriceFactorId and [value]=@MachineId) or (price_factor_id=@pPriceFactorId and [value]=@PaperSpcId)))
			if @tmpCount>2
			begin
				set @returnCount=(@returnCount+@amount)
			end
			fetch next from pcCur into @processContentId
		end
		close pcCur			
		deallocate pcCur

		fetch next from myCur into @orderItemId,@ordersId,@amount
	end
	close myCur
	deallocate myCur

	--减去未完工工单用纸数量
	set @returnCount=@returnCount-isnull((select USED_PAPER_COUNT from UNCOMPLETE_ORDERS_USED_PAPER where id=@LogCounterId and Machine_id=@MachineId and PAPER_SPECIFICATION_Id=@PaperSpcId),0)
	select @returnCount
go

