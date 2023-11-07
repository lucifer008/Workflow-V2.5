using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IBatisNet.DataMapper.Configuration.Cache;
using IBatisNet.DataMapper;
using System.Text;
using System.Collections.Generic;

public partial class ClearCache : Workflow.Web.PageBase
{
	protected ISqlMapper sqlMap;
	protected IList<CacheModel> models = new List<CacheModel>();
	public ISqlMapper SqlMap
	{
		set { sqlMap = value; }
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.IsPostBack)
		{
			ClearSelectedCache();
		}
		InitData();
	}

	public void InitData()
	{
		using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(sqlMap.DataSource.ConnectionString))
		{
			conn.Open();
			IDbCommand cmd = conn.CreateCommand();
			cmd.CommandText = "select name from sysobjects where xtype='U' order by name";
			using (IDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					string tableName = reader.GetString(0);
					string className = GetClassName(tableName);
					string cacheModel = className + "." + className + "Cache";
					try
					{
						models.Add(sqlMap.GetCache(cacheModel));
					}
					catch { }
				}
			}
		}
	}

	private string GetClassName(string tableName)
	{
		string[] parts = tableName.Split('_');
		StringBuilder buffer = new StringBuilder();

		foreach (string part in parts)
		{
			string p = part.ToLower();
			buffer.Append(p.Substring(0, 1).ToUpper());
			buffer.Append(p.Substring(1));
		}
		return buffer.ToString();
	}

	private void ClearSelectedCache()
	{
		string selectedTableString = Request.Form["selectedTable"];
		if (selectedTableString != null && selectedTableString.Trim() != "")
		{
			selectedTableString = selectedTableString.Trim();
			string[] selectedTables = selectedTableString.Split(',');
			foreach (string selectedTable in selectedTables)
			{
				sqlMap.GetCache(selectedTable).Flush();
			}
		}
	}
}
