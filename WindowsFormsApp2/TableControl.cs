using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class TableControl
    {
        public static SerialPort serialPort2 = new SerialPort();

        public void TableCon(double AngleV, double AngleH, double r)
        {
            //计算转台转角
            double dist = 0;
            double angleV = 0, angleH = 0;
            AngleCalcu(AngleV, AngleH, r, ref angleV, ref angleH);
            MessageBox.Show(AngleV.ToString());
            MessageBox.Show(AngleH.ToString());
            MessageBox.Show(angleV.ToString());
            MessageBox.Show(angleH.ToString());



            //传输转台指令
            //程序设置左右转动时，向左为负，比如向左转动45度，命令为-45。
            double horizontaloAngle = 0;//接收左右转动数据，因为不知道需求，这里新建文本框进行传输，还要结合激光雷达距离进行角度换算
            horizontaloAngle = horizontaloAngle * 100;
            //MessageBox.Show(horizontaloAngle.ToString());
            double verticalAngle = 20;//接收上下转动角度
                                          //double verticalAngle = 0;//激光测距仪垂直角度
            verticalAngle = verticalAngle * 100;
            //MessageBox.Show(verticalAngle.ToString());

            if ((horizontaloAngle >= -6500 && horizontaloAngle <= 6500) && (verticalAngle > -4000 && verticalAngle <= 9000))
            {
               if (horizontaloAngle >= -6500 && horizontaloAngle <= 0)
                    {
                        horizontaloAngle = horizontaloAngle + 36000;
                        sendCommond(CalCulaTion(0, 0x4b, Convert.ToString((int)horizontaloAngle / 256), Convert.ToString((int)horizontaloAngle % 256)));
                    }
                    else
                    {
                        sendCommond(CalCulaTion(0, 0x4b, Convert.ToString((int)horizontaloAngle / 256), Convert.ToString((int)horizontaloAngle % 256)));

                    }
               if (verticalAngle > -4000 && verticalAngle <= 0)
                    {
                        sendCommond(CalCulaTion(0, 0x4d, Convert.ToString((int)verticalAngle / 256), Convert.ToString((int)verticalAngle % 256)));

                    }
                    else
                    {
                        sendCommond(CalCulaTion(0, 0x4d, Convert.ToString((int)verticalAngle / 256), Convert.ToString((int)verticalAngle % 256)));
                    }
                }                                
            else
            {
                MessageBox.Show("角度超出限制", "提示");
            }
        }

        public void AngleCalcu(double AngleV, double AngleH, double radium, ref double angleV, ref double angleH)
        {
            double d_1 = 398; //设备左右间距
            double d_2 = 40;//设备前后间距
            double leica_distance1 = 30; //激光点距离
            double leica_degree = 25; //激光测距仪转角
            double length = Math.Sqrt(Math.Pow(d_1, 2) + Math.Pow(d_2, 2));//设备中心斜间距
            double l_degree = Math.Atan(d_2 / d_1) * (180 / Math.PI);//补充角度
            double leica_Hdegree1 = 90 - l_degree - leica_degree;//激光雷达点所在三角形内角
            double leicaRadians1 = leica_Hdegree1 * (Math.PI / 180);
            double cosleica1 = Math.Cos(leicaRadians1);
            double z_distance1 = Math.Sqrt(Math.Pow(length, 2) + Math.Pow(leica_distance1, 2) - 2 * length * leica_distance1 * cosleica1);//转台到测点距离
            double alphaInRadians1 = Math.Acos((Math.Pow(z_distance1, 2) + Math.Pow(leica_distance1, 2) - Math.Pow(length, 2)) / (2 * leica_distance1 * z_distance1));
            double alphaInDegrees1 = alphaInRadians1 * (180.0 / Math.PI);
            double z_Hdegree = 180 - alphaInDegrees1 - leica_Hdegree1;//转台点所在三角形的内角
            angleH = -(90 - z_Hdegree + l_degree);//转台水平所需旋转角度
                                                             //垂直
            double h = 300; //设备垂直高度
            double leica_distance2 = 11; //激光点距离
            double leica_Vdegree = 45; //激光测距仪转角
            double leica_Vdegree1 = 180 - leica_Vdegree; //激光雷达点所在三角形内角
            double leicaRadians2 = leica_Vdegree1 * (Math.PI / 180);
            double cosleica2 = Math.Cos(leicaRadians2);
            double z_distance2 = Math.Sqrt(Math.Pow(h, 2) + Math.Pow(leica_distance2, 2) - 2 * h * leica_distance2 * cosleica2);
            double alphaInRadians2 = Math.Acos((Math.Pow(z_distance2, 2) + Math.Pow(leica_distance2, 2) - Math.Pow(h, 2)) / (2 * leica_distance2 * z_distance2));
            double alphaInDegrees2 = alphaInRadians2 * (180.0 / Math.PI);
            double z_Vdegree = 180 - alphaInDegrees2 - leica_Vdegree1;//转台点所在三角形的内角
            angleV = 90 - z_Vdegree;//转台竖直所需旋转角度


        }

        public String CalCulaTion(int com1, int com2, String textData1, String textData2)
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
        public void sendCommond(String com)
        {
            
            if (serialPort2.IsOpen)
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
            else if (!serialPort2.IsOpen)
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
                    serialPort2.Write(Data, 0, 1);//循环发送（如果输入字符为0A0BB,则只发送0A,0B）
                }
                if (str.Length % 2 != 0)//剩下一位单独处理
                {
                    Data[0] = Convert.ToByte(str.Substring(str.Length - 1, 1), 16);//单独发送B（0B）
                    serialPort2.Write(Data, 0, 1);//发送
                }
            }
            catch
            {
                MessageBox.Show("发送出错", "提示");
            }
        }

        //转台链接
        public void tab_connect()
        {
            if (IsOpen())
            {
                MessageBox.Show("转台已连接，请勿重复点击", "提示");
            }
            else
            {
                text_Serial_port();
                SetSerialPortConfig("COM1", 9600, 1, 8, 1);//这里串口需更改为创建的虚拟串口
                serialPort2.Open();//打开串口
                if (serialPort2.IsOpen)
                {
                    MessageBox.Show("连接成功", "提示");
                }
                else
                {
                    MessageBox.Show("串口未打开", "提示");
                }
                
            }
        }
        private bool IsOpen()
        {
            return (serialPort2.IsOpen);
        }
        private void text_Serial_port()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames(); //获得可用的串口

        }
        private void SetSerialPortConfig(String portName, int baudRate, int parity, int dataBits, int stopBits)
        {
            serialPort2.PortName = portName;//获取要打开的串口
            serialPort2.BaudRate = baudRate;//获得波特率
            serialPort2.DataBits = dataBits;//获得数据位
            switch (parity)
            {
                case 0:
                default:
                    serialPort2.Parity = Parity.None;
                    break;

                case 1:
                    serialPort2.Parity = Parity.Odd;
                    break;

                case 2:
                    serialPort2.Parity = Parity.Even;
                    break;
            }
            switch (stopBits)
            {
                case 1:
                default:
                    serialPort2.StopBits = StopBits.One;
                    break;

                case 2:
                    serialPort2.StopBits = StopBits.Two;
                    break;
            }
        }
    }
}
