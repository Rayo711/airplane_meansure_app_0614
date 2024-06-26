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
using MathNet.Numerics.LinearAlgebra;
using iTextSharp.text;
using SixLabors.ImageSharp;
using System.Diagnostics;

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
        string Pts_plane_loc;//构建飞机坐标系的理论点组名
        public List<Point_cloud> pointDataList_PF = new List<Point_cloud> { };
        public List<Point_cloud> pointDataList_GND = new List<Point_cloud> { };
        Vector3 zeros = new Vector3((float)0.0, (float)0.0, (float)0.0);
        Myexcel myexcel = new Myexcel();
        TableControl tableControl = new TableControl();
        private int index_gnd = 0;
        private int num_gnd = 6;


        //相机画面参数
        private System.Drawing.Size pic_size;

        public Main()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            mInsList = new BindingList<Instrument>();
            mConnectedInsList = new BindingList<Instrument>();
            //数据绑定
            dataGridView_dev.DataSource = mInsList;

            combox_planeFrame.DataSource = mConnectedInsList;
            combox_planeFrame.DisplayMember = "Name";
            combox_planeFrame.ValueMember = "InsID";

            comboBox_gnd.DataSource = mConnectedInsList;
            comboBox_gnd.DisplayMember = "Name";
            comboBox_gnd.ValueMember = "InsID";


            mean_process.Text = info.doc_text;

            Process.Start(@"E:\table\USR-VCOM.exe");  //直接调用打开文件

        }

        //飞机基准点测量
        private void btn_plane_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;
            double x = 0, y = 0, z = 0;
            string groupName = text_pf_mean.Text.Split(':')[2];

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有点，删除点
                    string[] listPntToDelete = new string[2];
                    int index = dataGridView_PF.CurrentRow.Index;
                    listPntToDelete[0] = "A::" + groupName + "::" + pointDataList_PF[index].ptname;
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::" + groupName + "::" + pointDataList_PF[index].ptname))
                    {
                        MessageBox.Show("测量" + groupName + "::" + pointDataList_PF[index].ptname + "成功！");
                        //TODO：把点信息显示到界面上
                        mpObj.GetPointCoordinate("A", groupName, pointDataList_PF[index].ptname, ref x, ref y, ref z);
                        //TODO：把点信息显示到界面上
                        //pointDataList_PF[index].Set_mean((float)x, (float)y, (float)z
                        dataGridView_PF.Rows[index].Cells[2].Value = new Vector3((float)x, (float)y, (float)z);
                    }
                    else
                    {
                        MessageBox.Show("测量" + groupName + "::" + pointDataList_PF[index].ptname + "失败！");
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
            string text_path = step_textpath + "/设备连接.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }


        //左侧按键触发-全机水平测量
        private void btn_plane_meansure_Click(object sender, EventArgs e)
        {
            Plane plane = new Plane(mInsList, mConnectedInsList);
            plane.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）
            plane.TopLevel = false; //指示子窗体非顶级窗体
            this.tabPage1.Controls.Add(plane);//将子窗体载入panel
            plane.Show();
            tabcontrol_main.SelectedTab = tabPage1;

        }

        //左侧按键触发-雷达系统
        private void btn_radar_Click(object sender, EventArgs e)
        {
            tabcontrol_main.SelectedTab = page_radar;
            stime = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
            log += mean_process.Text + "\n";
            mean_process.Clear();
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
            string text_path = step_textpath + "/光雷系统.txt";
            string text_strs = ReadTxtContent(text_path);
            mean_process.Text = text_strs;
        }

        //连接摄像头
        private void btn_cam_connect_Click(object sender, EventArgs e)
        {
            camera camera = new camera();
            camera.Show();
        }
        //主程序退出
        private void close_main_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


       


        //连接SA
        private void ConnectSA_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                string _SAPath = ReadTxtContent(step_textpath + "/SA_path.txt");
                //string _SAPath = ReadTxtContent(step_textpath + "/SA_path_pre.txt");
                _SAPath = _SAPath.Remove(_SAPath.Length - 1, 1);
                string FilePath = ReadTxtContent(step_textpath + "/mean_path.txt");
                //string FilePath = ReadTxtContent(step_textpath + "/mean_path_pre.txt");
                FilePath = FilePath.Remove(FilePath.Length - 1, 1);
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

                dataGridView_dev.DataSource = mInsList;


                int InsListNum = mInsList.Count();
                for (int i = 0; i < mInsList.Count(); i++)
                {
                    mInsList.RemoveAt(0);
                }
                InsListNum = mConnectedInsList.Count();
                for (int i = 0; i < iInsID; i++)
                {
                    Instrument ins = new Instrument(mpObj);
                    ins.InsID = i;
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
                //ins.Connected = true;
                ins.SetCollectionName(col);
                mInsList.Add(ins);
                MessageBox.Show("添加仪器成功");
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
                    if (mInsList.ElementAt(InsIDToConnect).StartIns("A", InsIDToConnect, true, "192.168.0.1", true))
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
                    ins.InsID = i;
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
            Locate locate = new Locate(mInsList, mConnectedInsList);
            locate.ShowDialog();
        }


        //导入飞机基准点坐标
        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt文件|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName1 = dlg.FileName;

                //导入基准点数据到SA

                if (!mpObj.ImportASCII(fileName1, "点名 X Y Z", "毫米", "A", "飞机基准点"))
                {
                    MessageBox.Show("导入" + fileName1 + " 文件失败！");
                }
                else
                {
                    text_gnd_theo.Text = "A::飞机基准点";

                    string TempCol = "A";
                    string TempGroupName = "飞机基准点";
                    string TempPtName = "";
                    List<string> TempPntName = new List<string>();
                    int theoNum = 0;
                    double x = 0, y = 0, z = 0;
                    List<string> strings = new List<string>();
                    //列表中显示点信息
                    //获取所选点组中各点信息
                    mpObj.GetNumberOfPointsInGroup(TempCol, TempGroupName, ref theoNum);
                    mpObj.MakeAPointNameRefListFromAGroup(TempCol, TempGroupName, ref TempPntName);

                    for (int i = 0; i < theoNum; i++)
                    {
                        mpObj.GetPntInfoFromName(TempPntName[i], ref TempCol, ref TempGroupName, ref TempPtName);
                        mpObj.GetPointCoordinate(TempCol, TempGroupName, TempPtName, ref x, ref y, ref z);
                        pointDataList_PF.Add(new Point_cloud(TempPtName, new Vector3((float)x, (float)y, (float)z), zeros));
                    }
                    
                    dataGridView_PF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_PF.DataSource = pointDataList_PF;
                    dataGridView_PF.Refresh();
                }
            }
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


        //地面靶球测量
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请先在SA界面设置测量模式为：1.5英寸靶球测量");
            Pts_plane_loc = "地面测量点::";
            //单点测量
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;
            double x = 0, y = 0, z = 0;
            int index = dataGridView_gnd.CurrentRow.Index;
            if (mInsList.Count() > InsIDToConnect && index >=0)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {

                    //如果已经有点，删除点
                    string[] listPntToDelete = new string[1];

                    MessageBox.Show(pointDataList_GND.Count().ToString());

                    listPntToDelete[0] = "A::" + Pts_plane_loc + pointDataList_GND[index].ptname;
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::" + Pts_plane_loc + pointDataList_GND[index].ptname))
                    {
                        MessageBox.Show("测量" + Pts_plane_loc + pointDataList_GND[index].ptname + "成功！");
                        //TODO：把点信息显示到界面上
                        mpObj.GetPointCoordinate("A", Pts_plane_loc.Split(':')[0], pointDataList_GND[index].ptname, ref x, ref y, ref z);
                        //TODO：把点信息显示到界面上
                        dataGridView_gnd.Rows[index].Cells[2].Value = new Vector3((float)x, (float)y, (float)z);
                    }
                    else
                    {
                        MessageBox.Show("测量" + Pts_plane_loc + pointDataList_GND[index].ptname + "失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }

        }


        //建立飞机坐标系
        private void button1_Click(object sender, EventArgs e)
        {
            //设置当前坐标系为默认的世界坐标系

            //1为飞机坐标系下理论点集
            //2为测量点集

            mpObj.SetWorkingFrame("A", "WORLD");
            string RefCol = "A";
            string RefGroup ="飞机基准点";
            string CorrespondingCol ="A";
            string CorrespondingGroup = "飞机测量点";

            bool bShowInterface = false;
            double dRMS = 0.0;
            double dAbsTol = 0.0 ;
            double[,] sTransform = new double[4, 4];

            //计算转换矩阵
            mpObj.BestFitTransformationGrouptoGroup(RefCol, RefGroup, CorrespondingCol, CorrespondingGroup,
                bShowInterface, dRMS, dAbsTol, ref sTransform);

            ////构建之前先删除坐标系
            //string colName = "";
            //string ObjName = "";
            //mpObj.MakeACollectionObjectNameFromStrings("A", "产品坐标系", "Frame",ref colName,ref ObjName);

            //object ObjList = null;
            //mpObj.AddACollectionObjectNameToARefList("TempFrame", colName, ObjName, ref ObjList);
            //mpObj.DeleteObjects(ref ObjList);


            //A::New::坐标系
            //转换矩阵转构建坐标系
            mpObj.ConstructFrame("A", "飞机坐标系", sTransform);

            //激活坐标系
            mpObj.SetWorkingFrame("A", "飞机坐标系");


        }

        //首次测量地面基准点
        private void gnd_import_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请先在SA界面设置测量模式为：1.5英寸靶球测量");
            Pts_plane_loc = "地面基准点::";

            //单点测量
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;
            double x = 0, y = 0, z = 0;
            if(index_gnd == 0)
            {
                for (int i = 0; i < num_gnd; i++)
                {
                    pointDataList_GND.Add(new Point_cloud("P" + i.ToString(), zeros, zeros));

                }
                dataGridView_gnd.DataSource = pointDataList_GND;
                dataGridView_gnd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_gnd.Refresh();
            }



            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {

                    //如果已经有点，删除点
                    string[] listPntToDelete = new string[1];

                    listPntToDelete[0] = "A::地面基准点::P" + index_gnd.ToString();
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt("A::地面基准点::P" + index_gnd.ToString()))
                    {
                        MessageBox.Show("测量地面基准点P" + index_gnd.ToString() + "成功！");
                        //TODO：把点信息显示到界面上
                        mpObj.GetPointCoordinate("A", "地面基准点", "P" + index_gnd.ToString(), ref x, ref y, ref z);
                        //TODO：把点信息显示到界面上

                        dataGridView_gnd.Rows[index_gnd].Cells[1].Value = new Vector3((float)x, (float)y, (float)z);

                        index_gnd++;

                    }
                    else
                    {
                        MessageBox.Show("测量" + Pts_plane_loc + "P" + index_gnd.ToString() + "失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }

            dataGridView_gnd.Refresh();
        }


        //选择测量点组
        private void gnd_choose_theo_Click(object sender, EventArgs e)
        {
            //如果按钮被已被按下，则不响应
            string Prompt = ("选择基准点组合");
            string TempCol = "";
            string TempGroupName = "";
            string TempPtName = "";
            List<string> TempPntName = new List<string>();
            int theoNum = 0;
            double x = 0, y = 0, z = 0;
            //从SA中选择测量点
            mpObj.MakeACollectionObjectNameRuntimeSelect(Prompt, "Point Group", ref TempCol, ref TempGroupName);

            Prompt = TempCol + ("::") + TempGroupName;
            text_gnd_theo.Text = Prompt;

            //获取所选点组中各点信息
            mpObj.GetNumberOfPointsInGroup(TempCol, TempGroupName, ref theoNum);
            mpObj.MakeAPointNameRefListFromAGroup(TempCol, TempGroupName, ref TempPntName);

            for (int i = 0; i < theoNum; i++)
            {
                mpObj.GetPntInfoFromName(TempPntName[i], ref TempCol, ref TempGroupName, ref TempPtName);
                mpObj.GetPointCoordinate(TempCol, TempGroupName, TempPtName, ref x, ref y, ref z);
                pointDataList_GND.Add(new Point_cloud(TempPtName, new Vector3((float)x, (float)y, (float)z), zeros));
            }
            dataGridView_gnd.DataSource = pointDataList_GND;
            dataGridView_gnd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_gnd.Refresh();
        }


        //地面坐标系构建
        private void gnd_frame_Click(object sender, EventArgs e)
        {
            if (comboBox_gnd.Items.Count <= 0)
            {
                return;
            }

            Instrument selectedIns = (Instrument)comboBox_gnd.SelectedItem;
            //string pTheoNameList = "";
            //string pMeasNameList = "";

            int TheoPntNumber = 0;
            mpObj.GetNumberOfPointsInGroup("A", "地面基准点", ref TheoPntNumber);


            if (TheoPntNumber <= 0)
            {
                //理论点数量太少
                return;
            }

            int MeasPntNumber = 0;
            mpObj.GetNumberOfPointsInGroup("A", "地面测量点", ref MeasPntNumber);
            if (MeasPntNumber <= 0)
            {
                //测量数量太少
                return;
            }
            string sRefCollection = "A";
            string sRefGroup = "地面基准点";
            string sCorrespondingCollection = "A";
            string sCorrespondingGroup = "地面测量点";

            double[,] sTransform = new double[4, 4];
            double dScale = 1;


            if (mpObj.LocateInstrumentBestFitGroupToGroup(sRefCollection, sRefGroup, sCorrespondingCollection, sCorrespondingGroup,
          true, 0.0, 0.0, ref sTransform, ref dScale))
            {
                //调用该函数后，软件弹出转站对话框，本软件会弹出等待的对话框，该对话框无法被关闭。只有当SA软件操作结束后，本软件弹出的等待对话框才能被关闭；
                MessageBox.Show("请在SA完成转站操作后关闭本窗口");
            }
        } 

        private void plane_select_pointGroup_Click(object sender, EventArgs e)
        {
            //如果按钮被已被按下，则不响应
            string Prompt = ("选择理论点组合");
            string TempCol = "";
            string TempGroupName = "";
            string TempPtName = "";
            List<string> TempPntName = new List<string>();
            int theoNum = 0;
            double x = 0, y = 0, z = 0;
            //从SA中选择理论点
            mpObj.MakeACollectionObjectNameRuntimeSelect(Prompt, "Point Group", ref TempCol, ref TempGroupName);

            Prompt = TempCol + ("::") + TempGroupName;
            text_pf_theo.Text = Prompt;

            //获取所选点组中各点信息
            mpObj.GetNumberOfPointsInGroup(TempCol, TempGroupName, ref theoNum);
            mpObj.MakeAPointNameRefListFromAGroup(TempCol, TempGroupName, ref TempPntName);

            for (int i = 0; i < theoNum; i++)
            {
                mpObj.GetPntInfoFromName(TempPntName[i], ref TempCol, ref TempGroupName, ref TempPtName);
                mpObj.GetPointCoordinate(TempCol, TempGroupName, TempPtName, ref x, ref y, ref z);
                pointDataList_PF.Add(new Point_cloud(TempPtName, new Vector3((float)x, (float)y, (float)z), zeros));
            }
            dataGridView_PF.DataSource = pointDataList_PF;
            dataGridView_PF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_PF.Refresh();

        }

        //选择的设备更改时
        private void comboBox_gnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locate locate = new Locate(mInsList, mConnectedInsList);
            locate.ShowDialog();
        }

        //连接转台
        private void btn_table_connect_Click(object sender, EventArgs e)
        {
            tableControl.tab_connect();
        }

        //测量角可视化
        private void radar_x_error_TextChanged(object sender, EventArgs e)
        {
            double number;
            bool success = double.TryParse(radar_x_error.Text,out number);
            if (success && number <2 && number >-2)
            {
                trackBar1.Value = (int)(number * 1000);
            }
            else
            {
                trackBar1.Value = 0;
            }
        }

        private void radar_y_error_TextChanged(object sender, EventArgs e)
        {
            double number;
            bool success = double.TryParse(radar_y_error.Text, out number);
            if (success && number < 2 && number > -2)
            {
                trackBar2.Value = (int)(number * 1000);
            }
            else
            {
                trackBar2.Value = 0;
            }
        }

        private void radar_z_error_TextChanged(object sender, EventArgs e)
        {
            double number;
            bool success = double.TryParse(radar_z_error.Text, out number);
            if (success && number < 2 && number > -2)
            {
                trackBar3.Value = (int)(number * 1000);
            }
            else
            {
                trackBar3.Value = 0;
            }
        }

        //选择项目  更改子项目内容
        private void comboBox_sel_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = comboBox_sel_1.SelectedIndex;
            switch(ind)
            {
                case 0://雷达系统
                    comboBox_sel_2.Items.Clear(); 
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "雷达面安装角测量"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 1: //电子战系统
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "前向ESM","ECM天线","前向ESM","俯仰天线","后向ESM","ECM天线"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 2://CNI
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "机间数据链天线（前上)",
                    "机间数据链天线（前下)",
                    "机间数据链天线（前左)",
                    "机间数据链天线（前右)",
                    "机间数据链天线（后左)",
                    "机间数据链天线（后右)",
                    "卫星通讯天线"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 3://平显
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "平显前平面","平显上平面","平显侧平面"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 4://惯性
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "捷联惯导系统（座舱下方左右）","光纤捷联航姿系统（座舱下方）"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 5://飞控
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "左速率陀螺传感器安装支架","右速率陀螺传感器安装支架","加速度传感器组件"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
                case 6://光雷
                    comboBox_sel_2.Items.Clear();
                    comboBox_sel_2.Items.AddRange(new object[] {
                    "IRST系统","DAS天线(1）","DAS天线(2）","DAS天线(3）","DAS天线(4）","DAS天线(5）","DAS天线(6）"});
                    comboBox_sel_2.SelectedIndex = 0;
                    break;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Locate locate = new Locate(mInsList, mConnectedInsList);
            locate.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Locate locate = new Locate(mInsList, mConnectedInsList);
            locate.ShowDialog();
        }

        private void btn_radar_loc_Click(object sender, EventArgs e)
        {
            Locate locate = new Locate(mInsList, mConnectedInsList);
            locate.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double Last_horizontaloAngle = 0;
            double Last_verticalAngle = 0;
            tableControl.sendCommond(tableControl.CalCulaTion(0, 0x4b, Convert.ToString((int)Last_horizontaloAngle / 256), Convert.ToString((int)Last_horizontaloAngle % 256)));
            tableControl.sendCommond(tableControl.CalCulaTion(0, 0x4d, Convert.ToString((int)Last_verticalAngle / 256), Convert.ToString((int)Last_verticalAngle % 256)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //获取设备旋转角
            string PntCol = "A";
            string PntGroup = "TEST";
            string Pntname = "A1";

            double r = 0;
            double theta = 0;
            double phi = 0;
            Instrument selectedIns = (Instrument)comboBox_gnd.SelectedItem;
            selectedIns.GetAngle(PntCol, PntGroup, Pntname, ref r, ref theta, ref phi);

            tableControl.TableCon(theta, phi, r);
            mpObj.SetWorkingFrame("A", "World");
        }
    }
}