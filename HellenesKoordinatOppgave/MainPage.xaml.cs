using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using MetadataExtractor;
using Directory = MetadataExtractor.Directory;
using Image = Windows.UI.Xaml.Controls.Image;


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


            IEnumerable<Directory> directories1 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0025.JPG");
            IEnumerable<Directory> directories2 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0027.JPG");
            IEnumerable<Directory> directories3 = ImageMetadataReader.ReadMetadata("Assets\\DJI_0028.JPG");
            string temp1 = "";
            string temp2 = "";
            string temp3 = "";
            foreach (var directory in directories1)
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name.Contains("Latitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Longitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Altitude") && !tag.Name.Contains("Ref"))
                    {
                        var output = ($"{tag.Name} = {tag.Description}\n").Remove(0, 4);
                        txt1.Text += output;
                        temp1 += output;
                    }
                }
            foreach (var directory in directories2)
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name.Contains("Latitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Longitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Altitude") && !tag.Name.Contains("Ref"))
                    {
                        var output = ($"{tag.Name} = {tag.Description}\n").Remove(0, 4);
                        txt2.Text += output;
                        temp2 += output;
                    }
                }
            foreach (var directory in directories3)
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name.Contains("Latitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Longitude") && !tag.Name.Contains("Ref")
                        || tag.Name.Contains("Altitude") && !tag.Name.Contains("Ref"))
                    {
                        var output = ($"{tag.Name} = {tag.Description}\n").Remove(0, 4);
                        txt3.Text += output;
                        temp3 += output;
                    }
                }

            if (temp1 == temp2)
            {
                txt1.Text += "\nPicture 1 & 2 are taken at the same place";
                txt2.Text += "\nPicture 2 & 1 are taken at the same place";
            }
            if (temp2 == temp3)
            {
                txt2.Text += "\nPicture 2 & 3 are taken at the same place";
                txt3.Text += "\nPicture 3 & 2 are taken at the same place";

            }
            if (temp3 == temp1)
            {
                txt3.Text += "\nPicture 3 & 1 are taken at the same place";
                txt1.Text += "\nPicture 1 & 3 are taken at the same place";
            }
        }
    }
}
