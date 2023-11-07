<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearCache.aspx.cs" Inherits="ClearCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cache 管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<input type="button" value="Clear Selected Item" onclick="clearSelectedItem(this);"/>
		<input type="button" value="Clear All" onclick="clearAll(this);"/>
		<table border="1">
			<tr>
				<td>Cache名</td>
				<td>Hit %</td>
				<td>算法</td>
				<td>ReadOnly</td>
				<td >Serializable</td>
				<td>Flag</td>
				<td>操作</td>
			</tr>
			<% foreach (IBatisNet.DataMapper.Configuration.Cache.CacheModel cache in models)
	  {	
		  string cacheMath = cache.Implementation.Substring(0, cache.Implementation.IndexOf(","));
			%>
				<tr>
					<td><%= cache.Id.Substring(cache.Id.IndexOf('.') + 1)%></td>
					<td align="right"><%= (cache.HitRatio * 100.0d).ToString("00.00")%></td>
					<td><%= cacheMath.Substring(cacheMath.LastIndexOf('.') + 1)%></td>
					<td align="center"><%= cache.IsReadOnly%></td>
					<td align="center"><%= cache.IsSerializable%></td>
					<td align="center"><input type="checkbox" name="selectedTable" value="<%= cache.Id %>" /></td>
					<td align="center"><input type="button" value="Clear" onclick="clearThis(this);" /></td>
				</tr>
			<%} %>
		</table>
		<script type="text/javascript">
			function clearThis(button) {
				var cb = button.parentNode.parentNode.cells.item(5).firstChild;
				cb.checked = true;
				button.form.submit();
			}
			function clearSelectedItem(button) {
				button.form.submit();
			}
			function clearAll(button) {
				var inputs = document.getElementsByTagName("input");
				for (var i = 0;i < inputs.length; i++) {
					var cb = inputs[i];
					if (cb.type == "checkbox") {
						cb.checked = true;
					}
				}
				
				button.form.submit();
			}
		</script>
		<input type="button" value="Clear Selected Item" onclick="clearSelectedItem(this);"/>
		<input type="button" value="Clear All" onclick="clearAll(this);"/>
    </div>
    </form>
</body>
</html>
