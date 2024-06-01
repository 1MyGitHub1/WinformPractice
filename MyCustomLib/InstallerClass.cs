using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
                string installType = this.Context.Parameters["customData"].ToString();
                //string path = this.Context.Parameters["pathDir"].ToString();
                //安装路径
                Assembly asm = Assembly.GetExecutingAssembly();
                string path = asm.Location.Remove(asm.Location.LastIndexOf("\\")) + "\\";
                Logger($"安装路径:{path}");

                //Logger($"OnAfterInstall开始");
                long installDirSize = 0;
                string himassDir = "D:\\labtech\\APP1";
                //string himassDir = HelpClass.FindInstallDir("HiMass", out installDirSize);
                //判断否已经安装Mass,(没有安装:就不存在安装插件)
                if (himassDir != null || himassDir != " ")   //已安装
                {
                    if (installType == "2")//如果选择了以插件安装
                    {
                        if (himassDir != null || himassDir != " ")
                        {
                            if (Directory.Exists(himassDir + "\\SamplerPlugins"))
                            {
                                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(himassDir + "\\SamplerPlugins");
                                folder.MoveTo(himassDir + "\\SamplerPlugins备份");
                                Logger($"备份完成");


                                //得到原文件根目录下的所有文件夹
                                HelpClass.CopyFolder2(path, himassDir);
                                Logger($"复制完成");
                            }
                            else
                            {
                                //得到原文件根目录下的所有文件夹
                                HelpClass.CopyFolder2(path, himassDir);
                            }
                        }
                    }
                }
                //获取自定义安装用户界面上的端口值
                //string portId = this.Context.Parameters["PortId"];
                //string path = this.Context.Parameters["targetdir"];
                //Logger($"OnAfterInstall添加 targetdir savedState:{path}");
                //开机启动 1、硬编码，2设置Setup Projects的注册表编辑器
                //1、安装完成以后可以把硬编码把该软件写到注册表中，这样可以设置开机启动，
                //2、当然还有另外一种开机启动的方式是可以使用Setup Projects的注册表编辑器的来进行注册
                //savedState.Add("savedState", path);
                //Assembly asm = Assembly.GetExecutingAssembly();
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
        public static void Logger(string message)
        {
            try
            {
                //string fileName = @"C:\Test\log.txt";
                string fileName = @"C:\\labte\\Project\\Test\\Test_CSharp\\Function_Test";
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                string logFileName = fileName + "\\程序日志_" + DateTime.Now.ToString("yyyy_MM_dd_HH") + ".log";
                StringBuilder logContents = new StringBuilder();
                logContents.AppendLine(message);
                //当天的日志文件不存在则新建，否则追加内容
                StreamWriter sw = new StreamWriter(logFileName, true, System.Text.Encoding.Unicode);
                sw.Write(DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss") + " " + logContents.ToString());
                sw.Flush();
                sw.Close();

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

    public class HelpClass
    {
        public static List<string> IncludeFileList = new List<string>
        {
            "C:\\",
            "C:\\Labtech",
            "C:\\Program Files",
            "C:\\Program Files (x86)",
            "C:\\Program Files\\Labtech",
            "C:\\Program Files (x86)\\Labtech",
            "C:\\HiMass",
            "D:\\",
            "D:\\Labtech",
            "D:\\Program Files",
            "D:\\Program Files (x86)",
            "D:\\Program Files\\Labtech",
            "D:\\Program Files (x86)\\Labtech",
            "D:\\HiMass",
        };

        public static string FindInstallDir(string dirName, out long himassDirSize)
        {
            for (int i = 0; i < IncludeFileList.Count; i++)
            {
                string dirPath = FindDir(dirName, IncludeFileList[i]);
                if (dirPath == null)
                    continue;
                himassDirSize = 0;
                GetDirSizeByPath(dirPath, ref himassDirSize);
                if (himassDirSize < 10000000) //10M
                {
                    continue;
                }
                bool isExistHiMassExe = System.IO.File.Exists(dirPath + "\\HiMass.exe");
                bool isExistParaDir = Directory.Exists(dirPath + "\\Parameter");
                if (isExistHiMassExe && isExistParaDir)
                {
                    InstallerClass.Logger("Install dir size =" + himassDirSize);
                    //MainLogHelper.Instance.Info("Install dir size =" + himassDirSize);
                    return dirPath;
                }

            }
            himassDirSize = 0;
            return null;
        }
        /// <summary>
        /// 从rootDirPath中，找到名称为dirName的子文件夹，只搜寻两层
        /// </summary>
        /// <param name="dirName">要寻找的文件夹名称</param>
        /// <param name="rootDirPath">被搜寻的文件夹路径</param>
        /// <returns>目标文件夹的完整路径</returns>
        public static string FindDir(string dirName, string rootDirPath)
        {
            try
            {

                List<String> list = new List<string>();

                if (rootDirPath == null || rootDirPath == "" || dirName == "" || dirName == null)
                {
                    //InstallerClass.Logger("Find install directory failed. Parameter is null or empty");
                    //MainLogHelper.Instance.Error("Find install directory failed. Parameter is null or empty");
                    return null;
                }

                //遍历文件夹
                DirectoryInfo tmpFolder = new DirectoryInfo(rootDirPath);

                //遍历子文件夹
                DirectoryInfo[] dirInfo = GetDirectories(tmpFolder);
                if (dirInfo == null)
                {
                    //InstallerClass.Logger("Find install directory failed. Parameter is out of range.");
                    //MainLogHelper.Instance.Error("Find install directory failed. Parameter is out of range.");
                    return null;
                }

                foreach (DirectoryInfo NextFolder in dirInfo)
                {
                    if (NextFolder.Name == dirName)
                    {
                        return NextFolder.FullName;
                    }
                    else
                    {
                        //遍历子文件夹
                        DirectoryInfo[] thirdDirInfo = GetDirectories(NextFolder);
                        if (thirdDirInfo == null)
                        {
                            continue;
                        }
                        foreach (DirectoryInfo ThirdFolder in thirdDirInfo)
                        {
                            if (ThirdFolder.Name == dirName)
                            {
                                return ThirdFolder.FullName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InstallerClass.Logger(ex.ToString());
                //MainLogHelper.Instance.Error(ex);
            }
            //InstallerClass.Logger("Find install directory failed. Parameter is out of range.");
            //MainLogHelper.Instance.Error("Find install directory failed. Parameter is out of range.");
            return null;
        }

        public static DirectoryInfo[] GetDirectories(DirectoryInfo NextFolder)
        {
            try
            {
                if (!IncludeFileList.Contains(NextFolder.FullName))
                {
                    Console.WriteLine("GetDirectories:" + NextFolder.FullName);
                    //InstallerClass.Logger("GetDirectories:" + NextFolder.FullName);
                    //MainLogHelper.Instance.Error(NextFolder.FullName + " is refused to access.");
                    return null;
                }
                return NextFolder.GetDirectories();
            }
            catch (Exception ex)
            {
                InstallerClass.Logger(ex.ToString());
                //MainLogHelper.Instance.Error(ex);
            }
            return null;

        }

        /// <summary>
        /// 获取某一文件夹的大小,单位字节数
        /// </summary>
        /// <param name="dir">文件夹目录</param>
        /// <param name="dirSize">文件夹大小</param>
        public static void GetDirSizeByPath(string dir, ref long dirSize)
        {
            try
            {

                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                if (dirInfo == null)
                {
                    dirSize = 0;
                }

                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                FileInfo[] files = dirInfo.GetFiles();

                if (dirs != null)
                {
                    foreach (var item in dirs)
                    {
                        GetDirSizeByPath(item.FullName, ref dirSize);
                    }
                }

                if (files != null)
                {
                    foreach (var item in files)
                    {
                        dirSize += item.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                InstallerClass.Logger("Get directory size failed. " + ex.Message);
                //Console.WriteLine("Get directory size failed. " + ex.Message);
            }

        }

        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public static int CopyFolder2(string sourceFolder, string destFolder)
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
                InstallerClass.Logger($"CopyFolder2:{e}");
                return 0;
            }

        }


    }
}
