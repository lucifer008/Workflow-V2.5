create table PROCESS_CONTENT_ACHIEVEMENT_RATE (
   ID                   bigint               not null,
   PROCESS_CONTENT_ID   bigint               not null,
   ACHIEVEMENT_VALUE    decimal(14,2)        null,
   MEMO                 nvarchar(200)        null,
   constraint PK_PROCESS_CONTENT_ACHIEVEMENT primary key nonclustered (ID)
)
go

alter table PROCESS_CONTENT_ACHIEVEMENT_RATE
   add constraint FK_PROCESS__RELATIONS_PROCESS_ foreign key (PROCESS_CONTENT_ID)
      references PROCESS_CONTENT (ID)
go

insert id_generator
select 94,'PROCESS_CONTENT_ACHIEVEMENT_RATE',1,1,2147483647,'',1


insert PROCESS_CONTENT_ACHIEVEMENT_RATE
select 1,1,1.00,'�ڰ״�ӡ'
union
select 2,2,1.00,'��ɫ��ӡ'
union
select 3,3,1.00,'�ڰ׸�ӡ'
union
select 4,4,1.00,'��ɫ��ӡ'
union
select 5,5,1.00,'�ڰ�ɨ��'
union
select 6,6,1.00,'��ɫɨ��'
union
select 7,7,0.80,'Ч��ͼ'
union
select 8,8,0.80,'��ɫ����'
union
select 9,9,0.20,'��װ��װ'
union
select 10,10,0.20,'��������װ'
union
select 11,11,0.20,'��������װ'
union
select 12,12,0.20,'��װ����װ'
union
select 13,13,0.20,'��װ����װ'
union
select 14,14,0.20,'����Ƥ��װ'
union
select 15,15,0.20,'����Ƥ��װ'
union
select 16,16,0.20,'���⸲Ĥ��װ'
union
select 17,17,0.20,'Ƥ��ֽ��װ'
union
select 18,18,0.00,'����װ'
union
select 19,19,0.20,'��Ȧװ'
union
select 20,20,0.00,'����װ'
union
select 21,21,0.00,'����'
union
select 22,22,1.00,'�ڰ�������ӡ��ӡ'
union
select 23,23,1.00,'�ڰ�ɫ���ӡ/��ӡ'
union
select 24,24,0.80,'ɹͼ'
union
select 25,25,0.00,'�̹���'
union
select 26,26,0.00,'��ͼ'
union
select 27,27,0.00,'ƴ��'
union
select 28,28,0.80,'������Ƭ'
union
select 29,29,0.80,'˫����Ƭ'
union
select 30,30,0.00,'�Ѱ׿�'
union
select 31,31,0.80,'�Ѱ�'
union
select 32,32,0.00,'����'
union
select 33,3,0.20,'��װ'

update id_generator set current_value=34 where flag_no='PROCESS_CONTENT_ACHIEVEMENT_RATE'








