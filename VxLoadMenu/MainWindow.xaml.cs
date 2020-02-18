using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VxLoadMenu
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tblTest.Text = CVxParsor.VxGetTodayMenu();
        }

        private BitmapImage VxMakeBitmapImageFromDisk(String strUri, UriKind uriKind = UriKind.RelativeOrAbsolute, Image imgStoreTarget = null)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.None;
            bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmapImage.UriSource = new Uri(strUri, uriKind);
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            if (imgStoreTarget != null)
                imgStoreTarget.Source = bitmapImage;

            return bitmapImage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //imgBack.Source = VxMakeBitmapImageFromDisk("pack://application:,,,/VxLoadMenu;component/background.png");
        }
    }
}
