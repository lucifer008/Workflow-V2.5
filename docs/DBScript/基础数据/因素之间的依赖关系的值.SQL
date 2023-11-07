SELECT * FROM PRICE_FACTOR
SELECT * FROM process_content
select * from PAPER_SPECIFICATION

SELECT * FROM machine_type
select * from paper_type
SELECT * FROM [FACTOR_RELATION]
SELECT * FROM [FACTOR_RELATION_VALUES]


DELETE [FACTOR_RELATION_VALUES] 
insert [FACTOR_RELATION_VALUES] 
 -- Id,依赖关系Id,彩色打印在加工内容中的ID,DC8000在Machine_Type中的ID,...例如加工内容中彩色打印，只能用DC8000
--黑白打印可以使用的机器
select 1,1,1,1,getdate(),1,getdate(),1,1,0,1,1
union
select 2,1,1,2,getdate(),1,getdate(),1,1,0,1,1
union
select 3,1,1,3,getdate(),1,getdate(),1,1,0,1,1
union
select 4,1,1,4,getdate(),1,getdate(),1,1,0,1,1
union
select 5,1,1,5,getdate(),1,getdate(),1,1,0,1,1
union
select 6,1,1,6,getdate(),1,getdate(),1,1,0,1,1
union
select 7,1,1,7,getdate(),1,getdate(),1,1,0,1,1
union
select 8,1,1,8,getdate(),1,getdate(),1,1,0,1,1
--彩色打印可以使用的机器
union
select 9,1,2,1,getdate(),1,getdate(),1,1,0,1,1
union
select 10,1,2,2,getdate(),1,getdate(),1,1,0,1,1
union
select 11,1,2,3,getdate(),1,getdate(),1,1,0,1,1
union
select 12,1,2,4,getdate(),1,getdate(),1,1,0,1,1
--黑白复印可以使用的机器
union
select 13,4,3,4,getdate(),1,getdate(),1,1,0,1,1
union
select 14,4,3,5,getdate(),1,getdate(),1,1,0,1,1
union
select 15,4,3,6,getdate(),1,getdate(),1,1,0,1,1
union
select 16,4,3,7,getdate(),1,getdate(),1,1,0,1,1
union
select 17,4,3,8,getdate(),1,getdate(),1,1,0,1,1
union
select 18,4,3,9,getdate(),1,getdate(),1,1,0,1,1
union
select 19,4,3,13,getdate(),1,getdate(),1,1,0,1,1
--彩色复印可以使用的机器
union
select 20,4,4,4,getdate(),1,getdate(),1,1,0,1,1
--黑白扫描可以使用的机器
union
select 21,7,5,5,getdate(),1,getdate(),1,1,0,1,1
union
select 22,7,5,13,getdate(),1,getdate(),1,1,0,1,1
union
select 23,7,5,14,getdate(),1,getdate(),1,1,0,1,1
union
select 443,7,5,7,getdate(),1,getdate(),1,1,0,1,1
--彩色扫描可以使用的机器
union
select 24,7,6,13,getdate(),1,getdate(),1,1,0,1,1


--高光相纸写真喷绘可以使用的机器
union
select 25,10,7,10,getdate(),1,getdate(),1,1,0,1,1
union
select 26,10,7,11,getdate(),1,getdate(),1,1,0,1,1
union
select 27,10,7,12,getdate(),1,getdate(),1,1,0,1,1
--工程纸写真喷绘可以使用的机器
union
select 28,10,8,10,getdate(),1,getdate(),1,1,0,1,1
union
select 29,10,8,11,getdate(),1,getdate(),1,1,0,1,1
union
select 30,10,8,12,getdate(),1,getdate(),1,1,0,1,1
--胶装精装 可以使用的纸型
union
select 31,13,9,4,getdate(),1,getdate(),1,1,0,1,1
union
select 32,13,9,6,getdate(),1,getdate(),1,1,0,1,1
union
select 405,13,9,3,getdate(),1,getdate(),1,1,0,1,1
--内铁环精装 可以使用的纸型
union
select 33,13,10,4,getdate(),1,getdate(),1,1,0,1,1
union
select 34,13,10,6,getdate(),1,getdate(),1,1,0,1,1
--外铁环精装 可以使用的纸型
union
select 35,13,11,4,getdate(),1,getdate(),1,1,0,1,1
union
select 36,13,11,6,getdate(),1,getdate(),1,1,0,1,1
--精装蝴蝶装 可以使用的纸型
union
select 37,13,12,4,getdate(),1,getdate(),1,1,0,1,1
union
select 38,13,12,6,getdate(),1,getdate(),1,1,0,1,1
--软装蝴蝶装 可以使用的纸型
union
select 39,13,13,4,getdate(),1,getdate(),1,1,0,1,1
union
select 40,13,13,6,getdate(),1,getdate(),1,1,0,1,1
--激光胶装 可以使用的纸型
union
select 41,13,14,4,getdate(),1,getdate(),1,1,0,1,1
union
select 42,13,14,6,getdate(),1,getdate(),1,1,0,1,1
--背胶胶装 可以使用的纸型
union
select 43,13,15,4,getdate(),1,getdate(),1,1,0,1,1
union
select 44,13,15,6,getdate(),1,getdate(),1,1,0,1,1
--激光覆膜胶装 可以使用的纸型
union
select 45,13,16,4,getdate(),1,getdate(),1,1,0,1,1
union
select 46,13,16,6,getdate(),1,getdate(),1,1,0,1,1
--皮纹纸胶装 可以使用的纸型
union
select 47,13,17,4,getdate(),1,getdate(),1,1,0,1,1
union
select 48,13,17,6,getdate(),1,getdate(),1,1,0,1,1
--铁环装 可以使用的纸型
union
select 49,13,18,4,getdate(),1,getdate(),1,1,0,1,1
union
select 50,13,18,6,getdate(),1,getdate(),1,1,0,1,1
--胶圈装 可以使用的纸型
union
select 51,13,19,4,getdate(),1,getdate(),1,1,0,1,1
union
select 52,13,19,6,getdate(),1,getdate(),1,1,0,1,1
--夹条装 可以使用的纸型
union
select 53,13,20,4,getdate(),1,getdate(),1,1,0,1,1
union
select 54,13,20,6,getdate(),1,getdate(),1,1,0,1,1
--骑马订 可以使用的纸型
union
select 55,13,21,6,getdate(),1,getdate(),1,1,0,1,1
--胶装 可以使用的纸型
union
select 402,13,33,4,getdate(),1,getdate(),1,1,0,1,1
union
select 403,13,33,6,getdate(),1,getdate(),1,1,0,1,1


--黑白线条打印复印 可以使用的机器
union
select 56,14,22,13,getdate(),1,getdate(),1,1,0,1,1
--黑白色块打印/复印 可以使用的机器
union
select 57,14,23,13,getdate(),1,getdate(),1,1,0,1,1
--晒图 可以使用的机器
union
select 58,14,24,15,getdate(),1,getdate(),1,1,0,1,1

--刻光盘 可以使用的纸型
union
select 59,17,25,8,getdate(),1,getdate(),1,1,0,1,1
--折图 可以使用的纸型
union
select 60,17,26,8,getdate(),1,getdate(),1,1,0,1,1
--拼版 可以使用的纸型
union
select 61,17,27,8,getdate(),1,getdate(),1,1,0,1,1
--单面名片 可以使用的纸型
union
select 62,17,28,8,getdate(),1,getdate(),1,1,0,1,1
--双面名片 可以使用的纸型
union
select 63,17,29,8,getdate(),1,getdate(),1,1,0,1,1
--裱白卡 可以使用的纸型
union
select 64,17,30,4,getdate(),1,getdate(),1,1,0,1,1
union
select 65,17,30,6,getdate(),1,getdate(),1,1,0,1,1
--裱板 可以使用的纸型
union
select 66,17,31,1,getdate(),1,getdate(),1,1,0,1,1
union
select 67,17,31,2,getdate(),1,getdate(),1,1,0,1,1
union
select 68,17,31,3,getdate(),1,getdate(),1,1,0,1,1
union
select 69,17,31,4,getdate(),1,getdate(),1,1,0,1,1
union
select 70,17,31,6,getdate(),1,getdate(),1,1,0,1,1
--其它 可以使用的纸型
union
select 71,17,32,8,getdate(),1,getdate(),1,1,0,1,1
--DC8000可以使用的纸质
union
select 72,2,1,1,getdate(),1,getdate(),1,1,0,1,1
union
select 73,2,1,2,getdate(),1,getdate(),1,1,0,1,1
union
select 74,2,1,3,getdate(),1,getdate(),1,1,0,1,1
union
select 75,2,1,4,getdate(),1,getdate(),1,1,0,1,1
union
select 76,2,1,5,getdate(),1,getdate(),1,1,0,1,1
union
select 77,2,1,6,getdate(),1,getdate(),1,1,0,1,1
union
select 78,2,1,7,getdate(),1,getdate(),1,1,0,1,1
union
select 79,2,1,8,getdate(),1,getdate(),1,1,0,1,1
union
select 80,2,1,9,getdate(),1,getdate(),1,1,0,1,1
union
select 81,2,1,10,getdate(),1,getdate(),1,1,0,1,1
union
select 82,2,1,11,getdate(),1,getdate(),1,1,0,1,1
union
select 83,2,1,12,getdate(),1,getdate(),1,1,0,1,1
union
select 84,2,1,13,getdate(),1,getdate(),1,1,0,1,1
union
select 85,2,1,14,getdate(),1,getdate(),1,1,0,1,1
union
select 86,2,1,15,getdate(),1,getdate(),1,1,0,1,1
union
select 87,2,1,16,getdate(),1,getdate(),1,1,0,1,1
union
select 88,2,1,17,getdate(),1,getdate(),1,1,0,1,1
union
select 89,2,1,18,getdate(),1,getdate(),1,1,0,1,1
union
select 90,2,1,21,getdate(),1,getdate(),1,1,0,1,1
union
select 91,2,1,23,getdate(),1,getdate(),1,1,0,1,1
union
select 92,2,1,24,getdate(),1,getdate(),1,1,0,1,1
--DC2060可以使用的纸质
union
select 93,2,2,1,getdate(),1,getdate(),1,1,0,1,1
union
select 94,2,2,2,getdate(),1,getdate(),1,1,0,1,1
union
select 95,2,2,3,getdate(),1,getdate(),1,1,0,1,1
union
select 96,2,2,4,getdate(),1,getdate(),1,1,0,1,1
union
select 97,2,2,5,getdate(),1,getdate(),1,1,0,1,1
union
select 98,2,2,6,getdate(),1,getdate(),1,1,0,1,1
union
select 99,2,2,7,getdate(),1,getdate(),1,1,0,1,1
union
select 100,2,2,8,getdate(),1,getdate(),1,1,0,1,1
union
select 101,2,2,9,getdate(),1,getdate(),1,1,0,1,1
union
select 102,2,2,10,getdate(),1,getdate(),1,1,0,1,1
union
select 103,2,2,11,getdate(),1,getdate(),1,1,0,1,1
union
select 104,2,2,12,getdate(),1,getdate(),1,1,0,1,1
union
select 105,2,2,13,getdate(),1,getdate(),1,1,0,1,1
union
select 106,2,2,14,getdate(),1,getdate(),1,1,0,1,1
union
select 107,2,2,15,getdate(),1,getdate(),1,1,0,1,1
union
select 108,2,2,16,getdate(),1,getdate(),1,1,0,1,1
union
select 109,2,2,17,getdate(),1,getdate(),1,1,0,1,1
union
select 110,2,2,18,getdate(),1,getdate(),1,1,0,1,1
union
select 111,2,2,21,getdate(),1,getdate(),1,1,0,1,1
union
select 112,2,2,23,getdate(),1,getdate(),1,1,0,1,1
union
select 113,2,2,24,getdate(),1,getdate(),1,1,0,1,1
--DC1255可以使用的纸质
union
select 114,2,3,1,getdate(),1,getdate(),1,1,0,1,1
union
select 115,2,3,2,getdate(),1,getdate(),1,1,0,1,1
union
select 116,2,3,3,getdate(),1,getdate(),1,1,0,1,1
union
select 117,2,3,4,getdate(),1,getdate(),1,1,0,1,1
union
select 118,2,3,5,getdate(),1,getdate(),1,1,0,1,1
union
select 119,2,3,6,getdate(),1,getdate(),1,1,0,1,1
union
select 120,2,3,7,getdate(),1,getdate(),1,1,0,1,1
union
select 121,2,3,8,getdate(),1,getdate(),1,1,0,1,1
union
select 122,2,3,9,getdate(),1,getdate(),1,1,0,1,1
union
select 123,2,3,10,getdate(),1,getdate(),1,1,0,1,1
union
select 124,2,3,11,getdate(),1,getdate(),1,1,0,1,1
union
select 125,2,3,12,getdate(),1,getdate(),1,1,0,1,1
union
select 126,2,3,13,getdate(),1,getdate(),1,1,0,1,1
union
select 127,2,3,14,getdate(),1,getdate(),1,1,0,1,1
union
select 128,2,3,15,getdate(),1,getdate(),1,1,0,1,1
union
select 129,2,3,16,getdate(),1,getdate(),1,1,0,1,1
union
select 130,2,3,17,getdate(),1,getdate(),1,1,0,1,1
union
select 131,2,3,18,getdate(),1,getdate(),1,1,0,1,1
union
select 132,2,3,21,getdate(),1,getdate(),1,1,0,1,1
union
select 133,2,3,23,getdate(),1,getdate(),1,1,0,1,1
union
select 134,2,3,24,getdate(),1,getdate(),1,1,0,1,1
--DC1250可以使用的纸质
union
select 135,2,4,1,getdate(),1,getdate(),1,1,0,1,1
union
select 136,2,4,2,getdate(),1,getdate(),1,1,0,1,1
union
select 137,2,4,3,getdate(),1,getdate(),1,1,0,1,1
union
select 138,2,4,4,getdate(),1,getdate(),1,1,0,1,1
union
select 139,2,4,5,getdate(),1,getdate(),1,1,0,1,1
union
select 140,2,4,6,getdate(),1,getdate(),1,1,0,1,1
union
select 141,2,4,7,getdate(),1,getdate(),1,1,0,1,1
union
select 142,2,4,8,getdate(),1,getdate(),1,1,0,1,1
union
select 143,2,4,9,getdate(),1,getdate(),1,1,0,1,1
union
select 144,2,4,10,getdate(),1,getdate(),1,1,0,1,1
union
select 145,2,4,11,getdate(),1,getdate(),1,1,0,1,1
union
select 146,2,4,12,getdate(),1,getdate(),1,1,0,1,1
union
select 147,2,4,13,getdate(),1,getdate(),1,1,0,1,1
union
select 148,2,4,14,getdate(),1,getdate(),1,1,0,1,1
union
select 149,2,4,15,getdate(),1,getdate(),1,1,0,1,1
union
select 150,2,4,16,getdate(),1,getdate(),1,1,0,1,1
union
select 151,2,4,17,getdate(),1,getdate(),1,1,0,1,1
union
select 152,2,4,18,getdate(),1,getdate(),1,1,0,1,1
union
select 153,2,4,21,getdate(),1,getdate(),1,1,0,1,1
union
select 155,2,4,23,getdate(),1,getdate(),1,1,0,1,1
union
select 156,2,4,24,getdate(),1,getdate(),1,1,0,1,1
--DC900可以使用的纸质
union
select 157,2,5,1,getdate(),1,getdate(),1,1,0,1,1
union
select 158,2,5,2,getdate(),1,getdate(),1,1,0,1,1
union
select 159,2,5,3,getdate(),1,getdate(),1,1,0,1,1
union
select 160,2,5,4,getdate(),1,getdate(),1,1,0,1,1
union
select 161,2,5,5,getdate(),1,getdate(),1,1,0,1,1
union
select 162,2,5,6,getdate(),1,getdate(),1,1,0,1,1
union
select 163,2,5,21,getdate(),1,getdate(),1,1,0,1,1
union
select 164,2,5,23,getdate(),1,getdate(),1,1,0,1,1
union
select 165,2,5,24,getdate(),1,getdate(),1,1,0,1,1
union
select 377,2,5,7,getdate(),1,getdate(),1,1,0,1,1
union
select 378,2,5,8,getdate(),1,getdate(),1,1,0,1,1
union
select 379,2,5,11,getdate(),1,getdate(),1,1,0,1,1
union
select 380,2,5,12,getdate(),1,getdate(),1,1,0,1,1
union
select 381,2,5,15,getdate(),1,getdate(),1,1,0,1,1
union
select 382,2,5,16,getdate(),1,getdate(),1,1,0,1,1


--8060可以使用的纸质
union
select 166,2,6,1,getdate(),1,getdate(),1,1,0,1,1
union
select 167,2,6,2,getdate(),1,getdate(),1,1,0,1,1
union
select 168,2,6,3,getdate(),1,getdate(),1,1,0,1,1
union
select 169,2,6,4,getdate(),1,getdate(),1,1,0,1,1
union
select 170,2,6,5,getdate(),1,getdate(),1,1,0,1,1
union
select 171,2,6,6,getdate(),1,getdate(),1,1,0,1,1
union
select 172,2,6,21,getdate(),1,getdate(),1,1,0,1,1
union
select 173,2,6,23,getdate(),1,getdate(),1,1,0,1,1
union
select 174,2,6,24,getdate(),1,getdate(),1,1,0,1,1
union
select 383,2,6,7,getdate(),1,getdate(),1,1,0,1,1
union
select 384,2,6,8,getdate(),1,getdate(),1,1,0,1,1
union
select 385,2,6,11,getdate(),1,getdate(),1,1,0,1,1
union
select 386,2,6,12,getdate(),1,getdate(),1,1,0,1,1
union
select 387,2,6,15,getdate(),1,getdate(),1,1,0,1,1
union
select 388,2,6,16,getdate(),1,getdate(),1,1,0,1,1

--2035可以使用的纸质
union
select 175,2,7,1,getdate(),1,getdate(),1,1,0,1,1
union
select 176,2,7,2,getdate(),1,getdate(),1,1,0,1,1
union
select 177,2,7,3,getdate(),1,getdate(),1,1,0,1,1
union
select 178,2,7,4,getdate(),1,getdate(),1,1,0,1,1
union
select 179,2,7,5,getdate(),1,getdate(),1,1,0,1,1
union
select 180,2,7,6,getdate(),1,getdate(),1,1,0,1,1
union
select 181,2,7,21,getdate(),1,getdate(),1,1,0,1,1
union
select 182,2,7,23,getdate(),1,getdate(),1,1,0,1,1
union
select 183,2,7,24,getdate(),1,getdate(),1,1,0,1,1
union
select 389,2,7,7,getdate(),1,getdate(),1,1,0,1,1
union
select 390,2,7,8,getdate(),1,getdate(),1,1,0,1,1
union
select 391,2,7,11,getdate(),1,getdate(),1,1,0,1,1
union
select 392,2,7,12,getdate(),1,getdate(),1,1,0,1,1
union
select 393,2,7,15,getdate(),1,getdate(),1,1,0,1,1
union
select 394,2,7,16,getdate(),1,getdate(),1,1,0,1,1
--4035可以使用的纸质
union
select 184,2,8,1,getdate(),1,getdate(),1,1,0,1,1
union
select 185,2,8,2,getdate(),1,getdate(),1,1,0,1,1
union
select 186,2,8,3,getdate(),1,getdate(),1,1,0,1,1
union
select 187,2,8,4,getdate(),1,getdate(),1,1,0,1,1
union
select 188,2,8,5,getdate(),1,getdate(),1,1,0,1,1
union
select 189,2,8,6,getdate(),1,getdate(),1,1,0,1,1
union
select 190,2,8,21,getdate(),1,getdate(),1,1,0,1,1
union
select 191,2,8,23,getdate(),1,getdate(),1,1,0,1,1
union
select 192,2,8,24,getdate(),1,getdate(),1,1,0,1,1
union
select 395,2,8,7,getdate(),1,getdate(),1,1,0,1,1
union
select 396,2,8,8,getdate(),1,getdate(),1,1,0,1,1
union
select 397,2,8,11,getdate(),1,getdate(),1,1,0,1,1
union
select 398,2,8,12,getdate(),1,getdate(),1,1,0,1,1
union
select 399,2,8,15,getdate(),1,getdate(),1,1,0,1,1
union
select 400,2,8,16,getdate(),1,getdate(),1,1,0,1,1

--DC8000可以使用的纸型
union
select 193,3,1,4,getdate(),1,getdate(),1,1,0,1,1
union
select 194,3,1,5,getdate(),1,getdate(),1,1,0,1,1
union
select 195,3,1,6,getdate(),1,getdate(),1,1,0,1,1
--DC2060可以使用的纸型
union
select 196,3,2,4,getdate(),1,getdate(),1,1,0,1,1
union
select 197,3,2,5,getdate(),1,getdate(),1,1,0,1,1
union
select 198,3,2,6,getdate(),1,getdate(),1,1,0,1,1
--DC1255可以使用的纸型
union
select 199,3,3,4,getdate(),1,getdate(),1,1,0,1,1
union
select 200,3,3,5,getdate(),1,getdate(),1,1,0,1,1
union
select 201,3,3,6,getdate(),1,getdate(),1,1,0,1,1
--DC1250可以使用的纸型
union
select 202,3,4,4,getdate(),1,getdate(),1,1,0,1,1
union
select 203,3,4,5,getdate(),1,getdate(),1,1,0,1,1
union
select 204,3,4,6,getdate(),1,getdate(),1,1,0,1,1
--DC900可以使用的纸型
union
select 205,3,5,4,getdate(),1,getdate(),1,1,0,1,1
union
select 206,3,5,5,getdate(),1,getdate(),1,1,0,1,1
union
select 207,3,5,6,getdate(),1,getdate(),1,1,0,1,1
--8060可以使用的纸型
union
select 208,3,6,4,getdate(),1,getdate(),1,1,0,1,1
union
select 209,3,6,5,getdate(),1,getdate(),1,1,0,1,1
union
select 210,3,6,6,getdate(),1,getdate(),1,1,0,1,1
--2035可以使用的纸型
union
select 211,3,7,4,getdate(),1,getdate(),1,1,0,1,1
union
select 212,3,7,5,getdate(),1,getdate(),1,1,0,1,1
union
select 213,3,7,6,getdate(),1,getdate(),1,1,0,1,1
--4035可以使用的纸型
union
select 214,3,8,4,getdate(),1,getdate(),1,1,0,1,1
union
select 215,3,8,5,getdate(),1,getdate(),1,1,0,1,1
union
select 216,3,8,6,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:DC1250可以使用的纸质
union
select 217,5,4,1,getdate(),1,getdate(),1,1,0,1,1
union
select 218,5,4,2,getdate(),1,getdate(),1,1,0,1,1
union
select 219,5,4,3,getdate(),1,getdate(),1,1,0,1,1
union
select 220,5,4,4,getdate(),1,getdate(),1,1,0,1,1
union
select 221,5,4,5,getdate(),1,getdate(),1,1,0,1,1
union
select 222,5,4,6,getdate(),1,getdate(),1,1,0,1,1
union
select 223,5,4,22,getdate(),1,getdate(),1,1,0,1,1
union
select 224,5,4,23,getdate(),1,getdate(),1,1,0,1,1
union
select 225,5,4,24,getdate(),1,getdate(),1,1,0,1,1
union
select 226,5,4,7,getdate(),1,getdate(),1,1,0,1,1
union
select 227,5,4,8,getdate(),1,getdate(),1,1,0,1,1
union
select 228,5,4,9,getdate(),1,getdate(),1,1,0,1,1
union
select 229,5,4,10,getdate(),1,getdate(),1,1,0,1,1
union
select 230,5,4,11,getdate(),1,getdate(),1,1,0,1,1
union
select 231,5,4,12,getdate(),1,getdate(),1,1,0,1,1
union
select 232,5,4,13,getdate(),1,getdate(),1,1,0,1,1
union
select 233,5,4,14,getdate(),1,getdate(),1,1,0,1,1
union
select 234,5,4,15,getdate(),1,getdate(),1,1,0,1,1
union
select 235,5,4,16,getdate(),1,getdate(),1,1,0,1,1
union
select 236,5,4,17,getdate(),1,getdate(),1,1,0,1,1
union
select 237,5,4,18,getdate(),1,getdate(),1,1,0,1,1
union
select 437,5,4,21,getdate(),1,getdate(),1,1,0,1,1


--黑白复印:DC900可以使用的纸质
union
select 238,5,5,1,getdate(),1,getdate(),1,1,0,1,1
union
select 239,5,5,2,getdate(),1,getdate(),1,1,0,1,1
union
select 240,5,5,3,getdate(),1,getdate(),1,1,0,1,1
union
select 241,5,5,4,getdate(),1,getdate(),1,1,0,1,1
union
select 242,5,5,5,getdate(),1,getdate(),1,1,0,1,1
union
select 243,5,5,6,getdate(),1,getdate(),1,1,0,1,1
union
select 244,5,5,22,getdate(),1,getdate(),1,1,0,1,1
union
select 245,5,5,23,getdate(),1,getdate(),1,1,0,1,1
union
select 246,5,5,24,getdate(),1,getdate(),1,1,0,1,1
union
select 407,5,5,7,getdate(),1,getdate(),1,1,0,1,1
union
select 408,5,5,8,getdate(),1,getdate(),1,1,0,1,1
union
select 409,5,5,9,getdate(),1,getdate(),1,1,0,1,1
union
select 410,5,5,11,getdate(),1,getdate(),1,1,0,1,1
union
select 411,5,5,12,getdate(),1,getdate(),1,1,0,1,1
union
select 412,5,5,13,getdate(),1,getdate(),1,1,0,1,1
union
select 438,5,5,21,getdate(),1,getdate(),1,1,0,1,1


--黑白复印:8060可以使用的纸质
union
select 247,5,6,1,getdate(),1,getdate(),1,1,0,1,1
union
select 248,5,6,2,getdate(),1,getdate(),1,1,0,1,1
union
select 249,5,6,3,getdate(),1,getdate(),1,1,0,1,1
union
select 250,5,6,4,getdate(),1,getdate(),1,1,0,1,1
union
select 251,5,6,5,getdate(),1,getdate(),1,1,0,1,1
union
select 252,5,6,6,getdate(),1,getdate(),1,1,0,1,1
union
select 253,5,6,22,getdate(),1,getdate(),1,1,0,1,1
union
select 254,5,6,23,getdate(),1,getdate(),1,1,0,1,1
union
select 255,5,6,24,getdate(),1,getdate(),1,1,0,1,1
union
select 413,5,6,7,getdate(),1,getdate(),1,1,0,1,1
union
select 414,5,6,8,getdate(),1,getdate(),1,1,0,1,1
union
select 415,5,6,9,getdate(),1,getdate(),1,1,0,1,1
union
select 416,5,6,11,getdate(),1,getdate(),1,1,0,1,1
union
select 417,5,6,12,getdate(),1,getdate(),1,1,0,1,1
union
select 418,5,6,13,getdate(),1,getdate(),1,1,0,1,1
union
select 439,5,6,21,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:2035可以使用的纸质
union
select 256,5,7,1,getdate(),1,getdate(),1,1,0,1,1
union
select 257,5,7,2,getdate(),1,getdate(),1,1,0,1,1
union
select 258,5,7,3,getdate(),1,getdate(),1,1,0,1,1
union
select 259,5,7,4,getdate(),1,getdate(),1,1,0,1,1
union
select 260,5,7,5,getdate(),1,getdate(),1,1,0,1,1
union
select 261,5,7,6,getdate(),1,getdate(),1,1,0,1,1
union
select 262,5,7,22,getdate(),1,getdate(),1,1,0,1,1
union
select 263,5,7,23,getdate(),1,getdate(),1,1,0,1,1
union
select 264,5,7,24,getdate(),1,getdate(),1,1,0,1,1
union
select 419,5,7,7,getdate(),1,getdate(),1,1,0,1,1
union
select 420,5,7,8,getdate(),1,getdate(),1,1,0,1,1
union
select 421,5,7,9,getdate(),1,getdate(),1,1,0,1,1
union
select 422,5,7,11,getdate(),1,getdate(),1,1,0,1,1
union
select 423,5,7,12,getdate(),1,getdate(),1,1,0,1,1
union
select 424,5,7,13,getdate(),1,getdate(),1,1,0,1,1
union
select 440,5,7,21,getdate(),1,getdate(),1,1,0,1,1

--黑白复印:4035可以使用的纸质
union
select 265,5,8,1,getdate(),1,getdate(),1,1,0,1,1
union
select 266,5,8,2,getdate(),1,getdate(),1,1,0,1,1
union
select 267,5,8,3,getdate(),1,getdate(),1,1,0,1,1
union
select 268,5,8,4,getdate(),1,getdate(),1,1,0,1,1
union
select 269,5,8,5,getdate(),1,getdate(),1,1,0,1,1
union
select 270,5,8,6,getdate(),1,getdate(),1,1,0,1,1
union
select 271,5,8,22,getdate(),1,getdate(),1,1,0,1,1
union
select 272,5,8,23,getdate(),1,getdate(),1,1,0,1,1
union
select 273,5,8,24,getdate(),1,getdate(),1,1,0,1,1
union
select 425,5,8,7,getdate(),1,getdate(),1,1,0,1,1
union
select 426,5,8,8,getdate(),1,getdate(),1,1,0,1,1
union
select 427,5,8,9,getdate(),1,getdate(),1,1,0,1,1
union
select 428,5,8,11,getdate(),1,getdate(),1,1,0,1,1
union
select 429,5,8,12,getdate(),1,getdate(),1,1,0,1,1
union
select 430,5,8,13,getdate(),1,getdate(),1,1,0,1,1
union
select 441,5,8,21,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:1055可以使用的纸质
union
select 274,5,9,1,getdate(),1,getdate(),1,1,0,1,1
union
select 275,5,9,2,getdate(),1,getdate(),1,1,0,1,1
union
select 276,5,9,3,getdate(),1,getdate(),1,1,0,1,1
union
select 277,5,9,4,getdate(),1,getdate(),1,1,0,1,1
union
select 278,5,9,5,getdate(),1,getdate(),1,1,0,1,1
union
select 279,5,9,6,getdate(),1,getdate(),1,1,0,1,1
union
select 280,5,9,22,getdate(),1,getdate(),1,1,0,1,1
union
select 281,5,9,23,getdate(),1,getdate(),1,1,0,1,1
union
select 282,5,9,24,getdate(),1,getdate(),1,1,0,1,1
union
select 431,5,9,7,getdate(),1,getdate(),1,1,0,1,1
union
select 432,5,9,8,getdate(),1,getdate(),1,1,0,1,1
union
select 433,5,9,9,getdate(),1,getdate(),1,1,0,1,1
union
select 434,5,9,11,getdate(),1,getdate(),1,1,0,1,1
union
select 435,5,9,12,getdate(),1,getdate(),1,1,0,1,1
union
select 436,5,9,13,getdate(),1,getdate(),1,1,0,1,1
union
select 442,5,9,21,getdate(),1,getdate(),1,1,0,1,1

--黑白复印:4850可以使用的纸质
union
select 283,5,13,1,getdate(),1,getdate(),1,1,0,1,1
union
select 284,5,13,2,getdate(),1,getdate(),1,1,0,1,1
union
select 285,5,13,3,getdate(),1,getdate(),1,1,0,1,1
union
select 286,5,13,4,getdate(),1,getdate(),1,1,0,1,1
union
select 287,5,13,5,getdate(),1,getdate(),1,1,0,1,1
union
select 288,5,13,6,getdate(),1,getdate(),1,1,0,1,1
union
select 289,5,13,22,getdate(),1,getdate(),1,1,0,1,1
union
select 290,5,13,23,getdate(),1,getdate(),1,1,0,1,1
union
select 291,5,13,24,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:DC1250可以使用的纸型
union
select 292,6,4,4,getdate(),1,getdate(),1,1,0,1,1
union
select 293,6,4,5,getdate(),1,getdate(),1,1,0,1,1
union
select 294,6,4,6,getdate(),1,getdate(),1,1,0,1,1
union
select 295,6,4,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:DC900可以使用的纸型
union
select 296,6,5,4,getdate(),1,getdate(),1,1,0,1,1
union
select 297,6,5,5,getdate(),1,getdate(),1,1,0,1,1
union
select 298,6,5,6,getdate(),1,getdate(),1,1,0,1,1
union
select 299,6,5,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:8060可以使用的纸型
union
select 300,6,6,4,getdate(),1,getdate(),1,1,0,1,1
union
select 301,6,6,5,getdate(),1,getdate(),1,1,0,1,1
union
select 302,6,6,6,getdate(),1,getdate(),1,1,0,1,1
union
select 303,6,6,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:2035可以使用的纸型
union
select 304,6,7,4,getdate(),1,getdate(),1,1,0,1,1
union
select 305,6,7,5,getdate(),1,getdate(),1,1,0,1,1
union
select 306,6,7,6,getdate(),1,getdate(),1,1,0,1,1
union
select 307,6,7,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:4035可以使用的纸型
union
select 308,6,8,4,getdate(),1,getdate(),1,1,0,1,1
union
select 309,6,8,5,getdate(),1,getdate(),1,1,0,1,1
union
select 310,6,8,6,getdate(),1,getdate(),1,1,0,1,1
union
select 311,6,8,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:1055可以使用的纸型
union
select 312,6,9,4,getdate(),1,getdate(),1,1,0,1,1
union
select 313,6,9,5,getdate(),1,getdate(),1,1,0,1,1
union
select 314,6,9,6,getdate(),1,getdate(),1,1,0,1,1
union
select 315,6,9,7,getdate(),1,getdate(),1,1,0,1,1
--黑白复印:4850可以使用的纸型
union
select 316,6,13,4,getdate(),1,getdate(),1,1,0,1,1
union
select 317,6,13,5,getdate(),1,getdate(),1,1,0,1,1
union
select 318,6,13,6,getdate(),1,getdate(),1,1,0,1,1
union
select 319,6,13,7,getdate(),1,getdate(),1,1,0,1,1
--彩色扫描:4850可以使用的纸质
--union
--select 320,8,13,22,getdate(),1,getdate(),1,1,0,1,1
--彩色扫描:4850可以使用的纸型
union
select 321,9,13,1,getdate(),1,getdate(),1,1,0,1,1
union
select 322,9,13,2,getdate(),1,getdate(),1,1,0,1,1
union
select 323,9,13,3,getdate(),1,getdate(),1,1,0,1,1
union
select 324,9,13,7,getdate(),1,getdate(),1,1,0,1,1
union
select 444,9,13,4,getdate(),1,getdate(),1,1,0,1,1
union
select 445,9,13,6,getdate(),1,getdate(),1,1,0,1,1


----黑白扫描:DC900可以使用的纸质
--union
--select 325,8,5,1,getdate(),1,getdate(),1,1,0,1,1
--union
--select 326,8,5,2,getdate(),1,getdate(),1,1,0,1,1
----黑白扫描:4850可以使用的纸质
--union
--select 327,8,13,1,getdate(),1,getdate(),1,1,0,1,1
--union
--select 328,8,13,2,getdate(),1,getdate(),1,1,0,1,1
----黑白扫描:明基5000可以使用的纸质
--union
--select 329,8,14,1,getdate(),1,getdate(),1,1,0,1,1
--union
--select 330,8,14,2,getdate(),1,getdate(),1,1,0,1,1
--黑白扫描:DC900可以使用的纸型
union
select 331,9,5,6,getdate(),1,getdate(),1,1,0,1,1
union
insert FACTOR_RELATION_VALUES
select 446,9,5,4,getdate(),1,getdate(),1,1,0,1,1
--A4扫描:4850可以使用的纸型
--union
--select 332,9,13,6,getdate(),1,getdate(),1,1,0,1,1
--A4扫描:明基5000可以使用的纸型
union
select 333,9,14,6,getdate(),1,getdate(),1,1,0,1,1
union
select 447,9,14,4,getdate(),1,getdate(),1,1,0,1,1
--黑白扫描:2035可以使用的纸型
union
select 448,9,7,4,getdate(),1,getdate(),1,1,0,1,1
union
select 449,9,7,6,getdate(),1,getdate(),1,1,0,1,1


--高光相纸写真喷绘:HP5500可以使用的纸质
union
select 334,11,10,22,getdate(),1,getdate(),1,1,0,1,1
union
select 335,11,10,19,getdate(),1,getdate(),1,1,0,1,1
union
select 336,11,10,20,getdate(),1,getdate(),1,1,0,1,1
union
select 337,11,10,25,getdate(),1,getdate(),1,1,0,1,1
--高光相纸写真喷绘:EP1060可以使用的纸质
union
select 338,11,11,22,getdate(),1,getdate(),1,1,0,1,1
union
select 339,11,11,19,getdate(),1,getdate(),1,1,0,1,1
union
select 340,11,11,20,getdate(),1,getdate(),1,1,0,1,1
union
select 341,11,11,25,getdate(),1,getdate(),1,1,0,1,1
--高光相纸写真喷绘:Canon8400可以使用的纸质
union
select 342,11,12,22,getdate(),1,getdate(),1,1,0,1,1
union
select 343,11,12,19,getdate(),1,getdate(),1,1,0,1,1
union
select 344,11,12,20,getdate(),1,getdate(),1,1,0,1,1
union
select 345,11,12,25,getdate(),1,getdate(),1,1,0,1,1
--高光相纸写真喷绘:HP5500可以使用的纸型
union
select 346,12,10,1,getdate(),1,getdate(),1,1,0,1,1
union
select 347,12,10,2,getdate(),1,getdate(),1,1,0,1,1
union
select 348,12,10,3,getdate(),1,getdate(),1,1,0,1,1
union
select 349,12,10,4,getdate(),1,getdate(),1,1,0,1,1
union
select 350,12,10,6,getdate(),1,getdate(),1,1,0,1,1
union
select 351,12,10,7,getdate(),1,getdate(),1,1,0,1,1
--高光相纸写真喷绘:EP1060可以使用的纸型
union
select 352,12,11,1,getdate(),1,getdate(),1,1,0,1,1
union
select 353,12,11,2,getdate(),1,getdate(),1,1,0,1,1
union
select 354,12,11,3,getdate(),1,getdate(),1,1,0,1,1
union
select 355,12,11,4,getdate(),1,getdate(),1,1,0,1,1
union
select 356,12,11,6,getdate(),1,getdate(),1,1,0,1,1
union
select 357,12,11,7,getdate(),1,getdate(),1,1,0,1,1
--高光相纸写真喷绘:Canon8400可以使用的纸型
union
select 358,12,12,1,getdate(),1,getdate(),1,1,0,1,1
union
select 359,12,12,2,getdate(),1,getdate(),1,1,0,1,1
union
select 360,12,12,3,getdate(),1,getdate(),1,1,0,1,1
union
select 361,12,12,4,getdate(),1,getdate(),1,1,0,1,1
union
select 362,12,12,6,getdate(),1,getdate(),1,1,0,1,1
union
select 363,12,12,7,getdate(),1,getdate(),1,1,0,1,1
--黑白线条打印复印:4850可以使用的纸质
union
select 364,15,13,21,getdate(),1,getdate(),1,1,0,1,1
union
select 365,15,13,22,getdate(),1,getdate(),1,1,0,1,1
--黑白线条打印复印:4850可以使用的纸型
union
select 366,16,13,1,getdate(),1,getdate(),1,1,0,1,1
union
select 367,16,13,2,getdate(),1,getdate(),1,1,0,1,1
union
select 368,16,13,3,getdate(),1,getdate(),1,1,0,1,1
union
select 369,16,13,7,getdate(),1,getdate(),1,1,0,1,1

--工程图晒图:无关可以使用的纸质
union
select 370,15,15,21,getdate(),1,getdate(),1,1,0,1,1
union
select 375,15,15,26,getdate(),1,getdate(),1,1,0,1,1

--工程图晒图:无关可以使用的纸型
union
select 371,16,15,1,getdate(),1,getdate(),1,1,0,1,1
union
select 372,16,15,2,getdate(),1,getdate(),1,1,0,1,1
union
select 373,16,15,3,getdate(),1,getdate(),1,1,0,1,1
union
select 374,16,15,7,getdate(),1,getdate(),1,1,0,1,1



Update ID_Generator set current_value=450 where Flag_No='FACTOR_RELATION_VALUES'


