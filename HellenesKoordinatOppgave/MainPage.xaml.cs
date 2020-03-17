using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Image = Windows.UI.Xaml.Controls.Image;
using System.Drawing.Imaging;
//using System.Windows.Forms;


namespace HellenesKoordinatOppgave
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetImageData();
        }

        public void GetImageData()
        {
            Image image1 = new Image();
            Image image2 = new Image();
            Image image3 = new Image();
            StackPanel1.Children.Add(image1);
            StackPanel3.Children.Add(image2);
            StackPanel5.Children.Add(image3);
            image1.Source = new BitmapImage(new Uri(image1.BaseUri, "Assets/DJI_0025.JPG"));
            image2.Source = new BitmapImage(new Uri(image2.BaseUri, "Assets/DJI_0027.JPG"));
            image3.Source = new BitmapImage(new Uri(image3.BaseUri, "Assets/DJI_0028.JPG"));

            TextBlock txt1 = new TextBlock();
            TextBlock txt2 = new TextBlock();
            TextBlock txt3 = new TextBlock();
            StackPanel2.Children.Add(txt1);
            StackPanel4.Children.Add(txt2);
            StackPanel6.Children.Add(txt3);
            FileInfo info1 = new FileInfo("Assets/DJI_0025.JPG");
            FileInfo info2 = new FileInfo("Assets/DJI_0027.JPG");
            FileInfo info3 = new FileInfo("Assets/DJI_0028.JPG");
            txt1.Text = info1.FullName;
            txt2.Text = info2.FullName;
            txt3.Text = info3.FullName;
            txt1.Text += "\n" + info1.Directory.Name + "\\" + info1.Name;
            txt2.Text += "\n" + info2.Directory.Name + "\\" + info2.Name;
            txt3.Text += "\n" + info3.Directory.Name + "\\" + info3.Name;

            //Image theImage = new Image();
            //theImage.Source = new BitmapImage(new Uri(image1.BaseUri, "Assets/DJI_0025.JPG"));
            //PropertyItem[] propItems = theImage.PropertyItems;

            //ImageProperties props = await info1.Properties.GetImagePropertiesAsync();

        }

        //private void ExtractMetaData(PaintEventArgs e)
        //{
        //}
    }
}
