using All_Test.Serials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace All_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GlobalInfo.Instance.Totalab_LSerials.MsgCome += Sampler_MsgCome;

        }

        #region 日志
        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="logStr"></param>
        /// <param name="logNum"></param>
        public void LogShow(string logStr)
        {
            string str = "";
            this.BeginInvoke(new EventHandler(delegate
            {
                str = ChangeDateformat() + " " + DateTime.Now.ToShortTimeString() + " :" + logStr + "\n";
                list_log.AppendText(str);
                list_log.ScrollToCaret();
            }));
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

        #region 配置文件
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
        //保存
        private void btn_file_Click(object sender, EventArgs e)
        {
            string SavePath = System.IO.Path.Combine(AssemblyDirectory,"Parameters","SamplerPos.ini");
            string path = System.IO.Path.Combine(AssemblyDirectory, "Parameters");
            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
            }

            ////封装对象信息
            StudentInfo sto = new StudentInfo();
            if (textBox_name.Text!=""&& textBox_age.Text!="")
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

        #region  int转byte[]
        public byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];

            if (value<0)  // value > 0
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
            byte[] q = intToBytes(90);

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
            int count = 0;
            long longseconds;
            Random random = new Random();
            longseconds = DateTime.Now.Ticks / 10000;
            while (true)
            {
                while ((DateTime.Now.Ticks / 10000 - longseconds) / 1000 < 5)           //等待4600ms---约等于5s
                {
                    count++;
                    //Console.WriteLine("Thread.Sleep(100)");
                    Thread.Sleep(100);
                }
                string num = random.Next(1001, 1089).ToString();
                Console.WriteLine(count);
                Console.WriteLine(num);

                LogShow(count.ToString());
                LogShow(num.ToString());

                if (int.Parse(num) > 1005)
                {
                    break;
                }
            }
        }
        #endregion

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
            },token);

            while (true)
            {
                Console.WriteLine("请切换到英文输入法！");
                Console.WriteLine("取消任务请按W键");
                if (Console.ReadKey().Key ==ConsoleKey.W)
                {
                    tokenSource.Cancel();
                }
            }
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
            LogShow("运行时间为："+ timeSpan.TotalSeconds + "秒");
            
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
            public int Asge { get; set; }//属性
            public string Sex { get; set; }//属性
            public abstract void Speak();//方法
        }

        public class Student : Person
        {
            public string StudentNo { get; set; }
            public override void Speak()
            {
                Name = "反射";
                Console.WriteLine("我的名字是：" + Name +"  " + "学号是：" + GetStudentNo());
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
            if (tb_times.Text!="")
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
            if (tb_floatValue.Text !="")
            {
                byte[] bytes = BitConverter.GetBytes(float.Parse(tb_floatValue.Text));
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
            Console.WriteLine( BitConverter.ToSingle(arr, 0).ToString());
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

        #region 延时

        private void btn_TimerTest_Click(object sender, EventArgs e)
        {
            WaitFunctions(5);

            Thread thread= new Thread(WaitMin);
            thread.Start();
        }
        public void WaitFunctions(int waitTime)
        {
            if (waitTime <= 0) return;

            Console.WriteLine("开始执行 ...");
            DateTime nowTimer = DateTime.Now;
            Console.WriteLine("开始时间："+ nowTimer);
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
            Console.WriteLine("分钟数到："+ DateTime.Now);
        }
        #endregion

        #region modbus用到的字节转换
        private void btn_modbus_Click(object sender, EventArgs e)
        {
            CmdMsg msg11=new CmdMsg();
            byte[] bytes = { 0x01 ,0x10, 0x00 ,0x02 ,0x00, 0x02,0xE0, 0x08 };
            //GetMsg1(bytes, msg11);

            byte[] byte8_arry = { 0x01, 0x00 };
            Array.Reverse(byte8_arry);
            UInt16 word16 = BitConverter.ToUInt16(byte8_arry,0);
            //float word4 = BitConverter.ToSingle(byte8_arry, 0);
            if (word16 == 0x0100)
            {
                Console.WriteLine(word16);


                byte[] BY = GlobalInfo.intToBytes(word16);
                Console.WriteLine(BY[0]+" "+ BY[1] + " "+ BY[2] + " "+ BY[3] + " ");
                UInt16 w = BitConverter.ToUInt16(BY, 0);
                Console.WriteLine("BY:"+ w);
                byte[] BY2 = GlobalInfo.intToBytes2(word16);
                Console.WriteLine(BY2[0] + " " + BY2[1] + " " + BY2[2] + " " + BY2[3] + " ");
                UInt16 w2 = BitConverter.ToUInt16(BY2, 0);
                Console.WriteLine("BY2:" + w2);

            }
        }


        #endregion


    }
}
