// JScript 文件
//功能: 打印小票确认对话框JS
//作者: 张晓林
//日期: 2010年4月2日9:40:23

//功能: 打印检查
//作者: 张晓林
//日期: 2010年4月2日9:41:32
function printCheck(){
	doPrint();	
//    var yes=window.print();
//    if(yes){
//        //document.write('<input type=button name=print value="打印页面" onClick="javascript:window.print()"/>');
//        
//    }
//    return false;
	
}


function doPrint(){
	//打印文档对象
    var myDoc ={ 
    				documents: document,    // 打印页面(div)们在本文档中
					setting:{  //当前设置
						topMargin:10,
						leftMargin:0,
						rightmargin:0
					},
					//header:{height:36,html:myheader},
					classesReplacedWhenPrint: new Array('.only_for_print{display:block}'),  //打印隐藏对象
    				copyrights  :    '杰创软件拥有版权 www.jatools.com'         // 版权声明必须
    			  };
    			  
    // 调用打印方法
//    if(how == '打印预览...')
    	jatoolsPrinter.printPreview(myDoc );   // 打印预览
                 
//    else if(how == '打印...')
//   		jatoolsPrinter.print(myDoc ,true);   // 打印前弹出打印设置对话框
//                
//   	else
//   		jatoolsPrinter.print(myDoc ,false);       // 不弹出对话框打印
}
