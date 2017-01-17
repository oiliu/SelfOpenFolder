using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //943195e7-d830-47a1-ada6-d9026d3fd84e_B_01.mp4
            object o = "943195e7-d830-47a1-ada6-d9026d3fd84e_B_01.mp4";
            string s = o.ToString();
            System.Windows.Forms.MessageBox.Show(s.Substring(s.IndexOf("_") + 1, s.Length - s.IndexOf(".")));
        }

        private void CopyFileToDiskDirve(string targetPathFileName)
        {
            //检查盘符是否存在
            bool isExistsUDrive = false;
            string driveName = string.Empty;
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo i in s)
            {
                if (i.DriveType == DriveType.Removable)
                {
                    driveName = i.Name;
                    isExistsUDrive = true;
                    break;
                }
            }
            if (isExistsUDrive)
            {
                if (!Directory.Exists(driveName + "自定义文件夹"))
                {
                    Directory.CreateDirectory(driveName + "自定义文件夹");
                }
                string sourcePath = "";
                string targetPath = targetPathFileName;
                // true=覆盖已存在的同名文件,false则反之
                bool isrewrite = true;
                File.Copy(sourcePath, targetPath, isrewrite);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("不存在移动盘！");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;

            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool isRemovable = false;
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo i in s)
            {
                if (i.DriveType == DriveType.Removable)
                {
                    isRemovable = true;
                    break;
                }
            }
            if (isRemovable)
            {
                openFolder o = new openFolder();
                o.Closed += O_Closed;
                o.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("没有移动盘!");
            }
        }

        private void O_Closed(object sender, EventArgs e)
        {
            if (sender is openFolder)
            {
                openFolder openF = sender as openFolder;
                if (openF._tmepChecked != "")
                {
                    System.Windows.MessageBox.Show("您选择了 " + openF._tmepChecked + ",这个地址；");
                }
            }
        }
    }
}
