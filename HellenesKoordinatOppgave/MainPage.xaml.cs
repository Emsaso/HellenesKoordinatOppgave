using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Directory = MetadataExtractor.Directory;
//using Directory = System.IO.Directory;
using Image = Windows.UI.Xaml.Controls.Image;
//using System.Drawing.Imaging;
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
       

            IEnumerable<Directory> directories1 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0025.JPG");
            IEnumerable<Directory> directories2 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0027.JPG");
            IEnumerable<Directory> directories3 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0028.JPG");

            foreach (var directory in directories1) foreach (var tag in directory.Tags) if (tag.Name.Contains("GPS")) txt1.Text += ($"{directory.Name} - {tag.Name} = {tag.Description}\n");
            foreach (var directory in directories2) foreach (var tag in directory.Tags) if (tag.Name.Contains("GPS")) txt2.Text += ($"{directory.Name} - {tag.Name} = {tag.Description}\n");
            foreach (var directory in directories3) foreach (var tag in directory.Tags) if (tag.Name.Contains("GPS")) txt3.Text += ($"{directory.Name} - {tag.Name} = {tag.Description}\n"); 
            
            //var subIfdDirectory1 = directories1.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            //var subIfdDirectory2 = directories2.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            //var subIfdDirectory3 = directories3.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            //var dateTime1 = subIfdDirectory1?.GetDescription(ExifDirectoryBase.TagAperture);
            //var dateTime2 = subIfdDirectory2?.GetDescription(ExifDirectoryBase.Tag35MMFilmEquivFocalLength);
            //var dateTime3 = subIfdDirectory3?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);
            //txt1.Text = dateTime1 ?? "No Info";
            //txt2.Text = dateTime2 ?? "No Info";
            //txt3.Text = dateTime3 ?? "No Info";


        }
    }
}
