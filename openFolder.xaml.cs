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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// openFolder.xaml 的交互逻辑
    /// </summary>
    public partial class openFolder : Window
    {
        public openFolder()
        {
            InitializeComponent();
            LoadDrive();
        }

        private void LoadDrive()
        {
            string driveName = string.Empty;
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo i in s)
            {
                if (i.DriveType == DriveType.Removable)
                {
                    RadioButton r = new RadioButton();
                    r.Click += C_Click;
                    r.Content = i.Name.ToUpper();
                    stackPanelMain.Children.Add(r);
                }
            }
        }
        public string _tmepChecked = string.Empty;
        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton c = sender as RadioButton;
                _tmepChecked = c.Content.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(_tmepChecked);
        }
    }
}
