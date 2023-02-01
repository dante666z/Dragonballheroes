using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using SkiaSharp;
namespace Dragonballheroes.VistaModelo
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private ImageSource foto;
        public ImageSource Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                OnpropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }
        protected void SetValue<T>(ref T backingFieled, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingFieled, value))

            {

                return;

            }

            backingFieled = value;

            OnPropertyChanged(propertyName);
        }

        public static string ObtenerColorDominante(SKBitmap bmp)
        {
            int r0 = 0;
            int g0 = 0;
            int b0 = 0;
            int r1 = 0;
            int g1 = 0;
            int b1 = 0;

            int total0 = 0;
            int total1 = 0;

            // Color 1
            for(int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height/2; y++)
                {
                    SKColor clr = bmp.GetPixel(x, y);
                    r0 += clr.Red;
                    g0 += clr.Green;
                    b0 += clr.Blue;
                    total0++;
                }
            }
            r0 /= total0;
            g0 /= total0;
            b0 /= total0;

            // Color 2
            for (int x = 0; x < bmp.Height; x++)
            {
                for (int y = 0; y < bmp.Width / 2; y++)
                {
                    SKColor clr = bmp.GetPixel(y, x);
                    r1 += clr.Red;
                    g1 += clr.Green;
                    b1 += clr.Blue;
                    total1++;
                }
            }
            r1 /= total0;
            g1 /= total0;
            b1 /= total0;
            string color1 = $"#{r0:X2}{g0:X2}{b0:X2}";
            string color2 = $"#{r1:X2}{g1:X2}{b1:X2}";
            string colorUnido = color1 + '|' + color2;
            return colorUnido;
        }
    }
}
