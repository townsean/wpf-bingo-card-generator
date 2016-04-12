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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BingoCardGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new BingoCardGeneratorVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < _bingoCardsListBox.Items.Count; x++)
            {
                // http://msdn.microsoft.com/en-us/library/system.windows.controls.itemcontainergenerator(v=vs.110).aspx
                ListBoxItem bingoCard = (ListBoxItem)_bingoCardsListBox.ItemContainerGenerator.ContainerFromIndex(x);

                Size size = bingoCard.RenderSize;

                // http://msdn.microsoft.com/en-us/library/aa969819.aspx
                RenderTargetBitmap bitmap = new RenderTargetBitmap((int)bingoCard.ActualHeight, (int)bingoCard.ActualHeight, 96, 96, PixelFormats.Pbgra32);

                // http://go4answers.webhost4life.com/Example/renderbitmap-get-bitmap-entire-29564.aspx
                bingoCard.Measure(size);
                bingoCard.Arrange(new Rect(size));

                bitmap.Render(bingoCard);

                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(bitmap));

                using (Stream stream = File.Create(string.Format("{0}.png", x)))
                {
                    png.Save(stream);
                }
            }
        }
    }
}
