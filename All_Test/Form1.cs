using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using All_Test.Class;
using All_Test.Enum;
using All_Test.Serials;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using System.Timers;
using System.Windows.Forms;
using ZXing;
using static All_Test.Form1;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Point = System.Drawing.Point;
using Timer = System.Timers.Timer;

namespace All_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox_name_Leave(null,null);
            textBox_age_Leave(null, null);
            //GlobalInfo.Instance.Totalab_LSerials.MsgCome += Sampler_MsgCome;
            //long installDirSize = 0;
            //string himassDir = HelpClass.FindInstallDir("HiMass", out installDirSize);
            //string path = " D:\\labtech\\APP1";
            ////7判断是要新安装还是升级判断这个是不是有
            //if (himassDir != null || himassDir != " ")
            //{
            //    if (Directory.Exists(himassDir + "\\SamplerPlugins"))
            //    {
            //        System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(himassDir + "\\SamplerPlugins");
            //        folder.MoveTo(himassDir + "\\SamplerPlugins备份");

            //        //得到原文件根目录下的所有文件夹
            //        CopyFolder2(path, himassDir);
            //    }
            //    else
            //    {
            //        //得到原文件根目录下的所有文件夹
            //        CopyFolder2(path, himassDir);
            //    }
            //}
            MatchTest();
            getCamList();       //获取摄像头
        }

        #region 变量
        Thread randomThread = null;
        #endregion

        #region 日志
        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="logStr"></param>
        /// <param name="logNum"></param>
        public void LogShow(string logStr)
        {
            //string str = "";
            if (IsHandleCreated)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    list_log.AppendText(string.Format("[{0:HH:mm:ss}] {1}\r\n", DateTime.Now, logStr));
                    System.Windows.Forms.Application.DoEvents();
                    //更改颜色
                    list_log.ForeColor = Color.FromArgb(51, 255, 102);
                    //str = ChangeDateformat() + " " + DateTime.Now.ToShortTimeString() + " :" + logStr + "\n";
                    //list_log.AppendText(str);
                    list_log.ScrollToCaret();
                }));
            }
        }
        public static string ChangeDateformat()       //处理当前日期的格式为20150505
        {
            try
            {
                string strResult = "";
                string stryear = DateTime.Now.Year.ToString();
                string strmonth = DateTime.Now.Month.ToString();
                string strday = DateTime.Now.Day.ToString();
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                if ((month < 10) && (day < 10))
                {
                    strResult = stryear + "0" + strmonth + "0" + strday;
                }
                else if (month < 10)
                {
                    strResult = stryear + "0" + strmonth + strday;
                }
                else if (day < 10)
                {
                    strResult = stryear + strmonth + "0" + strday;
                }
                else
                {
                    strResult = stryear + strmonth + strday;
                }
                return strResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// 窗体关闭释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //说明：FormClosing事件或FormClosed事件二选一，这两个的区别在于 FormClosed 在关闭后发生，窗体的关闭动作不可取消； 
            //FormClosing 在关闭前发生，可取消，只要在里面使用 e.Cancel = true; 就可以让窗口不能关闭。  
            //进阶技巧：在退出程序前弹出确认退出程序的对话框 //主窗体的FormClosing事件代码 
            try
            {
                if (MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                //else
                //{
                //    Environment.Exit(0);
                //}
            }
            catch (Exception)
            {

            }
        }


        #region 测试页1

        #region 配置文件 .ini
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }
        [Serializable]      //对象可序列化标记   必须
        class StudentInfo
        {
            private string _name;
            public string name
            {
                get => _name;
                set
                {
                    _name = value;
                }
            }
            private int _age;
            public int age
            {
                get => _age;
                set
                {
                    _age = value;
                }
            }

        }
        private bool istextHas = false;             //记录文本框是否有文本
        private void textBox_name_Leave(object sender, EventArgs e)
        {
            if (textBox_name.Text=="")
            {
                textBox_name.Text = "电影名";          //显示提示信息
                textBox_name.ForeColor = Color.LightGray;
            }
            else
            {
                istextHas=true;                 //否则为文本框有文本
            }
        }
        private void textBox_name_MouseDown(object sender, MouseEventArgs e)
        {
            this.textBox_name.Text = ""; 
            textBox_name.ForeColor = Color.Black;
            
        }

        private void textBox_age_Leave(object sender, EventArgs e)
        {
            if (textBox_age.Text == "")
            {
                textBox_age.Text = "剧集";          //显示提示信息
                textBox_age.ForeColor = Color.LightGray;
            }
            else
            {
                istextHas = true;                 //否则为文本框有文本
            }
        }

        private void textBox_age_MouseDown(object sender, MouseEventArgs e)
        {
            this.textBox_age.Text = ""; 
            textBox_age.ForeColor = Color.Black;
        }
        //保存
        private void btn_file_Click(object sender, EventArgs e)
        {
            string SavePath = System.IO.Path.Combine(AssemblyDirectory, "Parameters", "SamplerPos.ini");
            string path = System.IO.Path.Combine(AssemblyDirectory, "Parameters");
            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
            }

            ////封装对象信息
            StudentInfo sto = new StudentInfo();
            if (textBox_name.Text != ""&& textBox_name.Text != "电影名" && textBox_age.Text != "" && textBox_age.Text != "剧集")
            {
                sto.name = textBox_name.Text;
                sto.age = int.Parse(textBox_age.Text);
            }
            else
            {
                sto.name = "星辰变";
                sto.age = 100;
            }

            //创建文件流
            if (!File.Exists(SavePath))
            {
                //MessageBox.Show(filePath + "  not exists!");
                FileStream fs = File.Create(SavePath);//创建文件
                                                      //创建二进制格式化器
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                //调用序列化方法
                binaryFormatter.Serialize(fs, sto);
                fs.Close();
                //return;
            }
            else
            {
                FileStream fs = new FileStream(SavePath, FileMode.Open);
                //创建二进制格式化器
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                //调用序列化方法
                binaryFormatter.Serialize(fs, sto);
                fs.Close();
            }
        }
        //读取
        private void btn_read_Click(object sender, EventArgs e)
        {
            string SavePath = "";
            SavePath = System.IO.Path.Combine(AssemblyDirectory, "Parameters", "SamplerPos.ini");

            //创建文件流
            FileStream fs = new FileStream(SavePath, FileMode.Open);
            //创建二进制格式化器
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //调用序列化方法
            StudentInfo sto = (StudentInfo)binaryFormatter.Deserialize(fs);
            fs.Close();
            //textBox_name.Text = sto.name;
            //textBox_age.Text = sto.age.ToString();
            this.textBox1.Text = sto.name + sto.age.ToString();

        }

        #endregion

        #region 配置文件 .dat
        private void btn_DatFilewrite_Click(object sender, EventArgs e)
        {
            try
            {
                string ConfigFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Parameters\\config.dat");
                //写入
                Hashtable para = new Hashtable();
                para.Add("ZH", tb_w1.Text);
                para.Add("MM", tb_w2.Text);
                DatFileHelpClass.EncryptObject(para, ConfigFilePath);
            }
            catch (Exception)
            {
                LogShow("数据写入失败！");
            }
        }
        private void btn_DatfileRead_Click(object sender, EventArgs e)
        {
            try
            {
                string ConfigFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Parameters\\config.dat");
                //读取
                Hashtable para = new Hashtable();
                object obj = DatFileHelpClass.DecryptObject(ConfigFilePath);
                para = obj as Hashtable;
                tb_R1.Text = para["ZH"].ToString();
                tb_R2.Text = para["MM"].ToString();
            }
            catch (Exception)
            {
                LogShow("数据读取失败！");
            }
        }
        #endregion

        #region  int转byte[]
        public byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            //float val = Math.Abs(values) * (-1);
            if (value < 0)  // value > 0
            {
                src[3] = (byte)((value >> 24) & 0xFF);                                              //0,1,0,0
                src[2] = (byte)((value >> 16) & 0xFF);                                              //14,58,0,0
                src[1] = (byte)((value >> 8) & 0xFF);                                               //29,252,255,255
                src[0] = (byte)(value & 0xFF);                                                          ///103,31,0,0
            }
            else
            {
                src[0] = (byte)(value % 65536 % 256);                                               //0,1,0,0
                src[1] = (byte)(value % 65536 / 256);                                               //14,58,0,0
                src[2] = (byte)(value / 65536 % 256);                                               //29,253,0,0
                src[3] = (byte)(value / 65536 / 256);
            }
            return src;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] a = intToBytes(256);
            //byte[] b = intToBytes(14862);
            //byte[] c = intToBytes(-995);
            //byte[] d = intToBytes(8039);
            byte[] q = intToBytes(Convert.ToInt16(tb_value.Text));

            //string result1 = a[0].ToString() + "," + a[1].ToString() + "," + a[2].ToString() + "," + a[3].ToString();
            //string result2 = b[0].ToString() + "," + b[1].ToString() + "," + b[2].ToString() + "," + b[3].ToString();
            //string result3 = c[0].ToString() + "," + c[1].ToString() + "," + c[2].ToString() + "," + c[3].ToString();
            //string result4 = d[0].ToString() + "," + d[1].ToString() + "," + d[2].ToString() + "," + d[3].ToString();
            //Console.WriteLine(a[0].ToString() + "," + a[1].ToString() + "," + a[2].ToString() + "," + a[3].ToString());
            //Console.WriteLine(b[0].ToString() + "," + b[1].ToString() + "," + b[2].ToString() + "," + b[3].ToString());
            //Console.WriteLine(c[0].ToString() + "," + c[1].ToString() + "," + c[2].ToString() + "," + c[3].ToString());
            //Console.WriteLine(d[0].ToString() + "," + d[1].ToString() + "," + d[2].ToString() + "," + d[3].ToString());
            Console.WriteLine(q[0].ToString() + "," + q[1].ToString() + "," + q[2].ToString() + "," + q[3].ToString());
            LogShow(q[0].ToString() + "," + q[1].ToString() + "," + q[2].ToString() + "," + q[3].ToString());

            //lab_result.Text = result1 + "\n" + result2 + "\n" + result3 + "\n" + result4;

        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_convert_Click(object sender, EventArgs e)
        {
            double volume = 1000.0;
            int nVolume1;
            int nVolume2;
            int nVolume3;
            int nVolume4;
            //if (volume >= 0)
            {
                nVolume1 = (byte)(volume / 16777216);
                nVolume2 = (byte)(volume % 16777216 / 65536);
                nVolume3 = (byte)(volume % 16777216 % 65536 / 256);
                nVolume4 = (byte)(volume % 16777216 % 65536 % 256);
            }
            byte[] by = BitConverter.GetBytes(90.0);
            Console.WriteLine("1:" + by[0] + ",2:" + by[1] + ",3:" + by[2] + ",4:" + by[3]);

            //else
            //{
            //    nVolume1 = (byte)((volume & 0xFF000000) >> 8 >> 8 >> 8);
            //    nVolume2 = (byte)((volume & 0xFF0000) >> 8 >> 8);
            //    nVolume3 = (byte)((volume & 0xFF00) >> 8);
            //    nVolume4 = (byte)(volume & 0XFF);
            //}

            Console.WriteLine("nVolume1:" + nVolume1 + ",nVolume2:" + nVolume2 + ",nVolume3:" + nVolume3 + ",nVolume4:" + nVolume4);
            LogShow("nVolume1:" + nVolume1 + "\n nVolume2:" + nVolume2 + "\n nVolume3:" + nVolume3 + "\n nVolume4:" + nVolume4);
        }

        #endregion

        #region string转float
        /// <summary>
        /// string转float
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StrToFloat_Click(object sender, EventArgs e)
        {
            string str = tb_str.Text;
            float floatValue = Convert.ToSingle(str);
            float floatValue2;
            if (!float.TryParse(str,out floatValue2))
            {
                LogShow("无法转换！");
            }
            else
            {
                LogShow("转换成功！");
            }
        }
        #endregion

        #region 四字节float类型转byte
        private void btn_shift_Click(object sender, EventArgs e)
        {

            //byte[] frameArray = new byte[4];

            //frameArray[0] = 0x42;
            //frameArray[1] = 0xB4;
            //frameArray[2] = 0x00;
            //frameArray[3] = 0x00;
            //Console.WriteLine(frameArray[3] + "\n" + frameArray[2] + "\n" + frameArray[1] + "\n" + frameArray[0] + "\n");

            ////四字节float类型转byte 方法1：
            if (tb_floatValue.Text != "")
            {
                byte[] bytes = BitConverter.GetBytes(float.Parse(tb_floatValue.Text));
                LogShow(bytes[0].ToString() + "," + bytes[1].ToString() + "," + bytes[2].ToString() + "," + bytes[3].ToString());
                Console.WriteLine(bytes[0] + "\n" + bytes[1] + "\n" + bytes[2] + "\n" + bytes[3] + "\n");
                //Array.Reverse(bytes);
                //Console.WriteLine(bytes[0] + "\n" + bytes[1] + "\n" + bytes[2] + "\n" + bytes[3] + "\n");
                if (BitConverter.ToUInt32(bytes, 0) == 0x42B40000)
                {
                    Console.WriteLine("=0x42B40000:" + BitConverter.ToUInt32(bytes, 0).ToString());

                }

            }
            else
            {
                tb_floatValue.Text = "90";
            }


            string accum = 90.ToString("X8");
            Console.WriteLine(accum);

            byte[] arr = new byte[] { 0x42, 0xB4, 0x00, 0x00 };
            Console.WriteLine(BitConverter.ToSingle(arr, 0).ToString());
            Array.Reverse(arr);
            if (BitConverter.ToUInt32(arr, 0) == 0x42B40000)
            {
                Console.WriteLine(BitConverter.ToUInt32(arr, 0).ToString());

            }

            //方法2：
            //byte[] bytes = GlobalInfo.ToByte(90);
            //Console.WriteLine(bytes[3] + "\n" + bytes[2] + "\n" + bytes[1] + "\n" + bytes[0] + "\n");

            //byte[] arr = new byte[] { 0x42, 0xB4, 0x00, 0x00 };
            //float value = GlobalInfo.ToFloat(arr);
            //Console.WriteLine(value);


            byte bytevalue = Convert.ToByte((0x88 >> 4) & 0x0f);
            Console.WriteLine(bytevalue);
        }

        #endregion

        #region 事件调用实时读取--参考

        private void Sampler_MsgCome(object sender, Serials.SamplerSerials.MsgComeEventArgs e)
        {
            try
            {
                //GlobalInfo.Instance.Totalab_LSerials.WaitSendSuccess.Set();
                //_IsRecived = true;
                if (e == null)
                    return;
                switch (e.Msg.FunctionCode)
                {
                    case 0x55:
                        //if (e.Msg.Cmd == 0xA1)
                        //{
                        //    //this.Dispatcher.Invoke((Action)(() =>
                        //    //{
                        //    IsConnect = true;
                        //    this.Dispatcher.Invoke((Action)(() =>
                        //    {
                        //        StatusColors = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF64DD17"));
                        //        StatusText = "Normal";
                        //    }));
                        //    //if (_IsFirst)
                        //    //{
                        //    //    GlobalInfo.Instance.IsCanRunning = false;
                        //    //    GlobalInfo.Instance.IsBusy = true;
                        //    //    GlobalInfo.Instance.Totalab_LSerials.XWZHome();
                        //    //}
                        //    //}));
                        //    //_IsRecived = true;
                        //}
                        break;
                    case 0xAA:
                        //if (e.Msg.Cmd == 0xA1)
                        //{
                        //    GlobalInfo.Instance.IsReadMCUOk = true;
                        //    GlobalInfo.Instance.MCUData = new byte[30];
                        //    GlobalInfo.Instance.MCUData = e.Msg.Data;
                        //}
                        //if (e.Msg.Cmd == 0xA2)
                        //    GlobalInfo.Instance.IsWriteMCUOk = true;
                        break;
                    case 0x85:
                        //if (e.Msg.Cmd == 0x50)//////////////////////正确的校验
                        //{
                        //    GlobalInfo.Instance.Totalab_LSerials.respondTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        //    GlobalInfo.Instance.Totalab_LSerials.WaitSendSuccess.Set();
                        //    Thread.Sleep(50);
                        //    break;
                        //}
                        //else if (e.Msg.Cmd == 0x51)/////////////////////////////错误校验
                        //{
                        //    GlobalInfo.Instance.Totalab_LSerials.respondTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        //    if (GlobalInfo.Instance.Totalab_LSerials.SendTempMsg != null)
                        //    {
                        //        GlobalInfo.Instance.Totalab_LSerials.Send(GlobalInfo.Instance.Totalab_LSerials.SendTempMsg.GetFrame());
                        //        GlobalInfo.Instance.Totalab_LSerials.respondTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        //    }
                        //    Thread.Sleep(50);
                        //    break;
                        //}
                        //else if (e.Msg.Cmd == 0x56)/////////////////////////////下位机接收错误的数据格式
                        //{
                        //    GlobalInfo.Instance.Totalab_LSerials.respondTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        //    Thread.Sleep(50);
                        //    break;
                        //}
                        break;
                    case 0x81:
                        //if (e.Msg.Cmd == 0x99)
                        //{

                        //}
                        //else if (e.Msg.Cmd == 0x9A)
                        //{

                        //}
                        //else if (e.Msg.Cmd == 0x9B)
                        //{
                        //    if (IsSamplerManual)
                        //    {
                        //        GlobalInfo.Instance.IsBusy = false;
                        //        IsSamplerManual = false;
                        //    }
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.ZHome)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.ZHomeOk;
                        //}
                        //else if (e.Msg.Cmd == 0x3d)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.ClosePump)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.ClosePumpOk;
                        //}
                        //else if (e.Msg.Cmd == 0x09)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.OpenPump)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.OpenPumpOk;
                        //}
                        //else if (e.Msg.Cmd == 0x17)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.SetPumpSpeed)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.SetPumpSpeedOk;
                        //}
                        break;
                    case 0x21:
                        //if (e.Msg.Cmd == 0x3d)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.ClosePump)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.ClosePumpOk;
                        //}
                        //else if (e.Msg.Cmd == 0x09)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.OpenPump)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.OpenPumpOk;
                        //}
                        //else if (e.Msg.Cmd == 0x17)
                        //{
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.SetPumpSpeed)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.SetPumpSpeedOk;
                        //}
                        break;
                    case 0x61:
                        //if (e.Msg.Cmd == 0x60)
                        //{
                        //    if (IsSamplerManual)
                        //    {
                        //        GlobalInfo.Instance.IsBusy = false;
                        //        IsSamplerManual = false;
                        //    }
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.XYZHome)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.XYZHomeOk;
                        //}
                        //else if (e.Msg.Cmd == 0x68)
                        //{
                        //    if (IsSamplerManual)
                        //    {
                        //        GlobalInfo.Instance.IsBusy = false;
                        //        IsSamplerManual = false;
                        //    }
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.GoToSampleXY)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.GoToSampleXYOk;
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.GoToSampleDepth)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.GoToSampleDepthOk;
                        //}
                        //else if (e.Msg.Cmd == 0x53)
                        //{
                        //    Thread.Sleep(500);
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.SendTrigger)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.SendTriggerOk;
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.CloseTrigger)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.CloseTriggerOk;
                        //}
                        //else if (e.Msg.Cmd == 0x79)
                        //{
                        //    if (IsSamplerManual)
                        //    {
                        //        GlobalInfo.Instance.IsBusy = false;
                        //        IsSamplerManual = false;
                        //    }
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.GoToSampleXY)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.GoToSampleXYOk;
                        //}
                        //else if (e.Msg.Cmd == 0x54 && e.Msg.Data[0] == 0x01)
                        //{
                        //    Thread.Sleep(500);
                        //    if (GlobalInfo.Instance.RunningStep == RunningStep_Status.RecvTrigger)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.RecvTriggerOk;
                        //}
                        break;
                    case 0x98:

                        break;
                    case 0x60://工作模式
                        //if (e.Msg.Data[1] == 0x01)
                        //    GlobalInfo.Instance.IsMotorXSetWorkModeOk = true;
                        //else if (e.Msg.Data[1] == 0x02)
                        //    GlobalInfo.Instance.IsMotorWSetWorkModeOk = true;
                        //else if (e.Msg.Data[1] == 0x03)
                        //    GlobalInfo.Instance.IsMotorZSetWorkModeOk = true;
                        //if (GlobalInfo.Instance.IsMotorXSetWorkModeOk && GlobalInfo.Instance.IsMotorWSetWorkModeOk && GlobalInfo.Instance.IsMotorZSetWorkModeOk)
                        //{
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.SetMortorWorkModeOk;
                        //    GlobalInfo.Instance.CurrentWorkType = Enum_MotorWorkType.Position;
                        //}
                        break;
                    case 0x7a:///设置目标位置
                        //if (e.Msg.Data[1] == 0x01)
                        //    GlobalInfo.Instance.IsMotorXSetTargetPositionOk = true;
                        //else if (e.Msg.Data[1] == 0x02)
                        //    GlobalInfo.Instance.IsMotorWSetTargetPositionOk = true;
                        //else if (e.Msg.Data[1] == 0x03)
                        //{
                        //    GlobalInfo.Instance.IsMotorZSetTargetPositionOk = true;
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.SetTargetPositionOk;
                        //}
                        //if (GlobalInfo.Instance.IsMotorWSetTargetPositionOk && GlobalInfo.Instance.IsMotorXSetTargetPositionOk && GlobalInfo.Instance.RunningStep != RunningStep_Status.SetTargetPositionOk)
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.SetTargetPositionOk;
                        break;
                    case 0x40:///执行
                        //int returnPositionX = 0;
                        //int returnPositionW = 0;
                        //if (e.Msg.Data[1] == 0x01)
                        //{
                        //    GlobalInfo.Instance.IsMotorXActionOk = true;
                        //    byte[] returnBytesX = new byte[4];
                        //    returnBytesX[0] = e.Msg.Data[2];
                        //    returnBytesX[1] = e.Msg.Data[3];
                        //    returnBytesX[2] = e.Msg.Data[4];
                        //    returnBytesX[3] = e.Msg.Data[5];
                        //    returnPositionX = BitConverter.ToInt32(returnBytesX, 0);
                        //    MainLogHelper.Instance.Info("移动完成后返回的位置：" + "X---" + returnPositionX);

                        //    GlobalInfo.Instance.Totalab_LSerials.ReadMotorPosition((byte)0x01);
                        //}
                        //else if (e.Msg.Data[1] == 0x02)
                        //{
                        //    GlobalInfo.Instance.IsMotorWActionOk = true;
                        //    byte[] returnBytesW = new byte[4];
                        //    returnBytesW[0] = e.Msg.Data[2];
                        //    returnBytesW[1] = e.Msg.Data[3];
                        //    returnBytesW[2] = e.Msg.Data[4];
                        //    returnBytesW[3] = e.Msg.Data[5];
                        //    returnPositionW = BitConverter.ToInt32(returnBytesW, 0);
                        //    MainLogHelper.Instance.Info("移动完成后返回的位置：" + "W---" + returnPositionW);

                        //    GlobalInfo.Instance.Totalab_LSerials.ReadMotorPosition((byte)0x02);
                        //}
                        //else if (e.Msg.Data[1] == 0x03)
                        //{
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.SetMotorActionOk;
                        //}
                        //if (GlobalInfo.Instance.IsMotorWActionOk && GlobalInfo.Instance.IsMotorXActionOk && GlobalInfo.Instance.RunningStep != RunningStep_Status.SetMotorActionOk)
                        //{
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.SetMotorActionOk;

                        //}
                        break;
                    case 0x41:///使能，急停，清除错误
                        //if (e.Msg.Data[2] == 0x80)
                        //{
                        //    if (e.Msg.Data[1] == 0x01)
                        //        GlobalInfo.Instance.IsMotorXError = false;
                        //    else if (e.Msg.Data[1] == 0x02)
                        //        GlobalInfo.Instance.IsMotorWError = false;
                        //    else if (e.Msg.Data[1] == 0x03)
                        //        GlobalInfo.Instance.IsMotorZError = false;
                        //    if (GlobalInfo.Instance.IsMotorXError == false && GlobalInfo.Instance.IsMotorWError == false && GlobalInfo.Instance.IsMotorZError == false)
                        //    {
                        //        this.Dispatcher.Invoke((Action)(() =>
                        //        {
                        //            StatusColors = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF64DD17"));
                        //            StatusText = "Normal";
                        //        }));
                        //    }
                        //}
                        //else if (e.Msg.Data[2] == 0x0B)
                        //{
                        //    if (e.Msg.Data[1] == 0x01)
                        //        GlobalInfo.Instance.IsMotorXStop = true;
                        //    else if (e.Msg.Data[1] == 0x02)
                        //        GlobalInfo.Instance.IsMotorWStop = true;
                        //    else if (e.Msg.Data[1] == 0x03)
                        //        GlobalInfo.Instance.IsMotorZStop = true;
                        //}
                        //else
                        //{
                        //    if (e.Msg.Data[1] == 0x01)
                        //        GlobalInfo.Instance.IsMotorXActionOk = true;
                        //    else if (e.Msg.Data[1] == 0x02)
                        //        GlobalInfo.Instance.IsMotorWActionOk = true;
                        //    else if (e.Msg.Data[1] == 0x03)
                        //    {
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.SetMotorActionOk;
                        //    }
                        //    if (GlobalInfo.Instance.IsMotorWActionOk && GlobalInfo.Instance.IsMotorXActionOk && GlobalInfo.Instance.RunningStep != RunningStep_Status.SetMotorActionOk)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.SetMotorActionOk;
                        //}
                        break;
                    case 0x64:                  //当前实际位置读取返回
                        //if (_IsFirst)
                        //{
                        //    _IsFirst = false;
                        //    GlobalInfo.Instance.TrayPanelCenter = (e.Msg.Data[5] * 16777216 + e.Msg.Data[4] * 65536 + e.Msg.Data[3] * 256 + e.Msg.Data[2]) / 3600.0 * GlobalInfo.XLengthPerCircle - GlobalInfo.Instance.TrayPanelHomeX;
                        //    GlobalInfo.Instance.IsCanRunning = true;
                        //    GlobalInfo.Instance.IsBusy = false;
                        //    byte[] content = FileHelper.ReadDecrypt(System.IO.Path.Combine(SampleHelper.AssemblyDirectory, "Parameters", "SamplerPos.ini"));
                        //    if (content != null)
                        //    {
                        //        GlobalInfo.Instance.CalibrationInfo = XmlObjSerializer.Deserialize<TrayPanelCalibrationInfo>(content);
                        //        GlobalInfo.Instance.TrayPanelCenter = GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition;
                        //        GlobalInfo.Instance.TrayPanelCenter_left = GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition_left;
                        //        GlobalInfo.Instance.TrayPanelCenter_right = GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition_right;
                        //        //GlobalInfo.Instance.TrayPanelHomeW = GlobalInfo.Instance.CalibrationInfo.WCalibrationPosition * 10.0 * 3.0;//取液针位置的实际角度长
                        //        GlobalInfo.Instance.TrayPanelHomeW = GlobalInfo.Instance.CalibrationInfo.WCalibrationPosition;//取液针位置的实际角度长
                        //    }
                        //    else
                        //    {
                        //        GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition = GlobalInfo.Instance.TrayPanelCenter;
                        //        GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition_left = GlobalInfo.Instance.TrayPanelCenter;
                        //        GlobalInfo.Instance.CalibrationInfo.XCalibrationPosition_right = GlobalInfo.Instance.TrayPanelCenter;
                        //        GlobalInfo.Instance.CalibrationInfo.WCalibrationPosition = GlobalInfo.Instance.TrayPanelHomeW / 10.0 / 3.0;
                        //        Point pt = new Point();
                        //        pt = GetPositionInfoHelper.GetWashPosition("W1");
                        //        GlobalInfo.Instance.CalibrationInfo.W1PointX = pt.X / 3600.0 * GlobalInfo.XLengthPerCircle - GlobalInfo.Instance.TrayPanelHomeX;
                        //        GlobalInfo.Instance.CalibrationInfo.W1PointY = pt.Y / 10.0 / 3.0;
                        //        pt = GetPositionInfoHelper.GetWashPosition("W2");
                        //        GlobalInfo.Instance.CalibrationInfo.W2PointX = pt.X / 3600.0 * GlobalInfo.XLengthPerCircle - GlobalInfo.Instance.TrayPanelHomeX;
                        //        GlobalInfo.Instance.CalibrationInfo.W2PointY = pt.Y / 10.0 / 3.0;
                        //    }
                        //}
                        //if (!_IsFirst && e.Msg.Data[1] == 0x01)
                        //{
                        //    byte[] bytes = new byte[4];
                        //    bytes[0] = e.Msg.Data[2];
                        //    bytes[1] = e.Msg.Data[3];
                        //    bytes[2] = e.Msg.Data[4];
                        //    bytes[3] = e.Msg.Data[5];
                        //    int positionX = BitConverter.ToInt32(bytes, 0);
                        //    MainLogHelper.Instance.Info("重新读取当前实际X位置：" + positionX);

                        //}
                        //if (e.Msg.Data[1] == 0x02)
                        //{
                        //    byte[] bytes = new byte[4];
                        //    bytes[0] = e.Msg.Data[2];
                        //    bytes[1] = e.Msg.Data[3];
                        //    bytes[2] = e.Msg.Data[4];
                        //    bytes[3] = e.Msg.Data[5];
                        //    int positionW = BitConverter.ToInt32(bytes, 0);
                        //    MainLogHelper.Instance.Info("重新读取当前实际W位置：" + positionW);

                        //}
                        break;
                    case 0x22:
                        //    if (e.Msg.DataLength == 12)
                        //        GlobalInfo.Instance.RunningStep = RunningStep_Status.XYZHomeOk;
                        //    if (_IsFirst)
                        //    {
                        //        GlobalInfo.Instance.TrayPanelHomeX = (e.Msg.Data[3] * 16777216 + e.Msg.Data[2] * 65536 + e.Msg.Data[1] * 256 + e.Msg.Data[0]) / 3600.0 * GlobalInfo.XLengthPerCircle;
                        //        GlobalInfo.Instance.TrayPanelHomeW = e.Msg.Data[7] * 16777216 + e.Msg.Data[6] * 65536 + e.Msg.Data[5] * 256 + e.Msg.Data[4];
                        //        GlobalInfo.Instance.TrayPanelHomeZ = (e.Msg.Data[11] * 16777216 + e.Msg.Data[10] * 65536 + e.Msg.Data[9] * 256 + e.Msg.Data[8]) / 3600.0 * GlobalInfo.ZLengthPerCircle;
                        //        //MainLogHelper.Instance.Info("返回当前的位置：" + GlobalInfo.Instance.TrayPanelHomeX + "---" + GlobalInfo.Instance.TrayPanelHomeW + "---" + GlobalInfo.Instance.TrayPanelHomeZ);
                        //        GlobalInfo.Instance.Totalab_LSerials.ReadMotorPosition((byte)0x01);

                        //    }
                        //    break;
                        //case 0xee:
                        //    if (e.Msg.Data[1] == 0x01)
                        //        GlobalInfo.Instance.IsMotorXError = true;
                        //    else if (e.Msg.Data[1] == 0x02)
                        //        GlobalInfo.Instance.IsMotorWError = true;
                        //    else if (e.Msg.Data[1] == 0x03)
                        //        GlobalInfo.Instance.IsMotorZError = true;
                        //    if (e.Msg.Data[2] == 0xe1)
                        //    {
                        //        this.Dispatcher.Invoke((Action)(() =>
                        //        {
                        //            GlobalInfo.Instance.LogInfo.Insert(0, DateTime.Now.ToString("hh:mm:ss") + "复位出错");
                        //        }));
                        //    }
                        //    else if (e.Msg.Data[2] == 0xe2)
                        //    {
                        //        this.Dispatcher.Invoke((Action)(() =>
                        //        {
                        //            GlobalInfo.Instance.LogInfo.Insert(0, DateTime.Now.ToString("hh:mm:ss") + "追随错误");
                        //        }));
                        //    }
                        //    else if (e.Msg.Data[2] == 0xe3)
                        //    {
                        //        this.Dispatcher.Invoke((Action)(() =>
                        //        {
                        //            GlobalInfo.Instance.LogInfo.Insert(0, DateTime.Now.ToString("hh:mm:ss") + "位置超限");
                        //        }));
                        //    }
                        //    GlobalInfo.Instance.RunningStep = RunningStep_Status.Error;
                        //    this.Dispatcher.Invoke((Action)(() =>
                        //    {
                        //        StatusColors = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF44336"));
                        //        StatusText = "Error";
                        //    }));
                        //    CancellationTokenSource source = new CancellationTokenSource();
                        //    Task.Factory.StartNew(() =>
                        //    {
                        //        GlobalInfo.Instance.Totalab_LSerials.SetLightStatus(0x00, 0x07);
                        //        Thread.Sleep(100);
                        //        GlobalInfo.Instance.Totalab_LSerials.SetLightStatus(0x02, 0x03);
                        //        Thread.Sleep(100);
                        //        if (Control_SampleListView.IsRunningFlow)
                        //            Control_SampleListView.ThreadStop();
                        //        else
                        //        {
                        //            bool result = MotorActionHelper.MotorErrorStopImmediately();
                        //            if (result == false)
                        //            {
                        //                ConntectWaring();
                        //            }
                        //        }
                        //    }, source.Token);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 随机获取一个数

        private void btn_Start_Click(object sender, EventArgs e)
        {
            //int count = 0;
            long longseconds;
            randomThread = new Thread(()=>
            {
                longseconds = DateTime.Now.Ticks / 10000;
                while (true)
                {

                    Random random = new Random();
                    //while ((DateTime.Now.Ticks / 10000 - longseconds) / 1000 < 5)           //等待4600ms---约等于5s
                    //{
                    //    count++;
                    //    Thread.Sleep(100);
                    //}
                    string num = random.Next(1001, 1089).ToString();
                    //Console.WriteLine(count);
                    Console.WriteLine(num);

                    //LogShow(count.ToString());
                    LogShow(num);
                    Thread.Sleep(1000);
                    //if (int.Parse(num) > 1005)
                    //{
                    //    break;
                    //}
                }
            });
            randomThread.Start();
        }
        #endregion

        #region 获取代码运行时间
        private void btn_AcquisitionTime_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"当前数值{i}");
                //模拟很耗时 得操作
                Thread.Sleep(1);
            }
            //停止代码运行计时
            stopwatch.Stop();
            //获取当前实例测量得出得总时间
            TimeSpan timeSpan = stopwatch.Elapsed;
            //运行的总秒数
            Console.WriteLine("success!");
            Console.WriteLine($"运行时间为：{timeSpan.TotalSeconds}秒");
            LogShow("运行时间为：" + timeSpan.TotalSeconds + "秒");

            //Console.ReadKey();
        }
        #endregion

        #region  反射
        /// <summary>
        /// 反射基本的类 获取属性及方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reflect_Click(object sender, EventArgs e)
        {
            //1、反射基本的类 获取属性及方法
            Type type = typeof(Person);
            Console.WriteLine("类型名:" + type.Name);

            Console.WriteLine("类全名：" + type.FullName);

            Console.WriteLine("命名空间名:" + type.Namespace);

            Console.WriteLine("程序集名：" + type.Assembly);

            Console.WriteLine("模块名:" + type.Module);

            Console.WriteLine("基类名：" + type.BaseType);

            Console.WriteLine("是否类：" + type.IsClass);

            Console.WriteLine("类的公共成员(Public)：");

            MemberInfo[] memberInfos = type.GetMembers();//得到所有公共成员
            foreach (var item in memberInfos)
            {
                Console.WriteLine(string.Format("{0}:{1}", item.MemberType, item));

            }
            Console.WriteLine("类的公共属性(Public)：");
            PropertyInfo[] Propertys = type.GetProperties();
            foreach (PropertyInfo fi in Propertys)
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine("类的公共方法(Public)：");
            MethodInfo[] mis = type.GetMethods();
            foreach (MethodInfo mi in mis)
            {
                Console.WriteLine(mi.ReturnType + " " + mi.Name);
            }

            Console.WriteLine("类的公共字段(Public)：");
            FieldInfo[] fis = type.GetFields();
            foreach (FieldInfo fi in fis)
            {
                Console.WriteLine(fi.Name);
            }

            //Console.ReadKey();
        }
        /// <summary>
        /// 利用发射创建对象并调用相应的方法 （System.Reflection.Assembly）：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reflectCreat_Click(object sender, EventArgs e)
        {
            string Namespace = "All_Test.Common";
            Person report = (Person)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(Namespace + ".Robot", false, System.Reflection.BindingFlags.Default, null, null, null, null);
            report.Speak();
            var student = new Student();
            student.Speak();
            //Console.ReadKey();
        }
        /// <summary>
        /// 利用反射探测当前程序集 （System.Reflection.Assembly）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reflectC_Click(object sender, EventArgs e)
        {
            //2、获取当前执行代码的程序集
            Assembly assem = Assembly.GetExecutingAssembly();

            Console.WriteLine("程序集全名:" + assem.FullName);

            Console.WriteLine("程序集的版本：" + assem.GetName().Version);

            Console.WriteLine("程序集初始位置:" + assem.CodeBase);

            Console.WriteLine("程序集位置：" + assem.Location);

            Console.WriteLine("程序集入口：" + assem.EntryPoint);


            Type[] types = assem.GetTypes();
            Console.WriteLine("程序集下包含的类型:");
            foreach (var item in types)
            {
                Console.WriteLine("类：" + item.Name);
            }
            //Console.ReadKey();
        }

        //在类声明中使用 abstract 修饰符来指示某个类仅用作其他类的基类，而不用于自行进行实例化。 标记为抽象的成员必须由派生自抽象类的非抽象类来实现。
        public abstract class Person
        {
            public string PersonType = "地球人";//字段
            public string Name { get; set; }//属性+方法：get_Name 等
            public int Age { get; set; }//属性
            public string Sex { get; set; }//属性
            public abstract void Speak();//方法
        }

        public class Student : Person
        {
            public string StudentNo { get; set; }
            public override void Speak()
            {
                Name = "反射";
                Console.WriteLine("我的名字是：" + Name + "  " + "学号是：" + GetStudentNo());
            }

            public string GetStudentNo()
            {
                return "081309207";
            }
        }
        #endregion

        #region 一秒执行一次
        Timer timer = new Timer();

        private void btn_TimeStart_Click(object sender, EventArgs e)
        {
            if (tb_times.Text != "")
            {
                TestTimer(long.Parse(tb_times.Text));
            }
            else
            {
                TestTimer(2000);
            }
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
        public void TestTimer(long time)
        {

            timer = new Timer(time);  //五秒访问
            //timer.Interval = time;              //设置间隔
            timer.Elapsed += new ElapsedEventHandler(ServerStart);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }
        public void ServerStart(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now + "============定时器数据接收服务开启============");
            LogShow("=定时器数据接收服务开启=");
        }


        #endregion

        #region 延时

        private void btn_TimerTest_Click(object sender, EventArgs e)
        {
            WaitFunctions(Convert.ToInt32(tb_min.Text));

            //Thread thread = new Thread(WaitMin);
            //thread.Start();
        }
        public void WaitFunctions(int waitTime)
        {
            if (waitTime <= 0) return;

            Console.WriteLine("开始执行 ...");
            DateTime nowTimer = DateTime.Now;
            Console.WriteLine("开始时间：" + nowTimer);
            int interval = 0;
            while (interval < waitTime)
            {
                TimeSpan spand = DateTime.Now - nowTimer;
                if (interval != spand.Seconds)
                {
                    interval = spand.Seconds;
                    Console.WriteLine(interval + "秒");
                }
            }
            DateTime endTimer = DateTime.Now;
            Console.WriteLine("结束时间：" + endTimer);
            Console.WriteLine(waitTime + "秒后继续 ...");

            #region 方式二
            //var oj = BeginInvoke((Action)(() =>
            //{
            //    while (true)
            //    {
            //        TimeSpan spand = DateTime.Now - nowTimer;
            //        Thread.Sleep(500);
            //        if (spand.Seconds == 10)
            //        {
            //            Console.WriteLine(spand.Seconds + "秒");
            //        }
            //        else { break; }
            //    }
            //}));
            //if (oj.IsCompleted)
            //{
            //    Console.WriteLine("运行完成");
            //}
            #endregion

        }

        public void WaitMin()
        {
            long min = DateTime.Now.Ticks / 10000;
            long delaySeconds = 0;
            Console.WriteLine("时间开始：" + DateTime.Now);
            while ((long.Parse(tb_min.Text) * 60 - delaySeconds) > 0)
            {
                Thread.Sleep(200);
                delaySeconds = (DateTime.Now.Ticks / 10000 - min) / 1000;
            }
            Console.WriteLine("分钟数到：" + DateTime.Now);
        }
        public async void WaitMin2()
        {
            for (int i = 0; i < 10; i++)
            {
                int interval = 0;
                var scheduler = new LimitedConcurrencyLevelTaskScheduler(1);
                await Task.Factory.StartNew(() =>
                {
                    while (interval < 10)
                    {
                        Thread.Sleep(1000);
                        interval++;
                        LogShow(interval.ToString());
                        //TimeSpan spand = DateTime.Now - startTimer;
                        //if (interval != spand.Seconds)
                        //{
                        //    interval = spand.Seconds;
                        //    //Console.WriteLine(interval + "秒");
                        //}
                        while (GlobalInfo.Instance.RunningStatus == RunningState.Pause)
                        {
                            interval = 0;
                            Thread.Sleep(100);
                        }
                    };
                }, CancellationToken.None, TaskCreationOptions.None, scheduler);

                LogShow("一分钟后执行" + Task.CurrentId.ToString());
            }
        }
        private void btn_wait60_Click(object sender, EventArgs e)
        {
            LogShow("执行开始");
            if (GlobalInfo.Instance.RunningStatus == RunningState.Pause)
            {
                GlobalInfo.Instance.RunningStatus = RunningState.Start;
            }
            else
            {
                GlobalInfo.Instance.RunningStatus = RunningState.Start;
                WaitMin2();
            }
        }

        private void btn_Panse_Click(object sender, EventArgs e)
        {
            LogShow("已暂停");
            GlobalInfo.Instance.RunningStatus = RunningState.Pause;
        }
        #endregion

        #region modbus用到的字节转换
        private void btn_modbus_Click(object sender, EventArgs e)
        {
            CmdMsg msg11 = new CmdMsg();
            byte[] bytes = { 0x01, 0x10, 0x00, 0x02, 0x00, 0x02, 0xE0, 0x08 };
            //GetMsg1(bytes, msg11);

            byte[] byte8_arry = { 0x01, 0x00 };
            byte[] byte4_arry = { 0x00, 0x00, 0xb4, 0xc2 };
            Array.Reverse(byte8_arry);
            UInt16 word16 = BitConverter.ToUInt16(byte8_arry, 0);
            float word4 = BitConverter.ToSingle(byte4_arry, 0);
            if (word4 == -90)
            {
                LogShow(word4.ToString());
            }
            if (word16 == 0x0100)
            {
                Console.WriteLine(word16);


                byte[] BY = GlobalInfo.intToBytes(word16);
                Console.WriteLine(BY[0] + " " + BY[1] + " " + BY[2] + " " + BY[3] + " ");
                UInt16 w = BitConverter.ToUInt16(BY, 0);
                Console.WriteLine("BY:" + w);
                byte[] BY2 = GlobalInfo.intToBytes2(word16);
                Console.WriteLine(BY2[0] + " " + BY2[1] + " " + BY2[2] + " " + BY2[3] + " ");
                UInt16 w2 = BitConverter.ToUInt16(BY2, 0);
                Console.WriteLine("BY2:" + w2);

            }
        }



        #endregion

        #region modbus----CRC校验
        private void btn_TypeConverter_Click(object sender, EventArgs e)
        {
            //float values = 20.0f;
            //byte[] bytes = BitConverter.GetBytes(values);
            //byte[] frameArray = new byte[13];
            //frameArray[0] = 0x01;
            //frameArray[1] = 0x10;
            //frameArray[2] = 0x00;
            //frameArray[3] = 0x02;
            //frameArray[4] = 0x00;
            //frameArray[5] = 0x02;
            //frameArray[6] = 0x04;
            //frameArray[7] = bytes[3];
            //frameArray[8] = bytes[2];
            //frameArray[9] = bytes[1];
            //frameArray[10] = bytes[0];
            //UInt16 CRC = CRCverify(frameArray, 11);
            //frameArray[11] = (byte)(CRC & 0xff);
            //frameArray[12] = (byte)((CRC >> 8) & 0xff);



            //Object Parameter=new List<int> { 1,2,3,4};
            //if (Parameter is List<int> analysisTypeList1)
            //{
            //    List<int> List2=((IEnumerable)Parameter).Cast<int>().ToList();
            //    foreach (int i in List2) 
            //    {
            //        LogShow(i.ToString());
            //    }

            //}

        }

        /// <summary>
        /// modbus----CRC校验
        /// </summary>
        /// <param name="bufData"></param>
        /// <param name="buflen"></param>
        /// <returns></returns>
        UInt16 CRCverify(byte[] bufData, UInt16 buflen)
        {
            UInt16 TCPCRC = 0xffff;
            UInt16 POLYNOMIAL = 0xa001;
            UInt16 i, j;

            for (i = 0; i < buflen; i++)
            {
                TCPCRC ^= bufData[i];
                for (j = 0; j < 8; j++)
                {
                    if ((TCPCRC & 0x0001) != 0)
                    {
                        TCPCRC >>= 1;
                        TCPCRC ^= POLYNOMIAL;
                    }
                    else
                    {
                        TCPCRC >>= 1;
                    }
                }
            }
            return TCPCRC;
        }

        #endregion

        #region 字符串换行显示
        private void StrTest()
        {
            string str = "附件二哦i阿娇佛奥马尔发i";
            if (str.Length > 5)
            {
                str = str.Insert(5, "\n");
            }
            Console.WriteLine(str);

        }
        #endregion

        #region 文件夹
        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public int CopyFolder2(string sourceFolder, string destFolder)
        {
            try
            {
                string folderName = System.IO.Path.GetFileName(sourceFolder);
                string destfolderdir = System.IO.Path.Combine(destFolder, folderName);
                string[] filenames = System.IO.Directory.GetFileSystemEntries(sourceFolder);
                foreach (string file in filenames)// 遍历所有的文件和目录
                {
                    if (System.IO.Directory.Exists(file))
                    {
                        string currentdir = System.IO.Path.Combine(destfolderdir, System.IO.Path.GetFileName(file));
                        if (!System.IO.Directory.Exists(currentdir))
                        {
                            System.IO.Directory.CreateDirectory(currentdir);
                        }
                        CopyFolder2(file, destfolderdir);
                    }
                    else
                    {
                        string srcfileName = System.IO.Path.Combine(destfolderdir, System.IO.Path.GetFileName(file));
                        if (!System.IO.Directory.Exists(destfolderdir))
                        {
                            System.IO.Directory.CreateDirectory(destfolderdir);
                        }
                        System.IO.File.Copy(file, srcfileName);
                    }
                }

                return 1;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return 0;
            }

        }
        #endregion

        #region DateTime.Time. Ticks

        private void btn_Ticks_Click(object sender, EventArgs e)
        {
            //long str = DateTime.Now.Ticks/10000000;
            DateTime str = DateTime.Now;
            LogShow(str.ToString());
            //Console.WriteLine(str);
            Thread.Sleep(5000);
            DateTime str1 = DateTime.Now;
            LogShow(str1.ToString());
            TimeSpan timeSpan = str1 - str;
            LogShow(timeSpan.ToString(@"hh\:mm\:ss"));
        }

        #endregion

        #region 等待时间
        /// <summary>
        /// 等待时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WaitTime_Click(object sender, EventArgs e)
        {
            int i = 0;
            long longsecondss = DateTime.Now.Ticks / 10000;
            while ((DateTime.Now.Ticks / 10000 - longsecondss) / 1000 < 5)
            {
                i++;
                LogShow(i.ToString());
                Thread.Sleep(1000);
            }
        }

        #endregion




        #endregion

        #region 测试页2

        #region 开启/停止Windows服务
        /// <summary>
        /// 关闭服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ServiceClose_Click(object sender, EventArgs e)
        {
            //string windowsServiceName = "Windows 更新";
            string windowsServiceName = tb_ServiceName.Text;
            StopWindowsService(windowsServiceName);
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ServiceOpen_Click(object sender, EventArgs e)
        {
            string windowsServiceName = tb_ServiceName.Text;
            StartWindowsService(windowsServiceName);
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="windowsServiceName">服务名称</param>
        private void StartWindowsService(string windowsServiceName)
        {
            using (System.ServiceProcess.ServiceController control = new System.ServiceProcess.ServiceController(windowsServiceName))
            {
                if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    Console.WriteLine("服务启动......");
                    control.Start();
                    Console.WriteLine("服务已经启动......");
                }
                else if (control.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    Console.WriteLine("服务已经启动......");
                }
            }

        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="windowsServiceName">服务名称</param>
        private void StopWindowsService(string windowsServiceName)
        {
            using (System.ServiceProcess.ServiceController control = new System.ServiceProcess.ServiceController(windowsServiceName))
            {
                if (control.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    Console.WriteLine("服务停止......");
                    LogShow("服务停止......");
                    control.Stop();
                    Console.WriteLine("服务已经停止......");
                    LogShow("服务已经停止......");
                }
                else if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    LogShow("服务已经停止......");
                    Console.WriteLine("服务已经停止......");
                }
            }
        }



        #endregion

        #region 三角函数
        private void btn_sin_Click(object sender, EventArgs e)
        {
            double angle = double.Parse(tb_angle.Text);
            double TrayWOffset = Math.Sin(angle / 2 * Math.PI / 180) * 120.8;
            LogShow("补偿的值： Math.Sin("+ angle + " / 2 * Math.PI / 180 )" +TrayWOffset );
            double itemXToCenter = 107 + TrayWOffset;
            double length = Math.Sqrt(Math.Pow(120.8, 2) - Math.Pow(itemXToCenter, 2)) - 49;
            LogShow("补偿后的值： " + length);
            double length1 = Math.Sqrt(Math.Pow(120.8, 2) - Math.Pow(107, 2)) - 49;
            LogShow("没补偿的值： Math.Pow(107, 2)" + length1);

            double TrayWOffset1 = Math.Sin(0 / 2 * Math.PI / 180) * 120.5;
            LogShow("测试0：" + TrayWOffset1);

            double value = 109.15 / ( Math.Tan(64.63 * Math.PI / 180));
            LogShow("Tan值：" + value);
        }

        #endregion

        #region MyRegion
        public static void ReportSave()
        {
            //System.Windows.Current.Dispatcher.Invoke((Action)(() =>
            //{
            //    DateTime date = DateTime.Now;
            //    if (!Directory.Exists(SettingData.Instance.ReportPath))
            //    {
            //        Directory.CreateDirectory(SettingData.Instance.ReportPath);
            //    }
            //    string filename = SettingData.Instance.ReportPath + "\\" + date.ToLongDateString();
            //    if (!Directory.Exists(filename))
            //    {
            //        Directory.CreateDirectory(filename);
            //        ProcessVariable.Instance.ReportName.Add(date.ToLongDateString());
            //    }
            //    string path = filename + "\\" + date.ToString("HH时mm分") + "By" + GlobalVariable.userInfor.UserName + ".ini";
            //    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            //    try
            //    {
            //        sw.WriteLine("用户名---" + GlobalVariable.userInfor.UserName);
            //        sw.WriteLine("是否为管理员--" + GlobalVariable.userInfor.Level_6);
            //        sw.WriteLine(MethodData.Instance.MethodName);
            //        sw.WriteLine("步骤" + "\t\t" + "样品/溶剂" + "\t\t" + "体积mL  " + "\t\t" + "流速mL/min" + "\t\t" + "收集位置" + "\t");
            //        for (int i = 0; i < MethodData.Instance.methodInfos.Count; i++)
            //        {
            //            if (MethodData.Instance.methodInfos[i].StepName == StepName.清洗样品瓶 || MethodData.Instance.methodInfos[i].StepName == StepName.清洗进样针)
            //                sw.WriteLine(MethodData.Instance.methodInfos[i].StepName + "\t" +
            //                    MethodData.Instance.methodInfos[i].SolventName + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].Volume + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].FlowRate + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].CollectionPosition + "\t\t");
            //            else if (MethodData.Instance.methodInfos[i].StepName == StepName.上样)
            //            {
            //                sw.WriteLine(MethodData.Instance.methodInfos[i].StepName + "\t\t" +
            //                    MethodData.Instance.methodInfos[i].SolventName + "\t\t\t" +
            //                    "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].FlowRate + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].CollectionPosition + "\t\t");
            //                sw.WriteLine("\t\t" + "通道" + "\t\t\t" + "体积" + "\t\t\t" + "上样完成时间");
            //                foreach (var item1 in GlobalVariable.LoadSampleVolumnReport)
            //                {
            //                    if (GlobalVariable.LoadSampleEndTimeReport.Count != 0)
            //                    {
            //                        foreach (var item2 in GlobalVariable.LoadSampleEndTimeReport)
            //                        {
            //                            if (item1.Key == item2.Key)
            //                            {
            //                                sw.WriteLine("\t\t" + item1.Key + "\t\t\t" + item1.Value + "\t\t\t" + item2.Value);
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        sw.WriteLine("\t\t" + item1.Key + "\t\t\t" + item1.Value);
            //                    }
            //                }
            //            }
            //            else
            //                sw.WriteLine(MethodData.Instance.methodInfos[i].StepName + "\t\t" +
            //                    MethodData.Instance.methodInfos[i].SolventName + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].Volume + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].FlowRate + "\t\t\t" +
            //                    MethodData.Instance.methodInfos[i].CollectionPosition + "\t\t");
            //        }
            //        foreach (string str in ProcessVariable.Instance.EngineerLog)
            //            sw.WriteLine(str);
            //    }
            //    catch
            //    {

            //    }
            //    finally
            //    {
            //        sw.Close();
            //        fs.Close();
            //    }
            //}));
        }

        #endregion

        #region list.ForEach
        public class PersonTest
        {
            //private int id;
            public int Id { get; set; }
            //private string personName;
            public string PersonName { get; set; }

        }
        private void btn_listForEach_Click(object sender, EventArgs e)
        {
            List<PersonTest> list = new List<PersonTest>(){
             new PersonTest(){ Id=1,PersonName="AAA"},
             new PersonTest(){ Id=2,PersonName="SSS"},
             new PersonTest(){ Id=3,PersonName="BBB"},
             new PersonTest(){ Id=4,PersonName="RRR"},
             };
            list.ForEach(item =>
            {
                if (item.PersonName.Contains("S") || item.PersonName.Contains("R"))
                {
                    item.PersonName = "111";
                }
                LogShow(item.Id + ":" + item.PersonName);
            });
            list.ForEach(t => t.PersonName = "OOO");
            list.ForEach(Print);
        }
        private void Print(PersonTest personTest)
        {
            LogShow(personTest.Id + ":" + personTest.PersonName);
        }
        #endregion

        #region 委托
        //Action委托(都没有返回值)：
        //Action：无参，无返回值；
        //Action<T>：有参数T(1~16 个)，无返回值；

        //Func委托(都有返回值)：
        //Func<T>:无参，返回值为T;
        //Func<T1, T2, T>:有参数T1,T2(1~16个)，返回值为T

        /// <summary>
        /// Action委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_action_Click(object sender, EventArgs e)
        {
            Action action01;                                    //定义Action委托，无参数，无返回值
            action01 = () => LogShow("Action无参数的委托");       //使用Lambda表达式添加方法语句块
            action01();

            Action<int> action02;
            action02 = (int a) => LogShow("Action有1个参数的委托" + a);
            //action02 = (int a) => Console.WriteLine("Action有1个参数的委托{0}", a);
            action02(666);
        }
        /// <summary>
        /// Func委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_func_Click(object sender, EventArgs e)
        {
            //定义Func委托，没有参数，返回值是int
            Func<int> func01;
            func01 = () =>
            {
                LogShow("一个无参数的Func委托，返回值是：");
                return 123;
            };
            var temp = func01();
            LogShow(temp.ToString());


            //定义Func委托，有两个string参数，返回值是int，注意返回值是在<>的最后一个
            Func<string, string, int> func02;
            func02 = (string str1, string str2) =>
            {
                LogShow($"{str1}一个无参数的Func委托{str2}，返回值是： ");
                return 567;
            };
            var temp02 = func02("我是", "类型");
            LogShow(temp02.ToString());
        }
        #endregion

        #region 正则表达式
        public void MatchTest()
        {
            string we = DateTime.Now.ToLongDateString().ToString();
            //string pattern = @"\^(?< !\\QSS\\E).*$\";
            //string str = "S S  456.5g";
            //// 找出不匹配项
            //List<string> mismatches = new List<string>();
            //foreach (var s in str)
            //{
            //    // 检查是否匹配
            //    Match match1 = Regex.Match(str, pattern);
            //    if (!match1.Success)
            //    {
            //        // 不匹配的项添加到列表
            //        mismatches.Add(str);
            //    }
            //}


            string str = "S S  456.5g";
            str = Regex.Replace(str, @"\s", "");
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'S' || str[i] == 'D' || str[i] == 'g')
                {
                    str = str.Replace(str[i], ' ');
                }
            }
            Console.WriteLine(str);


            #region MyRegion
            //string Text = "http://192.168.0.1:2008";
            //string pattern = @"/b(/S+)://(/S+)(?::(/S+))/b";
            //MatchCollection matches = Regex.Matches(Text, pattern, RegexOptions.ExplicitCapture | RegexOptions.RightToLeft);

            //Console.WriteLine("从左向右匹配字符串：");

            //foreach (Match NextMatch in matches)
            //{
            //    Console.Write("匹配的位置：{0} ", NextMatch.Index);
            //    Console.Write("匹配的内容：{0} ", NextMatch.Value);
            //    Console.Write("/n");

            //    for (int i = 0; i < NextMatch.Groups.Count; i++)
            //    {
            //        Console.Write("匹配的组 {0}：{1,4} ", i + 1, NextMatch.Groups[i].Value);
            //        Console.Write("/n");
            //    }
            //}
            #endregion


        }
        #endregion

        #region 二维码生成
        Bitmap bitmap = null;           //结果图片
        private void btn_QRcode_Click(object sender, EventArgs e)
        {
            string info = tb_QRcode.Text.ToString();

            int height = 153;
            int width = 153;
            try
            {
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;           //二维码有很多标准，这里可以设定
                barcodeWriter.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
                barcodeWriter.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
                barcodeWriter.Options.Height = height;
                barcodeWriter.Options.Width = width;
                barcodeWriter.Options.Margin = 0;
                ZXing.Common.BitMatrix bitMatrix = barcodeWriter.Encode(info);
                bitmap = barcodeWriter.Write(bitMatrix);

                //显示
                this.pictureBox1.Image = bitmap;

                // 保存为图片文件
                //string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "..\\QR_CODE_" + info.Substring(0, info.Length) + ".jpg";
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "QR_CODE";
                if (Directory.Exists(filePath))
                {
                    filePath = filePath + "\\" + info.Substring(0, info.Length) + ".jpg";
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    Directory.CreateDirectory(filePath);
                    filePath = filePath + "\\" + info.Substring(0, info.Length) + ".jpg";
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("二维码生成过程出错");
            }
        }
        /// <summary>
        /// 清除二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearQRCode_Click(object sender, EventArgs e)
        {
            tb_QRcode.Text = "";
            pictureBox1.Image = null;
        }
        #endregion

        #region 调用摄像头扫描二维码
        FilterInfoCollection videoDevices; //所有摄像头
        VideoCaptureDevice videoSource; //当前摄像头 
        public int selectedDeviceIndex = 0;
        /// <summary>
        /// 全局变量，标示设备摄像头设备是否存在
        /// </summary>
        bool DeviceExist;
        /// <summary>
        /// 全局变量，记录扫描线距离顶端的距离
        /// </summary>
        int top = 0;
        /// <summary>
        /// 全局变量，保存每一次捕获的图像
        /// </summary>
        Bitmap img = null;
        /// <summary>
        /// 获取摄像头列表
        /// </summary>

        [Obsolete]
        private void btn_GetCamera_Click(object sender, EventArgs e)
        {
            if (btn_GetCamera.Text == "摄像头扫描")
            {
                if (DeviceExist)
                {
                    //视频捕获设备
                    videoSource = new VideoCaptureDevice(videoDevices[cb_Camera.SelectedIndex].MonikerString);
                    //捕获到新画面时触发
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    //先关一下，下面再打开。避免重复打开的错误
                    CloseVideoSource();
                    //设置画面大小
                    videoSource.DesiredFrameSize = new Size(160, 120);
                    //启动视频组件
                    videoSource.Start();
                    btn_GetCamera.Text = "结束";
                    //启动定时解析二维码
                    timer1.Enabled = true;
                    //启动绘制视频中的扫描线
                    timer2.Enabled = true;
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    CloseVideoSource();
                    btn_GetCamera.Text = "开始";
                }
            }
        }
        private void getCamList()
        {
            try
            {
                //AForge.Video.DirectShow.FilterInfoCollection 设备枚举类
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //清空列表框
                cb_Camera.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                DeviceExist = true;
                //加入设备
                foreach (FilterInfo device in videoDevices)
                {
                    cb_Camera.Items.Add(device.Name);
                }
                //默认选择第一项
                cb_Camera.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cb_Camera.Items.Add("未找到可用设备");
            }
        }
        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            #region 读取图片并解析成文本-----方式1
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode(img);

            if (result != null)
            {
                Encoding utf8 = Encoding.GetEncoding("iso8859-1");   //设置以iso8859-1方式读取
                byte[] utf8byte = utf8.GetBytes(result.ToString());     //转成字节数组
                Encoding gbk = Encoding.GetEncoding("gbk");             //设置以gbk格式读取
                string decodedString = gbk.GetString(utf8byte);         //转成文本
                //string decodedString = Encoding.UTF8.GetString(utf8byte);
                tb_QRcodeshow.Text = decodedString;
            }

            #endregion

            #region 方式2
#if false
            #region 将图片转换成byte数组
            MemoryStream ms1 = new MemoryStream();
            img.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bt = ms1.GetBuffer();
            ms1.Close();
            #endregion

            #region 不稳定的二维码解析端口
            LuminanceSource source = new RGBLuminanceSource(bt, img.Width, img.Height);
            BinaryBitmap bitmap1 = new BinaryBitmap(new ZXing.Common.HybridBinarizer(source));

            Result result;

            MultiFormatReader multiFormatReader = new MultiFormatReader();

            try
            {
                //开始解码
                result = multiFormatReader.decode(bitmap1);//（不定期暴毙）
                
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                multiFormatReader.reset();

            }


            if (result != null)
            {
                string aaa = result.ToString();
                string bbb = result.Text;
                //Encoding.GetEncoding("GB2312").GetString(result);
                tb_QRcodeshow.Text = result.Text;

            }
            #endregion
#endif
            #endregion

        }
        /// <summary>
        /// 红色扫描线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            Bitmap img2 = (Bitmap)img.Clone();
            Pen p = new Pen(Color.Red);
            Graphics g = Graphics.FromImage(img2);
            Point p1 = new Point(0, top);
            Point p2 = new Point(pb_show.Width, top);
            g.DrawLine(p, p1, p2);
            g.Dispose();
            top += 4;

            top = top % pb_show.Height;
            pb_show.Image = img2;

        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
                pb_show.Image.Dispose();
                timer1.Dispose();
                timer2.Dispose();
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            img = (Bitmap) eventArgs.Frame.Clone();
            //pb_show.Image = img;
        }
        #endregion

        #region 单张二维码图片扫描
        /// <summary>
        /// 单张图片扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pictureScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("请先生成二维码！");
                    return;
                }
                Bitmap Imagemap = new Bitmap(pictureBox1.Image);
                string QRCodeResult = ParseBarCode(Imagemap);
                tb_QRcodeshow.Text = QRCodeResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 清空扫描文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ScanText_Click(object sender, EventArgs e)
        {
            tb_QRcodeshow.Text = "";
        }
        public static string ParseBarCode(Bitmap image)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode(image);
            return result.Text;
        }
        /// <summary>
        /// Bitmap转Byte
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public byte[] BitmapToByte(System.Drawing.Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Dispose();
            return bytes;
        }
        #endregion

        #endregion

        #region Task测试
        #region 取消正在运行得Task
        /// <summary>
        /// 非标准不推荐任务取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
            {
                //新建线程引用
                Thread _thread = null;
                //新建任务
                Task t = Task.Run(() =>
                {
                    //获取当前任务底层得线程得引用
                    _thread = Thread.CurrentThread;
                    //任务开始
                    Console.WriteLine("Task Start!");
                    //模拟耗时操作
                    Thread.Sleep(1000);
                    //任务结束
                    Console.WriteLine("Task finished!");

                });
                //让任务先运行起来
                Thread.Sleep(10000);

                //强行终止任务
                _thread.Abort();

                //wait
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            /// <summary>
            /// 标准推荐任务取消操作
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_StandardCancel_Click(object sender, EventArgs e)
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;

                Task t = Task.Run(() =>
                {
                    while (true)
                    {
                        //检测任务是否被取消
                        if (tokenSource.IsCancellationRequested)
                        {
                            Console.WriteLine("Task canceled");
                            break;
                        }
                        //任务开始
                        Console.WriteLine("Task start!");

                        //模拟耗时的操作
                        Thread.Sleep(10000);

                        //任务结束
                        Console.WriteLine("Task finished!");
                    }
                }, token);

                while (true)
                {
                    Console.WriteLine("请切换到英文输入法！");
                    Console.WriteLine("取消任务请按W键");
                    if (Console.ReadKey().Key == ConsoleKey.W)
                    {
                        tokenSource.Cancel();
                    }
                }
            }

            #endregion

        #region Task.Run资源释放
        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                sourceDis();
                Thread.Sleep(1000);
            }
        }
        public async void sourceDis()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            int interval = 0;
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    while (interval < 60)
                    {
                        Thread.Sleep(1000);
                        interval++;
                        //TimeSpan spand = DateTime.Now - startTimer;
                        //if (interval != spand.Seconds)
                        //{
                        //    interval = spand.Seconds;
                        //    //Console.WriteLine(interval + "秒");
                        //}

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("RunningStatus.LoadSample_VibrationMotorOpenOK" + ex.ToString());
                }
                finally
                {
                    Console.WriteLine("1分钟" + interval);
                    source.Cancel();
                    source.Dispose();
                }
            }, source.Token);
        }
        #endregion

        #region Task测试

        private void btn_TaskWaitAll_Click(object sender, EventArgs e)
        {
            Thread_HelpClass helpClass = new Thread_HelpClass();
            Task thread1 = Task.Factory.StartNew(() => helpClass.fun1());
            Task thread2 = Task.Factory.StartNew(() => helpClass.fun2());
            Task.WaitAll(thread1, thread2);
            LogShow(GlobalInfo.Instance.fun1num.ToString());
            LogShow(GlobalInfo.Instance.fun2num.ToString());
            LogShow("The End");

        }

        private void btn_ThreadJoin_Click(object sender, EventArgs e)
        {
            Thread_HelpClass helpClass = new Thread_HelpClass();
            LogShow(DateTime.Now.ToString());
            Thread thread1 = new Thread(new ThreadStart(helpClass.fun1));
            Thread thread2 = new Thread(new ThreadStart(helpClass.fun2));
            thread1.Start();
            thread1.Join();
            LogShow(DateTime.Now.ToString());
            thread2.Start();
            thread2.Join();
            LogShow(GlobalInfo.Instance.fun2num.ToString());
            LogShow(DateTime.Now.ToString());
        }
        #endregion

        #region 确保一个线程结束，开始下一个线程
        private void btn_Task_Click(object sender, EventArgs e)
        {
            Task<int> ta = new Task<int>(() =>
            {
                return 422;
            });
            //同步运行，相当于运行在主线程中
            ta.RunSynchronously();
            LogShow(ta.Result.ToString());

            Task<int> task = Task.Run<int>(() => {
                return 42;
            });
            //task.GetAwaiter().OnCompleted(() =>
            //{
            //    //这个一定会执行
            //    Console.WriteLine(task.Result);
            //});
            //Console.WriteLine("主线程结束！");

            Task<int> taskcontinue = task.ContinueWith<int>((tsk) => {
                //传入的是task任务对象
                LogShow(tsk.Result.ToString());
                return 24 + tsk.Result;
            });

            LogShow(taskcontinue.Result.ToString());
            //taskcontinue.GetAwaiter().OnCompleted(() =>
            //{
            //    //这个一定会执行
            //    Console.WriteLine(taskcontinue.Result);
            //});

            Task<int> tasktask = Task.Run<int>(() =>
            {
                return 4200;
            });
            //tasktask.Status!=TaskStatus.
            while (!tasktask.IsCompleted)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            LogShow(tasktask.Result.ToString());
        }











        #endregion

        #endregion


    }
}
