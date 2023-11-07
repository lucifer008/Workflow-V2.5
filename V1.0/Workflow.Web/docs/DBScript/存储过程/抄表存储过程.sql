--����:�������ϴγ�������ĳ�ֻ�����ӡĳ��ֽ��(�ڰ׻��ɫ)������
--����:	@MachineId bigint,		--��������ID
--		@PaperSpcId bigint,		--ֽ��ID
--		@Color	int,			--�ڰ�?��ɫ
--		@LogCounterId bigint,		--�ϴγ����¼Id	
--		@CloseStatus int		--�����Ľ���״̬
--����:��ǿ
--����:2009-5-5


alter PROCEDURE Get_Machine_Paper_Counter
	@MachineId bigint,		--��������ID
	@PaperSpcId bigint,		--ֽ��ID
	@Color	int,			--�ڰ�/��ɫ
	@LogCounterId bigint,	--�ϴγ����¼Id	
	@CloseStatus int,		--����״̬�Ĺ���
	@CompanyId	bigint,		--��˾ID
	@BranchShopId bigint	--�ֵ�ID
as
	declare @returnCount bigint					--����ֵ ĳ�ֻ���ĳ��ֽ�͵�����
	declare @lastLogDateTime  varchar(20)		--�ϴγ���ʱ��

	declare @mPriceFactorId bigint				--�������ͼ۸�����Id
	declare @pPriceFactorId bigint				--ֽ�ͼ۸�����Id
	declare @pcPriceFactorId bigint				--�ӹ���������Id
	
	set @mPriceFactorId=(select id from price_factor where target_table='MACHINE_TYPE' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @pPriceFactorId=(select id from price_factor where target_table='PAPER_SPECIFICATION' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @pcPriceFactorId=(select id from price_factor where target_table='PROCESS_CONTENT' and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)
	set @returnCount=0

	--��ȡ�ϴγ���ʱ��
	set @lastLogDateTime=(select RECORD_DATE_TIME from RECORD_MACHINE_WATCH where id=@LogCounterId and Company_Id=@CompanyId and Branch_Shop_Id=@BranchShopId)

	--��ȡ���ϴγ������������˵Ĺ���
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

	--��ȥδ�깤������ֽ����
	set @returnCount=@returnCount-isnull((select USED_PAPER_COUNT from UNCOMPLETE_ORDERS_USED_PAPER where id=@LogCounterId and Machine_id=@MachineId and PAPER_SPECIFICATION_Id=@PaperSpcId),0)
	select @returnCount
go

