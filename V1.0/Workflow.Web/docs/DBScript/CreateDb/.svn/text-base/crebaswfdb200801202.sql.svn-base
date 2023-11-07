/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2008-12-2 10:54:04                           */
/*==============================================================*/


/*==============================================================*/
/* Table: ACCREDIT_RECORD                                       */
/*==============================================================*/
create table ACCREDIT_RECORD (
   ID                   bigint               not null,
   USERS_ID             bigint               not null,
   USER_NAME            nvarchar(100)        not null,
   MEMO                 nvarchar(200)        null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               null,
   BRANCH_SHOP_ID       bigint               null,
   constraint PK_ACCREDIT_RECORD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ACHIEVEMENT                                           */
/*==============================================================*/
create table ACHIEVEMENT (
   ID                   bigint               not null,
   ORDER_ITEM_ID        bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   ORDERS_ID            bigint               not null,
   ACHIEVEMENT_VALUE    decimal(14,2)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_ACHIEVEMENT primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: AMOUNT_SEGMENT                                        */
/*==============================================================*/
create table AMOUNT_SEGMENT (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_AMOUNT_SEGMENT primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: APPLICATION_PROPERTIES                                */
/*==============================================================*/
create table APPLICATION_PROPERTIES (
   ID                   bigint               not null,
   PROPERTY_ID          nvarchar(100)        not null,
   PROPERTY_VALUE       nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_APPLICATION_PROPERTIES primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BASE_BUSINESS_TYPE_PRICE_SET                          */
/*==============================================================*/
create table BASE_BUSINESS_TYPE_PRICE_SET (
   ID                   bigint               not null,
   BUSINESS_TYPE_ID     bigint               not null,
   FACTOR1              bigint               null,
   FACTOR2              bigint               null,
   FACTOR3              bigint               null,
   FACTOR4              bigint               null,
   FACTOR5              bigint               null,
   FACTOR6              bigint               null,
   FACTOR7              bigint               null,
   FACTOR8              bigint               null,
   FACTOR9              bigint               null,
   FACTOR10             bigint               null,
   FACTOR11             bigint               null,
   FACTOR12             bigint               null,
   FACTOR13             bigint               null,
   FACTOR14             bigint               null,
   FACTOR15             bigint               null,
   FACTOR16             bigint               null,
   FACTOR17             bigint               null,
   FACTOR18             bigint               null,
   FACTOR19             bigint               null,
   FACTOR20             bigint               null,
   COST_PRICE           decimal(14,2)        not null,
   STANDARD_PRICE       decimal(14,2)        not null,
   ACTIVITY_PRICE       decimal(14,2)        not null,
   RESERVE_PRICE        decimal(14,2)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_BASE_BUSINESS_TYPE_PRICE_SE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BLANK_OUT_REASON                                      */
/*==============================================================*/
create table BLANK_OUT_REASON (
   ID                   bigint               not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_BLANK_OUT_REASON primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BRANCH_SHOP                                           */
/*==============================================================*/
create table BRANCH_SHOP (
   ID                   bigint               not null,
   COMPANY_ID           bigint               null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   constraint PK_BRANCH_SHOP primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BUSINESS_TYPE                                         */
/*==============================================================*/
create table BUSINESS_TYPE (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   NEED_RECORD_MACHINE  char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_BUSINESS_TYPE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BUSINESS_TYPE_PRICE_FACTOR                            */
/*==============================================================*/
create table BUSINESS_TYPE_PRICE_FACTOR (
   ID                   bigint               not null,
   PRICE_FACTOR_ID      bigint               not null,
   BUSINESS_TYPE_ID     bigint               not null,
   SORT_NO              int                  not null,
   constraint PK_BUSINESS_TYPE_PRICE_FACTOR primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: BUSINESS_TYPE_PRICE_SET                               */
/*==============================================================*/
create table BUSINESS_TYPE_PRICE_SET (
   ID                   bigint               not null,
   BASE_BUSINESS_TYPE_PRICE_SET_ID bigint               not null,
   BUSINESS_TYPE_ID     bigint               not null,
   PRICE_TYPE           bigint               not null,
   TARGET_ID            bigint               not null,
   FACTOR1              bigint               null,
   FACTOR2              bigint               null,
   FACTOR3              bigint               null,
   FACTOR4              bigint               null,
   FACTOR5              bigint               null,
   FACTOR6              bigint               null,
   FACTOR7              bigint               null,
   FACTOR8              bigint               null,
   FACTOR9              bigint               null,
   FACTOR10             bigint               null,
   FACTOR11             bigint               null,
   FACTOR12             bigint               null,
   FACTOR13             bigint               null,
   FACTOR14             bigint               null,
   FACTOR15             bigint               null,
   FACTOR16             bigint               null,
   FACTOR17             bigint               null,
   FACTOR18             bigint               null,
   FACTOR19             bigint               null,
   FACTOR20             bigint               null,
   COST_PRICE           decimal(14,2)        null,
   STANDARD_PRICE       decimal(14,2)        not null,
   ACTIVITY_PRICE       decimal(14,2)        not null,
   RESERVE_PRICE        decimal(14,2)        not null,
   NEW_PRICE            decimal(14,2)        not null,
   PRICE_CONCESSION     decimal(14,2)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_BUSINESS_TYPE_PRICE_SET primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CAMPAIGN                                              */
/*==============================================================*/
create table CAMPAIGN (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   BEGIN_DATE_TIME      datetime             not null,
   END_DATE_TIME        datetime             not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_CAMPAIGN primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CASH_HAND_OVER                                        */
/*==============================================================*/
create table CASH_HAND_OVER (
   ID                   bigint               not null,
   HAND_OVER_ID         bigint               not null,
   TICKET_AMOUNT_SUM    decimal(14,2)        not null,
   PAY_FOR_COUNT        int                  not null,
   PAY_FOR_AMOUNT_SUM   decimal(14,2)        not null,
   CASH_AMOUNT          decimal(14,2)        not null,
   KEEP_BUSINESS_RECORD_COUNT int                  not null,
   KEEP_BUSINESS_RECORD_AMOUNT_SUM decimal(14,2)        not null,
   DEBT_COUNT           int                  not null,
   DEBT_AMOUNT_SUM      decimal(14,2)        not null,
   STANDBY_AMOUNT       decimal(14,2)        not null,
   constraint PK_CASH_HAND_OVER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CASH_HAND_OVER_ORDERS                                 */
/*==============================================================*/
create table CASH_HAND_OVER_ORDERS (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   CASH_HAND_OVER_ID    bigint               not null,
   NO                   varchar(50)          not null,
   EARNEST_AMOUNT       decimal(14,2)        not null,
   constraint PK_CASH_HAND_OVER_ORDERS primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CHANGE_MEMBER_CARD                                    */
/*==============================================================*/
create table CHANGE_MEMBER_CARD (
   ID                   bigint               not null,
   MEMBER_CARD_ID       bigint               not null,
   OLD_MEMBER_CARD_NO   varchar(50)          not null,
   NEW_MEMBER_CARD_NO   varchar(50)          not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_CHANGE_MEMBER_CARD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: COMPANY                                               */
/*==============================================================*/
create table COMPANY (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   constraint PK_COMPANY primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: COMPENSATE_EMPLOYEE                                   */
/*==============================================================*/
create table COMPENSATE_EMPLOYEE (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   COMPENSATE_USED_PAPER_ID bigint               not null,
   constraint PK_COMPENSATE_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: COMPENSATE_USED_PAPER                                 */
/*==============================================================*/
create table COMPENSATE_USED_PAPER (
   ID                   bigint               not null,
   MACHINE_ID           bigint               not null,
   RECORD_MACHINE_WATCH_ID bigint               not null,
   PAPER_SPECIFICATION_ID bigint               not null,
   USED_PAPER_COUNT     int                  not null,
   COLOR_TYPE           char(1)              not null,
   MEMO                 nvarchar(200)        not null,
   constraint PK_COMPENSATE_USED_PAPER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CONCESSION                                            */
/*==============================================================*/
create table CONCESSION (
   ID                   bigint               not null,
   BASE_BUSINESS_TYPE_PRICE_SET_ID bigint               not null,
   CAMPAIGN_ID          bigint               not null,
   NAME                 nvarchar(50)         not null,
   DESCRIPTION          nvarchar(500)        not null,
   CHARGE_AMOUNT        decimal(14,2)        not null,
   PAPER_COUNT          decimal(14,2)        null,
   MEMO                 nvarchar(200)        not null,
   UNIT_PRICE           decimal(14,2)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_CONCESSION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CONCESSION_DIFFERENCE_PRICE                           */
/*==============================================================*/
create table CONCESSION_DIFFERENCE_PRICE (
   ID                   bigint               not null,
   BASE_BUSINESS_TYPE_PRICE_SET_ID bigint               not null,
   CONCESSION_ID        bigint               not null,
   PRICE_DIFFERENCE     decimal(14,2)        not null,
   constraint PK_CONCESSION_DIFFERENCE_PRICE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CONCESSION_MEMBER_CARD_LEVEL                          */
/*==============================================================*/
create table CONCESSION_MEMBER_CARD_LEVEL (
   ID                   bigint               not null,
   CONCESSION_ID        bigint               not null,
   MEMBER_CARD_LEVEL_ID bigint               not null,
   constraint PK_CONCESSION_MEMBER_CARD_LEVE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   ID                   bigint               not null,
   CUSTOMER_LEVEL_ID    bigint               not null,
   CUSTOMER_TYPE_ID     bigint               not null,
   SECONDARY_TRADE_ID   bigint               null,
   NAME                 nvarchar(50)         not null,
   SIMPLE_NAME          varchar(20)          not null,
   ADDRESS              nvarchar(100)        not null,
   LAST_LINK_MAN        nvarchar(20)         not null,
   LAST_TEL_NO          varchar(20)          not null,
   LINK_MAN_COUNT       int                  not null,
   MEMO                 nvarchar(200)        not null,
   VALIDATE_STATUS      char(1)              not null,
   INSERT_USER          bigint               not null,
   INSERT_DATE_TIME     datetime             not null,
   UPDATE_USER          bigint               null,
   UPDATE_DATE_TIME     datetime             null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               not null,
   NEED_TICKET          char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   PAY_TYPE             int                  not null,
   DELETED              char(1)              not null,
   constraint PK_CUSTOMER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CUSTOMER_LEVEL                                        */
/*==============================================================*/
create table CUSTOMER_LEVEL (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_CUSTOMER_LEVEL primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: CUSTOMER_TYPE                                         */
/*==============================================================*/
create table CUSTOMER_TYPE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_CUSTOMER_TYPE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: DAILY_RECORD_MACHINE                                  */
/*==============================================================*/
create table DAILY_RECORD_MACHINE (
   ID                   bigint               not null,
   MACHINE_ID           bigint               null,
   PAPER_SPECIFICATION_ID bigint               null,
   COLOR_TYPE           char(1)              not null,
   IN_WATCH_COUNT       decimal(14,2)        not null,
   MAKE_COUNT           decimal(14,2)        not null,
   CASH_COUNT           decimal(14,2)        not null,
   PATCH_COUNT          decimal(14,2)        not null,
   MEMO                 nvarchar(200)        not null,
   DO_WATCH_DATE_TIME   datetime             not null,
   constraint PK_DAILY_RECORD_MACHINE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: DELIVERY_ORDER                                        */
/*==============================================================*/
create table DELIVERY_ORDER (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   BEGIN_DATE_TIME      datetime             not null,
   END_DATE_TIME        datetime             not null,
   MEMO                 nvarchar(200)        not null,
   FINISHED             char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_DELIVERY_ORDER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: DUTY_EMPLOYEE                                         */
/*==============================================================*/
create table DUTY_EMPLOYEE (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               null,
   ORDERS_DUTY_ID       bigint               null,
   constraint PK_DUTY_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: EMPLOYEE_POSITION                                     */
/*==============================================================*/
create table EMPLOYEE_POSITION (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   POSITION_ID          bigint               not null,
   constraint PK_EMPLOYEE_POSITION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: FACTOR_RELATION                                       */
/*==============================================================*/
create table FACTOR_RELATION (
   ID                   bigint               not null,
   BUSINESS_TYPE_ID     bigint               null,
   PRICE_FACTOR_ID      bigint               not null,
   PRICE_FACTOR_ID2     bigint               not null,
   MEMO                 nvarchar(200)        null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_FACTOR_RELATION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: FACTOR_RELATION_VALUES                                */
/*==============================================================*/
create table FACTOR_RELATION_VALUES (
   ID                   bigint               not null,
   FACTOR_RELATION_ID   bigint               not null,
   SOURCE_VALUE         int                  not null,
   TARGET_VALUE         int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_FACTOR_RELATION_VALUES primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: FACTOR_VALUE                                          */
/*==============================================================*/
create table FACTOR_VALUE (
   ID                   bigint               not null,
   PRICE_FACTOR_ID      bigint               not null,
   VALUE                nvarchar(50)         not null,
   TEXT                 nvarchar(50)         not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_FACTOR_VALUE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: GATHERING                                             */
/*==============================================================*/
create table GATHERING (
   ID                   bigint               not null,
   AMOUNT               decimal(14,2)        not null,
   GATHERING_DATE_TIME  datetime             not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_GATHERING primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: GATHERING_ORDERS                                      */
/*==============================================================*/
create table GATHERING_ORDERS (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   GATHERING_ID         bigint               not null,
   PAY_KIND             char(1)              not null,
   constraint PK_GATHERING_ORDERS primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: HAND_OVER                                             */
/*==============================================================*/
create table HAND_OVER (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   OTHER_EMPLOYEE_ID    bigint               not null,
   HAND_OVER_DATE_TIME  datetime             not null,
   MEMO                 nvarchar(200)        not null,
   HAND_OVER_STATUS     char(1)              not null,
   HAND_OVER_TYPE       char(1)              not null,
   INSERT_USER          bigint               not null,
   INSERT_DATE_TIME     datetime             not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_HAND_OVER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: HAND_OVER_MEMBER_CARD                                 */
/*==============================================================*/
create table HAND_OVER_MEMBER_CARD (
   ID                   bigint               not null,
   HAND_OVER_ID         bigint               not null,
   MEMBER_CARD_ID       bigint               not null,
   MEMBER_CARD_NO       varchar(50)          not null,
   constraint PK_HAND_OVER_MEMBER_CARD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: HAND_OVER_ORDERS                                      */
/*==============================================================*/
create table HAND_OVER_ORDERS (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   HAND_OVER_ID         bigint               not null,
   NO                   varchar(50)          not null,
   INSERT_DATE_TIME     datetime             not null,
   DELIVERY_TYPE        int                  not null,
   DELIVERY_DATE_TIME   datetime             not null,
   MEMO                 nvarchar(200)        not null,
   STATUS               int                  not null,
   constraint PK_HAND_OVER_ORDERS primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ID_GENERATOR                                          */
/*==============================================================*/
create table ID_GENERATOR (
   ID                   bigint               not null,
   FLAG_NO              varchar(50)          not null,
   BEGIN_VALUE          bigint               not null,
   CURRENT_VALUE        bigint               not null,
   END_VALUE            bigint               not null,
   MEMO                 nvarchar(200)        not null,
   BRANCH_SHOP_ID       bigint               null,
   constraint PK_ID_GENERATOR primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: LINK_MAN                                              */
/*==============================================================*/
create table LINK_MAN (
   ID                   bigint               not null,
   CUSTOMER_ID          bigint               not null,
   NAME                 nvarchar(50)         not null,
   SEX                  char(1)              not null,
   AGE                  int                  not null,
   POSITION             nvarchar(50)         not null,
   HOBBY                nvarchar(100)        not null,
   COMPANY_TEL_NO       varchar(20)          not null,
   MOBILE_NO            varchar(20)          not null,
   QQ                   varchar(20)          not null,
   EMAIL                varchar(50)          not null,
   ADDRESS              nvarchar(100)        not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_LINK_MAN primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: LOGOFF_MEMBER_CARD                                    */
/*==============================================================*/
create table LOGOFF_MEMBER_CARD (
   MEMBER_CARD_ID       bigint               not null,
   NAME                 nvarchar(50)         not null,
   LOGOFF_DATE_TIME     datetime             not null,
   MEMO                 nvarchar(200)        not null,
   ID                   bigint               not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_LOGOFF_MEMBER_CARD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE                                               */
/*==============================================================*/
create table MACHINE (
   ID                   bigint               not null,
   MACHINE_TYPE_ID      bigint               not null,
   NO                   varchar(50)          null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_MACHINE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE_TYPE                                          */
/*==============================================================*/
create table MACHINE_TYPE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   NEED_RECORD_WARCH    char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_MACHINE_TYPE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE_WATCH                                         */
/*==============================================================*/
create table MACHINE_WATCH (
   ID                   bigint               not null,
   MACHINE_TYPE_ID      bigint               not null,
   NAME                 nvarchar(50)         not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_MACHINE_WATCH primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE_WATCH_CONVERSION_PAPER                        */
/*==============================================================*/
create table MACHINE_WATCH_CONVERSION_PAPER (
   ID                   bigint               not null,
   PAPER_SPECIFICATION_ID bigint               null,
   MACHINE_TYPE_ID      bigint               not null,
   NAME                 nvarchar(50)         not null,
   COMPUTE_FORMULA      varchar(200)         not null,
   COLOR_TYPE           char(1)              not null,
   constraint PK_MACHINE_WATCH_CONVERSION_PA primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE_WATCH_RECORD_LOG                              */
/*==============================================================*/
create table MACHINE_WATCH_RECORD_LOG (
   ID                   bigint               not null,
   MACHINE_ID           bigint               not null,
   MACHINE_WATCH_ID     bigint               not null,
   RECORD_MACHINE_WATCH_ID bigint               not null,
   LAST_NUMBER          int                  not null,
   NEW_NUMBER           int                  not null,
   MEMO                 nvarchar(200)        not null,
   constraint PK_MACHINE_WATCH_RECORD_LOG primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MACHINE_WATCH_SCALE                                   */
/*==============================================================*/
create table MACHINE_WATCH_SCALE (
   ID                   bigint               not null,
   MACHINE_ID           bigint               not null,
   MACHINE_WATCH_ID     bigint               not null,
   LASTEST_NUMBER       int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_MACHINE_WATCH_SCALE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MASTER_TRADE                                          */
/*==============================================================*/
create table MASTER_TRADE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_MASTER_TRADE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MEMBER_CARD                                           */
/*==============================================================*/
create table MEMBER_CARD (
   ID                   bigint               not null,
   CUSTOMER_ID          bigint               not null,
   MEMBER_CARD_LEVEL_ID bigint               not null,
   MEMBER_CARD_NO       varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   AGE                  int                  not null,
   EMAIL                varchar(50)          not null,
   HOBBY                nvarchar(100)        not null,
   MOBILE_NO            varchar(20)          not null,
   POSITION             nvarchar(50)         not null,
   SEX                  char(1)              not null,
   MEMBER_STATE         varchar(1)           not null,
   IDENTITY_CARD_NO     varchar(18)          not null,
   PASSWORD             char(32)             not null,
   MEMBER_CARD_BEGIN_DATE datetime             not null,
   MEMBER_CARD_END_DATE datetime             not null,
   NEED_TICKET          char(1)              not null,
   CONSUME_AMOUNT       decimal(14,2)        not null,
   INTEGRAl             int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_MEMBER_CARD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MEMBER_CARD_CONCESSION                                */
/*==============================================================*/
create table MEMBER_CARD_CONCESSION (
   ID                   bigint               not null,
   CONCESSION_ID        bigint               not null,
   MEMBER_CARD_ID       bigint               not null,
   JOIN_DATE_TIME       datetime             not null,
   REST_PAPER_COUNT     decimal(14,2)        not null,
   PAPER_COUNT          decimal(14,2)        not null,
   AMOUNT               decimal(14,2)        not null,
   constraint PK_MEMBER_CARD_CONCESSION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MEMBER_CARD_LEVEL                                     */
/*==============================================================*/
create table MEMBER_CARD_LEVEL (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_MEMBER_CARD_LEVEL primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: MEMBER_OPERATE_LOG                                    */
/*==============================================================*/
create table MEMBER_OPERATE_LOG (
   ID                   bigint               not null,
   MEMBER_CARD_ID       bigint               not null,
   OPERATE_TYPE         char(2)              not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_MEMBER_OPERATE_LOG primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDERS                                                */
/*==============================================================*/
create table ORDERS (
   ID                   bigint               not null,
   CUSTOMER_ID          bigint               null,
   NEW_ORDER_USER_ID    bigint               not null,
   CASH_USER_ID         bigint               null,
   MEMBER_CARD_ID       bigint               null,
   NO                   varchar(50)          not null,
   CUSTOMER_TYPE        int                  not null,
   CUSTOMER_NAME        nvarchar(50)         not null,
   NAME                 nvarchar(50)         not null,
   PROJECT_NAME         nvarchar(50)         not null,
   PAY_TYPE             int                  not null,
   PREPARE_MONEY        char(1)              not null,
   PREPARE_MONEY_AMOUNT decimal(14,2)        not null,
   NEED_TICKET          char(1)              not null,
   DELIVERY_TYPE        int                  not null,
   DELIVERY_DATE_TIME   datetime             null,
   SUM_AMOUNT           decimal(14,2)        not null,
   MEMO                 nvarchar(200)        not null,
   NOT_PAY_TICKET_AMOUNT decimal(14,2)        not null,
   REAL_PAID_AMOUNT     decimal(14,2)        not null,
   PAID_AMOUNT          decimal(14,2)        not null,
   PAID_TICKET          char(1)              not null,
   STATUS               int                  not null,
   BALANCE_DATE_TIME    datetime             null,
   DELETED              char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_ORDERS primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDERS_DUTY                                           */
/*==============================================================*/
create table ORDERS_DUTY (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   DUTY_AMOUNT          decimal(14,2)        not null,
   MEMO                 nvarchar(200)        not null,
   DUTY_FLAG            char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_ORDERS_DUTY primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDERS_FOR_RECORD_MACHINE_SUM                         */
/*==============================================================*/
create table ORDERS_FOR_RECORD_MACHINE_SUM (
   ID                   bigint               not null,
   ORDERS_ID            bigint               null,
   COLOR_TYPE           char(1)              not null,
   PAPER_COUNT          decimal(14,2)        not null,
   BALANCE_DATE_TIME    datetime             not null,
   PAPER_SPECIFICATION_ID bigint               null,
   MACHINE_ID           bigint               not null,
   TRASH_PAPERS         decimal(14,2)        null,
   constraint PK_ORDERS_FOR_RECORD_MACHINE_S primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDERS_STATUS_ALTER                                   */
/*==============================================================*/
create table ORDERS_STATUS_ALTER (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   STATUS               int                  null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_ORDERS_STATUS_ALTER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDER_ITEM                                            */
/*==============================================================*/
create table ORDER_ITEM (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   BUSINESS_TYPE_ID     bigint               not null,
   AMOUNT               decimal(14,2)        not null,
   UNIT_PRICE           decimal(14,2)        not null,
   FORECAST_MONEY_AMOUNT decimal(14,2)        not null,
   IS_USE_SAVED_PAPER   char(1)              not null,
   PAPER_CONSUME_COUNT  decimal(14,2)        not null,
   UNIT_DIFFERENCE_PRICE decimal(14,2)        not null,
   CONSUME_PAPER_AMOUNT decimal(14,2)        not null,
   CASH_CONSUME_COUNT   decimal(14,2)        not null,
   CASH_UNIT_PRICE      decimal(14,2)        not null,
   CASH_CONSUME_AMOUNT  decimal(14,2)        not null,
   DELETED              char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_ORDER_ITEM primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDER_ITEM_EMPLOYEE                                   */
/*==============================================================*/
create table ORDER_ITEM_EMPLOYEE (
   ID                   bigint               not null,
   ORDER_ITEM_ID        bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   constraint PK_ORDER_ITEM_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDER_ITEM_FACTOR_VALUE                               */
/*==============================================================*/
create table ORDER_ITEM_FACTOR_VALUE (
   ID                   bigint               not null,
   PRICE_FACTOR_ID      bigint               not null,
   ORDER_ITEM_ID        bigint               not null,
   VALUE                nvarchar(50)         not null,
   constraint PK_ORDER_ITEM_FACTOR_VALUE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ORDER_ITEM_PRINT_REQUIRE_DETAIL                       */
/*==============================================================*/
create table ORDER_ITEM_PRINT_REQUIRE_DETAIL (
   ID                   bigint               not null,
   ORDER_ITEM_ID        bigint               not null,
   PRINT_REQUIRE_DETAIL_ID bigint               not null,
   constraint PK_ORDER_ITEM_PRINT_REQUIRE_DE primary key (ID)
)
go

/*==============================================================*/
/* Table: PAPER_SPECIFICATION                                   */
/*==============================================================*/
create table PAPER_SPECIFICATION (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_PAPER_SPECIFICATION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PAPER_SPECIFICATION_SIMILARITY                        */
/*==============================================================*/
create table PAPER_SPECIFICATION_SIMILARITY (
   ID                   bigint               not null,
   PARENT_PAPER_SPECIFICATION_ID bigint               not null,
   CHILD_PAPER_SPECIFICATION_ID bigint               not null,
   constraint PK_PAPER_SPECIFICATION_SIMILAR primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PAPER_TYPE                                            */
/*==============================================================*/
create table PAPER_TYPE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_PAPER_TYPE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PAYMENT_CONCESSION                                    */
/*==============================================================*/
create table PAYMENT_CONCESSION (
   ID                   bigint               not null,
   AUTH_USERS_ID        bigint               not null,
   OPERATE_USERS_ID     bigint               not null,
   GATHERING_ID         bigint               not null,
   CONCESSION_TYPE      char(1)              not null,
   CONCESSION_AMOUNT    decimal(14,2)        not null,
   OPERATE_DATE_TIME    datetime             not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_PAYMENT_CONCESSION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PERMISSION                                            */
/*==============================================================*/
create table PERMISSION (
   ID                   bigint               not null,
   PERMISSION_IDENTITY  varchar(200)         not null,
   PERMISSION_TYPE      varchar(1)           not null,
   MEMO                 nvarchar(200)        null,
   constraint PK_PERMISSION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PERMISSION_GROUP                                      */
/*==============================================================*/
create table PERMISSION_GROUP (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   SORT_NO              int                  not null,
   constraint PK_PERMISSION_GROUP primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PERMISSION_GROUP_DETAIL                               */
/*==============================================================*/
create table PERMISSION_GROUP_DETAIL (
   ID                   bigint               not null,
   PERMISSION_ID        bigint               not null,
   PERMISSION_GROUP_ID  bigint               not null,
   constraint PK_PERMISSION_GROUP_DETAIL primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: POSITION                                              */
/*==============================================================*/
create table POSITION (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_POSITION primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PRICE_FACTOR                                          */
/*==============================================================*/
create table PRICE_FACTOR (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   DISPLAY_TEXT         nvarchar(200)        not null,
   TARGET_TABLE         varchar(50)          null,
   TARGET_VALUE_COLUMN  varchar(50)          null,
   TARGET_TEXT_COLUMN   varchar(50)          null,
   USED                 char(1)              not null,
   IS_DISPLAY           char(1)              not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_PRICE_FACTOR primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PRINT_DEMAND                                          */
/*==============================================================*/
create table PRINT_DEMAND (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_PRINT_DEMAND primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PRINT_DEMAND_DETAIL                                   */
/*==============================================================*/
create table PRINT_DEMAND_DETAIL (
   ID                   bigint               not null,
   PRINT_DEMAND_ID      bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_PRINT_DEMAND_DETAIL primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PRINT_REQUIRE_DETAIL                                  */
/*==============================================================*/
create table PRINT_REQUIRE_DETAIL (
   ID                   bigint               not null,
   PRINT_DEMAND_DETAIL_ID bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   SORT_NO              int                  not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_PRINT_REQUIRE_DETAIL primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PROCESS_CONTENT                                       */
/*==============================================================*/
create table PROCESS_CONTENT (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   COLOR_TYPE           char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_PROCESS_CONTENT primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REAL_ORDER_ITEM                                       */
/*==============================================================*/
create table REAL_ORDER_ITEM (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   ORDER_ITEM_ID        bigint               not null,
   BUSINESS_TYPE_ID     bigint               not null,
   AMOUNT               decimal(14,2)        not null,
   UNIT_PRICE           decimal(14,2)        not null,
   FORECAST_MONEY_AMOUNT decimal(14,2)        not null,
   IS_USE_SAVED_PAPER   char(1)              not null,
   PAPER_CONSUME_COUNT  decimal(14,2)        not null,
   UNIT_DIFFERENCE_PRICE decimal(14,2)        not null,
   CONSUME_PAPER_AMOUNT decimal(14,2)        not null,
   CASH_CONSUME_COUNT   decimal(14,2)        not null,
   CASH_UNIT_PRICE      decimal(14,2)        not null,
   CASH_CONSUME_AMOUNT  decimal(14,2)        not null,
   TRASH_PAPERS         decimal(14,2)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_REAL_ORDER_ITEM primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REAL_ORDER_ITEM_EMPLOYEE                              */
/*==============================================================*/
create table REAL_ORDER_ITEM_EMPLOYEE (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   REAL_ORDER_ITEM_ID   bigint               not null,
   constraint PK_REAL_ORDER_ITEM_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REAL_ORDER_ITEM_FACTOR_VALUE                          */
/*==============================================================*/
create table REAL_ORDER_ITEM_FACTOR_VALUE (
   ID                   bigint               not null,
   PRICE_FACTOR_ID      bigint               not null,
   REAL_ORDER_ITEM_ID   bigint               not null,
   VALUE                nvarchar(50)         not null,
   constraint PK_REAL_ORDER_ITEM_FACTOR_VALU primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REAL_ORDER_ITEM_PRINT_REQUIRE                         */
/*==============================================================*/
create table REAL_ORDER_ITEM_PRINT_REQUIRE (
   ID                   bigint               not null,
   PRINT_REQUIRE_DETAIL_ID bigint               not null,
   REAL_ORDER_ITEM_ID   bigint               not null,
   constraint PK_REAL_ORDER_ITEM_PRINT_REQUI primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REAL_ORDER_ITEM_TRASH_REASON                          */
/*==============================================================*/
create table REAL_ORDER_ITEM_TRASH_REASON (
   ID                   bigint               not null,
   REAL_ORDER_ITEM_ID   bigint               null,
   TRASH_REASON_ID      bigint               null,
   constraint PK_REAL_ORDER_ITEM_TRASH_REASO primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: RECORD_MACHINE_WATCH                                  */
/*==============================================================*/
create table RECORD_MACHINE_WATCH (
   ID                   bigint               not null,
   RECORD_DATE_TIME     datetime             not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_RECORD_MACHINE_WATCH primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: RELATION_EMPLOYEE                                     */
/*==============================================================*/
create table RELATION_EMPLOYEE (
   ID                   bigint               not null,
   ORDERS_STATUS_ALTER_ID bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   constraint PK_RELATION_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REPORT_LESS_MODE                                      */
/*==============================================================*/
create table REPORT_LESS_MODE (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_REPORT_LESS_MODE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REPORT_LOSS_MEMBER_CARD                               */
/*==============================================================*/
create table REPORT_LOSS_MEMBER_CARD (
   ID                   bigint               not null,
   REPORT_LESS_MODE_ID  bigint               null,
   MEMBER_CARD_ID       bigint               null,
   NAME                 nvarchar(50)         not null,
   TEL_NO               nvarchar(20)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_REPORT_LOSS_MEMBER_CARD primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: REQUIRE_ACCOUNTING_INFO                               */
/*==============================================================*/
create table REQUIRE_ACCOUNTING_INFO (
   ID                   bigint               not null,
   USERS_ID             bigint               not null,
   ORDERS_ID            bigint               not null,
   MEMO                 nvarchar(200)        not null,
   PASSED               char(1)              not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   DELETED              char(1)              not null,
   VERSION              int                  not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_REQUIRE_ACCOUNTING_INFO primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ROLE                                                  */
/*==============================================================*/
create table ROLE (
   ID                   bigint               not null,
   PERMISSION_VALUES    varchar(200)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_ROLE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ROLE_PERMISSION_GROUP                                 */
/*==============================================================*/
create table ROLE_PERMISSION_GROUP (
   ID                   bigint               not null,
   ROLE_ID              bigint               not null,
   PERMISSION_GROUP_ID  bigint               not null,
   constraint PK_ROLE_PERMISSION_GROUP primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: SECONDARY_TRADE                                       */
/*==============================================================*/
create table SECONDARY_TRADE (
   ID                   bigint               not null,
   MASTER_TRADE_ID      bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_SECONDARY_TRADE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: TAKE_WORK                                             */
/*==============================================================*/
create table TAKE_WORK (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   CUSTOMER_ID          bigint               not null,
   NO                   varchar(50)          not null,
   BEGIN_DATE_TIME      datetime             not null,
   END_DATE_TIME        datetime             not null,
   LINK_MAN_NAME        nvarchar(50)         not null,
   TEL_NO               nvarchar(20)         not null,
   ADDRESS              nvarchar(100)        not null,
   FINISHED             char(1)              not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_TAKE_WORK primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: TRASH_PAPER_EMPLOYEE                                  */
/*==============================================================*/
create table TRASH_PAPER_EMPLOYEE (
   ID                   bigint               not null,
   REAL_ORDER_ITEM_ID   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   TRASH_PAPERS         decimal(14,2)        not null,
   constraint PK_TRASH_PAPER_EMPLOYEE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: TRASH_REASON                                          */
/*==============================================================*/
create table TRASH_REASON (
   ID                   bigint               not null,
   NAME                 nvarchar(50)         not null,
   MEMO                 nvarchar(200)        not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_TRASH_REASON primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: UNCOMPLETE_ORDERS_USED_PAPER                          */
/*==============================================================*/
create table UNCOMPLETE_ORDERS_USED_PAPER (
   ID                   bigint               not null,
   ORDERS_ID            bigint               not null,
   RECORD_MACHINE_WATCH_ID bigint               not null,
   MACHINE_ID           bigint               not null,
   PAPER_SPECIFICATION_ID bigint               not null,
   USED_PAPER_COUNT     int                  not null,
   COLOR_TYPE           char(1)              not null,
   constraint PK_UNCOMPLETE_ORDERS_USED_PAPE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: UNIT                                                  */
/*==============================================================*/
create table UNIT (
   ID                   bigint               not null,
   NO                   varchar(50)          not null,
   NAME                 nvarchar(50)         not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   BRANCH_SHOP_ID       bigint               not null,
   COMPANY_ID           bigint               not null,
   constraint PK_UNIT primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: USERS                                                 */
/*==============================================================*/
create table USERS (
   ID                   bigint               not null,
   EMPLOYEE_ID          bigint               not null,
   USER_NAME            nvarchar(100)        not null,
   PASSWORD             char(32)             not null,
   INSERT_DATE_TIME     datetime             not null,
   INSERT_USER          bigint               not null,
   UPDATE_DATE_TIME     datetime             null,
   UPDATE_USER          bigint               null,
   VERSION              int                  not null,
   DELETED              char(1)              not null,
   COMPANY_ID           bigint               not null,
   BRANCH_SHOP_ID       bigint               not null,
   constraint PK_USERS primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: USER_ROLE                                             */
/*==============================================================*/
create table USER_ROLE (
   ID                   bigint               not null,
   USERS_ID             bigint               not null,
   ROLE_ID              bigint               not null,
   constraint PK_USER_ROLE primary key (ID)
)
go

alter table ACCREDIT_RECORD
   add constraint FK_ACCREDIT_RELATIONS_USERS foreign key (USERS_ID)
      references USERS (ID)
go

alter table ACHIEVEMENT
   add constraint FK_ACHIEVEM_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table ACHIEVEMENT
   add constraint FK_ACHIEVEM_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table ACHIEVEMENT
   add constraint FK_ACHIEVEM_RELATIONS_ORDER_IT foreign key (ORDER_ITEM_ID)
      references ORDER_ITEM (ID)
go

alter table BASE_BUSINESS_TYPE_PRICE_SET
   add constraint FK_BASE_BUS_RELATIONS_BUSINESS foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table BRANCH_SHOP
   add constraint FK_BRANCH_S_RELATIONS_COMPANY foreign key (COMPANY_ID)
      references COMPANY (ID)
go

alter table BUSINESS_TYPE_PRICE_FACTOR
   add constraint FK_BUSINESS_RELATIONS_BUSINESS3 foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table BUSINESS_TYPE_PRICE_FACTOR
   add constraint FK_BUSINESS_RELATIONS_PRICE_FA foreign key (PRICE_FACTOR_ID)
      references PRICE_FACTOR (ID)
go

alter table BUSINESS_TYPE_PRICE_SET
   add constraint FK_BUSINESS_RELATIONS_BASE_BUS foreign key (BASE_BUSINESS_TYPE_PRICE_SET_ID)
      references BASE_BUSINESS_TYPE_PRICE_SET (ID)
go

alter table BUSINESS_TYPE_PRICE_SET
   add constraint FK_BUSINESS_RELATIONS_BUSINESS2 foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table CASH_HAND_OVER
   add constraint FK_CASH_HAN_RELATIONS_HAND_OVE foreign key (HAND_OVER_ID)
      references HAND_OVER (ID)
go

alter table CASH_HAND_OVER_ORDERS
   add constraint FK_CASH_HAN_RELATIONS_CASH_HAN foreign key (CASH_HAND_OVER_ID)
      references CASH_HAND_OVER (ID)
go

alter table CASH_HAND_OVER_ORDERS
   add constraint FK_CASH_HAN_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table CHANGE_MEMBER_CARD
   add constraint FK_CHANGE_M_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table COMPENSATE_EMPLOYEE
   add constraint FK_COMPENSA_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table COMPENSATE_EMPLOYEE
   add constraint FK_COMPENSA_RELATIONS_COMPENSA foreign key (COMPENSATE_USED_PAPER_ID)
      references COMPENSATE_USED_PAPER (ID)
go

alter table COMPENSATE_USED_PAPER
   add constraint FK_COMPENSA_RELATIONS_PAPER_SP foreign key (PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table COMPENSATE_USED_PAPER
   add constraint FK_COMPENSA_RELATIONS_RECORD_M foreign key (RECORD_MACHINE_WATCH_ID)
      references RECORD_MACHINE_WATCH (ID)
go

alter table COMPENSATE_USED_PAPER
   add constraint FK_COMPENSA_RELATIONS_MACHINE foreign key (MACHINE_ID)
      references MACHINE (ID)
go

alter table CONCESSION
   add constraint FK_CONCESSI_RELATIONS_CAMPAIGN foreign key (CAMPAIGN_ID)
      references CAMPAIGN (ID)
go

alter table CONCESSION
   add constraint FK_CONCESSI_RELATIONS_BASE_BUS4 foreign key (BASE_BUSINESS_TYPE_PRICE_SET_ID)
      references BASE_BUSINESS_TYPE_PRICE_SET (ID)
go

alter table CONCESSION_DIFFERENCE_PRICE
   add constraint FK_CONCESSI_RELATIONS_BASE_BUS foreign key (BASE_BUSINESS_TYPE_PRICE_SET_ID)
      references BASE_BUSINESS_TYPE_PRICE_SET (ID)
go

alter table CONCESSION_DIFFERENCE_PRICE
   add constraint FK_CONCESSI_RELATIONS_CONCESSI2 foreign key (CONCESSION_ID)
      references CONCESSION (ID)
go

alter table CONCESSION_MEMBER_CARD_LEVEL
   add constraint FK_CONCESSI_RELATIONS_CONCESSI3 foreign key (CONCESSION_ID)
      references CONCESSION (ID)
go

alter table CONCESSION_MEMBER_CARD_LEVEL
   add constraint FK_CONCESSI_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_LEVEL_ID)
      references MEMBER_CARD_LEVEL (ID)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_RELATIONS_CUSTOMER foreign key (CUSTOMER_TYPE_ID)
      references CUSTOMER_TYPE (ID)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_RELATIONS_SECONDAR foreign key (SECONDARY_TRADE_ID)
      references SECONDARY_TRADE (ID)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_RELATIONS_CUSTOMER2 foreign key (CUSTOMER_LEVEL_ID)
      references CUSTOMER_LEVEL (ID)
go

alter table DAILY_RECORD_MACHINE
   add constraint FK_DAILY_RE_RELATIONS_MACHINE foreign key (MACHINE_ID)
      references MACHINE (ID)
go

alter table DAILY_RECORD_MACHINE
   add constraint FK_DAILY_RE_RELATIONS_PAPER_SP foreign key (PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table DELIVERY_ORDER
   add constraint FK_DELIVERY_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table DELIVERY_ORDER
   add constraint FK_DELIVERY_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table DUTY_EMPLOYEE
   add constraint FK_DUTY_EMP_RELATIONS_ORDERS_D foreign key (ORDERS_DUTY_ID)
      references ORDERS_DUTY (ID)
go

alter table DUTY_EMPLOYEE
   add constraint FK_DUTY_EMP_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table EMPLOYEE_POSITION
   add constraint FK_EMPLOYEE_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table EMPLOYEE_POSITION
   add constraint FK_EMPLOYEE_RELATIONS_POSITION foreign key (POSITION_ID)
      references POSITION (ID)
go

alter table FACTOR_RELATION
   add constraint FK_FACTOR_R_RELATIONS_PRICE_FA foreign key (PRICE_FACTOR_ID)
      references PRICE_FACTOR (ID)
go

alter table FACTOR_RELATION
   add constraint FK_FACTOR_R_RELATIONS_BUSINESS foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table FACTOR_RELATION
   add constraint FK_FACTOR_R_RELATIONS_PRICE2_FA foreign key (PRICE_FACTOR_ID2)
      references PRICE_FACTOR (ID)
go

alter table FACTOR_RELATION_VALUES
   add constraint FK_FACTOR_R_RELATIONS_FACTOR_R foreign key (FACTOR_RELATION_ID)
      references FACTOR_RELATION (ID)
go

alter table FACTOR_VALUE
   add constraint FK_FACTOR_V_RELATIONS_PRICE_FA foreign key (PRICE_FACTOR_ID)
      references PRICE_FACTOR (ID)
go

alter table GATHERING_ORDERS
   add constraint FK_GATHERIN_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table GATHERING_ORDERS
   add constraint FK_GATHERIN_RELATIONS_GATHERIN foreign key (GATHERING_ID)
      references GATHERING (ID)
go

alter table HAND_OVER
   add constraint FK_HAND_OVE_RELATIONS_EMPLOYEE1 foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table HAND_OVER
   add constraint FK_HAND_OVE_RELATIONS_EMPLOYEE2 foreign key (OTHER_EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table HAND_OVER_MEMBER_CARD
   add constraint FK_HAND_OVE_RELATIONS_HAND_OVE3 foreign key (HAND_OVER_ID)
      references HAND_OVER (ID)
go

alter table HAND_OVER_MEMBER_CARD
   add constraint FK_HAND_OVE_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table HAND_OVER_ORDERS
   add constraint FK_HAND_OVE_RELATIONS_HAND_OVE4 foreign key (HAND_OVER_ID)
      references HAND_OVER (ID)
go

alter table HAND_OVER_ORDERS
   add constraint FK_HAND_OVE_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table LINK_MAN
   add constraint FK_LINK_MAN_RELATIONS_CUSTOMER foreign key (CUSTOMER_ID)
      references CUSTOMER (ID)
go

alter table LOGOFF_MEMBER_CARD
   add constraint FK_LOGOFF_M_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table MACHINE
   add constraint FK_MACHINE_RELATIONS_MACHINE_ foreign key (MACHINE_TYPE_ID)
      references MACHINE_TYPE (ID)
go

alter table MACHINE_WATCH
   add constraint FK_MACHINE__RELATIONS_MACHINE_ foreign key (MACHINE_TYPE_ID)
      references MACHINE_TYPE (ID)
go

alter table MACHINE_WATCH_CONVERSION_PAPER
   add constraint FK_MACHINE__RELATIONS_PAPER_SP2 foreign key (PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table MACHINE_WATCH_CONVERSION_PAPER
   add constraint FK_MACHINE__RELATIONS_MACHINE_3 foreign key (MACHINE_TYPE_ID)
      references MACHINE_TYPE (ID)
go

alter table MACHINE_WATCH_RECORD_LOG
   add constraint FK_MACHINE__RELATIONS_MACHINE_2 foreign key (MACHINE_WATCH_ID)
      references MACHINE_WATCH (ID)
go

alter table MACHINE_WATCH_RECORD_LOG
   add constraint FK_MACHINE__RELATIONS_MACHINE2 foreign key (MACHINE_ID)
      references MACHINE (ID)
go

alter table MACHINE_WATCH_RECORD_LOG
   add constraint FK_MACHINE__RELATIONS_RECORD_M foreign key (RECORD_MACHINE_WATCH_ID)
      references RECORD_MACHINE_WATCH (ID)
go

alter table MACHINE_WATCH_SCALE
   add constraint FK_MACHINE__RELATIONS_MACHINE_4 foreign key (MACHINE_WATCH_ID)
      references MACHINE_WATCH (ID)
go

alter table MACHINE_WATCH_SCALE
   add constraint FK_MACHINE__RELATIONS_MACHINE foreign key (MACHINE_ID)
      references MACHINE (ID)
go

alter table MEMBER_CARD
   add constraint FK_MEMBER_C_RELATIONS_CUSTOMER foreign key (CUSTOMER_ID)
      references CUSTOMER (ID)
go

alter table MEMBER_CARD
   add constraint FK_MEMBER_C_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_LEVEL_ID)
      references MEMBER_CARD_LEVEL (ID)
go

alter table MEMBER_CARD_CONCESSION
   add constraint FK_MEMBER_C_RELATIONS_MEMBER_C2 foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table MEMBER_CARD_CONCESSION
   add constraint FK_MEMBER_C_RELATIONS_CONCESSI foreign key (CONCESSION_ID)
      references CONCESSION (ID)
go

alter table MEMBER_OPERATE_LOG
   add constraint FK_MEMBER_O_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table ORDERS
   add constraint FK_ORDERS_RELATIONS_USERS2 foreign key (NEW_ORDER_USER_ID)
      references USERS (ID)
go

alter table ORDERS
   add constraint FK_ORDERS_RELATIONS_USERS foreign key (CASH_USER_ID)
      references USERS (ID)
go

alter table ORDERS
   add constraint FK_ORDERS_RELATIONS_CUSTOMER foreign key (CUSTOMER_ID)
      references CUSTOMER (ID)
go

alter table ORDERS
   add constraint FK_ORDERS_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table ORDERS_DUTY
   add constraint FK_ORDERS_D_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table ORDERS_FOR_RECORD_MACHINE_SUM
   add constraint FK_ORDERS_F_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table ORDERS_STATUS_ALTER
   add constraint FK_ORDERS_S_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table ORDER_ITEM
   add constraint FK_ORDER_IT_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table ORDER_ITEM
   add constraint FK_ORDER_IT_RELATIONS_BUSINESS foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table ORDER_ITEM_EMPLOYEE
   add constraint FK_ORDER_IT_RELATIONS_ORDER_IT2 foreign key (ORDER_ITEM_ID)
      references ORDER_ITEM (ID)
go

alter table ORDER_ITEM_EMPLOYEE
   add constraint FK_ORDER_IT_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table ORDER_ITEM_FACTOR_VALUE
   add constraint FK_ORDER_IT_RELATIONS_PRICE_FA foreign key (PRICE_FACTOR_ID)
      references PRICE_FACTOR (ID)
go

alter table ORDER_ITEM_FACTOR_VALUE
   add constraint FK_ORDER_IT_RELATIONS_ORDER_IT foreign key (ORDER_ITEM_ID)
      references ORDER_ITEM (ID)
go

alter table ORDER_ITEM_PRINT_REQUIRE_DETAIL
   add constraint FK_ORDER_IT_RELATIONS_PRINT_RE foreign key (PRINT_REQUIRE_DETAIL_ID)
      references PRINT_REQUIRE_DETAIL (ID)
go

alter table ORDER_ITEM_PRINT_REQUIRE_DETAIL
   add constraint FK_ORDER_IT_RELATIONS_ORDER_IT3 foreign key (ORDER_ITEM_ID)
      references ORDER_ITEM (ID)
go

alter table PAPER_SPECIFICATION_SIMILARITY
   add constraint FK_PAPER_SP_RELATIONS_PAPER_SP2 foreign key (CHILD_PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table PAPER_SPECIFICATION_SIMILARITY
   add constraint FK_PAPER_SP_RELATIONS_PAPER_SP foreign key (PARENT_PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table PAYMENT_CONCESSION
   add constraint FK_PAYMENT__RELATIONS_GATHERIN foreign key (GATHERING_ID)
      references GATHERING (ID)
go

alter table PAYMENT_CONCESSION
   add constraint FK_PAYMENT__RELATIONS_USERS2 foreign key (OPERATE_USERS_ID)
      references USERS (ID)
go

alter table PAYMENT_CONCESSION
   add constraint FK_PAYMENT__RELATIONS_USERS foreign key (AUTH_USERS_ID)
      references USERS (ID)
go

alter table PERMISSION_GROUP_DETAIL
   add constraint FK_PERMISSI_RELATIONS_PERMISSI2 foreign key (PERMISSION_GROUP_ID)
      references PERMISSION_GROUP (ID)
go

alter table PERMISSION_GROUP_DETAIL
   add constraint FK_PERMISSI_RELATIONS_PERMISSI foreign key (PERMISSION_ID)
      references PERMISSION (ID)
go

alter table PRINT_DEMAND_DETAIL
   add constraint FK_PRINT_DE_RELATIONS_PRINT_DE foreign key (PRINT_DEMAND_ID)
      references PRINT_DEMAND (ID)
go

alter table PRINT_REQUIRE_DETAIL
   add constraint FK_PRINT_RE_RELATIONS_PRINT_DE foreign key (PRINT_DEMAND_DETAIL_ID)
      references PRINT_DEMAND_DETAIL (ID)
go

alter table REAL_ORDER_ITEM
   add constraint FK_REAL_ORD_RELATIONS_ORDER_IT foreign key (ORDER_ITEM_ID)
      references ORDER_ITEM (ID)
go

alter table REAL_ORDER_ITEM
   add constraint FK_REAL_ORD_RELATIONS_BUSINESS foreign key (BUSINESS_TYPE_ID)
      references BUSINESS_TYPE (ID)
go

alter table REAL_ORDER_ITEM
   add constraint FK_REAL_ORD_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table REAL_ORDER_ITEM_EMPLOYEE
   add constraint FK_REAL_ORD_RELATIONS_REAL_ORD4 foreign key (REAL_ORDER_ITEM_ID)
      references REAL_ORDER_ITEM (ID)
go

alter table REAL_ORDER_ITEM_EMPLOYEE
   add constraint FK_REAL_ORD_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table REAL_ORDER_ITEM_FACTOR_VALUE
   add constraint FK_REAL_ORD_RELATIONS_REAL_ORD3 foreign key (REAL_ORDER_ITEM_ID)
      references REAL_ORDER_ITEM (ID)
go

alter table REAL_ORDER_ITEM_FACTOR_VALUE
   add constraint FK_REAL_ORD_RELATIONS_PRICE_FA foreign key (PRICE_FACTOR_ID)
      references PRICE_FACTOR (ID)
go

alter table REAL_ORDER_ITEM_PRINT_REQUIRE
   add constraint FK_REAL_ORD_RELATIONS_REAL_ORD foreign key (REAL_ORDER_ITEM_ID)
      references REAL_ORDER_ITEM (ID)
go

alter table REAL_ORDER_ITEM_PRINT_REQUIRE
   add constraint FK_REAL_ORD_RELATIONS_PRINT_RE foreign key (PRINT_REQUIRE_DETAIL_ID)
      references PRINT_REQUIRE_DETAIL (ID)
go

alter table REAL_ORDER_ITEM_TRASH_REASON
   add constraint FK_REAL_ORD_RELATIONS_REAL_ORD2 foreign key (REAL_ORDER_ITEM_ID)
      references REAL_ORDER_ITEM (ID)
go

alter table REAL_ORDER_ITEM_TRASH_REASON
   add constraint FK_REAL_ORD_RELATIONS_TRASH_RE foreign key (TRASH_REASON_ID)
      references TRASH_REASON (ID)
go

alter table RELATION_EMPLOYEE
   add constraint FK_RELATION_RELATIONS_ORDERS_S foreign key (ORDERS_STATUS_ALTER_ID)
      references ORDERS_STATUS_ALTER (ID)
go

alter table RELATION_EMPLOYEE
   add constraint FK_RELATION_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table REPORT_LOSS_MEMBER_CARD
   add constraint FK_REPORT_L_RELATIONS_MEMBER_C foreign key (MEMBER_CARD_ID)
      references MEMBER_CARD (ID)
go

alter table REPORT_LOSS_MEMBER_CARD
   add constraint FK_REPORT_L_RELATIONS_REPORT_L foreign key (REPORT_LESS_MODE_ID)
      references REPORT_LESS_MODE (ID)
go

alter table REQUIRE_ACCOUNTING_INFO
   add constraint FK_REQUIRE__RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table REQUIRE_ACCOUNTING_INFO
   add constraint FK_REQUIRE__RELATIONS_USERS foreign key (USERS_ID)
      references USERS (ID)
go

alter table ROLE_PERMISSION_GROUP
   add constraint FK_ROLE_PER_RELATIONS_ROLE foreign key (ROLE_ID)
      references ROLE (ID)
go

alter table ROLE_PERMISSION_GROUP
   add constraint FK_ROLE_PER_RELATIONS_PERMISSI foreign key (PERMISSION_GROUP_ID)
      references PERMISSION_GROUP (ID)
go

alter table SECONDARY_TRADE
   add constraint FK_SECONDAR_RELATIONS_MASTER_T foreign key (MASTER_TRADE_ID)
      references MASTER_TRADE (ID)
go

alter table TAKE_WORK
   add constraint FK_TAKE_WOR_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table TAKE_WORK
   add constraint FK_TAKE_WOR_RELATIONS_CUSTOMER foreign key (CUSTOMER_ID)
      references CUSTOMER (ID)
go

alter table TRASH_PAPER_EMPLOYEE
   add constraint FK_TRASH_PA_RELATIONS_REAL_ORD foreign key (REAL_ORDER_ITEM_ID)
      references REAL_ORDER_ITEM (ID)
go

alter table TRASH_PAPER_EMPLOYEE
   add constraint FK_TRASH_PA_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table UNCOMPLETE_ORDERS_USED_PAPER
   add constraint FK_UNCOMPLE_RELATIONS_RECORD_M foreign key (RECORD_MACHINE_WATCH_ID)
      references RECORD_MACHINE_WATCH (ID)
go

alter table UNCOMPLETE_ORDERS_USED_PAPER
   add constraint FK_UNCOMPLE_RELATIONS_ORDERS foreign key (ORDERS_ID)
      references ORDERS (ID)
go

alter table UNCOMPLETE_ORDERS_USED_PAPER
   add constraint FK_UNCOMPLE_RELATIONS_MACHINE foreign key (MACHINE_ID)
      references MACHINE (ID)
go

alter table UNCOMPLETE_ORDERS_USED_PAPER
   add constraint FK_UNCOMPLE_RELATIONS_PAPER_SP foreign key (PAPER_SPECIFICATION_ID)
      references PAPER_SPECIFICATION (ID)
go

alter table USERS
   add constraint FK_USERS_RELATIONS_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (ID)
go

alter table USER_ROLE
   add constraint FK_USER_ROL_RELATIONS_ROLE foreign key (ROLE_ID)
      references ROLE (ID)
go

alter table USER_ROLE
   add constraint FK_USER_ROL_RELATIONS_USERS foreign key (USERS_ID)
      references USERS (ID)
go

