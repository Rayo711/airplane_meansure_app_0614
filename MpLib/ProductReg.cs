using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;

namespace MpLib
{
    class ProductReg
    {
        public  void getProdectID(ref string str1, ref string str2 )
        {
            long SerialNo = GetDiskSerialNo();
            //加密

            GostEnc Enc = new GostEnc();
            long [] data;
            data = new long[2];
            data[0] = SerialNo;
            data[1] = 54919677;

            long [] spkey;
            spkey = new long[32];
            for (int i = 0; i < 32; i++)
            {
                spkey[i] = i * 2 + 3;
            }
            int cord = Enc.gost_enc(ref data, ref spkey);
            str1 = data[0].ToString();
            str2 = data[1].ToString();
        }

        public long GetDiskSerialNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='IDE' AND Index=0");

            // 遍历获取到的硬盘信息
            string serialNumber ="";
            foreach (ManagementObject disk in searcher.Get())
            {
               serialNumber = disk["SerialNumber"].ToString();
            }

            long iSerialNumber = long.Parse(serialNumber);

            //作适当处理
            iSerialNumber ^= 0x201505011;//////////加密运算
            iSerialNumber = ~iSerialNumber;///////// 加密运算

            return iSerialNumber;
        }
        ////产生产品序列号
      //  public void getProductSerialNo( ref string str1, ref string  str2)
      //  {
      //      //加密
      //      GostEnc Enc = new GostEnc();
      //      unsigned long data[2];
      //      CString str;
      //      str.Format("%u", str1);
      //      sscanf(str, "%lu", &data[0]);
      //      str.Format("%u", str2);
      //      sscanf(str, "%lu", &data[1]);

      //      ULONG32 spkey[32];
      //      for (int i = 0; i < 32; i++)
      //      {
      //          spkey[i] = i + 3;
      //      }
      //      int cord = Enc.gost_enc(ref data, ref spkey);

      //      str1 = (DWORD)data[0];
      //      str2 = (DWORD)data[1];
      //  }

      //  public bool TestProductSerialNo(DWORD ProductID1, DWORD ProductID2, DWORD ProductSerialNo1, DWORD ProductSerialNo2)
      //  {
      //      //解密
      //      GostEnc Enc;
      //      unsigned long data[4];
      //      CString str;
      //      str.Format("%u", ProductSerialNo1);
      //      sscanf(str, "%lu", &data[0]);
      //      str.Format("%u", ProductSerialNo2);
      //      sscanf(str, "%lu", &data[1]);

      //      ULONG32 spkey[32];
      //      for (int i = 0; i < 32; i++)
      //      {
      //          spkey[i] = i + 3;
      //      }
      //      int cord = Enc.gost_dec((ULONG32*)data, spkey);
      //      str.Format("%u", ProductID1);
      //      sscanf(str, "%lu", &data[2]);
      //      str.Format("%u", ProductID2);
      //      sscanf(str, "%lu", &data[3]);
      //      if (data[0] == data[2] && data[1] == data[3])
      //      {
      //          return true;
      //      }
      //      else
      //      {
      //          return false;
      //      }
      //  }

      //public  bool getRegInfo(DWORD &ProductSerialNo1, DWORD &ProductSerialNo2)
      //  {
      //      //默认创建数据名：Demo.mdb，内部表名：DemoTable，表内有二个字段：姓名、年龄
      //      CString lpszFile = theApp.m_sDocPath + "\\config\\ProductReg.lic";
      //      CMarkup markUp;
      //      CString st1, st2;
      //      if (markUp.Load(lpszFile))
      //      {
      //          if (markUp.FindChildElem("SerialNo1"))
      //          {
      //              st1 = markUp.GetChildData();
      //          }
      //          else
      //          {
      //              return false;
      //          }
      //          if (markUp.FindChildElem("SerialNo2"))
      //          {
      //              st2 = markUp.GetChildData();
      //          }
      //          else
      //          {
      //              return false;
      //          }
      //      }
      //      else
      //      {
      //          AfxMessageBox("打开授权文件失败！");
      //          return false;
      //      }
      //      //把CString类型的值转换为DWORD值
      //      unsigned long data[2];
      //      sscanf(st1, "%lu", &data[0]);
      //      sscanf(st2, "%lu", &data[1]);
      //      ProductSerialNo1 = (DWORD)data[0];
      //      ProductSerialNo2 = (DWORD)data[1];

      //      return true;
      //  }

      //  public bool SetRegInfo(DWORD ProductSerialNo1, DWORD ProductSerialNo2)
      //  {
      //      //默认创建数据名：Demo.mdb，内部表名：DemoTable，表内有二个字段：姓名、年龄
      //      CString lpszFile = theApp.m_sDocPath + "\\config\\ProductReg.lic";

      //      //设置文件属性
      //      SetFileAttributes(lpszFile, FILE_ATTRIBUTE_NORMAL);

      //      CMarkup markUp;
      //      //把DWORD内容变为
      //      CString str1;
      //      str1.Format("%u", ProductSerialNo1);

      //      CString str2;
      //      str2.Format("%u", ProductSerialNo2);

      //      if (markUp.Load(lpszFile))
      //      {
      //          if (!markUp.FindChildElem("SerialNo1"))
      //              return false;
      //          if (!markUp.SetChildData(str1))
      //              return false;
      //          if (!markUp.FindChildElem("SerialNo2"))
      //              return false;
      //          if (!markUp.SetChildData(str2))
      //              return false;
      //      }
      //      markUp.Save(lpszFile);
      //      return true;
      //  }
    }
}
