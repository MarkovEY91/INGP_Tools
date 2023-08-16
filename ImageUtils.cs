using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.Windows;

namespace INGP_Tools
{
    public static class ImageUtils
    {



        public static ImageSource GetImageByResource(Bitmap source)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(
                source.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );
        }

        public static BitmapImage GetBitmapImage(string path, string iconName)
        {
            BitmapImage img = new BitmapImage(new Uri(path + iconName));
            return img;
        }
    }
}
