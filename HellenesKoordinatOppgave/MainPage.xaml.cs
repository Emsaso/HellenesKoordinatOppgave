using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using MetadataExtractor;
using Directory = MetadataExtractor.Directory;

namespace HellenesKoordinatOppgave
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetPictureAndMeta();
        }

        public void GetPictureAndMeta()
        {
            foreach (var item in System.IO.Directory.GetFiles("Assets\\CoordinateImages", "*.*").ToList())
            {

                string output = null;

                IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(item);
                foreach (var directory in directories)
                {
                    foreach (var tag in directory.Tags)
                    {
                        if (tag.Name.Contains("Latitude") && !tag.Name.Contains("Ref")
                         || tag.Name.Contains("Longitude") && !tag.Name.Contains("Ref")
                         || tag.Name.Contains("Altitude") && !tag.Name.Contains("Ref")
                         || directory.Name.Contains("DJI Makernote") && tag.Name.Contains("Camera"))
                        {
                            output += ($"{tag.Name} = {tag.Description}\n");
                        }
                    }
                }

                Button selectionButton1 = new Button();
                selectionButton1.Content = item.Remove(0, 24);
                selectionButton1.Click += (sender, args) => Image1.Source = new BitmapImage(new Uri(BaseUri, item));
                selectionButton1.Click += (sender, args) => Description1.Text = output ?? throw new InvalidOperationException();
                selectionButton1.Click += CheckForSimilarity;
                selectionButton1.HorizontalAlignment = HorizontalAlignment.Center;
                Button selectionButton2 = new Button();
                selectionButton2.Content = item.Remove(0, 24);
                selectionButton2.Click += (sender, args) => Image2.Source = new BitmapImage(new Uri(BaseUri, item));
                selectionButton2.Click += (sender, args) => Description2.Text = output ?? throw new InvalidOperationException();
                selectionButton2.Click += CheckForSimilarity;
                selectionButton2.HorizontalAlignment = HorizontalAlignment.Center;

                StackPanel1.Children.Add(selectionButton1);
                StackPanel2.Children.Add(selectionButton2);
            }
        }

        private void CheckForSimilarity(object sender, RoutedEventArgs e)
        {
            if (Description1.Text == Description2.Text)
            {
                EqualityChecker.Text = "Pictures are taken in the same spot.";
            }
            else
            {
                EqualityChecker.Text = "";
            }
        }
    }
}
