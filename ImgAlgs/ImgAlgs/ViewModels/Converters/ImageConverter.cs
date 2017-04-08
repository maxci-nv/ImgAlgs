using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ImgAlgs.ViewModels.Converters
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return Bitmap2BitmapSource((Bitmap)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return BitmapImage2Bitmap((BitmapSource)value);
        }

        /// <summary>
        /// Возвращает источник данных для указанного изображения
        /// </summary>
        /// <param name="bitmap">Изображение</param>
        /// <returns>Источник данных</returns>
        public static BitmapSource Bitmap2BitmapSource(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bitmap.GetHbitmap(),
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions()
                );
            }
        }

        /// <summary>
        /// Возвращает ссылку на изображение для указанного источника данных
        /// </summary>
        /// <param name="bitmapImage">Источник данных</param>
        /// <returns>Изображение</returns>
        public static Bitmap BitmapImage2Bitmap(BitmapSource bitmapImage)
        {
            if (bitmapImage == null)
                throw new ArgumentNullException("bitmapImage");

            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                var bitmap = new Bitmap(outStream);
                return bitmap;
            }
        }
    }
}
