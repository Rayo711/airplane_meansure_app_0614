using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MiniExcelLibs;
using NPOI.XWPF.UserModel;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp2
{
    public class Myexcel
    {
        public class pts
        {
            public string ptname { get; set; }
            public double coordx { get; set; }
            public double coordy { get; set; }
            public double coordz { get; set; }
        }

        public void ExportDataToExcel(System.Data.DataTable TableName, string FileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件标题
            saveFileDialog.Title = "导出Excel文件";
            //设置文件类型
            saveFileDialog.Filter = "Microsoft Office Excel 工作簿(*.xls)|*.xls";
            //设置默认文件类型显示顺序  
            saveFileDialog.FilterIndex = 1;
            //是否自动在文件名中添加扩展名
            saveFileDialog.AddExtension = true;
            //是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;
            //设置默认文件名
            saveFileDialog.FileName = FileName;
            //按下确定选择的按钮  
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径 
                string localFilePath = saveFileDialog.FileName.ToString();

                //数据初始化
                int TotalCount;     //总行数
                int RowRead = 0;    //已读行数
                int Percent = 0;    //百分比

                TotalCount = TableName.Rows.Count;
                

                //数据流
                Stream myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("gb2312"));
                string strHeader = "";

                //秒钟
                Stopwatch timer = new Stopwatch();
                timer.Start();

                try
                {
                    //写入标题
                    for (int i = 0; i < TableName.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            strHeader += "\t";
                        }
                        strHeader += TableName.Columns[i].ColumnName.ToString();
                    }
                    sw.WriteLine(strHeader);

                    //写入数据
                    //string strData;
                    for (int i = 0; i < TableName.Rows.Count; i++)
                    {
                        RowRead++;
                        Percent = (int)(100 * RowRead / TotalCount);
                        System.Windows.Forms.Application.DoEvents();

                        string strData = "";
                        for (int j = 0; j < TableName.Columns.Count; j++)
                        {
                            if (j > 0)
                            {
                                strData += "\t";
                            }
                            strData += TableName.Rows[i][j].ToString();
                        }
                        sw.WriteLine(strData);
                    }
                    //关闭数据流
                    sw.Close();
                    myStream.Close();
                    //关闭秒钟
                    timer.Reset();
                    timer.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    //关闭数据流
                    sw.Close();
                    myStream.Close();
                    //关闭秒钟
                    timer.Stop();
                }

            }
        }

        public IEnumerable<pts> ImportExcel(string exc_path)
        {
            var res = MiniExcel.Query<pts>(exc_path);
            if (res != null)
            {
                return res;
            }
            else { return null; }

        }


    }
}
