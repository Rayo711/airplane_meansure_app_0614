using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class camera : Form
    {
        public double frame_scale = 1;
        public bool video_flag = false;
        private VideoCapture capture;
        private bool fullScreenFlag1 = false;
        public camera()
        {
            InitializeComponent();
            capture = new VideoCapture(1);
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
            Scalar color = new Scalar(0,0,255);
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
                    Scalar lowerRed1 = new Scalar(0, 43, 46);
                    Scalar upperRed1 = new Scalar(10, 255, 255);
                    Scalar lowerRed2 = new Scalar(156, 43, 46);
                    Scalar upperRed2 = new Scalar(180, 255, 255);
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
                        Cv2.Circle(frame, center, 3,color, -1);
                        Cv2.Line(frame, new OpenCvSharp.Point(center.X - 10, center.Y), new OpenCvSharp.Point(center.X - 50, center.Y), color);
                        Cv2.Line(frame, new OpenCvSharp.Point(center.X + 10, center.Y), new OpenCvSharp.Point(center.X + 50, center.Y), color);
                        Cv2.Line(frame, new OpenCvSharp.Point(center.X, center.Y + 10), new OpenCvSharp.Point(center.X, center.Y + 50), color);
                        Cv2.Line(frame, new OpenCvSharp.Point(center.X, center.Y - 10), new OpenCvSharp.Point(center.X, center.Y - 50), color);

                    }
                }
                // 将帧显示到 pictureBox1 中
                Cv2.Resize(frame, new_frame, new OpenCvSharp.Size(640 * frame_scale, 480 * frame_scale), 0, 0);
                Cv2.Rotate(new_frame,new_frame,RotateFlags.Rotate90Counterclockwise);
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

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (frame_scale > 3) // 放大上限
                    frame_scale = 3;
                else
                {
                    frame_scale += 0.1;
                }
            }
            else
            {
                if (frame_scale < 0.2)  // 放大下限
                    frame_scale = 0.2;
                else
                {
                    frame_scale -= 0.1;
                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Drawing.Size primarySize = new System.Drawing.Size(640, 480);
            //最大化
            if (fullScreenFlag1 == false)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                System.Drawing.Rectangle ret = Screen.GetWorkingArea(this);
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
}
