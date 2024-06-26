using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace MpLib
{
    public class ProcessOp
    {
        public bool OpenSA(string _SAPath, string _FilePath)

        {
            //如果有SDK的进程，杀死该进程
            KillAllSASDK();

            //如果SA没有打开，打开SA文件
            if (!IsSAOpen())
            {
                OpenSAFile(_SAPath, _FilePath);

                bool bSAOpen = false;
                for (int i = 0; i < 100; i++)
                {
                    if (!IsSAOpen())
                    {
                        System.Threading.Thread.Sleep(300);
                    }
                    else
                    {
                        bSAOpen = true;
                        break;
                    }
                }
                if (bSAOpen == false)
                {
                    //ErrorMsg = ("打开SA失败");
                    return false;
                }
            }
            return true;
        }

        public bool KillAllSASDK()
        {
            // 获取所有正在运行的进程
            Process[] processes = Process.GetProcessesByName("SpatialAnalyzerSDK");

            // 结束所有匹配名字的进程
            foreach (Process process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(); // 等待进程退出
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"无法结束进程: {ex.Message}");
                    return false;
                }
            }
            return true;
        }

        public bool IsSAOpen()
        {
            Process[] processes = Process.GetProcessesByName("Spatial Analyzer");
            if (processes.Length>0)
            {
                return true;
            }

            return false;
        }

        public bool OpenSAFile(string _SaPath,string _FilePath)
        {

            try
            {
                //FileStream fileStream = File.Open("调姿测量.xit", FileMode.Open);
                // 可能引发异常的代码
                Process process = new Process();
                process.StartInfo.FileName = _SaPath;
                process.StartInfo.Arguments = _FilePath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.CreateNoWindow = false;
                process.Start();

            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine("文件不存在：" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("其他异常：" + ex.Message);
                return false;
            }


            return true;
        }

 
}
}
