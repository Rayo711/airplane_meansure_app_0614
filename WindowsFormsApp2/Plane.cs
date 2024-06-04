using NPOI.SS.Formula.Functions;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp2.Myexcel;
using iTextSharp;
using PointCloud;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;
using iTextSharp.text;
using NPOI.Util;
using MpLib;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using iTextSharp.text.pdf;

namespace WindowsFormsApp2
{
    public partial class Plane : Form
    {
        List<Point_cloud> pointDataList = new List<Point_cloud> { };
        Vector3 zeros = new Vector3((float)0.0, (float)0.0, (float)0.0);
        List<Vector2> paint = new List<Vector2>();
        System.Drawing.Image img = null;
        MpClass mpObj = Main.mpObj;
        BindingList<Instrument> mInsList;
        BindingList<Instrument> mConnectedInsList;
        List<string> Ptnames = new List<string>();
        //测量内容面板
        private Panel[] panels;
        private DataGridView[] dataGridViews;
        private string[] dataGridViewsName;

        public Plane(BindingList<Instrument> _mInsList, BindingList<Instrument> _mConnectedInsList)
        {
            InitializeComponent();
            init_meansure_step();
            img = pictureBox_sp1.Image;
            mInsList = _mInsList;
            mConnectedInsList = _mConnectedInsList;
            plane_devselect.DataSource = mConnectedInsList;
            plane_devselect.DisplayMember = "Name";
            plane_devselect.ValueMember = "InsID";
            
            // 初始化面板数组
            panels = new Panel[]
            {
                panel02, panel03, panel04, panel05, panel06, panel07, panel08, panel09, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18
            };
            dataGridViews = new DataGridView[]
            {
               dataGridView1, dataGridView2, dataGridView3, dataGridView4, dataGridView5, dataGridView6, dataGridView7, dataGridView8, dataGridView9, dataGridView10,
               dataGridView11, dataGridView12, dataGridView13, dataGridView14, dataGridView15, dataGridView16, dataGridView17, dataGridView18, dataGridView19, dataGridView20,
               dataGridView21, dataGridView22, dataGridView23
            };
            dataGridViewsName = new string[]
            {
                "机身测量", "机身测量", "机翼测量", "机翼测量", "机翼测量",
                "机翼测量", "鸭翼测量", "鸭翼测量", "鸭翼测量", "垂尾测量",
                "垂尾测量", "垂尾测量", "进气道测量", "进气道测量", "腹鳍测量",
                "腹鳍测量", "起落架测量", "起落架测量", "起落架测量", "起落架测量",
                "起落架测量", "起落架测量", "外挂物挂架"
            };
        }
        private void btn_import_plane_std_Click(object sender, EventArgs e)
        {
            string fileName = null;
            OpenFileDialog dlg = new OpenFileDialog { Filter = "txt文件|*.txt", Title = "请选择一个文本文件" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
            }
            else return;

            string[] ptdata = File.ReadAllLines(fileName);

            // 将PointData列表绑定到DataGridView的数据源
            for (int i = 0; i < ptdata.Length; i++)
            {
                string strs = ptdata[i].ToString();
                string name = strs.Split(' ')[0];
                Vector3 vector = new Vector3(StrToFloat(strs.Split(' ')[1]), StrToFloat(strs.Split(' ')[2]), StrToFloat(strs.Split(' ')[3]));
                Ptnames.Add(name);
                pointDataList.Add(new Point_cloud(name, vector, zeros));

                paint.Add(new Vector2(5*i,5*i));//测试用
            }
            dataGridView_plane.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView_plane.DataSource = pointDataList;
            dataGridView_plane.AllowUserToAddRows = false;
            dataGridView_plane.Refresh();

        }
        public float StrToFloat(object FloatString)
        {
            float result;
            if (FloatString != null)
            {
                if (float.TryParse(FloatString.ToString(), out result))
                    return result;
                else
                {
                    return (float)0.00;
                }
            }
            else
            {
                return (float)0.00;
            }
        }

        private void init_meansure_step() 
        {
            //机身测量1机身扭转角
            dataGridView1.Rows.Add("精度要求", "1.9614±0.0231");
            dataGridView1.Rows.Add("左");
            dataGridView1.Rows.Add("右");
            //机身测量2机身侧面倾角
            dataGridView2.Rows.Add("精度要求","1.9626±0.0210");
            dataGridView2.Rows.Add("左");
            dataGridView2.Rows.Add("右");
            //机翼测量1机翼安装角
            dataGridView3.Rows.Add("单侧精度","33.6±1.8", "-20.6±1.6", "-73.2±2.6", "7.5±2.2", "-43.1±2.4", "-35.4±1.5", "-25.9±1.6");
            dataGridView3.Rows.Add("Z左");
            dataGridView3.Rows.Add("Z右");
            dataGridView3.Rows.Add("对称精度", "0.0±2.3", "0.0±2.0", "0.0±3.3", "0.0±2.8", "0.0±3.0", "0.0±1.9", "0.0±2.0");
            dataGridView3.Rows.Add("Z左-Z右");
            //机翼测量2机翼下反角
            dataGridView4.Rows.Add("单侧精度", "72.6±5.9");
            dataGridView4.Rows.Add("Z左");
            dataGridView4.Rows.Add("Z右");
            dataGridView4.Rows.Add("对称精度", "0.0±5.9");
            dataGridView4.Rows.Add("Z左-Z右");
            //机翼测量3机翼前缘后掠角
            dataGridView5.Rows.Add("精度要求", "1.9626±0.0210");
            dataGridView5.Rows.Add("左");
            dataGridView5.Rows.Add("右");
            //机翼测量4机翼定位精度
            dataGridView6.Rows.Add("单侧精度", "3894.3±3.9", "15840.0±5.0");
            dataGridView6.Rows.Add("左");
            dataGridView6.Rows.Add("右");
            dataGridView6.Rows.Add("对称精度", "0.0±2.4", "0.0±3.8");
            dataGridView6.Rows.Add("左-右");
            //鸭翼测量1鸭翼安装角
            dataGridView7.Rows.Add("单侧精度", "18.7±1.5", "-11.7±3.2", "-26.6±1.7");
            dataGridView7.Rows.Add("左");
            dataGridView7.Rows.Add("右");
            //鸭翼测量2鸭翼上反角
            dataGridView8.Rows.Add("单侧精度", "275.6±3.7");
            dataGridView8.Rows.Add("Z左");
            dataGridView8.Rows.Add("Z右");
            dataGridView8.Rows.Add("对称精度", "0.0±4.1");
            dataGridView8.Rows.Add("Z左-Z右");
            //鸭翼测量3定位精度及对称性
            dataGridView9.Rows.Add("单侧精度", "2846.3±2.4", "8076.6±5.0");
            dataGridView9.Rows.Add("左");
            dataGridView9.Rows.Add("右");
            dataGridView9.Rows.Add("对称精度", "0.0±2.4", "0.0±1.6");
            dataGridView9.Rows.Add("左-右");
            //垂尾测量1垂尾安装角
            dataGridView10.Rows.Add("单侧精度", "98.8±2.1", "77.2±1.1", "8.5±2.1", "9.8±1.1");
            dataGridView10.Rows.Add("左");
            dataGridView10.Rows.Add("右");
            //垂尾测量2垂尾倾斜角
            dataGridView11.Rows.Add("精度要求", "2.1033±0.0146");
            dataGridView11.Rows.Add("左");
            dataGridView11.Rows.Add("右");
            //垂尾测量3垂尾定位精度及对称性
            dataGridView12.Rows.Add("单侧精度", "2338.1±2.4", "18740.0±5.0");
            dataGridView12.Rows.Add("左");
            dataGridView12.Rows.Add("右");
            dataGridView12.Rows.Add("对称精度", "0.0±2.4", "0.0±5.5");
            dataGridView12.Rows.Add("左-右");
            //进气道捕获面积测量
            dataGridView13.Rows.Add("单侧精度", "491.6±1.5", "754.3±1.8", "756.1±1.8", "1048.9±2.1");
            dataGridView13.Rows.Add("左");
            dataGridView13.Rows.Add("右");
            dataGridView14.Rows.Add("单侧精度", "1088.2±2.1", "1460.8±2.5", "669.6±1.7", "754.5±1.8");
            dataGridView14.Rows.Add("左");
            dataGridView14.Rows.Add("右");
            //腹鳍测量1腹鳍安装角
            dataGridView15.Rows.Add("单侧精度", "0.0±2.2");
            dataGridView15.Rows.Add("左");
            dataGridView15.Rows.Add("右");
            //腹鳍测量2腹鳍倾斜角
            dataGridView16.Rows.Add("单侧精度", "356.4±1.8", "699.4±1.0");
            dataGridView16.Rows.Add("左");
            dataGridView16.Rows.Add("右");
            //起落架测量1前主轮距
            dataGridView17.Rows.Add("精度要求", "6787.1±16.0");
            dataGridView17.Rows.Add("测量结果");
            //起落架测量2第13550框轴线至主轮距离
            dataGridView18.Rows.Add("单侧精度", "250.0±6.0");
            dataGridView18.Rows.Add("l左");
            dataGridView18.Rows.Add("l右");
            dataGridView18.Rows.Add("对称精度", "0.0±6.0");
            dataGridView18.Rows.Add("l左-l右");
            //起落架测量3横向主轮距
            dataGridView19.Rows.Add("精度要求", "3696.8±10.0");
            dataGridView19.Rows.Add("测量结果");
            //起落架测量4主轮安装对称性
            dataGridView20.Rows.Add("精度要求", "0.0±5.0");
            dataGridView20.Rows.Add("测量结果");
            //起落架测量5主轮倾角
            dataGridView21.Rows.Add("精度要求", "1.5°±25′");
            dataGridView21.Rows.Add("左");
            dataGridView21.Rows.Add("右");
            //起落架测量6前轮对称性
            dataGridView22.Rows.Add("精度要求", "0.0±25′", "0.0±4.0");
            dataGridView22.Rows.Add("测量结果");
            //外挂物挂架俯仰角
            dataGridView23.Rows.Add("精度要求(内)", "0.0±1.5", "3150.0±4.0", "0.0±1.5");
            dataGridView23.Rows.Add("测量结果");
            dataGridView23.Rows.Add("精度要求(外)", "0.0±1.5", "4550.0±4.0", "0.0±1.5");
            dataGridView23.Rows.Add("测量结果");

        }

        private void plane_save_Click(object sender, EventArgs e)
        {
            ///保存PDF
            SetAllPanel_visible();
            foreach (var panel in panels) 
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height);
                using (Bitmap bmp = new Bitmap(rect.Width, rect.Height))
                {
                    panel.DrawToBitmap(bmp, rect);
                    bmp.Save(info.save_path + "/" + panel.Name + ".jpg");
                }
            }
            string save_path = info.save_path;
            string[] FileNames = Directory.GetFiles(save_path, "*");
            string filePathOnly = save_path + "/";
            string folderName = DateTime.Now.ToString("yyyy_MM_dd HH：mm");
            string pdfPath = filePathOnly + folderName + ".pdf";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            int jpg_i = 0;
            using (iTextSharp.text.Document document = new iTextSharp.text.Document())
            {

                using (FileStream PdfStream = new FileStream(pdfPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (iTextSharp.text.pdf.PdfWriter write = PdfWriter.GetInstance(document, PdfStream))
                    {
                        document.SetMargins(0, 0, 0, 0);
                        document.Open();
                        iTextSharp.text.Image jpg = null;
                        foreach (string file in FileNames)
                        {
                            try
                            {
                                System.Drawing.Image SImage = System.Drawing.Image.FromFile(file);
                                int Width = SImage.Width;
                                int Height = SImage.Height;
                                SImage.Dispose();
                                jpg = iTextSharp.text.Image.GetInstance(file);
                                document.SetPageSize(new iTextSharp.text.Rectangle(Width, Height));
                                document.NewPage();
                                document.Add(jpg);
                                jpg_i++;
                            }
                            catch
                            { }
                        }
                        write.Flush();
                        document.Close();
                    }

                }

            }
            sw.Stop();
            double double_sec = sw.ElapsedMilliseconds / 1000.0;
            //MessageBox.Show("合并图片共" + jpg_i.ToString() + "张\n\r存储时间为：" + DateTime.Now.ToString() + "\n\r存储位置为：" + pdfPath);
            GC.Collect();
            System.Diagnostics.Process.Start(filePathOnly);




            ///保存EXCEL
            ISheet worksheet;
            // 创建一个新的XSSFWorkbook对象
            IWorkbook workbook = new XSSFWorkbook();

            // 遍历你的DataGridView控件
            for (int i = 0; i < dataGridViews.Length; i++)
            {
                // 检查是否存在同名的 Sheet
                if (workbook.GetSheet(dataGridViewsName[i]) != null)
                {
                    worksheet = workbook.GetSheet(dataGridViewsName[i]);
                    // 获取 Sheet 的最后一行索引
                    int lastRowIndex = worksheet.LastRowNum + 2;

                    // 写入列名
                    IRow headerRow = worksheet.CreateRow(lastRowIndex);
                    for (int j = 0; j < dataGridViews[i].Columns.Count; j++)
                    {
                        headerRow.CreateCell(j).SetCellValue(dataGridViews[i].Columns[j].HeaderText);
                    }

                    // 遍历 DataGridView 控件中的每一行
                    for (int x = 0; x < dataGridViews[i].Rows.Count; x++)
                    {
                        IRow row = worksheet.CreateRow(lastRowIndex + 1 + x);
                        // 写入数据
                        for (int j = 0; j < dataGridViews[i].Columns.Count; j++)
                        {
                            // 创建单元格并设置值
                            if (dataGridViews[i].Rows[x].Cells[j].Value == null)
                            {
                                // 处理单元格值为 null 的情况，例如设置一个默认值
                                row.CreateCell(j).SetCellValue("");
                            }
                            else
                            {
                                row.CreateCell(j).SetCellValue(dataGridViews[i].Rows[x].Cells[j].Value.ToString());
                            }
                        }
                    }

                }
                else
                {
                    worksheet = workbook.CreateSheet(dataGridViewsName[i]);
                    // 写入列名
                    IRow headerRow = worksheet.CreateRow(0);
                    for (int j = 0; j < dataGridViews[i].Columns.Count; j++)
                    {
                        headerRow.CreateCell(j).SetCellValue(dataGridViews[i].Columns[j].HeaderText);
                    }
                    // 写入数据
                    for (int x = 0; x < dataGridViews[i].Rows.Count; x++) // 假设 dataGridView1 是你的 DataGridView 控件
                    {
                        IRow row = worksheet.CreateRow(x + 1);
                        for (int j = 0; j < dataGridViews[i].Columns.Count; j++)
                        {
                            // 创建单元格并设置值
                            if (dataGridViews[i].Rows[x].Cells[j].Value == null)
                            {
                                // 处理单元格值为 null 的情况，例如设置一个默认值
                                row.CreateCell(j).SetCellValue("");
                            }
                            else
                            {
                                row.CreateCell(j).SetCellValue(dataGridViews[i].Rows[x].Cells[j].Value.ToString());
                            }
                        }
                    }
                }
            }
            // 保存 Excel 文件
            using (FileStream file = new FileStream(info.save_path + "/全机水平测量结果.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
            MessageBox.Show("成功保存全机水平测量结果");


        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 隐藏所有面板
            SetAllPanel_invisible();

            // 获取选中的索引
            int selectedIndex = comboBox1.SelectedIndex;

            // 确保索引在有效范围内
            if (selectedIndex >= 0 && selectedIndex < panels.Length)
            {
                // 显示选中的面板并设置位置
                panels[selectedIndex].Visible = true;
                panels[selectedIndex].Location = new System.Drawing.Point(15, 13);
            }
        }


        private void SetAllPanel_invisible()
        {
            // 隐藏所有面板
            foreach (var panel in panels)
            {
                panel.Visible = false;
            }
        }

        private void SetAllPanel_visible()
        {
            // 隐藏所有面板
            foreach (var panel in panels)
            {
                panel.Visible = true;
            }
        }

        private void btn_plane_devloc_Click(object sender, EventArgs e)
        {
            Locate locate = new Locate(mInsList, mConnectedInsList);
        }

        private void dataGridView_plane_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("未点击到坐标！");
                return;
            }

            // 创建一个新的 Bitmap 对象，大小与原始图片相同
            Bitmap newImage = new Bitmap(img);

            // 使用 Graphics 对象在新的 Bitmap 上绘制
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // 绘制新的图形
                g.FillEllipse(Brushes.Red, paint[e.RowIndex].X, paint[e.RowIndex].Y, 5, 5);
            }

            // 将新的 Bitmap 设置为 pictureBox_sp1 的 Image 属性
            pictureBox_sp1.Image = newImage;

            // 指点测量
            Vector3 vec = (Vector3)dataGridView_plane.Rows[e.RowIndex].Cells[1].Value;
            MessageBox.Show(vec.ToString());


        }

        private void btn_plane_means_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            //获取需要连接的仪器ID
            //DataGridViewRow selectedRow = dataGridView_plane.CurrentRow;
            //DataTable dt = ((DataTable)dataGridView_plane.DataSource)[selectedRow.Index];

            //测量数据
            double x = 0, y = 0, z = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有原点，删除原点
                    int ind = dataGridView_plane.CurrentRow.Index;
                    string[] listPntToDelete = new string[1];
                    string point_0 = "A::全机::" + Ptnames[ind];
                    //listPntToDelete[0] = "A::全机::P1";
                    listPntToDelete[0] = point_0;
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt(point_0))
                    {
                        MessageBox.Show("测量全机" + Ptnames[ind] + "成功！");
                        mpObj.GetPointCoordinate("A", "全机", Ptnames[ind], ref x, ref y, ref z);
                        //TODO：把点信息显示到界面上
                        pointDataList[ind].Set_mean((float)x, (float)y, (float)z);
                    }
                    else
                    {
                        MessageBox.Show("测量全机" + Ptnames[ind] + "失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }
        }

        private int GetSelectedRowIndex(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                return 0;
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Selected)
                {
                    return row.Index;
                }
            }
            return 0;
        }

    }
}
