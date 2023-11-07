using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using Workflow.Support.Log;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Workflow.Util
{
    /// <summary>
    /// 名    称: 生成条码号
    /// 功能概要: 
    /// 作    者: 付强
    /// 创建时间: 2010-1-8
    /// </summary>
    public class Code39Utils
    {
        //对应码表
        private Hashtable Decode;
        private Hashtable CheckCode;
        //字符间隔
        private string SPARATOR = "0";
        //粗线间隙宽度
        public int WidthCU = 3;
        //细线间隙宽度
        public int WidthXI = 1;
        //条码起始坐标
        public int xCoordiinate = 2;

        public int LineHeight = 60;
        private int Height = 0;
        private int Width = 0;


        public Code39Utils()
        {
            Decode = new Hashtable();
            Decode.Add("0", "001100100");
            Decode.Add("1", "100010100");
            Decode.Add("2", "010010100");
            Decode.Add("3", "110000100");
            Decode.Add("4", "001010100");
            Decode.Add("5", "101000100");
            Decode.Add("6", "011000100");
            Decode.Add("7", "000110100");
            Decode.Add("8", "100100100");
            Decode.Add("9", "010100100");
            Decode.Add("A", "100010010");
            Decode.Add("B", "010010010");
            Decode.Add("C", "110000010");
            Decode.Add("D", "001010010");
            Decode.Add("E", "101000010");
            Decode.Add("F", "011000010");
            Decode.Add("G", "000110010");
            Decode.Add("H", "100100010");
            Decode.Add("I", "010100010");
            Decode.Add("J", "001100010");
            Decode.Add("K", "100010001");
            Decode.Add("L", "010010001");
            Decode.Add("M", "110000001");
            Decode.Add("N", "001010001");
            Decode.Add("O", "101000001");
            Decode.Add("P", "011000001");
            Decode.Add("Q", "000110001");
            Decode.Add("R", "100100001");
            Decode.Add("S", "010100001");
            Decode.Add("T", "001100001");
            Decode.Add("U", "100011000");
            Decode.Add("V", "010011000");
            Decode.Add("W", "110001000");
            Decode.Add("X", "001011000");
            Decode.Add("Y", "101001000");
            Decode.Add("Z", "011001000");
            Decode.Add("-", "000111000");
            Decode.Add(".", "100101000");
            Decode.Add(" ", "010101000");
            Decode.Add("*", "001101000");
            Decode.Add("$", "000001110");
            Decode.Add("/", "000001101");
            Decode.Add("+", "000001011");
            Decode.Add("%", "000000111");

            //Decode.Add("0", "000110100");
            //Decode.Add("1", "100100001");
            //Decode.Add("2", "001100001");
            //Decode.Add("3", "101100000");
            //Decode.Add("4", "000110001");
            //Decode.Add("5", "100110000");
            //Decode.Add("6", "001110000");
            //Decode.Add("7", "000100101");
            //Decode.Add("8", "100100100");
            //Decode.Add("9", "001100100");
            //Decode.Add("A", "100001001");
            //Decode.Add("B", "001001001");
            //Decode.Add("C", "101001000");
            //Decode.Add("D", "000011001");
            //Decode.Add("E", "100011000");
            //Decode.Add("F", "001011000");
            //Decode.Add("G", "000001101");
            //Decode.Add("H", "100001100");
            //Decode.Add("I", "001001101");
            //Decode.Add("J", "000011100");
            //Decode.Add("K", "100000011");
            //Decode.Add("L", "001000011");
            //Decode.Add("M", "101000010");
            //Decode.Add("N", "000010011");
            //Decode.Add("O", "100010010");
            //Decode.Add("P", "001010010");
            //Decode.Add("Q", "000000111");
            //Decode.Add("R", "100000110");
            //Decode.Add("S", "001000110");
            //Decode.Add("T", "000010110");
            //Decode.Add("U", "110000001");
            //Decode.Add("V", "011000001");
            //Decode.Add("W", "111000000");
            //Decode.Add("X", "010010001");
            //Decode.Add("Y", "110010000");
            //Decode.Add("Z", "011010000");
            //Decode.Add("-", "010000101");
            //Decode.Add("%", "000101010");
            //Decode.Add("$", "010101000");
            //Decode.Add("*", "010010100");

            CheckCode = new Hashtable();
            CheckCode.Add("0", "0");
            CheckCode.Add("1", "1");
            CheckCode.Add("2", "2");
            CheckCode.Add("3", "3");
            CheckCode.Add("4", "4");
            CheckCode.Add("5", "5");
            CheckCode.Add("6", "6");
            CheckCode.Add("7", "7");
            CheckCode.Add("8", "8");
            CheckCode.Add("9", "9");
            CheckCode.Add("A", "10");
            CheckCode.Add("B", "11");
            CheckCode.Add("C", "12");
            CheckCode.Add("D", "13");
            CheckCode.Add("E", "14");
            CheckCode.Add("F", "15");
            CheckCode.Add("G", "16");
            CheckCode.Add("H", "17");
            CheckCode.Add("I", "18");
            CheckCode.Add("J", "19");
            CheckCode.Add("K", "20");
            CheckCode.Add("L", "21");
            CheckCode.Add("M", "22");
            CheckCode.Add("N", "23");
            CheckCode.Add("O", "24");
            CheckCode.Add("P", "25");
            CheckCode.Add("Q", "26");
            CheckCode.Add("R", "27");
            CheckCode.Add("S", "28");
            CheckCode.Add("T", "29");
            CheckCode.Add("U", "30");
            CheckCode.Add("V", "31");
            CheckCode.Add("W", "32");
            CheckCode.Add("X", "33");
            CheckCode.Add("Y", "34");
            CheckCode.Add("Z", "35");
            CheckCode.Add("-", "36");
            CheckCode.Add(".", "37");
            CheckCode.Add(" ", "38");
            CheckCode.Add("*", "39");
            CheckCode.Add("$", "40");
            CheckCode.Add("/", "41");
            CheckCode.Add("+", "42");
            CheckCode.Add("%", "43");
        }
        private string Encode39(string strCode, int nUseCheck, int nValidateCode)
        {
            int nUseStand = 1;//检查输入待编码字符是否为标准格式(是否以*开始结束)
            string strOrginalCode = strCode;//保存备份资料
            
            if (null == strCode || strCode.Trim().Equals(""))
            {
                return null;
            }

            strCode = strCode.ToUpper();

            Regex rule = new Regex(@"[^0-9A-Z%$\-*]");
            if (rule.IsMatch(strCode))
            {
                //编码中包含非法字符 ,目前仅支持字母，数字和%$-*符号
                return null;
            }

            if (nUseCheck == 1)
            {
                int nCheck = 0;
                for (int i = 0; i < strCode.Length; i++)
                {
                    nCheck += int.Parse((string)CheckCode[strCode.Substring(i, 1)]);
                }
                nCheck = nCheck % 43;

                //附加检测码
                if (nValidateCode == 1)
                {
                    foreach (DictionaryEntry de in CheckCode)
                    {
                        if ((string)de.Value == nCheck.ToString())
                        {
                            strCode = strCode + (string)de.Key;
                            break;
                        }
                    }
                }

            }

            //标准化输入字符 增加起始标记
            if (nUseStand == 1)
            {
                if (strCode.Substring(0, 1) != "*")
                {
                    strCode = "*" + strCode;
                }
                if (strCode.Substring(strCode.Length - 1, 1) != "*")
                {
                    strCode = strCode + "*";
                }
            }

            //转换成39编码
            string strCode39 = string.Empty;
            for (int i = 0; i < strCode.Length; i++)
            {
                strCode39 = strCode39 + (string)Decode[strCode.Substring(i, 1)] + SPARATOR;
            }
            int nHeight = 30 + LineHeight;//定义图片高度
            int nWidth = xCoordiinate;
            for (int i = 0; i < strCode39.Length; i++)
            {
                if ("0".Equals(strCode39.Substring(i, 1)))
                {
                    nWidth += WidthXI;
                }
                else
                {
                    nWidth += WidthCU;
                }
            }

            this.Width = nWidth + xCoordiinate;
            this.Height = nHeight;
            return strCode39;
        }

        private void DrawBarCode39(string strCode39, string strTitle, Graphics g)
        {
            int nUseTitle = 1;//条码上端显示标题
            //int nUseTTF = 1;//使用TTF字体,方便显示中文,需要$UseTitle=1时才生效

            if (strTitle.Trim().Equals(""))
            {
                nUseTitle = 0;
            }
            Pen pWhite = new Pen(Color.White, 1);
            Pen pBlack = new Pen(Color.Black, 1);
            int nPosition = xCoordiinate;

            //显示标题
            if (nUseTitle == 1)
            {
                Font fTitleFont = new Font("宋体", 16, FontStyle.Bold);
                SizeF sf = g.MeasureString(strTitle, fTitleFont);
                g.DrawString(strTitle, fTitleFont, Brushes.Black, (Width - sf.Width) / 2, 5);
            }

            for (int i = 0; i < strCode39.Length; i++)
            {
                if ("0".Equals(strCode39.Substring(i, 0)))
                {
                    for (int j = 0; j < WidthXI; j++)
                    {
                        g.DrawLine(pBlack, nPosition + j, 30, nPosition + j, 30 + LineHeight);
                    }
                    nPosition += WidthXI;
                }
                else
                {
                    for (int j = 0; j < WidthCU; j++)
                    {
                        g.DrawLine(pBlack, nPosition + j, 30, nPosition + j, 30 + LineHeight);
                    }
                    nPosition += WidthCU;
                }
                //i++;
                //绘制线间距
                if ("0".Equals(strCode39.Substring(i, 1)))
                {
                    nPosition += WidthXI;
                }
                else
                {
                    nPosition += WidthCU;
                }
            }
            return;
        }
        /// <summary>
        /// 绘制条码号
        /// </summary>
        /// <param name="strCode">要生成的条码内容</param>
        /// <param name="strTitle">要显示的标题</param>
        /// <param name="nUseCheck">计算检查码</param>
        /// <param name="nValidateCode"></param>
        /// <returns></returns>
        public Bitmap CreateBarCode(string strCode, string strTitle, int nUseCheck, int nValidateCode)
        {
            string strCode39 = Encode39(strCode, nUseCheck, nValidateCode);

            if (null != strCode)
            {
                Bitmap saved = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(saved);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
                this.DrawBarCode39(strCode39, strTitle, g);
                return saved;
            }
            return null;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Title"></param>
        /// <param name="UseCheck"></param>
        /// <param name="ValidateCode"></param>
        /// <returns></returns>
        public Boolean SaveFile(string strCode, string strTitle, int nUseCheck, int nValidateCode,out string fileName)
        {
            string strCode39 = Encode39(strCode, nUseCheck, nValidateCode);
            fileName = string.Empty;

            if (null != strCode39)
            {
                Bitmap saved = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(saved);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);

                this.DrawBarCode39(strCode39, strTitle, g);

                string strPath = string.Empty;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "*.JPEG|*.JPEG|*.JPG|*JPG";
                saveFile.ShowDialog();
                if (!saveFile.FileName.Equals(""))
                {
                    strPath = saveFile.FileName;
                }
                else
                {
                    return false;
                }

                string strFileName = strPath + strCode + ".jpg";
                fileName=strFileName;
                saved.Save(strFileName, ImageFormat.Jpeg);
                saved.Dispose();
                return true;

            }
            return false;
        }
    }
}
