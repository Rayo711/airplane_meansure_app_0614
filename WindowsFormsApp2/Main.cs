using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using NUnit.Framework.Constraints;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using NPOI.XWPF.UserModel;
using static WindowsFormsApp2.Myexcel;
using NPOI.OpenXmlFormats.Dml.Diagram;
using MathNet.Numerics.Distributions;
using NPOI.Util;
using MpLib;
using System.Reflection;
using System.Runtime.InteropServices;
using PointCloud;
using System.Numerics;
using System.IO.Ports;

namespace WindowsFormsApp2
{
    public partial class Main : Form
    {
        public string log;
        public double frame_scale = 1;
        public string stime;
        public string etime;
        public bool video_flag = false;
        private VideoCapture capture;
        public string step_textpath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + "/operate_schedule/";
        private bool fullScreenFlag1 = false;

        public SerialPort serialPort1 = new SerialPort();

        Myexcel myexcel = new Myexcel();
        public Main()
        {
            InitializeComponent();

            //mInsList.AllowNew = true; // 允许添加新项
            //mInsList.AllowEdit = true; // 允许编辑项
            //mInsList.AllowRemove = true; // 允许删除

            //People p = this.bindingSource1.DataSource as People;
            //this.tbName.DataBindings.Add(nameof(this.tbName.Text), this.bindingSource1, nameof(p.Name));
            //this.tbAge.DataBindings.Add(nameof(this.tbAge.Text), this.bindingSource1, nameof(p.Age), true, DataSourceUpdateMode.OnValidation);
            //this.errorProvider1.DataSource = this.bindingSource1;
            //dataGridView_dev.DataSource = mInsList;
            //mInsList.DataBind();

            //WindowState = FormWindowState.Maximized;

            mInsList = new BindingList<Instrument>();
            mConnectedInsList = new BindingList<Instrument>();

            //数据绑定
            //BindingList <Instrument> bList  = new BindingList<Instrument>(mInsList);
            dataGridView_dev.DataSource = mInsList;
            combSelTracker.DataSource = mConnectedInsList;
            combSelTracker.DisplayMember = "Name";
            combSelTracker.ValueMember = "InsID";

            comboBox_loc_dev_select.DataSource = mConnectedInsList;
            comboBox_loc_dev_select.DisplayMember = "Name";
            comboBox_loc_dev_select.ValueMember = "InsID";

            conv_dev_select.DataSource = mConnectedInsList;
            conv_dev_select.DisplayMember = "Name";
            conv_dev_select.ValueMember = "InsID";

            plane_devselect.DataSource = mConnectedInsList;
            plane_devselect.DisplayMember = "Name";
            plane_devselect.ValueMember = "InsID";
            mean_process.Text = info.doc_text;
            //create_tables();
            dgv_DoubleBuffer_init();


        }
        //地面基准坐标系原点测量
        private void btn_o_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有原点，删除原点
                    string[] listPntToDelete = new string[1];
                    listPntToDelete[0] = "A::坐标系::原点";
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::坐标系::原点"))
                    {
                        MessageBox.Show("测量原点成功！");
                        //TODO：把点信息显示到界面上
                    }
                    else
                    {
                        MessageBox.Show("测量原点失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }

        }
    
        //地面基准坐标系X轴方向点测量
        private void btn_x_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有原点，删除原点
                    string[] listPntToDelete = new string[1];
                    listPntToDelete[0] = "A::坐标系::X";
                    mpObj.DeletePoints(listPntToDelete);
                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::坐标系::X"))
                    {
                        MessageBox.Show("测量X成功！");
                        //TODO：把点信息显示到界面上
                    }
                    else
                    {
                        MessageBox.Show("测量X失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }

        }
        //地面基准坐标系Y轴方向点测量
        private void btn_y_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有原点，删除原点
                    string[] listPntToDelete = new string[1];
                    listPntToDelete[0] = "A::坐标系::Y";
                    mpObj.DeletePoints(listPntToDelete);
                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::坐标系::Y"))
                    {
                        MessageBox.Show("测量Y成功！");
                        //TODO：把点信息显示到界面上
                    }
                    else
                    {
                        MessageBox.Show("测量Y失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }
        }


        //读取操作步骤text
        public static string ReadTxtContent(string txtPath)
        {
            string Path = txtPath;

            StreamReader sr = new StreamReader(Path, Encoding.UTF8);
            string content;
            string res = "";
            while ((content = sr.ReadLine()) != null)
            {
                res += content + "\n";
            }
            sr.Close();
            return res;
        }
        //左侧按键触发-设备连接
        private void button17_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_dev;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\设备连接.txt";
            string text_path = step_textpath + "/设备连接.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }

        //左侧按键触发-仪器定位
        private void btn_gnd_meansure_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_gnd;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\仪器定位.txt";
            string text_path = step_textpath + "/仪器定位.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }

        //左侧按键触发-全机水平测量
        private void btn_plane_meansure_Click(object sender, EventArgs e)
        {
            //tabcontrol_main.SelectedTab = page_plane;
            //stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            //log += mean_process.Text + "\n";
            //mean_process.Clear();
            ////string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\全机水平测量.txt";
            //string text_path = step_textpath + "/全机水平测量.txt";
            //string text_strs = ReadTxtContent(text_path);
            //mean_process.Text = text_strs;
            Plane plane = new Plane(mInsList, mConnectedInsList);
            plane.ShowDialog();

        }

        //左侧按键触发-雷达系统
        private void btn_radar_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_radar;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\雷达系统.txt";
            string text_path = step_textpath + "/雷达系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }
        //左侧按键触发-电子战系统
        private void btn_elec_war_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_dzz;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\电子战系统.txt";
            string text_path = step_textpath + "/电子战系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }
        //左侧按键触发-CNI子系统
        private void btn_CNI_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_cni;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\CNI子系统.txt";
            string text_path = step_textpath + "/CNI子系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }
        //左侧按键触发-平显系统-座舱控制与显示系统
        private void btn_disp_cont_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_px;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\平显系统.txt";
            string text_path = step_textpath + "/平显系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }
        //左侧按键触发-惯性参考系统
        private void btn_IRS_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_irs;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\惯性参考系统.txt";
            string text_path = step_textpath + "/惯性参考系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;

        }
        //左侧按键触发-飞控系统
        private void btn_FCS_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_fcs;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\飞控系统.txt";
            string text_path = step_textpath + "/飞控系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }
        //左侧按键触发-光电分布式孔径雷达
        private void btn_ODA_radar_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_gd;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
            //string text_path = @"F:\\C#_proj\\airplane_meansure_app_0416\\WindowsFormsApp2\\operate_schedule\\光雷系统.txt";
            string text_path = step_textpath + "/光雷系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }


        //导入飞机理论值
        private void btn_import_conv_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_conv);

        }

        //导入机体靶点标准值
        private void button5_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_plane);
        }

        //导入电子战理论值
        private void btn_import_dzz_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_dzz);
        }
        //导入雷达理论值
        private void btn_import_radar_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_radar);
        }
        //导入CNI理论值
        private void btn_import_cni_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_cni);
        }
        //导入平显理论值
        private void btn_import_px_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_px);
        }
        //导入惯性组件理论值
        private void btn_import_irs_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_irs);
        }
        //导入飞控理论值
        private void btn_import_fcs_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_fcs);
        }
        //导入光电理论值
        private void btn_import_gd_std_Click(object sender, EventArgs e)
        {
            //Import_std_data(dt_gd);
        }
        //导入理论值函数
        public void Import_std_data(DataTable target_ob)
        {
            //Myexcel myexcel = new Myexcel();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "excel文件|*.xlsx";
            object fileName = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName1 = dlg.FileName;
                fileName = fileName1;
            }
            string str = (string)fileName;
            IEnumerable<pts> stddata = myexcel.ImportExcel(str);
            target_ob.Rows.Clear();
            foreach (pts pts in stddata)
            {
                target_ob.Rows.Add(pts.ptname,pts.coordx,pts.coordy,pts.coordz);

            }

        }

        //连接摄像头
        private void btn_cam_connect_Click(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
            Mat frame = new Mat();
            video_flag = true;

            if (!capture.IsOpened()) // 如果摄像头打开失败
            {
                MessageBox.Show("相机连接失败");
                return;
            }

            Thread video_th = new Thread(StartCapturing);
            video_th.IsBackground = true;
            video_th.Start();
        }

        public void StartCapturing()
        {
            Mat frame = new Mat();
            Mat new_frame = new Mat();
            while (video_flag)
            {
                capture.Read(frame);
                if (frame.Empty())
                {
                    break;
                }
                using (Mat hsvImage = new Mat())
                using (Mat redMask1 = new Mat())
                using (Mat redMask2 = new Mat())
                using (Mat redMask = new Mat())
                {
                    Cv2.CvtColor(frame, hsvImage, ColorConversionCodes.BGR2HSV);
                    // 在HSV图像中定义红色范围
                    Scalar lowerRed1 = new Scalar(0, 100, 100);
                    Scalar upperRed1 = new Scalar(10, 255, 255);
                    Scalar lowerRed2 = new Scalar(160, 100, 100);
                    Scalar upperRed2 = new Scalar(179, 255, 255);
                    // 通过颜色阈值，提取红色区域
                    Cv2.InRange(hsvImage, lowerRed1, upperRed1, redMask1);
                    Cv2.InRange(hsvImage, lowerRed2, upperRed2, redMask2);
                    Cv2.Add(redMask1, redMask2, redMask);
                    // 寻找红点的轮廓
                    OpenCvSharp.Point[][] contours = Cv2.FindContoursAsArray(redMask, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                    // 计算红点的中心并标记
                    if (contours.Length > 0)
                    {
                        Moments moments = Cv2.Moments(contours[0]);
                        OpenCvSharp.Point center = new OpenCvSharp.Point((int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00));
                        Cv2.Circle(frame, center, 3, new Scalar(255, 0, 0), -1);
                        
                    }
                }
                // 将帧显示到 pictureBox1 中
                Cv2.Resize(frame, new_frame, new OpenCvSharp.Size(640 * frame_scale, 480 * frame_scale), 0, 0);
                pictureBox1.Image = new_frame.ToBitmap(); 

                // 控制处理速度
                Thread.Sleep(50);
            }
            capture.Release(); // 释放视频捕获对象
            FlushMemory();
        }
        public static void FlushMemory()
        {
            GarbageCollect();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 主动通知系统进行垃圾回收
        /// </summary>
        public static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        //关闭摄像头
        private void btn_disconnect_cam_Click(object sender, EventArgs e)
        {
            video_flag = false;
            pictureBox1.Image = null;

        }
        //相机缩放
        private void zoomin_Click(object sender, EventArgs e)
        {
            frame_scale *= 1.2;
        }
        //相机缩放
        private void zoomout_Click(object sender, EventArgs e)
        {
            frame_scale *= 0.8;
        }
        //主程序退出
        private void close_main_Click(object sender, EventArgs e)
        {
            log += mean_process.Text;
 
            System.IO.File.WriteAllText(info.save_path + "/log.txt", log);

            System.Environment.Exit(0);
        }

        //保存全机测量数据
        private void plane_save_Click(object sender, EventArgs e)
        {

            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_plane.DataSource, filename);
        }

        //保存雷达测量数据
        private void radar_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_radar.DataSource, filename);
        }

        //保存电子战系统测量单天线数据
        private void btn_dzz_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_dzz.DataSource, filename);
        }

        //保存CNI数据
        private void cni_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_cni.DataSource, filename);
        }
        //保存平显数据
        private void px_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_px.DataSource, filename);
        }
        //保存惯性系统数据
        private void irs_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_irs.DataSource, filename);
        }
        //保存飞控系统数据
        private void fcs_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_fcs.DataSource, filename);
        }
        //保存光电分布式孔径雷达数据
        private void gd_save_Click(object sender, EventArgs e)
        {
            etime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            string filename = info.plane_num + "_" + tabcontrol_main.SelectedTab.Text + "_" + stime + "_" + etime;
            //Myexcel myexcel = new Myexcel();
            myexcel.ExportDataToExcel((DataTable)dataGridView_gd.DataSource, filename);
        }
        //计算飞机坐标系
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //转台控制
        private void btn_table_control_Click(object sender, EventArgs e)
        {
            double a = 0; //设备间距
            double b = 0; //激光点距离
            double gamma = 0; //激光测距仪转角
            //获取激光点距离和转角

            

            //计算转台转角
            double gammaRadians = gamma * (Math.PI / 180);
            double cosgamma = Math.Cos(gammaRadians);
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * cosgamma);
            //
            double alphaInRadians = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c));
            double alphaInDegrees = alphaInRadians * (180.0 / Math.PI);
            double betaDegrees = 180 - alphaInDegrees - gammaRadians * (180.0 / Math.PI);

            //传输转台指令
            //程序设置左右转动时，向左为负，比如向左转动45度，命令为-45。
            double horizontaloAngle = double.Parse(textBox1.Text);//接收左右转动数据，因为不知道需求，这里新建文本框进行传输，还要结合激光雷达距离进行角度换算
            horizontaloAngle = horizontaloAngle * 100;
            double verticalAngle = double.Parse(textBox2.Text);//接收上下转动角度
                                                               //double verticalAngle = 0;//激光测距仪垂直角度
            verticalAngle = verticalAngle * 100;

            if ((horizontaloAngle >= -6500 && horizontaloAngle <= 6500) && (verticalAngle > -4000 && verticalAngle <= 9000))
            {
                try
                {
                    if (horizontaloAngle <= -6500)
                    {
                        MessageBox.Show("水平角度超出限制", "提示");

                    }
                    else if (horizontaloAngle >= -6500 && horizontaloAngle <= 0)
                    {
                        horizontaloAngle = horizontaloAngle + 36000;
                        sendCommond(CalCulaTion(0, 0x4b, Convert.ToString((int)horizontaloAngle / 256), Convert.ToString((int)horizontaloAngle % 256)));
                    }
                    else if (horizontaloAngle >= 0 && horizontaloAngle <= 6500)
                    {
                        sendCommond(CalCulaTion(0, 0x4b, Convert.ToString((int)horizontaloAngle / 256), Convert.ToString((int)horizontaloAngle % 256)));

                    }
                }
                catch
                {
                    MessageBox.Show("水平角度传输有误", "提示");
                }
                try
                {

                    if (verticalAngle < -4000)
                    {
                        MessageBox.Show("垂直角度超出限制", "提示");
                    }
                    else if (verticalAngle > -4000 && verticalAngle <= 0)
                    {
                        sendCommond(CalCulaTion(0, 0x4d, Convert.ToString((int)verticalAngle / 256), Convert.ToString((int)verticalAngle % 256)));

                    }
                    else if (verticalAngle >= 0 && verticalAngle <= 9000)
                    {
                        sendCommond(CalCulaTion(0, 0x4d, Convert.ToString((int)verticalAngle / 256), Convert.ToString((int)verticalAngle % 256)));
                    }
                }
                catch
                {
                    MessageBox.Show("垂直角度传输有误", "提示");
                }
            }
            else
            {
                MessageBox.Show("角度超出限制", "提示");
            }

        }
        private String CalCulaTion(int com1, int com2, String textData1, String textData2)
        {
            string cal = "";

            int[] data1 = new int[7];

            data1[0] = 0xFF;
            data1[1] = Convert.ToInt16(1);
            data1[2] = com1;
            data1[3] = com2;
            data1[4] = Convert.ToInt16(textData1);
            data1[5] = Convert.ToInt16(textData2);
            data1[6] = (data1[1] + data1[2] + data1[3] + data1[4] + data1[5]) & 0x00FF;

            for (int i = 0; i < 7; i++)
            {
                cal += data1[i].ToString("X2") + " ";
            }

            return cal;
        }
        private void sendCommond(String com)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    //textBox7.Text = com;//显示发送数据
                    sendData(com);
                }
                catch
                {
                    MessageBox.Show("发送错误！", "提示");
                }
            }
            else if (!serialPort1.IsOpen)
            {
                //textBox7.Text = com;
                MessageBox.Show("串口未打开！", "提示");
            }
        }
        private void sendData(String Send_Data)
        {
            byte[] Data = new byte[1];//字节数组``

            try
            {
                string str = "";
                char[] st;
                st = Send_Data.ToCharArray();
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i] != ' ')
                    {
                        str += st[i];
                    }
                }
                for (int i = 0; i < str.Length / 2; i++)
                {
                    //每次取两位字符组成一个16进制
                    Data[0] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    serialPort1.Write(Data, 0, 1);//循环发送（如果输入字符为0A0BB,则只发送0A,0B）
                }
                if (str.Length % 2 != 0)//剩下一位单独处理
                {
                    Data[0] = Convert.ToByte(str.Substring(str.Length - 1, 1), 16);//单独发送B（0B）
                    serialPort1.Write(Data, 0, 1);//发送
                }
            }
            catch
            {
                MessageBox.Show("发送出错", "提示");
            }
        }

        //转台链接
        private void btn_table_connect_Click(object sender, EventArgs e)
        {
            if (IsOpen())
            {
                MessageBox.Show("转台已连接，请勿重复点击", "提示");
            }
            else
            {
                text_Serial_port();
                SetSerialPortConfig("COM2", 9600, 1, 8, 1);//这里串口需更改为创建的虚拟串口
                serialPort1.Open();//打开串口
                MessageBox.Show("连接成功", "提示");
            }
        }
        private bool IsOpen()
        {
            return (serialPort1.IsOpen);
        }
        private void text_Serial_port()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames(); //获得可用的串口
            /*for (int i = 0; i < ports.Length; i++)
            {
                if (ports.Contains("2"))
                {

                }
                else
                {
                    MessageBox.Show("请打开虚拟串口软件", "提示");
                }
                //comboBox1.Items.Add(ports[i]);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count > 0 ? 0 : -1;//如果里面有数据,显示第0个*/
        }
        private void SetSerialPortConfig(String portName, int baudRate, int parity, int dataBits, int stopBits)
        {
            serialPort1.PortName = portName;//获取要打开的串口
            serialPort1.BaudRate = baudRate;//获得波特率
            serialPort1.DataBits = dataBits;//获得数据位
            switch (parity)
            {
                case 0:
                default:
                    serialPort1.Parity = Parity.None;
                    break;

                case 1:
                    serialPort1.Parity = Parity.Odd;
                    break;

                case 2:
                    serialPort1.Parity = Parity.Even;
                    break;
            }
            switch (stopBits)
            {
                case 1:
                default:
                    serialPort1.StopBits = StopBits.One;
                    break;

                case 2:
                    serialPort1.StopBits = StopBits.Two;
                    break;
            }
        }


        //连接SA
        private void ConnectSA_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                //Todo:这里sa软件安装位置和模板文件位置需要根据实际情况更改，最好可以通过配置文件设置
                //string _SAPath = "C:\\Program Files (x86)\\New River Kinematics\\SpatialAnalyzer 2014.04.15\\Spatial Analyzer.exe";
                //string FilePath = "D:\\Programming\\airplane_meansure_app_0329\\airplane_meansure_app_0329\\WindowsFormsApp2\\bin\\Debug\\调姿测量.xit";
                string _SAPath = ReadTxtContent(step_textpath + "/SA_path.txt");
                string FilePath = ReadTxtContent(step_textpath + "/mean_path.txt");
                mpObj = new MpClass(_SAPath, FilePath);
            }
            else
            {

                DialogResult result = MessageBox.Show("已连接SA，确定要重新连接吗？", "确认对话框",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // 用户点击了OK
                    ProcessOp op = new ProcessOp();
                    op.KillAllSASDK();
                }
                else
                {
                    // 用户点击了Cancel
                    return;
                }
            }

            if (mpObj.Connect())
            {
                MessageBox.Show("连接SA成功!");

                //自动读取仪器列表
                string col = "A";
                int iInsID = 0;
                //不能直接获取已连接了多少个仪器，通过添加一个仪器，获得他的ID，得到仪器数量；
                if (!mpObj.AddNewInstrument("Leica emScon Absolute Tracker (AT901 Series)", ref col, ref iInsID))
                {
                    MessageBox.Show("添加仪器失败!");
                }
                if (!mpObj.DeleteInstrument(col, iInsID))
                {
                    MessageBox.Show("删除仪器失败!");
                }
                mInsList = new BindingList<Instrument>();

                //数据绑定
                //BindingList <Instrument> bList  = new BindingList<Instrument>(mInsList);

                dataGridView_dev.DataSource = mInsList;
                //for (int i = 0; i < 5; i++)
                //{
                //    bList.Add(new Instrument()
                //    {
                //        InsID = i
                //    });
                //}


                int InsListNum = mInsList.Count();
                for (int i = 0; i < mInsList.Count(); i++)
                {
                    mInsList.RemoveAt(0);
                }
                InsListNum = mConnectedInsList.Count();
                for (int i = 0; i < iInsID; i++)
                {
                    Instrument ins = new Instrument(mpObj);
                    ins.InsID=i;
                    ins.SetCollectionName(col);
                    ins.Name = "设备" + i.ToString();
                    mInsList.Add(ins);
                    ins.GetInsInfo();

                    if (ins.Connected)
                    {
                        mConnectedInsList.Add(ins);
                    }
                }

            }
            else
            {
                MessageBox.Show("连接SA失败，请打开SA软件！");
            }
        }

        //添加仪器
        private void btn_dev_add_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            int InsID = 0;
            string col = "A";

            if (mpObj.AddNewInstrument("Leica emScon Absolute Tracker(AT901 Series)", ref col, ref InsID))
            {
                Instrument ins = new Instrument(mpObj);
                ins.InsID = InsID;
                ins.InsType = "Leica emScon Absolute Tracker(AT901 Series)";
                ins.Connected = true;
                ins.SetCollectionName(col);
                mInsList.Add(ins);
            }
            else
            {
                MessageBox.Show("添加仪器失败！");
                return;
            }
            //把仪器信息显示到界面上；

        }

        //连接仪器
        private void btn_dev_connect_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            DataGridViewRow selectedRow = dataGridView_dev.CurrentRow;
            Instrument In = ((BindingList<Instrument>)dataGridView_dev.DataSource)[selectedRow.Index];
            if (In.Connected)
            {
                MessageBox.Show("选中的仪器已连接！");
                return;
            }
            else
            {
                int InsIDToConnect = In.InsID;

                if (mInsList.Count() > InsIDToConnect)
                {
                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).StartIns("A", InsIDToConnect, true, "127.0.0.1", true))
                    {
                        mInsList.ElementAt(InsIDToConnect).Connected = true;
                        mConnectedInsList.Add(mInsList.ElementAt(InsIDToConnect));
                        MessageBox.Show("连接仪器成功！");
                    }
                }
                else
                {
                    MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
                }
            }
        }

        //删除仪器
        private void btn_dev_delete_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取列表中的位置并赋值个InsID
            int InsID = 0;
            int InsNumber = mInsList.Count();
            if (mpObj.DeleteInstrument("A", InsID))
            {
                InsNumber--;

                //重新定义仪器列表
                for (int i = 0; i < mInsList.Count(); i++)
                {
                    mInsList.RemoveAt(0);
                }

                for (int i = 0; i < InsNumber; i++)
                {
                    Instrument ins = new Instrument(mpObj);
                    ins. InsID = i;
                    ins.SetCollectionName("A");
                    mInsList.Add(ins);
                }

            }
            else
            {
                MessageBox.Show("删除仪器！");
                return;
            }
        }


        private void combSelTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsLocate(true);
        }

        // 进行仪器定位,把误差取出来
        public bool InsLocate(bool bShowInterface)
        {

            //UpdateData(FALSE);
            //获取当前仪器
            //int InsSel = m_CombIns.GetCurSel();
            //if (-1 == InsSel)
            //{
            //    return FALSE;
            //}
            int InsSel = 0;

            //CInstrument * ins;
            //ins = (CInstrument*)m_CombIns.GetItemData(InsSel);
            //if (NULL == ins)
            //{
            //    return FALSE;
            //}
            Instrument ins = mInsList.ElementAt(InsSel);

            //CStringArray pMeasNameList;
            ////看集合是否存在，没有则可自己添加一个集合
            //CStringArray pTheoNameList;

            List<string> pMeasNameList = new List<string>();
            List<string> pTheoNameList = new List<string>();

            string m_ERSTheoCol = "A";
            string m_ERSTheoGroupName = "Theo";

            string m_ERSMeasCol = "A";
            string m_ERSMeasGroupName = "Meas";

            int Number = 0;
            if (mpObj.GetNumberOfPointsInGroup(m_ERSTheoCol, m_ERSTheoGroupName, ref Number))
            {
                if (Number <= 0)
                {
                    return false;
                }
                if (!mpObj.MakeAPointNameRefListFromAGroup(m_ERSTheoCol, m_ERSTheoGroupName, ref pTheoNameList))
                {
                    //theApp.WriteLog(_T("获取ERS理论点集合失败!"));

                    return false;
                }
            }
            else
            {
                return false;
            }
            //测量集合须重新加载
            if (mpObj.GetNumberOfPointsInGroup(m_ERSMeasCol, m_ERSMeasGroupName, ref Number))
            {
                if (Number <= 0)
                {
                    return false;
                }
                if (!mpObj.MakeAPointNameRefListFromAGroup(m_ERSMeasCol, m_ERSMeasGroupName, ref pMeasNameList))
                {
                    //theApp.WriteLog(_T("获取ERS测量点集合失败!"));
                    return false;
                }
            }
            else
            {
                return false;
            }


            //如果点数不够，则不进行定位
            int ThoeNumber = 0;
            ThoeNumber = pTheoNameList.Count();

            if (ThoeNumber < 3)
            {
                return false;
            }

            int MeasNumber = 0;
            MeasNumber = pMeasNameList.Count();
            string txt = "";
            string Col = "";
            string Grp = "";
            string MeasName = "";
            string TheoName = "";

            if (MeasNumber < 3)
            {
                for (int i = 0; i < MeasNumber; i++)
                {
                    mpObj.GetPntInfoFromName(pMeasNameList.ElementAt(i), ref Col, ref Grp, ref MeasName);
                    for (int j = 0; j < ThoeNumber; j++)
                    {
                        //如果两个点的名称一致
                        mpObj.GetPntInfoFromName(pTheoNameList.ElementAt(j), ref Col, ref Grp, ref TheoName);
                        if (MeasName == TheoName)
                        {
                            //设置误差
                            //txt = _T("****.***");
                            //m_ListERS.SetItemText(j, 1, txt);
                            //m_ListERS.SetItemText(j, 2, txt);
                            //m_ListERS.SetItemText(j, 3, txt);
                            //m_ListERS.SetItemBkColor(j, -1, COLOR_INVALID);
                        }
                    }
                }
                return false;
            }

            //int nItem = 0;
            //LVITEM item;
            //item.mask = LVIF_TEXT | LVIF_IMAGE;
            //item.iItem = nItem;
            //item.iSubItem = 0;
            //仪器定位前，先需要设置当前仪器的站位参数为零，保证

            //定位仪器
            if (ins.LocateInstrumentBestFit(m_ERSTheoCol, m_ERSTheoGroupName, m_ERSMeasCol, m_ERSMeasGroupName, bShowInterface))
            {

                // 定位成功
                //return UpdateErrorView();
            }
            else
            {
                //定位失败
                //for (int i = 0;i<MeasNumber;i++)
                //{
                //	theApp.m_Operator.GetPntInfoFromName(pMeasNameList.GetAt(i),Col,Grp,MeasName);
                //	for (int j = 0;j< ThoeNumber;j++)
                //	{
                //		//如果两个点的名称一致
                //		theApp.m_Operator.GetPntInfoFromName(pTheoNameList.GetAt(j),Col,Grp,TheoName);
                //		if (MeasName == TheoName)	
                //		{
                //			//设置误差
                //			txt = _T("****.***");
                //			m_ListERS.SetItemText(j,1,txt);
                //			m_ListERS.SetItemText(j,2,txt);
                //			m_ListERS.SetItemText(j,3,txt);
                //		}
                //	}
                //}
                return false;
            }
            return false;
        }

        ////初始化数据表
        //public DataTable Dt_init1(DataTable dt)
        //{
        //    dt.Columns.Add("点名", typeof(string));
        //    dt.Columns.Add("X理论值", typeof(float));
        //    dt.Columns.Add("Y理论值", typeof(float));
        //    dt.Columns.Add("Z理论值", typeof(float));
        //    dt.Columns.Add("X测量值", typeof(float));
        //    dt.Columns.Add("Y测量值", typeof(float));
        //    dt.Columns.Add("Z测量值", typeof(float));
        //    dt.Columns.Add("X误差", typeof(float));
        //    dt.Columns.Add("Y误差", typeof(float));
        //    dt.Columns.Add("Z误差", typeof(float));
        //    dt.Columns.Add("平均误差", typeof(float));

        //    return dt;
        //}
        //public DataTable Dt_init2(DataTable dt)
        //{
        //    dt.Columns.Add("点名", typeof(string));
        //    dt.Columns.Add("X理论值", typeof(float));
        //    dt.Columns.Add("Y理论值", typeof(float));
        //    dt.Columns.Add("Z理论值", typeof(float));
        //    dt.Columns.Add("X测量值", typeof(float));
        //    dt.Columns.Add("Y测量值", typeof(float));
        //    dt.Columns.Add("Z测量值", typeof(float));
        //    return dt;
        //}
        //public DataTable Dt_init3(DataTable dt)
        //{
        //    dt.Columns.Add("点名", typeof(string));
        //    dt.Columns.Add("X", typeof(float));
        //    dt.Columns.Add("Y", typeof(float));
        //    dt.Columns.Add("Z", typeof(float));
        //    return dt;
        //}
        ////仪器table
        //public DataTable Dt_init_dev(DataTable dt)
        //{
        //    dt.Columns.Add("ID", typeof(string));
        //    dt.Columns.Add("Name", typeof(string));
        //    dt.Columns.Add("Status", typeof(bool));
        //    return dt;
        //}

        //创建各存放数据的datatable并绑定数据项
        //public void create_tables()
        //{
        //    //仪器信息绑定到仪器类
        //    //dt_dev = Dt_init_dev(dt_dev);
        //    //this.dataGridView_dev.DataSource = dt_dev;
        //    //基准点标定table
        //    dt_gnd = Dt_init3(dt_gnd);
        //    this.dataGridView_gnd.DataSource = dt_gnd;
        //    //仪器定位table
        //    dt_loc = Dt_init2(dt_loc);
        //    this.dataGridView_loc.DataSource = dt_loc;
        //    //飞机坐标系table
        //    dt_conv = Dt_init2(dt_conv);
        //    this.dataGridView_conv.DataSource = dt_conv;


        //    //全机table
        //    //dt_plane = Dt_init1(dt_plane);
        //    //this.dataGridView_plane.DataSource = dt_plane;

        //    //Pc_plane.AddPoint(new Vector3(1, 2, 3));//添加新点

        //    //PointCloudBinder.BindPointCloudToDatatable_mean(Pc_plane, dt_plane);//将数据传到绑定的datasource
        //    //RemoveBlankRows(dataGridView_plane);//移除空白行
        //    //dataGridView_plane.Refresh();//刷新


        //    //雷达table
        //    dt_radar = Dt_init1(dt_radar);
        //    this.dataGridView_radar.DataSource = dt_radar;
        //    //电子战table
        //    dt_dzz = Dt_init1(dt_dzz);
        //    this.dataGridView_dzz.DataSource = dt_dzz;
        //    //CNI table
        //    dt_cni = Dt_init1(dt_cni);
        //    this.dataGridView_cni.DataSource = dt_cni;
        //    //平显table
        //    dt_px = Dt_init1(dt_px);
        //    this.dataGridView_px.DataSource = dt_px;
        //    //惯性table
        //    dt_irs = Dt_init1(dt_irs);
        //    this.dataGridView_irs.DataSource = dt_irs;
        //    //飞控table
        //    dt_fcs = Dt_init1(dt_fcs);
        //    this.dataGridView_fcs.DataSource = dt_fcs;
        //    //光电table
        //    dt_gd = Dt_init1(dt_gd);
        //    this.dataGridView_gd.DataSource = dt_gd;
        //}
        //datagridview数据闪烁
        public void dgv_DoubleBuffer_init()
        {
            dataGridView_dev.DoubleBufferedDataGirdView(true);
            dataGridView_gnd.DoubleBufferedDataGirdView(true);
            dataGridView_loc.DoubleBufferedDataGirdView(true);
            dataGridView_conv.DoubleBufferedDataGirdView(true);
            dataGridView_plane.DoubleBufferedDataGirdView(true);
            dataGridView_radar.DoubleBufferedDataGirdView(true);
            dataGridView_dzz.DoubleBufferedDataGirdView(true);
            dataGridView_cni.DoubleBufferedDataGirdView(true);
            dataGridView_px.DoubleBufferedDataGirdView(true);
            dataGridView_irs.DoubleBufferedDataGirdView(true);
            dataGridView_fcs.DoubleBufferedDataGirdView(true);
            dataGridView_gd.DoubleBufferedDataGirdView(true);
        }

        private void RemoveBlankRows(DataGridView dgv)
        {
            for (int i = dgv.Rows.Count - 1; i >= 0; i--)
            {
                var row = dgv.Rows[i];
                if (row.Cells.Cast<DataGridViewCell>().All(cell => string.IsNullOrEmpty(cell.Value?.ToString())))
                {
                    dgv.Rows.RemoveAt(i);
                }
            }
        }
        //图像界面最大化和恢复
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Drawing.Size primarySize = new System.Drawing.Size(640,480);
            //最大化
            if(fullScreenFlag1 == false)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                Rectangle ret = Screen.GetWorkingArea(this);
                this.pictureBox1.ClientSize = new System.Drawing.Size(ret.Width, ret.Height);
                this.pictureBox1.Dock = DockStyle.Fill;
                this.pictureBox1.BringToFront();
                fullScreenFlag1 = true;
            }
            else
            {
                //恢复
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                //primarySize即是控件的原始尺寸，也可 new Size(Width, Height);width和height全屏之前的
                this.pictureBox1.ClientSize = primarySize;
                this.pictureBox1.Dock = DockStyle.None;
                fullScreenFlag1 = false;
            }


            
        }
    }
    //datagridview 数据闪烁
    public static class DoubleBufferDataGridView
    {
        /// <summary>
        /// 双缓冲，解决闪烁问题
        /// </summary>
        public static void DoubleBufferedDataGirdView(this DataGridView dgv, bool flag)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, flag, null);
        }
    }
    

}
