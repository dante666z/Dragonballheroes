using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Dragonballheroes.Datos;
using Dragonballheroes.Modelo;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.IO;
using SkiaSharp;
using System.ComponentModel;

namespace Dragonballheroes.VistaModelo
{
    public class VMlista : BaseViewModel
    {
        #region VARIABLES
        List<Mlista> _lista;
        SKBitmap bitmap;
        string _color;
        int _indexSelected;
        string _imagen;
        string _color1;
        string _color2;
        #endregion

        #region CONSTRUCTOR
        public VMlista(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().Transparente();
            Mostrar();
        }
        #endregion
        #region OBJETOS
        public string Color1
        {
            get { return _color1; }
            set { SetValue(ref _color1, value); }
        }
        public string Color2        {
            get { return _color2; }
            set { SetValue(ref _color2, value); }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        public string Color
        {
            get { return _color; }
            set { SetValue(ref _color, value); }
        }
        public List<Mlista> Lista
        {
            get { return _lista; }
            set { SetValue(ref _lista, value); }
        }
        #endregion

        #region PROCESOS
        public async Task ObtenerColorPrimerImagen()
        {
            try
            {
                Imagen = Lista[0].Icono;
                Color = await ObtenerColores(Imagen);
                string[] c = Color.Split('|');
                Color1 = c[0];
                Color2 = c[1];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DesplazarCardView(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedIndex"))
            {
                var index = ((PanCardView.CoverFlowView)sender).SelectedIndex;
                if (index != _indexSelected)
                {
                    _indexSelected = index;
                    try
                    {
                        Imagen = Lista[_indexSelected].Icono;
                        Color = await ObtenerColores(Imagen);
                        string[] c = Color.Split('|');
                        Color1 = c[0];
                        Color2 = c[1];
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        public async Task <string> ObtenerColores(string url)
        {
            HttpClient client = new HttpClient();
            string Url = url;
            using (Stream stream = await client.GetStreamAsync(Url))
            using (MemoryStream memori = new MemoryStream())
            {
                await stream.CopyToAsync(memori);
                memori.Seek(0, SeekOrigin.Begin);
                bitmap = SKBitmap.Decode(memori);
                var colorUnido = ObtenerColorDominante(bitmap);
                Color = colorUnido;
            }
            return Color;
        }
        public async Task Mostrar()
        {
            var funcion = new Dlista();
            Lista = await funcion.Mostrar();
            await ObtenerColorPrimerImagen();
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
