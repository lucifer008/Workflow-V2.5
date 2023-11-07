<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
       // Workflow.Support.Log.LogHelper.WriteError((Exception)sender, Workflow.Support.Constants.LOGGER_NAME);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        
        // 在新会话启动时运行的代码

    }


    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
        Spring.Context.IApplicationContext ctx = Spring.Context.Support.ContextRegistry.GetContext();
        IBatisNet.DataMapper.SqlMapper sqlMap = (IBatisNet.DataMapper.SqlMapper)ctx.GetObject("sqlMap");
        Workflow.Da.Domain.User user = ((Workflow.Da.Domain.User)(((Workflow.Support.ThreadLocalUtils)(Session["Workflow.Support.ThreadLocalUtils"])).CurrentUser));
        UpdateUser(sqlMap.DataSource.ConnectionString, user);
        Workflow.Support.Log.LogHelper.WriteInfo("用户 " + user.UserName + " 已注销登陆.注销时间 " + DateTime.Now.ToString(), Workflow.Support.Constants.LOGGER_NAME);
        Session.Clear();

    }
    void UpdateUser(string connectionString,Workflow.Da.Domain.User user)
    {
        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
        {
            conn.Open();
            string cmdText = "Update Users set IS_LOGIN='N' where Id="+ user.Id +"and deleted='0' and Company_Id='" + user.CompanyId + "' and Branch_Shop_Id=" + user.BranchShopId;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
        }
    }
       
</script>
