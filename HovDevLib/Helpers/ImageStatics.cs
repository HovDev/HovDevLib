using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HovDevLib.Helpers
{
    public static class ImageStatics
    {
        /// <summary>
        ///     Преобразует System.Drawing.Icon в System.Windows.Media.ImageSource
        /// </summary>
        /// <param name="icon">Входящая иконки System.Drawing.Icon</param>
        /// <returns>Иконка, преобразованная в System.Windows.Media.ImageSource</returns>
        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }
    }
}