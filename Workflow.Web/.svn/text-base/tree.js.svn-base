// Title: Tigra Tree
// Description: See the demo at url
// URL: http://www.softcomplex.com/products/tigra_menu_tree/
// Version: 1.1
// Date: 11-12-2002 (mm-dd-yyyy)
// Notes: This script is free. Visit official site for further details.

var gItem,gTemplate;
function newtree (b_items, b_template) 
{
    gItem=b_items;
    gTemplate=b_template;
    var url="ajax/AjaxEngine.aspx";
    
    var provider = {};
    provider.a_items = b_items;
    provider.a_template=b_template;
    provider.process = function(json) {
        window.permissionCheck(json,provider.a_items,provider.a_template);
    };
    
    $.ajax({type:'GET',url:url,data:'a=17',success:permissionCheck,async:false});
    //$.getJSON(url,{a:'17'},provider.process);    

}

function permissionCheck(json,a_items,a_template)
{
    if (json.success == null || json.success) 
    {
        eval('data='+json);
        //data=json;
        
    }
    else 
    {
        return;
    }
    a_items=gItem;
    a_template=gTemplate;

    if(undefined==data.UserList) return;
    for(var i=0;i<data.UserList.length;i++)
    {
        for(var j=2;j<a_items[0].length;j++)
        {
            var obj=a_items[0][j];
            for(var n=2;n<obj.length;n++)
            {
                if(obj[n].length>2)
                {
                    for(var k=2;k<obj[n].length;k++)
                    {
                        if(obj[n][k]!=undefined && obj[n][k][0]==data.UserList[i].PermissionName)
                        {
                            obj[n][k][2]="Y";
                            if(obj[n][obj[n].length-1]!="Y")
                            {
                                obj[n][obj[n].length]="Y";
                            }
                        }
                    }
                }
                if(obj[n][0]==data.UserList[i].PermissionName)
                {
                    obj[n][2]="Y";
                }
            }
        }
    }
    var dCount1=0,dCount2=0;
    for(var j=2;j<a_items[0].length;j++)
    {
        var obj=a_items[0][j];
        dCount2=0;
        for(var n=2;n<obj.length+dCount2;n++)
        {
            if(obj[n-dCount2].length>2)
            {
                dCount1=0;
                for(var k=2;k<obj[n-dCount2].length+dCount1;k++)
                {
                    if(obj[n-dCount2][k-dCount1]!=undefined  && obj[n-dCount2][k-dCount1]!="Y" && obj[n-dCount2][k-dCount1][2]!="Y")
                    {
                        //obj[n][k][0]="";
                        //obj[n][k][1]="";
                        obj[n-dCount2].splice(k-dCount1,1);
                        dCount1++;
                    }
                }
            }            
            if(obj[n-dCount2][2]!="Y" && obj[n-dCount2][obj[n-dCount2].length-1]!="Y" )
            {
                //obj[n][0]="";
                //obj[n][1]="";
                obj.splice(n-dCount2,1);
                dCount2++;
                //obj[n].[2]="N";
            }
        }
    }

        
    //new tree(a_items,a_template);
}

//function newtree (a_items,a_template) 
//{
//    var url="ajax/AjaxEngine.aspx";
//    
//    var provider = {};
//    provider.a_items = a_items;
//    provider.a_template=a_template;
//    provider.process = function(json) {
//        window.permissionCheck(json,provider.a_items,provider.a_template);
//    };
//    
//    $.getJSON(url,{a:'17'},provider.process);    

//}

//function permissionCheck(json,a_items,a_template)
//{
//    if (json.success == null || json.success) 
//    {
//        data=json;
//    }
//    else 
//    {
//        return;
//    }
//    for(var i=0;i<data.UserList.length;i++)
//    {
//        for(var j=2;j<a_items[0].length;j++)
//        {
//            var obj=a_items[0][j];
//            for(var n=2;n<obj.length;n++)
//            {
//                if(obj[n].length>2)
//                {
//                    for(var k=2;k<obj[n].length;k++)
//                    {
//                        if(obj[n][k]!=undefined && obj[n][k][0]==data.UserList[i].PermissionName)
//                        {
//                            obj[n][k][2]="Y";
//                        }
//                    }
//                }
//           
//                if(obj[n][0]==data.UserList[i].PermissionName)
//                {
//                    obj[n][2]="Y";
//                }
//            }
//        }
//    }
//    for(var j=2;j<a_items[0].length;j++)
//    {
//        for(var n=2;n<a_items[0][j].length;n++)
//        {
//            if(a_items[0][j][n][2]!=undefined  && a_items[0][j][n][2]!="Y")
//            {
//                for(var k=2;k<a_items[0][j][n].length;k++)
//                {
//                    if(a_items[0][j][n][k]!=undefined && a_items[0][j][n][k][2]==undefined)
//                    {
//                        a_items[0][j][n]=a_items[0][j][n].slice(0,k).concat(a_items[0][j][n].slice(k+1,a_items[0][j][n].length));
//                        k--;
//                        continue;
//                    }
//                }
//                if(a_items[0][j][n].length<=2)
//                {   
//                    a_items[0][j]=a_items[0][j].slice(0,n).concat(a_items[0][j].slice(n+1,a_items[0][j].length));
//                    n--;
//                    continue;
//                }
//            }

//            if(a_items[0][j][n][2]==undefined)
//            {
//                a_items[0][j]=a_items[0][j].slice(0,n).concat(a_items[0][j].slice(n+1,a_items[0][j].length));
//                n--;
//                continue;
//            }
//        }
//        if(a_items[0][j].length<=2)
//        {
//            a_items[0]=a_items[0].slice(0,j).concat(a_items[0].slice(j+1,a_items[0].length));
//            j--;
//            continue;
//        }   
//    }
//    //items=a_items;
//    //new tree(a_items, TREE_TPL);
//}





function tree(a_items, a_template)
{
	this.a_tpl      = a_template;
	this.a_config   = a_items;
	this.o_root     = this;
	this.a_index    = [];
	this.o_selected = null;
	this.n_depth    = -1;
	
	var o_icone = new Image(),
		o_iconl = new Image();
	o_icone.src = a_template['icon_e'];
	o_iconl.src = a_template['icon_l'];
	a_template['im_e'] = o_icone;
	a_template['im_l'] = o_iconl;
	for (var i = 0; i < 64; i++)
		if (a_template['icon_' + i]) {
			var o_icon = new Image();
			a_template['im_' + i] = o_icon;
			o_icon.src = a_template['icon_' + i];
		}
	this.toggle = function (n_id) 
	{	
	    if(this.a_index.length>0)
	    {
	        var o_item = this.a_index[n_id]; 
	        o_item.open(o_item.b_opened) 
	    }
	};
	this.select = function (n_id) { return this.a_index[n_id].select(); };
	this.mout   = function (n_id) { this.a_index[n_id].upstatus(true) };
	this.mover  = function (n_id) { this.a_index[n_id].upstatus() };

	this.a_children = [];
	for (var i = 0; i < a_items.length; i++)
		new tree_item(this, i);

	this.n_id = trees.length;
	trees[this.n_id] = this;
	
	for (var i = 0; i < this.a_children.length; i++) {
		document.write(this.a_children[i].init());
		this.a_children[i].open();
	}
	
	if(trees.length>0){
		trees[0].toggle(1);
		var id='i_txt'+this.o_root.n_id+'_2';
		document.getElementById(id).click();
	}
}

function tree_item (o_parent, n_order) {

	this.n_depth  = o_parent.n_depth + 1;
	this.a_config = o_parent.a_config[n_order + (this.n_depth ? 2 : 0)];
	if (!this.a_config || this.a_config=="Y" || this.a_config.length<3) return;

	this.o_root    = o_parent.o_root;
	this.o_parent  = o_parent;
	this.n_order   = n_order;

	this.n_id = this.o_root.a_index.length;
	this.o_root.a_index[this.n_id] = this;
	o_parent.a_children[n_order] = this;

	this.a_children = [];
	if(this.a_config.length>=3 && this.a_config[2].length>1 )
	{
        for (var i = 0; i < this.a_config.length - 2; i++)
	   	    new tree_item(this, i);
    }

	this.get_icon = item_get_icon;
	this.open     = item_open;
	this.select   = item_select;
	this.init     = item_init;
	this.upstatus = item_upstatus;
	this.is_last  = function () { return this.n_order == this.o_parent.a_children.length - 1 };
	
}

function item_open (b_close) {
	var o_idiv = get_element('i_div' + this.o_root.n_id + '_' + this.n_id);
	if (!o_idiv) return;
	
	if (!o_idiv.innerHTML) {
		var a_children = [];
		for (var i = 0; i < this.a_children.length; i++)
		{
		    if(this.a_children[i]!=undefined)
			    a_children[i]= this.a_children[i].init();
		}
		o_idiv.innerHTML = a_children.join('');
	}
	o_idiv.style.display = (b_close ? 'none' : 'block');
	
	this.b_opened = !b_close;
//	var o_jicon = document.images['j_img alt=""' + this.o_root.n_id + '_' + this.n_id],
//	    o_iicon = document.images['i_img alt=""' + this.o_root.n_id + '_' + this.n_id];

	var o_jicon = document.images['j_img' + this.o_root.n_id + '_' + this.n_id],
	    o_iicon = document.images['i_img' + this.o_root.n_id + '_' + this.n_id];

//	var o_jicon=document.images[10];
//	var o_iicon=document.images[11];
	if (o_jicon) o_jicon.src = this.get_icon(true);
	if (o_iicon) o_iicon.src = this.get_icon();
	this.upstatus();
}

function item_select (b_deselect) {
	if (!b_deselect) {
		var o_olditem = this.o_root.o_selected;
		this.o_root.o_selected = this;
		if (o_olditem) o_olditem.select(true);
	}
	//var o_iicon = document.images['i_img alt=""' + this.o_root.n_id + '_' + this.n_id];
	var o_iicon = document.images['i_img' + this.o_root.n_id + '_' + this.n_id];
	if (o_iicon) o_iicon.src = this.get_icon();
	get_element('i_txt' + this.o_root.n_id + '_' + this.n_id).style.fontWeight = b_deselect ? 'normal' : 'bold';
	
	this.upstatus();
	return Boolean(this.a_config[1]);
}

function item_upstatus (b_clear) {
	//window.setTimeout('window.status="' + (b_clear ? '' : this.a_config[0] + (this.a_config[1] ? ' ('+ this.a_config[1] + ')' : '')) + '"', 10);
}

function item_init () {
	var a_offset = [],
		o_current_item = this.o_parent;
	for (var i = this.n_depth; i > 1; i--) {
		a_offset[i] = '<img alt="" src="' + this.o_root.a_tpl[o_current_item.is_last() ? 'icon_e' : 'icon_l'] + '" border="0" align="absbottom">';
		o_current_item = o_current_item.o_parent;
	}
//	return '<table cellpadding="0" cellspacing="0" border="0"><tr><td nowrap>' + (this.n_depth ? a_offset.join('') + (this.a_children.length
//		? '<a href="javascript: trees[' + this.o_root.n_id + '].toggle(' + this.n_id + ')" onmouseover="trees[' + this.o_root.n_id + '].mover(' + this.n_id + ')" onmouseout="trees[' + this.o_root.n_id + '].mout(' + this.n_id + ')"><img alt="" src="' + this.get_icon(true) + '" border="0" align="absbottom" name="j_img alt=""' + this.o_root.n_id + '_' + this.n_id + '"></a>'
//		: '<img alt="" src="' + this.get_icon(true) + '" border="0" align="absbottom">') : '') 
//		+ '<a href="' + this.a_config[1] + '" target="' + this.o_root.a_tpl['target'] + '" onclick="return trees[' + this.o_root.n_id + '].select(' + this.n_id + ')" ondblclick="trees[' + this.o_root.n_id + '].toggle(' + this.n_id + ')" onmouseover="trees[' + this.o_root.n_id + '].mover(' + this.n_id + ')" onmouseout="trees[' + this.o_root.n_id + '].mout(' + this.n_id + ')" class="t' + this.o_root.n_id + 'i" id="i_txt' + this.o_root.n_id + '_' + this.n_id + '"><img alt="" src="' + this.get_icon() + '" border="0" align="absbottom" name="i_img alt=""' + this.o_root.n_id + '_' + this.n_id + '" class="t' + this.o_root.n_id + 'im">' + this.a_config[0] + '</a></td></tr></table>' + (this.a_children.length ? '<div id="i_div' + this.o_root.n_id + '_' + this.n_id + '" style="display:none"></div>' : '');


	return '<table cellpadding="0" cellspacing="0" border="0"><tr><td nowrap>' + (this.n_depth ? a_offset.join('') + (this.a_children.length
		? '<a href="javascript: trees[' + this.o_root.n_id + '].toggle(' + this.n_id + ')" onmouseover="trees[' + this.o_root.n_id + '].mover(' + this.n_id + ')" onmouseout="trees[' + this.o_root.n_id + '].mout(' + this.n_id + ')"><img alt="" src="' + this.get_icon(true) + '" border="0" align="absbottom" name="j_img' + this.o_root.n_id + '_' + this.n_id + '"></a>'
		: '<img alt="" src="' + this.get_icon(true) + '" border="0" align="absbottom">') : '') 
		+ '<a href="' + this.a_config[1] + '" target="' + this.o_root.a_tpl['target'] + '" onclick="return trees[' + this.o_root.n_id + '].select(' + this.n_id + ')" ondblclick="trees[' + this.o_root.n_id + '].toggle(' + this.n_id + ')" onmouseover="trees[' + this.o_root.n_id + '].mover(' + this.n_id + ')" onmouseout="trees[' + this.o_root.n_id + '].mout(' + this.n_id + ')" class="t' + this.o_root.n_id + 'i" id="i_txt' + this.o_root.n_id + '_' + this.n_id + '"><img alt="" src="' + this.get_icon() + '" border="0" align="absbottom" name="i_img' + this.o_root.n_id + '_' + this.n_id + '" class="t' + this.o_root.n_id + 'im">' + this.a_config[0] + '</a></td></tr></table>' + (this.a_children.length ? '<div id="i_div' + this.o_root.n_id + '_' + this.n_id + '" style="display:none"></div>' : '');

}

function item_get_icon (b_junction) {
	return this.o_root.a_tpl['icon_' + ((this.n_depth ? 0 : 32) + (this.a_children.length ? 16 : 0) + (this.a_children.length && this.b_opened ? 8 : 0) + (!b_junction && this.o_root.o_selected == this ? 4 : 0) + (b_junction ? 2 : 0) + (b_junction && this.is_last() ? 1 : 0))];
}

var trees = [];
get_element = document.all ?
    function (s_id) { return document.all[s_id] } :
    function (s_id) { return document.getElementById(s_id) };






