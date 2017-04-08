using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAlgs.MaxciSkeletonization
{
    /// <summary>
    /// Класс, реализующий алгоритм скелетизации изображения
    /// </summary>
    public static class Skeletonization
    {
        /// <summary>
        /// Запустить алгоритм скелетизации изображения
        /// </summary>
        /// <param name="bitmap">Ссылка на изображение</param>
        /// <returns>Скелетизированное изображение</returns>
        /// <exception cref="ArgumentNullException">Не указана ссылка на изображение</exception>
        public static Bitmap Run(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");



            return bitmap;
        }
    }
}
