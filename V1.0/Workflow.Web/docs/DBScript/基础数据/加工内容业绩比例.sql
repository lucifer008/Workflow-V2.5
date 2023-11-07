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
select 1,1,1.00,'黑白打印'
union
select 2,2,1.00,'彩色打印'
union
select 3,3,1.00,'黑白复印'
union
select 4,4,1.00,'彩色复印'
union
select 5,5,1.00,'黑白扫描'
union
select 6,6,1.00,'彩色扫描'
union
select 7,7,0.80,'效果图'
union
select 8,8,0.80,'彩色线条'
union
select 9,9,0.20,'胶装精装'
union
select 10,10,0.20,'内铁环精装'
union
select 11,11,0.20,'外铁环精装'
union
select 12,12,0.20,'精装蝴蝶装'
union
select 13,13,0.20,'软装蝴蝶装'
union
select 14,14,0.20,'激光皮胶装'
union
select 15,15,0.20,'背胶皮胶装'
union
select 16,16,0.20,'激光覆膜胶装'
union
select 17,17,0.20,'皮纹纸胶装'
union
select 18,18,0.00,'铁环装'
union
select 19,19,0.20,'胶圈装'
union
select 20,20,0.00,'夹条装'
union
select 21,21,0.00,'骑马订'
union
select 22,22,1.00,'黑白线条打印复印'
union
select 23,23,1.00,'黑白色块打印/复印'
union
select 24,24,0.80,'晒图'
union
select 25,25,0.00,'刻光盘'
union
select 26,26,0.00,'折图'
union
select 27,27,0.00,'拼版'
union
select 28,28,0.80,'单面名片'
union
select 29,29,0.80,'双面名片'
union
select 30,30,0.00,'裱白卡'
union
select 31,31,0.80,'裱板'
union
select 32,32,0.00,'其它'
union
select 33,3,0.20,'胶装'

update id_generator set current_value=34 where flag_no='PROCESS_CONTENT_ACHIEVEMENT_RATE'








