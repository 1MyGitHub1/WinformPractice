using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyCustomLib
{
    [RunInstaller(true)]
    public partial class InstallerClass : System.Configuration.Install.Installer
    {
        public InstallerClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 安装完成之后的操作，可以保留安装路径到
        /// 使用跨调用保留并传入 Install、Commit、Rollback和 Uninstall 方法的 IDictionary。
        /// IDictionary savedState
        /// </summary>
        /// <param name="savedState"></param>
        protected override void OnAfterInstall(IDictionary savedState)
        {
            try
            {
                Logger($"OnAfterInstall开始");
                //获取自定义安装用户界面上的端口值
                //string portId = this.Context.Parameters["PortId"];
                //string path = "D:\\Debug";
                string path = this.Context.Parameters["targetdir"];
                //Logger($"OnAfterInstall添加 targetdir savedState:{path}");
                //开机启动 1、硬编码，2设置Setup Projects的注册表编辑器
                //1、安装完成以后可以把硬编码把该软件写到注册表中，这样可以设置开机启动，
                //2、当然还有另外一种开机启动的方式是可以使用Setup Projects的注册表编辑器的来进行注册
                //savedState.Add("savedState", path);
                Assembly asm = Assembly.GetExecutingAssembly();
                string asmpath = asm.Location.Remove(asm.Location.LastIndexOf("\\")) + "\\";
                Logger($"OnAfterInstall asmpath:{asmpath}");
                //SetAutoStart(true, "MyTestWinFrm", asmpath + "MyTestWinFrm.exe");
                //Process.Start(asmpath + "\\ServiceXStart.exe");//要执行的程序
                //Process.Start(asmpath + "SetupTest.exe");//要执行的程序
                Process.Start(asmpath + "CDM21412_Setup.exe");//要执行的程序
                base.OnAfterInstall(savedState);

            }
            catch (Exception ex)
            {
                Logger($"OnAfterInstall警告:{ex}");
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        private static void Logger(string message)
        {
            try
            {
                string fileName = @"D:\Test\log.txt";
                if(!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                using (var fs = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    var datas = System.Text.Encoding.Default.GetBytes(message);
                    fs.Write(datas, 0, datas.Count());
                    fs.Flush();
                }
                //if (!File.Exists(fileName))
                //{
                //    File.Create(fileName);
                //    //Trace.Listeners.Clear();
                //    //Trace.AutoFlush = true;
                //    //Trace.Listeners.Add(new TextWriterTraceListener(fileName));
                //}
                Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}" + message);
            }
            catch (Exception ex)
            {
                Trace.Listeners.Clear();
                Trace.AutoFlush = true;
                Trace.Listeners.Add(new TextWriterTraceListener(@"D:\Test\log.txt"));
                Trace.WriteLine($"Logger出错，错误信息：{ex}");
            }
        }
    }
}
