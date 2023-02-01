using System;
using System.Collections.Generic;
using System.Text;
using Dragonballheroes.Modelo;
using System.Threading.Tasks;
using Dragonballheroes.Conexiones;
using System.Linq;
namespace Dragonballheroes.Datos
{
    public class Dlista
    {
        public async Task <List<Mlista>> Mostrar()
        {
            return (await Cconexion.firebase.Child("Lista")
                .OnceAsync<Mlista>()).Select(item => new Mlista
                {
                    Icono = item.Object.Icono
                }).ToList();
        }
    }
}
