using Microsoft.Win32;
using System.Drawing;
using System.Windows.Input;
using System;
using ImgAlgs.MaxciSkeletonization;

namespace ImgAlgs.ViewModels
{
    /// <summary>
    /// Основная модель представления
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region FIELDS

        private string _fileName;
        private Bitmap _imgOriginal;
        private Bitmap _imgSkeletonization;

        #endregion


        #region PROPERTIES

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Bitmap ImgOriginal
        {
            get { return _imgOriginal; }
            set
            {
                if (_imgOriginal != value)
                {
                    _imgOriginal = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Bitmap ImgSkeletonization
        {
            get { return _imgSkeletonization; }
            set
            {
                if (_imgSkeletonization != value)
                {
                    _imgSkeletonization = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region COMMANDS

        private RelayCommand _cmdOpenFile;
        public ICommand OpenFile { get { return _cmdOpenFile ?? (_cmdOpenFile = new RelayCommand(param => openFile(param))); } }

        #endregion

        /// <summary>
        /// Загружаем картинку 
        /// </summary>
        private void openFile(object parameters)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".jpg, .jpeg, .gif, .bmp, .png|*.jpg;*.jpeg;*.gif;*.bmp;*.png|*.*|*.*";
            ofd.Multiselect = false;
            ofd.InitialDirectory = @"D:\_Downloads_\капча\";

            if (ofd.ShowDialog() == true)
            {
                FileName = ofd.FileName;
                ImgOriginal = new Bitmap(_fileName);
                ImgSkeletonization = Skeletonization.Run(_imgOriginal);
            }
        }
    }
}
