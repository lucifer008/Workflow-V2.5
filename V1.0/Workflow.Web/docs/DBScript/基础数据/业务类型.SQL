
--select * from [BUSINESS_TYPE] 
DELETE [PROCESS_CONTENT]
DELETE [BUSINESS_TYPE]
INSERT [BUSINESS_TYPE] 
select 1,'��ӡ','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'��ӡ','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'ɨ��','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'���','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 5,'װ��','N',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'����ͼ','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 7,'����','N',getdate(),1,getdate(),1,1,0,1,1

Update ID_Generator set current_value=8 where Flag_No='BUSINESS_TYPE'



--select * from [PROCESS_CONTENT] 
 
insert [PROCESS_CONTENT] 
select 1,1,'001','�ڰ״�ӡ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 2,1,'002','��ɫ��ӡ',2,getdate(),1,getdate(),1,1,0,1,1
union
select 3,2,'003','�ڰ׸�ӡ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 4,2,'004','��ɫ��ӡ',2,getdate(),1,getdate(),1,1,0,1,1
union
select 5,3,'005','�ڰ�ɨ��',1,getdate(),1,getdate(),1,1,0,1,1
union
select 6,3,'006','��ɫɨ��',1,getdate(),1,getdate(),1,1,0,1,1
union
select 7,4,'007','Ч��ͼ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 8,4,'008','��ɫ����',1,getdate(),1,getdate(),1,1,0,1,1
union
select 9,5,'009','��װ��װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 10,5,'010','��������װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 11,5,'011','��������װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 12,5,'012','��װ����װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 13,5,'013','��װ����װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 14,5,'014','��Ƥ�⽺װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 15,5,'015','��Ƥ����װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 16,5,'016','���⸲Ĥ��װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 17,5,'017','Ƥ��ֽ��װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 18,5,'018','����װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 19,5,'019','��Ȧװ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 20,5,'020','����װ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 21,5,'021','������',1,getdate(),1,getdate(),1,1,0,1,1
union
select 22,6,'022','�ڰ�������ӡ��ӡ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 23,6,'023','�ڰ�ɫ���ӡ/��ӡ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 24,6,'024','ɹͼ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 25,7,'025','�̹���',1,getdate(),1,getdate(),1,1,0,1,1
union
select 26,7,'026','��ͼ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 27,7,'027','ƴ��',1,getdate(),1,getdate(),1,1,0,1,1
union
select 28,7,'028','������Ƭ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 29,7,'029','˫����Ƭ',1,getdate(),1,getdate(),1,1,0,1,1
union
select 30,7,'030','�Ѱ׿�',1,getdate(),1,getdate(),1,1,0,1,1
union
select 31,7,'031','�Ѱ�',1,getdate(),1,getdate(),1,1,0,1,1
union
select 32,7,'032','����',1,getdate(),1,getdate(),1,1,0,1,1
union
select 33,5,'033','��װ',1,getdate(),1,getdate(),1,1,0,1,1

Update ID_Generator set current_value=34 where Flag_No='PROCESS_CONTENT'
