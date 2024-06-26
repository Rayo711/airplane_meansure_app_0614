using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpLib
{
    public class Instrument : INotifyPropertyChanged
    {
        public Instrument()
        {
            m_Operator = null;
            m_bBusy = false;
            m_bStopAutoMeasure = false;
            m_lInsID = 999;
            Connected = false;
            //m_lIDInDataBase = 1;
        }

        public Instrument(MpClass _Operate)
        {
            m_Operator = _Operate;
            m_bBusy = false;
            m_bStopAutoMeasure = false;
            m_lInsID = 999;
            Connected = false;
            //m_lIDInDataBase = 1;
        }


        public int InsID
        {
            get { return m_lInsID; }
            set
            {
                m_lInsID = value;
                OnPropertyChanged(nameof(m_lInsID));
            }
        }




//public void SetIDInDataBase(long _longInsID) 
//{
//    m_lIDInDataBase = _longInsID;
//}

//public bool GetIDInDataBase(ref long _InsID)
//{
//    _InsID = m_lIDInDataBase;
//    return false;
//}

public void SetIdInMainSys(int _ID)
        {
            m_iIDInMainSys = _ID;
        }
        public int GetIdInMainSys()
        {
            return m_iIDInMainSys;
        }

        //public void SetInsType(string _InsType)
        //{
        //    m_sInsType = _InsType;
        //}
        //public string GetInsType()
        //{
        //    return m_sInsType;
        //}




        //public void SetIPAddress(string _IPAddress)
        //{
        //    m_sIPAddress = _IPAddress;
        //}
        //public string GetIPAddress()
        //{
        //    return m_sIPAddress;
        //}

        public  string IPAddress
        {
            get { return m_sIPAddress; }
            set
            {
                m_sIPAddress = value;
                OnPropertyChanged(nameof(m_sIPAddress));
            }
        }

        public string Name
        {
            get { return m_sName; }
            set
            {
                if (m_lInsID != 999)
                {
                    m_sName = value;
                }
                else
                {
                    m_sName = "WrongID";
                }
                OnPropertyChanged(nameof(m_sName));
            }
        }

        public bool Connected
        {
            get { return m_bIsConnected; }
            set
            {
                m_bIsConnected = value;
                OnPropertyChanged(nameof(m_bIsConnected));
            }
        }

        public string InsType
        {
            get { return m_sInsType; }
            set
            {
                m_sInsType = value;
                OnPropertyChanged(nameof(m_sInsType));
            }
        }

        public void SetCollectionName(string _CollectionName)
        {
            m_sCollectionName = _CollectionName;
        }
        public string GetCollectionName()
        {
            return m_sCollectionName;
        }

        private bool m_bIsConnected;
        private string m_sName;
        private int m_lInsID;
        private string m_sIPAddress;
        private string m_sInsType;

        //主控中的ID
        protected int m_iIDInMainSys;

        //设备所在的集合
        protected string m_sCollectionName;

        //是否为仿真
        protected bool m_bSimulate;

        // IDIn DataBase
        //protected long m_lIDInDataBase;


        //连接仪器
        public bool StartIns(string _colName, int _lInsID, bool _bInitializeTracker, string _sIPAddress, bool _bSimulate)
        {
            bool bConnected = false;
            if (m_Operator.StartInstrumentInterface(_colName, _lInsID, _bInitializeTracker, _sIPAddress, _bSimulate))
            {
                if (!m_Operator.VerifyInstrumentConnection(_colName, _lInsID, ref bConnected))
                {
                    Connected = false;
                    return false;
                }
                if (!bConnected)
                {
                    Connected = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
            Connected = true;
            m_sCollectionName = _colName;
            InsID = _lInsID;
            IPAddress = _sIPAddress;
            m_bSimulate = _bSimulate;
            return true;
        }

        //指光
        public bool PointAtTarget(string TargetPntInfo)
        {
            string Colname = "";
            string GroupName = "";
            string PntName = "";
            m_Operator.GetPntInfoFromName(TargetPntInfo, ref Colname, ref GroupName, ref PntName);

            if (!m_Operator.PointAtTarget(m_sCollectionName, InsID, Colname, GroupName, PntName))
            {
                return false;
            }

            return true;
        }

        //测量
        public virtual bool MeasureSinglePnt(string TargetPntInfo)
        {
            string Colname = "";
            string GroupName = "";
            string PntName = "";
            if (!m_Operator.GetPntInfoFromName(TargetPntInfo, ref Colname, ref GroupName, ref PntName))
            {
                return false;
            }
            //如果这个点已存在，则删除该点

            string[] Pnts = new string[1];
            Pnts[0] = Colname + ("::") + GroupName + ("::") + PntName;
            m_Operator.DeletePoints(Pnts);

            //m_CriticalSection.Lock();
            if (!m_Operator.MeasureSinglePointHere(m_sCollectionName, InsID, Colname, GroupName, PntName))
            {
                // m_CriticalSection.Unlock();
                return false;
            }
            //m_CriticalSection.Unlock();
            return true;
        }

        //自动测量
        //public virtual void AutoMeas(AutoMeasCommandStructure _Str) = 0;


        //最佳拟合定位仪器
        public bool LocateInstrumentBestFit(string RefGrpCol, string RefGrpName, string CorGrpCol, string CorGrpName, bool ShowInterface)

        {
            //设置仪器初始参数
            double[,] T = new double[4, 4]
                {
                    {1,0,0,0 },
                    {0,1,0,0 },
                    {0,0,1,0 },
                    {0,0,0,1 }
                };
            double scale = 1.0;

            if (!m_Operator.SetInstrumentTransform(m_sCollectionName, InsID, T))
            {
                return false;
            }
            if (!m_Operator.SetAbsoluteInstrumentScaleFactorCAUTION(m_sCollectionName, InsID, scale))
            {
                return false;
            }
            //设置仪器初始参数结束
            double OriTol = 0.3;
            string Log;


            //此处不应设置转站误差
            OriTol = 0;

            if (!m_Operator.LocateInstrumentBestFitGroupToGroup(RefGrpCol, RefGrpName, CorGrpCol, CorGrpName, ShowInterface, 0.0, OriTol, ref T, ref scale))
            {

                return false;
            }

            return false;
        }

        //获取仪器信息
        public bool GetInsInfo()
        {
            bool bconnect = false;
            if (!m_Operator.VerifyInstrumentConnection(m_sCollectionName,InsID, ref bconnect))
            {
                Connected = false ;
                return false;
            }
            Connected = bconnect;
            //m_Operator.ins

            return true;
        }


        ////设备所在的集合
        //CString m_strCollection;

        //停止自动测量
        public bool StopAutoMeas()
        {
            m_bStopAutoMeasure = true;
            return true;
        }

        //仪器是否忙碌
        public bool m_bBusy;

        //停止自动测量标记
        public bool m_bStopAutoMeasure;


        //对应的操作
        protected MpClass m_Operator;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)  //属性变更通知
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public bool GetAngle(string _sPntCol,string _sPntGroup,string _sPntName,ref double _dR,ref double _dTheta, ref double _dPhi)
        {
            //构建跟踪仪坐标系
            string CurrentFrameCol = "";
            string CurrentFrameName = "";
            if (!m_Operator.GetWorkingFrameProperties(ref CurrentFrameCol,ref CurrentFrameName))
            {
                return false;
            }

            string frameName = "设备" + m_sCollectionName + InsID.ToString();
            if (!m_Operator.ConstructFrameOnInstrumentBase(m_sCollectionName, InsID, frameName))
            {
                return false;
            }

            if (!m_Operator.SetWorkingFrame(m_sCollectionName, frameName))
            {
                return false;
            }

            if (!m_Operator.GetPointCoordinatePolar(_sPntCol, _sPntGroup, _sPntName, ref _dR, ref _dTheta, ref _dPhi))
            {
                return false;
            }
           


            return true;
        }
        //开启测量线程时用到


    }
}
