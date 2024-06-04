using MpLib;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            //测量数据
            double x = 0, y = 0, z = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    //如果已经有原点，删除原点
                    string[] listPntToDelete = new string[1];
                    string point_0 = "A::全机::P1";
                    //listPntToDelete[0] = "A::全机::P1";
                    listPntToDelete[0] = point_0;
                    mpObj.DeletePoints(listPntToDelete);

                    //测试
                    if (mInsList.ElementAt(InsIDToConnect).MeasureSinglePnt(point_0))
                    {
                        MessageBox.Show("测量全机P1成功！");
                        mpObj.GetPointCoordinate("A", "全机", "P1", ref x, ref y, ref z);
                        //TODO：把点信息显示到界面上
                        //pointDataList[ind].Set_mean((float)x, (float)y, (float)z);
                    }
                    else
                    {
                        MessageBox.Show("测量全机P1失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }
        }

        private void btn_loc_pointing_Click(object sender, EventArgs e)
        {
            if (null == mpObj)
            {
                MessageBox.Show("未连接仪器！");
                return;
            }
            //获取需要连接的仪器ID
            int InsIDToConnect = 0;

            //测量数据
            double x = 0, y = 0, z = 0;

            if (mInsList.Count() > InsIDToConnect)
            {
                if (mInsList.ElementAt(InsIDToConnect).Connected)
                {
                    mInsList.ElementAt(InsIDToConnect).PointAtTarget("A::定位::P1");
                }
            }
            else
            {
                MessageBox.Show("仪器号码过大，系统中没有添加该仪器！");
            }
        }

    }
}
