using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dragonballheroes.VistaModelo
{
    public class VMpatron : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public VMpatron( INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {
            
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
