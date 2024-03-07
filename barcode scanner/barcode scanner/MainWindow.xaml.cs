using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;

namespace barcode_scanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Drawing.Image img = null;
                BitmapImage bimg = new BitmapImage();
                using (var ms = new MemoryStream())
                {
                    BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.CODE_93 };
                    writer.Options.Height = 80;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    img = writer.Write(this.txtbarcodecontent.Text);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = null;
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.imgbarcode.Source = bimg;// return File(ms.ToArray(), "image/jpeg");  
                    this.tbkbarcodecontent.Text = this.txtbarcodecontent.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


}
