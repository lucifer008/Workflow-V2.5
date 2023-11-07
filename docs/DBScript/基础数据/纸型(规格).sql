--纸型
delete from PAPER_SPECIFICATION
insert PAPER_SPECIFICATION
select 1, '001', 'A0', getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 2, '002', 'A1', getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 3, '003', 'A2', getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 4, '004', 'A3', getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 5,'005','A3出血',getdate(),1,getdate(),1,1,0,1,1
union
select 6, '006', 'A4', getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 7,'007','不规则尺寸',getdate(), 1, getdate(), 1, 1, 0, 1, 1
union
select 8,'008','无关',getdate(), 1, getdate(), 1, 1, 0, 1, 1
update id_generator set current_value=9 where flag_no='PAPER_SPECIFICATION'




