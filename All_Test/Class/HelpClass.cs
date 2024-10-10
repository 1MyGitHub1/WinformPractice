using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace All_Test.Class
{
    public class Thread_HelpClass : Form1
    {
        //Form1 form1 = new Form1();
        public void fun1()
        {
            long longsecondss = DateTime.Now.Ticks / 10000;
            while ((DateTime.Now.Ticks / 10000 - longsecondss) / 1000 < 5)
            {
                Thread.Sleep(1000);
            }
            //for (int i = 0; i < 2; i++)
            //{
            //    GlobalInfo.Instance.fun1num++;
            //}
        }
        public void fun2()
        {
            for (int i = 0; i < 2; i++)
            {
                GlobalInfo.Instance.fun2num++;
            }
        }
    }

    public class Files_HelpClass
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
                    //InstallerClass.Logger("Install dir size =" + himassDirSize);
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
                //InstallerClass.Logger(ex.ToString());
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
                    //InstallerClass.Logger(NextFolder.FullName + " is refused to access.");
                    //MainLogHelper.Instance.Error(NextFolder.FullName + " is refused to access.");
                    return null;
                }
                return NextFolder.GetDirectories();
            }
            catch (Exception ex)
            {
                //InstallerClass.Logger(ex.ToString());

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
                Console.WriteLine("Get directory size failed. " + ex.Message);
            }

        }
    }

}
