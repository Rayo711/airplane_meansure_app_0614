using iTextSharp.text;
using MpLib;
using NPOI.Util;
using PointCloud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Locate : Form
    {
        MpClass mpObj = Main.mpObj;
        BindingList<Instrument> mInsList;
        BindingList<Instrument> mConnectedInsList;

        string PtGroup_mean = "";
        string PtGroup_theo = "";

        List<Point_cloud> pointDataList_loc = new List<Point_cloud> { };
        Vector3 zeros = new Vector3((float)0.0, (float)0.0, (float)0.0);
        public Locate(BindingList<Instrument> _mInsList, BindingList<Instrument> _mConnectedInsList)
        {
            InitializeComponent();
            mpObj = Main.mpObj;
            mInsList = _mInsList;
            mConnectedInsList = _mConnectedInsList;
            comboBox_loc_dev_select.DataSource = mConnectedInsList;
            comboBox_loc_dev_select.DisplayMember = "Name";
            comboBox_loc_dev_select.ValueMember = "InsID";
        }

        private void btn_loc_means_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请先在SA界面设置测量模式为：1.5英寸靶球测量");
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = comboBox_loc_dev_select.SelectedIndex;

            //测量数据
            double x = 0, y = 0, z = 0;

            int index = dataGridView_loc.CurrentRow.Index;
            if (mInsList.Count() > InsIDToConnect && index>=0)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    if(PtGroup_theo != null)
                    {
                        //如果已经有原点，删除原点
                        string[] listPntToDelete = new string[1];
                        string _name = dataGridView_loc.Rows[index].Cells[0].ToString();

                        string point_0 = "A::" + PtGroup_mean + "::" + _name;
                        //listPntToDelete[0] = "A::全机::P1";
                        listPntToDelete[0] = point_0;
                        mpObj.DeletePoints(listPntToDelete);

                        //测试
                        if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt(point_0))
                        {
                            MessageBox.Show("测量" + point_0 + "成功！");
                            mpObj.GetPointCoordinate("A", PtGroup_mean, _name, ref x, ref y, ref z);
                            //TODO：把点信息显示到界面上
                            //pointDataList[ind].Set_mean((float)x, (float)y, (float)z);
                            dataGridView_loc.Rows[index].Cells[2].Value = new Vector3((float)x, (float)y, (float)z);
                        }
                        else
                        {
                            MessageBox.Show("测量" + PtGroup_mean + _name + "失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择理论点组！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }
        }

        //选择理论点组
        private void btn_selectTheo_Click(object sender, EventArgs e)
        {
            //如果按钮被已被按下，则不响应
            string Prompt = ("选择理论点组合");
            string TempCol = "";
            string TempGroupName = "";
            string TempPtName = "";
            List<string> TempPntName = new List<string>();
            int theoNum = 0;
            double x = 0, y = 0, z = 0;
            //从SA中选择点组
            mpObj.MakeACollectionObjectNameRuntimeSelect(Prompt, "Point Group", ref TempCol, ref TempGroupName);

            Prompt = TempCol + ("::") + TempGroupName;
            text_theo.Text = Prompt;
            PtGroup_theo = TempGroupName;
            PtGroup_mean = PtGroup_theo + "(测量)";

            //获取所选点组中各点信息
            mpObj.GetNumberOfPointsInGroup(TempCol, TempGroupName,ref theoNum);
            mpObj.MakeAPointNameRefListFromAGroup(TempCol, TempGroupName, ref TempPntName);
            
            for (int i = 0; i < theoNum; i++)
            {
                mpObj.GetPntInfoFromName(TempPntName[i],ref TempCol, ref TempGroupName, ref TempPtName);
                mpObj.GetPointCoordinate(TempCol, TempGroupName, TempPtName, ref x, ref y, ref z);
                pointDataList_loc.Add(new Point_cloud(TempPtName, new Vector3((float)x, (float)y, (float)z), zeros));
            }
            dataGridView_loc.DataSource = pointDataList_loc;
            dataGridView_loc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_loc.Refresh();

        }

        //进行转站计算
        private void btn_convert_Click(object sender, EventArgs e)
        {
            //根据选中的两个点组进行设备转站
            if (comboBox_loc_dev_select.Items.Count <= 0)
            {
                return;
            }

            Instrument selectedIns = (Instrument)comboBox_loc_dev_select.SelectedItem;
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
          true, 0.2, 0.2, ref sTransform, ref dScale))
            {
                //调用该函数后，软件弹出转站对话框，本软件会弹出等待的对话框，该对话框无法被关闭。只有当SA软件操作结束后，本软件弹出的等待对话框才能被关闭；
            }




        }

    }
}
