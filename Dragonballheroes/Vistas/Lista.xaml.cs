using Dragonballheroes.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dragonballheroes.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        VMlista vm;
        public Lista()
        {
            vm = new VMlista(Navigation);
            BindingContext = vm;
            InitializeComponent();
        }

        private async void Desplazamiento(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await vm.DesplazarCardView(sender, e);
        }
    }
}