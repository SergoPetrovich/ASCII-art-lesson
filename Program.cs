using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASCII_art_lesson
{
    internal class Program
    {
        private const double WIGHT_OFFSET = 1.5;

        [STAThread]
        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
            };
            //openFileDialog.ShowDialog();
            Console.WriteLine("Press OK");
            while (true)
            {
                Console.ReadLine();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();
                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayscale();
                var converter = new BitmapToASCIIConverter(bitmap);
                var rows = converter.Convert();

                foreach (var row in rows)
                    Console.WriteLine(row);
                Console.SetCursorPosition(0, 0);
                //char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };

            }

        }
        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var maxWight = 350;
            var newHeight = bitmap.Height/ WIGHT_OFFSET * maxWight/bitmap.Width;
            if (bitmap.Width > maxWight || bitmap.Height > newHeight)
                bitmap=new Bitmap(bitmap, new Size(maxWight,(int)newHeight));
            return bitmap;
        }
    
    }
}
